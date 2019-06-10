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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonNeraca = new System.Windows.Forms.Button();
            this.buttonPerubahanEkuitas = new System.Windows.Forms.Button();
            this.buttonLabaRugi = new System.Windows.Forms.Button();
            this.buttonBukuBesar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMaster = new System.Windows.Forms.Panel();
            this.buttonAkun = new System.Windows.Forms.Button();
            this.buttonKaryawan = new System.Windows.Forms.Button();
            this.buttonSupplier = new System.Windows.Forms.Button();
            this.buttonPelanggan = new System.Windows.Forms.Button();
            this.buttonEkspedisi = new System.Windows.Forms.Button();
            this.buttonBarang = new System.Windows.Forms.Button();
            this.labelMaster = new System.Windows.Forms.Label();
            this.panelTransaksi = new System.Windows.Forms.Panel();
            this.buttonTutupPeriode = new System.Windows.Forms.Button();
            this.buttonJurnal = new System.Windows.Forms.Button();
            this.buttonPelunasan = new System.Windows.Forms.Button();
            this.labelTransaksi = new System.Windows.Forms.Label();
            this.buttonPenjualan = new System.Windows.Forms.Button();
            this.buttonPembelian = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonPembayaran = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // keluarSistemToolStripMenuItem1
            // 
            this.keluarSistemToolStripMenuItem1.Name = "keluarSistemToolStripMenuItem1";
            this.keluarSistemToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.keluarSistemToolStripMenuItem1.Text = "Keluar Sistem";
            this.keluarSistemToolStripMenuItem1.Click += new System.EventHandler(this.keluarSistemToolStripMenuItem1_Click);
            // 
            // labelKodePgw
            // 
            this.labelKodePgw.BackColor = System.Drawing.Color.LightSteelBlue;
            this.labelKodePgw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKodePgw.Location = new System.Drawing.Point(134, 4);
            this.labelKodePgw.Name = "labelKodePgw";
            this.labelKodePgw.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelKodePgw.Size = new System.Drawing.Size(51, 17);
            this.labelKodePgw.TabIndex = 2;
            this.labelKodePgw.Text = "KODE";
            this.labelKodePgw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNamaPgw
            // 
            this.labelNamaPgw.BackColor = System.Drawing.Color.LightSteelBlue;
            this.labelNamaPgw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelNamaPgw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelNamaPgw.Location = new System.Drawing.Point(4, 4);
            this.labelNamaPgw.Name = "labelNamaPgw";
            this.labelNamaPgw.Size = new System.Drawing.Size(101, 17);
            this.labelNamaPgw.TabIndex = 4;
            this.labelNamaPgw.Text = " GUEST";
            this.labelNamaPgw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelJabatan
            // 
            this.labelJabatan.BackColor = System.Drawing.Color.LightSteelBlue;
            this.labelJabatan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelJabatan.Location = new System.Drawing.Point(214, 2);
            this.labelJabatan.Name = "labelJabatan";
            this.labelJabatan.Size = new System.Drawing.Size(58, 19);
            this.labelJabatan.TabIndex = 5;
            this.labelJabatan.Text = "JABATAN";
            this.labelJabatan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Gray;
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Controls.Add(this.panelMaster);
            this.panelMenu.Controls.Add(this.panelTransaksi);
            this.panelMenu.Controls.Add(this.labelMaster);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 24);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(250, 748);
            this.panelMenu.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.buttonNeraca);
            this.panel1.Controls.Add(this.buttonTutupPeriode);
            this.panel1.Controls.Add(this.buttonPerubahanEkuitas);
            this.panel1.Controls.Add(this.buttonJurnal);
            this.panel1.Controls.Add(this.buttonLabaRugi);
            this.panel1.Controls.Add(this.buttonBukuBesar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 408);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 293);
            this.panel1.TabIndex = 10;
            // 
            // buttonNeraca
            // 
            this.buttonNeraca.FlatAppearance.BorderSize = 0;
            this.buttonNeraca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNeraca.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNeraca.ForeColor = System.Drawing.Color.White;
            this.buttonNeraca.Location = new System.Drawing.Point(60, 222);
            this.buttonNeraca.Name = "buttonNeraca";
            this.buttonNeraca.Size = new System.Drawing.Size(123, 30);
            this.buttonNeraca.TabIndex = 8;
            this.buttonNeraca.Text = "Neraca";
            this.buttonNeraca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNeraca.UseVisualStyleBackColor = true;
            this.buttonNeraca.Click += new System.EventHandler(this.buttonNeraca_Click);
            // 
            // buttonPerubahanEkuitas
            // 
            this.buttonPerubahanEkuitas.FlatAppearance.BorderSize = 0;
            this.buttonPerubahanEkuitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPerubahanEkuitas.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPerubahanEkuitas.ForeColor = System.Drawing.Color.White;
            this.buttonPerubahanEkuitas.Location = new System.Drawing.Point(60, 186);
            this.buttonPerubahanEkuitas.Name = "buttonPerubahanEkuitas";
            this.buttonPerubahanEkuitas.Size = new System.Drawing.Size(169, 30);
            this.buttonPerubahanEkuitas.TabIndex = 7;
            this.buttonPerubahanEkuitas.Text = "Perubahan Ekuitas";
            this.buttonPerubahanEkuitas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPerubahanEkuitas.UseVisualStyleBackColor = true;
            this.buttonPerubahanEkuitas.Click += new System.EventHandler(this.buttonPerubahanEkuitas_Click);
            // 
            // buttonLabaRugi
            // 
            this.buttonLabaRugi.FlatAppearance.BorderSize = 0;
            this.buttonLabaRugi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLabaRugi.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLabaRugi.ForeColor = System.Drawing.Color.White;
            this.buttonLabaRugi.Location = new System.Drawing.Point(60, 150);
            this.buttonLabaRugi.Name = "buttonLabaRugi";
            this.buttonLabaRugi.Size = new System.Drawing.Size(123, 30);
            this.buttonLabaRugi.TabIndex = 6;
            this.buttonLabaRugi.Text = "Laba Rugi";
            this.buttonLabaRugi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLabaRugi.UseVisualStyleBackColor = true;
            this.buttonLabaRugi.Click += new System.EventHandler(this.buttonLabaRugi_Click);
            // 
            // buttonBukuBesar
            // 
            this.buttonBukuBesar.FlatAppearance.BorderSize = 0;
            this.buttonBukuBesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBukuBesar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBukuBesar.ForeColor = System.Drawing.Color.White;
            this.buttonBukuBesar.Location = new System.Drawing.Point(60, 114);
            this.buttonBukuBesar.Name = "buttonBukuBesar";
            this.buttonBukuBesar.Size = new System.Drawing.Size(123, 30);
            this.buttonBukuBesar.TabIndex = 5;
            this.buttonBukuBesar.Text = "Buku Besar";
            this.buttonBukuBesar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBukuBesar.UseVisualStyleBackColor = true;
            this.buttonBukuBesar.Click += new System.EventHandler(this.buttonBukuBesar_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Laporan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.panelMaster.Location = new System.Drawing.Point(1, 29);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Size = new System.Drawing.Size(250, 33);
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
            this.labelMaster.Location = new System.Drawing.Point(3, 10);
            this.labelMaster.Name = "labelMaster";
            this.labelMaster.Size = new System.Drawing.Size(243, 29);
            this.labelMaster.TabIndex = 2;
            this.labelMaster.Text = "Master";
            this.labelMaster.Click += new System.EventHandler(this.labelMaster_Click);
            // 
            // panelTransaksi
            // 
            this.panelTransaksi.BackColor = System.Drawing.Color.Transparent;
            this.panelTransaksi.Controls.Add(this.buttonPembayaran);
            this.panelTransaksi.Controls.Add(this.buttonPelunasan);
            this.panelTransaksi.Controls.Add(this.labelTransaksi);
            this.panelTransaksi.Controls.Add(this.buttonPenjualan);
            this.panelTransaksi.Controls.Add(this.buttonPembelian);
            this.panelTransaksi.Location = new System.Drawing.Point(1, 68);
            this.panelTransaksi.Name = "panelTransaksi";
            this.panelTransaksi.Size = new System.Drawing.Size(250, 334);
            this.panelTransaksi.TabIndex = 9;
            // 
            // buttonTutupPeriode
            // 
            this.buttonTutupPeriode.FlatAppearance.BorderSize = 0;
            this.buttonTutupPeriode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTutupPeriode.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTutupPeriode.ForeColor = System.Drawing.Color.White;
            this.buttonTutupPeriode.Location = new System.Drawing.Point(60, 78);
            this.buttonTutupPeriode.Name = "buttonTutupPeriode";
            this.buttonTutupPeriode.Size = new System.Drawing.Size(149, 30);
            this.buttonTutupPeriode.TabIndex = 4;
            this.buttonTutupPeriode.Text = "Tutup Periode";
            this.buttonTutupPeriode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTutupPeriode.UseVisualStyleBackColor = true;
            this.buttonTutupPeriode.Click += new System.EventHandler(this.buttonTutupPeriode_Click);
            // 
            // buttonJurnal
            // 
            this.buttonJurnal.FlatAppearance.BorderSize = 0;
            this.buttonJurnal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonJurnal.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonJurnal.ForeColor = System.Drawing.Color.White;
            this.buttonJurnal.Location = new System.Drawing.Point(60, 42);
            this.buttonJurnal.Name = "buttonJurnal";
            this.buttonJurnal.Size = new System.Drawing.Size(95, 30);
            this.buttonJurnal.TabIndex = 4;
            this.buttonJurnal.Text = "Jurnal";
            this.buttonJurnal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonJurnal.UseVisualStyleBackColor = true;
            this.buttonJurnal.Click += new System.EventHandler(this.buttonJurnal_Click);
            // 
            // buttonPelunasan
            // 
            this.buttonPelunasan.FlatAppearance.BorderSize = 0;
            this.buttonPelunasan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPelunasan.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPelunasan.ForeColor = System.Drawing.Color.White;
            this.buttonPelunasan.Location = new System.Drawing.Point(59, 74);
            this.buttonPelunasan.Name = "buttonPelunasan";
            this.buttonPelunasan.Size = new System.Drawing.Size(95, 30);
            this.buttonPelunasan.TabIndex = 3;
            this.buttonPelunasan.Text = "Pelunasan";
            this.buttonPelunasan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPelunasan.UseVisualStyleBackColor = true;
            this.buttonPelunasan.Click += new System.EventHandler(this.buttonPelunasan_Click);
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
            this.buttonPembelian.Location = new System.Drawing.Point(59, 110);
            this.buttonPembelian.Name = "buttonPembelian";
            this.buttonPembelian.Size = new System.Drawing.Size(95, 30);
            this.buttonPembelian.TabIndex = 0;
            this.buttonPembelian.Text = "Pembelian";
            this.buttonPembelian.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPembelian.UseVisualStyleBackColor = true;
            this.buttonPembelian.Click += new System.EventHandler(this.buttonPembelian_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(191, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "-";
            // 
            // buttonPembayaran
            // 
            this.buttonPembayaran.FlatAppearance.BorderSize = 0;
            this.buttonPembayaran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPembayaran.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPembayaran.ForeColor = System.Drawing.Color.White;
            this.buttonPembayaran.Location = new System.Drawing.Point(59, 146);
            this.buttonPembayaran.Name = "buttonPembayaran";
            this.buttonPembayaran.Size = new System.Drawing.Size(123, 30);
            this.buttonPembayaran.TabIndex = 5;
            this.buttonPembayaran.Text = "Pembayaran";
            this.buttonPembayaran.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPembayaran.UseVisualStyleBackColor = true;
            this.buttonPembayaran.Click += new System.EventHandler(this.buttonPembayaran_Click);
            // 
            // FormUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(854, 772);
            this.Controls.Add(this.labelJabatan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelNamaPgw);
            this.Controls.Add(this.labelKodePgw);
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
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonPelunasan;
        private System.Windows.Forms.Button buttonJurnal;
        private System.Windows.Forms.Button buttonBukuBesar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonNeraca;
        private System.Windows.Forms.Button buttonPerubahanEkuitas;
        private System.Windows.Forms.Button buttonLabaRugi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTutupPeriode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonPembayaran;
    }
}