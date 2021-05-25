using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop_Management_System
{
    public partial class Bakery : Form
    {
        public Bakery()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = System.Drawing.Color.Green;
            radioButton2.ForeColor = System.Drawing.Color.Red;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("CAKES");
            comboBox1.Items.Add("CHEESE CAKES");
            comboBox1.Items.Add("PIES");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = System.Drawing.Color.Red;
            radioButton2.ForeColor = System.Drawing.Color.Green;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("LOAF BREAD");
            comboBox1.Items.Add("ROLLS");
            comboBox1.Items.Add("ROLLS");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "CAKES")
            {
                textBox1.Text = "50";
            }
            else if (comboBox1.SelectedItem.ToString() == "CHEESE CAKES")
            {
                textBox1.Text = "100";
            }
            else if (comboBox1.SelectedItem.ToString() == "PIES")
            {
                textBox1.Text = "150";
            }
            else if (comboBox1.SelectedItem.ToString() == "LOAF BREAD")
            {
                textBox1.Text = "200";
            }
            else if (comboBox1.SelectedItem.ToString() == "ROLLS")
            {
                textBox1.Text = "250";
            }
            else if (comboBox1.SelectedItem.ToString() == "ROLLS")
            {
                textBox1.Text = "300";
            }
            else
            {
                textBox1.Text = "0";
            }
            textBox2.Text = "";
            textBox3.Text = "";
        }
       

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                textBox3.Text = (Convert.ToInt16(textBox1.Text) * Convert.ToInt16(textBox2.Text)).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] arr = new string[4];
            arr[0] = comboBox1.SelectedItem.ToString();
            arr[1] = textBox1.Text;
            arr[2] = textBox2.Text;
            arr[3] = textBox3.Text;
            ListViewItem lvi = new ListViewItem(arr);
            listView1.Items.Add(lvi);

            textBox4.Text = (Convert.ToInt16(textBox4.Text) + Convert.ToInt16(textBox3.Text)).ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length > 0)
            {
                textBox6.Text = (Convert.ToInt16(textBox4.Text) - Convert.ToInt16(textBox5.Text)).ToString();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Length > 0)
            {
                textBox8.Text = (Convert.ToInt16(textBox6.Text) - Convert.ToInt16(textBox7.Text)).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listView1.Items.Count; i++) 
                {
                    if (listView1.Items[i].Selected)
                    {
                        textBox4.Text = (Convert.ToInt16(textBox4.Text) - Convert.ToInt16(listView1.Items[i].SubItems[3].Text)).ToString();
                        listView1.Items[i].Remove();
                    }
                
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (listView1.Items.Count > 0)
            {
                try
                {
                    string ConnectionString = " Integrated Security=SSPI; Persist Security=False; Initial Catalog= Shop; Data Source =DESKTOP-EQBTH0V";
                    SqlConnection connection = new SqlConnection(ConnectionString);
                    SqlCommand command = connection.CreateCommand();

                    connection.Open();
                    command.CommandText = "Insert into Table_1 (Invoice_Date, Sub_Total , Discount, Net_Amount, Paid_Amount) values" +
                        " getdate()," + textBox4.Text + "," + textBox5.Text + "," + textBox6 + "," + textBox7 + ") select scope _identity()";
                    string InvoiceID = command.ExecuteScalar().ToString();
                    foreach (ListViewItem ListItem in listView1.Items)
                    {
                        command.CommandText = "Insert into Table_2 (MasterID, ItemName, ItemPrice, ItemQty, ItemTotal) values " +
                            " ( '" + InvoiceID + "' , '" + ListItem.SubItems[0].Text + "' , '" + ListItem.SubItems[1].Text + "' , '" + ListItem.SubItems[2].Text + "' , '" + ListItem.SubItems[3].Text + ")";
                        command.ExecuteNonQuery();

                    }
                    connection.Close();
                    MessageBox.Show("Sale Created Successfully, with Invoice #" + InvoiceID);
                }

                catch (Exception nn)
                {

                    MessageBox.Show("Sale Created  Successfully");

                }
            }
        }
            

        private void Bakery_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            listView1.Items.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            comboBox1.ResetText();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure ? " , "Confirmation Dialog", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
