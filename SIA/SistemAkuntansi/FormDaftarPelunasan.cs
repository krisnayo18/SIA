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
    public partial class FormDaftarPelunasan : Form
    {
        public FormDaftarPelunasan()
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

            dataGridViewPelunasan.Columns.Add("P.noPelunasan", "Nomor Pelunasan");
            dataGridViewPelunasan.Columns.Add("NP.noNotaPenjualan", "Nomor Nota Jual");
            dataGridViewPelunasan.Columns.Add("P.tgl", "Tanggal");
            dataGridViewPelunasan.Columns.Add("P.caraPembayaran", "Cara Pembayaran");
            dataGridViewPelunasan.Columns.Add("P.nominal", "Nominal");
            //dataGridViewPelunasan.Columns.Add("namaPelanggan", "Nama Pelanggan");
           
            //dataGridViewPelunasan.Columns.Add("tglBatasPelunasan", "Tanggal Batas Pelunasan");

            dataGridViewPelunasan.Columns["P.noPelunasan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelunasan.Columns["NP.noNotaPenjualan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelunasan.Columns["P.tgl"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelunasan.Columns["P.caraPembayaran"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPelunasan.Columns["P.nominal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridViewPelunasan.Columns["namaPelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridViewPelunasan.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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

        public void FormDaftarPelunasan_Load(object sender, EventArgs e)
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
                    listHasilData[i].Tanggal, listHasilData[i].CaraPembayaran, listHasilData[i].Nominal );
                   
                }
                
            }
        }
    }
}
