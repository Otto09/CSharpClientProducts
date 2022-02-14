using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProducts
{
    public partial class Comments : Form
    {
        public char r;
        Random rand = new Random();

        ServiceReference1.WebService1SoapClient service = new ServiceReference1.WebService1SoapClient();

        public Comments()
        {
            InitializeComponent();

            label1.Text = "Hello! Please fill out the form below.";
            textBox_id_cm.Text = rand.Next(1000).ToString();
        }

        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id_cm = int.Parse(textBox_id_cm.Text);
            int id_cl = int.Parse(textBox_id_cl.Text);
            string comment = richTextBox_description.Text;
            try
            {
                service.AddComments( id_cm,  id_cl, r, comment);
                MessageBox.Show("Your comment has been sent! Thank you!");
            }
            catch
            {
                MessageBox.Show("Technical issue! Please come back later!");
            }
            textBox_id_cm.Clear();
            textBox_id_cl.Clear();

            switch (r)
            {
                case '1': radioButton1.Checked = false; break;
                case '2': radioButton2.Checked = false; break;
                case '3': radioButton3.Checked = false; break;
                case '4': radioButton4.Checked = false; break;
                case '5': radioButton5.Checked = false; break;
            }
            // richTextBox allows us to write text on several lines.
            richTextBox_description.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
