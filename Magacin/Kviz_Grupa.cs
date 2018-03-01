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
    public partial class Kviz_Grupa : Form
    {
        int grupaId;
        string naziv;
        string forma;

        public Kviz_Grupa(int grupaId, string naziv)
        {
            InitializeComponent();

            this.grupaId = grupaId;
            this.naziv = naziv;
            this.forma = Kviz.FormaGrupe(grupaId);

            id_txt.Text = grupaId.ToString();
            naziv_txt.Text = naziv;
            forma_cmb.SelectedItem = forma;
        }

        private void Kviz_Grupa_Load(object sender, EventArgs e)
        {
            forma_cmb.DataSource = Kviz.FormeGrupe();
        }

        private void sacuvaj_btn_Click(object sender, EventArgs e)
        {
            Kviz.IzmeniGrupu(grupaId, naziv_txt.Text, forma_cmb.SelectedItem.ToString(), (int)brojPitanja_num.Value);
        }

        private void ponisti_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
