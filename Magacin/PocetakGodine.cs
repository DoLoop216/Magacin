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
    public partial class PocetakGodine : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        public PocetakGodine()
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);
        }
    }
}
