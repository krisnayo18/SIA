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
    public partial class FormTambahNotaJual : Form
    {
        public FormTambahNotaJual()
        {
            InitializeComponent();
        }

        List<Pelanggan> listHasilData = new List<Pelanggan>();
        List<Barang> listHasilBarang = new List<Barang>();

        private void FormatDataGrid()
        {
            dataGridViewNota.Columns.Clear();

            dataGridViewNota.Columns.Add("KodeBarang", "Kode Barang");
            dataGridViewNota.Columns.Add("NamaBarang", "Nama Barang");
            dataGridViewNota.Columns.Add("HargaJual", "Harga Jual");
            dataGridViewNota.Columns.Add("Jumlah", "Jumlah");
            dataGridViewNota.Columns.Add("SubTotal", "Sub Total");

            dataGridViewNota.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewNota.Columns["Jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewNota.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewNota.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewNota.Columns["HargaJual"].DefaultCellStyle.Format = "0,###";
            dataGridViewNota.Columns["SubTotal"].DefaultCellStyle.Format = "0,###";

            dataGridViewNota.AllowUserToAddRows = false;
        }

        private void FormTambahNotaJual_Load(object sender, EventArgs e)
        {
            this.Location = new Point(881, 26);
            FormatDataGrid();

            textBoxBarcode.MaxLength = 13;
            textBoxNo.Enabled = false;
            
            textBoxAlamat.Enabled = false;

            comboBoxPelanggan.DropDownStyle = ComboBoxStyle.DropDownList;


            string noNotaBaru;
            string hasilGenerate = NotaJual.GenerateNoNota(out noNotaBaru);
            textBoxNo.Clear();
            if (hasilGenerate == "1")
            {
                textBoxNo.Text = noNotaBaru;
                textBoxBarcode.Focus();
            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            }

            dateTimePickerTanggal.Value = DateTime.Now;
            dateTimePickerTanggal.Enabled = false;

            string hasilBaca = Pelanggan.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                comboBoxPelanggan.Items.Clear();
                for (int i = 0; i < listHasilData.Count; i++)
                {
                    comboBoxPelanggan.Items.Add(listHasilData[i].KodePelanggan + " - " + listHasilData[i].Nama);
                }
            }
            else
            {
                comboBoxPelanggan.Items.Clear();
            }

            FormUtama form = (FormUtama)this.Owner.MdiParent;
            labelKodePgw.Text = form.labelKodePgw.Text;
            labelNamaPgw.Text = form.labelNamaPgw.Text;
        }

        private void textBoxBarcode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBarcode.Text.Length == textBoxBarcode.MaxLength)
            {
                string hasilBaca = Barang.BacaData("barcode", textBoxBarcode.Text, listHasilBarang);

                if (hasilBaca == "1")
                {
                    if (listHasilBarang.Count > 0)
                    {

                        labelNama.Text = listHasilBarang[0].Nama;
                        labelKode.Text = listHasilBarang[0].KodeBarang;
                        labelHarga.Text = listHasilBarang[0].HargaJual.ToString();
                        textBoxJumlah.Focus();
                        textBoxJumlah.Text = "1";
                    }
                    else
                    {
                        MessageBox.Show("Baranf tidak ditemukan.");
                        textBoxBarcode.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankan. Pesan kesalahan: " + hasilBaca);
                }
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxJumlah_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int subTotal = int.Parse(labelHarga.Text) * int.Parse(textBoxJumlah.Text);

                dataGridViewNota.Rows.Add(labelKode.Text, labelNama.Text, labelHarga.Text, textBoxJumlah.Text, subTotal);
                labelTotalHarga.Text = HitungGrandTotal().ToString("0,###");


                textBoxBarcode.Clear();
                labelKode.Text = "";
                labelNama.Text = "";
                labelHarga.Text = "";
                textBoxJumlah.Clear();
            }
        }

        private int HitungGrandTotal()
        {
            int grandTotal = 0;
            for (int i=0; i<dataGridViewNota.Rows.Count; i++)
            {
                int subTotal = int.Parse(dataGridViewNota.Rows[i].Cells["SubTotal"].Value.ToString());
                grandTotal = grandTotal + subTotal;
            }
            return grandTotal;
        }

        private void comboBoxPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            listHasilData.Clear();
            string hasilBaca = Pelanggan.BacaData("KodePelanggan", comboBoxPelanggan.Text.Substring(0, 1), listHasilData);
            
            if (hasilBaca == "1")
            {
                textBoxAlamat.Clear();
                if (listHasilData.Count > 0)
                {
                    textBoxAlamat.Text = listHasilData[0].Alamat;
                }
            }
            else
            {
                textBoxAlamat.Clear();
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            FormDaftarNotaJual form = (FormDaftarNotaJual)this.Owner;
            Pelanggan pelanggan = new Pelanggan();

            pelanggan.KodePelanggan = int.Parse(comboBoxPelanggan.Text.Substring(0, 1));
            pelanggan.Nama = comboBoxPelanggan.Text.Substring(4, comboBoxPelanggan.Text.Length - 4);
            pelanggan.Alamat = textBoxAlamat.Text;

            Pegawai pgw = new Pegawai();
            pgw.KodePegawai = int.Parse(labelKodePgw.Text);
            pgw.Nama = labelNamaPgw.Text;

            NotaJual nota = new NotaJual(textBoxNo.Text, dateTimePickerTanggal.Value, pelanggan, pgw);

            for(int i = 0; i< dataGridViewNota.Rows.Count; i++)
            {
                Barang barang = new Barang();
                barang.KodeBarang = dataGridViewNota.Rows[i].Cells["KodeBarang"].Value.ToString();
                barang.Nama = dataGridViewNota.Rows[i].Cells["NamaBarang"].Value.ToString();
                int harga = int.Parse(dataGridViewNota.Rows[i].Cells["HargaJual"].Value.ToString());
                int jumlah = int.Parse(dataGridViewNota.Rows[i].Cells["Jumlah"].Value.ToString());

                NotaJualDetil notaDetil = new NotaJualDetil(barang, harga, jumlah);
                nota.TambahDetilBarang(barang, harga, jumlah);
            }

            string hasilTambah = NotaJual.TambahData(nota);
            if(hasilTambah == "1")
            {
                MessageBox.Show("Data nota jual telah tersimpan", "Info");
                form.FormDaftarNotaJual_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Data nota jual gagal tersimpan. Pesan kesalahan : " + hasilTambah, "Kesalahan");
            }
        }

        private void buttonCetakNota_Click(object sender, EventArgs e)
        {
            string hasilCetak = NotaJual.CetakNota("N.NoNota", textBoxNo.Text, "Nota_Jual_Tambah.txt");
            if (hasilCetak == "1") MessageBox.Show("Nota telah tercetak");
            else MessageBox.Show("Nota jual gagal dicetak. Pesan kesalahan : " + hasilCetak);   
        }
    }
}
