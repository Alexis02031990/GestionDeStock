using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GestionDeStock.BL
{
    internal class CLS_Client
    {
        private dbStockContext db = new dbStockContext();
        private Client C; //table Client

        //fonction pour ajouter un client dans la basse e de données 
        public bool Ajouter_Client(string Nom, string Prenom, string Adresse, string Telephone, string Email, string Pays, string Ville)
        {
            C = new Client();

            C.Nom_Client = Nom;
            C.Prenom_client = Prenom;
            C.Adresse_Client = Adresse;
            C.Telephone_client = Telephone;
            C.Email_Client = Email;
            C.Pays_Client = Pays;
            C.Ville_Client = Ville;

            //verifier si le client existe deja en basse de donnees
            if (db.Clients.SingleOrDefault(s => s.Nom_Client == Nom && s.Prenom_client == Prenom) == null)//si le client n'existe pas , on l'ajoute
            {
                db.Clients.Add(C);//ajouter dans la table client
                db.SaveChanges();//Enregistrer dans la basse de sonnees
                return true;
            }
            else//s'il n'existe pas , on retour faux
            {
                return false;
            }

        }
        //fonction pour modifier un client dans la basse e de données 
        public void Modifier_Client(int id, string Nom, string Prenom, string Adresse, string Telephone, string Email, string Pays, string Ville)
        {
            C = new Client();
            C = db.Clients.SingleOrDefault(s => s.ID_Client == id);

            if (C != null)//existe?
            {
                C.Nom_Client = Nom;//nouveau Nom du client
                C.Prenom_client = Prenom;
                C.Adresse_Client = Adresse;
                C.Telephone_client = Telephone;
                C.Email_Client = Email;
                C.Pays_Client = Pays;
                C.Ville_Client = Ville;

                db.SaveChanges();//souvegarde les nouveau informations du client 

            }
        }
        //fonction pour supprimer un client dans la basse e de données
        public void Supprimer_Client(int id)
        {
            C = new Client();
            C = db.Clients.SingleOrDefault(s => s.ID_Client == id);//verifier si l'id du client existe

            if (C != null)
            {
                db.Clients.Remove(C);
                db.SaveChanges();
            }
        }

    }
}
