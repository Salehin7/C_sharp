using matomonial_management_system.databases;
<<<<<<< HEAD
=======
using matomonial_management_system.Session;
>>>>>>> 4185212 (final change)
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            if(Database.CheckHasProfile() == true)
            {
                materialButton1.Enabled = false;
            }
            else
            {
                viewProfile.Enabled = false;
            }
        }

        private void card1_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            new CreateProfile().Show();
        }

        private void viewProfile_Click(object sender, EventArgs e)
        {
            new ViewProfile().Show();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
           new Edit_Profile().Show();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            new FIndProfile().Show();
        }
<<<<<<< HEAD
=======

        private void materialButton4_Click(object sender, EventArgs e)
        {
            SessionData.key.Remove("id");
            this.Close();
            new Login().Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            new MyMatchings().Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
>>>>>>> 4185212 (final change)
    }
}
