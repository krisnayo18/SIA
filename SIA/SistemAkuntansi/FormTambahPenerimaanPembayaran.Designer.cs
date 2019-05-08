namespace SistemAkuntansi
{
    partial class FormTambahPenerimaanPembayaran
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
            this.dateTimePickerTgl = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxNoNotaJual = new System.Windows.Forms.ComboBox();
            this.textBoxIdPenerimaan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNominal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCaraPemb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePickerTgl
            // 
            this.dateTimePickerTgl.CustomFormat = "dddd dd MMM yyyy";
            this.dateTimePickerTgl.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTgl.Location = new System.Drawing.Point(208, 126);
            this.dateTimePickerTgl.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerTgl.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerTgl.Name = "dateTimePickerTgl";
            this.dateTimePickerTgl.Size = new System.Drawing.Size(165, 20);
            this.dateTimePickerTgl.TabIndex = 3;
            this.dateTimePickerTgl.Value = new System.DateTime(2019, 5, 1, 15, 57, 7, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "No Nota Penjualan : ";
            // 
            // comboBoxNoNotaJual
            // 
            this.comboBoxNoNotaJual.FormattingEnabled = true;
            this.comboBoxNoNotaJual.Location = new System.Drawing.Point(208, 99);
            this.comboBoxNoNotaJual.Name = "comboBoxNoNotaJual";
            this.comboBoxNoNotaJual.Size = new System.Drawing.Size(165, 21);
            this.comboBoxNoNotaJual.TabIndex = 2;
            // 
            // textBoxIdPenerimaan
            // 
            this.textBoxIdPenerimaan.Location = new System.Drawing.Point(208, 73);
            this.textBoxIdPenerimaan.Name = "textBoxIdPenerimaan";
            this.textBoxIdPenerimaan.Size = new System.Drawing.Size(45, 20);
            this.textBoxIdPenerimaan.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(102, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "ID Penerimaan :";
            // 
            // textBoxNominal
            // 
            this.textBoxNominal.Location = new System.Drawing.Point(208, 179);
            this.textBoxNominal.Name = "textBoxNominal";
            this.textBoxNominal.Size = new System.Drawing.Size(165, 20);
            this.textBoxNominal.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(138, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Nominal :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(138, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Tanggal :";
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
            this.buttonSimpan.TabIndex = 6;
            this.buttonSimpan.Text = "SIMPAN";
            this.buttonSimpan.UseVisualStyleBackColor = false;
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
            this.buttonKosongi.TabIndex = 7;
            this.buttonKosongi.Text = "KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
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
            this.buttonKeluar.TabIndex = 8;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.dateTimePickerTgl);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxNoNotaJual);
            this.panel1.Controls.Add(this.textBoxIdPenerimaan);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxNominal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBoxCaraPemb);
            this.panel1.Location = new System.Drawing.Point(12, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 307);
            this.panel1.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 32);
            this.label1.TabIndex = 30;
            this.label1.Text = "TAMBAH PENERIMAAN PEMBAYARAN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxCaraPemb
            // 
            this.comboBoxCaraPemb.FormattingEnabled = true;
            this.comboBoxCaraPemb.Location = new System.Drawing.Point(208, 152);
            this.comboBoxCaraPemb.Name = "comboBoxCaraPemb";
            this.comboBoxCaraPemb.Size = new System.Drawing.Size(165, 21);
            this.comboBoxCaraPemb.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(86, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Cara Pembayaran : ";
            // 
            // FormTambahPenerimaanPembayaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(467, 407);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTambahPenerimaanPembayaran";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerTgl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxNoNotaJual;
        private System.Windows.Forms.TextBox textBoxIdPenerimaan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNominal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxCaraPemb;
        private System.Windows.Forms.Label label1;
    }
}