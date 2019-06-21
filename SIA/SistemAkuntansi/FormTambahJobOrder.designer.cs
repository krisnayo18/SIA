namespace SistemAkuntansi
{
    partial class FormTambahJobOrder
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
            this.comboBoxSatuan = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.labelTelepon = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.labelNama = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxGaji = new System.Windows.Forms.TextBox();
            this.labelTotalGaji = new System.Windows.Forms.Label();
            this.dataGridViewJobOrder = new System.Windows.Forms.DataGridView();
            this.textBoxIdKaryawan = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.labelKodePgw = new System.Windows.Forms.Label();
            this.labelNamaPgw = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxSatuan = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePickerSelesai = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerMulai = new System.Windows.Forms.DateTimePicker();
            this.textBoxOverhead = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxDirectMaterial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxNoNotaJual = new System.Windows.Forms.ComboBox();
            this.textBoxKodeJobOrder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDirectLabor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxItem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJobOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonSimpan.FlatAppearance.BorderSize = 0;
            this.buttonSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimpan.ForeColor = System.Drawing.Color.White;
            this.buttonSimpan.Location = new System.Drawing.Point(12, 462);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(96, 33);
            this.buttonSimpan.TabIndex = 10;
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
            this.buttonKosongi.Location = new System.Drawing.Point(223, 462);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(96, 33);
            this.buttonKosongi.TabIndex = 11;
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
            this.buttonKeluar.Location = new System.Drawing.Point(455, 462);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(96, 33);
            this.buttonKeluar.TabIndex = 12;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.comboBoxSatuan);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.labelTelepon);
            this.panel1.Controls.Add(this.labelGender);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.labelNama);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.textBoxGaji);
            this.panel1.Controls.Add(this.labelTotalGaji);
            this.panel1.Controls.Add(this.dataGridViewJobOrder);
            this.panel1.Controls.Add(this.textBoxIdKaryawan);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.labelKodePgw);
            this.panel1.Controls.Add(this.labelNamaPgw);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.textBoxSatuan);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.dateTimePickerSelesai);
            this.panel1.Controls.Add(this.dateTimePickerMulai);
            this.panel1.Controls.Add(this.textBoxOverhead);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textBoxDirectMaterial);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxNoNotaJual);
            this.panel1.Controls.Add(this.textBoxKodeJobOrder);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxQuantity);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBoxDirectLabor);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.comboBoxItem);
            this.panel1.Location = new System.Drawing.Point(12, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 409);
            this.panel1.TabIndex = 26;
            // 
            // comboBoxSatuan
            // 
            this.comboBoxSatuan.FormattingEnabled = true;
            this.comboBoxSatuan.Location = new System.Drawing.Point(378, 251);
            this.comboBoxSatuan.Name = "comboBoxSatuan";
            this.comboBoxSatuan.Size = new System.Drawing.Size(59, 21);
            this.comboBoxSatuan.TabIndex = 97;
            this.comboBoxSatuan.SelectedIndexChanged += new System.EventHandler(this.comboBoxSatuan_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(270, 237);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 13);
            this.label21.TabIndex = 96;
            this.label21.Text = "Telepon";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(208, 237);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 13);
            this.label19.TabIndex = 95;
            this.label19.Text = "Gender";
            // 
            // labelTelepon
            // 
            this.labelTelepon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTelepon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTelepon.Location = new System.Drawing.Point(273, 252);
            this.labelTelepon.Name = "labelTelepon";
            this.labelTelepon.Size = new System.Drawing.Size(99, 20);
            this.labelTelepon.TabIndex = 94;
            // 
            // labelGender
            // 
            this.labelGender.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGender.Location = new System.Drawing.Point(208, 252);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(59, 20);
            this.labelGender.TabIndex = 93;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(375, 237);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 13);
            this.label20.TabIndex = 91;
            this.label20.Text = "Satuan";
            // 
            // labelNama
            // 
            this.labelNama.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNama.Location = new System.Drawing.Point(95, 252);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(107, 20);
            this.labelNama.TabIndex = 89;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(443, 237);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 13);
            this.label14.TabIndex = 87;
            this.label14.Text = "Gaji Per Satuan";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(95, 237);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 13);
            this.label16.TabIndex = 85;
            this.label16.Text = "Nama";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(10, 237);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 13);
            this.label18.TabIndex = 83;
            this.label18.Text = "ID Karyawan";
            // 
            // textBoxGaji
            // 
            this.textBoxGaji.Location = new System.Drawing.Point(443, 253);
            this.textBoxGaji.Name = "textBoxGaji";
            this.textBoxGaji.Size = new System.Drawing.Size(96, 20);
            this.textBoxGaji.TabIndex = 82;
            this.textBoxGaji.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxGaji_KeyDown);
            // 
            // labelTotalGaji
            // 
            this.labelTotalGaji.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalGaji.Location = new System.Drawing.Point(328, 189);
            this.labelTotalGaji.Name = "labelTotalGaji";
            this.labelTotalGaji.Size = new System.Drawing.Size(211, 39);
            this.labelTotalGaji.TabIndex = 81;
            this.labelTotalGaji.Text = "0";
            this.labelTotalGaji.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridViewJobOrder
            // 
            this.dataGridViewJobOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJobOrder.Location = new System.Drawing.Point(5, 276);
            this.dataGridViewJobOrder.Name = "dataGridViewJobOrder";
            this.dataGridViewJobOrder.Size = new System.Drawing.Size(534, 130);
            this.dataGridViewJobOrder.TabIndex = 80;
            // 
            // textBoxIdKaryawan
            // 
            this.textBoxIdKaryawan.Location = new System.Drawing.Point(8, 253);
            this.textBoxIdKaryawan.Name = "textBoxIdKaryawan";
            this.textBoxIdKaryawan.Size = new System.Drawing.Size(81, 20);
            this.textBoxIdKaryawan.TabIndex = 79;
            this.textBoxIdKaryawan.TextChanged += new System.EventHandler(this.textBoxIdKaryawan_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(131, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 13);
            this.label12.TabIndex = 68;
            this.label12.Text = "-";
            // 
            // labelKodePgw
            // 
            this.labelKodePgw.AutoSize = true;
            this.labelKodePgw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKodePgw.Location = new System.Drawing.Point(75, 200);
            this.labelKodePgw.Name = "labelKodePgw";
            this.labelKodePgw.Size = new System.Drawing.Size(36, 13);
            this.labelKodePgw.TabIndex = 67;
            this.labelKodePgw.Text = "Kode";
            // 
            // labelNamaPgw
            // 
            this.labelNamaPgw.AutoSize = true;
            this.labelNamaPgw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNamaPgw.Location = new System.Drawing.Point(163, 200);
            this.labelNamaPgw.Name = "labelNamaPgw";
            this.labelNamaPgw.Size = new System.Drawing.Size(39, 13);
            this.labelNamaPgw.TabIndex = 66;
            this.labelNamaPgw.Text = "Nama";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 65;
            this.label13.Text = "Pegawai:";
            // 
            // textBoxSatuan
            // 
            this.textBoxSatuan.Location = new System.Drawing.Point(120, 130);
            this.textBoxSatuan.Name = "textBoxSatuan";
            this.textBoxSatuan.Size = new System.Drawing.Size(58, 20);
            this.textBoxSatuan.TabIndex = 52;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(56, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 53;
            this.label11.Text = "Satuan :";
            // 
            // dateTimePickerSelesai
            // 
            this.dateTimePickerSelesai.CustomFormat = "dddd dd MMM yyyy";
            this.dateTimePickerSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSelesai.Location = new System.Drawing.Point(374, 130);
            this.dateTimePickerSelesai.Name = "dateTimePickerSelesai";
            this.dateTimePickerSelesai.Size = new System.Drawing.Size(165, 20);
            this.dateTimePickerSelesai.TabIndex = 9;
            this.dateTimePickerSelesai.Value = new System.DateTime(2019, 6, 13, 0, 0, 0, 0);
            // 
            // dateTimePickerMulai
            // 
            this.dateTimePickerMulai.CustomFormat = "dddd dd MMM yyyy";
            this.dateTimePickerMulai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMulai.Location = new System.Drawing.Point(374, 104);
            this.dateTimePickerMulai.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerMulai.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerMulai.Name = "dateTimePickerMulai";
            this.dateTimePickerMulai.Size = new System.Drawing.Size(165, 20);
            this.dateTimePickerMulai.TabIndex = 8;
            this.dateTimePickerMulai.Value = new System.DateTime(2019, 6, 13, 0, 0, 0, 0);
            // 
            // textBoxOverhead
            // 
            this.textBoxOverhead.Enabled = false;
            this.textBoxOverhead.Location = new System.Drawing.Point(375, 78);
            this.textBoxOverhead.Name = "textBoxOverhead";
            this.textBoxOverhead.Size = new System.Drawing.Size(105, 20);
            this.textBoxOverhead.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(240, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "Overhead Produksi  :";
            // 
            // textBoxDirectMaterial
            // 
            this.textBoxDirectMaterial.Enabled = false;
            this.textBoxDirectMaterial.Location = new System.Drawing.Point(374, 26);
            this.textBoxDirectMaterial.Name = "textBoxDirectMaterial";
            this.textBoxDirectMaterial.Size = new System.Drawing.Size(106, 20);
            this.textBoxDirectMaterial.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Nota Penjualan : ";
            // 
            // comboBoxNoNotaJual
            // 
            this.comboBoxNoNotaJual.FormattingEnabled = true;
            this.comboBoxNoNotaJual.Location = new System.Drawing.Point(119, 50);
            this.comboBoxNoNotaJual.Name = "comboBoxNoNotaJual";
            this.comboBoxNoNotaJual.Size = new System.Drawing.Size(110, 21);
            this.comboBoxNoNotaJual.TabIndex = 3;
            // 
            // textBoxKodeJobOrder
            // 
            this.textBoxKodeJobOrder.Location = new System.Drawing.Point(119, 24);
            this.textBoxKodeJobOrder.Name = "textBoxKodeJobOrder";
            this.textBoxKodeJobOrder.Size = new System.Drawing.Size(59, 20);
            this.textBoxKodeJobOrder.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Kode Job Order :";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(120, 104);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(58, 20);
            this.textBoxQuantity.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Quantity :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(260, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Tanggal Selesai :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(73, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Item : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(271, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Tanggal Mulai :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(268, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Direct Material :";
            // 
            // textBoxDirectLabor
            // 
            this.textBoxDirectLabor.Enabled = false;
            this.textBoxDirectLabor.Location = new System.Drawing.Point(375, 52);
            this.textBoxDirectLabor.Name = "textBoxDirectLabor";
            this.textBoxDirectLabor.Size = new System.Drawing.Size(105, 20);
            this.textBoxDirectLabor.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(282, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Direct Labor :";
            // 
            // comboBoxItem
            // 
            this.comboBoxItem.FormattingEnabled = true;
            this.comboBoxItem.Location = new System.Drawing.Point(119, 77);
            this.comboBoxItem.Name = "comboBoxItem";
            this.comboBoxItem.Size = new System.Drawing.Size(110, 21);
            this.comboBoxItem.TabIndex = 2;
            this.comboBoxItem.SelectedIndexChanged += new System.EventHandler(this.comboBoxItem_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(549, 32);
            this.label1.TabIndex = 25;
            this.label1.Text = "TAMBAH JOB ORDER";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormTambahJobOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(567, 507);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormTambahJobOrder";
            this.Load += new System.EventHandler(this.FormTambahBarang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJobOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDirectLabor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerSelesai;
        private System.Windows.Forms.DateTimePicker dateTimePickerMulai;
        private System.Windows.Forms.TextBox textBoxOverhead;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxDirectMaterial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxNoNotaJual;
        private System.Windows.Forms.TextBox textBoxKodeJobOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSatuan;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelKodePgw;
        private System.Windows.Forms.Label labelNamaPgw;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label labelNama;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxGaji;
        private System.Windows.Forms.Label labelTotalGaji;
        private System.Windows.Forms.DataGridView dataGridViewJobOrder;
        private System.Windows.Forms.TextBox textBoxIdKaryawan;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label labelTelepon;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.ComboBox comboBoxSatuan;
    }
}