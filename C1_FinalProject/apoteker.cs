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
    public partial class apoteker : Form
    {
        private string stringConnection = "data source=LAPTOP-8VUKFT0D\\DESTAKKA;" + "database = apotek_5arah; User ID = sa; Password=Desta21";
        private SqlConnection koneksi;
        public apoteker()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();

        }
        private void refreshform()
        {
            idA.Text = "";
            nmA.Text = "";
            tlpA.Text = "";
            wkA.Text = "";
            almtA.Text = "";
            idA.Enabled = false;
            nmA.Enabled = false;
            tlpA.Enabled = false;
            wkA.Enabled = false;
            almtA.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }
        private void DataGridView()
        {
            koneksi.Open();
            string str = "select id_apoteker from dbo.apoteker";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void apoteker_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idapoteker = idA.Text;
            string nmapoteker = nmA.Text;
            string telpapoteker = tlpA.Text;
            string wkapoteker = wkA.Text;
            string almtapoteker = almtA.Text;
            if (idapoteker == "")
            {
                MessageBox.Show("Masukkan Id Apoteker", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (nmapoteker == "")
            {
                MessageBox.Show("Masukkan Nama Apoteker", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (telpapoteker == "")
            {
                MessageBox.Show("Masukkan No Telpon Apoteker", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (wkapoteker == "")
            {
                MessageBox.Show("Masukkan Waktu Kerja Apoteker", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (almtapoteker == "")
            {
                MessageBox.Show("Masukkan Alamat Apoteker", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.apoteker (id_apoteker, nama_apoteker, no_telp, waktu_kerja, alamat_apoteker)" + "values(@id_apoteker, @nama_apoteker, @no_telp, @waktu_kerja, @alamat_apoteker)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@id_apoteker", idapoteker));
                cmd.Parameters.Add(new SqlParameter("@nama_apoteker", nmapoteker));
                cmd.Parameters.Add(new SqlParameter("@no_telp", telpapoteker));
                cmd.Parameters.Add(new SqlParameter("@waktu_kerja", wkapoteker));
                cmd.Parameters.Add(new SqlParameter("@alamat_apoteker", almtapoteker));
                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridView();
                refreshform();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
        }

        private void refreshform_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            idA.Enabled = true;
            nmA.Enabled = true;
            tlpA.Enabled = true;
            wkA.Enabled = true;
            almtA.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = true;
            btnDisplay.Enabled = true;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void idA_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DataGridView();
            btnDisplay.Enabled = false;
        }

        private void obatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            obat fm = new obat();
            fm.Show();
            this.Hide();
        }

        private void pelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pelanggan fm = new pelanggan();
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
    }
}
