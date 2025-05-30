﻿using System;
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
    public partial class SignupS : Form
    {
        public SignupS()
        {
            InitializeComponent();
        }

        private void signupbtn_Click(object sender, EventArgs e)
        {
            {
                string fname = fnameTB.Text;
                string lname = lnameTB.Text;
                string email = EmailTB.Text;
                string password = PasswordTB.Text;
                string contact = usernameTB.Text;


                using (SqlConnection con = new SqlConnection(@"data source=DESKTOP-GO96BDE\SQLEXPRESS;initial catalog=Kahreedo;integrated security=True;"))
                {
                    con.Open();
                    string query = "INSERT INTO desktopSupplier (Firstname, Lastname, Email, Password, Contactno) VALUES (@firstname, @lastname, @email, @password, @contactno)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@firstname", fname);
                    cmd.Parameters.AddWithValue("@lastname", lname);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@contactno", contact);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Signup successful!");
                    this.Hide();
                    LoginS loginForm = new LoginS();
                    loginForm.Show();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginS mainForm = new LoginS();
            mainForm.Show();
            this.Hide();
        }
    }
}
