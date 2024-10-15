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
    public partial class ordersS : Form
    {
        public ordersS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard mainForm = new Dashboard();
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
                string query = "SELECT * FROM [Order]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                GridView1.DataSource = dataTable;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ordersS mainForm = new ordersS();
            mainForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            main mainForm = new main();
            mainForm.Show();
            this.Hide();
        }
    }
}
