using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeStock.BL
{
    internal class CLS_Categorie
    {
        private dbStockContext db = new dbStockContext();
        private Categorie cat;

        //fonction pour ajouter un categorie dans la basse e de données 
        public bool Ajouter_Categorie(string NomCat)
        {
            cat = new Categorie();
            cat.Nom_Categorie = NomCat;
            if (db.Categories.SingleOrDefault(s => s.Nom_Categorie == NomCat) == null)
            {
                db.Categories.Add(cat);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        //
        //une categorie
        public void Modifier_Categorie(int id,string Nomcat)
        {
            cat = new Categorie();
            cat= db.Categories.SingleOrDefault(s=> s.Id_Categorie==id);


            if(cat  != null)
            {
                cat.Nom_Categorie = Nomcat;
                db.SaveChanges();
            }
        }
        //fonction pour supprimer un client dans la basse e de données
        public void Supprimer_Categerie(int id)
        {
            cat = new Categorie();
            cat = db.Categories.SingleOrDefault(s => s.Id_Categorie == id);//verifier si l'id du client existe

            if (cat != null)
            {
                db.Categories.Remove(cat);
                db.SaveChanges();
            }
        }


    }
}
