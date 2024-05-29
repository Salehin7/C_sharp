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
    public partial class ViewProfile : Form
    {
        public ViewProfile()
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
            Dictionary<string, string> reader = Database.viewProfile(int.Parse(SessionData.key["id"]));

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
}
