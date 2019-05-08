namespace SistemAkuntansi
{
    partial class FormDaftarEkspedisi
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
            this.buttonCari = new System.Windows.Forms.Button();
            this.textBoxBarang = new System.Windows.Forms.TextBox();
            this.comboBoxBarang = new System.Windows.Forms.ComboBox();
            this.buttonTambah = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.dataGridViewBarang = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarang)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCari
            // 
            this.buttonCari.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonCari.FlatAppearance.BorderSize = 0;
            this.buttonCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCari.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCari.ForeColor = System.Drawing.Color.White;
            this.buttonCari.Location = new System.Drawing.Point(550, 43);
            this.buttonCari.Name = "buttonCari";
            this.buttonCari.Size = new System.Drawing.Size(46, 25);
            this.buttonCari.TabIndex = 31;
            this.buttonCari.Text = "CARI";
            this.buttonCari.UseVisualStyleBackColor = false;
            // 
            // textBoxBarang
            // 
            this.textBoxBarang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBarang.Location = new System.Drawing.Point(309, 43);
            this.textBoxBarang.MaximumSize = new System.Drawing.Size(500, 500);
            this.textBoxBarang.Multiline = true;
            this.textBoxBarang.Name = "textBoxBarang";
            this.textBoxBarang.Size = new System.Drawing.Size(232, 24);
            this.textBoxBarang.TabIndex = 30;
            // 
            // comboBoxBarang
            // 
            this.comboBoxBarang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxBarang.FormattingEnabled = true;
            this.comboBoxBarang.Items.AddRange(new object[] {
            "Kode Barang",
            "Barcode",
            "Nama",
            "Harga Jual",
            "Stok",
            "Kode Kategori",
            "Nama Kategori"});
            this.comboBoxBarang.Location = new System.Drawing.Point(110, 45);
            this.comboBoxBarang.Name = "comboBoxBarang";
            this.comboBoxBarang.Size = new System.Drawing.Size(192, 21);
            this.comboBoxBarang.TabIndex = 29;
            // 
            // buttonTambah
            // 
            this.buttonTambah.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonTambah.FlatAppearance.BorderSize = 0;
            this.buttonTambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTambah.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTambah.ForeColor = System.Drawing.Color.White;
            this.buttonTambah.Location = new System.Drawing.Point(11, 351);
            this.buttonTambah.Name = "buttonTambah";
            this.buttonTambah.Size = new System.Drawing.Size(96, 33);
            this.buttonTambah.TabIndex = 27;
            this.buttonTambah.Text = "TAMBAH";
            this.buttonTambah.UseVisualStyleBackColor = false;
            this.buttonTambah.Click += new System.EventHandler(this.buttonTambah_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-1, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(607, 35);
            this.label2.TabIndex = 22;
            this.label2.Text = "Cari Berdasarkan:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonKeluar.FlatAppearance.BorderSize = 0;
            this.buttonKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(510, 351);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(96, 33);
            this.buttonKeluar.TabIndex = 25;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            // 
            // dataGridViewBarang
            // 
            this.dataGridViewBarang.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBarang.Location = new System.Drawing.Point(-1, 78);
            this.dataGridViewBarang.Name = "dataGridViewBarang";
            this.dataGridViewBarang.Size = new System.Drawing.Size(607, 267);
            this.dataGridViewBarang.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(607, 32);
            this.label1.TabIndex = 23;
            this.label1.Text = "DAFTAR EKSPEDISI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormDaftarEkspedisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(605, 386);
            this.Controls.Add(this.buttonCari);
            this.Controls.Add(this.textBoxBarang);
            this.Controls.Add(this.comboBoxBarang);
            this.Controls.Add(this.buttonTambah);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.dataGridViewBarang);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDaftarEkspedisi";
            this.Text = "FormEkspedisi";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCari;
        private System.Windows.Forms.TextBox textBoxBarang;
        private System.Windows.Forms.ComboBox comboBoxBarang;
        private System.Windows.Forms.Button buttonTambah;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.DataGridView dataGridViewBarang;
        private System.Windows.Forms.Label label1;
    }
}