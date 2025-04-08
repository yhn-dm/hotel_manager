using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class Client
    {
        public int Id { get; set; }                // Identifiant unique du client (clé primaire)
        public string Nom { get; set; }            // Nom du client
        public string Prenom { get; set; }         // Prénom du client
        public string Telephone { get; set; }      // Numéro de téléphone
        public string Email { get; set; }          // Adresse e-mail

        public string NomComplet => $"{Prenom} {Nom}"; // Propriété pratique pour affichage
    }
}