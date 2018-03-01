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
    public partial class Kviz_Grupe : Form
    {
        public Kviz_Grupe()
        {
            InitializeComponent();
        }

        private void Kviz_Grupe_Load(object sender, EventArgs e)
        {
            Ucitaj();
        }

        private void Ucitaj()
        {
            treeView1.Nodes.Clear();
            List<Int_String> grupe = new List<Int_String>();
            grupe = Kviz.UcitajGrupe();

            foreach (Int_String item in grupe)
            {
                TreeNode node = new TreeNode(item._string);
                node.Tag = item._int;
                treeView1.Nodes.Add(node);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Morate uneti naziv grupe!");
                return;
            }
            
            if(Kviz.GrupaPostoji(textBox1.Text))
            {
                MessageBox.Show("Grupa sa tim nazivom vec postoji!");
            }

            Kviz.DodajGrupu(textBox1.Text, formaKviza_cmb.SelectedItem.ToString(), (int)numericUpDown1.Value);
            Ucitaj();
        }
        private void izmeniGrupuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode == null)
                return;

            Kviz_Grupa kg = new Kviz_Grupa(Convert.ToInt32(treeView1.SelectedNode.Tag), treeView1.SelectedNode.Text);
            kg.ShowDialog();
            Ucitaj();
        }
        private void obrisiGrupuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;

            Kviz.ObrisiGrupu(Convert.ToInt32(treeView1.SelectedNode.Tag));
            Ucitaj();
        }
    }
}
