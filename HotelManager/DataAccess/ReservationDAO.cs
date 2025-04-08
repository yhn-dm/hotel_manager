using System;
using System.Collections.Generic;
using HotelManager.Models;
using MySql.Data.MySqlClient;
using HotelManager.Database;
using System.Windows.Forms;

namespace HotelManager.DataAccess
{
    public class ReservationDAO
    {
        public List<Reservation> GetAll()
        {
            var reservations = new List<Reservation>();
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(@"
                SELECT r.*, c.nom AS nom_client, c.prenom AS prenom_client, ch.numero AS numero_chambre 
                FROM reservations r
                JOIN clients c ON r.id_client = c.id
                JOIN chambres ch ON r.id_chambre = ch.id
                WHERE r.utilisateur_id = @utilisateur_id", conn);

                cmd.Parameters.AddWithValue("@utilisateur_id", Session.UtilisateurConnecte.Id);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    reservations.Add(new Reservation
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        IdClient = Convert.ToInt32(reader["id_client"]),
                        IdChambre = Convert.ToInt32(reader["id_chambre"]),
                        DateArrivee = Convert.ToDateTime(reader["date_arrivee"]),
                        DateDepart = Convert.ToDateTime(reader["date_depart"]),
                        Statut = reader["statut"].ToString(),
                        NomClient = $"{reader["prenom_client"]} {reader["nom_client"]}",
                        NumeroChambre = reader["numero_chambre"].ToString()
                    });
                }
            }
            return reservations;
        }

        public List<Reservation> GetByChambreId(int chambreId)
        {
            var list = new List<Reservation>();
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(@"
                SELECT r.*, c.nom AS nom_client, c.prenom AS prenom_client
                FROM reservations r
                JOIN clients c ON r.id_client = c.id
                WHERE r.id_chambre = @id AND r.utilisateur_id = @utilisateur_id", conn);

                cmd.Parameters.AddWithValue("@id", chambreId);
                cmd.Parameters.AddWithValue("@utilisateur_id", Session.UtilisateurConnecte.Id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Reservation
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            IdClient = Convert.ToInt32(reader["id_client"]),
                            IdChambre = Convert.ToInt32(reader["id_chambre"]),
                            DateArrivee = Convert.ToDateTime(reader["date_arrivee"]),
                            DateDepart = Convert.ToDateTime(reader["date_depart"]),
                            Statut = reader["statut"].ToString(),
                            NomClient = $"{reader["prenom_client"]} {reader["nom_client"]}"
                        });
                    }
                }
            }
            return list;
        }

        public List<Reservation> GetByClientId(int clientId)
        {
            var list = new List<Reservation>();
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(@"
                SELECT r.*, ch.numero AS numero_chambre 
                FROM reservations r
                JOIN chambres ch ON r.id_chambre = ch.id
                WHERE r.id_client = @id AND r.utilisateur_id = @utilisateur_id", conn);

                cmd.Parameters.AddWithValue("@id", clientId);
                cmd.Parameters.AddWithValue("@utilisateur_id", Session.UtilisateurConnecte.Id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Reservation
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            IdClient = Convert.ToInt32(reader["id_client"]),
                            IdChambre = Convert.ToInt32(reader["id_chambre"]),
                            DateArrivee = Convert.ToDateTime(reader["date_arrivee"]),
                            DateDepart = Convert.ToDateTime(reader["date_depart"]),
                            Statut = reader["statut"].ToString(),
                            NumeroChambre = reader["numero_chambre"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public void Add(Reservation r)
        {
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                try
                {
                    var cmd = new MySqlCommand(@"
                    INSERT INTO reservations 
                    (id_client, id_chambre, date_arrivee, date_depart, statut, utilisateur_id) 
                    VALUES (@id_client, @id_chambre, @date_arrivee, @date_depart, @statut, @utilisateur_id)", conn);

                    cmd.Parameters.AddWithValue("@id_client", r.IdClient);
                    cmd.Parameters.AddWithValue("@id_chambre", r.IdChambre);
                    cmd.Parameters.AddWithValue("@date_arrivee", r.DateArrivee);
                    cmd.Parameters.AddWithValue("@date_depart", r.DateDepart);
                    cmd.Parameters.AddWithValue("@statut", r.Statut);
                    cmd.Parameters.AddWithValue("@utilisateur_id", Session.UtilisateurConnecte.Id);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur SQL (Add) : " + ex.Message);
                }
            }
        }

        public void Update(Reservation r)
        {
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(@"
                UPDATE reservations SET 
                id_client = @id_client, 
                id_chambre = @id_chambre, 
                date_arrivee = @date_arrivee, 
                date_depart = @date_depart, 
                statut = @statut
                WHERE id = @id AND utilisateur_id = @utilisateur_id", conn);

                cmd.Parameters.AddWithValue("@id", r.Id);
                cmd.Parameters.AddWithValue("@id_client", r.IdClient);
                cmd.Parameters.AddWithValue("@id_chambre", r.IdChambre);
                cmd.Parameters.AddWithValue("@date_arrivee", r.DateArrivee);
                cmd.Parameters.AddWithValue("@date_depart", r.DateDepart);
                cmd.Parameters.AddWithValue("@statut", r.Statut);
                cmd.Parameters.AddWithValue("@utilisateur_id", Session.UtilisateurConnecte.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM reservations WHERE id = @id AND utilisateur_id = @utilisateur_id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@utilisateur_id", Session.UtilisateurConnecte.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }

}
