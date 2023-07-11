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

    public partial class pemasok : Form
    {
        private string stringConnection = "data source=LAPTOP-8VUKFT0D\\DESTAKKA;" + "database = apotek_5arah; User ID = sa; Password=Desta21";
        private SqlConnection koneksi;
        private string idpem, nmpem, telppem, produkpem, alamatpem;
        public pemasok()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();

        }
        private void refreshform()
        {
            idPem.Text = "";
            nmPem.Text = "";
            telpPem.Text = "";
            prdP.Text = "";
            almtPem.Text = "";
            idPem.Enabled = false;
            nmPem.Enabled = false;
            telpPem.Enabled = false;
            prdP.Enabled = false;
            almtPem.Enabled = false;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }
        private void DataGridView()
        {
            koneksi.Open();
            string str = "select id_pemasok from dbo.pemasok";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }


        private void apotekerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apoteker fm = new apoteker();
            fm.Show();
            this.Hide();
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

        private void pemasok_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            idPem.Enabled = true;
            nmPem.Enabled = true;
            telpPem.Enabled = true;
            prdP.Enabled = true;
            almtPem.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = true;
            btnDisplay.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idpemasok = idPem.Text;
            string nmpemasok = nmPem.Text;
            string telppemasok = telpPem.Text;
            string produkpemasok = prdP.Text;
            string alamatpemasok = almtPem.Text;
            if (idpemasok == "")
            {
                MessageBox.Show("Masukkan Id Pemasok", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (nmpemasok == "")
            {
                MessageBox.Show("Masukkan Nama Pemasok", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (telppemasok == "")
            {
                MessageBox.Show("Masukkan No Telpon Pemasok", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (produkpemasok == "")
            {
                MessageBox.Show("Masukkan Produk Pemasok", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (alamatpemasok == "")
            {
                MessageBox.Show("Masukkan Alamat Pemasok", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.pemasok (id_pemasok, nama_pemasok, no_telepon, produk_pemasok, alamat_pemasok)" + "values(@id_pemasok, @nama_pemasok, @no_telepon, @produk_pemasok, @alamat_pemasok)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@id_pemasok", idpemasok));
                cmd.Parameters.Add(new SqlParameter("@nama_pemasok", nmpemasok));
                cmd.Parameters.Add(new SqlParameter("@no_telepon", telppemasok));
                cmd.Parameters.Add(new SqlParameter("@produk_pemasok", produkpemasok));
                cmd.Parameters.Add(new SqlParameter("@alamat_pemasok", alamatpemasok));
                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridView();
                refreshform();
            }
        }
    }
}
