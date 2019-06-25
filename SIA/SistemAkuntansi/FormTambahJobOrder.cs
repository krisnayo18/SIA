using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryJurnal;
using ClassLibraryTransaksi;


namespace SistemAkuntansi
{
    public partial class FormTambahJobOrder : Form
    {
        public FormTambahJobOrder()
        {
            InitializeComponent();
        }
        int totalGaji = 0;
        List<NotaPenjualan> listHasilNotaPenjualan = new List<NotaPenjualan>();
        List<Barang> listHasilBarang = new List<Barang>();
        List<Karyawan> listHasilKaryawan = new List<Karyawan>();
        Periode pPeriode = new Periode();

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormatDataGrid()
        {
            dataGridViewJobOrder.Columns.Clear();

            dataGridViewJobOrder.Columns.Add("idKaryawan", "ID Karyawan");
            dataGridViewJobOrder.Columns.Add("nama", "Nama Karyawan");
            dataGridViewJobOrder.Columns.Add("gender", "Gender");
            dataGridViewJobOrder.Columns.Add("noTelp", "No Telepon");
            dataGridViewJobOrder.Columns.Add("satuan", "Satuan");
            dataGridViewJobOrder.Columns.Add("gaji", "Gaji Per Satuan");

            dataGridViewJobOrder.Columns["idKaryawan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJobOrder.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJobOrder.Columns["gender"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJobOrder.Columns["noTelp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJobOrder.Columns["satuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJobOrder.Columns["gaji"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewJobOrder.Columns["gaji"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewJobOrder.AllowUserToAddRows = false;
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            FormUtama frmUtama = (FormUtama)this.Owner.MdiParent;
            FormDaftarJobOrder form = (FormDaftarJobOrder)this.Owner;

            //buat object bertipe notapenjualan
            NotaPenjualan nota = new NotaPenjualan();
            nota.NoNotaPenjualan = comboBoxNoNotaJual.Text;

            //buat objek bertipe barang
            Barang br = new Barang();
            br.KodeBarang = comboBoxItem.Text.Substring(0, 5);
            // ammil dari combo box item, karena nama berada di index ke 8, dengan panjang karakter sesuai text dikurangi 8 
            br.Nama = comboBoxItem.Text.Substring(8, comboBoxItem.Text.Length - 8);

            //buat object bertipe job order
            string kode = textBoxKodeJobOrder.Text;
            int quant =int.Parse(textBoxQuantity.Text);
            int material = 0;
            int labor = HitungGrandTotal();
            int overhead = 0;
            DateTime pMulai = dateTimePickerMulai.Value;
            DateTime  pSelesai = dateTimePickerSelesai.Value;
            string pStatus = "P";
            JobOrder job = new JobOrder(kode, quant, labor, material, overhead, pMulai, pSelesai, pStatus, br, nota);

            //data barang diperoleh dari data gridview
            for (int i = 0; i < dataGridViewJobOrder.Rows.Count; i++)
            {
                //buat object bertipe karyawan
                Karyawan k = new Karyawan();
                //tambahkan informasi karyawan
                //hati hati dalam menambahkan
                k.IdKaryawan = dataGridViewJobOrder.Rows[i].Cells["idKaryawan"].Value.ToString();
                k.Nama = dataGridViewJobOrder.Rows[i].Cells["nama"].Value.ToString();
                k.Gender = dataGridViewJobOrder.Rows[i].Cells["gender"].Value.ToString();
                k.NoTelepon = dataGridViewJobOrder.Rows[i].Cells["noTelp"].Value.ToString();
                //simpan  data satuan dan gaji
                string pSat = dataGridViewJobOrder.Rows[i].Cells["satuan"].Value.ToString();
                int pGaji = int.Parse(dataGridViewJobOrder.Rows[i].Cells["gaji"].Value.ToString());
                //buat object detiljoborder dan tambahkan
                DetilJobOrder detilJob = new DetilJobOrder(k, pSat, pGaji);
                //simpan detil job 
                job.TambahDetilJobOrder(k, pSat, pGaji);
            }

            //inser ke database joborder
            string hasilTambahJob = JobOrder.TambahData(job);

            if (hasilTambahJob == "1") //jika berhasil maka insert jurnal dan detil jurnal
            {
                MessageBox.Show("Job Order telah dibuat", "Info");

                //tambah posting ke jurnal
                //karena pembuatan job order tidak perlu ditambahkan ke jurnal 
                //insert jurnal pembayaran karyawan 
                // 2 kali insert ke jurnal  1, untuk membebankan ke wip, 2, untuk pembayaran tenaga kerja
                string idtrans = "";
                string ket = "";
                string idJurnal = Jurnal.GenerateIdJurnal();

                //1.membebankan ke wip
                idtrans = "005";
                ket = "Menghitung dan membebankan biaya tenaga kerja langsung terhadap Job Order no 123";

                Transaksi trans = new Transaksi();
                //transaksi membebankan biaya tenaga ke Job Order (id transkasi 005);
                trans.IdTransaksi = idtrans;
                trans.Keterangan = ket;

                //buat object bertipe jurnal
                Jurnal jurnal = new Jurnal();
                //tambahkan data
                jurnal.IdJurnal = int.Parse(idJurnal);
                jurnal.Tanggal = dateTimePickerMulai.Value;

                jurnal.NomorBukti = comboBoxNoNotaJual.Text;
                jurnal.Jenis = "JU";
                jurnal.Periode = pPeriode;
                jurnal.Transaksi = trans;

                //isi detil jurnalnya
                totalGaji = HitungGrandTotal(); // panggil method  untuk mendapatkan total gaji
                jurnal.TambahDetilJurnalMenghitungBiayaTK(totalGaji);
                
                //simpan ke tabel _jurnal
                string hasilTambahJurnal = Jurnal.TambahData(jurnal);
                if (hasilTambahJurnal == "1")
                {
                    idJurnal = Jurnal.GenerateIdJurnal();
                    idtrans = "006";
                    ket = "Membayar biaya tenaga kerja langsung secara tunai";

                    Transaksi trans2 = new Transaksi();
                    //transaksi membayar secara tunai(id transkasi 006);
                    trans2.IdTransaksi = idtrans;
                    trans2.Keterangan = ket;

                    //buat object bertipe jurnal
                    Jurnal jurnal2 = new Jurnal();
                    //tambahkan data
                    jurnal2.IdJurnal = int.Parse(idJurnal);
                    jurnal2.Tanggal = dateTimePickerMulai.Value;

                    jurnal2.NomorBukti = comboBoxNoNotaJual.Text;
                    jurnal2.Jenis = "JU";
                    jurnal2.Periode = pPeriode;
                    jurnal2.Transaksi = trans2;

                    jurnal2.TambahDetilJurnalPembayaranTK(totalGaji);

                    hasilTambahJurnal = Jurnal.TambahData(jurnal2);
                    if( hasilTambahJurnal == "1")
                    {
                        MessageBox.Show("berhasil posting ke jurnal");
                        this.Close();
                        form.FormDaftarJobOrder_Load(sender, e); //supaya formdaftar job order menampilkan daftar terbaru
                    }
                    else
                    {
                        MessageBox.Show("gagal posting ke jurnal" + hasilTambahJurnal);
                    }
                }
                else
                {
                    MessageBox.Show("gagal posting ke jurnal" + hasilTambahJurnal);
                }

            }
            else
            {
                MessageBox.Show("Data nota jual gagal tersimpan. Pesan kesalahan : " + hasilTambahJob, "Kesalahan");
            }
        }

        private void FormTambahBarang_Load(object sender, EventArgs e)
        {
            comboBoxSatuan.Items.AddRange(new string[] { "Unit", "Jam" });
            this.Location = new Point(500, 26);
            FormatDataGrid();
            pPeriode = Periode.GetPeriodeTerbaru();
            textBoxIdKaryawan.MaxLength = 1;
            textBoxKodeJobOrder.Enabled = false;

            comboBoxItem.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxNoNotaJual.DropDownStyle = ComboBoxStyle.DropDownList;

            string KodeJobBaru;
            string hasilGenerate = JobOrder.GenerateKodeJobOrder(out KodeJobBaru);
            textBoxKodeJobOrder.Clear();
            if (hasilGenerate == "1")
            {
                textBoxKodeJobOrder.Text = KodeJobBaru;
                comboBoxNoNotaJual.Focus();
            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            }
            dateTimePickerSelesai.Value = DateTime.Now;
            dateTimePickerMulai.Value = DateTime.Now;
            dateTimePickerMulai.Enabled = false;
            textBoxSatuan.Enabled = false;

            string hasilBaca = Barang.BacaData("jenis", "BJ", listHasilBarang); // untuk mendapatkan nama barang, kode  dan menampilkan di comboboxitems
            if (hasilBaca == "1")
            {
                comboBoxItem.Items.Clear();
                for (int i = 0; i < listHasilBarang.Count; i++)
                {
                    comboBoxItem.Items.Add(listHasilBarang[i].KodeBarang + " - " + listHasilBarang[i].Nama);
                }
            }
            else
            {
                comboBoxItem.Items.Clear();
            }

            string hasilBaca2 = NotaPenjualan.BacaData("", "", listHasilNotaPenjualan); // tampilkan ke combobox nonotapenjualan
            if (hasilBaca2 == "1")
            {
                comboBoxNoNotaJual.Items.Clear();
                for (int i = 0; i < listHasilNotaPenjualan.Count; i++)
                {
                    comboBoxNoNotaJual.Items.Add(listHasilNotaPenjualan[i].NoNotaPenjualan);
                }
            }
            else
            {
                comboBoxNoNotaJual.Items.Clear();
            }

            if (comboBoxNoNotaJual.Items.Count != 0)
                comboBoxNoNotaJual.SelectedIndex = 0;
            comboBoxItem.SelectedIndex = 0;
            FormUtama form = (FormUtama)this.Owner.MdiParent;
            labelKodePgw.Text = form.labelKodePgw.Text;
            labelNamaPgw.Text = form.labelNamaPgw.Text;
        }
        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            //textBoxQuantity.Clear();
            //textBoxDirectLabor.Clear();
            //textBoxHargaJual.Clear();
            //textBoxStok.Clear();
            //textBoxNama.Clear();
        }
        private void textBoxIdKaryawan_TextChanged(object sender, EventArgs e)
        {
            //jika user mengisi panjang karakter sesuai id karyawan
            if (textBoxIdKaryawan.Text.Length == textBoxIdKaryawan.MaxLength)
            {
                //cari nama karyawan sesuai kode yang diinputkan oleh user
                string hasilBaca = Karyawan.BacaData("idkaryawan", textBoxIdKaryawan.Text, listHasilKaryawan);

                if (hasilBaca == "1")
                {
                    if (listHasilKaryawan.Count > 0) //jika id karyawan  ditemukan di database
                    {

                        labelNama.Text = listHasilKaryawan[0].Nama;
                        labelGender.Text = listHasilKaryawan[0].Gender;
                        labelTelepon.Text = listHasilKaryawan[0].NoTelepon;
                        comboBoxSatuan.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Karyawan tidak ditemukan.");
                        textBoxIdKaryawan.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankan. Pesan kesalahan: " + hasilBaca);
                }
            }
        }

        private void comboBoxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            listHasilBarang.Clear();
            string hasilBaca = Barang.BacaData("kodeBarang", comboBoxItem.Text.Substring(0,5), listHasilBarang); 
            // ambil dari combobox mulai dari index 0, panjang karakter 5
            if (hasilBaca == "1")
            {
                textBoxSatuan.Clear();
                if (listHasilBarang.Count > 0)
                {
                    textBoxSatuan.Text = listHasilBarang[0].Satuan;
                }
            }
            else
            {
                textBoxSatuan.Clear();
            }
        }

        private void comboBoxSatuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxGaji.Focus();
        }

        private void textBoxGaji_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int gaji = int.Parse(textBoxGaji.Text);
                dataGridViewJobOrder.Rows.Add(textBoxIdKaryawan.Text, labelNama.Text, labelGender.Text,
                labelTelepon.Text, comboBoxSatuan.Text, gaji);

                labelTotalGaji.Text = HitungGrandTotal().ToString("0,###");

                textBoxIdKaryawan.Clear();
                textBoxGaji.Clear();
                comboBoxSatuan.Text = "";
                labelNama.Text = "";
                labelGender.Text = "";
                labelTelepon.Text = "";
                textBoxIdKaryawan.Focus();
            }
        }
        private int HitungGrandTotal()
        {
            int grandTotal = 0;
            for (int i = 0; i < dataGridViewJobOrder.Rows.Count; i++)
            {
                int subTotal = int.Parse(dataGridViewJobOrder.Rows[i].Cells["gaji"].Value.ToString());
                grandTotal = grandTotal + subTotal;
            }
            return grandTotal;
        }
    }
}
