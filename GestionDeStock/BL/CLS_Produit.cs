using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeStock.BL
{
    internal class CLS_Produit
    {
        private dbStockContext db = new dbStockContext();
        private Produit PR; //table produit

        //fonction pour ajouter un produit dans la basse e de données 
        public bool Ajouter_Produit(string Nom, int Quantite, string Prix, byte[] Image,int IdCategorie)
        {
            PR = new Produit();

            PR.Nom_Produit = Nom;
            PR.Quantite_Produit = Quantite;
            PR.Prix_Produit = Prix;
            PR.Image_Produit = Image;
            PR.ID_CATEGORIE = IdCategorie;
           

            //verifier si le produit existe deja en basse de donnees
            if (db.Produits.SingleOrDefault(s => s.Nom_Produit == Nom && s.ID_CATEGORIE == IdCategorie) == null)//si le produit n'existe pas , on l'ajoute
            {
                db.Produits.Add(PR);//ajouter dans la table produit
                db.SaveChanges();//Enregistrer dans la basse de sonnees
                return true;
            }
            else//s'il n'existe pas , on retour faux
            {
                return false;
            }

        }
        //fonction pour modifier un produit dans la basse e de données 
        public void Modifier_Produit(int id, string Nom, int Quantite, string Prix, byte[] Image, int IdCategorie)
        {
            PR = new Produit();
            PR = db.Produits.SingleOrDefault(s => s.Id_Produit == id);

            if (PR != null)//existe?
            {
                PR.Nom_Produit = Nom;//nouveau Nom du produit
                PR.Quantite_Produit = Quantite;
                PR.Prix_Produit = Prix;
                PR.Image_Produit = Image;
                PR.ID_CATEGORIE = IdCategorie;
                db.SaveChanges();//souvegarde les nouveau informations du produit

            }
        }
        //fonction pour supprimer un client dans la basse e de données
        public void Supprimer_Produit(int id)
        {
            PR = new Produit();
            PR = db.Produits.SingleOrDefault(s => s.Id_Produit == id);//verifier si l'id du client existe

            if (PR != null)
            {
                db.Produits.Remove(PR);
                db.SaveChanges();
            }
        }
    }
}
