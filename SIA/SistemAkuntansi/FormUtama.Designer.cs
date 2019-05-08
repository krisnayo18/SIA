namespace SistemAkuntansi
{
    partial class FormUtama
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.keluarSistemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keluarSistemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelKodePgw = new System.Windows.Forms.Label();
            this.labelNamaPgw = new System.Windows.Forms.Label();
            this.labelJabatan = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelProfil = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMaster = new System.Windows.Forms.Panel();
            this.buttonAkun = new System.Windows.Forms.Button();
            this.buttonKaryawan = new System.Windows.Forms.Button();
            this.buttonSupplier = new System.Windows.Forms.Button();
            this.buttonPelanggan = new System.Windows.Forms.Button();
            this.buttonEkspedisi = new System.Windows.Forms.Button();
            this.buttonBarang = new System.Windows.Forms.Button();
            this.labelMaster = new System.Windows.Forms.Label();
            this.panelTransaksi = new System.Windows.Forms.Panel();
            this.labelTransaksi = new System.Windows.Forms.Label();
            this.buttonPenjualan = new System.Windows.Forms.Button();
            this.buttonPembelian = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelProfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMaster.SuspendLayout();
            this.panelTransaksi.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keluarSistemToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(854, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // keluarSistemToolStripMenuItem
            // 
            this.keluarSistemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.keluarSistemToolStripMenuItem1});
            this.keluarSistemToolStripMenuItem.Name = "keluarSistemToolStripMenuItem";
            this.keluarSistemToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.keluarSistemToolStripMenuItem.Text = "Pengaturan";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // keluarSistemToolStripMenuItem1
            // 
            this.keluarSistemToolStripMenuItem1.Name = "keluarSistemToolStripMenuItem1";
            this.keluarSistemToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.keluarSistemToolStripMenuItem1.Text = "Keluar Sistem";
            this.keluarSistemToolStripMenuItem1.Click += new System.EventHandler(this.keluarSistemToolStripMenuItem1_Click);
            // 
            // labelKodePgw
            // 
            this.labelKodePgw.BackColor = System.Drawing.Color.Transparent;
            this.labelKodePgw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKodePgw.Location = new System.Drawing.Point(80, 174);
            this.labelKodePgw.Name = "labelKodePgw";
            this.labelKodePgw.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelKodePgw.Size = new System.Drawing.Size(75, 20);
            this.labelKodePgw.TabIndex = 2;
            this.labelKodePgw.Text = "   Kode";
            this.labelKodePgw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNamaPgw
            // 
            this.labelNamaPgw.BackColor = System.Drawing.Color.Transparent;
            this.labelNamaPgw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelNamaPgw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNamaPgw.Location = new System.Drawing.Point(76, 194);
            this.labelNamaPgw.Name = "labelNamaPgw";
            this.labelNamaPgw.Size = new System.Drawing.Size(94, 20);
            this.labelNamaPgw.TabIndex = 4;
            this.labelNamaPgw.Text = " GUEST";
            this.labelNamaPgw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelJabatan
            // 
            this.labelJabatan.BackColor = System.Drawing.Color.Transparent;
            this.labelJabatan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJabatan.Location = new System.Drawing.Point(72, 214);
            this.labelJabatan.Name = "labelJabatan";
            this.labelJabatan.Size = new System.Drawing.Size(98, 24);
            this.labelJabatan.TabIndex = 5;
            this.labelJabatan.Text = " Jabatan";
            this.labelJabatan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Gray;
            this.panelMenu.Controls.Add(this.panelProfil);
            this.panelMenu.Controls.Add(this.panelMaster);
            this.panelMenu.Controls.Add(this.panelTransaksi);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 24);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(250, 748);
            this.panelMenu.TabIndex = 6;
            // 
            // panelProfil
            // 
            this.panelProfil.BackColor = System.Drawing.Color.Gray;
            this.panelProfil.Controls.Add(this.labelKodePgw);
            this.panelProfil.Controls.Add(this.pictureBox1);
            this.panelProfil.Controls.Add(this.labelJabatan);
            this.panelProfil.Controls.Add(this.labelNamaPgw);
            this.panelProfil.Location = new System.Drawing.Point(0, 1);
            this.panelProfil.Name = "panelProfil";
            this.panelProfil.Size = new System.Drawing.Size(249, 245);
            this.panelProfil.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SIA.Properties.Resources.profil;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(41, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 163);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelMaster
            // 
            this.panelMaster.BackColor = System.Drawing.Color.Transparent;
            this.panelMaster.Controls.Add(this.buttonAkun);
            this.panelMaster.Controls.Add(this.buttonKaryawan);
            this.panelMaster.Controls.Add(this.buttonSupplier);
            this.panelMaster.Controls.Add(this.buttonPelanggan);
            this.panelMaster.Controls.Add(this.buttonEkspedisi);
            this.panelMaster.Controls.Add(this.buttonBarang);
            this.panelMaster.Controls.Add(this.labelMaster);
            this.panelMaster.Location = new System.Drawing.Point(1, 269);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Size = new System.Drawing.Size(250, 210);
            this.panelMaster.TabIndex = 7;
            // 
            // buttonAkun
            // 
            this.buttonAkun.FlatAppearance.BorderSize = 0;
            this.buttonAkun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAkun.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAkun.ForeColor = System.Drawing.Color.White;
            this.buttonAkun.Location = new System.Drawing.Point(59, 173);
            this.buttonAkun.Name = "buttonAkun";
            this.buttonAkun.Size = new System.Drawing.Size(95, 30);
            this.buttonAkun.TabIndex = 0;
            this.buttonAkun.Text = "Akun";
            this.buttonAkun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAkun.UseVisualStyleBackColor = true;
            // 
            // buttonKaryawan
            // 
            this.buttonKaryawan.FlatAppearance.BorderSize = 0;
            this.buttonKaryawan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKaryawan.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKaryawan.ForeColor = System.Drawing.Color.White;
            this.buttonKaryawan.Location = new System.Drawing.Point(59, 143);
            this.buttonKaryawan.Name = "buttonKaryawan";
            this.buttonKaryawan.Size = new System.Drawing.Size(95, 30);
            this.buttonKaryawan.TabIndex = 0;
            this.buttonKaryawan.Text = "Karyawan";
            this.buttonKaryawan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonKaryawan.UseVisualStyleBackColor = true;
            this.buttonKaryawan.Click += new System.EventHandler(this.buttonPegawai_Click);
            // 
            // buttonSupplier
            // 
            this.buttonSupplier.FlatAppearance.BorderSize = 0;
            this.buttonSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSupplier.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSupplier.ForeColor = System.Drawing.Color.White;
            this.buttonSupplier.Location = new System.Drawing.Point(59, 113);
            this.buttonSupplier.Name = "buttonSupplier";
            this.buttonSupplier.Size = new System.Drawing.Size(95, 30);
            this.buttonSupplier.TabIndex = 0;
            this.buttonSupplier.Text = "Supplier";
            this.buttonSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSupplier.UseVisualStyleBackColor = true;
            this.buttonSupplier.Click += new System.EventHandler(this.buttonSupplier_Click);
            // 
            // buttonPelanggan
            // 
            this.buttonPelanggan.FlatAppearance.BorderSize = 0;
            this.buttonPelanggan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPelanggan.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPelanggan.ForeColor = System.Drawing.Color.White;
            this.buttonPelanggan.Location = new System.Drawing.Point(59, 83);
            this.buttonPelanggan.Name = "buttonPelanggan";
            this.buttonPelanggan.Size = new System.Drawing.Size(110, 30);
            this.buttonPelanggan.TabIndex = 0;
            this.buttonPelanggan.Text = "Pelanggan";
            this.buttonPelanggan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPelanggan.UseVisualStyleBackColor = true;
            this.buttonPelanggan.Click += new System.EventHandler(this.buttonPelanggan_Click);
            // 
            // buttonEkspedisi
            // 
            this.buttonEkspedisi.FlatAppearance.BorderSize = 0;
            this.buttonEkspedisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEkspedisi.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEkspedisi.ForeColor = System.Drawing.Color.White;
            this.buttonEkspedisi.Location = new System.Drawing.Point(59, 53);
            this.buttonEkspedisi.Name = "buttonEkspedisi";
            this.buttonEkspedisi.Size = new System.Drawing.Size(95, 30);
            this.buttonEkspedisi.TabIndex = 0;
            this.buttonEkspedisi.Text = "Ekspedisi";
            this.buttonEkspedisi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEkspedisi.UseVisualStyleBackColor = true;
            this.buttonEkspedisi.Click += new System.EventHandler(this.buttonEkspedisi_Click);
            // 
            // buttonBarang
            // 
            this.buttonBarang.FlatAppearance.BorderSize = 0;
            this.buttonBarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBarang.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBarang.ForeColor = System.Drawing.Color.White;
            this.buttonBarang.Location = new System.Drawing.Point(59, 23);
            this.buttonBarang.Name = "buttonBarang";
            this.buttonBarang.Size = new System.Drawing.Size(95, 30);
            this.buttonBarang.TabIndex = 0;
            this.buttonBarang.Text = "Barang";
            this.buttonBarang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBarang.UseVisualStyleBackColor = true;
            this.buttonBarang.Click += new System.EventHandler(this.buttonBarang_Click);
            // 
            // labelMaster
            // 
            this.labelMaster.BackColor = System.Drawing.Color.Transparent;
            this.labelMaster.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaster.ForeColor = System.Drawing.Color.White;
            this.labelMaster.Location = new System.Drawing.Point(3, 3);
            this.labelMaster.Name = "labelMaster";
            this.labelMaster.Size = new System.Drawing.Size(243, 25);
            this.labelMaster.TabIndex = 2;
            this.labelMaster.Text = "Master";
            this.labelMaster.Click += new System.EventHandler(this.labelMaster_Click);
            // 
            // panelTransaksi
            // 
            this.panelTransaksi.BackColor = System.Drawing.Color.Transparent;
            this.panelTransaksi.Controls.Add(this.labelTransaksi);
            this.panelTransaksi.Controls.Add(this.buttonPenjualan);
            this.panelTransaksi.Controls.Add(this.buttonPembelian);
            this.panelTransaksi.Location = new System.Drawing.Point(1, 479);
            this.panelTransaksi.Name = "panelTransaksi";
            this.panelTransaksi.Size = new System.Drawing.Size(250, 120);
            this.panelTransaksi.TabIndex = 9;
            // 
            // labelTransaksi
            // 
            this.labelTransaksi.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTransaksi.ForeColor = System.Drawing.Color.White;
            this.labelTransaksi.Location = new System.Drawing.Point(3, 3);
            this.labelTransaksi.Name = "labelTransaksi";
            this.labelTransaksi.Size = new System.Drawing.Size(243, 25);
            this.labelTransaksi.TabIndex = 2;
            this.labelTransaksi.Text = "Transaksi";
            this.labelTransaksi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTransaksi.Click += new System.EventHandler(this.labelTransaksi_Click);
            // 
            // buttonPenjualan
            // 
            this.buttonPenjualan.FlatAppearance.BorderSize = 0;
            this.buttonPenjualan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPenjualan.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPenjualan.ForeColor = System.Drawing.Color.White;
            this.buttonPenjualan.Location = new System.Drawing.Point(59, 38);
            this.buttonPenjualan.Name = "buttonPenjualan";
            this.buttonPenjualan.Size = new System.Drawing.Size(95, 30);
            this.buttonPenjualan.TabIndex = 0;
            this.buttonPenjualan.Text = "Penjualan";
            this.buttonPenjualan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPenjualan.UseVisualStyleBackColor = true;
            this.buttonPenjualan.Click += new System.EventHandler(this.buttonPenjualan_Click);
            // 
            // buttonPembelian
            // 
            this.buttonPembelian.FlatAppearance.BorderSize = 0;
            this.buttonPembelian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPembelian.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPembelian.ForeColor = System.Drawing.Color.White;
            this.buttonPembelian.Location = new System.Drawing.Point(59, 78);
            this.buttonPembelian.Name = "buttonPembelian";
            this.buttonPembelian.Size = new System.Drawing.Size(95, 30);
            this.buttonPembelian.TabIndex = 0;
            this.buttonPembelian.Text = "Pembelian";
            this.buttonPembelian.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPembelian.UseVisualStyleBackColor = true;
            this.buttonPembelian.Click += new System.EventHandler(this.buttonPembelian_Click);
            // 
            // FormUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(854, 772);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormUtama";
            this.Text = "Indomart";
            this.Load += new System.EventHandler(this.FormUtama_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelProfil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMaster.ResumeLayout(false);
            this.panelTransaksi.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem keluarSistemToolStripMenuItem;
        public System.Windows.Forms.Label labelKodePgw;
        public System.Windows.Forms.Label labelNamaPgw;
        public System.Windows.Forms.Label labelJabatan;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label labelTransaksi;
        private System.Windows.Forms.Label labelMaster;
        private System.Windows.Forms.Button buttonPembelian;
        private System.Windows.Forms.Button buttonPenjualan;
        private System.Windows.Forms.Button buttonBarang;
        private System.Windows.Forms.Panel panelMaster;
        private System.Windows.Forms.Button buttonAkun;
        private System.Windows.Forms.Button buttonKaryawan;
        private System.Windows.Forms.Button buttonSupplier;
        private System.Windows.Forms.Button buttonPelanggan;
        private System.Windows.Forms.Button buttonEkspedisi;
        private System.Windows.Forms.Panel panelTransaksi;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keluarSistemToolStripMenuItem1;
        private System.Windows.Forms.Panel panelProfil;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}