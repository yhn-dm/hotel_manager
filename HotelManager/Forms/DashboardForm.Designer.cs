namespace HotelManager.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTotalChambres = new System.Windows.Forms.Label();
            this.lblLibres = new System.Windows.Forms.Label();
            this.lblNettoyer = new System.Windows.Forms.Label();
            this.lblArrives = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();

            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(52, 152, 219); // Bleu clair
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTotalChambres);
            this.panel1.Location = new System.Drawing.Point(50, 40);
            this.panel1.Size = new System.Drawing.Size(300, 150);
            this.panel1.TabIndex = 4;

            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(46, 204, 113); // Vert
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblLibres);
            this.panel2.Location = new System.Drawing.Point(400, 40);
            this.panel2.Size = new System.Drawing.Size(300, 150);
            this.panel2.TabIndex = 5;

            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(241, 196, 15); // Jaune
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblNettoyer);
            this.panel3.Location = new System.Drawing.Point(50, 220);
            this.panel3.Size = new System.Drawing.Size(300, 150);
            this.panel3.TabIndex = 6;

            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(231, 76, 60); // Rouge
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblArrives);
            this.panel4.Location = new System.Drawing.Point(400, 220);
            this.panel4.Size = new System.Drawing.Size(300, 150);
            this.panel4.TabIndex = 7;

            // lblTotalChambres
            this.lblTotalChambres.AutoSize = true;
            this.lblTotalChambres.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalChambres.ForeColor = System.Drawing.Color.White;
            this.lblTotalChambres.Location = new System.Drawing.Point(15, 37); 
            this.lblTotalChambres.Text = "Chambres totales : 0";

            // lblLibres
            this.lblLibres.AutoSize = true;
            this.lblLibres.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLibres.ForeColor = System.Drawing.Color.White;
            this.lblLibres.Location = new System.Drawing.Point(15, 37); 
            this.lblLibres.Text = "Chambres libres \net propres :";

            // lblNettoyer
            this.lblNettoyer.AutoSize = true;
            this.lblNettoyer.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblNettoyer.ForeColor = System.Drawing.Color.White;
            this.lblNettoyer.Location = new System.Drawing.Point(15, 37); 
            this.lblNettoyer.Text = "Chambres à \nnettoyer :";

            // lblArrives
            this.lblArrives.AutoSize = true;
            this.lblArrives.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblArrives.ForeColor = System.Drawing.Color.White;
            this.lblArrives.Location = new System.Drawing.Point(15, 37); 
            this.lblArrives.Text = "Clients arrivés \naujourd’hui :";


            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tableau de bord";

            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
        }


        #endregion


        private System.Windows.Forms.Label lblTotalChambres;
        private System.Windows.Forms.Label lblLibres;
        private System.Windows.Forms.Label lblNettoyer;
        private System.Windows.Forms.Label lblArrives;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}
