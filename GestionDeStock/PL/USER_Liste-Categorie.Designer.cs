namespace GestionDeStock.PL
{
    partial class USER_Liste_Categorie
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dvgcategorie = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categorie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modifier = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Supprimer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtrecherche = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnsauvegarderexcel = new System.Windows.Forms.Button();
            this.btnimprimertout = new System.Windows.Forms.Button();
            this.btnajouterproduit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgcategorie)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvgcategorie
            // 
            this.dvgcategorie.AllowUserToAddRows = false;
            this.dvgcategorie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgcategorie.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dvgcategorie.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgcategorie.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgcategorie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgcategorie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.Id,
            this.Categorie,
            this.Modifier,
            this.Supprimer});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgcategorie.DefaultCellStyle = dataGridViewCellStyle4;
            this.dvgcategorie.EnableHeadersVisualStyles = false;
            this.dvgcategorie.GridColor = System.Drawing.SystemColors.HotTrack;
            this.dvgcategorie.Location = new System.Drawing.Point(39, 134);
            this.dvgcategorie.Name = "dvgcategorie";
            this.dvgcategorie.RowHeadersVisible = false;
            this.dvgcategorie.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dvgcategorie.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dvgcategorie.Size = new System.Drawing.Size(1250, 439);
            this.dvgcategorie.TabIndex = 18;
            this.dvgcategorie.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgcategorie_CellContentClick);
            // 
            // Select
            // 
            this.Select.FillWeight = 47.23416F;
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            // 
            // Id
            // 
            this.Id.FillWeight = 49.94924F;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // Categorie
            // 
            this.Categorie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Categorie.FillWeight = 152.348F;
            this.Categorie.HeaderText = "Nom Categorie";
            this.Categorie.Name = "Categorie";
            // 
            // Modifier
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Green;
            this.Modifier.DefaultCellStyle = dataGridViewCellStyle2;
            this.Modifier.FillWeight = 139.7513F;
            this.Modifier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Modifier.HeaderText = "Modifier";
            this.Modifier.Name = "Modifier";
            this.Modifier.Text = "Modifier";
            this.Modifier.UseColumnTextForButtonValue = true;
            // 
            // Supprimer
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.OliveDrab;
            this.Supprimer.DefaultCellStyle = dataGridViewCellStyle3;
            this.Supprimer.FillWeight = 102.7173F;
            this.Supprimer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Supprimer.HeaderText = "Supprimer";
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.Text = "Supprimer";
            this.Supprimer.UseColumnTextForButtonValue = true;
            // 
            // txtrecherche
            // 
            this.txtrecherche.BackColor = System.Drawing.SystemColors.Control;
            this.txtrecherche.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtrecherche.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrecherche.ForeColor = System.Drawing.Color.DimGray;
            this.txtrecherche.Location = new System.Drawing.Point(545, 37);
            this.txtrecherche.Name = "txtrecherche";
            this.txtrecherche.Size = new System.Drawing.Size(744, 29);
            this.txtrecherche.TabIndex = 20;
            this.txtrecherche.Text = "Recherche";
            this.txtrecherche.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtrecherche.TextChanged += new System.EventHandler(this.txtrecherche_TextChanged);
            this.txtrecherche.Enter += new System.EventHandler(this.txtrecherche_Enter);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.panel3.Controls.Add(this.flowLayoutPanel3);
            this.panel3.Location = new System.Drawing.Point(542, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(750, 3);
            this.panel3.TabIndex = 21;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Location = new System.Drawing.Point(432, 66);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // btnsauvegarderexcel
            // 
            this.btnsauvegarderexcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.btnsauvegarderexcel.FlatAppearance.BorderSize = 0;
            this.btnsauvegarderexcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsauvegarderexcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsauvegarderexcel.ForeColor = System.Drawing.Color.White;
            this.btnsauvegarderexcel.Image = global::GestionDeStock.Properties.Resources.application_office_excel_2474;
            this.btnsauvegarderexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsauvegarderexcel.Location = new System.Drawing.Point(931, 579);
            this.btnsauvegarderexcel.Name = "btnsauvegarderexcel";
            this.btnsauvegarderexcel.Size = new System.Drawing.Size(361, 48);
            this.btnsauvegarderexcel.TabIndex = 23;
            this.btnsauvegarderexcel.Text = "Sauvegarder Categorie";
            this.btnsauvegarderexcel.UseVisualStyleBackColor = false;
            this.btnsauvegarderexcel.Click += new System.EventHandler(this.btnsauvegarderexcel_Click);
            // 
            // btnimprimertout
            // 
            this.btnimprimertout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.btnimprimertout.FlatAppearance.BorderSize = 0;
            this.btnimprimertout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnimprimertout.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnimprimertout.ForeColor = System.Drawing.Color.White;
            this.btnimprimertout.Image = global::GestionDeStock.Properties.Resources._3925426_print_printer_printing_icon_111556;
            this.btnimprimertout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnimprimertout.Location = new System.Drawing.Point(43, 579);
            this.btnimprimertout.Name = "btnimprimertout";
            this.btnimprimertout.Size = new System.Drawing.Size(361, 48);
            this.btnimprimertout.TabIndex = 22;
            this.btnimprimertout.Text = "Imprimer toutes";
            this.btnimprimertout.UseVisualStyleBackColor = false;
            this.btnimprimertout.Click += new System.EventHandler(this.btnimprimertout_Click);
            // 
            // btnajouterproduit
            // 
            this.btnajouterproduit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.btnajouterproduit.FlatAppearance.BorderSize = 0;
            this.btnajouterproduit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnajouterproduit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnajouterproduit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnajouterproduit.Image = global::GestionDeStock.Properties.Resources.add_icon_icons_com_52393;
            this.btnajouterproduit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnajouterproduit.Location = new System.Drawing.Point(43, 30);
            this.btnajouterproduit.Margin = new System.Windows.Forms.Padding(6);
            this.btnajouterproduit.Name = "btnajouterproduit";
            this.btnajouterproduit.Size = new System.Drawing.Size(323, 45);
            this.btnajouterproduit.TabIndex = 19;
            this.btnajouterproduit.Text = "Ajouter ";
            this.btnajouterproduit.UseVisualStyleBackColor = false;
            this.btnajouterproduit.Click += new System.EventHandler(this.btnajouterproduit_Click);
            // 
            // USER_Liste_Categorie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnsauvegarderexcel);
            this.Controls.Add(this.btnimprimertout);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtrecherche);
            this.Controls.Add(this.btnajouterproduit);
            this.Controls.Add(this.dvgcategorie);
            this.Name = "USER_Liste_Categorie";
            this.Size = new System.Drawing.Size(1295, 630);
            this.Load += new System.EventHandler(this.USER_Liste_Categorie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgcategorie)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnajouterproduit;
        private System.Windows.Forms.TextBox txtrecherche;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnimprimertout;
        private System.Windows.Forms.Button btnsauvegarderexcel;
        public System.Windows.Forms.DataGridView dvgcategorie;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categorie;
        private System.Windows.Forms.DataGridViewButtonColumn Modifier;
        private System.Windows.Forms.DataGridViewButtonColumn Supprimer;
    }
}
