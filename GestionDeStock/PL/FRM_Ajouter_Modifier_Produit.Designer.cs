namespace GestionDeStock.PL
{
    partial class FRM_Ajouter_Modifier_Produit
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
            this.lblTitre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnparcourir = new System.Windows.Forms.Button();
            this.combocategorie = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnenregistrer = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtprixproduit = new System.Windows.Forms.TextBox();
            this.txtquantiteproduit = new System.Windows.Forms.TextBox();
            this.txtnomproduit = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnactualiser = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureproduit = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureproduit)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitre.Location = new System.Drawing.Point(288, 9);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(207, 33);
            this.lblTitre.TabIndex = 37;
            this.lblTitre.Text = "Ajouter Produit";
            this.lblTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 29);
            this.label1.TabIndex = 63;
            this.label1.Text = "Image:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 3);
            this.panel1.TabIndex = 64;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(795, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 461);
            this.panel2.TabIndex = 65;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 461);
            this.panel3.TabIndex = 66;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 461);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(792, 3);
            this.panel4.TabIndex = 67;
            // 
            // btnparcourir
            // 
            this.btnparcourir.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnparcourir.FlatAppearance.BorderSize = 0;
            this.btnparcourir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnparcourir.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnparcourir.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnparcourir.Location = new System.Drawing.Point(158, 243);
            this.btnparcourir.Name = "btnparcourir";
            this.btnparcourir.Size = new System.Drawing.Size(198, 43);
            this.btnparcourir.TabIndex = 68;
            this.btnparcourir.Text = "Parcourire..";
            this.btnparcourir.UseVisualStyleBackColor = false;
            this.btnparcourir.Click += new System.EventHandler(this.btnparcourir_Click);
            // 
            // combocategorie
            // 
            this.combocategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combocategorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combocategorie.FormattingEnabled = true;
            this.combocategorie.Items.AddRange(new object[] {
            "Nom",
            "Prenom",
            "Telephone",
            "Email",
            "Ville",
            "Pays"});
            this.combocategorie.Location = new System.Drawing.Point(513, 73);
            this.combocategorie.Name = "combocategorie";
            this.combocategorie.Size = new System.Drawing.Size(262, 33);
            this.combocategorie.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(372, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 29);
            this.label2.TabIndex = 70;
            this.label2.Text = "Categorie:";
            // 
            // btnenregistrer
            // 
            this.btnenregistrer.BackColor = System.Drawing.Color.Maroon;
            this.btnenregistrer.FlatAppearance.BorderSize = 0;
            this.btnenregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnenregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnenregistrer.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnenregistrer.Location = new System.Drawing.Point(456, 377);
            this.btnenregistrer.Name = "btnenregistrer";
            this.btnenregistrer.Size = new System.Drawing.Size(319, 54);
            this.btnenregistrer.TabIndex = 76;
            this.btnenregistrer.Text = "Enregistrer";
            this.btnenregistrer.UseVisualStyleBackColor = false;
            this.btnenregistrer.Click += new System.EventHandler(this.btnenregistrer_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel7.Location = new System.Drawing.Point(513, 195);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(262, 3);
            this.panel7.TabIndex = 75;
            // 
            // txtprixproduit
            // 
            this.txtprixproduit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.txtprixproduit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtprixproduit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprixproduit.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtprixproduit.Location = new System.Drawing.Point(514, 308);
            this.txtprixproduit.Multiline = true;
            this.txtprixproduit.Name = "txtprixproduit";
            this.txtprixproduit.Size = new System.Drawing.Size(261, 36);
            this.txtprixproduit.TabIndex = 73;
            this.txtprixproduit.Text = "Prix";
            this.txtprixproduit.Enter += new System.EventHandler(this.txtprixproduit_Enter);
            this.txtprixproduit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprixproduit_KeyPress);
            this.txtprixproduit.Leave += new System.EventHandler(this.txtprixproduit_Leave);
            // 
            // txtquantiteproduit
            // 
            this.txtquantiteproduit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.txtquantiteproduit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtquantiteproduit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtquantiteproduit.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtquantiteproduit.Location = new System.Drawing.Point(513, 223);
            this.txtquantiteproduit.Multiline = true;
            this.txtquantiteproduit.Name = "txtquantiteproduit";
            this.txtquantiteproduit.Size = new System.Drawing.Size(262, 39);
            this.txtquantiteproduit.TabIndex = 72;
            this.txtquantiteproduit.Text = "Quantité";
            this.txtquantiteproduit.Enter += new System.EventHandler(this.txtquantiteproduit_Enter);
            this.txtquantiteproduit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtquantiteproduit_KeyPress);
            this.txtquantiteproduit.Leave += new System.EventHandler(this.txtquantiteproduit_Leave);
            // 
            // txtnomproduit
            // 
            this.txtnomproduit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.txtnomproduit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtnomproduit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnomproduit.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtnomproduit.Location = new System.Drawing.Point(513, 154);
            this.txtnomproduit.Multiline = true;
            this.txtnomproduit.Name = "txtnomproduit";
            this.txtnomproduit.Size = new System.Drawing.Size(262, 44);
            this.txtnomproduit.TabIndex = 71;
            this.txtnomproduit.Text = "Nom Produit";
            this.txtnomproduit.Enter += new System.EventHandler(this.txtnomproduit_Enter);
            this.txtnomproduit.Leave += new System.EventHandler(this.txtnomproduit_Leave);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel5.Location = new System.Drawing.Point(514, 255);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(261, 3);
            this.panel5.TabIndex = 77;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel6.Location = new System.Drawing.Point(517, 341);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(258, 3);
            this.panel6.TabIndex = 78;
            // 
            // btnactualiser
            // 
            this.btnactualiser.BackColor = System.Drawing.Color.Maroon;
            this.btnactualiser.FlatAppearance.BorderSize = 0;
            this.btnactualiser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnactualiser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnactualiser.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnactualiser.Location = new System.Drawing.Point(58, 377);
            this.btnactualiser.Name = "btnactualiser";
            this.btnactualiser.Size = new System.Drawing.Size(298, 54);
            this.btnactualiser.TabIndex = 79;
            this.btnactualiser.Text = "Actualiser";
            this.btnactualiser.UseVisualStyleBackColor = false;
            this.btnactualiser.Click += new System.EventHandler(this.btnactualiser_Click);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = global::GestionDeStock.Properties.Resources._1486564179_finance_saving_81499;
            this.button4.Location = new System.Drawing.Point(456, 302);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 49);
            this.button4.TabIndex = 82;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::GestionDeStock.Properties.Resources.Box_full_29854;
            this.button3.Location = new System.Drawing.Point(456, 223);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 48);
            this.button3.TabIndex = 81;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::GestionDeStock.Properties.Resources.shopping_cart_caddy_icon_185995;
            this.button2.Location = new System.Drawing.Point(456, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 43);
            this.button2.TabIndex = 80;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pictureproduit
            // 
            this.pictureproduit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureproduit.Location = new System.Drawing.Point(110, 73);
            this.pictureproduit.Name = "pictureproduit";
            this.pictureproduit.Size = new System.Drawing.Size(246, 155);
            this.pictureproduit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureproduit.TabIndex = 62;
            this.pictureproduit.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::GestionDeStock.Properties.Resources.delete_remove_close_icon_181533;
            this.button1.Location = new System.Drawing.Point(742, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 32);
            this.button1.TabIndex = 52;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FRM_Ajouter_Modifier_Produit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(798, 464);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnactualiser);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnenregistrer);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.txtprixproduit);
            this.Controls.Add(this.txtquantiteproduit);
            this.Controls.Add(this.txtnomproduit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combocategorie);
            this.Controls.Add(this.btnparcourir);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureproduit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTitre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_Ajouter_Modifier_Produit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_Ajouter_Modifier_Produit";
            ((System.ComponentModel.ISupportInitialize)(this.pictureproduit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel7;
        public System.Windows.Forms.TextBox txtprixproduit;
        public System.Windows.Forms.TextBox txtquantiteproduit;
        public System.Windows.Forms.TextBox txtnomproduit;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.Button btnactualiser;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.Button btnenregistrer;
        public System.Windows.Forms.PictureBox pictureproduit;
        public System.Windows.Forms.Button btnparcourir;
        public System.Windows.Forms.ComboBox combocategorie;
    }
}