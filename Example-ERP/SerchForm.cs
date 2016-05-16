using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Example_ERP
{
    public partial class SerchForm : Form
    {
        public OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Goods.accdb");
        OleDbCommand cmd;
        OleDbDataReader dr;
       
        public SerchForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            cmd = new OleDbCommand();
            cmd.Connection = con;
            
            cmd.CommandText = "SELECT P_ID, P_name, P_type, P_unit, P_Qty, P_Price from Prod_Details WHERE P_ID = " +this.comboBox1.Text +" ";
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.Read()){
                textBox6.Text = dr[0].ToString();
                textBox1.Text = dr[1].ToString(); 
                textBox2.Text = (dr[2].ToString()); 
                textBox3.Text = (dr[3].ToString());
                textBox4.Text = (dr[4].ToString());
                textBox5.Text = (dr[5].ToString()); 

            }
            con.Close();
        }

        private void SerchForm_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd = new OleDbCommand("Select P_ID from Prod_Details", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            { 
                comboBox1.Items.Add(dr["P_ID"].ToString()); 
            } 
            con.Close(); 
  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int c = 0;
            int a = Convert.ToInt32(textBox4.Text);
            int b = Convert.ToInt32(textBox5.Text);
            c = a * b;
            richTextBox1.Text = "Product cost is" + c.ToString();

        }

      
    }
}
