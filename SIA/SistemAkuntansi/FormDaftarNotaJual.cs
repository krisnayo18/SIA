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
    public partial class FormDaftarNotaJual : Form
    {
        public FormDaftarNotaJual()
        {
            InitializeComponent();
        }

        List<NotaPenjualan> listHasilData = new List<NotaPenjualan>();
        string kriteria = "";
       
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahNotaJual frmTambah = new FormTambahNotaJual();
            frmTambah.Owner = this;
            frmTambah.ShowDialog();
        }

        public void FormDaftarNotaJual_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            FormatDataGrid();

            string hasilBaca = NotaPenjualan.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewNota.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    string total = listHasilData[i].TotalHarga.ToString("RP 0,###");
                    dataGridViewNota.Rows.Add(listHasilData[i].NoNotaPenjualan, listHasilData[i].Pelanggan.IdPelanggan, 
                        listHasilData[i].Pelanggan.Nama, listHasilData[i].Pelanggan.Alamat, listHasilData[i].Diskon,
                        total, listHasilData[i].TglBatasPelunasan.ToString("dddd, dd MMMM yyyy"), 
                        listHasilData[i].TglBatasDiskon.ToString("dddd, dd MMMM yyyy"), 
                        listHasilData[i].TglJual.ToString("dddd, dd MMMM yyyy"), listHasilData[i].Status, listHasilData[i].Keterangan);
                }
            }
        }

        private void FormatDataGrid()
        {
            dataGridViewNota.Columns.Clear();

            dataGridViewNota.Columns.Add("noNotaPenjualan", "No Nota");
            dataGridViewNota.Columns.Add("idPelanggan", "No Pelanggan");
            dataGridViewNota.Columns.Add("NamaPelanggan", "Nama Pelanggan");
            dataGridViewNota.Columns.Add("AlamatPelanggan", "Alamat Pelanggan");
            dataGridViewNota.Columns.Add("diskon", "Diskon");
            dataGridViewNota.Columns.Add("totalHarga", "Total Harga");
            dataGridViewNota.Columns.Add("tglBatasPelunasan", "Batas Pelunasan");
            dataGridViewNota.Columns.Add("tglBatasDiskon", "Batas Diskon");
            dataGridViewNota.Columns.Add("tglJual", "Tanggal Penjualan");
            dataGridViewNota.Columns.Add("status", "Status");
            dataGridViewNota.Columns.Add("keterangan", "Keterangan");

            

            dataGridViewNota.Columns["noNotaPenjualan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["idPelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["NamaPelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["AlamatPelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["diskon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["totalHarga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["tglBatasPelunasan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["tglBatasDiskon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["tglJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //dataGridViewNota.Columns["totalHarga"].DefaultCellStyle.Format = "0,###";
             

            dataGridViewNota.AllowUserToAddRows = false;
        }

        private void buttonCari_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNotaJual_TextChanged(object sender, EventArgs e)
        {
            string nilaiKriteria = textBoxCari.Text;
            if (comboBoxCari.Text == "No Nota") kriteria = "N.NoNotaPenjualan";
            else if (comboBoxCari.Text == "No Pelanggan") kriteria = "N.idPelanggan";
            else if (comboBoxCari.Text == "Nama Pelanggan") kriteria = "P.nama";
            else if (comboBoxCari.Text == "Alamat Pelanggan") kriteria = "P.alamat";
            else if (comboBoxCari.Text == "Diskon") kriteria = "N.diskon";
            else if (comboBoxCari.Text == "Total Harga") kriteria = "N.totalHarga";
            else if (comboBoxCari.Text == "Batas Pelunasan") kriteria = "N.tglBatasPelunasan";
            else if (comboBoxCari.Text == "Batas Diskon") kriteria = "N.tglBatasDiskon";
            else if (comboBoxCari.Text == "Tanggal Penjualan") kriteria = "N.tglJual";
            else if (comboBoxCari.Text == "Status") kriteria = "N.status";
            else if (comboBoxCari.Text == "Keterangan") kriteria = "N.keterangan";


            string hasilBaca = NotaPenjualan.BacaData(kriteria, nilaiKriteria, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewNota.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    dataGridViewNota.Rows.Add(listHasilData[i].NoNotaPenjualan, listHasilData[i].Pelanggan.IdPelanggan, 
                        listHasilData[i].Pelanggan.Nama, listHasilData[i].Pelanggan.Alamat, listHasilData[i].Diskon, 
                        listHasilData[i].TotalHarga, listHasilData[i].TglBatasPelunasan, listHasilData[i].TglBatasDiskon,
                        listHasilData[i].TglJual, listHasilData[i].Status, listHasilData[i].Keterangan);
                }
            }
        }

        private void buttoncetak_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBoxCari_TextChanged(object sender, EventArgs e)
        {
            string nilaiKriteria = textBoxCari.Text;
            if (comboBoxCari.Text == "No Nota") kriteria = "N.NoNotaPenjualan";
            else if (comboBoxCari.Text == "No Pelanggan") kriteria = "N.idPelanggan";
            else if (comboBoxCari.Text == "Nama Pelanggan") kriteria = "P.nama";
            else if (comboBoxCari.Text == "Alamat Pelanggan") kriteria = "P.alamat";
            else if (comboBoxCari.Text == "Diskon") kriteria = "N.diskon";
            else if (comboBoxCari.Text == "Total Harga") kriteria = "N.totalHarga";
            else if (comboBoxCari.Text == "Batas Pelunasan") kriteria = "N.tglBatasPelunasan";
            else if (comboBoxCari.Text == "Batas Diskon") kriteria = "N.tglBatasDiskon";
            else if (comboBoxCari.Text == "Tanggal Penjualan") kriteria = "N.tglJual";
            else if (comboBoxCari.Text == "Status") kriteria = "N.status";
            else if (comboBoxCari.Text == "Keterangan") kriteria = "N.keterangan";


            string hasilBaca = NotaPenjualan.BacaData(kriteria, nilaiKriteria, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewNota.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    dataGridViewNota.Rows.Add(listHasilData[i].NoNotaPenjualan, listHasilData[i].Pelanggan.IdPelanggan,
                        listHasilData[i].Pelanggan.Nama, listHasilData[i].Pelanggan.Alamat, listHasilData[i].Diskon,
                        listHasilData[i].TotalHarga, listHasilData[i].TglBatasPelunasan, listHasilData[i].TglBatasDiskon,
                        listHasilData[i].TglJual, listHasilData[i].Status, listHasilData[i].Keterangan);
                }
            }
        }
    }
}
