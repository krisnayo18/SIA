using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryJurnal;
using ClassLibraryTransaksi;

namespace SistemAkuntansi
{
    public partial class FormTambahPembayaran : Form
    {
        public FormTambahPembayaran()
        {
            InitializeComponent();
        }
        List<Pembayaran> listHasilData = new List<Pembayaran>();
        List<NotaPembelian> listHasilData2 = new List<NotaPembelian>();
        Periode pPeriode = new Periode();
        private void buttonSimpan_Click(object sender, EventArgs e)
        {

        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxNoNotaBeli_SelectedIndexChanged(object sender, EventArgs e)
        {
            listHasilData.Clear();
            string hasilBaca = Pembayaran.BacaDataPembayaran("noNotaPenjualan", comboBoxNoNotaBeli.Text, listHasilData2);

            if (hasilBaca == "1")
            {
                textBoxNominal.Clear();
                if (listHasilData2.Count > 0)
                {
                    textBoxNominal.Text = listHasilData2[0].TotalHarga.ToString();
                }
            }
            else
            {
                textBoxNominal.Clear();
            }
        }

        private void FormTambahPembayaran_Load(object sender, EventArgs e)
        {
            string noNotaBaru;
            pPeriode = Periode.GetPeriodeTerbaru();
            comboBoxNoNotaBeli.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCaraPemb.DropDownStyle = ComboBoxStyle.DropDownList;
            string hasilGenerate = Pembayaran.GenerateNoNota(out noNotaBaru);
            textBoxNoPembayaran.Clear();
            if (hasilGenerate == "1")
            {
                textBoxNoPembayaran.Text = noNotaBaru;

            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            }

            dateTimePickerTgl.Value = DateTime.Now;
            dateTimePickerTgl.Enabled = false;

            string hasilBaca = Pembayaran.BacaDataPembayaran("", "", listHasilData2);

            if (hasilBaca == "1")
            {
                comboBoxNoNotaBeli.Items.Clear();
                for (int i = 0; i < listHasilData2.Count; i++)
                {
                    comboBoxNoNotaBeli.Items.Add(listHasilData2[i].NoNotaPembelian);
                }
            }
            else
            {
                comboBoxNoNotaBeli.Items.Clear();
            }
        }
    }
}
