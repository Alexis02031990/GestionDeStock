namespace GestionDeStock.PL
{
    partial class FRM_HOME_PAGE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.dvgHistoriqueCommande = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCommandes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartProduits = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartStock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dvgCommandes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pbxDiaporama = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgHistoriqueCommande)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCommandes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProduits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCommandes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDiaporama)).BeginInit();
            this.SuspendLayout();
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // dvgHistoriqueCommande
            // 
            this.dvgHistoriqueCommande.BackColor = System.Drawing.Color.MediumSeaGreen;
            chartArea1.Name = "ChartArea1";
            this.dvgHistoriqueCommande.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.dvgHistoriqueCommande.Legends.Add(legend1);
            this.dvgHistoriqueCommande.Location = new System.Drawing.Point(12, -3);
            this.dvgHistoriqueCommande.Name = "dvgHistoriqueCommande";
            this.dvgHistoriqueCommande.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.dvgHistoriqueCommande.Series.Add(series1);
            this.dvgHistoriqueCommande.Size = new System.Drawing.Size(446, 350);
            this.dvgHistoriqueCommande.TabIndex = 1;
            this.dvgHistoriqueCommande.Text = "Historique Commande";
            // 
            // chartCommandes
            // 
            this.chartCommandes.BackColor = System.Drawing.Color.DarkGoldenrod;
            chartArea2.Name = "ChartArea1";
            this.chartCommandes.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartCommandes.Legends.Add(legend2);
            this.chartCommandes.Location = new System.Drawing.Point(12, 342);
            this.chartCommandes.Name = "chartCommandes";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartCommandes.Series.Add(series2);
            this.chartCommandes.Size = new System.Drawing.Size(446, 340);
            this.chartCommandes.TabIndex = 2;
            this.chartCommandes.Text = "Commandes";
            // 
            // chartProduits
            // 
            this.chartProduits.BackColor = System.Drawing.Color.Cyan;
            chartArea3.Name = "ChartArea1";
            this.chartProduits.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartProduits.Legends.Add(legend3);
            this.chartProduits.Location = new System.Drawing.Point(455, 342);
            this.chartProduits.Name = "chartProduits";
            this.chartProduits.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartProduits.Series.Add(series3);
            this.chartProduits.Size = new System.Drawing.Size(446, 340);
            this.chartProduits.TabIndex = 5;
            this.chartProduits.Text = "Produits";
            // 
            // chartStock
            // 
            this.chartStock.BackColor = System.Drawing.Color.RosyBrown;
            chartArea4.Name = "ChartArea1";
            this.chartStock.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartStock.Legends.Add(legend4);
            this.chartStock.Location = new System.Drawing.Point(883, 342);
            this.chartStock.Name = "chartStock";
            this.chartStock.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartStock.Series.Add(series4);
            this.chartStock.Size = new System.Drawing.Size(430, 340);
            this.chartStock.TabIndex = 6;
            this.chartStock.Text = "chart Stock";
            // 
            // dvgCommandes
            // 
            this.dvgCommandes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            chartArea5.Name = "ChartArea1";
            this.dvgCommandes.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.dvgCommandes.Legends.Add(legend5);
            this.dvgCommandes.Location = new System.Drawing.Point(883, -3);
            this.dvgCommandes.Name = "dvgCommandes";
            this.dvgCommandes.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.dvgCommandes.Series.Add(series5);
            this.dvgCommandes.Size = new System.Drawing.Size(430, 350);
            this.dvgCommandes.TabIndex = 4;
            this.dvgCommandes.Text = "Produits En Stock";
            // 
            // pbxDiaporama
            // 
            this.pbxDiaporama.BackColor = System.Drawing.Color.White;
            this.pbxDiaporama.Location = new System.Drawing.Point(455, -3);
            this.pbxDiaporama.Name = "pbxDiaporama";
            this.pbxDiaporama.Size = new System.Drawing.Size(427, 345);
            this.pbxDiaporama.TabIndex = 8;
            this.pbxDiaporama.TabStop = false;
            this.pbxDiaporama.Click += new System.EventHandler(this.pbxDiaporama_Click);
            // 
            // FRM_HOME_PAGE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1313, 684);
            this.Controls.Add(this.pbxDiaporama);
            this.Controls.Add(this.chartStock);
            this.Controls.Add(this.chartProduits);
            this.Controls.Add(this.dvgCommandes);
            this.Controls.Add(this.chartCommandes);
            this.Controls.Add(this.dvgHistoriqueCommande);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_HOME_PAGE";
            this.Text = "FRM_HOME_PAGE";
            ((System.ComponentModel.ISupportInitialize)(this.dvgHistoriqueCommande)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCommandes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProduits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCommandes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDiaporama)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.DataVisualization.Charting.Chart dvgHistoriqueCommande;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCommandes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProduits;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStock;
        private System.Windows.Forms.DataVisualization.Charting.Chart dvgCommandes;
        private System.Windows.Forms.PictureBox pbxDiaporama;
    }
}