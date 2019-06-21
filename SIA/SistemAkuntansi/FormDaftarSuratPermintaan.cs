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
    public partial class FormDaftarSuratPermintaan : Form
    {
        
        public FormDaftarSuratPermintaan()
        {
            InitializeComponent();
        }
        List<SuratPermintaan> listHasilPermintaan = new List<SuratPermintaan>();
        private void FormatDataGrid()
        {
            dataGridViewSurat.Columns.Clear();

            dataGridViewSurat.Columns.Add("noSuratPermintaan", "No Surat Permintaan");
            dataGridViewSurat.Columns.Add("tanggal", "Tanggal");
            dataGridViewSurat.Columns.Add("keterangan", "Keterangan");
            dataGridViewSurat.Columns.Add("kodeJobOrder", "Kode Job Order");
            dataGridViewSurat.Columns.Add("status", "Status Job Order");

            dataGridViewSurat.Columns["noSuratPermintaan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewSurat.Columns["tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewSurat.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewSurat.Columns["kodeJobOrder"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewSurat.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewSurat.AllowUserToAddRows = false;
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
           FormTambahSuratPermintaan frm = new FormTambahSuratPermintaan();
            frm.Owner = this;
            frm.ShowDialog();
        }
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FormDaftarSuratPermintaan_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            FormatDataGrid();

            string hasilBaca = SuratPermintaan.BacaData("", "", listHasilPermintaan);

            if (hasilBaca == "1")
            {
                dataGridViewSurat.Rows.Clear();

                for (int i = 0; i < listHasilPermintaan.Count; i++)
                {
                    dataGridViewSurat.Rows.Add(listHasilPermintaan[i].NoSuratPermintaan, listHasilPermintaan[i].Tanggal.ToString("dddd, dd MMMM yyyy"),
                        listHasilPermintaan[i].Keterangan,listHasilPermintaan[i].JobOrder.KodeJobOrder, listHasilPermintaan[i].JobOrder.Status
                        );
                }
            }
        }
    }
}
