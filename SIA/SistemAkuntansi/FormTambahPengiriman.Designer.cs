﻿namespace SIA
{
    partial class FormTambahPengiriman
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePickerMulai = new System.Windows.Forms.DateTimePicker();
            this.textBoxDirectMaterial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxNoNotaJual = new System.Windows.Forms.ComboBox();
            this.textBoxKodeJobOrder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDirectLabor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxKodeBarang = new System.Windows.Forms.ComboBox();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.buttonSimpan.Location = new System.Drawing.Point(13, 361);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(96, 33);
            this.buttonSimpan.TabIndex = 37;
            this.buttonSimpan.Text = "SIMPAN";
            this.buttonSimpan.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dateTimePickerMulai);
            this.panel1.Controls.Add(this.textBoxDirectMaterial);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxNoNotaJual);
            this.panel1.Controls.Add(this.textBoxKodeJobOrder);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxQuantity);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBoxDirectLabor);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.comboBoxKodeBarang);
            this.panel1.Location = new System.Drawing.Point(13, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 307);
            this.panel1.TabIndex = 41;
            // 
            // dateTimePickerMulai
            // 
            this.dateTimePickerMulai.CustomFormat = "dddd dd MMM yyyy";
            this.dateTimePickerMulai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMulai.Location = new System.Drawing.Point(203, 218);
            this.dateTimePickerMulai.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerMulai.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerMulai.Name = "dateTimePickerMulai";
            this.dateTimePickerMulai.Size = new System.Drawing.Size(165, 20);
            this.dateTimePickerMulai.TabIndex = 8;
            this.dateTimePickerMulai.Value = new System.DateTime(2019, 5, 1, 15, 57, 7, 0);
            // 
            // textBoxDirectMaterial
            // 
            this.textBoxDirectMaterial.Location = new System.Drawing.Point(203, 166);
            this.textBoxDirectMaterial.Name = "textBoxDirectMaterial";
            this.textBoxDirectMaterial.Size = new System.Drawing.Size(135, 20);
            this.textBoxDirectMaterial.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "No Nota Pembelian:";
            // 
            // comboBoxNoNotaJual
            // 
            this.comboBoxNoNotaJual.FormattingEnabled = true;
            this.comboBoxNoNotaJual.Location = new System.Drawing.Point(203, 87);
            this.comboBoxNoNotaJual.Name = "comboBoxNoNotaJual";
            this.comboBoxNoNotaJual.Size = new System.Drawing.Size(165, 21);
            this.comboBoxNoNotaJual.TabIndex = 3;
            // 
            // textBoxKodeJobOrder
            // 
            this.textBoxKodeJobOrder.Location = new System.Drawing.Point(203, 34);
            this.textBoxKodeJobOrder.Name = "textBoxKodeJobOrder";
            this.textBoxKodeJobOrder.Size = new System.Drawing.Size(74, 20);
            this.textBoxKodeJobOrder.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Nomor Pengiriman:";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(203, 114);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(58, 20);
            this.textBoxQuantity.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(119, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Biaya Kirim:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(86, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Jenis Pengiriman:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(100, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Tanggal Kirim";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(116, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Keterangan:";
            // 
            // textBoxDirectLabor
            // 
            this.textBoxDirectLabor.Location = new System.Drawing.Point(203, 140);
            this.textBoxDirectLabor.Name = "textBoxDirectLabor";
            this.textBoxDirectLabor.Size = new System.Drawing.Size(135, 20);
            this.textBoxDirectLabor.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(149, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Nama:";
            // 
            // comboBoxKodeBarang
            // 
            this.comboBoxKodeBarang.FormattingEnabled = true;
            this.comboBoxKodeBarang.Location = new System.Drawing.Point(203, 60);
            this.comboBoxKodeBarang.Name = "comboBoxKodeBarang";
            this.comboBoxKodeBarang.Size = new System.Drawing.Size(165, 21);
            this.comboBoxKodeBarang.TabIndex = 2;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonKeluar.FlatAppearance.BorderSize = 0;
            this.buttonKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(359, 361);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(96, 33);
            this.buttonKeluar.TabIndex = 39;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 32);
            this.label1.TabIndex = 40;
            this.label1.Text = "TAMBAH PENGIRIMAN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonKosongi
            // 
            this.buttonKosongi.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonKosongi.FlatAppearance.BorderSize = 0;
            this.buttonKosongi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKosongi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKosongi.ForeColor = System.Drawing.Color.White;
            this.buttonKosongi.Location = new System.Drawing.Point(116, 361);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(96, 33);
            this.buttonKosongi.TabIndex = 38;
            this.buttonKosongi.Text = "KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(87, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Nomor Ekspedisi:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(203, 190);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 20);
            this.textBox1.TabIndex = 51;
            // 
            // FormTambahPengiriman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(468, 404);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonKosongi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTambahPengiriman";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerMulai;
        private System.Windows.Forms.TextBox textBoxDirectMaterial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxNoNotaJual;
        private System.Windows.Forms.TextBox textBoxKodeJobOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDirectLabor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxKodeBarang;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKosongi;
    }
}