using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace GestionDeStock.PL
{
    public partial class FRM_Ajouter_Modifier_Client : Form
    {
        private UserControl usclient;
        public FRM_Ajouter_Modifier_Client(UserControl usclient)
        {
            InitializeComponent();
            this.usclient = usclient;
        }
        //les champs  obligatoire
        string testobligatoire()
        {
            if(txtnomclient.Text == "Nom du Client" || txtnomclient.Text == "")
            {
                return "Entrer le nom du client";
            }else 
            if(txtprenomclient.Text == "Prenom Client" || txtprenomclient.Text == "")
            {
                return "Entrer le prenom du client";
            } else
            if(txtadresseclient.Text == "Adresse Client" || txtadresseclient.Text == "")
            {
                return "Entrer l'adresse du client";
            } else
            if(txttelephoneclient.Text == "Telephone Client" || txttelephoneclient.Text == "")
            {
                return "Entrer le telephone du client";
            }else
            if(txtemailclient.Text == "Email Client" || txtemailclient.Text == "")
            {
                return "Entrer l'email du client";
            } else
            if(txtpaysclient.Text == "Pays Client" || txtpaysclient.Text == "")
            {
                return "Entrer le pays du client";
            }else
            if(txtvilleclient.Text == "Ville Client" || txtvilleclient.Text == "")
            {
                return "Entrer la ville du client";
            } 
            ///verifier si l'email valide ou non
            if(txtemailclient.Text == "" || txtemailclient.Text != "Email Client")
            {
                try
                {
                    new MailAddress(txtemailclient.Text);//pour verifier si l'email est valide ou pas.
                }
                catch(Exception e) 
                {
                    return "Email Invalide!";
                }
            }
            return null;
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(txtnomclient.Text == "Nom du Client")
            {
                txtnomclient.Text = "";
                txtnomclient.ForeColor = Color.White;
            } 
        }

        private void txtnomclient_Leave(object sender, EventArgs e)
        {
            if(txtnomclient.Text == "")
            {
                txtnomclient.Text = "Nom du Client";
                txtnomclient.ForeColor = Color.Silver;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();//quitter le formulaire
        }

        private void txtprenomclient_Enter(object sender, EventArgs e)
        {
            if (txtprenomclient.Text == "Prenom Client")
            {
                txtprenomclient.Text = "";
                txtprenomclient.ForeColor = Color.White;
            }
        }

        private void txtprenomclient_Leave(object sender, EventArgs e)
        {
            if (txtprenomclient.Text == "")
            {
                txtprenomclient.Text = "Prenom Client";
                txtprenomclient.ForeColor = Color.Silver;
            }
        }

        private void txtadresseclient_Enter(object sender, EventArgs e)
        {
            if (txtadresseclient.Text == "Adresse Client")
            {
                txtadresseclient.Text = "";
                txtadresseclient.ForeColor = Color.White;
            }
        }

        private void txtadresseclient_Leave(object sender, EventArgs e)
        {
            if (txtadresseclient.Text == "")
            {
                txtadresseclient.Text = "Adresse Client";
                txtadresseclient.ForeColor = Color.Silver;
            }
        }

        private void txtpaysclient_Enter(object sender, EventArgs e)
        {
            if (txtpaysclient.Text == "Pays Client")
            {
                txtpaysclient.Text = "";
                txtpaysclient.ForeColor = Color.White;
            }
        }

        private void txtpaysclient_Leave(object sender, EventArgs e)
        {
            if (txtpaysclient.Text == "")
            {
                txtpaysclient.Text = "Pays Client";
                txtpaysclient.ForeColor = Color.Silver;
            }
        }

        private void txttelephoneclient_Enter(object sender, EventArgs e)
        {
            if (txttelephoneclient.Text == "Telephone Client")
            {
                txttelephoneclient.Text = "";
                txttelephoneclient.ForeColor = Color.White;
            }
        }

        private void txttelephoneclient_Leave(object sender, EventArgs e)
        {
            if (txttelephoneclient.Text == "")
            {
                txttelephoneclient.Text = "Telephone Client";
                txttelephoneclient.ForeColor = Color.Silver;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (txtemailclient.Text == "Email Client")
            {
                txtemailclient.Text = "";
                txtemailclient.ForeColor = Color.White;
            }
        }

        private void txtemailclient_Leave(object sender, EventArgs e)
        {
            if (txtemailclient.Text == "")
            {
                txtemailclient.Text = "Email Client";
                txtemailclient.ForeColor = Color.Silver;
            }
        }

        private void txtvilleclient_Enter(object sender, EventArgs e)
        {
            if (txtvilleclient.Text == "Ville Client")
            {
                txtvilleclient.Text = "";
                txtvilleclient.ForeColor = Color.White;
            }
        }

        private void txtvilleclient_Leave(object sender, EventArgs e)
        {
            if (txtvilleclient.Text == "")
            {
                txtvilleclient.Text = "Ville Client";
                txtvilleclient.ForeColor = Color.Silver;
            }
        }

        private void txttelephoneclient_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Textbox numeric 
            if(e.KeyChar < 48 || e.KeyChar > 57)//code asci des numeros 
            {
                e.Handled = true; 
            }
            if(e.KeyChar == 8)
            {
                e.Handled= false;
            }
        }
        public int IdSelect;

        private void btnenregistrer_Click(object sender, EventArgs e)
        {
            if (testobligatoire() != null)
            {
                MessageBox.Show(testobligatoire(),"Obligatoire",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if(lblTitre.Text == "Ajouter Client")
            {

                BL.CLS_Client clclient = new BL.CLS_Client();
                if (clclient.Ajouter_Client(txtnomclient.Text, txtprenomclient.Text, txtadresseclient.Text, txttelephoneclient.Text, txtemailclient.Text, txtpaysclient.Text, txtvilleclient.Text) == true)
                {
                    MessageBox.Show("Client ajouter avec succes", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (usclient as USER_Liste_Client).ActualiseDataGrid();
                }
                else
                {
                    MessageBox.Show("Ce client existe deja ", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else//si lbltitre = Modifier client
            {
                BL.CLS_Client clclient = new BL.CLS_Client();
                //USER_Liste_Client user = new USER_Liste_Client();

                DialogResult R = MessageBox.Show("Voulez-vous vraiment modifier les informations de ce client?", "Modification",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    clclient.Modifier_Client(IdSelect, txtnomclient.Text, txtprenomclient.Text, txtadresseclient.Text, txttelephoneclient.Text, txtemailclient.Text, txtpaysclient.Text, txtvilleclient.Text);
                    //pour actualiser datagrid view 
                    (usclient as USER_Liste_Client).ActualiseDataGrid();
                    MessageBox.Show("Client modifié avec succés", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("La modification est annulé", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void btnactualiser_Click(object sender, EventArgs e)
        {
            //vider les textbox 
            txtnomclient.Text = "Nom du Client";txtnomclient.ForeColor = Color.Silver;
            txtprenomclient.Text = "Prenom Client"; txtprenomclient.ForeColor = Color.Silver;
            txtadresseclient.Text = "Adresse Client"; txtadresseclient.ForeColor = Color.Silver;
            txttelephoneclient.Text = "Telephone Client"; txttelephoneclient.ForeColor = Color.Silver;
            txtemailclient.Text = "Email Client"; txtemailclient.ForeColor = Color.Silver;
            txtpaysclient.Text = "pays Client"; txtpaysclient.ForeColor = Color.Silver;
            txtvilleclient.Text = "Ville Client"; txtvilleclient.ForeColor = Color.Silver;
        }

        private void FRM_Ajouter_Modifier_Client_Load(object sender, EventArgs e)
        {

        }
    }
}
