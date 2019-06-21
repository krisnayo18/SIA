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
    public partial class FormTambahNotaBeli : Form
    {
        public FormTambahNotaBeli()
        {
            InitializeComponent();
        }
        int hargaBeli = 0;
        List<Supplier> listHasilData = new List<Supplier>();
        List<Barang> listHasilBarang = new List<Barang>();
        Periode pPeriode = new Periode();
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormatDataGrid()
        {
            dataGridViewNota.Columns.Clear();

            dataGridViewNota.Columns.Add("KodeBarang", "Kode Barang");
            dataGridViewNota.Columns.Add("NamaBarang", "Nama Barang");
            dataGridViewNota.Columns.Add("diskon", "Diskon");
            dataGridViewNota.Columns.Add("status", "Status");
            dataGridViewNota.Columns.Add("keterangan", "Keterangan");
            dataGridViewNota.Columns.Add("HargaBeli", "Harga Beli");
            dataGridViewNota.Columns.Add("jenis", "Jenis");
            dataGridViewNota.Columns.Add("satuan", "Satuan");
            dataGridViewNota.Columns.Add("Jumlah", "Jumlah");
            dataGridViewNota.Columns.Add("SubTotal", "Sub Total");

            dataGridViewNota.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["diskon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["HargaBeli"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["jenis"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["satuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewNota.Columns["Jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewNota.Columns["diskon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewNota.Columns["HargaBeli"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewNota.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewNota.Columns["HargaBeli"].DefaultCellStyle.Format = "0,###";
            dataGridViewNota.Columns["SubTotal"].DefaultCellStyle.Format = "0,###";

            dataGridViewNota.AllowUserToAddRows = false;
        }
        private void FormTambahNotaBeli_Load(object sender, EventArgs e)
        {
            comboBoxStatus.Items.AddRange(new string[] {"L","B"});
            this.Location = new Point(500, 26);
            FormatDataGrid();

            pPeriode = Periode.GetPeriodeTerbaru();
            textBoxKode.MaxLength = 5;
            textBoxNo.Enabled = false;

            textBoxAlamat.Enabled = false;

            comboBoxSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            string noNotaBaru;
            string hasilGenerate = NotaPembelian.GenerateNoNota(out noNotaBaru);
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

            dateTimePickerTanggalBeli.Value = DateTime.Now;
            dateTimePickerTanggalBeli.Enabled = false;

            string hasilBaca = Supplier.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                comboBoxSupplier.Items.Clear();
                for (int i = 0; i < listHasilData.Count; i++)
                {
                    comboBoxSupplier.Items.Add(listHasilData[i].IdSupplier + " - " + listHasilData[i].Nama);
                }
            }
            else
            {
                comboBoxSupplier.Items.Clear();
            }

            if (comboBoxStatus.Items.Count != 0)
                comboBoxStatus.SelectedIndex = 0;
            if (comboBoxSupplier.Items.Count != 0)
                comboBoxSupplier.SelectedIndex = 0;

            FormUtama form = (FormUtama)this.Owner.MdiParent;
            labelKodePgw.Text = form.labelKodePgw.Text;
            labelNamaPgw.Text = form.labelNamaPgw.Text;
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            FormUtama frmUtama = (FormUtama)this.Owner.MdiParent;
            FormDaftarNotaBeli form = (FormDaftarNotaBeli)this.Owner;
            //buat objek bertipe Supplier
            Supplier supplier = new Supplier();
            //format combo box supplier: X -yyyyyy (kode supplier karakter 0 sebanyak 1, nama kategori mulai karakter  ke-4 s/d akhir
            supplier.IdSupplier = comboBoxSupplier.Text.Substring(0, 1); //kode supplier diambil dari  combobox
            supplier.Nama = comboBoxSupplier.Text.Substring(4, comboBoxSupplier.Text.Length - 4);//nama supplier diambil dari combo box
            supplier.Alamat = textBoxAlamat.Text;

            //buat object bertipe notabeli
            NotaPembelian nota = new NotaPembelian(textBoxNo.Text, comboBoxStatus.Text, textBoxKeterangan.Text, double.Parse(textBoxDiskon.Text),
                HitungGrandTotal(), dateTimePickerTglLunas.Value, dateTimePickerDiskon.Value, dateTimePickerTanggalBeli.Value, supplier);

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
                barang.Satuan = dataGridViewNota.Rows[i].Cells["satuan"].Value.ToString();
                //simpan  data hargabeli dan jumlah 
                int harga = int.Parse(dataGridViewNota.Rows[i].Cells["HargaBeli"].Value.ToString());
                int jumlah = int.Parse(dataGridViewNota.Rows[i].Cells["Jumlah"].Value.ToString());
                //buat object dan tambahkan
                DetilNotaBeli notaDetil = new DetilNotaBeli(barang, jumlah, harga);
                //simpan detil barang ke nota
                nota.TambahDetilBarang(barang, jumlah, harga);
            }

            string hasilTambahNota = NotaPembelian.TambahData(nota);

            if (hasilTambahNota == "1") //jika berhasil maka insert jurnal dan detil jurnal
            {
                MessageBox.Show("Data nota beli telah tersimpan", "Info");


                //tambah posting ke jurnal
                string idtrans = "";
                string ket = "";
                string idJurnal = Jurnal.GenerateIdJurnal();
                if (comboBoxStatus.Text == "L")
                {
                    idtrans = "012";
                    ket = "Membeli bahan baku secara Tunai";
                }
                else if (comboBoxStatus.Text == "B")
                {
                    idtrans = "001";
                    ket = "Membeli bahan baku secara kredit";
                }

                Transaksi trans = new Transaksi();
                trans.IdTransaksi = idtrans;
                trans.Keterangan = ket;

                //buat object bertipe jurnal
                Jurnal jurnal = new Jurnal();
                //tambahkan data
                jurnal.IdJurnal = int.Parse(idJurnal);
                jurnal.Tanggal = dateTimePickerTanggalBeli.Value;

                jurnal.NomorBukti = textBoxNo.Text;
                jurnal.Jenis = "JU";
                jurnal.Periode = pPeriode;
                jurnal.Transaksi = trans;

                //isi detil jurnalnya
                int totalharga = HitungGrandTotal(); // panggil method hitung total harga untuk mendapatkan totalharga
                if (comboBoxStatus.Text == "L")
                {
                    jurnal.TambahDetilJurnalPembelianBarangTunai(totalharga);
                }
                else
                {
                    jurnal.TambahDetilJurnalPembelianBarangKredit(totalharga);
                }
                //simpan ke tabel _jurnal
                string hasilTambahJurnal = Jurnal.TambahData(jurnal);
                if (hasilTambahJurnal == "1")
                {
                    string hasilCetak = NotaPembelian.CetakNota("NoNotaPembelian", textBoxNo.Text, "Nota_Beli_Tambah.txt");
                    if (hasilCetak == "1")
                    {
                        MessageBox.Show("berhasil posting ke jurnal");
                        MessageBox.Show("Nota telah tercetak");
                        this.Close();
                        form.FormDaftarNotaBeli_Load(sender, e); //supaya formdaftar barang menampilkan daftar terbaru
                    }
                    else MessageBox.Show("Nota beli gagal dicetak. Pesan kesalahan : " + hasilCetak);
                }
                else
                {
                    MessageBox.Show("gagal posting ke jurnal" + hasilTambahJurnal);
                }

            }
            else
            {
                MessageBox.Show("Data nota beli gagal tersimpan. Pesan kesalahan : " + hasilTambahNota, "Kesalahan");
            }

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
                        textBoxHarga.Focus();
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

        private void textBoxJumlah_KeyDown(object sender, KeyEventArgs e)
        {
            hargaBeli = int.Parse(textBoxHarga.Text);
            if (e.KeyCode == Keys.Enter)
            {
                int subTotal = hargaBeli * int.Parse(textBoxJumlah.Text);

                dataGridViewNota.Rows.Add(textBoxKode.Text, labelNama.Text, textBoxDiskon.Text,
                comboBoxStatus.Text, textBoxKeterangan.Text, textBoxHarga.Text, labelJenis.Text,
                labelSatuan.Text, textBoxJumlah.Text, subTotal);

                labelTotalHarga.Text = HitungGrandTotal().ToString("0,###");


                textBoxKode.Clear();
                labelJenis.Text = "";
                labelNama.Text = "";
                textBoxHarga.Text = "";
                labelSatuan.Text = "";
                labelJenis.Text = "";
                textBoxJumlah.Clear();
                textBoxKode.Focus();
            }
        }
        private int HitungGrandTotal()
        {
            int grandTotal = 0;
            for (int i = 0; i < dataGridViewNota.Rows.Count; i++)
            {
                int subTotal = int.Parse(dataGridViewNota.Rows[i].Cells["SubTotal"].Value.ToString());
                grandTotal = grandTotal + subTotal;
            }
            return grandTotal;
        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            listHasilData.Clear();
            string hasilBaca = Supplier.BacaData("idSupplier", comboBoxSupplier.Text.Substring(0, 1), listHasilData);

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

        private void buttonCetakNotaBeli_Click(object sender, EventArgs e)
        {
           
        }
    }
}
