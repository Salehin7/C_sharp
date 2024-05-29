using matomonial_management_system.databases;
using matomonial_management_system.Session;
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

namespace matomonial_management_system
{
    public partial class Edit_Profile : Form
    {
        public Edit_Profile()
        {
            InitializeComponent();
            Data();
        }
        public void Data()
        {
            Dictionary<string,string> reader = Database.viewProfile(int.Parse(SessionData.key["id"]));
            occupation.Text = reader["occupation"];
            age.Text = reader["age"];
            Height.Text = reader["height"];
            religion.Text = reader["religion"];
            gender.Text = reader["gender"];
            education.Text = reader["education"];
            Ethnicity.Text = reader["ethincity"];
            MatarialStatus.Text = reader["mataril1"];
            aboutme.Text = reader["about_me1"];

        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Submit_Click(object sender, EventArgs e)
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
            Database.UpdateProfile(age1, height1, education1, occupation1, gender1, religion1, ethnicity1, matarialStatus1, aboutme1);
            Data();
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