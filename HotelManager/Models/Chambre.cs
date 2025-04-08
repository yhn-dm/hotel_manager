using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class Chambre
    {
        public int Id { get; set; }                   // Clé primaire
        public string Numero { get; set; }            // Numéro de chambre (ex: 101)
        public string Type { get; set; }              // Type de chambre (simple, double, triple)
        public decimal Tarif { get; set; }            // Tarif par nuit
        public string Statut { get; set; }            // Statut actuel (libre, occupée, à nettoyer)

        public override string ToString()
        {
            return $"Chambre {Numero} ({Type})";
        }
    }
}