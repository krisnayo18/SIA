﻿namespace SistemAkuntansi
{
    partial class FormDaftarNotaBeli
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
            this.buttonTambah = new System.Windows.Forms.Button();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.dataGridViewNota = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCari = new System.Windows.Forms.Button();
            this.textBoxCari = new System.Windows.Forms.TextBox();
            this.comboBoxCari = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttoncetak = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNota)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTambah
            // 
            this.buttonTambah.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonTambah.FlatAppearance.BorderSize = 0;
            this.buttonTambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTambah.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTambah.ForeColor = System.Drawing.Color.White;
            this.buttonTambah.Location = new System.Drawing.Point(24, 360);
            this.buttonTambah.Name = "buttonTambah";
            this.buttonTambah.Size = new System.Drawing.Size(96, 33);
            this.buttonTambah.TabIndex = 16;
            this.buttonTambah.Text = "TAMBAH";
            this.buttonTambah.UseVisualStyleBackColor = false;
            this.buttonTambah.Click += new System.EventHandler(this.buttonTambah_Click);
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonKeluar.FlatAppearance.BorderSize = 0;
            this.buttonKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(523, 360);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(96, 33);
            this.buttonKeluar.TabIndex = 14;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // dataGridViewNota
            // 
            this.dataGridViewNota.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewNota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNota.Location = new System.Drawing.Point(12, 87);
            this.dataGridViewNota.Name = "dataGridViewNota";
            this.dataGridViewNota.Size = new System.Drawing.Size(607, 267);
            this.dataGridViewNota.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.buttonCari);
            this.panel1.Controls.Add(this.textBoxCari);
            this.panel1.Controls.Add(this.comboBoxCari);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(11, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 37);
            this.panel1.TabIndex = 12;
            // 
            // buttonCari
            // 
            this.buttonCari.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonCari.FlatAppearance.BorderSize = 0;
            this.buttonCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCari.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCari.ForeColor = System.Drawing.Color.White;
            this.buttonCari.Location = new System.Drawing.Point(543, 7);
            this.buttonCari.Name = "buttonCari";
            this.buttonCari.Size = new System.Drawing.Size(57, 24);
            this.buttonCari.TabIndex = 21;
            this.buttonCari.Text = "CARI";
            this.buttonCari.UseVisualStyleBackColor = false;
            this.buttonCari.Click += new System.EventHandler(this.buttonCari_Click);
            // 
            // textBoxCari
            // 
            this.textBoxCari.Location = new System.Drawing.Point(316, 9);
            this.textBoxCari.Name = "textBoxCari";
            this.textBoxCari.Size = new System.Drawing.Size(221, 20);
            this.textBoxCari.TabIndex = 20;
            this.textBoxCari.TextChanged += new System.EventHandler(this.textBoxNotaBeli_TextChanged);
            // 
            // comboBoxCari
            // 
            this.comboBoxCari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCari.FormattingEnabled = true;
            this.comboBoxCari.Location = new System.Drawing.Point(115, 8);
            this.comboBoxCari.Name = "comboBoxCari";
            this.comboBoxCari.Size = new System.Drawing.Size(192, 21);
            this.comboBoxCari.TabIndex = 19;
            this.comboBoxCari.TextChanged += new System.EventHandler(this.comboBoxCari_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cari Berdasarkan:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(607, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "DAFTAR NOTA BELI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttoncetak
            // 
            this.buttoncetak.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttoncetak.FlatAppearance.BorderSize = 0;
            this.buttoncetak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttoncetak.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttoncetak.ForeColor = System.Drawing.Color.White;
            this.buttoncetak.Location = new System.Drawing.Point(259, 360);
            this.buttoncetak.Name = "buttoncetak";
            this.buttoncetak.Size = new System.Drawing.Size(96, 33);
            this.buttoncetak.TabIndex = 17;
            this.buttoncetak.Text = "CETAK";
            this.buttoncetak.UseVisualStyleBackColor = false;
            this.buttoncetak.Click += new System.EventHandler(this.buttoncetak_Click);
            // 
            // FormDaftarNotaBeli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(629, 400);
            this.Controls.Add(this.buttoncetak);
            this.Controls.Add(this.buttonTambah);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.dataGridViewNota);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDaftarNotaBeli";
            this.Text = "Daftar Nota Beli";
            this.Load += new System.EventHandler(this.FormDaftarNotaBeli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNota)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTambah;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.DataGridView dataGridViewNota;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCari;
        private System.Windows.Forms.TextBox textBoxCari;
        private System.Windows.Forms.ComboBox comboBoxCari;
        private System.Windows.Forms.Button buttoncetak;
    }
}