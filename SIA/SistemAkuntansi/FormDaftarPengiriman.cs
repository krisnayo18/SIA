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
    public partial class FormDaftarPengiriman : Form
    {
        public FormDaftarPengiriman()
        {
            InitializeComponent();
        }
        List<Pengiriman> listHasilData = new List<Pengiriman>();
        string kriteria = "";
        string jenis = "";
        public void FormatDataGrid()
        {

            dataGridViewPengiriman.Columns.Clear();

            dataGridViewPengiriman.Columns.Add("kodePengiriman", "Kode Pengiriman");
            dataGridViewPengiriman.Columns.Add("jenisPengiriman", "Jenis Pengiriman");
            dataGridViewPengiriman.Columns.Add("biayaKirim", "Biaya Kirim");
            dataGridViewPengiriman.Columns.Add("tglKirim", "Tanggal Kirim");
            dataGridViewPengiriman.Columns.Add("nama", "Nama");
            dataGridViewPengiriman.Columns.Add("keterangan", "Keterangan");
            dataGridViewPengiriman.Columns.Add("NoNotaPenjualan", "Nomor Nota Pembelian");
            dataGridViewPengiriman.Columns.Add("idEkspedisi", "ID Ekspedisi");
            dataGridViewPengiriman.Columns.Add("namaEkspedisi", "Nama Ekspedisi");


            dataGridViewPengiriman.Columns["kodePengiriman"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengiriman.Columns["jenisPengiriman"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengiriman.Columns["tglKirim"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengiriman.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengiriman.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengiriman.Columns["biayaKirim"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengiriman.Columns["noNotaPenjualan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengiriman.Columns["idEkspedisi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengiriman.Columns["NamaEkspedisi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewPengiriman.AllowUserToAddRows = false;
        }
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPengiriman frm = new FormTambahPengiriman();
            frm.Owner = this;
            frm.ShowDialog();
        }

        public void FormDaftarPengiriman_Load(object sender, EventArgs e)
        {
            comboBoxCari.Items.AddRange(new string[] { "Kode Pengiriman", "Jenis Penerimaan", "Biaya Kirim", "Tanggal Kirim", "Nama", "Keterangan",
                "Nomor Nota Penjualan", "ID Ekspedisi", "Nama Ekspedisi"});

            this.Location = new Point(0, 0);
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            FormatDataGrid();

            string hasilBaca = Pengiriman.BacaData("", "", listHasilData);
           
            if (hasilBaca == "1")
            {
                dataGridViewPengiriman.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    if (listHasilData[i].JenisPengiriman == "SP")
                        jenis = "Shipping Point";
                    else
                        jenis = "Destination Point";
                    string total = listHasilData[i].BiayaKirim.ToString("RP 0,###");
                    dataGridViewPengiriman.Rows.Add(listHasilData[i].KodePengiriman, jenis,
                        total, listHasilData[i].TglKirim.ToString("dddd, dd MMMM yyyy"), listHasilData[i].Nama, listHasilData[i].Keterangan, listHasilData[i].NotaPenjualan.NoNotaPenjualan,
                        listHasilData[i].Ekspedisi.IdEkspedisi, listHasilData[i].Ekspedisi.Nama);
                }
            }
        }

        private void comboBoxCari_TextChanged(object sender, EventArgs e)
        {
            textBoxCari.Clear();
            string hasilBaca = Pengiriman.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewPengiriman.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    if (listHasilData[i].JenisPengiriman == "SP")
                        jenis = "Shipping Point";
                    else
                        jenis = "Destination Point";
                    string total = listHasilData[i].BiayaKirim.ToString("RP 0,###");
                    dataGridViewPengiriman.Rows.Add(listHasilData[i].KodePengiriman, jenis,
                        total, listHasilData[i].TglKirim.ToString("dddd, dd MMMM yyyy"), listHasilData[i].Nama, listHasilData[i].Keterangan, listHasilData[i].NotaPenjualan.NoNotaPenjualan,
                        listHasilData[i].Ekspedisi.IdEkspedisi, listHasilData[i].Ekspedisi.Nama);
                }
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCari.Text == "")
            {
                string hasilBaca = Pengiriman.BacaData("", "", listHasilData);

                if (hasilBaca == "1")
                {
                    dataGridViewPengiriman.Rows.Clear();

                    for (int i = 0; i < listHasilData.Count; i++)
                    {
                        if (listHasilData[i].JenisPengiriman == "SP")
                            jenis = "Shipping Point";
                        else
                            jenis = "Destination Point";
                        string total = listHasilData[i].BiayaKirim.ToString("RP 0,###");
                        dataGridViewPengiriman.Rows.Add(listHasilData[i].KodePengiriman, jenis,
                            total, listHasilData[i].TglKirim.ToString("dddd, dd MMMM yyyy"), listHasilData[i].Nama, listHasilData[i].Keterangan, listHasilData[i].NotaPenjualan.NoNotaPenjualan,
                            listHasilData[i].Ekspedisi.IdEkspedisi, listHasilData[i].Ekspedisi.Nama);
                    }
                }
            }
        }

        private void buttonCari_Click(object sender, EventArgs e)
        {

            string nilaiKriteria = textBoxCari.Text;
            if (comboBoxCari.Text == "Kode Pengiriman") kriteria = "P.kodePengiriman";
            else if (comboBoxCari.Text == "Jenis Penerimaan") kriteria = "P.jenisPenerimaan";
            else if (comboBoxCari.Text == "Biaya Kirim") kriteria = "P.biayaKirim";
            else if (comboBoxCari.Text == "Tanggal Kirim") kriteria = "P.tglKirim";
            else if (comboBoxCari.Text == "Nama") kriteria = "P.nama";
            else if (comboBoxCari.Text == "Keterangan") kriteria = "P.keterangan";
            else if (comboBoxCari.Text == "Nomor Nota Penjualan") kriteria = "NP.noNotaPenjualan";
            else if (comboBoxCari.Text == "ID Ekspedisi") kriteria = "E.idEkspedisi";
            else if (comboBoxCari.Text == "Nama Ekspedisi") kriteria = "E.namaEkspedisi";

            string hasilBaca = Pengiriman.BacaData(kriteria, nilaiKriteria, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewPengiriman.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    if (listHasilData[i].JenisPengiriman == "SP")
                        jenis = "Shipping Point";
                    else
                        jenis = "Destination Point";
                    string total = listHasilData[i].BiayaKirim.ToString("RP 0,###");
                    dataGridViewPengiriman.Rows.Add(listHasilData[i].KodePengiriman, jenis,
                        total, listHasilData[i].TglKirim.ToString("dddd, dd MMMM yyyy"), listHasilData[i].Nama, listHasilData[i].Keterangan, listHasilData[i].NotaPenjualan.NoNotaPenjualan,
                        listHasilData[i].Ekspedisi.IdEkspedisi, listHasilData[i].Ekspedisi.Nama);
                }
            }
        }
    }
}
