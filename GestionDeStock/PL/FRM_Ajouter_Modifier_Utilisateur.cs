using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace GestionDeStock.PL
{
    public partial class FRM_Ajouter_Modifier_Utilisateur : Form
    {
        private dbStockContext db;  // Contexte de base de données
        private UserControl ususer;
        private Form frmenu;

        public FRM_Ajouter_Modifier_Utilisateur(UserControl ususer)
        {
            InitializeComponent();
            db = new dbStockContext(); // Initialiser le contexte de base de données
            this.ususer = ususer;
        }

        // Méthode pour hacher le mot de passe (recommandé pour la sécurité)
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();  // Fermer le formulaire sans enregistrer
        }

        string testobligatoire()
        {
            if (txtUsername.Text == "Nom Utilisateur" || txtUsername.Text == "")
            {
                return "Entrer le nom de utilisateur";
            }
            else
            if (txtAddress.Text == "Adresse Utilisateur" || txtAddress.Text == "")
            {
                return "Entrer l'adresse du client";
            }
            else
            if (txtPhone.Text == "Telephone Utilisateur" || txtPhone.Text == "")
            {
                return "Entrer le telephone de l'Utilisateur";
            }
            else
            if (txtEmail.Text == "Email Utilisateur" || txtEmail.Text == "")
            {
                return "Entrer l'email de l'Utilisateur";
            }
            else
            if (txtCountry.Text == "Pays Utilisateur" || txtCountry.Text == "")
            {
                return "Entrer le pays de l'Utilisateur";
            }
            else
            if (txtCity.Text == "Ville Utilisateur" || txtCity.Text == "")
            {
                return "Entrer la ville de l'Utilisateur";
            }
            ///verifier si l'email valide ou non
            if (txtEmail.Text == "" || txtEmail.Text != "Email Utilisateur")
            {
                try
                {
                    new MailAddress(txtEmail.Text);//pour verifier si l'email est valide ou pas.
                }
                catch (Exception e)
                {
                    return "Email Invalide!";
                }
            }
            return null;
        }
        public int IdUser;

        private void btnenregistrer_Click_1(object sender, EventArgs e)
        {
            if (testobligatoire() != null)
            {
                MessageBox.Show(testobligatoire(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lblTitre.Text == "Ajouter Utilisateur")
            {

                if (txtPassword.Text == "Password" || txtPassword.Text == "")
                {
                    MessageBox.Show("Entrer un mot de passe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Vérification des mots de passe lors de l'ajout d'un nouvel utilisateur
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Les mots de passe ne correspondent pas", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BL.CLS_Utilisateur cluser = new BL.CLS_Utilisateur();
                if (cluser.Ajouter_Utilisateur(txtUsername.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text, txtCountry.Text, txtCity.Text, txtPassword.Text, txtConfirmPassword.Text) == true)
                {
                    MessageBox.Show("Utilisateur ajouté avec succès", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (ususer as USER_Liste_Utilisateur).ActualiseDataGrid();
                }
            }
            else // Modification utilisateur
            {
                // Pas besoin de vérifier les mots de passe si les champs sont désactivés
                BL.CLS_Utilisateur clUser = new BL.CLS_Utilisateur();

                DialogResult R = MessageBox.Show("Voulez-vous vraiment modifier les informations de cet utilisateur ?", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    clUser.Modifier_Utilisateur(IdUser,txtUsername.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text, txtCountry.Text, txtCity.Text);
                    (ususer as USER_Liste_Utilisateur).ActualiseDataGrid();
                    MessageBox.Show("Utilisateur modifié avec succès", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("La modification est annulée", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void FRM_Ajouter_Modifier_Utilisateur_Load(object sender, EventArgs e)
        {
            if (lblTitre.Text == "Modifier Utilisateur")
            {
                // Désactiver les champs de mot de passe et confirmation en mode modification
                txtPassword.Enabled = false;
                txtConfirmPassword.Enabled = false;
            }
            else
            {
                // Activer les champs de mot de passe si c'est un ajout
                txtPassword.Enabled = true;
                txtConfirmPassword.Enabled = true;
            }

        }

        private void btnactualiser_Click(object sender, EventArgs e)
        {
            //vider les textbox 
            txtUsername.Text = "Nom Utilisateur"; txtUsername.ForeColor = Color.Silver;
            txtPhone.Text = "Telephone Utilisateur"; txtPhone.ForeColor = Color.Silver;
            txtAddress.Text = "Adresse Utilisateur"; txtAddress.ForeColor = Color.Silver;
            
            txtEmail.Text = "Email Utilisateur"; txtEmail.ForeColor = Color.Silver;
            txtCountry.Text = "pays Utilisateur"; txtCountry.ForeColor = Color.Silver;
            txtCity.Text = "Ville Utilisateur"; txtCity.ForeColor = Color.Silver;
        }
    }
}
