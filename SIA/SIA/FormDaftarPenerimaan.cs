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
    public partial class FormDaftarPenerimaan : Form
    {
        public FormDaftarPenerimaan()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {

        }
        
        private void FormatDataGrid()
        {
            dataGridViewPelanggan.Columns.Clear();

            dataGridViewPelanggan.Columns.Add("idPengiriman", "Nomor Pengiriman");
            dataGridViewPelanggan.Columns.Add("jenisPengiriman", "Jenis Pengiriman");
            dataGridViewPelanggan.Columns.Add("biayaKirim", "Biaya Kirim");
            dataGridViewPelanggan.Columns.Add("tglKirim", "Tanggal Kirim");
            dataGridViewPelanggan.Columns.Add("nama", "Nama");
            dataGridViewPelanggan.Columns.Add("keterangan", "Keterangan");

            dataGridViewPelanggan.Columns.Add("idNotaPembelian", "Nomor Nota Beli");

            dataGridViewPelanggan.Columns["idPengiriman"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelanggan.Columns["jenisPengiriman"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelanggan.Columns["biayaKirim"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelanggan.Columns["tglKirim"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelanggan.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelanggan.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewPelanggan.Columns["idNotaPembelian"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string hasilCari = "";
            if (comboBoxCari.Text == "Nomor Pengiriman")
            {
                hasilCari = "T.idPengiriman";
            }
            else if (comboBoxCari.Text == "Jenis Pengiriman")
            {
                hasilCari = "T.jenisPengiriman";
            }
            else if (comboBoxCari.Text == "Biaya Kirim")
            {
                hasilCari = "T.biayaKirim";
            }
            else if (comboBoxCari.Text == "Tanggal Kirim")
            {
                hasilCari = "T.tglKirim";
            }
            else if (comboBoxCari.Text == "Nama")
            {
                hasilCari = "T.nama";
            }
            else if (comboBoxCari.Text == "Keterangan")
            {
                hasilCari = "T.keterangan";
            }

            else if (comboBoxCari.Text == "Nomor Nota Beli")
            {
                hasilCari = "T.idNotaPembelian";
            }
        }
    }
}
