using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClassLibraryTransaksi;
using ClassLibraryJurnal;

namespace SistemAkuntansi
{
    public partial class FormTambahNotaJual : Form
    {
        public FormTambahNotaJual()
        {
            InitializeComponent();
        }

        int totalHpp = 0;
        int hargaBeli = 0;
        List<Pelanggan> listHasilData = new List<Pelanggan>();
        List<Barang> listHasilBarang = new List<Barang>();

        private void FormatDataGrid()
        {
            dataGridViewNota.Columns.Clear();

            dataGridViewNota.Columns.Add("KodeBarang", "Kode Barang");
            dataGridViewNota.Columns.Add("NamaBarang", "Nama Barang");
            dataGridViewNota.Columns.Add("diskon", "Diskon");
            dataGridViewNota.Columns.Add("status", "Status");
            dataGridViewNota.Columns.Add("keterangan", "Keterangan");
            dataGridViewNota.Columns.Add("HargaJual", "Harga Jual");
            dataGridViewNota.Columns.Add("jenis", "Jenis");
            dataGridViewNota.Columns.Add("satuan", "Satuan");
            dataGridViewNota.Columns.Add("Jumlah", "Jumlah");
            dataGridViewNota.Columns.Add("SubTotal", "Sub Total");

            dataGridViewNota.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["diskon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["jenis"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["satuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewNota.Columns["Jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewNota.Columns["diskon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewNota.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewNota.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewNota.Columns["HargaJual"].DefaultCellStyle.Format = "0,###";
            dataGridViewNota.Columns["SubTotal"].DefaultCellStyle.Format = "0,###";

            dataGridViewNota.AllowUserToAddRows = false;
        }

        private void FormTambahNotaJual_Load(object sender, EventArgs e)
        {
            this.Location = new Point(500, 26);
            FormatDataGrid();

            textBoxKode.MaxLength = 5;
            textBoxNo.Enabled = false;
            
            textBoxAlamat.Enabled = false;

            comboBoxPelanggan.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            string noNotaBaru;
            string hasilGenerate = NotaPenjualan.GenerateNoNota(out noNotaBaru);
            textBoxNo.Clear();
            if (hasilGenerate == "1")
            {
                textBoxNo.Text = noNotaBaru;
                textBoxKode.Focus();
            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            }

            dateTimePickerTanggalJual.Value = DateTime.Now;
            dateTimePickerTanggalJual.Enabled = false;

            string hasilBaca = Pelanggan.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                comboBoxPelanggan.Items.Clear();
                for (int i = 0; i < listHasilData.Count; i++)
                {
                    comboBoxPelanggan.Items.Add(listHasilData[i].IdPelanggan + " - " + listHasilData[i].Nama);
                }
            }
            else
            {
                comboBoxPelanggan.Items.Clear();
            }

            FormUtama form = (FormUtama)this.Owner.MdiParent;
            labelKodePgw.Text = form.labelKodePgw.Text;
            labelNamaPgw.Text = form.labelNamaPgw.Text;
        }

        private void textBoxKode_TextChanged(object sender, EventArgs e)
        {
            //jika user mengisi panjang karakter sesuai kode barang
            if (textBoxKode.Text.Length == textBoxKode.MaxLength)
            {   
                //cari nama barang sesuai kode yang diinputkan oleh user
                string hasilBaca = Barang.BacaData("kodeBarang", textBoxKode.Text, listHasilBarang);

                if (hasilBaca == "1")
                {
                    if (listHasilBarang.Count > 0) //jika kode barang  ditemukan di database
                    {

                        labelNama.Text = listHasilBarang[0].Nama;
                        labelSatuan.Text = listHasilBarang[0].Satuan;
                        labelJenis.Text = listHasilBarang[0].Jenis;
                        labelHarga.Text = listHasilBarang[0].HargaJual.ToString();
                        hargaBeli = int.Parse(listHasilBarang[0].HargaBeliTerbaru.ToString());
                        textBoxJumlah.Focus();
                        textBoxJumlah.Text = "1";
                    }
                    else
                    {
                        MessageBox.Show("Barang tidak ditemukan.");
                        textBoxKode.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankan. Pesan kesalahan: " + hasilBaca);
                }
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxJumlah_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int subTotal = int.Parse(labelHarga.Text) * int.Parse(textBoxJumlah.Text);
                totalHpp = totalHpp + (int.Parse(textBoxJumlah.Text) * hargaBeli);

                dataGridViewNota.Rows.Add(textBoxKode.Text, labelNama.Text, textBoxDiskon.Text,
                comboBoxStatus.Text, textBoxKeterangan.Text, labelHarga.Text, labelJenis.Text,
                labelSatuan.Text,  textBoxJumlah.Text,   subTotal);

                labelTotalHarga.Text = HitungGrandTotal().ToString("0,###");


                textBoxKode.Clear();
                labelJenis.Text = "";
                labelNama.Text = "";
                labelHarga.Text = "";
                labelSatuan.Text = "";
                labelJenis.Text = "";
                textBoxJumlah.Clear();
            }
        }

        private int HitungGrandTotal()
        {
            int grandTotal = 0;
            for (int i=0; i<dataGridViewNota.Rows.Count; i++)
            {
                int subTotal = int.Parse(dataGridViewNota.Rows[i].Cells["SubTotal"].Value.ToString());
                grandTotal = grandTotal + subTotal;
            }
            return grandTotal;
        }

        private void comboBoxPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            listHasilData.Clear();
            string hasilBaca = Pelanggan.BacaData("idPelanggan", comboBoxPelanggan.Text.Substring(0, 1), listHasilData);

            if (hasilBaca == "1")
            {
                textBoxAlamat.Clear();
                if (listHasilData.Count > 0)
                {
                    textBoxAlamat.Text = listHasilData[0].Alamat;
                }
            }
            else
            {
                textBoxAlamat.Clear();
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            FormDaftarNotaJual form = (FormDaftarNotaJual)this.Owner;
            //buat objek bertipe pelanggan
            Pelanggan pelanggan = new Pelanggan();
            //format combo box pelanggan: X -yyyyyy (kode pelanggan karakter 0 sebanyak 1, nama kategori mulai karakter  ke-4 s/d akhir
            pelanggan.IdPelanggan = int.Parse(comboBoxPelanggan.Text.Substring(0, 1)); //kode pelanggan diambil dari  combobox
            pelanggan.Nama = comboBoxPelanggan.Text.Substring(4, comboBoxPelanggan.Text.Length - 4);//nama pelanggan diambil dari combo box
            pelanggan.Alamat = textBoxAlamat.Text;

            //buat object bertipe notajual
            NotaPenjualan nota = new NotaPenjualan();
            nota.NoNotaPenjualan = textBoxNo.Text;
            nota.Status = comboBoxStatus.Text;
            nota.Keterangan = textBoxKeterangan.Text;
            nota.Diskon = double.Parse(textBoxDiskon.Text);
            nota.TotalHarga = HitungGrandTotal();
            nota.TglBatasPelunasan = dateTimePickerTglLunas.Value;
            nota.TglBatasDiskon = dateTimePickerDiskon.Value;
            nota.TglJual = dateTimePickerTanggalJual.Value;
            nota.Pelanggan = pelanggan;

            //data barang diperoleh dari data gridview
            for (int i = 0; i < dataGridViewNota.Rows.Count; i++)
            {
                //buat object bertipe barang
                Barang barang = new Barang();
                //tambahkan kode, nama, jenis, satuan
                //hati hati dalam menambahkan
                barang.KodeBarang = dataGridViewNota.Rows[i].Cells["KodeBarang"].Value.ToString();
                barang.Nama = dataGridViewNota.Rows[i].Cells["NamaBarang"].Value.ToString();
                barang.Jenis = dataGridViewNota.Rows[i].Cells["jenis"].Value.ToString();
                barang.Satuan= dataGridViewNota.Rows[i].Cells["satuan"].Value.ToString();
                //simpan  data hargajual dan jumlah 
                int harga = int.Parse(dataGridViewNota.Rows[i].Cells["HargaJual"].Value.ToString());
                int jumlah = int.Parse(dataGridViewNota.Rows[i].Cells["Jumlah"].Value.ToString());
                //buat object dan tambahkan
                DetilNotaJual notaDetil = new DetilNotaJual(barang, jumlah, harga);
                //simpan detil barang ke nota
                nota.TambahDetilBarang(barang, jumlah, harga);
            }

            string hasilTambahNota = NotaPenjualan.TambahData(nota);

            if (hasilTambahNota == "1") //jika berhasil maka insert jurnal dan detil jurnal
            {
                MessageBox.Show("Data nota jual telah tersimpan", "Info");
                form.FormDaftarNotaJual_Load(sender, e); //supaya formdaftar barang menampilkan daftar terbaru

                //tambah posting ke jurnal
                FormUtama frmUtama = (FormUtama)this.Owner.MdiParent; ;
                string idJurnal = Jurnal.GenerateIdJurnal();

                // periode diambil dari form utama
                //Periode periode = frmUtama.periode;

                //buat object periode
                Periode periode = new Periode();
                //tambhakan data id periode
                periode.IdPeriode = "1501";

                Transaksi trans = new Transaksi();
                //transaksi penjualan tunai (id transkasi 008);
                trans.IdTransaksi = "008";
                trans.Keterangan = "Menjual barang dagangan secara tunai";

                //buat object bertipe jurnal
                Jurnal jurnal = new Jurnal();
                //tambahkan data
                jurnal.IdJurnal = idJurnal;
                jurnal.Tanggal = dateTimePickerTanggalJual.Value;
                jurnal.Keterangan = textBoxKeterangan.Text;
                jurnal.NomorBukti = textBoxNo.Text;
                jurnal.Jenis = "JU";
                jurnal.Periode = periode;
                jurnal.Transaksi = trans;

                //isi detil jurnalnya
                int totalharga = HitungGrandTotal(); // panggil method hitung total harga untuk mendapatkan totalharga

                jurnal.TambahDetilJurnalPenjualanBarangTunai(totalharga, totalHpp);
                 //simpan ke tabel _jurnal
                string hasilTambahJurnal = Jurnal.TambahData(jurnal);
                if (hasilTambahJurnal == "1")
                {
                    MessageBox.Show("berhasil posting ke jurnal");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("gagal posting ke jurnal" + hasilTambahJurnal);
                }

            }
            else
            {
                MessageBox.Show("Data nota jual gagal tersimpan. Pesan kesalahan : " + hasilTambahNota, "Kesalahan");
            }
        }

        private void buttonCetakNota_Click(object sender, EventArgs e)
        {
            //string hasilCetak = NotaJual.CetakNota("N.NoNota", textBoxNo.Text, "Nota_Jual_Tambah.txt");
            //if (hasilCetak == "1") MessageBox.Show("Nota telah tercetak");
            //else MessageBox.Show("Nota jual gagal dicetak. Pesan kesalahan : " + hasilCetak);   
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void labelKode_Click(object sender, EventArgs e)
        {

        }
    }
}
