using HotelManager.DataAccess;
using HotelManager.Models;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private UtilisateurDAO utilisateurDAO = new UtilisateurDAO();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            var utilisateurDAO = new UtilisateurDAO();

            // Vérifie si l'utilisateur existe déjà
            var existant = utilisateurDAO.GetByUsername(username);
            if (existant != null)
            {
                MessageBox.Show("Ce nom d'utilisateur est déjà pris.");
                return;
            }

            // Hash du mot de passe (ici simple hash pour la démo, à sécuriser en prod)
            string hash = BCrypt.Net.BCrypt.HashPassword(password);

            var utilisateur = new Utilisateur
            {
                Username = username,
                PasswordHash = hash
            };

            utilisateurDAO.Create(utilisateur);
            MessageBox.Show("Compte créé avec succès !");
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            var utilisateur = utilisateurDAO.GetByUsername(txtUsername.Text);
            if (utilisateur != null && BCrypt.Net.BCrypt.Verify(txtPassword.Text, utilisateur.PasswordHash))
            {
                // Enregistrer l'utilisateur connecté
                Session.UtilisateurConnecte = utilisateur;

                MessageBox.Show("Connexion réussie !");
                this.Hide();
                new MainForm().Show(); // ou Dashboard
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
            }
        }



        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
