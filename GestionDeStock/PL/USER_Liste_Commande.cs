using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace GestionDeStock.PL
{
    public partial class USER_Liste_Commande : UserControl
    {
        private static USER_Liste_Commande UserCommande;
        private dbStockContext db;

        // Créer une instance pour le UserControl
        public static USER_Liste_Commande Instance
        {
            get
            {
                if (UserCommande == null)
                {
                    UserCommande = new USER_Liste_Commande();
                }

                return UserCommande;
            }
        }

        public USER_Liste_Commande()
        {
            InitializeComponent();
            db = new dbStockContext();
            // Abonnement à l'événement Paint
            this.Paint += new PaintEventHandler(USER_Liste_Produit_Paint);
        }

        private void USER_Liste_Produit_Paint(object sender, PaintEventArgs e)
        {
            // Créer un rectangle qui représente l'entièreté du UserControl
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            // Créer un LinearGradientBrush avec deux couleurs (dégradé)
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.LightBlue, Color.DarkRed, 45F))
            {
                // Dessiner le dégradé dans le fond du UserControl
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        // Fonction pour formater le montant avec le symbole Euro après
        private string FormatPrixEuro(string montant)
        {
            return $"{montant:N2} €"; // Ajoute le symbole € après le montant
        }

        // Remplir la DataGridView commande avec chaque produit dans les détails de commande
        public void remplirdata()
        {
            dvgCommande.Rows.Clear();
            Client c = new Client();
            string NomPrenom;

            foreach (var LC in db.Commandes)
            {
                // Récupérer le client associé à la commande
                c = db.Clients.Single(s => s.ID_Client == LC.ID_Client);
                NomPrenom = c.Nom_Client + " " + c.Prenom_client;

                // Récupérer tous les détails de commande associés à la commande
                var detailsCommande = db.Detail_Commande.Where(dc => dc.ID_Commande == LC.ID_Commande).ToList();

                // Ajouter chaque produit de la commande dans la DataGridView
                foreach (var detail in detailsCommande)
                {
                    // Formater les montants avec le symbole Euro
                    string totalHtFormaté = FormatPrixEuro(LC.ToTal_HT);
                    string totalTtcFormaté = FormatPrixEuro(LC.TOTAL_TTC);

                    dvgCommande.Rows.Add(LC.ID_Commande, LC.DATE_Commande, NomPrenom, detail.Quantite, totalHtFormaté, LC.TVA, totalTtcFormaté);
                }
            }
        }

        private void btnajouterproduit_Click(object sender, EventArgs e)
        {
            PL.FRM_Detail_Commande frmC = new FRM_Detail_Commande(this);
            frmC.ShowDialog();
        }

        private void USER_Liste_Commande_Load(object sender, EventArgs e)
        {
            remplirdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Recherche Entre deux dates
            var listecommande = db.Commandes.ToList();

            if (dvgCommande.Rows.Count != 0)
            {
                listecommande = listecommande.Where(s => s.DATE_Commande >= dateDebut.Value.Date && s.DATE_Commande <= datedefin.Value.Date).ToList();
                // Remplir DataGridView
                dvgCommande.Rows.Clear();
                Client c = new Client();
                string NomPrenom;
                foreach (var LC in listecommande)
                {
                    // Afficher NOM + PRENOM du client
                    c = db.Clients.Single(s => s.ID_Client == LC.ID_Client);
                    NomPrenom = c.Nom_Client + " " + c.Prenom_client;

                    var detailsCommande = db.Detail_Commande.Where(dc => dc.ID_Commande == LC.ID_Commande).ToList();

                    foreach (var detail in detailsCommande)
                    {
                        // Formater les montants avec le symbole Euro
                        string totalHtFormaté = FormatPrixEuro(LC.ToTal_HT);
                        string totalTtcFormaté = FormatPrixEuro(LC.TOTAL_TTC);

                        dvgCommande.Rows.Add(LC.ID_Commande, LC.DATE_Commande, NomPrenom, detail.Quantite, totalHtFormaté, LC.TVA, totalTtcFormaté);
                    }
                }
            }
        }

        private void btnimprimer_Click(object sender, EventArgs e)
        {
            RAP.FRM_RAPPORT frmrap = new RAP.FRM_RAPPORT();
            try
            {
                // Commande sélectionnée
                int idCommande = (int)dvgCommande.CurrentRow.Cells[0].Value;
                var Commande = db.Commandes.Single(s => s.ID_Commande == idCommande);
                // Client
                var ClientCommande = db.Clients.Single(s => s.ID_Client == Commande.ID_Client);
                // Détail de commande
                var listdetail = db.Detail_Commande.Where(s => s.ID_Commande == idCommande).ToList();
                frmrap.RPAfficher.LocalReport.ReportEmbeddedResource = "GestionDeStock.RAP.RPT_Commande.rdlc";
                frmrap.RPAfficher.LocalReport.DataSources.Add(new ReportDataSource("dataCommande", listdetail));
                // Ajouter les informations du client
                ReportParameter NomPrenom = new ReportParameter("NomPrenomClient", ClientCommande.Nom_Client + " " + ClientCommande.Prenom_client);
                ReportParameter Adresse = new ReportParameter("AdresseC", ClientCommande.Adresse_Client);
                ReportParameter Telephone = new ReportParameter("TelephoneC", ClientCommande.Telephone_client);
                ReportParameter Email = new ReportParameter("EmailC", ClientCommande.Email_Client);
                // Ajouter info de la commande
                ReportParameter NumeroCommande = new ReportParameter("IDCommande", idCommande.ToString());
                ReportParameter DateCommande = new ReportParameter("DateCommande", Commande.DATE_Commande.ToString());
                // Ajouter totalht, tva, totalttc avec le symbole Euro
                ReportParameter Totalht = new ReportParameter("Totalht", FormatPrixEuro(Commande.ToTal_HT));
                ReportParameter Tva = new ReportParameter("Tva", Commande.TVA);
                ReportParameter Totalttc = new ReportParameter("Totalttc", FormatPrixEuro(Commande.TOTAL_TTC));
                // Enregistrer les valeurs
                frmrap.RPAfficher.LocalReport.SetParameters(new ReportParameter[] { NomPrenom, Adresse, Telephone, Email, NumeroCommande, DateCommande, Totalht, Tva, Totalttc });
                frmrap.RPAfficher.RefreshReport();
                frmrap.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Une erreur est survenue lors de l'impression. Veuillez vérifier si les paramètres du Rapport sont corrects.", "Impression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RAP.FRM_RAPPORT frmrap = new RAP.FRM_RAPPORT();
            try
            {
                // Récupérer la commande sélectionnée
                int idCommande = (int)dvgCommande.CurrentRow.Cells[0].Value;
                var Commande = db.Commandes.Single(s => s.ID_Commande == idCommande);
                var ClientCommande = db.Clients.Single(s => s.ID_Client == Commande.ID_Client);
                var listdetail = db.Detail_Commande.Where(s => s.ID_Commande == idCommande).ToList();

                // Charger le rapport de facture
                frmrap.RPAfficher.LocalReport.ReportEmbeddedResource = "GestionDeStock.RAP.RPT_Facture.rdlc";
                frmrap.RPAfficher.LocalReport.DataSources.Add(new ReportDataSource("datafacture", listdetail));

                // Générer un numéro de facture aléatoire
                string numeroFactureUnique = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

                // Ajouter les informations du client
                ReportParameter NomPrenom = new ReportParameter("NomPrenomClient", ClientCommande.Nom_Client + " " + ClientCommande.Prenom_client);
                ReportParameter Adresse = new ReportParameter("AdresseC", ClientCommande.Adresse_Client);
                ReportParameter Telephone = new ReportParameter("TelephoneC", ClientCommande.Telephone_client);
                ReportParameter Email = new ReportParameter("EmailC", ClientCommande.Email_Client);

                // Ajouter les informations de l'émetteur (utilisateur connecté)
                var frmMenu = Application.OpenForms.OfType<FRM_Menu>().FirstOrDefault(); // Accéder à FRM_Menu
                if (frmMenu != null && frmMenu.UtilisateurConnecte != null)
                {
                    ReportParameter NomEmetteur = new ReportParameter("NomEmetteur", frmMenu.UtilisateurConnecte.NomUtilisateur);
                    ReportParameter AdresseE = new ReportParameter("AdresseE", frmMenu.UtilisateurConnecte.Adresse);
                    ReportParameter TelephoneE = new ReportParameter("TelephoneE", frmMenu.UtilisateurConnecte.Telephone);
                    ReportParameter EmailE = new ReportParameter("EmailE", frmMenu.UtilisateurConnecte.Email);

                    // Ajouter les informations de l'émetteur dans le rapport
                    frmrap.RPAfficher.LocalReport.SetParameters(new ReportParameter[] { NomEmetteur, AdresseE, TelephoneE, EmailE });
                }
                else
                {
                    MessageBox.Show("Aucun utilisateur connecté. Veuillez vous connecter.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ajouter les informations de la commande
                ReportParameter NumeroFacture = new ReportParameter("NumeroFacture", numeroFactureUnique);
                ReportParameter DateEmission = new ReportParameter("DateEmission", DateTime.Now.ToString());

                // Ajouter les totaux (HT, TVA, TTC) avec le symbole Euro
                ReportParameter Totalht = new ReportParameter("Totalht", FormatPrixEuro(Commande.ToTal_HT));
                ReportParameter Tva = new ReportParameter("Tva", Commande.TVA);
                ReportParameter Totalttc = new ReportParameter("Totalttc", FormatPrixEuro(Commande.TOTAL_TTC));

                // Passer tous les paramètres au rapport
                frmrap.RPAfficher.LocalReport.SetParameters(new ReportParameter[]
                {
           NomPrenom, Adresse, Telephone, Email, NumeroFacture, DateEmission, Totalht, Tva, Totalttc
                });

                // Rafraîchir et afficher le rapport
                frmrap.RPAfficher.RefreshReport();
                frmrap.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Une erreur est survenue lors de la génération de la facture.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
