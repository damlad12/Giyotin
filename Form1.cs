using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.Xml;

namespace yeniproje
{
    public partial class Form1 : Form
    {
        private List<Label> labels = new List<Label>();

        private Form2 form2 = new Form2();


        private readonly Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();

        }

        public async void display_names()
        {

            System.Drawing.Color[] colors = { System.Drawing.Color.Green, System.Drawing.Color.Purple, System.Drawing.Color.DarkOrange,
            System.Drawing.Color.DarkGreen, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.DarkMagenta};


            if (form2.DialogResult == DialogResult.OK)
            {
                for (int i = 0; i < form2.listView1.Items.Count; i++)
                {
                    for (int j = 0 ; j < 10; j++)
                    {
                        labels.Add(new Label());
                        labels[labels.Count()-1].Text = form2.listView1.Items[i].Text;
                        labels[labels.Count()-1].ForeColor = colors[rnd.Next(0, colors.Length)];
                        labels[labels.Count()-1].BackColor = Color.Transparent;
                        labels[labels.Count()-1].Location = new System.Drawing.Point(rnd.Next(0, this.Size.Width), rnd.Next(0, this.Size.Height));  
                    }
                }
            }

            //form2.Close();

            for (int i = 0; i < labels.Count(); i++)
            {
                this.Controls.Add(labels[i]);
                await Task.Delay(20);
            }

            await Task.Delay(1600);
            deletelabels(labels);
        }

        public async void deletelabels(List<Label> labels)
        {

            //double x = 2;
            double x = 1;
            double wait_time = 10;
            while (labels.Count() >= 2)
            {
                wait_time = (10 + Math.Pow(2, x));
                x += 0.048;
                int ind_secilen2 = rnd.Next(0, labels.Count());
                Label label_secilen2 = labels[ind_secilen2];
                labels.Remove(label_secilen2);
                Controls.Remove(label_secilen2);
                label_secilen2.Dispose();
                if (labels.Count != 1)
                {
                    await Task.Delay((int)wait_time);
                }
            }
            if (labels.Count() != 0 && labels[0].Text != "")
            {
               label1.Text = labels[0].Text;
            }
           // label1.Text = labels.Count().ToString();
            Label son = labels[0];
            labels.Remove(son);
            Controls.Remove(son);
            son.Dispose();
            label1.Visible = true;
            form2.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form2.ShowDialog();
            form2.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controls.Remove(button1);
            Controls.Remove(button2);
            button1.Dispose();
            button2.Dispose();
            display_names();

        }
        private void label1_Click(object sender, EventArgs e)
        {


        }



    }
}
