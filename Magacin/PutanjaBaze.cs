using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Magacin
{
    public partial class PutanjaBaze : Form
    {
        public PutanjaBaze()
        {
            InitializeComponent();
        }

        private void PutanjaBaze_Load(object sender, EventArgs e)
        {
            if (File.Exists(M.Podesavanja.path_podesavanja))
            {
                string[] lines = File.ReadAllLines(M.Podesavanja.path_podesavanja);
                foreach (string line in lines)
                {
                    string[] data = line.Split('|');
                    switch (data[0])
                    {
                        case "Putanja baze magacin 2018":
                            putanjaMagacin_txt.Text = String.Format("{0}|{1}|{2}|{3}", data[1], data[2], data[3], data[4]);
                            break;
                        case "Putanja baze komercijalno":
                            putanjaKomercijalno2018_txt.Text = String.Format("{0}|{1}|{2}|{3}", data[1], data[2], data[3], data[4]);
                            break;
                        case "Putanja baze komercijalno 2017":
                            putanjaKomercijalno2017_txt.Text = String.Format("{0}|{1}|{2}|{3}", data[1], data[2], data[3], data[4]);
                            break;
                        case "Putanja baze komercijalno 2016":
                            putanjaKomercijalno2016_txt.Text = String.Format("{0}|{1}|{2}|{3}", data[1], data[2], data[3], data[4]);
                            break;
                        case "Putanja baze komercijalno 2015":
                            putanjaKomercijalno2015_txt.Text = String.Format("{0}|{1}|{2}|{3}", data[1], data[2], data[3], data[4]);
                            break;
                    }
                }
            }
        }

        private void podesi_btn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(putanjaMagacin_txt.Text))
            {
                MessageBox.Show("Niste uneli putanju za bazu MAGACIN-a!");
                return;
            }
            if(string.IsNullOrWhiteSpace(putanjaKomercijalno2018_txt.Text))
            {
                MessageBox.Show("Niste uneli putanju za bazu KOMERCIJALNO 2018!");
                return;
            }
            if (string.IsNullOrWhiteSpace(putanjaKomercijalno2018_txt.Text))
            {
                MessageBox.Show("Niste uneli putanju za bazu KOMERCIJALNO 2017!");
                return;
            }
            if (string.IsNullOrWhiteSpace(putanjaKomercijalno2017_txt.Text))
            {
                MessageBox.Show("Niste uneli putanju za bazu KOMERCIJALNO 2016!");
                return;
            }
            if (string.IsNullOrWhiteSpace(putanjaKomercijalno2016_txt.Text))
            {
                MessageBox.Show("Niste uneli putanju za bazu KOMERCIJALNO 2015!");
                return;
            }
            if (File.Exists(M.Podesavanja.path_podesavanja))
            {
                string[] lines = File.ReadAllLines(M.Podesavanja.path_podesavanja);
                string[] tempFile;
                int i = 0;
                bool c1 = false;
                bool c2 = false;
                bool c3 = false;
                bool c4 = false;
                bool c5 = false;
                foreach (string line in lines)
                {
                    string[] data = line.Split('|');
                    switch (data[0])
                    {
                        case "Putanja baze magacin":
                            lines[i] = String.Format("Putanja baze magacin|{0}", putanjaMagacin_txt.Text);
                            c1 = true;
                            break;
                        case "Putanj baze komercijalno 2018":
                            lines[1] = String.Format("Putanja baze komercijalno 2018|{0}", putanjaKomercijalno2018_txt.Text);
                            c2 = true;
                            break;
                        case "Putanj baze komercijalno 2017":
                            lines[1] = String.Format("Putanja baze komercijalno 2017|{0}", putanjaKomercijalno2017_txt.Text);
                            c3 = true;
                            break;
                        case "Putanj baze komercijalno 2016":
                            lines[1] = String.Format("Putanja baze komercijalno 2016|{0}", putanjaKomercijalno2016_txt.Text);
                            c4 = true;
                            break;
                        case "Putanj baze komercijalno 2015":
                            lines[1] = String.Format("Putanja baze komercijalno 2015|{0}", putanjaKomercijalno2015_txt.Text);
                            c5 = true;
                            break;
                    }
                    i++;
                }
                if(!c1)
                {
                    tempFile = new string[lines.Length + 1];
                    lines.CopyTo(tempFile, 0);
                    tempFile[tempFile.Length - 1] = String.Format("Putanja baze magacin|{0}", putanjaMagacin_txt.Text);
                    lines = tempFile;
                }
                if(!c2)
                {
                    tempFile = new string[lines.Length + 1];
                    lines.CopyTo(tempFile, 0);
                    tempFile[tempFile.Length - 1] = String.Format("Putanja baze komercijalno 2018|{0}", putanjaKomercijalno2018_txt.Text);
                    lines = tempFile;
                }
                if (!c3)
                {
                    tempFile = new string[lines.Length + 1];
                    lines.CopyTo(tempFile, 0);
                    tempFile[tempFile.Length - 1] = String.Format("Putanja baze komercijalno 2017|{0}", putanjaKomercijalno2017_txt.Text);
                    lines = tempFile;
                }
                if (!c4)
                {
                    tempFile = new string[lines.Length + 1];
                    lines.CopyTo(tempFile, 0);
                    tempFile[tempFile.Length - 1] = String.Format("Putanja baze komercijalno 2016|{0}", putanjaKomercijalno2016_txt.Text);
                    lines = tempFile;
                }
                if (!c5)
                {
                    tempFile = new string[lines.Length + 1];
                    lines.CopyTo(tempFile, 0);
                    tempFile[tempFile.Length - 1] = String.Format("Putanja baze komercijalno 2015|{0}", putanjaKomercijalno2015_txt.Text);
                    lines = tempFile;
                }
                File.WriteAllLines(M.Podesavanja.path_podesavanja, lines);
            }
            else
            {
                string[] newFile = new string[5];
                newFile[0] = String.Format("Putanja baze magacin|{0}", putanjaMagacin_txt.Text);
                newFile[1] = String.Format("Putanja baze komercijalno 2018|{0}", putanjaKomercijalno2018_txt.Text);
                newFile[2] = String.Format("Putanja baze komercijalno 2017|{0}", putanjaKomercijalno2017_txt.Text);
                newFile[3] = String.Format("Putanja baze komercijalno 2016|{0}", putanjaKomercijalno2016_txt.Text);
                newFile[4] = String.Format("Putanja baze komercijalno 2015|{0}", putanjaKomercijalno2015_txt.Text);
                File.WriteAllLines(M.Podesavanja.path_podesavanja, newFile);
            }
            this.Close();
        }
    }
}
