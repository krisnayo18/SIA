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

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPembayaran frmTambah = new FormTambahPembayaran();
            frmTambah.Owner = this;
            frmTambah.ShowDialog();
        }

        private void FormDaftarPembayaran_Load(object sender, EventArgs e)
        {

        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
