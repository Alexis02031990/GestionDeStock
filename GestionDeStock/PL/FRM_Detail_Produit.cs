using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace GestionDeStock.PL
{
    public partial class FRM_Detail_Produit : Form
    {
        private Produit produit;

        // Constructeur qui accepte un produit en paramètre
        public FRM_Detail_Produit(Produit produit)
        {
            InitializeComponent();
            this.produit = produit; // Initialiser le produit passé en paramètre
            ChargerDetailsProduit(); // Charger les détails du produit
        }

        // Charger les détails du produit
        // Charger les détails du produit
        private void ChargerDetailsProduit()
        {
            lblNomProduit.Text = produit.Nom_Produit;
            lblQuantiteProduit.Text = produit.Quantite_Produit.ToString();

            // Convertir le prix en decimal pour s'assurer qu'il est numérique
            decimal prixDecimal = Convert.ToDecimal(produit.Prix_Produit);

            // Afficher le prix avec deux décimales et ajouter "FCFA" après le montant
            lblPrixProduit.Text = $"{prixDecimal:C2}";

            // Charger l'image du produit
            if (produit.Image_Produit != null)
            {
                using (MemoryStream ms = new MemoryStream(produit.Image_Produit))
                {
                    pbxImageProduit.Image = Image.FromStream(ms);
                    pbxImageProduit.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
