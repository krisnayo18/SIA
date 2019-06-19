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



namespace SistemAkuntansi
{
    public partial class FormDaftarSuratJalan : Form
    {
        public FormDaftarSuratJalan()
        {
            InitializeComponent();
        }
        List<SuratJalan> listHasilJalan = new List<SuratJalan>();
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormatDataGrid()
        {
            dataGridViewSurat.Columns.Clear();

            dataGridViewSurat.Columns.Add("noSuratJalan", "No Surat Jalan");
            dataGridViewSurat.Columns.Add("jenis", "Jenis");
            dataGridViewSurat.Columns.Add("tgl", "Tanggal");
            dataGridViewSurat.Columns.Add("keterangan", "Keterangan");
            dataGridViewSurat.Columns.Add("noSuratPermintaan", "No Surat Permintaan");

            dataGridViewSurat.Columns["noSuratJalan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewSurat.Columns["jenis"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewSurat.Columns["tgl"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewSurat.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewSurat.Columns["noSuratPermintaan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewSurat.AllowUserToAddRows = false;
        }
        public void FormDaftarSuratJalan_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            FormatDataGrid();

            string hasilBaca = SuratJalan.BacaData("", "", listHasilJalan);

            if (hasilBaca == "1")
            {
                dataGridViewSurat.Rows.Clear();

                for (int i = 0; i < listHasilJalan.Count; i++)
                {
                    string jenis = listHasilJalan[i].Jenis;
                    string je = "";
                    if(jenis == "M")
                    {
                        je = "Masuk";
                    }
                    else
                    {
                        je = "Keluar";
                    }
                    dataGridViewSurat.Rows.Add(listHasilJalan[i].NoSuratJalan,je, listHasilJalan[i].Tgl.ToString("dddd, dd MMMM yyyy"),
                        listHasilJalan[i].Keterangan, listHasilJalan[i].SuratPermintaan.NoSuratPermintaan
                        );
                }
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahSuratJalan frm = new FormTambahSuratJalan();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void textBoxBarang_TextChanged(object sender, EventArgs e)
        {
            //string hasilCari = "";
            //if (comboBoxBarang.Text == "Kode Barang")
            //{
            //    hasilCari = "B.kodeBarang";
            //}
            //else if (comboBoxBarang.Text == "Nama Barang")
            //{
            //    hasilCari = "B.nama";
            //}
            //else if (comboBoxBarang.Text == "Harga Beli")
            //{
            //    hasilCari = "B.hargaBeliTerbaru";
            //}
            //else if (comboBoxBarang.Text == "Harga Jual")
            //{
            //    hasilCari = "B.hargaJual";
            //}
            //else if (comboBoxBarang.Text == "Jenis")
            //{
            //    hasilCari = "B.jenis";
            //}
            //else if (comboBoxBarang.Text == "Kuantitas")
            //{
            //    hasilCari = "B.quantity";
            //}
            //else if (comboBoxBarang.Text == "Satuan")
            //{
            //    hasilCari = "B.satuan";
            //}

            //string hasilBaca = Barang.BacaData(hasilCari, textBoxBarang.Text, listHasilData);

            //if (hasilBaca == "1")
            //{
            //    dataGridViewBarang.Rows.Clear();

            //    for (int i = 0; i < listHasilData.Count; i++)
            //    {
            //        dataGridViewBarang.Rows.Add(listHasilData[i].KodeBarang, listHasilData[i].Barcode, listHasilData[i].Nama, listHasilData[i].HargaJual, listHasilData[i].Stok, listHasilData[i].Kategori.KodeKategori, listHasilData[i].Kategori.Nama);
            //    }
            //}
            //else
            //{
            //    dataGridViewBarang.Rows.Clear();
            //}
        }
    }
}
