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
        private string idobt, nmobat, kandunganobt, merkobt;
        private DateTime expobt;
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
            dateexp.Text = "";
            idO.Enabled = false;
            nmO.Enabled = false;
            kandungan.Enabled = false;
            merk.Enabled = false;
            dateexp.Enabled = false;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }
        private void DataGridView()
        {
            koneksi.Open();
            string str = "select*from obat";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DataGridView();
            btnDisplay.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            idobt = idO.Text.Trim();
            nmobat = nmO.Text.Trim();
            kandunganobt = kandungan.Text.Trim();
            merkobt = merk.Text.Trim();
            expobt = dateexp.Value;
            if (string.IsNullOrEmpty(idobt) || string.IsNullOrEmpty(nmobat) || string.IsNullOrEmpty(kandunganobt) || string.IsNullOrEmpty(merkobt))
            {
                MessageBox.Show("Please fill in all identity fields!");
            }

            else
            {
                koneksi.Open();
                string str = "select*from obat";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.Parameters.AddWithValue("@id_obat", idobt);
                cmd.Parameters.AddWithValue("@nama_bat", nmobat);
                cmd.Parameters.AddWithValue("@kandungan", kandunganobt);
                cmd.Parameters.AddWithValue("@merk", merkobt);
                cmd.Parameters.AddWithValue("@expired_date", expobt);
                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refreshform();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dateexp.Value = DateTime.Today;
            idO.Enabled = true;
            nmO.Enabled = true;
            kandungan.Enabled = true;
            merk.Enabled = true;
            dateexp.Enabled = true;
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
