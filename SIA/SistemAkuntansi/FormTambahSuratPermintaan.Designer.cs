namespace SistemAkuntansi
{
    partial class FormTambahSuratPermintaan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePickerMulai = new System.Windows.Forms.DateTimePicker();
            this.textBoxDirectMaterial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxNoNotaJual = new System.Windows.Forms.ComboBox();
            this.textBoxKodeJobOrder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.dateTimePickerMulai);
            this.panel1.Controls.Add(this.textBoxDirectMaterial);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxNoNotaJual);
            this.panel1.Controls.Add(this.textBoxKodeJobOrder);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(12, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 218);
            this.panel1.TabIndex = 46;
            // 
            // dateTimePickerMulai
            // 
            this.dateTimePickerMulai.CustomFormat = "dddd dd MMM yyyy";
            this.dateTimePickerMulai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMulai.Location = new System.Drawing.Point(203, 166);
            this.dateTimePickerMulai.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerMulai.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerMulai.Name = "dateTimePickerMulai";
            this.dateTimePickerMulai.Size = new System.Drawing.Size(165, 20);
            this.dateTimePickerMulai.TabIndex = 8;
            this.dateTimePickerMulai.Value = new System.DateTime(2019, 5, 1, 15, 57, 7, 0);
            // 
            // textBoxDirectMaterial
            // 
            this.textBoxDirectMaterial.Location = new System.Drawing.Point(203, 114);
            this.textBoxDirectMaterial.Name = "textBoxDirectMaterial";
            this.textBoxDirectMaterial.Size = new System.Drawing.Size(135, 20);
            this.textBoxDirectMaterial.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(103, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "No Job Order:";
            // 
            // comboBoxNoNotaJual
            // 
            this.comboBoxNoNotaJual.FormattingEnabled = true;
            this.comboBoxNoNotaJual.Location = new System.Drawing.Point(203, 87);
            this.comboBoxNoNotaJual.Name = "comboBoxNoNotaJual";
            this.comboBoxNoNotaJual.Size = new System.Drawing.Size(165, 21);
            this.comboBoxNoNotaJual.TabIndex = 3;
            // 
            // textBoxKodeJobOrder
            // 
            this.textBoxKodeJobOrder.Location = new System.Drawing.Point(203, 34);
            this.textBoxKodeJobOrder.Name = "textBoxKodeJobOrder";
            this.textBoxKodeJobOrder.Size = new System.Drawing.Size(74, 20);
            this.textBoxKodeJobOrder.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Nomor Permintaan:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(132, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Tanggal:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(116, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Keterangan:";
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonSimpan.FlatAppearance.BorderSize = 0;
            this.buttonSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimpan.ForeColor = System.Drawing.Color.White;
            this.buttonSimpan.Location = new System.Drawing.Point(13, 271);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(96, 33);
            this.buttonSimpan.TabIndex = 42;
            this.buttonSimpan.Text = "SIMPAN";
            this.buttonSimpan.UseVisualStyleBackColor = false;
            // 
            // buttonKosongi
            // 
            this.buttonKosongi.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonKosongi.FlatAppearance.BorderSize = 0;
            this.buttonKosongi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKosongi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKosongi.ForeColor = System.Drawing.Color.White;
            this.buttonKosongi.Location = new System.Drawing.Point(116, 271);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(96, 33);
            this.buttonKosongi.TabIndex = 43;
            this.buttonKosongi.Text = "KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 32);
            this.label1.TabIndex = 45;
            this.label1.Text = "TAMBAH SURAT PERMINTAAN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonKeluar.FlatAppearance.BorderSize = 0;
            this.buttonKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(359, 271);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(96, 33);
            this.buttonKeluar.TabIndex = 44;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            // 
            // FormTambahSuratPermintaan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(466, 316);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonKeluar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTambahSuratPermintaan";
            this.Text = "FormTambahSuratPermintaan";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerMulai;
        private System.Windows.Forms.TextBox textBoxDirectMaterial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxNoNotaJual;
        private System.Windows.Forms.TextBox textBoxKodeJobOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKeluar;
    }
}