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
    public partial class Clients : Form
    {
        ServiceReference1.WebService1SoapClient service = new ServiceReference1.WebService1SoapClient();
        Random rand = new Random();
        public Clients()
        {
            InitializeComponent();

            label1.Text = "Please fill in your name, address and phone!";

            textBox_id_cl.Text = rand.Next(1000).ToString();
            textBox_cod_prod.Text = Products.COD_PROD;
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Completion w4 = new Completion();
            w4.Show();
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id_cl = int.Parse(textBox_id_cl.Text);
            string cod_prod = textBox_cod_prod.Text;
            string name = textBox_name.Text;
            string address = textBox_address.Text;
            string phone = textBox_phone.Text;
            try
            {
                service.AddClients(id_cl, cod_prod, name, address, phone);
                MessageBox.Show("Your data has been saved successfully!");
            }
            catch
            {
                MessageBox.Show("Technical issue! Please come back later!");
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id_cl = int.Parse(textBox_id_cl.Text);
            string cod_prod = textBox_cod_prod.Text;
            string name = textBox_name.Text;
            string address = textBox_address.Text;
            string phone = textBox_phone.Text;
            try
            {
                service.UpdateClients(id_cl, name, address, phone);
                MessageBox.Show("Your data has been updated successfully!");
            }
            catch
            {
                MessageBox.Show("Technical issue! Please come back later!");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id_cl = int.Parse(textBox_id_cl.Text);
            try
            {
                service.DeleteClients(id_cl);
                MessageBox.Show("Your data has been deleted! We wish you a good day!");
            }
            catch
            {
                MessageBox.Show("Technical issue! Please come back later!");
            }
            textBox_id_cl.Clear();
        }
    }
}
