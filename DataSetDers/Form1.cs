using DataSetDers.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSetDers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.denemeTableAdapter adapter = new DataSet1TableAdapters.denemeTableAdapter();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = adapter.GetDataBy();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adapter.InsertQuery(Ad.Text,Soyad.Text,Tel.Text,Eposta.Text);
            foreach (Control c in panel1.Controls) if (c is TextBox) c.Text = "";
            dataGridView1.DataSource = adapter.GetDataBy();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adapter.UpdateQuery(Ad.Text, Soyad.Text, Tel.Text, Eposta.Text,
                Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            foreach (Control c in panel1.Controls) if (c is TextBox) c.Text = "";
            dataGridView1.DataSource = adapter.GetDataBy();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adapter.DeleteQuery(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            dataGridView1.DataSource = adapter.GetDataBy();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = adapter.ourSeach("%" + textBox1.Text + "%");
        }
    }
}
