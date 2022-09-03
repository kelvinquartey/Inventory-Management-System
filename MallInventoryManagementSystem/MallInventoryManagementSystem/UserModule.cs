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
    public partial class UserModule : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NII\Documents\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();

        public UserModule()
        {
            InitializeComponent();
        }

        private void UserModule_Load(object sender, EventArgs e)
        {

        }      

        public void Clear()
        {
            txtBoxFname.Clear();
            txtBoxPhone.Clear();
            txtBoxPword.Clear();
            txtBoxUname.Clear();
            txtBoxCpword.Clear();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtBoxPword.Text != txtBoxCpword.Text)
            {
                MessageBox.Show("Password did not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (MessageBox.Show("Are you sure you want to save this user?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand cm = new SqlCommand("INSERT INTO UserTb(username,fullname,password,phone)VALUES(@username,@fullname,@password,@phone)", con);
                    cm.Parameters.AddWithValue("@username", txtBoxUname.Text);
                    cm.Parameters.AddWithValue("@fullname", txtBoxFname.Text);
                    cm.Parameters.AddWithValue("@password", txtBoxPword.Text);
                    cm.Parameters.AddWithValue("@phone", txtBoxPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been successfully added");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (txtBoxPword.Text != txtBoxCpword.Text)
            {
                MessageBox.Show("Password did not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (MessageBox.Show("Are you sure you want to Edit this user?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand cm = new SqlCommand("UPDATE UserTb SET username=@username,fullname=@fullname,password=@password,phone=@phone WHERE  username LIKE '" + txtBoxUname.Text + "'", con);
                    cm.Parameters.AddWithValue("@username", txtBoxUname.Text);
                    cm.Parameters.AddWithValue("@fullname", txtBoxFname.Text);
                    cm.Parameters.AddWithValue("@password", txtBoxPword.Text);
                    cm.Parameters.AddWithValue("@phone", txtBoxPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been successfully Updated");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
