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
    public partial class FRM_Ajouter_Modifier_Categorie : Form
    {
        private UserControl usercat;

        public FRM_Ajouter_Modifier_Categorie(UserControl usercategorie)
        {
            InitializeComponent();
            this.usercat = usercategorie;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtnomcategorie_Enter(object sender, EventArgs e)
        {
            if(txtnomcategorie.Text == "Nom de la Categorie")
            {
                txtnomcategorie.Text ="";
                txtnomcategorie.ForeColor = Color.White;
            }
        }

        public int idCategorie;
        private void btnenregistrer_Click(object sender, EventArgs e)
        {
            BL.CLS_Categorie clcat = new BL.CLS_Categorie();
            if(txtnomcategorie.Text == "" || txtnomcategorie.Text == "Nom de la Categorie")
            {
                MessageBox.Show("Entrer le nom de la categorie.", "Ajouter une categorie", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (lblTitre.Text == "Ajouter Une Categorie")
                {
                    if (clcat.Ajouter_Categorie(txtnomcategorie.Text) == false)
                    {
                        MessageBox.Show("Categorie existe deja.", "Ajouter une categorie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Categorie ajouté correctement.", "Ajouter une categorie", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        (usercat as USER_Liste_Categorie).remplissagedatagrid();
                    }
                }
                if(lblTitre.Text == "Modifier Une Categorie")
                {
                   
                    DialogResult DR = MessageBox.Show("Voulez-vous vraiment modifier cette categorie?", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(DR == DialogResult.Yes)
                    {
                        clcat.Modifier_Categorie(idCategorie,txtnomcategorie.Text);
                        MessageBox.Show("Categorie modifier avec succes", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //actuliser datagrid
                        (usercat as USER_Liste_Categorie) .remplissagedatagrid();
                    }
                    else
                    {
                        MessageBox.Show("Modification annulée", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                   
                }
            }
            
        }
    }
}
