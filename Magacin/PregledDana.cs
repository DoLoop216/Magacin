using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;

namespace Magacin
{
    public partial class PregledDana : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        private Random rnd = new Random();
        private CiljMagacina lokalCiljMagacina = new CiljMagacina();
        private CiljMagacina globalniCiljMagacina = new CiljMagacina();

        public PregledDana()
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);

            magacin_cmb.SelectedValue = 12;
            magacin_cmb.Enabled = ((Korisnik.ImaPravo(31004)) ? true : false);
        }

        private void PregledDana_Load(object sender, EventArgs e)
        {
            magacin_cmb.DataSource = Komercijalno.UcitajMagacine();
            magacin_cmb.DisplayMember = "_string";
            magacin_cmb.ValueMember = "_int";

            NamestiGrafikon();
            UcitajPodatke();
            lokalCiljMagacina.Initialize(Korisnik.korisnikId, (int)magacin_cmb.SelectedValue);
            magacin_cmb.SelectedValue = Korisnik.magacinId;
        }

        private void NamestiGrafikon()
        {
            List<String_Double> list = Komercijalno.DnevniPrometSvihMagacina(dateTimePicker1.Value);

            chart1.DataSource = list;
            chart1.Series.First().XValueMember = "_string";
            chart1.Series.First().YValueMembers = "_double";

            chart1.Series[0].IsVisibleInLegend = false;

            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.Maximum = 18;

            chart1.ChartAreas[0].AxisX.CustomLabels.Add(0.5, 1.5, "M12");
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(1.5, 2.5, "M13");
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(2.5, 3.5, "M14");
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(3.5, 4.5, "M15");
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(4.5, 5.5, "M16");
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(5.5, 6.5, "M17");
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(6.5, 7.5, "M18");
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(7.5, 8.5, "M19");
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(8.5, 9.5, "M20");
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(9.5, 10.5, "M21");
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(10.5, 11.5, "M22");
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(11.5, 12.5, "M23");
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(12.5, 13.5, "M24");
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(13.5, 14.5, "M25");
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(14.5, 15.5, "M26");
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(15.5, 16.5, "M27");
            chart1.ChartAreas[0].AxisX.CustomLabels.Add(16.5, 17.5, "M28");
        }
        private void UcitajPodatke()
        {
            lokalCiljMagacina.Initialize(Korisnik.korisnikId, (int)magacin_cmb.SelectedValue);
            globalniCiljMagacina.Initialize(-1, (int)magacin_cmb.SelectedValue);

            double mesecniPromet = Komercijalno.PrometMagacina((int)magacin_cmb.SelectedValue, M.Godina.MesecGet(dateTimePicker1.Value.Month), dateTimePicker1.Value.Year);
            double proslogodisnjiMesecniPromet = Komercijalno.PrometMagacina((int)magacin_cmb.SelectedValue, M.Godina.MesecGet(dateTimePicker1.Value.Month), dateTimePicker1.Value.Year - 1);

            double lokalniCilj = 0;
            double globalniCilj = 0;

            if(lokalCiljMagacina.procentualno == true)
            {
                lokalniCilj = proslogodisnjiMesecniPromet + (proslogodisnjiMesecniPromet * lokalCiljMagacina.godisnjiRast / 100);
            }
            else
            {
                lokalniCilj = lokalCiljMagacina.godisnjiRast;
            }
            if(globalniCiljMagacina.procentualno == true)
            {
                globalniCilj = proslogodisnjiMesecniPromet + (proslogodisnjiMesecniPromet * globalniCiljMagacina.godisnjiRast / 100);
            }
            else
            {
                globalniCilj = globalniCiljMagacina.godisnjiRast;
            }

            ukupanPromet_txt.Text = String.Format("{0:n} RSD", Komercijalno.PrometMagacina((int)magacin_cmb.SelectedValue, dateTimePicker1.Value));
            gotovina_txt.Text = String.Format("{0:n} RSD", Komercijalno.PrometMagacina((int)magacin_cmb.SelectedValue, dateTimePicker1.Value, NacinUplate.Gotovina));
            virman_txt.Text = String.Format("{0:n} RSD", Komercijalno.PrometMagacina((int)magacin_cmb.SelectedValue, dateTimePicker1.Value, NacinUplate.Virman));
            kartica_txt.Text = String.Format("{0:n} RSD", Komercijalno.PrometMagacina((int)magacin_cmb.SelectedValue, dateTimePicker1.Value, NacinUplate.Kartica));
            odlozeno_txt.Text = String.Format("{0:n} RSD", Komercijalno.PrometMagacina((int)magacin_cmb.SelectedValue, dateTimePicker1.Value, NacinUplate.Odlozeo));

            ukupanPrometM_txt.Text = String.Format("{0:n} RSD", mesecniPromet);
            globalCilj_txt.Text = String.Format("{0:n} RSD", globalniCilj);
            lokalniCilj_txt.Text = String.Format("{0:n} RSD", lokalniCilj);

            label6.Text = dateTimePicker1.Value.ToShortDateString();

            lokalniCilj_txt.BackColor = (lokalniCilj > mesecniPromet) ? Color.Pink : Color.LightGreen;
            globalCilj_txt.BackColor = (globalniCilj > mesecniPromet) ? Color.Pink : Color.LightGreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NamestiGrafikon();
            UcitajPodatke();
        }

        private void izmeniCiljToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Korisnik.ImaPravo(99313))
            {
                CiljeviMagacina cm = new CiljeviMagacina(true, null, null);
                cm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nemate prava pristupa modulu [99313]");
            }
        }

        private void izmeniCiljToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (magacin_cmb.SelectedIndex > -1)
            {
                if (Korisnik.ImaPravo(99312))
                {
                    CiljeviMagacina cm = new CiljeviMagacina(false, (int)magacin_cmb.SelectedValue, Korisnik.korisnikId);
                    cm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nemate prava pristupa modulu [99312]");
                }
            }
        }
    }
}
