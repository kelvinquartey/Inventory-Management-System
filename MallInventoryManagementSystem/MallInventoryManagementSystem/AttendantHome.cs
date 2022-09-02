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
            welcome();
        }


        public void welcome()
        {
            LoginForm loginForm = new LoginForm();
            string username = loginForm.textBoxUsername.Text;
            labelWelcome.Text = username;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            SalesForm salesForm = new SalesForm();
            salesForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TransactionForm transactionForm = new TransactionForm();
            transactionForm.ShowDialog();
        }
    }

}
