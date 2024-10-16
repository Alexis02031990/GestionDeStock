namespace GestionDeStock.PL
{
    partial class USER_Liste_Commande
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dvgCommande = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.directorySearcher2 = new System.DirectoryServices.DirectorySearcher();
            this.datebebut = new System.Windows.Forms.Label();
            this.datefin = new System.Windows.Forms.Label();
            this.dateDebut = new System.Windows.Forms.DateTimePicker();
            this.datedefin = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnimprimer = new System.Windows.Forms.Button();
            this.btnajouterproduit = new System.Windows.Forms.Button();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantité = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalTTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCommande)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgCommande
            // 
            this.dvgCommande.AllowUserToAddRows = false;
            this.dvgCommande.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgCommande.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dvgCommande.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgCommande.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgCommande.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgCommande.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Date,
            this.Client,
            this.Quantité,
            this.TotalHT,
            this.TVA,
            this.TotalTTC});
            this.dvgCommande.EnableHeadersVisualStyles = false;
            this.dvgCommande.Location = new System.Drawing.Point(24, 115);
            this.dvgCommande.Name = "dvgCommande";
            this.dvgCommande.RowHeadersVisible = false;
            this.dvgCommande.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dvgCommande.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dvgCommande.Size = new System.Drawing.Size(1270, 462);
            this.dvgCommande.TabIndex = 30;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // directorySearcher2
            // 
            this.directorySearcher2.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher2.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher2.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // datebebut
            // 
            this.datebebut.AutoSize = true;
            this.datebebut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datebebut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.datebebut.Location = new System.Drawing.Point(340, 43);
            this.datebebut.Name = "datebebut";
            this.datebebut.Size = new System.Drawing.Size(119, 24);
            this.datebebut.TabIndex = 82;
            this.datebebut.Text = "Date Début:";
            // 
            // datefin
            // 
            this.datefin.AutoSize = true;
            this.datefin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datefin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.datefin.Location = new System.Drawing.Point(876, 43);
            this.datefin.Name = "datefin";
            this.datefin.Size = new System.Drawing.Size(94, 24);
            this.datefin.TabIndex = 83;
            this.datefin.Text = "Date Fin:";
            // 
            // dateDebut
            // 
            this.dateDebut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDebut.Location = new System.Drawing.Point(465, 43);
            this.dateDebut.Name = "dateDebut";
            this.dateDebut.Size = new System.Drawing.Size(240, 23);
            this.dateDebut.TabIndex = 84;
            // 
            // datedefin
            // 
            this.datedefin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datedefin.Location = new System.Drawing.Point(976, 44);
            this.datedefin.Name = "datedefin";
            this.datedefin.Size = new System.Drawing.Size(236, 23);
            this.datedefin.TabIndex = 85;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Image = global::GestionDeStock.Properties.Resources.telecharger_156341;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(24, 586);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(355, 52);
            this.button1.TabIndex = 86;
            this.button1.Text = "Générer une facture";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::GestionDeStock.Properties.Resources.preferencessystemsearch_94404__1_1;
            this.button2.Location = new System.Drawing.Point(1218, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 68);
            this.button2.TabIndex = 81;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnimprimer
            // 
            this.btnimprimer.BackColor = System.Drawing.Color.Navy;
            this.btnimprimer.FlatAppearance.BorderSize = 0;
            this.btnimprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnimprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnimprimer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnimprimer.Image = global::GestionDeStock.Properties.Resources._3925426_print_printer_printing_icon_1115561;
            this.btnimprimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnimprimer.Location = new System.Drawing.Point(940, 586);
            this.btnimprimer.Margin = new System.Windows.Forms.Padding(6);
            this.btnimprimer.Name = "btnimprimer";
            this.btnimprimer.Size = new System.Drawing.Size(354, 52);
            this.btnimprimer.TabIndex = 32;
            this.btnimprimer.Text = "Imprimer la commande";
            this.btnimprimer.UseVisualStyleBackColor = false;
            this.btnimprimer.Click += new System.EventHandler(this.btnimprimer_Click);
            // 
            // btnajouterproduit
            // 
            this.btnajouterproduit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.btnajouterproduit.FlatAppearance.BorderSize = 0;
            this.btnajouterproduit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnajouterproduit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnajouterproduit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnajouterproduit.Image = global::GestionDeStock.Properties.Resources.add_icon_icons1;
            this.btnajouterproduit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnajouterproduit.Location = new System.Drawing.Point(24, 34);
            this.btnajouterproduit.Margin = new System.Windows.Forms.Padding(6);
            this.btnajouterproduit.Name = "btnajouterproduit";
            this.btnajouterproduit.Size = new System.Drawing.Size(307, 56);
            this.btnajouterproduit.TabIndex = 23;
            this.btnajouterproduit.Text = "Ajouter ";
            this.btnajouterproduit.UseVisualStyleBackColor = false;
            this.btnajouterproduit.Click += new System.EventHandler(this.btnajouterproduit_Click);
            // 
            // Column9
            // 
            this.Column9.FillWeight = 21.52777F;
            this.Column9.HeaderText = "Id";
            this.Column9.Name = "Column9";
            // 
            // Date
            // 
            this.Date.FillWeight = 36.42081F;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Client
            // 
            this.Client.FillWeight = 39.54904F;
            this.Client.HeaderText = "Client";
            this.Client.Name = "Client";
            // 
            // Quantité
            // 
            this.Quantité.FillWeight = 23.34616F;
            this.Quantité.HeaderText = "Quantite";
            this.Quantité.Name = "Quantité";
            // 
            // TotalHT
            // 
            this.TotalHT.FillWeight = 34.25455F;
            this.TotalHT.HeaderText = "ToTal HT";
            this.TotalHT.Name = "TotalHT";
            // 
            // TVA
            // 
            this.TVA.FillWeight = 30.76743F;
            this.TVA.HeaderText = "TVA%";
            this.TVA.Name = "TVA";
            // 
            // TotalTTC
            // 
            this.TotalTTC.FillWeight = 26.18279F;
            this.TotalTTC.HeaderText = "TOTAL TTC";
            this.TotalTTC.Name = "TotalTTC";
            // 
            // USER_Liste_Commande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.datedefin);
            this.Controls.Add(this.dateDebut);
            this.Controls.Add(this.datefin);
            this.Controls.Add(this.datebebut);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnimprimer);
            this.Controls.Add(this.btnajouterproduit);
            this.Controls.Add(this.dvgCommande);
            this.Name = "USER_Liste_Commande";
            this.Size = new System.Drawing.Size(1301, 644);
            this.Load += new System.EventHandler(this.USER_Liste_Commande_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgCommande)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgCommande;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnajouterproduit;
        private System.Windows.Forms.Button btnimprimer;
        private System.Windows.Forms.Button button2;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.DirectoryServices.DirectorySearcher directorySearcher2;
        private System.Windows.Forms.Label datebebut;
        private System.Windows.Forms.Label datefin;
        private System.Windows.Forms.DateTimePicker dateDebut;
        private System.Windows.Forms.DateTimePicker datedefin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantité;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalTTC;
    }
}
