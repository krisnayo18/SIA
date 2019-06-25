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
    public partial class FormTambahSuratJalan : Form
    {
        public FormTambahSuratJalan()
        {
            InitializeComponent();
        }
        int totalHpp = 0;
        int quantity = 0;
        int totalJobCost = 0;
        int hargaBeli = 0;
        int directMaterial;
        string kodeJob = "";
        List<SuratPermintaan> listHasilSuratPer = new List<SuratPermintaan>();
        List<Barang> listHasilBarang = new List<Barang>();
        List<JobOrder> listHasilJob = new List<JobOrder>();
        Periode pPeriode = new Periode();
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormatDataGrid()
        {
            dataGridViewSurat.Columns.Clear();

            dataGridViewSurat.Columns.Add("kodeBarang", "Kode Barang");
            dataGridViewSurat.Columns.Add("namaBarang", "Nama Barang");
            dataGridViewSurat.Columns.Add("harga", "Harga");
            dataGridViewSurat.Columns.Add("jenis", "Jenis");
            dataGridViewSurat.Columns.Add("satuan", "Satuan");
            dataGridViewSurat.Columns.Add("jumlah", "Jumlah");
            dataGridViewSurat.Columns.Add("subTotal", "Sub Total");

            dataGridViewSurat.Columns["kodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewSurat.Columns["namaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewSurat.Columns["harga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewSurat.Columns["jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewSurat.Columns["subTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewSurat.Columns["jenis"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewSurat.Columns["satuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewSurat.Columns["jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSurat.Columns["harga"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSurat.Columns["subTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewSurat.AllowUserToAddRows = false;
        }

        private void FormTambahSuratJalan_Load(object sender, EventArgs e)
        {
            comboBoxJenis.Items.AddRange(new string[] { "Masuk", "Keluar" });
            this.Location = new Point(500, 26);
            FormatDataGrid();
            pPeriode = Periode.GetPeriodeTerbaru();
            textBoxKode.MaxLength = 5;
            textBoxNoSurat.Enabled = false;

            comboBoxSuratPermintaan.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxJenis.DropDownStyle = ComboBoxStyle.DropDownList;

            string noSuratBaru;
            string hasilGenerate = SuratJalan.GenerateNoSuratJalan(out noSuratBaru);
            textBoxNoSurat.Clear();
            if (hasilGenerate == "1")
            {
                textBoxNoSurat.Text = noSuratBaru;
            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            }

            dateTimePickerTgl.Value = DateTime.Now;
            dateTimePickerTgl.Enabled = false;

            string hasilBaca = SuratPermintaan.BacaData("JO.status", "P", listHasilSuratPer);

            if (hasilBaca == "1")
            {
                comboBoxSuratPermintaan.Items.Clear();
                for (int i = 0; i < listHasilSuratPer.Count; i++)
                {
                    comboBoxSuratPermintaan.Items.Add(listHasilSuratPer[i].NoSuratPermintaan);

                }
            }
            else
            {
                comboBoxSuratPermintaan.Items.Clear();
            }
            if(comboBoxSuratPermintaan.Items.Count != 0)
            comboBoxSuratPermintaan.SelectedIndex = 0;
            comboBoxJenis.SelectedIndex = 1;

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
                        string hasilJenis = listHasilBarang[0].Jenis;
                        string jenisSurat = comboBoxJenis.Text;
                        if(jenisSurat == "Keluar")
                        {
                            if (hasilJenis == "BB")
                            {
                                labelNama.Text = listHasilBarang[0].Nama;
                                labelSatuan.Text = listHasilBarang[0].Satuan;
                                labelJenis.Text = listHasilBarang[0].Jenis;
                                labelHarga.Text = listHasilBarang[0].HargaBeliTerbaru.ToString();
                                hargaBeli = int.Parse(listHasilBarang[0].HargaBeliTerbaru.ToString());
                                textBoxJumlah.Focus();
                                textBoxJumlah.Text = "1";
                            }
                            else
                            {
                                MessageBox.Show("Gunakan bahan baku, untuk mengurangi biaya.");
                                textBoxKode.Clear();
                            }
                        }
                        else
                        {
                                labelNama.Text = listHasilBarang[0].Nama;
                                labelSatuan.Text = listHasilBarang[0].Satuan;
                                labelJenis.Text = listHasilBarang[0].Jenis;
                                labelHarga.Text = (totalJobCost / quantity).ToString();
                                textBoxJumlah.Text = quantity.ToString();
                                textBoxJumlah.Focus();
                        }

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
            if (e.KeyCode == Keys.Enter)
            {
                int subTotal = int.Parse(labelHarga.Text) * int.Parse(textBoxJumlah.Text);    
                totalHpp = totalHpp + (int.Parse(textBoxJumlah.Text) * hargaBeli);

                dataGridViewSurat.Rows.Add(textBoxKode.Text, labelNama.Text, labelHarga.Text,
                labelJenis.Text, labelSatuan.Text, textBoxJumlah.Text, subTotal);

                labelTotalHarga.Text = HitungGrandTotal().ToString("0,###");

                textBoxKode.Clear();
                labelJenis.Text = "";
                labelNama.Text = "";
                labelHarga.Text = "";
                labelSatuan.Text = "";
                labelJenis.Text = "";
                textBoxJumlah.Clear();
                textBoxKode.Focus();
                if(comboBoxJenis.Text == "Masuk")
                {
                    textBoxJumlah.Enabled = false;
                }
            }
        }
        private int HitungGrandTotal()
        {
            int grandTotal = 0;
            for (int i = 0; i < dataGridViewSurat.Rows.Count; i++)
            {
                int subTotal = int.Parse(dataGridViewSurat.Rows[i].Cells["subTotal"].Value.ToString());
                grandTotal = grandTotal + subTotal;
            }
            return grandTotal;
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {

            FormUtama frmUtama = (FormUtama)this.Owner.MdiParent;
            FormDaftarSuratJalan form = (FormDaftarSuratJalan)this.Owner;
            //buat objek bertipe job order
            SuratPermintaan sp = new SuratPermintaan();
            sp.NoSuratPermintaan = comboBoxSuratPermintaan.Text;

            //buat object bertipe suratjalan
            string no = textBoxNoSurat.Text;
            string pjenis = comboBoxJenis.Text;
            if (pjenis == "Masuk")
                pjenis = "M";
            else
                pjenis = "K";
            string ket = textBoxKeterangan.Text;
            DateTime tanggal = dateTimePickerTgl.Value;
            SuratJalan surat = new SuratJalan(no,pjenis,ket,tanggal,sp);

            //data barang diperoleh dari data gridview
            for (int i = 0; i < dataGridViewSurat.Rows.Count; i++)
            {
                //buat object bertipe barang
                Barang barang = new Barang();
                //tambahkan kode, nama, jenis, satuan
                //hati hati dalam menambahkan
                barang.KodeBarang = dataGridViewSurat.Rows[i].Cells["KodeBarang"].Value.ToString();
                barang.Nama = dataGridViewSurat.Rows[i].Cells["NamaBarang"].Value.ToString();
                barang.Jenis = dataGridViewSurat.Rows[i].Cells["jenis"].Value.ToString();
                barang.Satuan = dataGridViewSurat.Rows[i].Cells["satuan"].Value.ToString();
                //simpan  data harga dan jumlah 
                int jumlah = int.Parse(dataGridViewSurat.Rows[i].Cells["Jumlah"].Value.ToString());
                //buat object dan tambahkan
                DetilSuratJalan detilSurat = new DetilSuratJalan(barang, jumlah);
                //simpan detil barang ke nota
                surat.TambahDetilBarang(barang, jumlah);
            }

            string hasilTambahNota = SuratJalan.TambahData(surat);

            if (hasilTambahNota == "1") //jika berhasil maka insert jurnal dan detil jurnal
            {
                MessageBox.Show("Surat Jalan telah tersimpan", "Info");

                //tambah posting ke jurnal
                string idtrans = "";
                string ketTrans = "";
                string idJurnal = Jurnal.GenerateIdJurnal();
                if (comboBoxJenis.Text == "Masuk")
                {   
                    // barang masuk ke gudang
                    idtrans = "007";
                    ketTrans = "Menyelesaikan produksi Job Order no 123";
                }
                else
                {   
                    //barang diambil dari gudang 
                    idtrans = "004";
                    ketTrans = "PPIC menerima bahan baku dari gudang";
                }
                Transaksi trans = new Transaksi();
                trans.IdTransaksi = idtrans;
                trans.Keterangan = ketTrans;

                //buat object bertipe jurnal
                Jurnal jurnal = new Jurnal();
                //tambahkan data
                jurnal.IdJurnal = int.Parse(idJurnal);
                jurnal.Tanggal = dateTimePickerTgl.Value;

                jurnal.NomorBukti = textBoxNoSurat.Text;
                jurnal.Jenis = "JU";
                jurnal.Periode = pPeriode;
                jurnal.Transaksi = trans;

                //isi detil jurnalnya
                int totalharga = HitungGrandTotal(); // panggil method hitung total harga untuk mendapatkan totalharga
                if (comboBoxJenis.Text == "Masuk")
                {
                    jurnal.TambahDetilJurnalPenyelesaianProduksi(totalJobCost);
                    string hasil = JobOrder.UpdateStatusJobOrder(kodeJob);
                    if(hasil == "1")
                        MessageBox.Show("Job Order : " + kodeJob + " telah selesai ");
                    else
                        MessageBox.Show(hasil);

                }
                else
                {
                    string hasil =  JobOrder.UpdateDirectMaterial(kodeJob, totalharga);
                  
                    if(hasil =="1")
                    {
                        MessageBox.Show("sudah di update " + kodeJob + ", total Direct Material RP " + totalharga.ToString("0,###") );
                    }
                    else
                    {
                        MessageBox.Show(hasil);
                    }
                    jurnal.TambahDetilJurnalMenerimaBahanBaku(totalharga);
                }
                //simpan ke tabel _jurnal
                string hasilTambahJurnal = Jurnal.TambahData(jurnal);
                if (hasilTambahJurnal == "1")
                {
                    MessageBox.Show("berhasil posting ke jurnal");
                    this.Close();
                    form.FormDaftarSuratJalan_Load(sender, e); //supaya formdaftar surat jalan menampilkan daftar terbaru
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
        private void comboBoxJenis_TextChanged(object sender, EventArgs e)
        {
            if(comboBoxJenis.Text == "Masuk")
            {
                textBoxKode.Clear();
                

                string hasilBaca2 = JobOrder.BacaData("kodejoborder", kodeJob, listHasilJob);

                    if (hasilBaca2 == "1")
                    {
                        if (listHasilJob.Count > 0)
                        {
                            textBoxKode.Enabled = false;
                            textBoxKode.Text = listHasilJob[0].Barang.KodeBarang;
                        }
                        else
                        {
                            MessageBox.Show("job order tidak ditemukan.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Perintah SQL gagal dijalankan. Pesan kesalahan: " + hasilBaca2);
                    }        

                MessageBox.Show("Kode Job Order : " + kodeJob + ",Quantity : " + quantity + ", Total Job Cost : " + totalJobCost.ToString("RP 0,###") + "", "Info");
            }
            else if(comboBoxJenis.Text == "Keluar")
            {
                textBoxKode.Clear();
                textBoxKode.Enabled = true;
                labelJenis.Text = "";
                labelNama.Text = "";
                labelHarga.Text = "";
                labelSatuan.Text = "";
                labelJenis.Text = "";
                textBoxJumlah.Clear();
                textBoxKode.Focus();
           }
        }

        private void comboBoxSuratPermintaan_SelectedIndexChanged(object sender, EventArgs e)
        {

            string hasilBaca2 = SuratPermintaan.BacaData("nosuratpermintaan", comboBoxSuratPermintaan.Text, listHasilSuratPer);
            if (hasilBaca2 == "1")
            {
                if (listHasilSuratPer.Count > 0)
                {
                    kodeJob = listHasilSuratPer[0].JobOrder.KodeJobOrder;
                    quantity = listHasilSuratPer[0].JobOrder.Quantity;
                    directMaterial = listHasilSuratPer[0].JobOrder.DirectMaterial;
                    totalJobCost = listHasilSuratPer[0].JobOrder.DirectLabor + listHasilSuratPer[0].JobOrder.DirectMaterial +
                                   listHasilSuratPer[0].JobOrder.OverheadProduksi;
                }
            }
            else
            {
                MessageBox.Show("Perintah SQL gagal dijalankan. Pesan kesalahan: " + hasilBaca2);
            }
            comboBoxJenis_TextChanged(sender, e);
        }
    }
}
