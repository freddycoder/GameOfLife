namespace GameOfLife
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LabelLongeur = new System.Windows.Forms.ToolStripLabel();
            this.TextboxLongeur = new System.Windows.Forms.ToolStripTextBox();
            this.LabelHauteur = new System.Windows.Forms.ToolStripLabel();
            this.TextboxHauteur = new System.Windows.Forms.ToolStripTextBox();
            this.LabelCarte = new System.Windows.Forms.ToolStripLabel();
            this.listTemplate = new System.Windows.Forms.ToolStripComboBox();
            this.NouvelleCarteAleatoire = new System.Windows.Forms.ToolStripButton();
            this.LabelSleepTime = new System.Windows.Forms.ToolStripLabel();
            this.SleepTime = new System.Windows.Forms.ToolStripTextBox();
            this.LabelT = new System.Windows.Forms.ToolStripLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelMessageError = new System.Windows.Forms.Label();
            this.gameOfLifeImage = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameOfLifeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelLongeur,
            this.TextboxLongeur,
            this.LabelHauteur,
            this.TextboxHauteur,
            this.LabelCarte,
            this.listTemplate,
            this.NouvelleCarteAleatoire,
            this.LabelSleepTime,
            this.SleepTime,
            this.LabelT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "Nouvelle Carte Aléatoire";
            // 
            // LabelLongeur
            // 
            this.LabelLongeur.Name = "LabelLongeur";
            this.LabelLongeur.Size = new System.Drawing.Size(51, 22);
            this.LabelLongeur.Text = "Longeur";
            // 
            // TextboxLongeur
            // 
            this.TextboxLongeur.Name = "TextboxLongeur";
            this.TextboxLongeur.Size = new System.Drawing.Size(100, 25);
            // 
            // LabelHauteur
            // 
            this.LabelHauteur.Name = "LabelHauteur";
            this.LabelHauteur.Size = new System.Drawing.Size(50, 22);
            this.LabelHauteur.Text = "Hauteur";
            // 
            // TextboxHauteur
            // 
            this.TextboxHauteur.Name = "TextboxHauteur";
            this.TextboxHauteur.Size = new System.Drawing.Size(100, 25);
            // 
            // LabelCarte
            // 
            this.LabelCarte.Name = "LabelCarte";
            this.LabelCarte.Size = new System.Drawing.Size(35, 22);
            this.LabelCarte.Text = "Carte";
            // 
            // listTemplate
            // 
            this.listTemplate.Name = "listTemplate";
            this.listTemplate.Size = new System.Drawing.Size(121, 25);
            // 
            // NouvelleCarteAleatoire
            // 
            this.NouvelleCarteAleatoire.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NouvelleCarteAleatoire.Image = ((System.Drawing.Image)(resources.GetObject("NouvelleCarteAleatoire.Image")));
            this.NouvelleCarteAleatoire.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NouvelleCarteAleatoire.Name = "NouvelleCarteAleatoire";
            this.NouvelleCarteAleatoire.Size = new System.Drawing.Size(139, 22);
            this.NouvelleCarteAleatoire.Text = "Nouvelle Carte Aléatoire";
            this.NouvelleCarteAleatoire.ToolTipText = "Nouvelle Carte Aléatoire";
            // 
            // LabelSleepTime
            // 
            this.LabelSleepTime.Name = "LabelSleepTime";
            this.LabelSleepTime.Size = new System.Drawing.Size(47, 22);
            this.LabelSleepTime.Text = "Ms.A.R.";
            this.LabelSleepTime.ToolTipText = "Milliseconde avant rafraichissement";
            // 
            // SleepTime
            // 
            this.SleepTime.Name = "SleepTime";
            this.SleepTime.Size = new System.Drawing.Size(100, 25);
            // 
            // LabelT
            // 
            this.LabelT.Name = "LabelT";
            this.LabelT.Size = new System.Drawing.Size(23, 22);
            this.LabelT.Text = "t: 0";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.LabelMessageError, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gameOfLifeImage, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.54519F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.45481F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 343);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // LabelMessageError
            // 
            this.LabelMessageError.AutoSize = true;
            this.LabelMessageError.Location = new System.Drawing.Point(3, 314);
            this.LabelMessageError.Name = "LabelMessageError";
            this.LabelMessageError.Size = new System.Drawing.Size(38, 15);
            this.LabelMessageError.TabIndex = 0;
            this.LabelMessageError.Text = "label1";
            // 
            // gameOfLifeImage
            // 
            this.gameOfLifeImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameOfLifeImage.Location = new System.Drawing.Point(3, 3);
            this.gameOfLifeImage.Name = "gameOfLifeImage";
            this.gameOfLifeImage.Size = new System.Drawing.Size(788, 308);
            this.gameOfLifeImage.TabIndex = 1;
            this.gameOfLifeImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 371);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameOfLifeImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel LabelLongeur;
        private System.Windows.Forms.ToolStripTextBox TextboxLongeur;
        private System.Windows.Forms.ToolStripLabel LabelHauteur;
        private System.Windows.Forms.ToolStripTextBox TextboxHauteur;
        private System.Windows.Forms.ToolStripLabel LabelCarte;
        private System.Windows.Forms.ToolStripComboBox listTemplate;
        private System.Windows.Forms.ToolStripButton NouvelleCarteAleatoire;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LabelMessageError;
        private System.Windows.Forms.PictureBox gameOfLifeImage;
        private System.Windows.Forms.ToolStripTextBox SleepTime;
        private System.Windows.Forms.ToolStripLabel LabelSleepTime;
        private System.Windows.Forms.ToolStripLabel LabelT;
    }
}

