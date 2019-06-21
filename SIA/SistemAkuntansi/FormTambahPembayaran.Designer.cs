namespace SistemAkuntansi
{
    partial class FormTambahPembayaran
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
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.labelKodePgw = new System.Windows.Forms.Label();
            this.labelNamaPgw = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerTgl = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxNoNotaBeli = new System.Windows.Forms.ComboBox();
            this.textBoxNoPembayaran = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNominal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxCaraPemb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonSimpan.FlatAppearance.BorderSize = 0;
            this.buttonSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimpan.ForeColor = System.Drawing.Color.White;
            this.buttonSimpan.Location = new System.Drawing.Point(12, 360);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(96, 33);
            this.buttonSimpan.TabIndex = 32;
            this.buttonSimpan.Text = "SIMPAN";
            this.buttonSimpan.UseVisualStyleBackColor = false;
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // buttonKosongi
            // 
            this.buttonKosongi.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonKosongi.FlatAppearance.BorderSize = 0;
            this.buttonKosongi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKosongi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKosongi.ForeColor = System.Drawing.Color.White;
            this.buttonKosongi.Location = new System.Drawing.Point(115, 360);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(96, 33);
            this.buttonKosongi.TabIndex = 33;
            this.buttonKosongi.Text = "KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            this.buttonKosongi.Click += new System.EventHandler(this.buttonKosongi_Click);
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonKeluar.FlatAppearance.BorderSize = 0;
            this.buttonKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(358, 360);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(96, 33);
            this.buttonKeluar.TabIndex = 34;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.labelKodePgw);
            this.panel1.Controls.Add(this.labelNamaPgw);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.dateTimePickerTgl);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxNoNotaBeli);
            this.panel1.Controls.Add(this.textBoxNoPembayaran);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxNominal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBoxCaraPemb);
            this.panel1.Location = new System.Drawing.Point(12, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 307);
            this.panel1.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(129, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 13);
            this.label7.TabIndex = 82;
            this.label7.Text = "-";
            // 
            // labelKodePgw
            // 
            this.labelKodePgw.AutoSize = true;
            this.labelKodePgw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKodePgw.Location = new System.Drawing.Point(73, 12);
            this.labelKodePgw.Name = "labelKodePgw";
            this.labelKodePgw.Size = new System.Drawing.Size(36, 13);
            this.labelKodePgw.TabIndex = 81;
            this.labelKodePgw.Text = "Kode";
            // 
            // labelNamaPgw
            // 
            this.labelNamaPgw.AutoSize = true;
            this.labelNamaPgw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNamaPgw.Location = new System.Drawing.Point(161, 12);
            this.labelNamaPgw.Name = "labelNamaPgw";
            this.labelNamaPgw.Size = new System.Drawing.Size(39, 13);
            this.labelNamaPgw.TabIndex = 80;
            this.labelNamaPgw.Text = "Nama";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 79;
            this.label8.Text = "Pegawai:";
            // 
            // dateTimePickerTgl
            // 
            this.dateTimePickerTgl.CustomFormat = "dddd dd MMM yyyy";
            this.dateTimePickerTgl.Enabled = false;
            this.dateTimePickerTgl.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTgl.Location = new System.Drawing.Point(210, 133);
            this.dateTimePickerTgl.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerTgl.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerTgl.Name = "dateTimePickerTgl";
            this.dateTimePickerTgl.Size = new System.Drawing.Size(165, 20);
            this.dateTimePickerTgl.TabIndex = 71;
            this.dateTimePickerTgl.Value = new System.DateTime(2019, 6, 11, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 78;
            this.label3.Text = "No Nota Pembelian : ";
            // 
            // comboBoxNoNotaBeli
            // 
            this.comboBoxNoNotaBeli.FormattingEnabled = true;
            this.comboBoxNoNotaBeli.Location = new System.Drawing.Point(210, 106);
            this.comboBoxNoNotaBeli.Name = "comboBoxNoNotaBeli";
            this.comboBoxNoNotaBeli.Size = new System.Drawing.Size(165, 21);
            this.comboBoxNoNotaBeli.TabIndex = 70;
            this.comboBoxNoNotaBeli.SelectedIndexChanged += new System.EventHandler(this.comboBoxNoNotaBeli_SelectedIndexChanged);
            // 
            // textBoxNoPembayaran
            // 
            this.textBoxNoPembayaran.Enabled = false;
            this.textBoxNoPembayaran.Location = new System.Drawing.Point(210, 80);
            this.textBoxNoPembayaran.Name = "textBoxNoPembayaran";
            this.textBoxNoPembayaran.Size = new System.Drawing.Size(136, 20);
            this.textBoxNoPembayaran.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 77;
            this.label2.Text = "No Pembayaran :";
            // 
            // textBoxNominal
            // 
            this.textBoxNominal.Enabled = false;
            this.textBoxNominal.Location = new System.Drawing.Point(210, 186);
            this.textBoxNominal.Name = "textBoxNominal";
            this.textBoxNominal.Size = new System.Drawing.Size(165, 20);
            this.textBoxNominal.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(140, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 75;
            this.label4.Text = "Nominal :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(88, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 74;
            this.label5.Text = "Cara Pembayaran : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(140, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 76;
            this.label6.Text = "Tanggal :";
            // 
            // comboBoxCaraPemb
            // 
            this.comboBoxCaraPemb.FormattingEnabled = true;
            this.comboBoxCaraPemb.Items.AddRange(new object[] {
            "T",
            "K"});
            this.comboBoxCaraPemb.Location = new System.Drawing.Point(210, 159);
            this.comboBoxCaraPemb.Name = "comboBoxCaraPemb";
            this.comboBoxCaraPemb.Size = new System.Drawing.Size(165, 21);
            this.comboBoxCaraPemb.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 32);
            this.label1.TabIndex = 35;
            this.label1.Text = "TAMBAH PEMBAYARAN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormTambahPembayaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(465, 407);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormTambahPembayaran";
            this.Load += new System.EventHandler(this.FormTambahPembayaran_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelKodePgw;
        private System.Windows.Forms.Label labelNamaPgw;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerTgl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxNoNotaBeli;
        private System.Windows.Forms.TextBox textBoxNoPembayaran;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNominal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxCaraPemb;
    }
}