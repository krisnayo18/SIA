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
    public partial class FormDaftarNotaBeli : Form
    {
        public FormDaftarNotaBeli()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FormDaftarNotaBeli_Load(object sender, EventArgs e)
        {
            
             
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahNotaBeli form = new FormTambahNotaBeli();
            form.Owner = this;
            form.ShowDialog();
        }
        private void FormatDataGrid()
        {
            dataGridViewNota.Columns.Clear();

            dataGridViewNota.Columns.Add("idNotaPembelian", "No Nota");
            dataGridViewNota.Columns.Add("diskon", "Diskon");
            dataGridViewNota.Columns.Add("totalHarga", "Total Harga");
            dataGridViewNota.Columns.Add("tglBatasPelunasan", "Batas Pelunasan");
            dataGridViewNota.Columns.Add("tglBatasDiskon", "Batas Diskon");
            dataGridViewNota.Columns.Add("tglBeli", "Tanggal Pembelian");
            dataGridViewNota.Columns.Add("status", "Status");
            dataGridViewNota.Columns.Add("keterangan", "Keterangan");

            dataGridViewNota.Columns.Add("idSupplier", "No Supplier");

            dataGridViewNota.Columns["idNotaPembelian"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["diskon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["totalHarga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["tglBatasPelunasan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["tglBatasDiskon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["tglBeli"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewNota.Columns["idSupplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            dataGridViewNota.AllowUserToAddRows = false;
        }

        private void buttoncetak_Click(object sender, EventArgs e)
        {
            
        }

        private void textBoxNotaBeli_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonCari_Click(object sender, EventArgs e)
        {
            
        }
    } 
}
