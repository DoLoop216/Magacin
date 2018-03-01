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
    public partial class MessageBoxWithValue : Form
    {
        public bool brojevi = false;
        public bool slova = false;
        public bool znakovi = false;
        public bool razmak = false;

        public double maxBroj = -1;
        public int maxKaraktera = -1;

        public string returnValue;

        public MessageBoxWithValue(string naslov, string opis)
        {
            InitializeComponent();
            this.Text = naslov;
            label1.Text = opis;
        }

        int currentNumber = 0;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!brojevi && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (!slova && char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (!znakovi && char.IsPunctuation(e.KeyChar) || !znakovi && char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (!razmak && char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (maxKaraktera != -1 && (textBox1.Text.Length + 1) > maxKaraktera)
            {
                e.Handled = true;
                return;
            }
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                Uspesno();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Uspesno();
        }

        private void Uspesno()
        {
            if(maxBroj != -1)
            {
                if(maxBroj < Convert.ToInt32(textBox1.Text))
                {
                    MessageBox.Show("Nemoj da pokusavas da prevaris program. Poruka o pokusaju poslata administratorima!");
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
            returnValue = textBox1.Text;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (maxBroj != -1 && Convert.ToDouble(textBox1.Text) > maxBroj)
                {
                    textBox1.Text = currentNumber.ToString();
                }
                else
                {
                    currentNumber = Convert.ToInt32(textBox1.Text);
                }
            }
        }
    }
}
