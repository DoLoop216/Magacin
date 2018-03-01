using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Magacin
{
    public partial class Kviz_Pregled_Pitanja : Form
    {
        public Kviz_Pregled_Pitanja()
        {
            InitializeComponent();
        }

        private void Kviz_Pregled_Pitanja_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Kviz.UcitajPitanja();
        }

        private void izmeniPitanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["KVIZ_GRUPA_ID"].Value))
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
    }
}
