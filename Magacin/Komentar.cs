using FirebirdSql.Data.FirebirdClient;
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
    public partial class Komentar : Form
    {
        Dokument1 dokument;
        public Komentar(Dokument1 dokument)
        {
            InitializeComponent();
            this.dokument = dokument;
            komentar_rtxt.Text = dokument.komentar;

            if (dokument.flag != 0)
                komentar_rtxt.ReadOnly = true;
        }

        private void Komentar_Load(object sender, EventArgs e)
        {
        }

        private void sacuvaj_btn_Click(object sender, EventArgs e)
        {
            dokument.SacuvajKomentar(komentar_rtxt.Text);
        }
    }
}
