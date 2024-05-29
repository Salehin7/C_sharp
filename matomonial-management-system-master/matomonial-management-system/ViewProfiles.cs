using matomonial_management_system.databases;
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
    public partial class ViewProfiles : Form
    {
        public ViewProfiles()
        {
            InitializeComponent();
            getProfile();
        }
     
        public void getProfile()
        {
<<<<<<< HEAD
=======
            
>>>>>>> 4185212 (final change)
            SqlDataReader reader = Database.getProfile();
            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);

                dataGridView1.DataSource = dt;
            }
            reader.Close();
        }
<<<<<<< HEAD
   
=======

        private void ViewProfiles_Load(object sender, EventArgs e)
        {

        }
>>>>>>> 4185212 (final change)
    }
}
