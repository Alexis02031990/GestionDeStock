using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeStock.BL
{
    internal class CLS_Commande_DetailCommande
    {
        private dbStockContext db = new dbStockContext();
        private Commande clscmd;
        private Detail_Commande clsD;
        public int IDCommande;
        //Premiere chose c'est sauvegarder la commande
        public void Ajouter_Commande(DateTime dateC, int IdClient, string totalht,string tva, string totalttc)
        {
            clscmd = new Commande();
            clscmd.DATE_Commande = dateC;
            clscmd.ID_Client = IdClient;
            clscmd.ToTal_HT = totalht;
            clscmd.TVA = tva;
            clscmd.TOTAL_TTC = totalttc;

            db.Commandes.Add(clscmd);
            db.SaveChanges();

            IDCommande = clscmd.ID_Commande;//ID de la commande Ajouter
        }

        //Puis on va ajouter le detail de la commande
        public void Ajouter_DetailCommande(int IdProduit,string NomProduit, int quantite,string prix,string remise,string total)
        {
            clsD = new Detail_Commande();
            clsD.ID_Commande = IDCommande;
            clsD.ID_Produit = IdProduit;
            clsD.Nom_Produit = NomProduit;
            clsD.Quantite = quantite;
            clsD.Prix = prix;
            clsD.Remise = remise;
            clsD.ToTaL = total;

            db.Detail_Commande.Add(clsD);
            db.SaveChanges();
        }
    }
}
