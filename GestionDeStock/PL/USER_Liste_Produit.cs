using GestionDeStock.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Microsoft.Office.Interop.Excel;
using System.Drawing.Drawing2D;
using Rectangle = System.Drawing.Rectangle;

namespace GestionDeStock.PL
{
    public partial class USER_Liste_Produit : UserControl
    {
        private static USER_Liste_Produit Produit;
        private dbStockContext db;

        // Créer une instance pour le userControl
        private static USER_Liste_Client instance;

        public static USER_Liste_Produit Instance
        {
            get
            {
                if (Produit == null)
                {
                    Produit = new USER_Liste_Produit();
                }

                return Produit;
            }
        }

        public USER_Liste_Produit()
        {
            InitializeComponent();
            db = new dbStockContext();
            // Désactiver le textbox de recherche
            txtrechercheproduit.Enabled = true;
            this.dvgproduit.CellContentClick += new DataGridViewCellEventHandler(this.dvgproduit_CellContentClick);
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

        // Méthode pour formater le prix avec le symbole Euro après
        private string FormatPrixEuro(string montant)
        {
            return $"{montant:N2} €"; // Formater avec deux décimales et ajouter le symbole € après
        }

        // Actualiser DataGridView produit
        public void ActualiseDvg()
        {
            db = new dbStockContext();
            dvgproduit.Rows.Clear(); // Vider DataGridView

            // Pour afficher le nom de la catégorie à partir de l'ID de la catégorie
            Categorie Cat = new Categorie();

            foreach (var S in db.Produits)
            {
                Cat = db.Categories.SingleOrDefault(c => c.Id_Categorie == S.ID_CATEGORIE);
                if (Cat != null)
                {
                    // Formater le prix avec le symbole € derrière
                    string prixFormaté = FormatPrixEuro(S.Prix_Produit);

                    // Ajouter les lignes dans DataGridView
                    dvgproduit.Rows.Add(false, S.Id_Produit, S.Nom_Produit, S.Quantite_Produit, prixFormaté, Cat.Nom_Categorie);
                }
            }

            // Colorer le stock vide en rouge
            for (int i = 0; i < dvgproduit.Rows.Count; i++)
            {
                if ((int)dvgproduit.Rows[i].Cells[3].Value == 0) // Si le stock est vide
                {
                    dvgproduit.Rows[i].Cells[3].Style.BackColor = Color.Red;
                }
                else if ((int)dvgproduit.Rows[i].Cells[3].Value >= 5 && (int)dvgproduit.Rows[i].Cells[3].Value <= 10)
                {
                    dvgproduit.Rows[i].Cells[3].Style.BackColor = Color.Yellow;
                }
                else
                {
                    dvgproduit.Rows[i].Cells[3].Style.BackColor = Color.Green;
                }
            }
        }

        // Vérifier combien de lignes sont sélectionnées
        public string SelectVerif()
        {
            int selectedRowCount = 0;

            for (int i = 0; i < dvgproduit.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkBoxCell = dvgproduit.Rows[i].Cells[0] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null && checkBoxCell.Value != null && (bool)checkBoxCell.Value)
                {
                    selectedRowCount++;
                }
            }

            if (selectedRowCount == 0)
            {
                return "Sélectionner le produit.";
            }
            else if (selectedRowCount > 1)
            {
                return "Sélectionner seulement un seul produit.";
            }

            return null;
        }

        private void txtrechercheproduit_TextChanged(object sender, EventArgs e)
        {
            db = new dbStockContext();
            var listerecherche = db.Produits.ToList(); // liste des produits

            listerecherche = listerecherche.Where(s => s.Nom_Produit.IndexOf(txtrechercheproduit.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            //StringComparison.CurrentCultureIgnoreCase == recherche insensible à la casse

            // Vider DataGridView
            dvgproduit.Rows.Clear();

            // Ajouter listeRecherche dans DataGridView
            Categorie cat = new Categorie();

            foreach (var l in listerecherche)
            {
                cat = db.Categories.SingleOrDefault(s => s.Id_Categorie == l.ID_CATEGORIE); // Pour afficher le nom de la catégorie
                dvgproduit.Rows.Add(false, l.ID_CATEGORIE, l.Nom_Produit, l.Quantite_Produit, FormatPrixEuro(l.Prix_Produit), cat.Nom_Categorie);
            }
        }

        private void txtrechercheproduit_Enter(object sender, EventArgs e)
        {
            if (txtrechercheproduit.Text == "Recherche")
            {
                txtrechercheproduit.Text = "";
                txtrechercheproduit.ForeColor = Color.Black;
            }
        }

        private void USER_Liste_Produit_Load(object sender, EventArgs e)
        {
            ActualiseDvg();
        }

        private void btnajouterproduit_Click(object sender, EventArgs e)
        {
            PL.FRM_Ajouter_Modifier_Produit frmProduit = new PL.FRM_Ajouter_Modifier_Produit(this);
            frmProduit.ShowDialog();
        }

        private void btnmodifierproduit_Click(object sender, EventArgs e)
        {
            Produit PR = new Produit();
            int selectedRowCount = 0;
            int selectedRowIndex = -1;

            for (int i = 0; i < dvgproduit.Rows.Count; i++)
            {
                if ((bool)dvgproduit.Rows[i].Cells[0].Value == true) // Si une ligne est sélectionnée
                {
                    selectedRowCount++;
                    selectedRowIndex = i;
                }
            }

            if (selectedRowCount == 0)
            {
                MessageBox.Show("Sélectionnez un produit à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (selectedRowCount > 1)
            {
                MessageBox.Show("Sélectionnez un seul produit à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int MYIDSELECT = (int)dvgproduit.Rows[selectedRowIndex].Cells[1].Value; // Récupérer l'ID du produit sélectionné
                PR = db.Produits.SingleOrDefault(s => s.Id_Produit == MYIDSELECT); // Vérification si l'ID du produit correspond à l'ID sélectionné

                if (PR != null)
                {
                    PL.FRM_Ajouter_Modifier_Produit frmproduit = new FRM_Ajouter_Modifier_Produit(this);
                    frmproduit.lblTitre.Text = "Modifier Produit";
                    frmproduit.combocategorie.Text = dvgproduit.Rows[selectedRowIndex].Cells[5].Value.ToString();
                    frmproduit.txtnomproduit.Text = dvgproduit.Rows[selectedRowIndex].Cells[2].Value.ToString();
                    frmproduit.txtquantiteproduit.Text = dvgproduit.Rows[selectedRowIndex].Cells[3].Value.ToString();
                    frmproduit.txtprixproduit.Text = dvgproduit.Rows[selectedRowIndex].Cells[4].Value.ToString();
                    frmproduit.IdProduit = MYIDSELECT;

                    // Afficher l'image du produit
                    if (PR.Image_Produit != null)
                    {
                        MemoryStream MS = new MemoryStream(PR.Image_Produit);
                        frmproduit.pictureproduit.Image = Image.FromStream(MS);
                    }

                    frmproduit.btnactualiser.Visible = false;
                    frmproduit.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Produit introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnafficherphotos_Click(object sender, EventArgs e)
        {
            // Compter le nombre de lignes sélectionnées
            int selectedRowCount = 0;

            Produit PR = new Produit();

            for (int i = 0; i < dvgproduit.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkBoxCell = dvgproduit.Rows[i].Cells[0] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null && checkBoxCell.Value != null && (bool)checkBoxCell.Value)
                {
                    selectedRowCount++;
                }
            }

            if (selectedRowCount == 0)
            {
                MessageBox.Show(null, "Sélectionner le produit.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (selectedRowCount > 1)
            {
                MessageBox.Show(null, "Sélectionner seulement un seul produit.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Vérification de la ligne sélectionnée
                for (int i = 0; i < dvgproduit.Rows.Count; i++)
                {
                    // Si une ligne est sélectionnée
                    if ((bool)dvgproduit.Rows[i].Cells[0].Value == true)
                    {
                        int MYIDSELECT = (int)dvgproduit.Rows[i].Cells[1].Value; // Récupérer l'ID de la ligne sélectionnée
                        PR = db.Produits.SingleOrDefault(s => s.Id_Produit == MYIDSELECT); // Vérifier si l'ID du produit correspond à la ligne sélectionnée
                        if (PR != null)
                        {
                            FRM_Photo_Produit frmP = new FRM_Photo_Produit();
                            MemoryStream MS = new MemoryStream(PR.Image_Produit); // Convertir l'image du produit pour affichage dans PictureBox
                            frmP.imageproduit.Image = Image.FromStream(MS);
                            frmP.nomproduit.Text = dvgproduit.Rows[i].Cells[2].Value.ToString();
                            frmP.ShowDialog();
                        }
                    }
                }
            }
        }

        private void dvgproduit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifier si l'utilisateur a cliqué sur une cellule qui contient une checkbox
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Assurez-vous que l'index de la colonne est correct
            {
                DataGridViewCheckBoxCell checkBoxCell = dvgproduit.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null)
                {
                    // Inverser l'état de la case à cocher
                    bool isChecked = (checkBoxCell.Value != null) && (bool)checkBoxCell.Value;
                    checkBoxCell.Value = !isChecked;

                    // Pour rafraîchir l'affichage du DataGridView
                    dvgproduit.RefreshEdit();
                }
            }
        }

        private void btnimprimer_Click(object sender, EventArgs e)
        {
            db = new dbStockContext();
            int idSelect = 0;
            string NomCategorie = null;
            RAP.FRM_RAPPORT frmrpt = new RAP.FRM_RAPPORT();
            Produit PR = new Produit();

            if (SelectVerif() != null)
            {
                MessageBox.Show(SelectVerif(), "Imprimer Produit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                for (int i = 0; i < dvgproduit.Rows.Count; i++)
                {
                    if ((bool)dvgproduit.Rows[i].Cells[0].Value)
                    {
                        idSelect = (int)dvgproduit.Rows[i].Cells[1].Value; // idSelect de la ligne sélectionnée
                        NomCategorie = dvgproduit.Rows[i].Cells[5].Value.ToString(); // Nom de la catégorie
                    }
                }

                PR = db.Produits.SingleOrDefault(s => s.Id_Produit == idSelect);
                if (PR != null)
                {
                    frmrpt.RPAfficher.LocalReport.ReportEmbeddedResource = "GestionDeStock.RAP.RPT_Produit.rdlc"; // chemin du rapport

                    ReportParameter PCategorie = new ReportParameter("RPCategorie", NomCategorie);
                    ReportParameter PNom = new ReportParameter("RPNom", PR.Nom_Produit);
                    ReportParameter PQuantite = new ReportParameter("RPQuantite", PR.Quantite_Produit.ToString());
                    ReportParameter PPrix = new ReportParameter("RPPrix", PR.Prix_Produit);

                    string ImageString = Convert.ToBase64String(PR.Image_Produit);
                    ReportParameter PImage = new ReportParameter("RPImage", ImageString);

                    var parameters = new List<ReportParameter>
                    {
                        PCategorie,
                        PNom,
                        PQuantite,
                        PPrix,
                        PImage
                    };

                    frmrpt.RPAfficher.LocalReport.SetParameters(parameters);
                    frmrpt.RPAfficher.RefreshReport();
                    frmrpt.ShowDialog();
                }
            }
        }

        private void btnimprimertout_Click(object sender, EventArgs e)
        {
            RAP.FRM_RAPPORT frmrpt = new RAP.FRM_RAPPORT();
            db = new dbStockContext();

            try
            {
                var listeProduit = db.Produits.ToList();

                frmrpt.RPAfficher.LocalReport.ReportEmbeddedResource = "GestionDeStock.RAP.RPT_LISTES_PRODUITS.rdlc";
                frmrpt.RPAfficher.LocalReport.DataSources.Add(new ReportDataSource("databaseproduit", listeProduit));

                ReportParameter date = new ReportParameter("Date", DateTime.Now.ToString());
                frmrpt.RPAfficher.LocalReport.SetParameters(new ReportParameter[] { date });
                frmrpt.RPAfficher.RefreshReport();
                frmrpt.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsauvegarderexcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog SFD = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
            {
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;

                    ws.Cells[1, 1] = "Id Produit";
                    ws.Cells[1, 2] = "Nom Produit";
                    ws.Cells[1, 3] = "Quantité";
                    ws.Cells[1, 4] = "Prix";

                    var ListeProduit = db.Produits.ToList();
                    int i = 2;

                    foreach (var L in ListeProduit)
                    {
                        ws.Cells[i, 1] = L.Id_Produit;
                        ws.Cells[i, 2] = L.Nom_Produit;
                        ws.Cells[i, 3] = L.Quantite_Produit;
                        ws.Cells[i, 4] = L.Prix_Produit;

                        i++;
                    }

                    ws.Range["A1:D1"].Interior.Color = Color.Teal;
                    ws.Range["A1:D1"].Font.Color = Color.White;
                    ws.Range["A1:D1"].Font.Size = 15;

                    ws.Range["A:D"].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    ws.Range["A:D"].ColumnWidth = 25;

                    wb.SaveAs(SFD.FileName);
                    app.Quit();
                    MessageBox.Show("Le fichier a été sauvegardé avec succès dans Excel", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualiseDvg();
        }

        private void btnsupprimerproduit_Click(object sender, EventArgs e)
        {
            if (SelectVerif() == "Selectionner Produit")
            {
                MessageBox.Show(SelectVerif(), "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult DR = MessageBox.Show("Voulez-vous vraiment supprimer ce produit?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes)
                {
                    for (int i = 0; i < dvgproduit.Rows.Count; i++)
                    {
                        if ((bool)dvgproduit.Rows[i].Cells[0].Value == true)
                        {
                            BL.CLS_Produit clproduit = new CLS_Produit();
                            int idselect = (int)dvgproduit.Rows[i].Cells[1].Value;
                            clproduit.Supprimer_Produit(idselect);
                        }
                    }

                    ActualiseDvg();
                    MessageBox.Show("Produit supprimé avec succès.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Suppression annulée.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
