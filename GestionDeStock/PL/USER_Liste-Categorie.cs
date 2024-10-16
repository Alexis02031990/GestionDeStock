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
using Microsoft.Office.Interop.Excel;
using Microsoft.Reporting.WinForms;
using Rectangle = System.Drawing.Rectangle;

namespace GestionDeStock.PL
{
    public partial class USER_Liste_Categorie : UserControl
    {
        private static USER_Liste_Categorie usercategorie;
        private dbStockContext db;

        public static USER_Liste_Categorie Instance
        {
            get 
            { 
                if(usercategorie == null)
                {
                    usercategorie = new USER_Liste_Categorie();
                }
                return usercategorie; 
            } 

        }

        public USER_Liste_Categorie()
        {
            InitializeComponent();
            db = new dbStockContext();
            this.dvgcategorie.CellContentClick += new DataGridViewCellEventHandler(this.dvgcategorie_CellContent);
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

        public void remplissagedatagrid()
        {
            db = new dbStockContext();
            dvgcategorie.Rows.Clear();
            foreach(var Cat in db.Categories)
            {
                dvgcategorie.Rows.Add(false,Cat.Id_Categorie,Cat.Nom_Categorie);
            }

            for (int i = 0; i < dvgcategorie.Rows.Count; i++)
            {
                dvgcategorie.Rows[i].Cells[3].Style.BackColor = Color.Yellow;
                dvgcategorie.Rows[i].Cells[4].Style.BackColor = Color.Red;
            }
        }
        //verifier combien de ligne est selectionner
        public string SelectVerif()
        {
            int selectedRowCount = 0;

            for (int i = 0; i < dvgcategorie.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkBoxCell = dvgcategorie.Rows[i].Cells[0] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null && checkBoxCell.Value != null && (bool)checkBoxCell.Value)
                {
                    selectedRowCount++;
                }
            }

            if (selectedRowCount == 0)
            {
                MessageBox.Show(null, "Sélectionner la catégorie.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (selectedRowCount > 1)
            {
                MessageBox.Show(null, "Sélectionner seulement une seule catégorie.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
        private void txtrecherche_Enter(object sender, EventArgs e)
        {
            if(txtrecherche.Text == "Recherche")
            {
                txtrecherche.Text = "";
                txtrecherche.ForeColor = Color.Black;
            }
        }
        private void USER_Liste_Categorie_Load(object sender, EventArgs e)
        {
            remplissagedatagrid();
        }

        private void btnajouterproduit_Click(object sender, EventArgs e)
        {
            PL.FRM_Ajouter_Modifier_Categorie frmcat = new FRM_Ajouter_Modifier_Categorie(this);
            frmcat.ShowDialog();
        }

        private void dvgcategorie_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PL.FRM_Ajouter_Modifier_Categorie frmcat = new FRM_Ajouter_Modifier_Categorie(this);
            if (dvgcategorie.Columns[e.ColumnIndex].Name == "Modifier")//si je click sur le button modifier
            {
                //id de la categorie
                frmcat.idCategorie = (int)dvgcategorie.Rows[e.RowIndex].Cells[1].Value;
                //autocomplet du formulaire
                frmcat.txtnomcategorie.Text = dvgcategorie.Rows[e.RowIndex].Cells[2].Value.ToString();//On recupere l'index de la ligne 
                frmcat.lblTitre.Text = "Modifier Une Catégorie";
                frmcat.ShowDialog(this);
            }
            //Supprimer une categorie
            if (dvgcategorie.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                BL.CLS_Categorie clscat = new BL.CLS_Categorie();
                DialogResult PR = MessageBox.Show("Voulez-vous vraiment suprrimer cette catégorie?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(PR == DialogResult.Yes)
                {
                    //Verifier s'il y a des produit dans cette categorie
                    int idcat = (int)dvgcategorie.Rows[e.RowIndex].Cells[1].Value;
                    int P = db.Produits.Count(s => s.ID_CATEGORIE==idcat);

                    if (P == 0)
                    {
                        clscat.Supprimer_Categerie(idcat);
                        MessageBox.Show("Catégorie supprimé avec succces", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //Actualiser la grid d'affichage de categorie
                        remplissagedatagrid();
                    }
                    else
                    {
                        DialogResult PDP= MessageBox.Show("Impossible de supprimer une categorie contenant des produits.Cette categorie contient " + P + " ProsuitsVoulez vous continuer avec la supprission?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (PDP == DialogResult.Yes)
                        {
                            clscat.Supprimer_Categerie(idcat);
                            MessageBox.Show("Catégorie supprimé avec succces", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            //Actualiser la grid d'affichage de categorie
                            remplissagedatagrid();
                        }
                        else
                        {
                            MessageBox.Show("Suppression annulée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Suppression annulée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtrecherche_TextChanged(object sender, EventArgs e)
        {
            var maliste = db.Categories.ToList();
            maliste = maliste.Where(c=> c.Nom_Categorie.IndexOf(txtrecherche.Text,StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            dvgcategorie.Rows.Clear();
            foreach(var l in maliste)
            {
                dvgcategorie.Rows.Add(false,l.Id_Categorie,l.Nom_Categorie);
            }
        }

        private void btnimprimertout_Click(object sender, EventArgs e)
        {
            RAP.FRM_RAPPORT frmR = new RAP.FRM_RAPPORT();
            db = new dbStockContext();

            try
            {
                //Listes Categories
                var listecat = db.Categories.ToList();
                //Nombre de Categorie
                int NBcategorie = db.Categories.Count();
                //Ajouter dataSource

                frmR.RPAfficher.LocalReport.ReportEmbeddedResource = "GestionDeStock.RAP.RPT_LISTES_CATEGORIES.rdlc"; // chemin du rapport
                //Ajouter data source
                frmR.RPAfficher.LocalReport.DataSources.Add(new ReportDataSource("databasecategorie", listecat));
                //Data system
                ReportParameter date = new ReportParameter("Date",DateTime.Now.ToShortDateString());
                ReportParameter Nbc = new ReportParameter("NBCategorie", NBcategorie.ToString());
                frmR.RPAfficher.LocalReport.SetParameters(new ReportParameter[] {date, Nbc});
                frmR.RPAfficher.RefreshReport();
                frmR.ShowDialog(this);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dvgcategorie_CellContent(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifier si l'utilisateur a cliqué sur une cellule qui contient une checkbox
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Assurez-vous que l'index de la colonne est correct
            {
                DataGridViewCheckBoxCell checkBoxCell = dvgcategorie.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null)
                {
                    // Inverser l'état de la case à cocher
                    bool isChecked = (checkBoxCell.Value != null) && (bool)checkBoxCell.Value;
                    checkBoxCell.Value = !isChecked;

                    // Pour rafraîchir l'affichage du DataGridView
                    dvgcategorie.RefreshEdit();
                }
            }
        }
        private void btnsauvegarderexcel_Click(object sender, EventArgs e)
        {
            db = new dbStockContext();
            var NomCategorie = "Selectionner";
            int idcategorie = 0;

            if (SelectVerif() != null)
            {
                MessageBox.Show(SelectVerif(), "Selectionner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SaveFileDialog SF = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })//Filtre uniquement les fichiers Excel
                {
                    if (SF.ShowDialog() == DialogResult.OK)
                    {

                        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                        Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                        Worksheet ws = (Worksheet)app.ActiveSheet;
                        app.Visible = false;

                        //Nom de la categorie et son id
                        for (int j = 0; j < dvgcategorie.Rows.Count; j++)
                        {
                            if ((bool)dvgcategorie.Rows[j].Cells[0].Value == true)
                            {
                                NomCategorie = dvgcategorie.Rows[j].Cells[2].Value.ToString();
                                idcategorie = (int)dvgcategorie.Rows[j].Cells[1].Value;
                            }
                        }

                        //Ecrire le nom de la categorie dans le  fichier excel.
                        ws.Range["A1:D1"].Merge();
                        ws.Range["A1:D1"].Value = NomCategorie;
                        //Ajouter ceels de produit
                        ws.Cells[2, 1] = "Id Produit";
                        ws.Cells[2, 2] = "Nom produit";
                        ws.Cells[2, 3] = "Quantité";
                        ws.Cells[2, 4] = "Prix";

                        //Liste des produit dans cette categorie 
                        var listeporoduit = db.Produits.Where(s => s.ID_CATEGORIE == idcategorie).ToList();
                        int i = 3;
                        foreach(var LP in listeporoduit)
                        {
                            ws.Cells[i, 1]= LP.Id_Produit;
                            ws.Cells[i, 2]= LP.Nom_Produit;
                            ws.Cells[i, 3]= LP.Quantite_Produit;
                            ws.Cells[i, 4]= LP.Prix_Produit;

                            i++;
                        }

                        //Style de fichier excel
                        //produit
                        ws.Range["A2:D2"].Interior.Color = Color.Teal;// background color
                        ws.Range["A2:D2"].Font.Color = Color.White;// texte color
                        ws.Range["A2:D2"].Font.Size = 15;
                        //Categorie
                        ws.Range["A1:D1"].Interior.Color = Color.DarkGreen;// background color
                        ws.Range["A1:D1"].Font.Color = Color.White;// texte color
                        ws.Range["A1:D1"].Font.Size = 15;

                        //Centrer le text
                        ws.Range["A:D"].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        ws.Range["A2:D2"].ColumnWidth = 20;
                        ///--------------------------------------------------------
                        wb.SaveAs(SF.FileName,XlFileFormat.xlWorkbookDefault,Type.Missing,Type.Missing,true,false);//sauvergarder dans le fichier excel
                        app.Quit();
                        MessageBox.Show("Le fichier a été sauvegardé avec succes dans Excel", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
      
        }
    }
}
