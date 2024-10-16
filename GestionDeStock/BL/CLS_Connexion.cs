using GestionDeStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeStock.BL
{
    internal class CLS_Connexion
    {
        //function pour verifier la connexion 
        public int ConnexionValide(dbStockContext db, string Nom, string Mot_de_pass)
        {
            // Vérification si l'utilisateur existe
            var user = db.Utilisateurs.SingleOrDefault(s => s.NomUtilisateur == Nom);

            if (user == null)
            {
                // Si l'utilisateur n'existe pas
                return -1; // Utilisateur non trouvé
            }
            else if (user.Mot_De_Passe != Mot_de_pass)
            {
                // Si le mot de passe est incorrect
                return 0; // Mot de passe incorrect
            }
            else
            {
                // Si le nom d'utilisateur et le mot de passe sont corrects
                return 1; // Connexion réussie
            }
        }

    }
}

//public bool ConnexionValide(dbStockContext db, string Nom, string Mot_de_pass)
//{
//    // Récupérer tous les utilisateurs
//    var listeUsers = db.Utilisateurs.Where(U => U.NomUtilisateur != null || string.IsNullOrEmpty(U.NomUtilisateur)).ToList();

//    if (listeUsers.Count > 0)
//    {
//        // Parcourir la liste des utilisateurs
//        foreach (var user in listeUsers)
//        {
//            // Si le nom d'utilisateur et le mot de passe correspondent
//            if (user.NomUtilisateur == Nom && user.Mot_De_Passe == Mot_de_pass)
//            {
//                return true; // Connexion réussie
//            }
//        }
//    }

//    // Si aucun utilisateur ne correspond, retourner false
//    return false;
//}