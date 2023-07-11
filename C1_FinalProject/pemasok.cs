using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C1_FinalProject
{
    public partial class pemasok : Form
    {
        public pemasok()
        {
            InitializeComponent();
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


            }
        }
    }
}
