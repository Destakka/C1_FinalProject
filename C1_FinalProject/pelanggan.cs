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
    public partial class pelanggan : Form
    {
        private string stringConnection = "data source=LAPTOP-8VUKFT0D\\DESTAKKA;" + "database = apotek_5arah; User ID = sa; Password=Desta21";
        private SqlConnection koneksi;
        private string idpel, nmpel, telppel, jkpel;
        private DateTime tglbeli;
        public pelanggan()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }
        private void refreshform()
        {
            idP.Text = "";
            nmP.Text = "";
            telpP.Text = "";
            jkP.Text = "";
            datebeli.Text = "";
            idP.Enabled = false;
            nmP.Enabled = false;
            telpP.Enabled = false;
            jkP.Enabled = false;
            datebeli.Enabled = false;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }
        private void DataGridView()
        {
            koneksi.Open();
            string str = "select id_pelanggan from dbo.pelanggann";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            idP.Enabled = true;
            nmP.Enabled = true;
            telpP.Enabled = true;
            datebeli.Enabled = true;
            jkP.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = true;
            btnDisplay.Enabled = true;
        }

        private void apotekerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apoteker fm = new apoteker();
            fm.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            idpel = idP.Text.Trim();
            nmpel = nmP.Text.Trim();
            telppel = telpP.Text.Trim();
            jkpel = jkP.Text.Trim();
            tglbeli = datebeli.Value;
            if (string.IsNullOrEmpty(idpel) || string.IsNullOrEmpty(nmpel) || string.IsNullOrEmpty(telppel) || string.IsNullOrEmpty(jkpel))
            {
                MessageBox.Show("Please fill in all identity fields!");
            }

            else
            {
                koneksi.Open();
                string str = "insert into dbo.pelanggann (id_pelanggan, nama_pelanggan, no_telepon, tanggal_beli, jenis_kelamin)" + "values(@id_pelanggan, @nama_pelanggan, @no_telepon, @tanggal_beli, @jenis_kelamin)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.Parameters.AddWithValue("@id_pelanggan", idpel);
                cmd.Parameters.AddWithValue("@nama_pelanggan", nmpel);
                cmd.Parameters.AddWithValue("@no_telepon", telppel);
                cmd.Parameters.AddWithValue("@tanggal_beli", tglbeli);
                cmd.Parameters.AddWithValue("@jenis_kelamin", jkpel);
                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refreshform();
            }
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
