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
    public partial class FormTambahSuratPermintaan : Form
    {
        public FormTambahSuratPermintaan()
        {
            InitializeComponent();
        }
        List<JobOrder> listHasilJob = new List<JobOrder>();
        List<Barang> listHasilBarang = new List<Barang>();
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
        private void FormTambahSuratPermintaan_Load(object sender, EventArgs e)
        {
 
            this.Location = new Point(500, 26);
            FormatDataGrid();
            pPeriode = Periode.GetPeriodeTerbaru();
            textBoxKode.MaxLength = 5;
            textBoxNoSurat.Enabled = false;

            comboBoxKodeJobOrder.DropDownStyle = ComboBoxStyle.DropDownList;

            string noSuratBaru;
            string hasilGenerate = SuratPermintaan.GenerateNoSuratPermintaan(out noSuratBaru);
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

            string hasilBaca = JobOrder.BacaData("", "", listHasilJob);

            if (hasilBaca == "1")
            {
                comboBoxKodeJobOrder.Items.Clear();
                for (int i = 0; i < listHasilJob.Count; i++)
                {
                    comboBoxKodeJobOrder.Items.Add(listHasilJob[i].KodeJobOrder);
                }
            }
            else
            {
                comboBoxKodeJobOrder.Items.Clear();
            }

            FormUtama form = (FormUtama)this.Owner.MdiParent;
            labelKodePgw.Text = form.labelKodePgw.Text;
            labelNamaPgw.Text = form.labelNamaPgw.Text;
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {

            FormUtama frmUtama = (FormUtama)this.Owner.MdiParent;
            FormDaftarSuratPermintaan form = (FormDaftarSuratPermintaan)this.Owner;
            //buat objek bertipe job order
            JobOrder job = new JobOrder();
            job.KodeJobOrder = comboBoxKodeJobOrder.Text;
            

            //buat object bertipe suratpermintaan
            string no = textBoxNoSurat.Text;
            string ket = textBoxKeterangan.Text;
            DateTime tanggal = dateTimePickerTgl.Value;
            SuratPermintaan surat = new SuratPermintaan(no, ket, tanggal,job);

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
                DetilSuratPermintaan detilSurat = new DetilSuratPermintaan(barang, jumlah);
                //simpan detil barang ke nota
                surat.TambahDetilBarang(barang, jumlah);
            }

            string hasilTambahSurat = SuratPermintaan.TambahData(surat);

            if (hasilTambahSurat == "1") 
            {
                    MessageBox.Show("berhasil tambah surat permintaan, barang akan diterima setelah menambahkan surat jalan");
                    this.Close();
                    form.FormDaftarSuratPermintaan_Load(sender, e); //supaya formdaftar surat menampilkan daftar terbaru
            }
            else
            {
                MessageBox.Show("Data nota jual gagal tersimpan. Pesan kesalahan : " + hasilTambahSurat, "Kesalahan");
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
                        string hasilJenis = listHasilBarang[0].Jenis;
                        if (hasilJenis == "BB")
                        {
                            labelNama.Text = listHasilBarang[0].Nama;
                            labelSatuan.Text = listHasilBarang[0].Satuan;
                            labelJenis.Text = listHasilBarang[0].Jenis;
                            labelHarga.Text = listHasilBarang[0].HargaBeliTerbaru.ToString();
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
                int hrga = int.Parse(labelHarga.Text);
                dataGridViewSurat.Rows.Add(textBoxKode.Text, labelNama.Text, hrga, labelJenis.Text,
                labelSatuan.Text, textBoxJumlah.Text, subTotal);

                labelTotalHarga.Text = HitungGrandTotal().ToString("0,###");

                textBoxKode.Clear();
                labelJenis.Text = "";
                labelNama.Text = "";
                labelHarga.Text = "";
                labelSatuan.Text = "";
                labelJenis.Text = "";
                textBoxJumlah.Clear();
                textBoxKode.Focus();
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

        private void comboBoxKodeJobOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            listHasilJob.Clear();
            string hasilBaca = JobOrder.BacaData("kodejoborder", comboBoxKodeJobOrder.Text, listHasilJob);

            if (hasilBaca == "1")
            {
                textBoxItem.Clear();
                if (listHasilJob.Count > 0)
                {
                    textBoxItem.Text = listHasilJob[0].Barang.Nama;
                }
            }
            else
            {
                textBoxItem.Clear();
            }
        }
    }
   
}
