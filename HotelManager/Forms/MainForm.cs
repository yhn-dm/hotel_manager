using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManager.Forms;


namespace HotelManager.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Méthode appelée au chargement de la fenêtre
        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowForm(new DashboardForm()); // Affiche le dashboard par défaut
        }

        // Affiche dynamiquement un formulaire dans panelMain
        private void ShowForm(Form form)
        {
            panelMain.Controls.Clear();                      // Vide le contenu précédent
            form.TopLevel = false;                           // On ne veut pas une nouvelle fenêtre
            form.FormBorderStyle = FormBorderStyle.None;     // Pas de bordure
            form.Dock = DockStyle.Fill;                      // Prend tout l'espace dispo
            panelMain.Controls.Add(form);                    // Ajoute au panel
            form.Show();                                     // Affiche le form
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowForm(new DashboardForm());
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            ShowForm(new ClientForm());
        }

        private void btnChambres_Click(object sender, EventArgs e)
        {
            ShowForm(new ChambreForm());
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            ShowForm(new ReservationForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vous déconnecter ?", "Déconnexion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                new LoginForm().Show();
            }
        }


        // Événement inutile sauf si tu veux dessiner dans le panel
        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
