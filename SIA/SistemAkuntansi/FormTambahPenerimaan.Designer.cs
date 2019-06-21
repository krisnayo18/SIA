namespace SistemAkuntansi
{
    partial class FormTambahPenerimaan
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerTerima = new System.Windows.Forms.DateTimePicker();
            this.textBoxKeterangan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxNoNotaBeli = new System.Windows.Forms.ComboBox();
            this.textBoxIdPengiriman = new System.Windows.Forms.TextBox();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBiaya = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxNama = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxJenisPengiriman = new System.Windows.Forms.ComboBox();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.labelKodePgw = new System.Windows.Forms.Label();
            this.labelNamaPgw = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 32);
            this.label1.TabIndex = 35;
            this.label1.Text = "TAMBAH PENERIMAAN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePickerTerima
            // 
            this.dateTimePickerTerima.CustomFormat = "dddd dd MMM yyyy";
            this.dateTimePickerTerima.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTerima.Location = new System.Drawing.Point(205, 243);
            this.dateTimePickerTerima.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerTerima.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerTerima.Name = "dateTimePickerTerima";
            this.dateTimePickerTerima.Size = new System.Drawing.Size(165, 20);
            this.dateTimePickerTerima.TabIndex = 8;
            this.dateTimePickerTerima.Value = new System.DateTime(2019, 5, 1, 15, 57, 7, 0);
            // 
            // textBoxKeterangan
            // 
            this.textBoxKeterangan.Location = new System.Drawing.Point(205, 194);
            this.textBoxKeterangan.Multiline = true;
            this.textBoxKeterangan.Name = "textBoxKeterangan";
            this.textBoxKeterangan.Size = new System.Drawing.Size(165, 43);
            this.textBoxKeterangan.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "No Nota Pembelian:";
            // 
            // comboBoxNoNotaBeli
            // 
            this.comboBoxNoNotaBeli.FormattingEnabled = true;
            this.comboBoxNoNotaBeli.Location = new System.Drawing.Point(205, 115);
            this.comboBoxNoNotaBeli.Name = "comboBoxNoNotaBeli";
            this.comboBoxNoNotaBeli.Size = new System.Drawing.Size(165, 21);
            this.comboBoxNoNotaBeli.TabIndex = 3;
            // 
            // textBoxIdPengiriman
            // 
            this.textBoxIdPengiriman.Location = new System.Drawing.Point(205, 62);
            this.textBoxIdPengiriman.Name = "textBoxIdPengiriman";
            this.textBoxIdPengiriman.Size = new System.Drawing.Size(74, 20);
            this.textBoxIdPengiriman.TabIndex = 1;
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
            this.buttonKeluar.Location = new System.Drawing.Point(364, 360);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(96, 33);
            this.buttonKeluar.TabIndex = 34;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Kode Pengiriman:";
            // 
            // textBoxBiaya
            // 
            this.textBoxBiaya.Location = new System.Drawing.Point(205, 142);
            this.textBoxBiaya.Name = "textBoxBiaya";
            this.textBoxBiaya.Size = new System.Drawing.Size(58, 20);
            this.textBoxBiaya.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(121, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Biaya Kirim:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(88, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Jenis Pengiriman:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(91, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Tanggal Terima :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(118, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Keterangan:";
            // 
            // textBoxNama
            // 
            this.textBoxNama.Location = new System.Drawing.Point(205, 168);
            this.textBoxNama.Name = "textBoxNama";
            this.textBoxNama.Size = new System.Drawing.Size(165, 20);
            this.textBoxNama.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(151, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Nama:";
            // 
            // comboBoxJenisPengiriman
            // 
            this.comboBoxJenisPengiriman.FormattingEnabled = true;
            this.comboBoxJenisPengiriman.Location = new System.Drawing.Point(205, 88);
            this.comboBoxJenisPengiriman.Name = "comboBoxJenisPengiriman";
            this.comboBoxJenisPengiriman.Size = new System.Drawing.Size(165, 21);
            this.comboBoxJenisPengiriman.TabIndex = 2;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dateTimePickerTerima);
            this.panel1.Controls.Add(this.labelKodePgw);
            this.panel1.Controls.Add(this.textBoxKeterangan);
            this.panel1.Controls.Add(this.labelNamaPgw);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxNoNotaBeli);
            this.panel1.Controls.Add(this.textBoxIdPengiriman);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxBiaya);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBoxNama);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.comboBoxJenisPengiriman);
            this.panel1.Location = new System.Drawing.Point(12, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 307);
            this.panel1.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(128, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 13);
            this.label7.TabIndex = 86;
            this.label7.Text = "-";
            // 
            // labelKodePgw
            // 
            this.labelKodePgw.AutoSize = true;
            this.labelKodePgw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKodePgw.Location = new System.Drawing.Point(72, 9);
            this.labelKodePgw.Name = "labelKodePgw";
            this.labelKodePgw.Size = new System.Drawing.Size(36, 13);
            this.labelKodePgw.TabIndex = 85;
            this.labelKodePgw.Text = "Kode";
            // 
            // labelNamaPgw
            // 
            this.labelNamaPgw.AutoSize = true;
            this.labelNamaPgw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNamaPgw.Location = new System.Drawing.Point(160, 9);
            this.labelNamaPgw.Name = "labelNamaPgw";
            this.labelNamaPgw.Size = new System.Drawing.Size(39, 13);
            this.labelNamaPgw.TabIndex = 84;
            this.labelNamaPgw.Text = "Nama";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 83;
            this.label10.Text = "Pegawai:";
            // 
            // FormTambahPenerimaan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(472, 410);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormTambahPenerimaan";
            this.Load += new System.EventHandler(this.FormTambahPenerimaan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerTerima;
        private System.Windows.Forms.TextBox textBoxKeterangan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxNoNotaBeli;
        private System.Windows.Forms.TextBox textBoxIdPengiriman;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxBiaya;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxNama;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxJenisPengiriman;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelKodePgw;
        private System.Windows.Forms.Label labelNamaPgw;
        private System.Windows.Forms.Label label10;
    }
}