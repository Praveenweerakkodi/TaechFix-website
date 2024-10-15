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

namespace LoginRegister
{
    public partial class inventoryS : Form
    {
        public inventoryS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard mainForm = new Dashboard();
            mainForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ordersS mainForm = new ordersS();
            mainForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            inventoryS mainForm = new inventoryS();
            mainForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"data source=DESKTOP-GO96BDE\SQLEXPRESS;initial catalog=Kahreedo;integrated security=True;"))
            {
                con.Open();
                string query = "SELECT * FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                GridView1.DataSource = dataTable;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            
                using (SqlConnection con = new SqlConnection(@"data source=DESKTOP-GO96BDE\SQLEXPRESS;initial catalog=Kahreedo;integrated security=True;"))
                {
                    con.Open();

                    // SQL query to search for the name entered in the searchTextBox
                    string query = "SELECT * FROM Products WHERE Name LIKE @Name";
                    SqlCommand cmd = new SqlCommand(query, con);

                    // Use LIKE to allow partial matching (e.g. "abc%")
                    cmd.Parameters.AddWithValue("@Name", "%" + searchTextBox.Text + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    // Fill the dataTable with the results from the database
                    adapter.Fill(dataTable);

                    // Display the results in the DataGridView (assuming your grid view name is dataGridView1)
                    GridView1.DataSource = dataTable;

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No records found!");
                    }
                }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            main mainForm = new main();
            mainForm.Show();
            this.Hide();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            editS mainForm = new editS();
            mainForm.Show();
            this.Hide();
        }
    }
}
