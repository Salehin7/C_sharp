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
    public partial class MyMatchings : Form
    {
        public MyMatchings()
        {
            InitializeComponent();
            getProfile();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void getProfile()
        {
           // SqlDataReader reader = Database.getProfile();

            SqlDataReader reader = Database.GetMatchingByID(int.Parse(SessionData.key["id"]));
            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);

                dataGridView1.DataSource = dt;
            }
            reader.Close();
            Database.conn.Close();
        }
        private void MyMatchings_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
