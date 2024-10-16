using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GestionDeStock.PL
{
    public partial class FRM_Ajouter_Modifier_Produit : Form
    {
        private dbStockContext db;
        private UserControl userProduit;

        public FRM_Ajouter_Modifier_Produit(UserControl User)
        {
            InitializeComponent();
            db = new dbStockContext();
            this.userProduit = User;

            //Afficher les categories dans comboboxcategorie
            combocategorie.DataSource = db.Categories.ToList();
            //Filtrer uniquement les nom de categories
            combocategorie.DisplayMember = "Nom_Categorie";
            combocategorie.ValueMember = "ID_CATEGORIE";
            this.userProduit = userProduit;
        }

        //champs oblogatoire
        string testobligatoire()
        {
            if (txtnomproduit.Text == "Nom Produit" || txtnomproduit.Text == "")
            {
                return "Entrer le nom du produit.";
            }
            if (txtquantiteproduit.Text == "Quantité" || txtquantiteproduit.Text == "")
            {
                return "Entrer la quantitédu produit.";
            }
            if (txtprixproduit.Text == "Prix" || txtquantiteproduit.Text == "")
            {
                return "Entrer le prix du produit.";
            }
            if (pictureproduit.Image == null)
            {
                return "Entrer l'image du produit.";
            }
            if (combocategorie.Text == "")
            {
                return "Entrer la Categorie";
            }
            return null;
        }

        private void txtnomproduit_Enter(object sender, EventArgs e)
        {
            if (txtnomproduit.Text == "Nom Produit")
            {
                txtnomproduit.Text = "";
                txtnomproduit.ForeColor = Color.White;
            }
        }

        private void txtnomproduit_Leave(object sender, EventArgs e)
        {
            if (txtnomproduit.Text == "")
            {
                txtnomproduit.Text = "Nom Produit";
                txtnomproduit.ForeColor = Color.White;
            }
        }

        private void txtquantiteproduit_Enter(object sender, EventArgs e)
        {
            if (txtquantiteproduit.Text == "Quantité")
            {
                txtquantiteproduit.Text = "";
                txtquantiteproduit.ForeColor = Color.White;
            }
        }

        private void txtquantiteproduit_Leave(object sender, EventArgs e)
        {
            if (txtquantiteproduit.Text == "")
            {
                txtquantiteproduit.Text = "Quantité";
                txtquantiteproduit.ForeColor = Color.White;
            }
        }

        private void txtprixproduit_Enter(object sender, EventArgs e)
        {
            if (txtprixproduit.Text == "Prix")
            {
                txtprixproduit.Text = "";
                txtprixproduit.ForeColor = Color.White;
            }
        }

        private void txtprixproduit_Leave(object sender, EventArgs e)
        {
            if (txtprixproduit.Text == "")
            {
                txtprixproduit.Text = "Prix";
                txtprixproduit.ForeColor = Color.White;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnparcourir_Click(object sender, EventArgs e)
        {
            //Afficher les images
            OpenFileDialog OP = new OpenFileDialog();
            OP.Filter = "|*.JPG;*.PNG;*.GIF;*.BMP";//Afficher uniquement les images
            if (OP.ShowDialog() == DialogResult.OK)
            {
                pictureproduit.Image = Image.FromFile(OP.FileName);
            }
        }

        private void txtnomproduit_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnactualiser_Click(object sender, EventArgs e)
        {
            //Vider le formulaire
            txtnomproduit.Text = "Nom Produit"; txtnomproduit.ForeColor = Color.Silver;
            txtquantiteproduit.Text = "Quantité"; txtquantiteproduit.ForeColor = Color.Silver;
            txtprixproduit.Text = "Prix"; txtprixproduit.ForeColor = Color.Silver;
            combocategorie.Text = "";
            pictureproduit.Image = null;
        }

        private void txtquantiteproduit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Textbox numeric 
            if (e.KeyChar < 48 || e.KeyChar > 57)//code asci des numeros 
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void txtprixproduit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Textbox numeric 
            if (e.KeyChar < 48 || e.KeyChar > 57)//code asci des numeros 
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }
        public int IdProduit;
        private void btnenregistrer_Click(object sender, EventArgs e)
        {
            if (testobligatoire() != null)
            {
                MessageBox.Show(testobligatoire(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (lblTitre.Text == "Ajouter Produit")
            {

                BL.CLS_Produit clcproduit = new BL.CLS_Produit();
                //Convertir l'image en format byte 
                //ajouter system.IO
                MemoryStream MR = new MemoryStream();
                pictureproduit.Image.Save(MR, pictureproduit.Image.RawFormat);
                byte[] byteimage = MR.ToArray();//convertire image en format byte[]

                if (clcproduit.Ajouter_Produit(txtnomproduit.Text, int.Parse(txtquantiteproduit.Text), txtprixproduit.Text, byteimage, Convert.ToInt32(combocategorie.SelectedValue)) == true)
                {
                    MessageBox.Show("Prdouit ajouter avec succes", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (userProduit as USER_Liste_Produit).ActualiseDvg();
                }
                else
                {
                    MessageBox.Show("Ce produit existe deja ", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else//si lbltitre = Modifier produit
            {
                BL.CLS_Produit clcproduit = new BL.CLS_Produit();
                //USER_Liste_Produit user = new USER_Liste_Produit();
                //Convertir l'image en format byte 
                MemoryStream MR = new MemoryStream();
                pictureproduit.Image.Save(MR, pictureproduit.Image.RawFormat);
                byte[] byteimage = MR.ToArray();//convertire image en format byte[]

                DialogResult R = MessageBox.Show("Voulez-vous vraiment modifier les informations de ce Produit?", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    clcproduit.Modifier_Produit(IdProduit, txtnomproduit.Text, int.Parse(txtquantiteproduit.Text), txtprixproduit.Text, byteimage, Convert.ToInt32(combocategorie.SelectedValue));
                    //pour actualiser datagrid view 
                    (userProduit as USER_Liste_Produit).ActualiseDvg();
                    MessageBox.Show("Produit modifié avec succés", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }
                else
                {
                    MessageBox.Show("La modification est annulé", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}
