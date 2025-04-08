namespace HotelManager.Forms
{
    partial class ChambreForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblTarif = new System.Windows.Forms.Label();
            this.lblStatut = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtTarif = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbStatut = new System.Windows.Forms.ComboBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dataGridChambres = new System.Windows.Forms.DataGridView();
            this.dataGridReservationsChambre = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridChambres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReservationsChambre)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(97, 406);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(65, 20);
            this.lblNumero.TabIndex = 1;
            this.lblNumero.Text = "Numéro";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(97, 446);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(43, 20);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Type";
            // 
            // lblTarif
            // 
            this.lblTarif.AutoSize = true;
            this.lblTarif.Location = new System.Drawing.Point(385, 409);
            this.lblTarif.Name = "lblTarif";
            this.lblTarif.Size = new System.Drawing.Size(40, 20);
            this.lblTarif.TabIndex = 5;
            this.lblTarif.Text = "Tarif";
            // 
            // lblStatut
            // 
            this.lblStatut.AutoSize = true;
            this.lblStatut.Location = new System.Drawing.Point(385, 449);
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(53, 20);
            this.lblStatut.TabIndex = 7;
            this.lblStatut.Text = "Statut";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(197, 403);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(150, 26);
            this.txtNumero.TabIndex = 2;
            // 
            // txtTarif
            // 
            this.txtTarif.Location = new System.Drawing.Point(485, 406);
            this.txtTarif.Name = "txtTarif";
            this.txtTarif.Size = new System.Drawing.Size(150, 26);
            this.txtTarif.TabIndex = 6;
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(197, 443);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(150, 28);
            this.cmbType.TabIndex = 4;
            // 
            // cmbStatut
            // 
            this.cmbStatut.FormattingEnabled = true;
            this.cmbStatut.Location = new System.Drawing.Point(485, 446);
            this.cmbStatut.Name = "cmbStatut";
            this.cmbStatut.Size = new System.Drawing.Size(150, 28);
            this.cmbStatut.TabIndex = 8;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(711, 406);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(120, 35);
            this.btnAjouter.TabIndex = 9;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(711, 446);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(120, 35);
            this.btnModifier.TabIndex = 10;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(711, 486);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(120, 35);
            this.btnSupprimer.TabIndex = 11;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(711, 526);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 35);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Réinitialiser";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dataGridChambres
            // 
            this.dataGridChambres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridChambres.Location = new System.Drawing.Point(47, 66);
            this.dataGridChambres.Name = "dataGridChambres";
            this.dataGridChambres.RowHeadersWidth = 62;
            this.dataGridChambres.RowTemplate.Height = 28;
            this.dataGridChambres.Size = new System.Drawing.Size(987, 296);
            this.dataGridChambres.TabIndex = 0;
            this.dataGridChambres.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridChambres_CellClick);
            this.dataGridChambres.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridChambres_CellContentClick_1);
            // 
            // dataGridReservationsChambre
            // 
            this.dataGridReservationsChambre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReservationsChambre.Location = new System.Drawing.Point(47, 611);
            this.dataGridReservationsChambre.Name = "dataGridReservationsChambre";
            this.dataGridReservationsChambre.RowHeadersWidth = 62;
            this.dataGridReservationsChambre.RowTemplate.Height = 28;
            this.dataGridReservationsChambre.Size = new System.Drawing.Size(987, 296);
            this.dataGridReservationsChambre.TabIndex = 13;
            this.dataGridReservationsChambre.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridReservationsChambre_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Chambres :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 585);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Historique :";
            // 
            // ChambreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1140, 1023);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridReservationsChambre);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.cmbStatut);
            this.Controls.Add(this.lblStatut);
            this.Controls.Add(this.txtTarif);
            this.Controls.Add(this.lblTarif);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.dataGridChambres);
            this.Name = "ChambreForm";
            this.Load += new System.EventHandler(this.ChambreForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridChambres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReservationsChambre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblTarif;
        private System.Windows.Forms.Label lblStatut;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtTarif;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmbStatut;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dataGridChambres;
        private System.Windows.Forms.DataGridView dataGridReservationsChambre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
