using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManager.Forms;

namespace HotelManager
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Abonne-toi à l'événement global de sortie de l'application
            Application.ApplicationExit += OnApplicationExit;

            // Démarre avec le formulaire de connexion
            Application.Run(new LoginForm());
        }

        /// <summary>
        /// Méthode appelée automatiquement quand l'application se ferme.
        /// Pratique pour libérer les ressources, tuer les threads, etc.
        /// </summary>
        private static void OnApplicationExit(object sender, EventArgs e)
        {
            // 🔧 Tu peux ajouter ici du code de nettoyage global si besoin
            // Par exemple, fermer des connexions DB, timers, etc.
            // Exemple fictif :
            // MyDatabase.CloseAllConnections();

            Console.WriteLine("Application fermée proprement.");
        }
    }
}
