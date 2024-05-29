using matomonial_management_system.databases;
using matomonial_management_system.Session;
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
    public partial class ViewProfileMatch : Form
    {
        private int id;
        public ViewProfileMatch(int id)
        {
            InitializeComponent();
            age.Enabled = false;
            Height.Enabled = false;
            education.Enabled = false;
            religion.Enabled = false;
            occupation.Enabled = false;
            gender.Enabled = false;
            aboutme.Enabled = false;
            Ethnicity.Enabled = false;
            MatarialStatus.Enabled = false;
            materialComboBox1.Enabled = false;
            Dictionary<string, string> reader = Database.viewProfile(id);
            this.id = id;
            if(reader == null )
            {
                new FIndProfile().Show();
            }
            else
            {
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

        }

        private void ViewProfileMatch_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Database.insertMarch(int.Parse(SessionData.key["id"]), this.id);
        }
    }
}
