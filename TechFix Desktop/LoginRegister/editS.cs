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
    public partial class editS : Form
    {
        public editS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {
            main mainForm = new main();
            mainForm.Show();
            this.Hide();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"data source=DESKTOP-GO96BDE\SQLEXPRESS;initial catalog=Kahreedo;integrated security=True;"))
            {
                con.Open();
                string query = "SELECT * FROM Products WHERE [Name] = @Name";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", searchTextBox.Text); // Search by product name

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // If product is found
                {
                    pnameTB.Text = reader["Name"].ToString();
                    upriceTB.Text = reader["UnitPrice"].ToString();
                    opriceTB.Text = reader["OldPrice"].ToString();
                    imgurlTB.Text = reader["ImageURL"].ToString();
                    sdTB.Text = reader["ShortDescription"].ToString();
                    comboBox3.SelectedItem = reader["QuantityPerUnit"].ToString();
                    comboBox1.SelectedItem = reader["UnitWeight"].ToString();
                    comboBox2.SelectedItem = reader["Size"].ToString();
                    comboBox4.SelectedItem = reader["SupplierID"].ToString();
                    comboBox5.SelectedItem = reader["CategoryID"].ToString();
                    comboBox6.SelectedItem = reader["SubCategoryID"].ToString();
                }
                else
                {
                    MessageBox.Show("Product not found!");
                }
                reader.Close();
            }
        }

        private void addBT_Click(object sender, EventArgs e)
        {
            {
                using (SqlConnection con = new SqlConnection(@"data source=DESKTOP-GO96BDE\SQLEXPRESS;initial catalog=Kahreedo;integrated security=True;"))
                {
                    con.Open();
                    string query = "INSERT INTO Products (Name, SupplierID, CategoryID, SubCategoryID, QuantityPerUnit, UnitPrice, OldPrice, UnitWeight, Size, ImageURL, ShortDescription) " +
                                   "VALUES (@Name, @SupplierID, @CategoryID,@SubCategoryID, @QuantityPerUnit, @UnitPrice, @OldPrice, @UnitWeight, @Size, @ImageURL, @ShortDescription)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", pnameTB.Text);
                    cmd.Parameters.AddWithValue("@SupplierID", comboBox4.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CategoryID", comboBox5.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SubCategoryID", comboBox6.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@QuantityPerUnit", comboBox3.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@UnitPrice", decimal.Parse(upriceTB.Text));
                    cmd.Parameters.AddWithValue("@OldPrice", decimal.Parse(opriceTB.Text));
                    cmd.Parameters.AddWithValue("@UnitWeight", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Size", comboBox2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ImageURL", imgurlTB.Text);
                    cmd.Parameters.AddWithValue("@ShortDescription", sdTB.Text);



                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product inserted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Insert failed!");
                    }
                }
            }
        }

        private void updateBT_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"data source=DESKTOP-GO96BDE\SQLEXPRESS;initial catalog=Kahreedo;integrated security=True;"))
            {
                con.Open();
                string query = "UPDATE Products SET UnitPrice = @UnitPrice, SupplierID = @SupplierID, CategoryID = @CategoryID, SubCategoryID = @SubCategoryID, OldPrice = @OldPrice, ImageURL = @ImageURL, " +
                               "ShortDescription = @ShortDescription, QuantityPerUnit = @QuantityPerUnit, UnitWeight = @UnitWeight, Size = @Size " +
                               "WHERE Name = @Name";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", pnameTB.Text);
                cmd.Parameters.AddWithValue("@SupplierID", comboBox4.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@CategoryID", comboBox5.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@SubCategoryID", comboBox6.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@UnitPrice", decimal.Parse(upriceTB.Text));
                cmd.Parameters.AddWithValue("@OldPrice", decimal.Parse(opriceTB.Text));
                cmd.Parameters.AddWithValue("@ImageURL", imgurlTB.Text);
                cmd.Parameters.AddWithValue("@ShortDescription", sdTB.Text);
                cmd.Parameters.AddWithValue("@QuantityPerUnit", comboBox3.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@UnitWeight", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Size", comboBox2.SelectedItem.ToString());

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product updated successfully!");
                }
                else
                {
                    MessageBox.Show("Update failed!");
                }
            }
        }

        private void deleteBT_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"data source=DESKTOP-GO96BDE\SQLEXPRESS;initial catalog=Kahreedo;integrated security=True;"))
            {
                con.Open();
                string query = "DELETE FROM Products WHERE Name = @Name";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", pnameTB.Text);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Delete failed!");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Clear all TextBoxes
            pnameTB.Clear();
            upriceTB.Clear();
            opriceTB.Clear();
            imgurlTB.Clear();
            sdTB.Clear();
            searchTextBox.Clear();

            // Clear all ComboBoxes (setting them to null or default value)
            comboBox1.SelectedIndex = -1; // Clear selection for comboBox1 (UnitWeight)
            comboBox2.SelectedIndex = -1; // Clear selection for comboBox2 (Size)
            comboBox3.SelectedIndex = -1; // Clear selection for comboBox3 (QuantityPerUnit)
            comboBox4.SelectedIndex = -1; // Clear selection for comboBox4 (Supplier)
            comboBox5.SelectedIndex = -1; // Clear selection for comboBox5 (Category)
            comboBox6.SelectedIndex = -1; // Clear selection for comboBox6 (SubCategory)
        }
    }
}
