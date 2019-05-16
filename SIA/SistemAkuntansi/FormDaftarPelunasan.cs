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
    public partial class FormDaftarPenerimaanPembayaran : Form
    {
        public FormDaftarPenerimaanPembayaran()
        {
            InitializeComponent();
        }
        List<Pelunasan> listHasilData = new List<Pelunasan>();
        string kriteria = "";
        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPenerimaanPembayaran frmTambah = new FormTambahPenerimaanPembayaran();
            frmTambah.Owner = this;
            frmTambah.ShowDialog();
        }
        private void FormatDataGrid()
        {
            dataGridViewPelunasan.Columns.Clear();

            dataGridViewPelunasan.Columns.Add("noPelunasan", "Nomor Pelunasan");
            dataGridViewPelunasan.Columns.Add("noNotaPenjualan", "Nomor Nota Jual");
            dataGridViewPelunasan.Columns.Add("tgl", "Tanggal");
            dataGridViewPelunasan.Columns.Add("caraPembayaran", "Cara Pembayaran");
            dataGridViewPelunasan.Columns.Add("nominal", "Nominal");
            //dataGridViewPelunasan.Columns.Add("namaPelanggan", "Nama Pelanggan");
            dataGridViewPelunasan.Columns.Add("status", "Status");
            //dataGridViewPelunasan.Columns.Add("tglBatasPelunasan", "Tanggal Batas Pelunasan");

            dataGridViewPelunasan.Columns["noPelunasan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelunasan.Columns["noNotaPenjualan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelunasan.Columns["tgl"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelunasan.Columns["caraPembayaran"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelunasan.Columns["nominal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridViewPelunasan.Columns["namaPelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelunasan.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridViewPelunasan.Columns["tglBatasPelunasan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


        }
        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string hasilCari = "";
            if (comboBoxCari.Text == "Nomor Penerimaan Pembayaran")
            {
                hasilCari = "T.idPenerimaanPembayaran";
            }
            else if (comboBoxCari.Text == "Tanggal")
            {
                hasilCari = "T.tgl";
            }
            else if (comboBoxCari.Text == "Cara Pembayaran")
            {
                hasilCari = "T.caraPembayaran";
            }
            else if (comboBoxCari.Text == "Nominal")
            {
                hasilCari = "T.nominal";
            }
            else if (comboBoxCari.Text == "Nomor Nota Jual")
            {
                hasilCari = "T.idNotaPenjualan";

            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDaftarPenerimaanPembayaran_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            FormatDataGrid();

            string hasilBaca = Pelunasan.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewPelunasan.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    //tampilkan data sesuai urutan di format data grid
                    dataGridViewPelunasan.Rows.Add(listHasilData[i].NoPelunasan, listHasilData[i].NotaPenjualan.NoNotaPenjualan,
                    listHasilData[i].Tanggal, listHasilData[i].CaraPembayaran, listHasilData[i].Nominal, 
                    listHasilData[i].NotaPenjualan.Status
                    //listHasilData[i].NotaPenjualan.Pelanggan.Nama, 
                    //listHasilData[i].NotaPenjualan.TglBatasPelunasan
                    );
                }
            }
        }
    }
}
