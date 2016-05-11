namespace PFI3
{
    partial class PFI3
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LBL_AireRectangle = new System.Windows.Forms.Label();
            this.BTN_CalculerAire = new System.Windows.Forms.Button();
            this.NUD_a = new System.Windows.Forms.NumericUpDown();
            this.NUD_b = new System.Windows.Forms.NumericUpDown();
            this.NUD_yMax = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_a)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_b)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_yMax)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "P(a < X < b)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "a: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "b: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "y max: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Aire rectangle: ";
            // 
            // LBL_AireRectangle
            // 
            this.LBL_AireRectangle.AutoSize = true;
            this.LBL_AireRectangle.Location = new System.Drawing.Point(88, 125);
            this.LBL_AireRectangle.Name = "LBL_AireRectangle";
            this.LBL_AireRectangle.Size = new System.Drawing.Size(41, 13);
            this.LBL_AireRectangle.TabIndex = 4;
            this.LBL_AireRectangle.Text = "answer";
            // 
            // BTN_CalculerAire
            // 
            this.BTN_CalculerAire.Location = new System.Drawing.Point(12, 159);
            this.BTN_CalculerAire.Name = "BTN_CalculerAire";
            this.BTN_CalculerAire.Size = new System.Drawing.Size(117, 44);
            this.BTN_CalculerAire.TabIndex = 5;
            this.BTN_CalculerAire.Text = "Calculer aire rectangle";
            this.BTN_CalculerAire.UseVisualStyleBackColor = true;
            this.BTN_CalculerAire.Click += new System.EventHandler(this.BTN_CalculerAire_Click);
            // 
            // NUD_a
            // 
            this.NUD_a.Location = new System.Drawing.Point(59, 40);
            this.NUD_a.Name = "NUD_a";
            this.NUD_a.Size = new System.Drawing.Size(70, 20);
            this.NUD_a.TabIndex = 6;
            // 
            // NUD_b
            // 
            this.NUD_b.Location = new System.Drawing.Point(59, 66);
            this.NUD_b.Name = "NUD_b";
            this.NUD_b.Size = new System.Drawing.Size(70, 20);
            this.NUD_b.TabIndex = 6;
            // 
            // NUD_yMax
            // 
            this.NUD_yMax.Location = new System.Drawing.Point(59, 92);
            this.NUD_yMax.Name = "NUD_yMax";
            this.NUD_yMax.Size = new System.Drawing.Size(70, 20);
            this.NUD_yMax.TabIndex = 6;
            // 
            // PFI3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 215);
            this.Controls.Add(this.NUD_yMax);
            this.Controls.Add(this.NUD_b);
            this.Controls.Add(this.NUD_a);
            this.Controls.Add(this.BTN_CalculerAire);
            this.Controls.Add(this.LBL_AireRectangle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PFI3";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PFI3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_a)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_b)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_yMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LBL_AireRectangle;
        private System.Windows.Forms.Button BTN_CalculerAire;
        private System.Windows.Forms.NumericUpDown NUD_a;
        private System.Windows.Forms.NumericUpDown NUD_b;
        private System.Windows.Forms.NumericUpDown NUD_yMax;
    }
}

