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
    public partial class Kviz_Form : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        public Kviz_Form()
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);
        }

        private void zapocni_btn_Click(object sender, EventArgs e)
        {
            Kviz_Radi rk = new Kviz_Radi();
            rk.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kviz_Uredjivanje ku = new Kviz_Uredjivanje();
            ku.ShowDialog();
        }
    }
}
