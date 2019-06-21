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
    public partial class FormTambahPenerimaan : Form
    {
        public FormTambahPenerimaan()
        {
            InitializeComponent();
        }
        List<NotaPembelian> listHasilNota = new List<NotaPembelian>();
        List<Penerimaan> listHasilData = new List<Penerimaan>();
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {

        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            FormUtama frmUtama = (FormUtama)this.Owner.MdiParent;
            FormDaftarPenerimaan form = (FormDaftarPenerimaan)this.Owner;

            NotaPembelian nota = new NotaPembelian();
            nota.NoNotaPembelian = comboBoxNoNotaBeli.Text;

            string kode = textBoxIdPengiriman.Text;
            string jenis = "";
            if (comboBoxJenisPengiriman.Text == "Shipping Point")
                jenis = "SP";
            else
                jenis = "DP";
            int biaya = int.Parse(textBoxBiaya.Text);
            string nama = textBoxNama.Text;
            DateTime tgl = dateTimePickerTerima.Value;
            string ket = textBoxKeterangan.Text;
            Penerimaan peng = new Penerimaan(kode, jenis, nama, ket,biaya, tgl, nota);

            string hasilTambah = Penerimaan.TambahData(peng);

            if (hasilTambah == "1")
            {
                MessageBox.Show("Berhasil Menambahkan Penerimaan");
                this.Close();
                form.FormDaftarPenerimaan_Load(sender, e);
            }
            else
            {
                MessageBox.Show("pengiriman gagal tersimpan. Pesan kesalahan : " + hasilTambah, "Kesalahan");
            }
        }

        private void FormTambahPenerimaan_Load(object sender, EventArgs e)
        {
            comboBoxJenisPengiriman.Items.AddRange(new string[] { "Shipping Point", "Destination Point" });
            string noNotaBaru;
            textBoxIdPengiriman.Enabled = false;
            dateTimePickerTerima.Enabled = false;
            dateTimePickerTerima.Value = DateTime.Now;
            comboBoxNoNotaBeli.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxJenisPengiriman.DropDownStyle = ComboBoxStyle.DropDownList;

            string hasilGenerate = Penerimaan.GenerateNoNota(out noNotaBaru);
            textBoxIdPengiriman.Clear();
            if (hasilGenerate == "1")
            {
                textBoxIdPengiriman.Text = noNotaBaru;

            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            }

            string hasilBaca = NotaPembelian.BacaData("", "", listHasilNota);

            if (hasilBaca == "1")
            {
                comboBoxNoNotaBeli.Items.Clear();
                for (int i = 0; i < listHasilNota.Count; i++)
                {
                    comboBoxNoNotaBeli.Items.Add(listHasilNota[i].NoNotaPembelian);
                }
            }
            else
            {
                comboBoxNoNotaBeli.Items.Clear();
            }

            if(comboBoxNoNotaBeli.Items.Count != 0)
                comboBoxNoNotaBeli.SelectedIndex = 0;
            comboBoxJenisPengiriman.SelectedIndex = 0;

            FormUtama form = (FormUtama)this.Owner.MdiParent;
            labelKodePgw.Text = form.labelKodePgw.Text;
            labelNamaPgw.Text = form.labelNamaPgw.Text;
        }
    }
}
