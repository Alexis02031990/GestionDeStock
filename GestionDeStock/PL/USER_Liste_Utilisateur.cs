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
    public partial class USER_Liste_Utilisateur : UserControl
    {
        private static USER_Liste_Utilisateur User;
        private dbStockContext db;

        //Créer une instance pour le userConttrole
        public static USER_Liste_Utilisateur Instance
        { 
            get 
            { 
                if(User == null)
                {
                    User = new USER_Liste_Utilisateur();
                }
                return User; 
            }
        }

        public USER_Liste_Utilisateur()
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

        //Ajouter dans datagridview 
        public void ActualiseDataGrid()
        {
            db = new dbStockContext();
            dvgutilisateur.Rows.Clear();//vider datagrid view
            foreach (var U in db.Utilisateurs)
            {
                //Ajouter les lignes dans datagrid
                dvgutilisateur.Rows.Add(false,U.Id, U.NomUtilisateur, U.Telephone, U.Adresse, U.Email, U.Pays, U.Ville);
            }
        }

        //verifier combien de ligne est selectionner
        public string SelectVerif()
        {
            int NombreLigneSelect = 0;


            for (int i = 0; i < dvgutilisateur.Rows.Count; i++)
            {
                if ((bool)dvgutilisateur.Rows[i].Cells[0].Value == true)
                {
                    // Si la case à cocher est cochée, incrémenter le compteur
                    NombreLigneSelect++;
                }
            }
            if (NombreLigneSelect == 0)
            {
                return "Sélectionner l'utilisateur que vous souhatez modifier.";
            }
            if (NombreLigneSelect > 0)
            {
                Console.WriteLine(NombreLigneSelect);
                return "Sélectionner seulement 1 seul utilisateur pour modifier.";
            }

            return null;
        }

        private void btnajouterutilisateur_Click(object sender, EventArgs e)
        {
            PL.FRM_Ajouter_Modifier_Utilisateur frmUser = new PL.FRM_Ajouter_Modifier_Utilisateur(this);
            frmUser.ShowDialog();
        }

        private void USER_Liste_Utilisateur_Load(object sender, EventArgs e)
        {
            ActualiseDataGrid();
        }

        private void btnmodifier_Click(object sender, EventArgs e)
        {
            //modifier les infos de l'utilisateur
            PL.FRM_Ajouter_Modifier_Utilisateur frmuser = new FRM_Ajouter_Modifier_Utilisateur(this);

            // Compter le nombre de lignes sélectionnées
            int selectedRowCount = 0;
            int selectedRowIndex = -1;

            for (int i = 0; i < dvgutilisateur.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkBoxCell = dvgutilisateur.Rows[i].Cells[0] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null && checkBoxCell.Value != null && (bool)checkBoxCell.Value)
                {
                    selectedRowCount++;
                    selectedRowIndex = i;
                }
            }

            // Vérifier le nombre de lignes sélectionnées
            if (selectedRowCount == 0)
            {
                MessageBox.Show("Sélectionner l'utilisateur  que vous souhaitez modifier.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (selectedRowCount > 1)
            {
                MessageBox.Show("Sélectionner seulement un seul utilisateur pour modifier.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedRowIndex != -1)
            {
                for (int i = 0; i < dvgutilisateur.Rows.Count; i++)
                {
                    if ((bool)dvgutilisateur.Rows[i].Cells[0].Value == true)
                    {
                        //si la checkbox est vrai ,afficher les information dans le formulaire utilisateur
                        frmuser.IdUser = (int)dvgutilisateur.Rows[i].Cells[1].Value;
                        frmuser.txtUsername.Text = dvgutilisateur.Rows[i].Cells[2].Value.ToString();
                        frmuser.txtAddress.Text = dvgutilisateur.Rows[i].Cells[3].Value.ToString();
                        frmuser.txtPhone.Text = dvgutilisateur.Rows[i].Cells[4].Value.ToString();
                        frmuser.txtEmail.Text = dvgutilisateur.Rows[i].Cells[5].Value.ToString();
                        frmuser.txtCountry.Text = dvgutilisateur.Rows[i].Cells[6].Value.ToString();
                        frmuser.txtCity.Text = dvgutilisateur.Rows[i].Cells[7].Value.ToString();
                    }
                }
                frmuser.lblTitre.Text = "Modifier Utilisateur";
                frmuser.btnactualiser.Visible = false;  
                frmuser.ShowDialog();
            }
            else
            {
                MessageBox.Show(SelectVerif(), "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Événement déclenché lors du clic sur le bouton Supprimer
        private void btnsupprimer_Click(object sender, EventArgs e)
        {
            BL.CLS_Utilisateur clclient = new BL.CLS_Utilisateur();
            int select = 0;

            // Compter combien d'utilisateurs sont sélectionnés
            for (int i = 0; i < dvgutilisateur.Rows.Count; i++)
            {
                if ((bool)dvgutilisateur.Rows[i].Cells[0].Value == true)
                {
                    select++;
                }
            }

            if (select == 0)
            {
                MessageBox.Show("Aucun utilisateur sélectionné", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult R = MessageBox.Show("Voulez-vous vraiment supprimer les utilisateurs sélectionnés ?",
                                                  "Suppression",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

                if (R == DialogResult.Yes)
                {

                    // Supprimer tous les utilisateurs sélectionnés
                    for (int i = 0; i < dvgutilisateur.Rows.Count; i++)
                    {
                        if ((bool)dvgutilisateur.Rows[i].Cells[0].Value == true)
                        {
                            clclient.Supprimer_Utilisateur(int.Parse(dvgutilisateur.Rows[i].Cells[1].Value.ToString()));
                        }
                    }
                    // Actualiser la DataGridView après la suppression
                    ActualiseDataGrid();
                    MessageBox.Show("Utilisateur(s) supprimé(s) avec succès", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Suppression annulée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

    }
}
    