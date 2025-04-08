using System.Windows.Forms;

namespace HotelManager.Forms
{
    partial class ReservationForm
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
            this.dataGridReservations = new System.Windows.Forms.DataGridView();
            this.lblClient = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.lblChambre = new System.Windows.Forms.Label();
            this.cmbChambre = new System.Windows.Forms.ComboBox();
            this.lblChambreStatut = new System.Windows.Forms.Label();
            this.lblArrivee = new System.Windows.Forms.Label();
            this.dtpArrivee = new System.Windows.Forms.DateTimePicker();
            this.lblDepart = new System.Windows.Forms.Label();
            this.dtpDepart = new System.Windows.Forms.DateTimePicker();
            this.lblStatut = new System.Windows.Forms.Label();
            this.cmbStatut = new System.Windows.Forms.ComboBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnTerminer = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFiltre = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReservations)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridReservations
            // 
            this.dataGridReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReservations.Location = new System.Drawing.Point(48, 66);
            this.dataGridReservations.Name = "dataGridReservations";
            this.dataGridReservations.RowHeadersWidth = 62;
            this.dataGridReservations.RowTemplate.Height = 28;
            this.dataGridReservations.Size = new System.Drawing.Size(980, 607);
            this.dataGridReservations.TabIndex = 0;
            this.dataGridReservations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridReservations_CellClick);
            this.dataGridReservations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridReservations_CellContentClick);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(130, 709);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(49, 20);
            this.lblClient.TabIndex = 10;
            this.lblClient.Text = "Client";
            // 
            // cmbClient
            // 
            this.cmbClient.Location = new System.Drawing.Point(231, 706);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(200, 28);
            this.cmbClient.TabIndex = 1;
            // 
            // lblChambre
            // 
            this.lblChambre.AutoSize = true;
            this.lblChambre.Location = new System.Drawing.Point(130, 749);
            this.lblChambre.Name = "lblChambre";
            this.lblChambre.Size = new System.Drawing.Size(74, 20);
            this.lblChambre.TabIndex = 9;
            this.lblChambre.Text = "Chambre";
            // 
            // cmbChambre
            // 
            this.cmbChambre.Location = new System.Drawing.Point(231, 746);
            this.cmbChambre.Name = "cmbChambre";
            this.cmbChambre.Size = new System.Drawing.Size(200, 28);
            this.cmbChambre.TabIndex = 2;
            // 
            // lblChambreStatut
            // 
            this.lblChambreStatut.AutoSize = true;
            this.lblChambreStatut.Location = new System.Drawing.Point(450, 789);
            this.lblChambreStatut.Name = "lblChambreStatut";
            this.lblChambreStatut.Size = new System.Drawing.Size(146, 20);
            this.lblChambreStatut.TabIndex = 0;
            this.lblChambreStatut.Text = "Statut chambre : ---";
            // 
            // lblArrivee
            // 
            this.lblArrivee.AutoSize = true;
            this.lblArrivee.Location = new System.Drawing.Point(450, 749);
            this.lblArrivee.Name = "lblArrivee";
            this.lblArrivee.Size = new System.Drawing.Size(95, 20);
            this.lblArrivee.TabIndex = 8;
            this.lblArrivee.Text = "Date arrivée";
            // 
            // dtpArrivee
            // 
            this.dtpArrivee.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpArrivee.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpArrivee.Location = new System.Drawing.Point(551, 744);
            this.dtpArrivee.Name = "dtpArrivee";
            this.dtpArrivee.ShowUpDown = true;
            this.dtpArrivee.Size = new System.Drawing.Size(200, 26);
            this.dtpArrivee.TabIndex = 8;
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Location = new System.Drawing.Point(450, 709);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(94, 20);
            this.lblDepart.TabIndex = 7;
            this.lblDepart.Text = "Date départ";
            // 
            // dtpDepart
            // 
            this.dtpDepart.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpDepart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDepart.Location = new System.Drawing.Point(550, 706);
            this.dtpDepart.Name = "dtpDepart";
            this.dtpDepart.ShowUpDown = true;
            this.dtpDepart.Size = new System.Drawing.Size(200, 26);
            this.dtpDepart.TabIndex = 7;
            // 
            // lblStatut
            // 
            this.lblStatut.AutoSize = true;
            this.lblStatut.Location = new System.Drawing.Point(130, 789);
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(53, 20);
            this.lblStatut.TabIndex = 6;
            this.lblStatut.Text = "Statut";
            // 
            // cmbStatut
            // 
            this.cmbStatut.Location = new System.Drawing.Point(230, 786);
            this.cmbStatut.Name = "cmbStatut";
            this.cmbStatut.Size = new System.Drawing.Size(200, 28);
            this.cmbStatut.TabIndex = 5;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(800, 709);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(120, 35);
            this.btnAjouter.TabIndex = 3;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(800, 749);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(120, 35);
            this.btnModifier.TabIndex = 2;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnTerminer
            // 
            this.btnTerminer.Location = new System.Drawing.Point(800, 789);
            this.btnTerminer.Name = "btnTerminer";
            this.btnTerminer.Size = new System.Drawing.Size(120, 35);
            this.btnTerminer.TabIndex = 1;
            this.btnTerminer.Text = "Terminer";
            this.btnTerminer.UseVisualStyleBackColor = true;
            this.btnTerminer.Click += new System.EventHandler(this.btnTerminer_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(800, 829);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 35);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Réinitialiser";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(769, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Filtrer :";
            // 
            // cmbFiltre
            // 
            this.cmbFiltre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltre.Location = new System.Drawing.Point(832, 30);
            this.cmbFiltre.Name = "cmbFiltre";
            this.cmbFiltre.Size = new System.Drawing.Size(200, 28);
            this.cmbFiltre.TabIndex = 15;
            this.cmbFiltre.SelectedIndexChanged += new System.EventHandler(this.cmbFiltre_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Réservations :";
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(2085, 1195);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFiltre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblChambreStatut);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnTerminer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.cmbStatut);
            this.Controls.Add(this.lblStatut);
            this.Controls.Add(this.dtpDepart);
            this.Controls.Add(this.lblDepart);
            this.Controls.Add(this.dtpArrivee);
            this.Controls.Add(this.lblArrivee);
            this.Controls.Add(this.cmbChambre);
            this.Controls.Add(this.lblChambre);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.dataGridReservations);
            this.Name = "ReservationForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReservations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridReservations;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblChambre;
        private System.Windows.Forms.Label lblArrivee;
        private System.Windows.Forms.Label lblDepart;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.ComboBox cmbChambre;
        private System.Windows.Forms.Label lblChambreStatut;

        private System.Windows.Forms.DateTimePicker dtpArrivee;
        private System.Windows.Forms.DateTimePicker dtpDepart;
        private System.Windows.Forms.Label lblStatut;
        private System.Windows.Forms.ComboBox cmbStatut;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnTerminer;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFiltre;
        private Label label2;
    }
}