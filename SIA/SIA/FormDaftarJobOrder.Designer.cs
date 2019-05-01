namespace SIA
{
    partial class FormDaftarJobOrder
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
            this.buttonTambah = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.dataGridViewBarang = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBarang = new System.Windows.Forms.ComboBox();
            this.buttonHapus = new System.Windows.Forms.Button();
            this.buttonUbah = new System.Windows.Forms.Button();
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
            this.buttonCari.Location = new System.Drawing.Point(828, 68);
            this.buttonCari.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCari.Name = "buttonCari";
            this.buttonCari.Size = new System.Drawing.Size(69, 38);
            this.buttonCari.TabIndex = 30;
            this.buttonCari.Text = "CARI";
            this.buttonCari.UseVisualStyleBackColor = false;
            // 
            // textBoxBarang
            // 
            this.textBoxBarang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBarang.Location = new System.Drawing.Point(465, 68);
            this.textBoxBarang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxBarang.MaximumSize = new System.Drawing.Size(750, 769);
            this.textBoxBarang.Multiline = true;
            this.textBoxBarang.Name = "textBoxBarang";
            this.textBoxBarang.Size = new System.Drawing.Size(348, 37);
            this.textBoxBarang.TabIndex = 29;
            // 
            // buttonTambah
            // 
            this.buttonTambah.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonTambah.FlatAppearance.BorderSize = 0;
            this.buttonTambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTambah.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTambah.ForeColor = System.Drawing.Color.White;
            this.buttonTambah.Location = new System.Drawing.Point(20, 542);
            this.buttonTambah.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonTambah.Name = "buttonTambah";
            this.buttonTambah.Size = new System.Drawing.Size(144, 51);
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
            this.label2.Location = new System.Drawing.Point(2, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(910, 54);
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
            this.buttonKeluar.Location = new System.Drawing.Point(768, 542);
            this.buttonKeluar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(144, 51);
            this.buttonKeluar.TabIndex = 25;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            // 
            // dataGridViewBarang
            // 
            this.dataGridViewBarang.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBarang.Location = new System.Drawing.Point(2, 122);
            this.dataGridViewBarang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewBarang.Name = "dataGridViewBarang";
            this.dataGridViewBarang.Size = new System.Drawing.Size(910, 411);
            this.dataGridViewBarang.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(910, 49);
            this.label1.TabIndex = 23;
            this.label1.Text = "DAFTAR JOB ORDER";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.comboBoxBarang.Location = new System.Drawing.Point(166, 72);
            this.comboBoxBarang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxBarang.Name = "comboBoxBarang";
            this.comboBoxBarang.Size = new System.Drawing.Size(286, 28);
            this.comboBoxBarang.TabIndex = 31;
            // 
            // buttonHapus
            // 
            this.buttonHapus.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonHapus.FlatAppearance.BorderSize = 0;
            this.buttonHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHapus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHapus.ForeColor = System.Drawing.Color.White;
            this.buttonHapus.Location = new System.Drawing.Point(312, 542);
            this.buttonHapus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonHapus.Name = "buttonHapus";
            this.buttonHapus.Size = new System.Drawing.Size(144, 51);
            this.buttonHapus.TabIndex = 26;
            this.buttonHapus.Text = "HAPUS";
            this.buttonHapus.UseVisualStyleBackColor = false;
            // 
            // buttonUbah
            // 
            this.buttonUbah.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonUbah.FlatAppearance.BorderSize = 0;
            this.buttonUbah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUbah.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUbah.ForeColor = System.Drawing.Color.White;
            this.buttonUbah.Location = new System.Drawing.Point(166, 542);
            this.buttonUbah.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonUbah.Name = "buttonUbah";
            this.buttonUbah.Size = new System.Drawing.Size(144, 51);
            this.buttonUbah.TabIndex = 28;
            this.buttonUbah.Text = "UBAH";
            this.buttonUbah.UseVisualStyleBackColor = false;
            // 
            // FormDaftarJobOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(915, 603);
            this.Controls.Add(this.comboBoxBarang);
            this.Controls.Add(this.buttonCari);
            this.Controls.Add(this.buttonUbah);
            this.Controls.Add(this.textBoxBarang);
            this.Controls.Add(this.buttonTambah);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonHapus);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.dataGridViewBarang);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormDaftarJobOrder";
            this.Text = "FormJobOrder";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCari;
        private System.Windows.Forms.TextBox textBoxBarang;
        private System.Windows.Forms.Button buttonTambah;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.DataGridView dataGridViewBarang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBarang;
        private System.Windows.Forms.Button buttonHapus;
        private System.Windows.Forms.Button buttonUbah;
    }
}