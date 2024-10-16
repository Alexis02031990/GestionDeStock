using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeStock.BL
{
    internal class CLS_Utilisateur
    {
        private dbStockContext db = new dbStockContext();
        private Utilisateur U; //table Client

        // Méthode pour hacher le mot de passe (recommandé pour la sécurité)
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        //fonction pour ajouter un client dans la basse e de données 
        public bool Ajouter_Utilisateur(string Username, string Adresse, string Telephone, string Email, string Pays, string Ville, string Password, string confirmPassword)
        {
            U = new Utilisateur();

            U.NomUtilisateur = Username;
            U.Adresse= Adresse;
            U.Telephone = Telephone;
            U.Email = Email;
            U.Pays = Pays;
            U.Ville = Ville;
            U.Mot_De_Passe = HashPassword(Password); // Hachage du mot de passe


            //verifier si l'utilisateur existe deja en basse de donnees
            if (db.Utilisateurs.SingleOrDefault(s => s.NomUtilisateur == Username || s.Email == Email) == null)//si l'utilisateur n'existe pas , on l'ajoute
            {
                db.Utilisateurs.Add(U);//ajouter dans la table utilisateur
                db.SaveChanges();//Enregistrer dans la basse de sonnees
                return true;
            }
            else//s'il n'existe pas , on retour faux
            {
                MessageBox.Show("Le nom d'utilisateur existe déjà. Veuillez en choisir un autre.", "Erreur d'enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        //fonction pour modifier un utilisateur dans la basse e de données 
        public void Modifier_Utilisateur(int idUser, string Username, string Adresse, string Telephone, string Email, string Pays, string Ville)
        {
            U = new Utilisateur();
            U = db.Utilisateurs.SingleOrDefault(u => u.NomUtilisateur == Username || u.Email == Email);

            U.NomUtilisateur = Username;
            U.Adresse = Adresse;
            U.Telephone = Telephone;
            U.Email = Email;
            U.Pays = Pays;
            U.Ville = Ville;

            db.SaveChanges();//souvegarde les nouveau informations de l'utilisateur

        }

        // Fonction pour supprimer un utilisateur dans la base de données
        public void Supprimer_Utilisateur(int id)
        {
            U = db.Utilisateurs.SingleOrDefault(s => s.Id == id); // Vérifier si l'utilisateur existe

            if (U != null)
            {
                db.Utilisateurs.Remove(U); // Suppression depuis la table Utilisateurs, et non utilisateurs
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Utilisateur introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
