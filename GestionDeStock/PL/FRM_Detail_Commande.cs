using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeStock.PL
{
    public partial class FRM_Detail_Commande : Form
    {
        private UserControl userCommande;
        private dbStockContext db;

        public FRM_Detail_Commande(UserControl user)
        {
            InitializeComponent();
            db = new dbStockContext();
            userCommande = user;
        }

        // Fonction pour formater les prix avec le symbole Euro après le montant
        private string FormatPrixEuro(decimal montant)
        {
            return $"{montant:N2} €"; // Formater le prix avec deux décimales et ajouter le symbole Euro après
        }

        // Remplir datagrid de commande par liste
        public void Actualise_DetailCommande()
        {
            // Calcule total HT, TVA, Total ttc
            decimal Totalht = 0, TVA = 0, Totalttc;

            // Vérifier et convertir la TVA avec decimal.TryParse en gérant l'exception
            if (!decimal.TryParse(txttva.Text, out TVA))
            {
                MessageBox.Show("Le format de la TVA est incorrect. Veuillez entrer un nombre valide.");
                return; // Sortir de la fonction si le format est incorrect
            }

            dvgdetailcommande.Rows.Clear();
            foreach (var L in BL.D_Commande.listeDetail)
            {
                // Convertir le prix et le total en decimal pour permettre les opérations arithmétiques
                if (decimal.TryParse(L.Prix, out decimal prixDecimal) && decimal.TryParse(L.Total, out decimal totalDecimal))
                {
                    // Formater le prix et le total avec le symbole Euro
                    string prixFormaté = FormatPrixEuro(prixDecimal);
                    string totalFormaté = FormatPrixEuro(totalDecimal);

                    // Ajouter les informations au DataGridView
                    dvgdetailcommande.Rows.Add(L.Id, L.Nom, L.Quantite, prixFormaté, L.Remise, totalFormaté);

                    // Ajouter le total à Totalht
                    Totalht += totalDecimal;
                }
                else
                {
                    // Afficher un message d'erreur si la conversion échoue
                    MessageBox.Show($"Impossible de convertir le prix ou le total pour l'article {L.Nom}.", "Erreur de conversion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Formater et afficher le total HT et le total TTC avec le symbole Euro
            txtht.Text = FormatPrixEuro(Totalht);

            // Calcul du total TTC
            Totalttc = Totalht + (Totalht * TVA / 100);
            txtTcc.Text = FormatPrixEuro(Totalttc); // Afficher le total TTC dans le textbox
        }

        // Fonction pour remplir la datagrid de produit
        public void RemplirDvgProduit()
        {
            db = new dbStockContext();
            dvgProduit.Rows.Clear(); // Vider le DataGridView avant d'ajouter de nouvelles lignes

            // Ajouter les lignes dans le datagridview
            foreach (var l in db.Produits)
            {
                // Vérifier et convertir le prix en decimal pour permettre les opérations de formatage
                if (decimal.TryParse(l.Prix_Produit.ToString(), out decimal prixDecimal))
                {
                    // Formater le prix avec le symbole Euro
                    string prixFormaté = FormatPrixEuro(prixDecimal);

                    // Ajouter les informations au DataGridView
                    dvgProduit.Rows.Add(l.Id_Produit, l.Nom_Produit, l.Quantite_Produit, prixFormaté);
                }
                else
                {
                    // Afficher un message d'erreur si la conversion échoue
                    MessageBox.Show($"Impossible de convertir le prix pour le produit {l.Nom_Produit}.", "Erreur de conversion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            // Colorer le stock vide en rouge
            for (int i = 0; i < dvgProduit.Rows.Count; i++)
            {
                if ((int)dvgProduit.Rows[i].Cells[2].Value == 0) // Si le stock == 0
                {
                    dvgProduit.Rows[i].Cells[2].Style.BackColor = Color.Red;
                }
                else if ((int)dvgProduit.Rows[i].Cells[2].Value >= 5 && (int)dvgProduit.Rows[i].Cells[2].Value <= 10)
                {
                    dvgProduit.Rows[i].Cells[2].Style.BackColor = Color.Yellow;
                }
                else
                {
                    dvgProduit.Rows[i].Cells[2].Style.BackColor = Color.Green;
                }
            }

            // Vider la ligne sélectionnée
            dvgProduit.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            // Vider la liste des produits
            BL.D_Commande.listeDetail.Clear();
        }

        private void txtrecherche_Enter(object sender, EventArgs e)
        {
            if (txtrecherche.Text == "Recherche")
            {
                txtrecherche.Text = "";
                txtrecherche.ForeColor = Color.White;
            }
        }

        private void FRM_Detail_Commande_Load(object sender, EventArgs e)
        {
            RemplirDvgProduit();
        }

        private void txtrecherche_TextChanged(object sender, EventArgs e)
        {
            db = new dbStockContext();
            var listerecherche = db.Produits.ToList();
            listerecherche = listerecherche.Where(s => s.Nom_Produit.IndexOf(txtrecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            dvgProduit.Rows.Clear();

            // Ajouter les lignes basées sur les résultats de la recherche
            foreach (var l in listerecherche)
            {
                // Vérifier et convertir le prix en decimal pour permettre les opérations de formatage
                if (decimal.TryParse(l.Prix_Produit.ToString(), out decimal prixDecimal))
                {
                    // Formater le prix avec le symbole Euro
                    string prixFormaté = FormatPrixEuro(prixDecimal);

                    // Ajouter les informations au DataGridView
                    dvgProduit.Rows.Add(l.Id_Produit, l.Nom_Produit, l.Quantite_Produit, prixFormaté);
                }
                else
                {
                    // Afficher un message d'erreur si la conversion échoue
                    MessageBox.Show($"Impossible de convertir le prix pour le produit {l.Nom_Produit}.", "Erreur de conversion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Réappliquer les couleurs après avoir ajouté les lignes
            for (int i = 0; i < dvgProduit.Rows.Count; i++)
            {
                if ((int)dvgProduit.Rows[i].Cells[2].Value == 0) // Si le stock == 0
                {
                    dvgProduit.Rows[i].Cells[2].Style.BackColor = Color.Red;
                }
                else if ((int)dvgProduit.Rows[i].Cells[2].Value >= 5 && (int)dvgProduit.Rows[i].Cells[2].Value <= 10)
                {
                    dvgProduit.Rows[i].Cells[2].Style.BackColor = Color.Yellow;
                }
                else
                {
                    dvgProduit.Rows[i].Cells[2].Style.BackColor = Color.Green;
                }
            }

            // Vider la ligne sélectionnée
            dvgProduit.ClearSelection();
        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            PL.FRM_Client_Commande frmC = new FRM_Client_Commande();
            frmC.ShowDialog();
            // Afficher les informations du client
            IDCLIENT = (int)frmC.dvgclient.CurrentRow.Cells[0].Value;
            txtNom.Text = frmC.dvgclient.CurrentRow.Cells[1].Value.ToString();
            txtPrenom.Text = frmC.dvgclient.CurrentRow.Cells[2].Value.ToString();
            txtTelephone.Text = frmC.dvgclient.CurrentRow.Cells[4].Value.ToString();
            txtEmail.Text = frmC.dvgclient.CurrentRow.Cells[5].Value.ToString();
            txtPays.Text = frmC.dvgclient.CurrentRow.Cells[6].Value.ToString();
            txtVille.Text = frmC.dvgclient.CurrentRow.Cells[7].Value.ToString();
        }

        private void dvgProduit_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FRM_Produit_Commande frmp = new FRM_Produit_Commande(this);
            // Si le stock est vide
            if ((int)dvgProduit.CurrentRow.Cells[2].Value == 0)
            {
                MessageBox.Show("Ce produit n'est plus en stock.", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Afficher les informations du produit
                frmp.lblid.Text = dvgProduit.CurrentRow.Cells[0].Value.ToString();
                frmp.lblnom.Text = dvgProduit.CurrentRow.Cells[1].Value.ToString();
                frmp.lblstock.Text = dvgProduit.CurrentRow.Cells[2].Value.ToString();
                frmp.lblprix.Text = dvgProduit.CurrentRow.Cells[3].Value.ToString();
                frmp.txttotal.Text = dvgProduit.CurrentRow.Cells[3].Value.ToString();
                frmp.ShowDialog();
            }
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_Produit_Commande frm = new FRM_Produit_Commande(this);
            Produit PR = new Produit();

            if (dvgdetailcommande.CurrentRow != null)
            {
                frm.grpproduit.Text = "Modifier Produit";
                // Afficher les informations du produit à modifier
                frm.lblid.Text = dvgdetailcommande.CurrentRow.Cells[0].Value.ToString();
                frm.lblnom.Text = dvgdetailcommande.CurrentRow.Cells[1].Value.ToString();
                // Importer le stock de produit
                int IDP = int.Parse(dvgdetailcommande.CurrentRow.Cells[0].Value.ToString());
                PR = db.Produits.Single(c => c.Id_Produit == IDP);
                frm.lblstock.Text = PR.Quantite_Produit.ToString();
                //---------------------------------------------------------------------
                frm.lblprix.Text = dvgdetailcommande.CurrentRow.Cells[3].Value.ToString();
                frm.txtquantite.Text = dvgdetailcommande.CurrentRow.Cells[2].Value.ToString();
                frm.txtremise.Text = dvgdetailcommande.CurrentRow.Cells[4].Value.ToString();
                frm.txttotal.Text = dvgdetailcommande.CurrentRow.Cells[5].Value.ToString();
                frm.ShowDialog();
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_Produit_Commande frm = new FRM_Produit_Commande(this);

            DialogResult PR = MessageBox.Show("Voulez-vous vraiment supprimer ce produit?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (PR == DialogResult.Yes)
            {
                // Supprimer un produit dans la liste des commandes
                int index = BL.D_Commande.listeDetail.FindIndex(c => c.Id == int.Parse(dvgdetailcommande.CurrentRow.Cells[0].Value.ToString()));
                BL.D_Commande.listeDetail.RemoveAt(index);
                // Actualiser datagrid
                Actualise_DetailCommande();
                MessageBox.Show("Le produit a été supprimé de la liste.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Suppression annulée.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ID CLIENT
        public int IDCLIENT;
        private void btnenregistrer_Click(object sender, EventArgs e)
        {
            BL.CLS_Commande_DetailCommande clscommande = new BL.CLS_Commande_DetailCommande();

            if (dvgdetailcommande.Rows.Count == 0)
            {
                MessageBox.Show("Ajouter des Produits", "Enregistrer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtNom.Text == "")
                {
                    MessageBox.Show("Ajouter un Client", "Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Enregistrer la Commande
                    clscommande.Ajouter_Commande(commandedate.Value, IDCLIENT, txtht.Text, txttva.Text, txtTcc.Text);

                    // Enregistrer la liste de détail commande dans la base de données
                    foreach (var LD in BL.D_Commande.listeDetail)
                    {
                        // Ajouter chaque produit dans le détail de la commande
                        clscommande.Ajouter_DetailCommande(LD.Id, LD.Nom, LD.Quantite, LD.Prix, LD.Remise, LD.Total);

                        // Mettre à jour le stock du produit
                        Produit produit = db.Produits.SingleOrDefault(p => p.Id_Produit == LD.Id);
                        if (produit != null)
                        {
                            // Soustraire la quantité commandée de la quantité en stock
                            produit.Quantite_Produit -= LD.Quantite;

                            // Vérifier si le stock est négatif
                            if (produit.Quantite_Produit < 0)
                            {
                                MessageBox.Show($"La quantité demandée pour le produit {LD.Nom} dépasse la quantité en stock.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Enregistrer la modification dans la base de données
                            db.SaveChanges();
                        }
                    }

                    // Actualiser la liste des commandes dans l'interface
                    (userCommande as USER_Liste_Commande).remplirdata();

                    // Vider la liste
                    BL.D_Commande.listeDetail.Clear();

                    // Quitter le formulaire
                    Close();
                    MessageBox.Show("Commande ajoutée avec succès.", "Commande", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void txttva_TextChanged(object sender, EventArgs e)
        {
            // Calcul TTC
            Actualise_DetailCommande();
        }
    }
}
