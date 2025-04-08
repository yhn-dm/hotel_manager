using System;
using System.Collections.Generic;
using HotelManager.Models;
using MySql.Data.MySqlClient;
using HotelManager.Database;

namespace HotelManager.DataAccess
{
    public class ClientDAO
    {
        public List<Client> GetAll()
        {
            var clients = new List<Client>();
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM clients WHERE utilisateur_id = @utilisateur_id", conn);
                cmd.Parameters.AddWithValue("@utilisateur_id", Session.UtilisateurConnecte.Id);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new Client
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nom = reader["nom"].ToString(),
                        Prenom = reader["prenom"].ToString(),
                        Telephone = reader["telephone"].ToString(),
                        Email = reader["email"].ToString()
                    });
                }
            }
            return clients;
        }

        public void Add(Client client)
        {
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO clients (nom, prenom, telephone, email, utilisateur_id) VALUES (@nom, @prenom, @telephone, @email, @utilisateur_id)", conn);
                cmd.Parameters.AddWithValue("@nom", client.Nom);
                cmd.Parameters.AddWithValue("@prenom", client.Prenom);
                cmd.Parameters.AddWithValue("@telephone", client.Telephone);
                cmd.Parameters.AddWithValue("@email", client.Email);
                cmd.Parameters.AddWithValue("@utilisateur_id", Session.UtilisateurConnecte.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Client client)
        {
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE clients SET nom = @nom, prenom = @prenom, telephone = @telephone, email = @email WHERE id = @id AND utilisateur_id = @utilisateur_id", conn);
                cmd.Parameters.AddWithValue("@id", client.Id);
                cmd.Parameters.AddWithValue("@nom", client.Nom);
                cmd.Parameters.AddWithValue("@prenom", client.Prenom);
                cmd.Parameters.AddWithValue("@telephone", client.Telephone);
                cmd.Parameters.AddWithValue("@email", client.Email);
                cmd.Parameters.AddWithValue("@utilisateur_id", Session.UtilisateurConnecte.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM clients WHERE id = @id AND utilisateur_id = @utilisateur_id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@utilisateur_id", Session.UtilisateurConnecte.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
