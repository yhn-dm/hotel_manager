using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.Models;
using MySql.Data.MySqlClient;
using HotelManager.Database;

namespace HotelManager.DataAccess
{
    public class UtilisateurDAO
    {
        public void Create(Utilisateur utilisateur)
        {
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO utilisateurs (username, password_hash) VALUES (@username, @password_hash)", conn);
                cmd.Parameters.AddWithValue("@username", utilisateur.Username);
                cmd.Parameters.AddWithValue("@password_hash", utilisateur.PasswordHash);
                cmd.ExecuteNonQuery();
            }
        }


        public Utilisateur GetByUsername(string username)
        {
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand("SELECT * FROM utilisateurs WHERE username = @username", conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Utilisateur
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Username = reader["username"].ToString(),
                                PasswordHash = reader["password_hash"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        public Utilisateur GetById(int id)
        {
            using (var conn = Database.Database.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand("SELECT * FROM utilisateurs WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Utilisateur
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Username = reader["username"].ToString(),
                                PasswordHash = reader["password_hash"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

    }
}