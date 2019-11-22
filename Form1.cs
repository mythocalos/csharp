using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client; // Oracle Client Library
using System.Configuration;// To Access App Config Attributes
namespace oraclecsharp
{
    public partial class Form1 : Form
    {
        //Object of Oracle Connection Class 
        //its constructor only takes one string parameter which is 
        //since our connection string is in app config file we need to access it using configuration
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //clicking on this button the data will be fetched from the database into gridview
            //this is the object of dataadapter class using this we can fetch complete schema of a table 
            //this works with disconnected environment 
            OracleDataAdapter adp = new OracleDataAdapter("Select * from emp",con);

            //a Datatable to store records 
            DataTable dt = new DataTable();
            //now im going to fetch data
            adp.Fill(dt);//all the data in OracleAdapter will be filled into Datatable 

            dataGridView1.DataSource = dt; //and the datagridview will be filled using datatable
            //lets run it 
           //this is the simplest way to fill datagridview with oracle table 
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //this class is responsible to execute dml commands r you can say this class executes queries
            OracleCommand cmd = new OracleCommand("select ename from emp", con);
            con.Open();
            //reads record return by the query this works with connected environment so first
            //we need to open connection
            OracleDataReader dr = cmd.ExecuteReader();
            while(dr.Read())//it is like cursor it will triverse until the number of records gets 0
            {
                //since datareader consist of object type values we need to convert it
                string ename = dr["ename"].ToString();
                //method to add items into combox
                comboBox1.Items.Add(ename);

            }
            con.Close();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //this class is responsible to execute dml commands r you can say this class executes queries
            OracleCommand cmd = new OracleCommand("select ename from emp", con);
            con.Open();
            //reads record return by the query this works with connected environment so first
            //we need to open connection
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())//it is like cursor it will triverse until the number of records gets 0
            {
                //since datareader consist of object type values we need to convert it
                string ename = dr["ename"].ToString();
                //method to add items into listbox
                listBox1.Items.Add(ename);

            }
            con.Close();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //Since textbox and labels are static controls we can only  display one record so
            //this class is responsible to execute dml commands r you can say this class executes queries
            OracleCommand cmd = new OracleCommand("select ename from emp", con);
            con.Open();
            //reads record return by the query this works with connected environment so first
            //we need to open connection
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())//now it will return only first record
            {
                //since datareader consist of object type values we need to convert it
                string ename = dr["ename"].ToString();
                textBox1.Text = ename; // for textbox
                label1.Text = ename; //for label

            }
            con.Close();
        }
    }
}
