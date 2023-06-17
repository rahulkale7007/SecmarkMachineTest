using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SeckmarkWin
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "insert into Employee values(@emp_code,@emp_Name,@emp_Dept)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@emp_code", txt2.Text);
                cmd.Parameters.AddWithValue("@emp_Name", txt3.Text);
                cmd.Parameters.AddWithValue("@emp_Dept", txt4.Text);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if(result == 1)
                {
                    MessageBox.Show("Record Inserted");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from Employee";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr = cmd.ExecuteReader(); // fire the select query
                if (dr.HasRows)
                {
                    DataTable table = new DataTable();
                    table.Load(dr);
                    dataGridView1.DataSource = table;
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // step 7
                con.Close();
            }

        }
    }
}
