using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SistemAkuntansi
{
    public partial class FormDaftarNotaJual : Form
    {
        public FormDaftarNotaJual()
        {
            InitializeComponent();
        }

        //List<NotaJual> listHasilData = new List<NotaJual>();
        //string kriteria = "";
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
            //this.Location = new Point(0, 0);
            //comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            //FormatDataGrid();

            //string hasilBaca = NotaJual.BacaData("", "", listHasilData);

            //if (hasilBaca == "1")
            //{
            //    dataGridViewNota.Rows.Clear();

            //    for (int i = 0; i < listHasilData.Count; i++)
            //    {
            //        dataGridViewNota.Rows.Add(listHasilData[i].NoNota, listHasilData[i].Tanggal, listHasilData[i].Pelanggan.KodePelanggan, listHasilData[i].Pelanggan.Nama,listHasilData[i].Pelanggan.Alamat,listHasilData[i].Pegawai.KodePegawai,listHasilData[i].Pegawai.Nama);
            //    }
            //}
        }

        private void FormatDataGrid()
        {
            dataGridViewNota.Columns.Clear();

            dataGridViewNota.Columns.Add("idNotaPenjualan", "No Nota");
            dataGridViewNota.Columns.Add("tglJual", "Tanggal Penjualan");
            dataGridViewNota.Columns.Add("totalHarga", "Total Harga");
            dataGridViewNota.Columns.Add("tglBatasPelunasan", "Batas Pelunasan");
            dataGridViewNota.Columns.Add("tglBatasDiskon", "Batas Diskon");
            dataGridViewNota.Columns.Add("tglBeli", "Tanggal Pembelian");
            dataGridViewNota.Columns.Add("status", "Status");
            dataGridViewNota.Columns.Add("keterangan", "Keterangan");

            dataGridViewNota.Columns.Add("idPelanggan", "No Pelanggan");

            dataGridViewNota.Columns["idNotaPenjualan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["tglJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["totalHarga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["tglBatasPelunasan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["tglBatasDiskon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["tglBeli"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewNota.Columns["idPelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            dataGridViewNota.AllowUserToAddRows = false;
        }

        private void buttonCari_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNotaJual_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void buttoncetak_Click(object sender, EventArgs e)
        {
            
        }
    }
}
