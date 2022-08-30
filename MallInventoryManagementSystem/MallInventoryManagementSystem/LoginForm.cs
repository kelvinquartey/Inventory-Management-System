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

namespace MallInventoryManagementSystem
{
    public partial class LoginForm : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NII\Documents\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxShowPassword.Checked == true)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else if (checkBoxShowPassword.Checked == false)
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (radioBtnAdmin.Checked == true)
            {
                try
                {
                    cm = new SqlCommand("SELECT * FROM AdminTb WHERE username=@username AND password=@password", con);
                    cm.Parameters.AddWithValue("@username", textBoxUsername.Text);
                    cm.Parameters.AddWithValue("@password", textBoxPassword.Text);
                    con.Open();
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        MessageBox.Show("Welcome Admin", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AdminHome ff = new AdminHome();
                        this.Hide();
                        ff.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password!", "TRY AGAIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (radioBtnAttendant.Checked == true)
            {
                try
                {
                    cm = new SqlCommand("SELECT * FROM UserTb WHERE username=@username AND password=@password", con);
                    cm.Parameters.AddWithValue("@username", textBoxUsername.Text);
                    cm.Parameters.AddWithValue("@password", textBoxPassword.Text);
                    con.Open();
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        MessageBox.Show("Welcome" + dr["fullname"].ToString() + " | ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AttendantHome ff = new AttendantHome();
                        this.Hide();
                        ff.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password!", "TRY AGAIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else
            {
                MessageBox.Show("Please Select a field", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
