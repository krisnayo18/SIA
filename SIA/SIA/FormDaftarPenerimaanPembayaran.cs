using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIA
{
    public partial class FormDaftarPenerimaanPembayaran : Form
    {
        public FormDaftarPenerimaanPembayaran()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {

        }
        private void FormatDataGrid()
        {
            dataGridViewPelanggan.Columns.Clear();

            dataGridViewPelanggan.Columns.Add("idPenerimaanPembayaran", "Nomor Penerimaan Pembayaran");
            dataGridViewPelanggan.Columns.Add("tgl", "Tanggal");
            dataGridViewPelanggan.Columns.Add("caraPembayaran", "Cara Pembayaran");
            dataGridViewPelanggan.Columns.Add("nominal", "Nominal");

            dataGridViewPelanggan.Columns.Add("idNotaPenjualan", "Nomor Nota Jual");

            dataGridViewPelanggan.Columns["idPenerimaanPembayaran"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelanggan.Columns["tgl"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelanggan.Columns["caraPembayaran"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelanggan.Columns["nominal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewPelanggan.Columns["idNotaPenjualan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
    }
}
