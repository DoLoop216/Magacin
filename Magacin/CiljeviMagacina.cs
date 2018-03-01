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
    public partial class CiljeviMagacina : Form, MForm
    {
        public Help helpWindow { get; set; }
        public M.Podesavanja.Forma InitializeForm { get; set; }

        string txt1 = "Lokalni cilj magacina oznacava cilj koji definise svaki trgovac za sebe i moze ga videti samo on\n\n Cilj je iskazan u procentima i oznacava zeljeni rast u odnosu na proslu godinu.";
        string txt2 = "Globalni cilj magacina oznacava cilj koji definise administrator i moze ga videti svaki trgovac\n\n Cilj je iskazan u procentima i oznacava zeljeni rast u odnosu na proslu godinu.";
        int? magacinId;
        int? korisnikId;
        bool isGlobal = false;
        
        CiljMagacina cm = new CiljMagacina();
        List<CiljMagacina> cm_g = new List<CiljMagacina>();

        string[] m_cmb =
        {
            "Vrednosno",
            "Procentualno"
        };

        public CiljeviMagacina(bool isGlobal, int? magacinId, int? korisnikId)
        {
            InitializeComponent();
            InitializeForm = new M.Podesavanja.Forma(this, this);

            if(isGlobal)
            {
                richTextBox1.Text = txt1;
            }
            else
            {
                richTextBox1.Text = txt2;
            }

            this.magacinId = magacinId;
            this.korisnikId = korisnikId;
            this.isGlobal = isGlobal;

            m12_cmb.DataSource = m_cmb.Clone();
            m13_cmb.DataSource = m_cmb.Clone();
            m14_cmb.DataSource = m_cmb.Clone();
            m15_cmb.DataSource = m_cmb.Clone();
            m16_cmb.DataSource = m_cmb.Clone();
            m17_cmb.DataSource = m_cmb.Clone();
            m18_cmb.DataSource = m_cmb.Clone();
            m19_cmb.DataSource = m_cmb.Clone();
            m20_cmb.DataSource = m_cmb.Clone();
            m21_cmb.DataSource = m_cmb.Clone();
            m22_cmb.DataSource = m_cmb.Clone();
            m23_cmb.DataSource = m_cmb.Clone();
            m24_cmb.DataSource = m_cmb.Clone();
            m25_cmb.DataSource = m_cmb.Clone();
            m26_cmb.DataSource = m_cmb.Clone();
            m27_cmb.DataSource = m_cmb.Clone();
            m28_cmb.DataSource = m_cmb.Clone();
        }
        private void CiljeviMagacina_Load(object sender, EventArgs e)
        {
            if (!isGlobal)
            {
                UcitajLokalniCilj();
            }
            else
            {
                UcitajGlobalniCilj();
            }

            Setup();
        }

        private void UcitajLokalniCilj()
        {
            cm.Initialize((int)korisnikId, (int)magacinId);
            switch(magacinId)
            {
                case 12:
                    m12_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
                case 13:
                    m13_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
                case 14:
                    m14_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
                case 15:
                    m15_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
                case 16:
                    m16_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
                case 17:
                    m17_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
                case 18:
                    m18_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
                case 19:
                    m19_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
                case 20:
                    m20_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
                case 21:
                    m21_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
                case 22:
                    m22_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
                case 23:
                    m23_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
                case 24:
                    m24_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
                case 25:
                    m25_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
                case 26:
                    m26_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
                case 27:
                    m27_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
                case 28:
                    m28_txt.Text = String.Format("{0:##}", cm.godisnjiRast);
                    break;
            }
        }
        private void UcitajGlobalniCilj()
        {
            for(int i = 12; i < 29; i++)
            {
                CiljMagacina c = new CiljMagacina();
                c.Initialize(-1, i);

                cm_g.Add(c);

                switch (i)
                {
                    case 12:
                        m12_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m12_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                    case 13:
                        m13_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m13_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                    case 14:
                        m14_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m14_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                    case 15:
                        m15_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m15_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                    case 16:
                        m16_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m16_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                    case 17:
                        m17_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m17_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                    case 18:
                        m18_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m18_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                    case 19:
                        m19_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m19_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                    case 20:
                        m20_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m20_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                    case 21:
                        m21_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m21_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                    case 22:
                        m22_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m22_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                    case 23:
                        m23_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m23_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                    case 24:
                        m24_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m24_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                    case 25:
                        m25_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m25_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                    case 26:
                        m26_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m26_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                    case 27:
                        m27_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m27_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                    case 28:
                        m28_txt.Text = String.Format("{0:##}", c.godisnjiRast);
                        m28_cmb.SelectedIndex = (c.procentualno) ? 1 : 0;
                        break;
                }

            }
        }
        private void Setup()
        {
            if (!isGlobal)
            {
                m12_txt.Enabled = false;
                m12_cmb.Enabled = false;

                m13_txt.Enabled = false;
                m13_cmb.Enabled = false;

                m14_txt.Enabled = false;
                m14_cmb.Enabled = false;

                m15_txt.Enabled = false;
                m15_cmb.Enabled = false;

                m16_txt.Enabled = false;
                m16_cmb.Enabled = false;

                m17_txt.Enabled = false;
                m17_cmb.Enabled = false;

                m18_txt.Enabled = false;
                m18_cmb.Enabled = false;

                m19_txt.Enabled = false;
                m19_cmb.Enabled = false;

                m20_txt.Enabled = false;
                m20_cmb.Enabled = false;

                m21_txt.Enabled = false;
                m21_cmb.Enabled = false;

                m22_txt.Enabled = false;
                m22_cmb.Enabled = false;

                m23_txt.Enabled = false;
                m23_cmb.Enabled = false;

                m24_txt.Enabled = false;
                m24_cmb.Enabled = false;

                m25_txt.Enabled = false;
                m25_cmb.Enabled = false;

                m26_txt.Enabled = false;
                m26_cmb.Enabled = false;

                m27_txt.Enabled = false;
                m27_cmb.Enabled = false;

                m28_txt.Enabled = false;
                m28_cmb.Enabled = false;

                switch (magacinId)
                {
                    case 12:
                        m12_txt.Enabled = true;
                        m12_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m12_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m12_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m12_cmb.SelectedIndex = -1;
                        }
                        break;
                    case 13:
                        m13_txt.Enabled = true;
                        m13_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m13_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m13_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m13_cmb.SelectedIndex = -1;
                        }
                        break;
                    case 14:
                        m14_txt.Enabled = true;
                        m14_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m14_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m14_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m14_cmb.SelectedIndex = -1;
                        }
                        break;
                    case 15:
                        m15_txt.Enabled = true;
                        m15_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m15_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m15_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m15_cmb.SelectedIndex = -1;
                        }
                        break;
                    case 16:
                        m16_txt.Enabled = true;
                        m16_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m16_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m16_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m16_cmb.SelectedIndex = -1;
                        }
                        break;
                    case 17:
                        m17_txt.Enabled = true;
                        m17_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m17_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m17_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m17_cmb.SelectedIndex = -1;
                        }
                        break;
                    case 18:
                        m18_txt.Enabled = true;
                        m18_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m18_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m18_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m18_cmb.SelectedIndex = -1;
                        }
                        break;
                    case 19:
                        m19_txt.Enabled = true;
                        m19_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m19_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m19_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m19_cmb.SelectedIndex = -1;
                        }
                        break;
                    case 20:
                        m20_txt.Enabled = true;
                        m20_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m20_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m20_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m20_cmb.SelectedIndex = -1;
                        }
                        break;
                    case 21:
                        m21_txt.Enabled = true;
                        m21_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m21_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m21_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m21_cmb.SelectedIndex = -1;
                        }
                        break;
                    case 22:
                        m22_txt.Enabled = true;
                        m22_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m22_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m22_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m22_cmb.SelectedIndex = -1;
                        }
                        break;
                    case 23:
                        m23_txt.Enabled = true;
                        m23_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m23_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m23_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m23_cmb.SelectedIndex = -1;
                        }
                        break;
                    case 24:
                        m24_txt.Enabled = true;
                        m24_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m24_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m24_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m24_cmb.SelectedIndex = -1;
                        }
                        break;
                    case 25:
                        m25_txt.Enabled = true;
                        m25_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m25_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m25_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m25_cmb.SelectedIndex = -1;
                        }
                        break;
                    case 26:
                        m26_txt.Enabled = true;
                        m26_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m26_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m26_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m26_cmb.SelectedIndex = -1;
                        }
                        break;
                    case 27:
                        m27_txt.Enabled = true;
                        m27_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m27_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m27_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m27_cmb.SelectedIndex = -1;
                        }
                        break;
                    case 28:
                        m28_txt.Enabled = true;
                        m28_cmb.Enabled = true;
                        if (cm.procentualno)
                        {
                            m28_cmb.SelectedIndex = 1;
                        }
                        else if (!cm.procentualno)
                        {
                            m28_cmb.SelectedIndex = 0;
                        }
                        else
                        {
                            m28_cmb.SelectedIndex = -1;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void sacuvaj_btn_Click(object sender, EventArgs e)
        {
            if (!isGlobal)
            {
                switch (magacinId)
                {
                    case 12:
                        cm.godisnjiRast = Convert.ToDouble(m12_txt.Text);
                        cm.procentualno = (m12_cmb.SelectedIndex == 1) ? true : false;
                        break;
                    case 13:
                        cm.godisnjiRast = Convert.ToDouble(m13_txt.Text);
                        cm.procentualno = (m13_cmb.SelectedIndex == 1) ? true : false;
                        break;
                    case 14:
                        cm.godisnjiRast = Convert.ToDouble(m14_txt.Text);
                        cm.procentualno = (m14_cmb.SelectedIndex == 1) ? true : false;
                        break;
                    case 15:
                        cm.godisnjiRast = Convert.ToDouble(m15_txt.Text);
                        cm.procentualno = (m15_cmb.SelectedIndex == 1) ? true : false;
                        break;
                    case 16:
                        cm.godisnjiRast = Convert.ToDouble(m16_txt.Text);
                        cm.procentualno = (m16_cmb.SelectedIndex == 1) ? true : false;
                        break;
                    case 17:
                        cm.godisnjiRast = Convert.ToDouble(m17_txt.Text);
                        cm.procentualno = (m17_cmb.SelectedIndex == 1) ? true : false;
                        break;
                    case 18:
                        cm.godisnjiRast = Convert.ToDouble(m18_txt.Text);
                        cm.procentualno = (m18_cmb.SelectedIndex == 1) ? true : false;
                        break;
                    case 19:
                        cm.godisnjiRast = Convert.ToDouble(m19_txt.Text);
                        cm.procentualno = (m19_cmb.SelectedIndex == 1) ? true : false;
                        break;
                    case 20:
                        cm.godisnjiRast = Convert.ToDouble(m20_txt.Text);
                        cm.procentualno = (m20_cmb.SelectedIndex == 1) ? true : false;
                        break;
                    case 21:
                        cm.godisnjiRast = Convert.ToDouble(m21_txt.Text);
                        cm.procentualno = (m21_cmb.SelectedIndex == 1) ? true : false;
                        break;
                    case 22:
                        cm.godisnjiRast = Convert.ToDouble(m22_txt.Text);
                        cm.procentualno = (m22_cmb.SelectedIndex == 1) ? true : false;
                        break;
                    case 23:
                        cm.godisnjiRast = Convert.ToDouble(m23_txt.Text);
                        cm.procentualno = (m23_cmb.SelectedIndex == 1) ? true : false;
                        break;
                    case 24:
                        cm.godisnjiRast = Convert.ToDouble(m24_txt.Text);
                        cm.procentualno = (m24_cmb.SelectedIndex == 1) ? true : false;
                        break;
                    case 25:
                        cm.godisnjiRast = Convert.ToDouble(m25_txt.Text);
                        cm.procentualno = (m25_cmb.SelectedIndex == 1) ? true : false;
                        break;
                    case 26:
                        cm.godisnjiRast = Convert.ToDouble(m26_txt.Text);
                        cm.procentualno = (m26_cmb.SelectedIndex == 1) ? true : false;
                        break;
                    case 27:
                        cm.godisnjiRast = Convert.ToDouble(m27_txt.Text);
                        cm.procentualno = (m27_cmb.SelectedIndex == 1) ? true : false;
                        break;
                    case 28:
                        cm.godisnjiRast = Convert.ToDouble(m28_txt.Text);
                        cm.procentualno = (m28_cmb.SelectedIndex == 1) ? true : false;
                        break;
                }
                cm.Zapisi(isGlobal, korisnikId, magacinId);
            }
            else
            {
                for(int i = 12; i < 28; i++)
                {
                    CiljMagacina c = cm_g[i - 12];

                    switch (i)
                    {
                        case 12:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m12_txt.Text)) ? 0 : Convert.ToDouble(m12_txt.Text);
                            c.procentualno = (m12_cmb.SelectedIndex == 1) ? true : false;
                            break;
                        case 13:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m13_txt.Text)) ? 0 : Convert.ToDouble(m13_txt.Text);
                            c.procentualno = (m13_cmb.SelectedIndex == 1) ? true : false;
                            break;
                        case 14:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m14_txt.Text)) ? 0 : Convert.ToDouble(m14_txt.Text);
                            c.procentualno = (m14_cmb.SelectedIndex == 1) ? true : false;
                            break;
                        case 15:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m15_txt.Text)) ? 0 : Convert.ToDouble(m15_txt.Text);
                            c.procentualno = (m15_cmb.SelectedIndex == 1) ? true : false;
                            break;
                        case 16:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m16_txt.Text)) ? 0 : Convert.ToDouble(m16_txt.Text);
                            c.procentualno = (m16_cmb.SelectedIndex == 1) ? true : false;
                            break;
                        case 17:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m17_txt.Text)) ? 0 : Convert.ToDouble(m17_txt.Text);
                            c.procentualno = (m17_cmb.SelectedIndex == 1) ? true : false;
                            break;
                        case 18:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m18_txt.Text)) ? 0 : Convert.ToDouble(m18_txt.Text);
                            c.procentualno = (m18_cmb.SelectedIndex == 1) ? true : false;
                            break;
                        case 19:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m19_txt.Text)) ? 0 : Convert.ToDouble(m19_txt.Text);
                            c.procentualno = (m19_cmb.SelectedIndex == 1) ? true : false;
                            break;
                        case 20:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m20_txt.Text)) ? 0 : Convert.ToDouble(m20_txt.Text);
                            c.procentualno = (m20_cmb.SelectedIndex == 1) ? true : false;
                            break;
                        case 21:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m21_txt.Text)) ? 0 : Convert.ToDouble(m21_txt.Text);
                            c.procentualno = (m21_cmb.SelectedIndex == 1) ? true : false;
                            break;
                        case 22:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m22_txt.Text)) ? 0 : Convert.ToDouble(m22_txt.Text);
                            c.procentualno = (m22_cmb.SelectedIndex == 1) ? true : false;
                            break;
                        case 23:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m23_txt.Text)) ? 0 : Convert.ToDouble(m23_txt.Text);
                            c.procentualno = (m23_cmb.SelectedIndex == 1) ? true : false;
                            break;
                        case 24:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m24_txt.Text)) ? 0 : Convert.ToDouble(m24_txt.Text);
                            c.procentualno = (m24_cmb.SelectedIndex == 1) ? true : false;
                            break;
                        case 25:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m25_txt.Text)) ? 0 : Convert.ToDouble(m25_txt.Text);
                            c.procentualno = (m25_cmb.SelectedIndex == 1) ? true : false;
                            break;
                        case 26:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m26_txt.Text)) ? 0 : Convert.ToDouble(m26_txt.Text);
                            c.procentualno = (m26_cmb.SelectedIndex == 1) ? true : false;
                            break;
                        case 27:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m27_txt.Text)) ? 0 : Convert.ToDouble(m27_txt.Text);
                            c.procentualno = (m27_cmb.SelectedIndex == 1) ? true : false;
                            break;
                        case 28:
                            c.godisnjiRast = (string.IsNullOrWhiteSpace(m28_txt.Text)) ? 0 : Convert.ToDouble(m28_txt.Text);
                            c.procentualno = (m28_cmb.SelectedIndex == 1) ? true : false;
                            break;
                    }
                    c.Zapisi(isGlobal, -1, i);
                }
            }
        }
    }
}
