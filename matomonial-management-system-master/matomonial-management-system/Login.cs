using System;
using System.Windows.Forms;
using matomonial_management_system.databases;
using matomonial_management_system.Session;

namespace matomonial_management_system
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void singup_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SingUP().Show();

        }

        private void forgetbox_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string control = userControlBox.Text;
            string email = emailBox.Text;
            string password = passwordBox.Text;
            int count = Database.login(email, password, control);
            if (control == "Admin")
            {
                if (count == 1)
                {
                    MessageBox.Show("Login successful! ");
                    SessionData.key.Add("id", Database.conn.GetID("admin", email, "id").ToString());
                    this.Hide();
                    new Dashboard().Show();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password. Please try again.");
                }
            }else if(control == "User") 
            {
                if (count == 1)
                {
                    MessageBox.Show("Login successful! ");
                    SessionData.key.Add("id", Database.conn.GetID("users", email, "userID").ToString());
                    this.Hide();
                    new Home().Show();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password. Please try again.");
                }
            }
           
        }

        private void emailBox_TextChanged(object sender, EventArgs e)
        {

        }
<<<<<<< HEAD
=======

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
>>>>>>> 4185212 (final change)
    }
}
