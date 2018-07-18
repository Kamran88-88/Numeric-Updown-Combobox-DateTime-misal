using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Product> list = new List<Product>() { new Product() { Name = "Alma", Count = 10 }, new Product() { Name = "Armud", Count = 15 }, new Product() { Name = "Qarpiz", Count = 11 } };

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now.AddDays(5);
            comboBox1.Items.AddRange(list.Select(x => x.Name).ToArray());

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var SearchedPr = list.SingleOrDefault(x => x.Name == comboBox1.Text);
            numericUpDown1.Maximum = SearchedPr.Count;
            numericUpDown1.Value = SearchedPr.Count;

            if (SearchedPr.Count == 0)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var SearchedPr = list.SingleOrDefault(x => x.Name == comboBox1.Text);

            //if (Convert.ToInt32(numericUpDown1.Text) > SearchedPr.Count)
            //{
            //    MessageBox.Show("tor");
            //}
            if (numericUpDown1.Value <= SearchedPr.Count)
            {
                SearchedPr.Count -= Convert.ToInt32(numericUpDown1.Value);
                comboBox1.Text = "";
                numericUpDown1.Value = 0;
            }
        }
    }

    class Product
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
