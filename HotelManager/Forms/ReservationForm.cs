using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using HotelManager.Models;
using HotelManager.DataAccess;
using System.Linq;

namespace HotelManager.Forms
{
    public partial class ReservationForm : Form
    {
        private ReservationDAO reservationDAO = new ReservationDAO();
        private ClientDAO clientDAO = new ClientDAO();
        private ChambreDAO chambreDAO = new ChambreDAO();
        private int selectedReservationId = -1;

        public ReservationForm()
        {
            InitializeComponent();
            LoadData();
            LoadComboBoxes();
            cmbChambre.SelectedIndexChanged += CmbChambre_SelectedIndexChanged;
            InitFilter();
        }

        private void LoadData()
        {
            dataGridReservations.DataSource = reservationDAO.GetAll();
            dataGridReservations.Columns["Id"].Visible = false;

            PersonnaliserColonnesReservations();
        }
        private void PersonnaliserColonnesReservations()
        {
            dataGridReservations.Columns["Id"].HeaderText = "Réservation #";
            dataGridReservations.Columns["IdClient"].HeaderText = "Client ID";
            dataGridReservations.Columns["IdChambre"].HeaderText = "Chambre ID";
            dataGridReservations.Columns["DateArrivee"].HeaderText = "Date d'arrivée";
            dataGridReservations.Columns["DateDepart"].HeaderText = "Date de départ";
            dataGridReservations.Columns["Statut"].HeaderText = "Présence";
            dataGridReservations.Columns["NomClient"].HeaderText = "Client";
            dataGridReservations.Columns["NumeroChambre"].HeaderText = "Chambre";
        }
        private void InitFilter()
        {
            cmbFiltre.Items.Clear();
            cmbFiltre.Items.AddRange(new[] { "Toutes sauf passées", "À venir", "En cours", "Passées" });
            cmbFiltre.SelectedIndex = 0;
            cmbFiltre.SelectedIndexChanged += cmbFiltre_SelectedIndexChanged;
        }
        private void LoadComboBoxes()
        {

            
            cmbClient.Items.Clear();
            foreach (var client in clientDAO.GetAll())
                cmbClient.Items.Add(new ComboBoxItem(client.NomComplet, client.Id));

            cmbChambre.Items.Clear();
            foreach (var chambre in chambreDAO.GetAll())
                cmbChambre.Items.Add(new ComboBoxItem(chambre.ToString(), chambre.Id));

            cmbStatut.Items.Clear();
            cmbStatut.Items.AddRange(new[] { "présent", "absent" });
        }

        private void CmbChambre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChambre.SelectedItem is ComboBoxItem selected)
            {
                var chambre = chambreDAO.GetById(selected.Value);
                lblChambreStatut.Text = $"Statut chambre : {chambre.Statut}";
            }
            else
            {
                lblChambreStatut.Text = "Statut chambre : ---";
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (cmbClient.SelectedItem is null)
            {
                MessageBox.Show("Veuillez sélectionner un client.");
                return;
            }

            if (cmbChambre.SelectedItem is null)
            {
                MessageBox.Show("Veuillez sélectionner une chambre.");
                return;
            }

            var statutValide = new[] { "présent", "absent" };
            if (!statutValide.Contains(cmbStatut.Text.ToLower()))
            {
                MessageBox.Show("Veuillez sélectionner un statut valide (présent ou absent).");
                return;
            }

            if (dtpArrivee.Value.Date < DateTime.Today)
            {
                MessageBox.Show("La date d’arrivée ne peut pas être dans le passé.");
                return;
            }

            if (dtpDepart.Value <= dtpArrivee.Value)
            {
                MessageBox.Show("La date de départ doit être postérieure à la date d’arrivée.");
                return;
            }

            var reservation = new Reservation
            {
                IdClient = ((ComboBoxItem)cmbClient.SelectedItem).Value,
                IdChambre = ((ComboBoxItem)cmbChambre.SelectedItem).Value,
                DateArrivee = dtpArrivee.Value,
                DateDepart = dtpDepart.Value,
                Statut = cmbStatut.Text
            };

            reservationDAO.Add(reservation);
            LoadData();
            ResetForm();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (selectedReservationId == -1) return;

            if (cmbClient.SelectedItem is null)
            {
                MessageBox.Show("Veuillez sélectionner un client.");
                return;
            }

            if (cmbChambre.SelectedItem is null)
            {
                MessageBox.Show("Veuillez sélectionner une chambre.");
                return;
            }

            var statutValide = new[] { "présent", "absent" };
            if (!statutValide.Contains(cmbStatut.Text.ToLower()))
            {
                MessageBox.Show("Veuillez sélectionner un statut valide (présent ou absent).");
                return;
            }

            if (dtpArrivee.Value.Date < DateTime.Today)
            {
                MessageBox.Show("La date d’arrivée ne peut pas être dans le passé.");
                return;
            }

            if (dtpDepart.Value <= dtpArrivee.Value)
            {
                MessageBox.Show("La date de départ doit être postérieure à la date d’arrivée.");
                return;
            }

            var reservation = new Reservation
            {
                Id = selectedReservationId,
                IdClient = ((ComboBoxItem)cmbClient.SelectedItem).Value,
                IdChambre = ((ComboBoxItem)cmbChambre.SelectedItem).Value,
                DateArrivee = dtpArrivee.Value,
                DateDepart = dtpDepart.Value,
                Statut = cmbStatut.Text
            };

            reservationDAO.Update(reservation);
            LoadData();
            ResetForm();
        }


        private void btnTerminer_Click(object sender, EventArgs e)
        {
            if (selectedReservationId == -1) return;

            if (MessageBox.Show("Terminer/supprimer cette réservation ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                reservationDAO.Delete(selectedReservationId);
                LoadData();
                ResetForm();
            }
        }

        private void dataGridReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var ligne = dataGridReservations.Rows[e.RowIndex];
                selectedReservationId = Convert.ToInt32(ligne.Cells["Id"].Value);

                var idClient = Convert.ToInt32(ligne.Cells["IdClient"].Value);
                var idChambre = Convert.ToInt32(ligne.Cells["IdChambre"].Value);

                foreach (ComboBoxItem item in cmbClient.Items)
                    if (item.Value == idClient) cmbClient.SelectedItem = item;

                foreach (ComboBoxItem item in cmbChambre.Items)
                    if (item.Value == idChambre) cmbChambre.SelectedItem = item;

                dtpArrivee.Value = Convert.ToDateTime(ligne.Cells["DateArrivee"].Value);
                dtpDepart.Value = Convert.ToDateTime(ligne.Cells["DateDepart"].Value);
                cmbStatut.Text = ligne.Cells["Statut"].Value.ToString();
            }
        }

        private void FiltrerReservations()
        {
            var toutes = reservationDAO.GetAll();
            var maintenant = DateTime.Now;
            var filtre = cmbFiltre.SelectedItem?.ToString();

            List<Reservation> filtrées = toutes;

            switch (filtre)
            {
                case "À venir":
                    filtrées = toutes.FindAll(r => r.DateArrivee > maintenant);
                    break;
                case "En cours":
                    filtrées = toutes.FindAll(r => r.DateArrivee <= maintenant && r.DateDepart >= maintenant);
                    break;
                case "Passées":
                    filtrées = toutes.FindAll(r => r.DateDepart < maintenant);
                    break;
                case "Toutes sauf passées":
                default:
                    filtrées = toutes.FindAll(r => r.DateDepart >= maintenant);
                    break;
            }

            dataGridReservations.DataSource = filtrées;
            if (dataGridReservations.Columns.Contains("Id"))
                dataGridReservations.Columns["Id"].Visible = false;
        }

        private void cmbFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrerReservations();
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            selectedReservationId = -1;
            cmbClient.SelectedIndex = -1;
            cmbChambre.SelectedIndex = -1;
            cmbStatut.SelectedIndex = -1;
            lblChambreStatut.Text = "Statut chambre : ---";
            dtpArrivee.Value = DateTime.Now;
            dtpDepart.Value = DateTime.Now;
            dataGridReservations.ClearSelection();
        }

        private void dataGridReservations_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }


    }



    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public ComboBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString() => Text;
    }
}
