using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManager.Models;
using HotelManager.DataAccess;


namespace HotelManager.Forms
{
    public partial class ChambreForm : Form
    {
        private ChambreDAO chambreDAO = new ChambreDAO();
        private ReservationDAO reservationDAO = new ReservationDAO();

        private int selectedChambreId = -1;

        public ChambreForm()
        {
            InitializeComponent();
            LoadComboBoxes();
            ChargerChambres();

            PersonnaliserColonnesChambres();

        }

        private void PersonnaliserColonnesChambres()
        {
            dataGridChambres.Columns["Id"].HeaderText = "Chambre #";
            dataGridChambres.Columns["Numero"].HeaderText = "Numéro";
            dataGridChambres.Columns["Type"].HeaderText = "Type";
            dataGridChambres.Columns["Tarif"].HeaderText = "Tarif (€)";
            dataGridChambres.Columns["Statut"].HeaderText = "État";


        }

        private void PersonnaliserHistoriqueChambre()
        {
            if (dataGridReservationsChambre.Columns.Count == 0) return;

            if (dataGridReservationsChambre.Columns.Contains("Id"))
                dataGridReservationsChambre.Columns["Id"].Visible = false;

            if (dataGridReservationsChambre.Columns.Contains("IdClient"))
                dataGridReservationsChambre.Columns["IdClient"].Visible = false;

            if (dataGridReservationsChambre.Columns.Contains("IdChambre"))
                dataGridReservationsChambre.Columns["IdChambre"].Visible = false;

            if (dataGridReservationsChambre.Columns.Contains("DateArrivee"))
                dataGridReservationsChambre.Columns["DateArrivee"].HeaderText = "Arrivée";

            if (dataGridReservationsChambre.Columns.Contains("DateDepart"))
                dataGridReservationsChambre.Columns["DateDepart"].HeaderText = "Départ";

            if (dataGridReservationsChambre.Columns.Contains("Statut"))
                dataGridReservationsChambre.Columns["Statut"].HeaderText = "Présence";

            if (dataGridReservationsChambre.Columns.Contains("NomClient"))
                dataGridReservationsChambre.Columns["NomClient"].HeaderText = "Client";
        }



        private void LoadComboBoxes()
        {
            cmbType.Items.AddRange(new[] { "simple", "double", "triple" });
            cmbStatut.Items.AddRange(new[] { "libre", "occupée", "à nettoyer" });
        }

        private void ChargerChambres()
        {
            var chambres = chambreDAO.GetAll();
            dataGridChambres.DataSource = chambres;
            dataGridChambres.Columns["Id"].Visible = false;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                MessageBox.Show("Le numéro de la chambre est obligatoire.");
                return;
            }

            if (!decimal.TryParse(txtTarif.Text, out var tarif) || tarif <= 0)
            {
                MessageBox.Show("Le tarif doit être un nombre positif.");
                return;
            }

            var typeValide = new[] { "simple", "double", "triple" };
            if (!typeValide.Contains(cmbType.Text.ToLower()))
            {
                MessageBox.Show("Veuillez sélectionner un type de chambre valide.");
                return;
            }

            var statutValide = new[] { "libre", "occupée", "à nettoyer" };
            if (!statutValide.Contains(cmbStatut.Text.ToLower()))
            {
                MessageBox.Show("Veuillez sélectionner un statut valide.");
                return;
            }

            var chambre = new Chambre
            {
                Numero = txtNumero.Text,
                Type = cmbType.Text,
                Tarif = tarif,
                Statut = cmbStatut.Text
            };

            chambreDAO.Add(chambre);
            ChargerChambres();
            ResetForm();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (selectedChambreId == -1) return;

            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                MessageBox.Show("Le numéro de la chambre est obligatoire.");
                return;
            }

            if (!decimal.TryParse(txtTarif.Text, out var tarif) || tarif <= 0)
            {
                MessageBox.Show("Le tarif doit être un nombre positif.");
                return;
            }

            var typeValide = new[] { "simple", "double", "triple" };
            if (!typeValide.Contains(cmbType.Text.ToLower()))
            {
                MessageBox.Show("Veuillez sélectionner un type de chambre valide.");
                return;
            }

            var statutValide = new[] { "libre", "occupée", "à nettoyer" };
            if (!statutValide.Contains(cmbStatut.Text.ToLower()))
            {
                MessageBox.Show("Veuillez sélectionner un statut valide.");
                return;
            }

            var chambre = new Chambre
            {
                Id = selectedChambreId,
                Numero = txtNumero.Text,
                Type = cmbType.Text,
                Tarif = tarif,
                Statut = cmbStatut.Text
            };

            chambreDAO.Update(chambre);
            ChargerChambres();
            ResetForm();
        }


        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (selectedChambreId == -1) return;

            if (MessageBox.Show("Supprimer cette chambre ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                chambreDAO.Delete(selectedChambreId);
                ChargerChambres();
                ResetForm();
            }
        }

        private void dataGridChambres_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var ligne = dataGridChambres.Rows[e.RowIndex];
                selectedChambreId = Convert.ToInt32(ligne.Cells["Id"].Value);
                txtNumero.Text = ligne.Cells["Numero"].Value.ToString();
                cmbType.Text = ligne.Cells["Type"].Value.ToString();
                txtTarif.Text = ligne.Cells["Tarif"].Value.ToString();
                cmbStatut.Text = ligne.Cells["Statut"].Value.ToString();

                // Charger les réservations liées
                var reservations = reservationDAO.GetByChambreId(selectedChambreId);
                dataGridReservationsChambre.DataSource = reservations;

                // ✅ Personnalisation APRES .DataSource
                PersonnaliserHistoriqueChambre();
            }
        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtNumero.Clear();
            txtTarif.Clear();
            cmbType.SelectedIndex = -1;
            cmbStatut.SelectedIndex = -1;
            selectedChambreId = -1;
            dataGridChambres.ClearSelection();
        }

        private void dataGridChambres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ChambreForm_Load(object sender, EventArgs e)
        {

        }

        private void ChambreForm_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridReservationsChambre_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridChambres_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
