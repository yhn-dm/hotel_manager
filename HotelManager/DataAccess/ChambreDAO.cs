using System;
using System.Collections.Generic;
using HotelManager.Models;
using MySql.Data.MySqlClient;
using HotelManager.Database;

namespace HotelManager.DataAccess
{
    public class ChambreDAO
    {
        public List<Chambre> GetAll()
        {
            var chambres = new List<Chambre>();
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM chambres WHERE utilisateur_id = @utilisateur_id", conn);
                cmd.Parameters.AddWithValue("@utilisateur_id", Session.UtilisateurConnecte.Id);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    chambres.Add(new Chambre
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Numero = reader["numero"].ToString(),
                        Type = reader["type"].ToString(),
                        Tarif = Convert.ToDecimal(reader["tarif"]),
                        Statut = reader["statut"].ToString()
                    });
                }
            }
            return chambres;
        }

        public Chambre GetById(int id)
        {
            Chambre chambre = null;
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM chambres WHERE id = @id AND utilisateur_id = @utilisateur_id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@utilisateur_id", Session.UtilisateurConnecte.Id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        chambre = new Chambre
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Numero = reader["numero"].ToString(),
                            Type = reader["type"].ToString(),
                            Tarif = Convert.ToDecimal(reader["tarif"]),
                            Statut = reader["statut"].ToString()
                        };
                    }
                }
            }

            return chambre;
        }

        public void Add(Chambre chambre)
        {
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO chambres (numero, type, tarif, statut, utilisateur_id) VALUES (@numero, @type, @tarif, @statut, @utilisateur_id)", conn);
                cmd.Parameters.AddWithValue("@numero", chambre.Numero);
                cmd.Parameters.AddWithValue("@type", chambre.Type);
                cmd.Parameters.AddWithValue("@tarif", chambre.Tarif);
                cmd.Parameters.AddWithValue("@statut", chambre.Statut);
                cmd.Parameters.AddWithValue("@utilisateur_id", Session.UtilisateurConnecte.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Chambre chambre)
        {
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE chambres SET numero = @numero, type = @type, tarif = @tarif, statut = @statut WHERE id = @id AND utilisateur_id = @utilisateur_id", conn);
                cmd.Parameters.AddWithValue("@id", chambre.Id);
                cmd.Parameters.AddWithValue("@numero", chambre.Numero);
                cmd.Parameters.AddWithValue("@type", chambre.Type);
                cmd.Parameters.AddWithValue("@tarif", chambre.Tarif);
                cmd.Parameters.AddWithValue("@statut", chambre.Statut);
                cmd.Parameters.AddWithValue("@utilisateur_id", Session.UtilisateurConnecte.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM chambres WHERE id = @id AND utilisateur_id = @utilisateur_id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@utilisateur_id", Session.UtilisateurConnecte.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
