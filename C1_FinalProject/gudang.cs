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
    public partial class gudang : Form
    {
        private string stringConnection = "data source=LAPTOP-8VUKFT0D\\DESTAKKA;" + "database = apotek_5arah; User ID = sa; Password=Desta21";
        private SqlConnection koneksi;
        private string idgdg, nmgdg, stockob, koderak, obatmasuk;
        public gudang()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }
        private void refreshform()
        {
            idG.Text = "";
            nmG.Text = "";
            stockobat.Text = "";
            KodeR.Text = "";
            obatM.Text = "";
            idG.Enabled = false;
            nmG.Enabled = false;
            stockobat.Enabled = false;
            KodeR.Enabled = false;
            obatM.Enabled = false;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }
        private void DataGridView()
        {
            koneksi.Open();
            string str = "select id_obat from dbo.gudang_pengimporan";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void apotekerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apoteker fm = new apoteker();
            fm.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idgudang = idG.Text;
            string nmgudang = nmG.Text;
            string stockob = stockobat.Text;
            string koderak = KodeR.Text;
            string obatmasuk = obatM.Text;
            if (idgudang == "")
            {
                MessageBox.Show("Masukkan Id Gudang", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (nmgudang == "")
            {
                MessageBox.Show("Masukkan Nama Gudang", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (stockob == "")
            {
                MessageBox.Show("Masukkan Stock Obat", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (koderak == "")
            {
                MessageBox.Show("Masukkan Kode Rak", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (obatmasuk == "")
            {
                MessageBox.Show("Masukkan Obat Masuk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.gudang_pengimporan (nama_gudang, id_gudang, stok_obat, kode_rak, obat_masuk)" + "values(@nama_gudang, @id_gudang, @stok_obat, @kode_rak, @obat_masuk)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@id_gudang", idgudang));
                cmd.Parameters.Add(new SqlParameter("@nama_gudang", nmgudang));
                cmd.Parameters.Add(new SqlParameter("@stock_obat", stockob));
                cmd.Parameters.Add(new SqlParameter("@kode_rak", koderak));
                cmd.Parameters.Add(new SqlParameter("@obat_masuk", obatmasuk));
                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridView();
                refreshform();
            }
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

        private void pemasokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pemasok fm = new pemasok();
            fm.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            idG.Enabled = true;
            nmG.Enabled = true;
            stockobat.Enabled = true;
            KodeR.Enabled = true;
            obatM.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = true;
            btnDisplay.Enabled = true;
        }
    }
}
