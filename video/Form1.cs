using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace video
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet2.RentedMovies' table. You can move, or remove it, as needed.
            this.rentedMoviesTableAdapter.Fill(this.database1DataSet2.RentedMovies);
            // TODO: This line of code loads data into the 'database1DataSet1.Movies' table. You can move, or remove it, as needed.
            this.moviesTableAdapter.Fill(this.database1DataSet1.Movies);
            // TODO: This line of code loads data into the 'database1DataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.database1DataSet.Customer);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox5.Text = row.Cells[0].Value.ToString();
               
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataoperation f = new dataoperation();
            bool g=f.updatecustomer(textBox5.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            if (g == true)
            {
                MessageBox.Show("Customer Updated");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataoperation d = new dataoperation();
            bool h=d.addcustomer(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            if (h == true)
            {
                MessageBox.Show("New Cutomer Added");
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataoperation f = new dataoperation();
            f.deletecustomer(textBox5.Text);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                    textBox6.Text = row.Cells[0].Value.ToString();
                    textBox7.Text = row.Cells[1].Value.ToString();
                    textBox8.Text = row.Cells[2].Value.ToString();
                    textBox9.Text = row.Cells[3].Value.ToString();
                    textBox10.Text = row.Cells[4].Value.ToString();
                    textBox11.Text = row.Cells[5].Value.ToString();
                    textBox12.Text = row.Cells[6].Value.ToString();
                    textBox13.Text = row.Cells[7].Value.ToString();


                }
            }
            catch (Exception e1)
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataoperation f = new dataoperation();
            bool g=f.insertnewmovie(textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox11.Text, textBox12.Text, textBox13.Text);
            if (g == true)
            {
                MessageBox.Show("New Movie Inserted");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataoperation d = new dataoperation();
            bool g=d.deletemovie(textBox6.Text);
            if (g == true)
            {
                MessageBox.Show("Movie Deleted");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataoperation f = new dataoperation();
            bool g = f.updatemovie(textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox11.Text, textBox12.Text, textBox13.Text);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];

                textBox14.Text = row.Cells[0].Value.ToString();

                textBox15.Text = row.Cells[1].Value.ToString();
                textBox16.Text = row.Cells[2].Value.ToString();
                textBox17.Text = row.Cells[3].Value.ToString();
                textBox18.Text = row.Cells[4].Value.ToString();


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataoperation d = new dataoperation();
           bool f= d.issuemovie(textBox15.Text, textBox16.Text, textBox17.Text);
           if (f == true)
           {
               MessageBox.Show("Movie Issued");
           }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataoperation d = new dataoperation();
            bool f = d.returnmovie(textBox14.Text, textBox18.Text);
            if (f == true)
                        {
                            MessageBox.Show("Movie retunrned");
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataoperation d = new dataoperation();
            DataSet f = d.showcurrent();
            dataGridView4.DataSource = f.Tables[0];
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataoperation d = new dataoperation();
            DataSet f1 = d.mostpopular();
            dataGridView4.DataSource = f1.Tables[0];
        }
    }
}
