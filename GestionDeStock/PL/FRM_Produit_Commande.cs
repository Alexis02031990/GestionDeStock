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
    public partial class FRM_Produit_Commande : Form
    {

        public Form frmdetail;

        public FRM_Produit_Commande(Form frm)
        {
            InitializeComponent();
            frmdetail = frm;
        }

        private void txtquantite_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Text numerique uniquement
            if (!char.IsDigit(e.KeyChar) && e.KeyChar!=8)
            {
                e.Handled = true;
            }
        }

        private void txtremise_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Text numerique uniquement
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtquantite_TextChanged(object sender, EventArgs e)
        {
            if (txtquantite.Text !="")
            {
                int quantite = int.Parse(txtquantite.Text);
                int prix = int.Parse(lblprix.Text);
                if(int.Parse(txtquantite.Text) > int.Parse(lblstock.Text))
                {
                     MessageBox.Show("Il y a seulement " + int.Parse(lblstock.Text) + " produit(s) en Stock", "Stock", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    //Vider textbox quantity
                    txtquantite.Text = "";
                    txttotal.Text = lblprix.Text;
                }
                else
                {
                    //Calcul total
                    txttotal.Text = (quantite * prix).ToString();
                }
            }
            else
            {
                txttotal.Text = lblprix.Text;
            }
        }

        private void txtremise_TextChanged(object sender, EventArgs e)
        {
            if(txtremise.Text != "")
            {
                int quantite;
                if (txtquantite.Text != "")
                {
                    quantite = int.Parse(txtquantite.Text);
                }
                else
                {
                    quantite = 1;
                }
                
                int prix = int.Parse(lblprix.Text);
                int total = quantite * prix;
                int remise = int.Parse(txtremise.Text);
                txttotal.Text = (total - (total * remise / 100)).ToString();
            }
            else
            {
                int quantite;
                if (txtquantite.Text != "")
                {
                    quantite = int.Parse(txtquantite.Text);
                }
                else
                {
                    quantite = 1;
                }
                int prix = int.Parse(lblprix.Text);
                txttotal.Text = (quantite * prix).ToString();
            }
        }

        private void btnenregistrer_Click(object sender, EventArgs e)
        {
            //Si txtbox Quantite et textbox remise vide
            int quantite, Re;
            if(txtquantite.Text != "")
            {
                quantite = int.Parse(txtquantite.Text);
            }
            else
            {
                quantite = 1;
            }
            if(txtremise.Text != "")
            {
                Re = int.Parse(txtremise.Text);
            }
            else
            {
                Re = 0;
            }
            //Ajouter le produit dans la commande
            BL.D_Commande detail = new BL.D_Commande
            {
                Id = int.Parse(lblid.Text),
                Nom = lblnom.Text,
                Quantite = int.Parse(txtquantite.Text),
                Prix = lblprix.Text,
                Remise = Re.ToString(),
                Total = txttotal.Text,
            };

            //Ajouter dans la liste
            if(grpproduit.Text == "")
            {
                if (BL.D_Commande.listeDetail.SingleOrDefault(s => s.Id == detail.Id) != null)
                {
                    MessageBox.Show("Ce produit existe déjà dans la commande", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    BL.D_Commande.listeDetail.Add(detail);
                    Close();
                }
            }
            else if(detail != null)
            {
                //Modifier le produit
                DialogResult PR = MessageBox.Show("Voulez-vous vraiment modifier ce produit?", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(PR == DialogResult.Yes)
                {
                    //Trouver l'index du produit en question
                    int index = BL.D_Commande.listeDetail.FindIndex(c => c.Id == int.Parse(lblid.Text));
                    BL.D_Commande.listeDetail[index] = detail;
                    MessageBox.Show("Le produit a été modifié avec succes.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }
                else
                {
                    MessageBox.Show("Modification annulé.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
           
            //Actualiser 
           (frmdetail as FRM_Detail_Commande).Actualise_DetailCommande();
        }
    }
}
