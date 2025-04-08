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
    public partial class ClientForm : Form
    {
        private ClientDAO clientDAO = new ClientDAO();
        private ReservationDAO reservationDAO = new ReservationDAO();

        private int selectedClientId = -1;

        public ClientForm()
        {
            InitializeComponent();
            ChargerClients();
        }

        private void ChargerClients()
        {
            var clients = clientDAO.GetAll();
            dataGridClients.DataSource = clients;
            dataGridClients.Columns["Id"].Visible = false;

            PersonnaliserColonnesClients();

        }
        private void PersonnaliserColonnesClients()
        {
            dataGridClients.Columns["Id"].HeaderText = "Client #";
            dataGridClients.Columns["Nom"].HeaderText = "Nom";
            dataGridClients.Columns["Prenom"].HeaderText = "Prénom";
            dataGridClients.Columns["Telephone"].HeaderText = "Téléphone";
            dataGridClients.Columns["Email"].HeaderText = "Email";
            dataGridClients.Columns["NomComplet"].HeaderText = "Nom complet";
        }

        private void PersonnaliserHistoriqueClient()
        {
            if (dataGridReservationsClient.Columns.Count == 0) return;

            if (dataGridReservationsClient.Columns.Contains("Id"))
                dataGridReservationsClient.Columns["Id"].Visible = false;
            if (dataGridReservationsClient.Columns.Contains("IdClient"))
                dataGridReservationsClient.Columns["IdClient"].Visible = false;
            if (dataGridReservationsClient.Columns.Contains("IdChambre"))
                dataGridReservationsClient.Columns["IdChambre"].Visible = false;
            if (dataGridReservationsClient.Columns.Contains("DateArrivee"))
                dataGridReservationsClient.Columns["DateArrivee"].HeaderText = "Arrivée";
            if (dataGridReservationsClient.Columns.Contains("DateDepart"))
                dataGridReservationsClient.Columns["DateDepart"].HeaderText = "Départ";
            if (dataGridReservationsClient.Columns.Contains("Statut"))
                dataGridReservationsClient.Columns["Statut"].HeaderText = "Présence";
            if (dataGridReservationsClient.Columns.Contains("NumeroChambre"))
                dataGridReservationsClient.Columns["NumeroChambre"].HeaderText = "Chambre";
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Nom et prénom sont obligatoires.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtTelephone.Text, @"^0[1-9](\d{2}){4}$"))
            {
                MessageBox.Show("Le numéro de téléphone doit être valide (ex : 0612345678).");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("L'adresse e-mail n'est pas valide.");
                return;
            }

            var client = new Client
            {
                Nom = txtNom.Text,
                Prenom = txtPrenom.Text,
                Telephone = txtTelephone.Text,
                Email = txtEmail.Text
            };

            clientDAO.Add(client);
            ChargerClients();
            ResetForm();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (selectedClientId == -1) return;

            if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Nom et prénom sont obligatoires.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtTelephone.Text, @"^0[1-9](\d{2}){4}$"))
            {
                MessageBox.Show("Le numéro de téléphone doit être valide (ex : 0612345678).");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("L'adresse e-mail n'est pas valide.");
                return;
            }

            var client = new Client
            {
                Id = selectedClientId,
                Nom = txtNom.Text,
                Prenom = txtPrenom.Text,
                Telephone = txtTelephone.Text,
                Email = txtEmail.Text
            };

            clientDAO.Update(client);
            ChargerClients();
            ResetForm();
        }


        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (selectedClientId == -1) return;

            if (MessageBox.Show("Supprimer ce client ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                clientDAO.Delete(selectedClientId);
                ChargerClients();
                ResetForm();
            }
        }

        private void dataGridClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var ligne = dataGridClients.Rows[e.RowIndex];
                selectedClientId = Convert.ToInt32(ligne.Cells["Id"].Value);
                txtNom.Text = ligne.Cells["Nom"].Value.ToString();
                txtPrenom.Text = ligne.Cells["Prenom"].Value.ToString();
                txtTelephone.Text = ligne.Cells["Telephone"].Value.ToString();
                txtEmail.Text = ligne.Cells["Email"].Value.ToString();

                var reservations = reservationDAO.GetByClientId(selectedClientId);
                dataGridReservationsClient.DataSource = reservations;

                // ⬇️ Important : personnaliser après avoir défini le DataSource
                if (reservations.Count > 0)
                {
                    if (dataGridReservationsClient.Columns.Contains("Id"))
                        dataGridReservationsClient.Columns["Id"].Visible = false;
                }

                PersonnaliserHistoriqueClient(); // 🛠️ Ce call manquait, c'est lui qui applique les noms
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtNom.Text = "";
            txtPrenom.Text = "";
            txtTelephone.Text = "";
            txtEmail.Text = "";
            selectedClientId = -1;
            dataGridClients.ClearSelection();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridReservationsClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
