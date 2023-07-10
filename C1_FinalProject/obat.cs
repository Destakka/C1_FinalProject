using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C1_FinalProject
{
    public partial class obat : Form
    {
        private string stringConnection = "data source=LAPTOP-8VUKFT0D\\DESTAKKA;" + "database = apotek_5arah; User ID = sa; Password=Desta21";
        private SqlConnection koneksi;
        private string id, nmobat, kandunganobt, merkobt, expobt;
        private DateTime tgl;
        public obat()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void refreshform()
        {
            idO.Text = "";
            nmO.Text = "";
            kandungan.Text = "";
            merk.Text = "";
            exp.Text = "";
            idO.Enabled = false;
            nmO.Enabled = false;
            kandungan.Enabled = false;
            merk.Enabled = false;
            exp.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }

        private void pelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pelanggan fm = new pelanggan();
            fm.Show();
            this.Hide();
        }

        private void apotekerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apoteker fm = new apoteker();
            fm.Show();
            this.Hide();
        }

        private void gudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gudang fm = new gudang();
            fm.Show();
            this.Hide();
        }

        private void pemasokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pemasok fm = new pemasok();
            fm.Show();
            this.Hide();
        }

        private void obat_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idobat = idO.Text.Trim();
            string nmobat = nmO.Text.Trim();
            string kandunganobat = kandungan.Text.Trim();
            string merkobat = merk.Text.Trim();
            string expobat = exp.Text.Trim();
            if (idobat == "")
            {
                MessageBox.Show("Masukkan Id Obat", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (nmobat == "")
            {
                MessageBox.Show("Masukkan Nama Obat", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (kandunganobat == "")
            {
                MessageBox.Show("Masukkan Kandungan Obat", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (merkobat == "")
            {
                MessageBox.Show("Masukkan Merk Obat", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (expobat == "")
            {
                MessageBox.Show("Masukkan Expired", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.obat (id_obat, nama_bat, kandungan, merk, expired_date)" + "values(@id_obat, @nama_bat, @kandungan, @merk, @expired_date)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@id_obat", idobat));
                cmd.Parameters.Add(new SqlParameter("@nama_bat", nmobat));
                cmd.Parameters.Add(new SqlParameter("@kandungan", kandunganobat));
                cmd.Parameters.Add(new SqlParameter("@merk", merkobat));
                cmd.Parameters.Add(new SqlParameter("@expired_date", expobat));
                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                refreshform();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            idO.Enabled = true;
            nmO.Enabled = true;
            kandungan.Enabled = true;
            merk.Enabled = true;
            exp.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = true;
            btnDisplay.Enabled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
