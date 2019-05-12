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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        List<Karyawan> listHasilData = new List<Karyawan>();

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.Height = 150 + panelLogin.Height;

            textBoxUsername.Text = "root";
            textBoxPassword.Text = "";
            textBoxDatabase.Text = "akuntansi";
            textBoxServer.Text = "localhost";
        }

        private void labelPengaturanLanjut_Click(object sender, EventArgs e)
        {
            this.Height = 170 + panelLogin.Height + panelServer.Height;
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (textBoxServer.Text != "" && textBoxDatabase.Text != "")
            {
                this.Height = 150 + panelLogin.Height;
            }
            else
            {
                MessageBox.Show("NAMA SERVER DAN DATABASE TIDAK BOLEH DIKOSONGI!", "KESALAHAN");
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text != "")
            {

                //ciptakan object bertipe koneksi  dengan memanggil constructor  berparameter  milik  class koneksi
                ClassLibraryJurnal.Koneksi k = new ClassLibraryJurnal.Koneksi(textBoxServer.Text, textBoxDatabase.Text, textBoxUsername.Text, textBoxPassword.Text);


                string hasilCon = k.Connect();

                if (hasilCon == "1")
                {
                    FormUtama frmUtama = (FormUtama)this.Owner;
                    frmUtama.Enabled = true;
                    MessageBox.Show("Selamat datang di sistem akuntansi", "Info");
                    

                    string hasilCariKaryawan = Karyawan.BacaData("nama", textBoxUsername.Text, listHasilData);
                    if (hasilCariKaryawan == "1")
                    {
                        
                        if (listHasilData.Count > 0)
                        {
                            frmUtama.labelKodePgw.Text = "   " + listHasilData[0].IdKaryawan;
                            frmUtama.labelNamaPgw.Text = listHasilData[0].Nama;
                            frmUtama.labelJabatan.Text = "Admin";
                        }
                        this.Close();
                    }
                }
                else
                  {
                    MessageBox.Show("koneksi gagal, pesan kesalahan: " + hasilCon, "Kesalahan");
                  }
            }
            else
            {
                MessageBox.Show("Usename tidak boleh dikosongi!", "Kesalahan");
            }
        }
    }
}
