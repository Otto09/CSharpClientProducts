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
    public partial class Products : Form
    {
        ServiceReference1.WebService1SoapClient service = new ServiceReference1.WebService1SoapClient();
        public static string COD_PROD;
        public Products()
        {
            InitializeComponent();

            label1.Text = "Welcome! Please fill out the form below to create your account ";
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clients w3 = new Clients();
            w3.Show();
            this.Close();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cod_prod = textBox_cod_prod.Text;
            string name = textBox_name.Text;
            int price = int.Parse(textBox_price.Text);
            string availability = textBox_availability.Text;
            string best_seller = textBox_best_seller.Text;
            try
            {
                service.UpdateProducts(cod_prod, name, price, availability, best_seller);
                MessageBox.Show("Your data has been successfully updated!");
            }
            catch
            {
                MessageBox.Show("Technical issue! Please come back later!");
            }
            COD_PROD = cod_prod;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cod_prod = textBox_cod_prod.Text;
            string name = textBox_name.Text;
            int price = int.Parse(textBox_price.Text);
            string availability = textBox_availability.Text;
            string best_seller = textBox_best_seller.Text;
            try
            {
                service.AddProducts(cod_prod, name, price, availability, best_seller);
                MessageBox.Show("Your data has been successfully added!");
            }
            catch
            {
                MessageBox.Show("Technical issue! Please come back later!");
            }
            COD_PROD = cod_prod;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cod_prod = textBox_cod_prod.Text;
            try
            {
                service.DeleteProducts(cod_prod);
                MessageBox.Show("Your data has been deleted! Have a nice day!");
            }
            catch
            {
                MessageBox.Show("Technical issue! Please come back later!");
            }
            textBox_cod_prod.Clear();
        }
    }
}
