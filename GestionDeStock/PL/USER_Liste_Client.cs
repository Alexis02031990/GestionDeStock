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

namespace GestionDeStock.PL
{
    public partial class USER_Liste_Client : UserControl
    {
        private static USER_Liste_Client UserClient;
        private dbStockContext db;

        //Créer une instance pour le userControle
        private static USER_Liste_Client instance;

        public static USER_Liste_Client Instance
        {
            get 
            {

                if (UserClient == null)
                {
                    UserClient = new USER_Liste_Client();
                }

                return UserClient;
            }
        }

        public USER_Liste_Client()
        {
            InitializeComponent();
            db = new dbStockContext();
            //desactiver texbox de recherche
            txtrecherche.Enabled=false;
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
        //Ajouter dans datagridview 
        public void ActualiseDataGrid()
        {
            db = new dbStockContext();
            dvgclient.Rows.Clear();//vider datagrid view
            foreach (var S in db.Clients)
            {
                //Ajouter les lignes dans datagrid
                dvgclient.Rows.Add(false,S.ID_Client,S.Nom_Client,S.Prenom_client,S.Adresse_Client,S.Telephone_client,S.Email_Client,S.Pays_Client,S.Ville_Client);  
            }
        }
        //verifier combien de ligne est selectionner
        public string SelectVerif()
        {
            int NombreLigneSelect = 0;

            
            for (int i = 0;i< dvgclient.Rows.Count;i++)
            {
                if ((bool)dvgclient.Rows[i].Cells[0].Value == true)
                {
                    // Si la case à cocher est cochée, incrémenter le compteur
                    NombreLigneSelect++;
                }
            }
            if (NombreLigneSelect == 0)
            {
                return "Sélectionner le client que vous souhatez modifier.";
            }
            if (NombreLigneSelect > 0)
            {
                Console.WriteLine(NombreLigneSelect);
                return "Sélectionner seulement 1 seul client pour modifier.";
            }

            return null;
        }
        private void USER_Liste_Client_Load(object sender, EventArgs e)
        {
            ActualiseDataGrid();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(txtrecherche.Text == "Recherche")
            {
                txtrecherche.Text = "";
                txtrecherche.ForeColor = Color.Black;
            }
        }

        private void btnajouterclient_Click(object sender, EventArgs e)
        {
            //Afficher formulaire de saisie 
            PL.FRM_Ajouter_Modifier_Client frmclient = new FRM_Ajouter_Modifier_Client(this);
            frmclient.ShowDialog();
        }
        //public int IdSelect;

        private void btnmodifier_Click(object sender, EventArgs e)
        {
            //modifier les infos du client de saisie 
            PL.FRM_Ajouter_Modifier_Client frmclient = new FRM_Ajouter_Modifier_Client(this);

            // Compter le nombre de lignes sélectionnées
            int selectedRowCount = 0;
            int selectedRowIndex = -1;

            for (int i = 0; i < dvgclient.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkBoxCell = dvgclient.Rows[i].Cells[0] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null && checkBoxCell.Value != null && (bool)checkBoxCell.Value)
                {
                    selectedRowCount++;
                    selectedRowIndex = i;
                }
            }

            // Vérifier le nombre de lignes sélectionnées
            if (selectedRowCount == 0)
            {
                MessageBox.Show("Sélectionner le client que vous souhaitez modifier.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (selectedRowCount > 1)
            {
                MessageBox.Show("Sélectionner seulement un seul client pour modifier.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedRowIndex != -1)
            {
                for(int i = 0; i< dvgclient.Rows.Count; i++)
                {
                    if ((bool)dvgclient.Rows[i].Cells[0].Value == true)
                    {
                        //si la checkbox est vrai ,afficher les information dans le formulaire client
                        frmclient.IdSelect = (int)dvgclient.Rows[i].Cells[1].Value;
                        frmclient.txtnomclient.Text = dvgclient.Rows[i].Cells[2].Value.ToString();
                        frmclient.txtprenomclient.Text = dvgclient.Rows[i].Cells[3].Value.ToString();
                        frmclient.txtadresseclient.Text = dvgclient.Rows[i].Cells[4].Value.ToString();
                        frmclient.txttelephoneclient.Text = dvgclient.Rows[i].Cells[5].Value.ToString();
                        frmclient.txtemailclient.Text = dvgclient.Rows[i].Cells[6].Value.ToString();
                        frmclient.txtpaysclient.Text = dvgclient.Rows[i].Cells[7].Value.ToString();
                        frmclient.txtvilleclient.Text = dvgclient.Rows[i].Cells[8].Value.ToString();
                    }
                }
                frmclient.lblTitre.Text = "Modifier Client";
                frmclient.btnactualiser.Visible = false;
                frmclient.ShowDialog();
            }
            else
            {
                MessageBox.Show(SelectVerif(),"Modification",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void dvgclient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewCheckBoxCell checkBoxCell = dvgclient.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

            if (checkBoxCell != null)
            {
                bool isChecked = (bool)checkBoxCell.Value;
                checkBoxCell.Value = !isChecked;
            }


        }

        private void btnsupprimer_Click(object sender, EventArgs e)
        {
            BL.CLS_Client clclient = new BL.CLS_Client();

            int select = 0;
            //pour supprimer touts les client selectionner
            for(int i= 0; i< dvgclient.Rows.Count;i++)
            {
                if ((bool)dvgclient.Rows[i].Cells[0].Value==true)
                {
                    select++;
                }
            }
            if(select == 0)
            {
                MessageBox.Show("Aucun client selectionné", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DialogResult R =
                    MessageBox.Show("Voulez-vous vraiment supprimer ce client?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(R == DialogResult.Yes)
                {
                    //pour supprimer tous les client selectionnés
                    for (int i = 0; i < dvgclient.Rows.Count; i++)
                    {
                        if ((bool)dvgclient.Rows[i].Cells[0].Value==true)
                        {
                            clclient.Supprimer_Client(int.Parse(dvgclient.Rows[i].Cells[1].Value.ToString()));
                        }
                    }
                    //Actualiser datagrid view
                    ActualiseDataGrid();
                    MessageBox.Show("Client supprimé avec succés", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Suppression annulé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //activer le textbox recherche si j'ai choisis un champ
            txtrecherche.Enabled = true;
            txtrecherche.Text = "";//vider le textbox de recherche
        }

        private void txtrecherche_TextChanged(object sender, EventArgs e) 
        { 
        
            db = new dbStockContext();
            var listerecherche = db.Clients.ToList();//liste recherche = liste des clients

            if (txtrecherche.Text != "")
            {
                switch (comborecherche.Text)
                {
                    case "Nom":
                        listerecherche = listerecherche.Where(s => s.Nom_Client.IndexOf(txtrecherche.Text,StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //StringComparison.CurrentCultureIgnoreCase == soit j'ai écris la premiere lettre en majuscule ou minuscule.
                        //!=-1 existe dans la base de donnée
                        break;
                    case "Prenom":
                        listerecherche = listerecherche.Where(s => s.Prenom_client.IndexOf(txtrecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //StringComparison.CurrentCultureIgnoreCase == soit j'ai écris la premiere lettre en majuscule ou minuscule.
                        //!=-1 existe dans la base de donnée
                        break;
                    case "Telephone":
                        listerecherche = listerecherche.Where(s => s.Telephone_client.IndexOf(txtrecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //StringComparison.CurrentCultureIgnoreCase == soit j'ai écris la premiere lettre en majuscule ou minuscule.
                        //!=-1 existe dans la base de donnée
                        break;
                    case "Email":
                        listerecherche = listerecherche.Where(s => s.Email_Client.IndexOf(txtrecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //StringComparison.CurrentCultureIgnoreCase == soit j'ai écris la premiere lettre en majuscule ou minuscule.
                        //!=-1 existe dans la base de donnée
                        break;
                    case "Pays":
                        listerecherche = listerecherche.Where(s => s.Pays_Client.IndexOf(txtrecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //StringComparison.CurrentCultureIgnoreCase == soit j'ai écris la premiere lettre en majuscule ou minuscule.
                        //!=-1 existe dans la base de donnée
                        break;
                    case "Ville":
                        listerecherche = listerecherche.Where(s => s.Ville_Client.IndexOf(txtrecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //StringComparison.CurrentCultureIgnoreCase == soit j'ai écris la premiere lettre en majuscule ou minuscule.
                        //!=-1 existe dans la base de donnée
                        break;

                    default:
                        MessageBox.Show("Aucun client trouvé");
                        break;
                }
            }
            //vider data grid
            dvgclient.Rows.Clear();
            //ajouter listerecherche dans datagridview client 

            foreach(var l in listerecherche)
            {
                dvgclient.Rows.Add(false,l.ID_Client,l.Nom_Client,l.Prenom_client,l.Adresse_Client,l.Telephone_client,l.Email_Client,l.Pays_Client,l.Ville_Client);

            }
        }
    }
}
