using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeStock.PL
{
    public partial class FRM_Menu : Form
    {
        private dbStockContext db;
        // Propriété pour stocker l'utilisateur connecté
        public Utilisateur UtilisateurConnecte { get; private set; }


        public FRM_Menu()
        {
            InitializeComponent();
            panel1.Size = new Size(182, 450);
            pnlParamettrer.Visible = false;
        }

        // Désactiver le formulaire
        void desactiverForm()
        {
            btnclient.Enabled = false;
            btnproduit.Enabled = false;
            btncategorie.Enabled = false;
            btncommande.Enabled = false;
            btnutilisateur.Enabled = false;
            btncopie.Enabled = false;
            btnrestaurer.Enabled = false;
            btndeconnecter.Enabled = false;
            pnlBut.Enabled = false;
            dashboard.Enabled = false;

            // Connecte activé 
            btnconnecter.Enabled = true;
        }

        // Activer le formulaire
        public void activeForm()
        {
            btnclient.Enabled = true;
            btnproduit.Enabled = true;
            btncategorie.Enabled = true;
            btncommande.Enabled = true;
            btnutilisateur.Enabled = true;
            btncopie.Enabled = true;
            btnrestaurer.Enabled = true;
            btndeconnecter.Enabled = true;
            pnlBut.Enabled = true;
            dashboard.Enabled = true;

            // Connecte désactivé 
            btnconnecter.Enabled = false;
            pnlParamettrer.Visible = false;
        }

        private void AfficherHomePage()
        {
            // Effacer tout le contenu du panel avant d'ajouter un nouveau formulaire
            pnlAffichage.Controls.Clear();

            // Créer une instance de FRM_HOME_PAGE
            FRM_HOME_PAGE homePage = new FRM_HOME_PAGE();

            // Définir les propriétés Dock et TopLevel pour afficher le formulaire à l'intérieur du panel
            homePage.TopLevel = false;
            homePage.Dock = DockStyle.Fill;

            // Ajouter le formulaire au panel
            pnlAffichage.Controls.Add(homePage);

            // Afficher le formulaire
            homePage.Show();
        }

        // Lors du chargement du formulaire
        private void FRM_Menu_Load(object sender, EventArgs e)
        {
            desactiverForm();

            // Ajuster manuellement la taille du panel
            int largeurPanel = 1400;  // Largeur personnalisée (par exemple 1000 pixels)
            int hauteurPanel = 670;   // Hauteur personnalisée

            pnlAffichage.Size = new Size(largeurPanel, hauteurPanel);  // Définir la taille

            // Calculer la position pour déplacer le panel vers la gauche
            int positionX = (this.ClientSize.Width - pnlAffichage.Width) / 2; 
            int positionY = (this.ClientSize.Height - pnlAffichage.Height) / 2;

            pnlAffichage.Location = new Point(positionX, positionY);  // Positionner le panneau

            // Afficher FRM_HOME_PAGE automatiquement au chargement de FRM_Menu
            AfficherHomePage();
        }


        // Lors du redimensionnement de la fenêtre
        private void FRM_Menu_Resize(object sender, EventArgs e)
        {
            // Ajuster la position pour recentrer le panel à chaque redimensionnement de la fenêtre
            int positionX = (this.ClientSize.Width - pnlAffichage.Width) / 2;
            int positionY = (this.ClientSize.Height - pnlAffichage.Height) / 2;

            pnlAffichage.Location = new Point(positionX, positionY);  // Repositionner au centre
        }

        public void SetNomUtilisateur(string nomUtilisateur, Utilisateur utilisateur)
        {
            lblUtilisateurConnecte.Text = nomUtilisateur;
            lblUtilisateurConnecte.AutoSize = false;
            lblUtilisateurConnecte.Width = 200;
            lblUtilisateurConnecte.Height = 35;

            if (!string.IsNullOrEmpty(nomUtilisateur))
            {
                lblUtilisateurConnecte.BackColor = Color.DarkGreen;
                UtilisateurConnecte = utilisateur; // Enregistrer l'utilisateur connecté
            }
            else
            {
                lblUtilisateurConnecte.BackColor = Color.Transparent;
                UtilisateurConnecte = null; // Aucune connexion active
            }
        }



        private void btnshutdown_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnsubstract_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btnclient.Top;
            if (!pnlAffichage.Controls.Contains(USER_Liste_Client.Instance))
            {
                pnlAffichage.Controls.Clear();
                pnlAffichage.Controls.Add(USER_Liste_Client.Instance);
                USER_Liste_Client.Instance.Dock = DockStyle.Fill;
                USER_Liste_Client.Instance.BringToFront();
            }
            else
            {
                USER_Liste_Client.Instance.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btnproduit.Top;
            if (!pnlAffichage.Controls.Contains(USER_Liste_Produit.Instance))
            {
                pnlAffichage.Controls.Clear();
                pnlAffichage.Controls.Add(USER_Liste_Produit.Instance);
                USER_Liste_Produit.Instance.Dock = DockStyle.Fill;
                USER_Liste_Produit.Instance.BringToFront();
            }
            else
            {
                USER_Liste_Produit.Instance.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 182)
            {
                panel1.Size = new Size(68, 450);
            }
            else
            {
                panel1.Size = new Size(182, 450);
            }
        }

        private void btncategorie_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btncategorie.Top;
            if (!pnlAffichage.Controls.Contains(USER_Liste_Categorie.Instance))
            {
                pnlAffichage.Controls.Clear();
                pnlAffichage.Controls.Add(USER_Liste_Categorie.Instance);
                USER_Liste_Categorie.Instance.Dock = DockStyle.Fill;
                USER_Liste_Categorie.Instance.BringToFront();
            }
            else
            {
                USER_Liste_Categorie.Instance.BringToFront();
            }
        }

        private void btncommande_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btncommande.Top;
            if (!pnlAffichage.Controls.Contains(USER_Liste_Commande.Instance))
            {
                pnlAffichage.Controls.Clear();
                pnlAffichage.Controls.Add(USER_Liste_Commande.Instance);
                USER_Liste_Commande.Instance.Dock = DockStyle.Fill;
                USER_Liste_Commande.Instance.BringToFront();
            }
            else
            {
                USER_Liste_Commande.Instance.BringToFront();
            }
        }

        private void btnutilisateur_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btnutilisateur.Top;
            if (!pnlAffichage.Controls.Contains(USER_Liste_Utilisateur.Instance))
            {
                pnlAffichage.Controls.Clear();
                pnlAffichage.Controls.Add(USER_Liste_Utilisateur.Instance);
                USER_Liste_Utilisateur.Instance.Dock = DockStyle.Fill;
                USER_Liste_Utilisateur.Instance.BringToFront();
            }
            else
            {
                USER_Liste_Utilisateur.Instance.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Afficher formulaire de connexion
            FRM_Connexion frmc = new FRM_Connexion(this); // this = FRM_MENU 
            frmc.ShowDialog();
            // Réafficher le menu après la connexion
            this.Show();
        }

        private void btnsetting_Click(object sender, EventArgs e)
        {
            pnlParamettrer.Size = new Size(344, 215);
            pnlParamettrer.Visible = !pnlParamettrer.Visible;
            pnlParamettrer.BringToFront();
        }

        private void btndeconnecter_Click(object sender, EventArgs e)
        {
            // Désactiver les fonctionnalités du menu
            desactiverForm();
        }

        private void btncopie_Click_1(object sender, EventArgs e)
        {
            // Ouvrir un dialogue pour permettre à l'utilisateur de choisir l'emplacement du fichier de sauvegarde
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Fichiers de sauvegarde (*.dbbackup)|*.dbbackup";
            saveFileDialog.Title = "Sauvegarder la base de données";
            saveFileDialog.InitialDirectory = @"C:\Sauvegardes"; // Emplacement avec permissions suffisantes

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string backupPath = saveFileDialog.FileName;

                    // Créer la commande de sauvegarde SQL
                    string backupQuery = $"BACKUP DATABASE [GESTION_DE_STOCK] TO DISK = '{backupPath}'";

                    // Utiliser la chaîne de connexion SQL Server directe
                    string connectionString = @"data source=DESKTOP-TA7UUKA\SQLEXPRESS;initial catalog=GESTION_DE_STOCK;integrated security=True;MultipleActiveResultSets=True;";

                    using (var connection = new SqlConnection(connectionString))
                    {
                        using (var command = new SqlCommand(backupQuery, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    MessageBox.Show("Sauvegarde effectuée avec succès", "Sauvegarde", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la sauvegarde: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnrestaurer_Click(object sender, EventArgs e)
        {
            // Ouvrir un dialogue pour permettre à l'utilisateur de choisir le fichier de restauration
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers de sauvegarde (*.dbbackup)|*.dbbackup";
            openFileDialog.Title = "Restaurer la base de données";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Utiliser l'extension .dbbackup
                    string restorePath = openFileDialog.FileName;

                    // Chaîne de connexion SQL Server directe
                    string connectionString = @"data source=DESKTOP-TA7UUKA\SQLEXPRESS;initial catalog=master;integrated security=True;MultipleActiveResultSets=True;";

                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Mettre la base de données en mode monoutilisateur pour fermer toutes les connexions actives
                        string setSingleUserQuery = "ALTER DATABASE [GESTION_DE_STOCK] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                        using (var setSingleUserCommand = new SqlCommand(setSingleUserQuery, connection))
                        {
                            setSingleUserCommand.ExecuteNonQuery();
                        }

                        // Créer la commande de restauration SQL
                        string restoreQuery = $"RESTORE DATABASE [GESTION_DE_STOCK] FROM DISK = '{restorePath}' WITH REPLACE";
                        using (var restoreCommand = new SqlCommand(restoreQuery, connection))
                        {
                            restoreCommand.ExecuteNonQuery();
                        }

                        // Remettre la base de données en mode multi-utilisateur après restauration
                        string setMultiUserQuery = "ALTER DATABASE [GESTION_DE_STOCK] SET MULTI_USER";
                        using (var setMultiUserCommand = new SqlCommand(setMultiUserQuery, connection))
                        {
                            setMultiUserCommand.ExecuteNonQuery();
                        }

                        connection.Close();
                    }

                    MessageBox.Show("Restauration effectuée avec succès", "Restauration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la restauration: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            pnlBut.Top = dashboard.Top;
            AfficherHomePage();
        }
    }
}
