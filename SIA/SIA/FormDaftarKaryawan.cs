using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClassJualBeli;

namespace Indomart
{
    public partial class FormDaftarPegawai : Form
    {
        public FormDaftarPegawai()
        {
            InitializeComponent();
        }

        List<Pegawai> listHasilData = new List<Pegawai>();

        private void FormatDataGrid()
        {
            dataGridViewPegawai.Columns.Clear();

            dataGridViewPegawai.Columns.Add("KodePegawai", "Kode Pegawai");
            dataGridViewPegawai.Columns.Add("NamaPegawai", "Nama Pegawai");
            dataGridViewPegawai.Columns.Add("TglLahir", "Tgl Lahir");
            dataGridViewPegawai.Columns.Add("Alamat", "Alamat");
            dataGridViewPegawai.Columns.Add("Gaji", "Gaji");
            dataGridViewPegawai.Columns.Add("Username", "Username");
            dataGridViewPegawai.Columns.Add("NamaJabatan", "Jabatan");

            dataGridViewPegawai.Columns["KodePegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["NamaPegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["TglLahir"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["Alamat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["Gaji"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["NamaJabatan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewPegawai.Columns["TglLahir"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewPegawai.Columns["Gaji"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dataGridViewPegawai.Columns["Gaji"].DefaultCellStyle.Format = "0,###";
        }
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPegawai frmTmbhPegawai = new FormTambahPegawai();
            frmTmbhPegawai.Owner = this;
            frmTmbhPegawai.ShowDialog();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahPegawai frmUbhPegawai = new FormUbahPegawai();
            frmUbhPegawai.Owner = this;
            frmUbhPegawai.ShowDialog();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusPegawai frmHpsPegawai = new FormHapusPegawai();
            frmHpsPegawai.Owner = this;
            frmHpsPegawai.ShowDialog();
        }

        public void FormDaftarPegawai_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            FormatDataGrid();

            string hasilBaca = Pegawai.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewPegawai.Rows.Clear();

                for (int i=0; i<listHasilData.Count; i++)
                {
                    dataGridViewPegawai.Rows.Add(listHasilData[i].KodePegawai, listHasilData[i].Nama, listHasilData[i].TglLahir, listHasilData[i].Alamat, listHasilData[i].Gaji, listHasilData[i].Username, listHasilData[i].Jabatan.NamaJabatan);
                }
            }
        }

        private void textBoxPegawai_TextChanged(object sender, EventArgs e)
        {
            string hasilCari = "";
            if (comboBoxPegawai.Text == "Kode Pegawai")
            {
                hasilCari = "P.KodePegawai";
            }
            else if (comboBoxPegawai.Text == "Nama")
            {
                hasilCari = "P.Nama";
            }
            else if (comboBoxPegawai.Text == "Tanggal Lahir")
            {
                hasilCari = "P.TglLahir";
            }
            else if (comboBoxPegawai.Text == "Alamat")
            {
                hasilCari = "P.Alamat";
            }
            else if (comboBoxPegawai.Text == "Gaji")
            {
                hasilCari = "P.Gaji";
            }
            else if (comboBoxPegawai.Text == "Username")
            {
                hasilCari = "P.Username";
            }
            else if (comboBoxPegawai.Text == "Jabatan")
            {
                hasilCari = "J.Nama";
            }

            string hasilBaca = Pegawai.BacaData(hasilCari, textBoxPegawai.Text, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewPegawai.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    dataGridViewPegawai.Rows.Add(listHasilData[i].KodePegawai, listHasilData[i].Nama, listHasilData[i].TglLahir, listHasilData[i].Alamat, listHasilData[i].Gaji, listHasilData[i].Username, listHasilData[i].Jabatan.NamaJabatan);
                }
            }
            else
            {
                dataGridViewPegawai.Rows.Clear();
            }
        }
    }
}
