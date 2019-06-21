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
    public partial class FormDaftarPenerimaan : Form
    {
        public FormDaftarPenerimaan()
        {
            InitializeComponent();
        }
        List<Penerimaan> listHasilData = new List<Penerimaan>();
        string kriteria = "";
        string jenis = "";
        public void FormatDataGrid()
        {

            dataGridViewPenerimaan.Columns.Clear();

            dataGridViewPenerimaan.Columns.Add("kodePenerimaan", "Kode Penerimaan");
            dataGridViewPenerimaan.Columns.Add("jenisPengiriman", "Jenis Pengiriman");
            dataGridViewPenerimaan.Columns.Add("biayaKirim", "Biaya Kirim");
            dataGridViewPenerimaan.Columns.Add("tglTerima", "Tanggal Terima");
            dataGridViewPenerimaan.Columns.Add("nama", "Nama");
            dataGridViewPenerimaan.Columns.Add("keterangan", "Keterangan");
            dataGridViewPenerimaan.Columns.Add("NoNotaPembelian", "Nomor Nota Pembelian");
            
            
            dataGridViewPenerimaan.Columns["kodePenerimaan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPenerimaan.Columns["jenisPengiriman"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPenerimaan.Columns["tglTerima"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPenerimaan.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPenerimaan.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPenerimaan.Columns["biayaKirim"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPenerimaan.Columns["noNotaPembelian"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewPenerimaan.AllowUserToAddRows = false;
        }
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPenerimaan frm = new FormTambahPenerimaan();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void buttonCari_Click(object sender, EventArgs e)
        {

            string nilaiKriteria = textBoxCari.Text;
            if (comboBoxCari.Text == "Kode Penerimaan") kriteria = "kodePenerimaan";
            else if (comboBoxCari.Text == "Jenis Penerimaan") kriteria = "jenisPenerimaan";
            else if (comboBoxCari.Text == "Biaya Kirim") kriteria = "biayaKirim";
            else if (comboBoxCari.Text == "Tanggal Terima") kriteria = "tglTerima";
            else if (comboBoxCari.Text == "Nama") kriteria = "nama";
            else if (comboBoxCari.Text == "Keterangan") kriteria = "keterangan";
            else if (comboBoxCari.Text == "Nomor Nota Pembelian") kriteria = "noNotaPembelian";

            string hasilBaca = Penerimaan.BacaData(kriteria, nilaiKriteria, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewPenerimaan.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    if (listHasilData[i].JenisPengiriman == "SP")
                        jenis = "Shipping Point";
                    else
                        jenis = "Destination Point";
                    string total = listHasilData[i].BiayaKirim.ToString("RP 0,###");
                    dataGridViewPenerimaan.Rows.Add(listHasilData[i].KodePenerimaan, jenis,
                    total, listHasilData[i].TglTerima.ToString("dddd, dd MMMM yyyy"), listHasilData[i].Nama, listHasilData[i].Keterangan, 
                    listHasilData[i].NotaPembelian.NoNotaPembelian);
                }
            }
        }

        public void FormDaftarPenerimaan_Load(object sender, EventArgs e)
        {
            comboBoxCari.Items.AddRange(new string[] { "Kode Penerimaan","Jenis Penerimaan","Biaya Kirim","Tanggal Terima","Nama","Keterangan","Nomor Nota Pembelian" });

            this.Location = new Point(0, 0);
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            FormatDataGrid();

            string hasilBaca = Penerimaan.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewPenerimaan.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    if (listHasilData[i].JenisPengiriman == "SP")
                        jenis = "Shipping Point";
                    else
                        jenis = "Destination Point";
                    string total = listHasilData[i].BiayaKirim.ToString("RP 0,###");
                    dataGridViewPenerimaan.Rows.Add(listHasilData[i].KodePenerimaan, jenis,
                    total, listHasilData[i].TglTerima.ToString("dddd, dd MMMM yyyy"), listHasilData[i].Nama, listHasilData[i].Keterangan,
                    listHasilData[i].NotaPembelian.NoNotaPembelian);
                }
            }
        }

        private void comboBoxCari_TextChanged(object sender, EventArgs e)
        {
            textBoxCari.Clear();
            string hasilBaca = Penerimaan.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewPenerimaan.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    if (listHasilData[i].JenisPengiriman == "SP")
                        jenis = "Shipping Point";
                    else
                        jenis = "Destination Point";
                    string total = listHasilData[i].BiayaKirim.ToString("RP 0,###");
                    dataGridViewPenerimaan.Rows.Add(listHasilData[i].KodePenerimaan, jenis,
                    total, listHasilData[i].TglTerima.ToString("dddd, dd MMMM yyyy"), listHasilData[i].Nama, listHasilData[i].Keterangan,
                    listHasilData[i].NotaPembelian.NoNotaPembelian);
                }
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCari.Text == "")
            {
                string hasilBaca = Penerimaan.BacaData("", "", listHasilData);

                if (hasilBaca == "1")
                {
                    dataGridViewPenerimaan.Rows.Clear();

                    for (int i = 0; i < listHasilData.Count; i++)
                    {
                        if (listHasilData[i].JenisPengiriman == "SP")
                            jenis = "Shipping Point";
                        else
                            jenis = "Destination Point";
                        string total = listHasilData[i].BiayaKirim.ToString("RP 0,###");
                        dataGridViewPenerimaan.Rows.Add(listHasilData[i].KodePenerimaan, jenis,
                        total, listHasilData[i].TglTerima.ToString("dddd, dd MMMM yyyy"), listHasilData[i].Nama, listHasilData[i].Keterangan,
                        listHasilData[i].NotaPembelian.NoNotaPembelian);
                    }
                }
            }
        }
    }
}
