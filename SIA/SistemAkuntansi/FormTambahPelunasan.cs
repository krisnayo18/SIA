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
    public partial class FormTambahPenerimaanPembayaran : Form
    {
        public FormTambahPenerimaanPembayaran()
        {
            InitializeComponent();
        }
        List<Pelunasan> listHasilData = new List<Pelunasan>();

        private void FormatDataGrid()
        {
            dataGridViewNota.Columns.Clear();

            dataGridViewNota.Columns.Add("noNotaPenjualan", "No Nota Penjualan");
            dataGridViewNota.Columns.Add("tanggal", "Tanggal");
            dataGridViewNota.Columns.Add("caraPembayaran", "Cara Pembayaran");
            dataGridViewNota.Columns.Add("nominal", "nominal");

            dataGridViewNota.Columns["noNotaPenjualan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["caraPembayaran"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["nominal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewNota.Columns["nominal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewNota.Columns["nominal"].DefaultCellStyle.Format = "0,###";

            dataGridViewNota.AllowUserToAddRows = false;
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
           
        }

        private void FormTambahPenerimaanPembayaran_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            string noNotaBaru;
            comboBoxNoNotaJual.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCaraPemb.DropDownStyle = ComboBoxStyle.DropDownList;
            string hasilGenerate = Pelunasan.GenerateNoNota(out noNotaBaru);
            textBoxNoPelunasan.Clear();
            if (hasilGenerate == "1")
            {
                textBoxNoPelunasan.Text = noNotaBaru;
              
            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            }

            dateTimePickerTgl.Value = DateTime.Now;
            dateTimePickerTgl.Enabled = false;

            string hasilBaca = Pelunasan.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                comboBoxNoNotaJual.Items.Clear();
                for (int i = 0; i < listHasilData.Count; i++)
                {
                        comboBoxNoNotaJual.Items.Add(listHasilData[i].NotaPenjualan.NoNotaPenjualan);
                }
            }
            else
            {
                comboBoxNoNotaJual.Items.Clear();
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxNoNotaJual_SelectedIndexChanged(object sender, EventArgs e)
        {
            listHasilData.Clear();
            string hasilBaca = Pelunasan.BacaData("NP.noNotaPenjualan", comboBoxNoNotaJual.Text, listHasilData);

            if (hasilBaca == "1")
            {
                textBoxNominal.Clear();
                if (listHasilData.Count > 0)
                {
                    textBoxNominal.Text = listHasilData[0].NotaPenjualan.TotalHarga.ToString();
                }
            }
            else
            {
                textBoxNominal.Clear();
            }
        }
    }
}
