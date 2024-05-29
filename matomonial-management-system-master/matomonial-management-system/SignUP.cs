using matomonial_management_system.databases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matomonial_management_system
{
    public partial class SingUP : Form
    {
        public SingUP()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void singIN_Click(object sender, EventArgs e)
        {
            if (Validatation() == false) { return ; }
            Database.signUp(nameBox.Text,emailbox.Text,phoneBox.Text,usernameBox.Text,password.Text);
        }
        public bool Validatation()
        {
            if (string.IsNullOrEmpty(nameBox.Text))
            {
                MessageBox.Show("Name can not be empty! ");
                return false;
            }

            if (string.IsNullOrEmpty(emailbox.Text))
            {
                MessageBox.Show("email can not be empty! ");
                return false;
            }

            if (string.IsNullOrEmpty(phoneBox.Text))
            {
                MessageBox.Show("phone number can not be empty! ");
                return false;
            }
            if (string.IsNullOrEmpty(usernameBox.Text))
            {
                MessageBox.Show("username can not be empty! ");
                return false;
            }

            if (string.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show("password can not be empty! ");
                return false;
            }
            if (string.IsNullOrEmpty(confrimPasswordBox.Text))
            {
                MessageBox.Show("confrim Password can not be empty! ");
                return false;
            }
            if(confrimPasswordBox.Text != password.Text)
            {
                MessageBox.Show("confrim password and password should be same ");
                return false;
            }

            return true;

        }
<<<<<<< HEAD
=======

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
>>>>>>> 4185212 (final change)
    }
}
