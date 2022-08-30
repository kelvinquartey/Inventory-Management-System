using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MallInventoryManagementSystem
{
    public partial class AttendantHome : Form
    {
        public AttendantHome()
        {
            InitializeComponent();
        }


        public void welcome()
        {
            LoginForm loginForm = new LoginForm();
            string username = loginForm.textBoxUsername.Text;
            labelWelcome.Text = username;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
