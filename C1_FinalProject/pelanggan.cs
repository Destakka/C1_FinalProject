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
        private string id, nmobat, kandunganobt, merkobt;
        private DateTime expobt;
        public pelanggan()
        {
            InitializeComponent();
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
