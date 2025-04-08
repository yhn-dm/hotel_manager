using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using HotelManager.Database;
using HotelManager.Models;

namespace HotelManager.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            ChargerStatistiques(); // Lancement dès la création
        }

        private void ChargerStatistiques()
        {
            try
            {
                using (var conn = Database.Database.GetConnection())
                {
                    conn.Open();

                    int userId = Session.UtilisateurConnecte.Id;

                    // Chambres totales
                    var cmd1 = new MySqlCommand("SELECT COUNT(*) FROM chambres WHERE utilisateur_id = @utilisateur_id", conn);
                    cmd1.Parameters.AddWithValue("@utilisateur_id", userId);
                    lblTotalChambres.Text = "Chambres totales : " + cmd1.ExecuteScalar().ToString();

                    // Chambres libres
                    var cmd2 = new MySqlCommand("SELECT COUNT(*) FROM chambres WHERE statut = 'libre' AND utilisateur_id = @utilisateur_id", conn);
                    cmd2.Parameters.AddWithValue("@utilisateur_id", userId);
                    lblLibres.Text = "Chambres libres et propres : " + cmd2.ExecuteScalar().ToString();

                    // Chambres à nettoyer
                    var cmd3 = new MySqlCommand("SELECT COUNT(*) FROM chambres WHERE statut = 'à nettoyer' AND utilisateur_id = @utilisateur_id", conn);
                    cmd3.Parameters.AddWithValue("@utilisateur_id", userId);
                    lblNettoyer.Text = "Chambres à nettoyer : " + cmd3.ExecuteScalar().ToString();

                    // Clients arrivés aujourd’hui (en fonction des réservations de l’utilisateur)
                    var today = DateTime.Today.ToString("yyyy-MM-dd");
                    var cmd4 = new MySqlCommand(@"
                SELECT COUNT(*) FROM reservations r
                JOIN chambres ch ON r.id_chambre = ch.id
                WHERE r.date_arrivee = @today AND ch.utilisateur_id = @utilisateur_id", conn);
                    cmd4.Parameters.AddWithValue("@today", today);
                    cmd4.Parameters.AddWithValue("@utilisateur_id", userId);
                    lblArrives.Text = "Clients arrivés aujourd’hui : " + cmd4.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des statistiques : " + ex.Message);
            }
        }


        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblNettoyer_Click(object sender, EventArgs e)
        {

        }
    }
}
