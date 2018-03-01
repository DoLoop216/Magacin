using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Magacin
{
    public partial class Obavestenje : Form
    {
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        double sekundi = 3;

        public Obavestenje(int sekundi, string text)
        {
            InitializeComponent();
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
            t = new System.Windows.Forms.Timer();
            this.sekundi = (sekundi != 0) ? sekundi : this.sekundi;
            richTextBox1.Text = text;
        }

        private void Obavestenje_Load(object sender, EventArgs e)
        {
            t.Interval = (int)(sekundi * 1000);
            t.Tick += new EventHandler(Zatvori);
            t.Start();
        }

        private void Zatvori(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
