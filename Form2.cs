using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Security.Cryptography.Xml;

namespace yeniproje
{
    public partial class Form2 : Form
    {
        public int cnt = 0;

        public Form2()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string name = textBox1.Text;
                isim_ekle(name);
                textBox1.ResetText();
                cnt++;
                if (cnt >= 20)
                {
                    MessageBox.Show("maximum number of names entered.");
                    textBox1.Dispose();
                }
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (cnt < 15)
            {
                MessageBox.Show("Have to enter at least 15 names");

            }
           else
            {
                this.Hide();
            }
        }
        public void isimler()
        {
            listView1.Columns.Add("İsimler", 17);
        }
        public void isim_ekle(string name)
        {
            listView1.Items.Add(new ListViewItem(name));
        }
    }
}
