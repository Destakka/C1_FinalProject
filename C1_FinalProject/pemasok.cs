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

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
