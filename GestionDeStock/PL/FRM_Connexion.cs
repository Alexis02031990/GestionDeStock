using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeStock.PL
{
    public partial class FRM_Connexion : Form
    {
        private dbStockContext db;
        private Form frmmenu;

        //classe connexion
        BL.CLS_Connexion C = new BL.CLS_Connexion();

        public FRM_Connexion(Form Menu)
        {
            InitializeComponent();
            this.frmmenu= Menu;
            //initialiser la base de donnees
            db = new dbStockContext();
        }

        // Méthode pour hacher le mot de passe (recommandée pour la sécurité)
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

        //pour verifier les camp obligatoires 
        string testobligatoire()
        {
            if(txtnom.Text == "" || txtnom.Text == "Nom d'utilisateur")//si le nom d'utilisateur est vide ou le text de textbox est "Nom d'utilisateur"
            {
                return "Entrer votre Nom";
            } 
            if(txtmotdepasse.Text == "" || txtmotdepasse.Text == "Mot de passe")
            {
                return "Entrer votre Mot De Passe";
            }
            //si l'utilisateur est entrer son et mot de passe 

            return null;
        }

        private void btnquitter_Click(object sender, EventArgs e)
        {
            //Quiter le formulaire
            this.Close();
        }

        private void txtnom_Enter(object sender, EventArgs e)
        {
            //Pour vider le texteBox
            if (txtnom.Text == "Nom d'utilisateur")
            {
                txtnom.Text= string.Empty;
                txtnom.ForeColor = Color.WhiteSmoke;//chnager couleur de texte
            }
        }

        private void txtmotdepasse_Enter(object sender, EventArgs e)
        {
            //Pour vider le texteBox
            if (txtmotdepasse.Text == "Mot de passe")
            {
                txtmotdepasse.Text = string.Empty;
                txtmotdepasse.UseSystemPasswordChar = false;
                txtmotdepasse.PasswordChar = '*';
                txtmotdepasse.ForeColor = Color.WhiteSmoke;//chnager couleur de texte
            }
        }

        private void txtnom_Leave(object sender, EventArgs e)
        {
            if(txtnom.Text == "")
            {
                txtnom.Text = "Nom d'utilisateur"; 
                txtnom.ForeColor = Color.Silver;
            }
        }

        private void txtmotdepasse_Leave(object sender, EventArgs e)
        {
            if (txtmotdepasse.Text == "")
            {
                txtmotdepasse.Text = "Mot de passe";
                txtmotdepasse.UseSystemPasswordChar = true;//desactiver passwordchar
                //txtmotdepasse.PasswordChar = '*';
                txtmotdepasse.ForeColor = Color.Silver;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (testobligatoire() == null)
            {
                // Hachez le mot de passe entré avant la vérification
                string hashedPassword = HashPassword(txtmotdepasse.Text);

                // Vérifier les informations de connexion
                int resultat = C.ConnexionValide(db, txtnom.Text, hashedPassword);

                if (resultat == 1) // Connexion réussie
                {
                    MessageBox.Show("Connexion réussie", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    // Récupérer l'utilisateur connecté à partir de la base de données
                    Utilisateur utilisateurConnecte = db.Utilisateurs.SingleOrDefault(u => u.NomUtilisateur == txtnom.Text);
                    if (utilisateurConnecte != null)
                    {
                        // Passer le nom d'utilisateur et l'objet Utilisateur connecté à la fenêtre principale
                        (frmmenu as FRM_Menu).SetNomUtilisateur(utilisateurConnecte.NomUtilisateur, utilisateurConnecte);
                    }

                    (frmmenu as FRM_Menu).activeForm(); // Activer le formulaire principal
                    this.Close(); // Quitter le formulaire de connexion
                }
                else if (resultat == 0) // Mot de passe incorrect
                {
                    MessageBox.Show("Le mot de passe est incorrect", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (resultat == -1) // Utilisateur non trouvé
                {
                    MessageBox.Show("Le nom d'utilisateur n'existe pas", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(testobligatoire(), "Champs obligatoires", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btninscription_Click(object sender, EventArgs e)
        {
            PL.FRM_Ajouter_Modifier_Utilisateur clUser = new FRM_Ajouter_Modifier_Utilisateur(new USER_Liste_Utilisateur());
            clUser.ShowDialog();
        }

    }
}
