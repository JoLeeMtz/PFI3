namespace PFI3
{
    partial class Menu
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
            this.BTN_Opt1 = new System.Windows.Forms.Button();
            this.BTN_Opt2 = new System.Windows.Forms.Button();
            this.BTN_Opt3 = new System.Windows.Forms.Button();
            this.BTN_Opt4 = new System.Windows.Forms.Button();
            this.BTN_Opt5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_Opt1
            // 
            this.BTN_Opt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Opt1.Location = new System.Drawing.Point(12, 12);
            this.BTN_Opt1.Name = "BTN_Opt1";
            this.BTN_Opt1.Size = new System.Drawing.Size(343, 48);
            this.BTN_Opt1.TabIndex = 0;
            this.BTN_Opt1.Text = "f(x)= - ³√( x² - 16x + 63) + 4";
            this.BTN_Opt1.UseVisualStyleBackColor = true;
            this.BTN_Opt1.Click += new System.EventHandler(this.BTN_Opt1_Click);
            // 
            // BTN_Opt2
            // 
            this.BTN_Opt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Opt2.Location = new System.Drawing.Point(12, 66);
            this.BTN_Opt2.Name = "BTN_Opt2";
            this.BTN_Opt2.Size = new System.Drawing.Size(343, 48);
            this.BTN_Opt2.TabIndex = 0;
            this.BTN_Opt2.Text = "f(x)= 3 * (x-7/5)⁵ - 5 * (x-7/5)³ +3";
            this.BTN_Opt2.UseVisualStyleBackColor = true;
            this.BTN_Opt2.Click += new System.EventHandler(this.BTN_Opt2_Click);
            // 
            // BTN_Opt3
            // 
            this.BTN_Opt3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Opt3.Location = new System.Drawing.Point(12, 120);
            this.BTN_Opt3.Name = "BTN_Opt3";
            this.BTN_Opt3.Size = new System.Drawing.Size(343, 48);
            this.BTN_Opt3.TabIndex = 0;
            this.BTN_Opt3.Text = "f(x)= -1/3 * (x - 6)² + 12";
            this.BTN_Opt3.UseVisualStyleBackColor = true;
            this.BTN_Opt3.Click += new System.EventHandler(this.BTN_Opt3_Click);
            // 
            // BTN_Opt4
            // 
            this.BTN_Opt4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Opt4.Location = new System.Drawing.Point(12, 174);
            this.BTN_Opt4.Name = "BTN_Opt4";
            this.BTN_Opt4.Size = new System.Drawing.Size(343, 48);
            this.BTN_Opt4.TabIndex = 0;
            this.BTN_Opt4.Text = "f(x)= x + sin(x)";
            this.BTN_Opt4.UseVisualStyleBackColor = true;
            this.BTN_Opt4.Click += new System.EventHandler(this.BTN_Opt4_Click);
            // 
            // BTN_Opt5
            // 
            this.BTN_Opt5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Opt5.Location = new System.Drawing.Point(12, 228);
            this.BTN_Opt5.Name = "BTN_Opt5";
            this.BTN_Opt5.Size = new System.Drawing.Size(343, 48);
            this.BTN_Opt5.TabIndex = 0;
            this.BTN_Opt5.Text = "f(x)= cos(x) + 3";
            this.BTN_Opt5.UseVisualStyleBackColor = true;
            this.BTN_Opt5.Click += new System.EventHandler(this.BTN_Opt5_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 289);
            this.Controls.Add(this.BTN_Opt5);
            this.Controls.Add(this.BTN_Opt4);
            this.Controls.Add(this.BTN_Opt3);
            this.Controls.Add(this.BTN_Opt2);
            this.Controls.Add(this.BTN_Opt1);
            this.MaximumSize = new System.Drawing.Size(383, 328);
            this.MinimumSize = new System.Drawing.Size(383, 328);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_Opt1;
        private System.Windows.Forms.Button BTN_Opt2;
        private System.Windows.Forms.Button BTN_Opt3;
        private System.Windows.Forms.Button BTN_Opt4;
        private System.Windows.Forms.Button BTN_Opt5;
    }
}