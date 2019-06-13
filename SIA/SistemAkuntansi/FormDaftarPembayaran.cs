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
    public partial class FormDaftarPembayaran : Form
    {
        public FormDaftarPembayaran()
        {
            InitializeComponent();
        }
        List<Pembayaran> listHasilData = new List<Pembayaran>();
        string kriteria = "";
        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPembayaran frmTambah = new FormTambahPembayaran();
            frmTambah.Owner = this;
            frmTambah.ShowDialog();
        }
        public void FormatDataGrid()
        {

            dataGridViewPembayaran.Columns.Clear();

            dataGridViewPembayaran.Columns.Add("IdPembayaran", "ID Pembayaran");
            dataGridViewPembayaran.Columns.Add("NoNotaPembelian", "Nomor Nota Pembelian");
            dataGridViewPembayaran.Columns.Add("tgl", "Tanggal");
            dataGridViewPembayaran.Columns.Add("caraPembayaran", "Cara Pembayaran");
            dataGridViewPembayaran.Columns.Add("nominal", "Nominal");

            dataGridViewPembayaran.Columns["IdPembayaran"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPembayaran.Columns["NoNotaPembelian"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPembayaran.Columns["tgl"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPembayaran.Columns["caraPembayaran"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPembayaran.Columns["nominal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewPembayaran.AllowUserToAddRows = false;
        }
        public void FormDaftarPembayaran_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            FormatDataGrid();

            string hasilBaca = Pembayaran.BacaData("", "", listHasilData);
            if (hasilBaca == "1")
            {
                dataGridViewPembayaran.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    //tampilkan data sesuai urutan di format data grid
                    string harga = listHasilData[i].Nominal.ToString("RP 0,###");
                    dataGridViewPembayaran.Rows.Add(listHasilData[i].IdPembayaran, listHasilData[i].NotaPembelian.NoNotaPembelian,
                    listHasilData[i].Tgl.ToString("dddd, dd MMMM yyyy"), listHasilData[i].CaraPembayaran, harga);

                }

            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
