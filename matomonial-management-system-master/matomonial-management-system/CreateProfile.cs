using MaterialSkin.Controls;
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
    public partial class CreateProfile : Form
    {
        public CreateProfile()
        {
            InitializeComponent();
        }

        private void CreateProfile_Load(object sender, EventArgs e)
        {

        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void materialTextBox24_Click(object sender, EventArgs e)
        {

        }

        private void materialTextBox25_Click(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            validationForm();
            int age1 = int.Parse(age.Text);
            double height1 = Double.Parse(Height.Text);
            string education1 = education.Text;
            string occupation1 = occupation.Text;
            string gender1 = gender.Text;
            string religion1 = religion.Text;
            string ethnicity1 = Ethnicity.Text;
            string matarialStatus1 = MatarialStatus.Text;
            string aboutme1 = aboutme.Text;
            Database.CreateProfile(age1, height1, education1, occupation1, gender1, religion1, ethnicity1, matarialStatus1, aboutme1);
        }

        private void materialTextBox21_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel8_Click(object sender, EventArgs e)
        {

        }

        private void Ethnicity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void validationForm()
        {
            if (age.Text == "")
            {
                MessageBox.Show("Age can not be empty");
            }
            if (Height.Text == "")
            {
                MessageBox.Show("Height can not be empty");
            }
            if (education.Text == "")
            {
                MessageBox.Show("education can not be empty");
            }
            if (occupation.Text == "")
            {
                MessageBox.Show("occupation can not be empty");
            }
            if (gender.Text == "")
            {
                MessageBox.Show("gender can not be empty");
            }
            if (religion.Text == "")
            {
                MessageBox.Show("religion can not be empty");
            }
            if (Ethnicity.Text == "")
            {
                MessageBox.Show("Ethnicity can not be empty");
            }
            if (MatarialStatus.Text == "")
            {
                MessageBox.Show("Matarial Status can not be empty");
            }
        }
    }
}
