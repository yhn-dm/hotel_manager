using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class Reservation
    {
        public int Id { get; set; }                        // Clé primaire
        public int IdClient { get; set; }                  // Référence client
        public int IdChambre { get; set; }                 // Référence chambre
        public DateTime DateArrivee { get; set; }          // Date d'arrivée
        public DateTime DateDepart { get; set; }           // Date de départ
        public string Statut { get; set; }                 // en cours / terminée

        // Propriétés utiles pour afficher les infos liées
        public string NomClient { get; set; }              // Nom complet du client (optionnel)
        public string NumeroChambre { get; set; }          // Numéro de la chambre (optionnel)
    }
}
