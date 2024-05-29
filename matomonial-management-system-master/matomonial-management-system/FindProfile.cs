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
    public partial class FIndProfile : Form
    {
        public FIndProfile()
        {
            InitializeComponent();
            getProfile();
        }

  
        public void getProfile()
        {
            SqlDataReader reader = Database.getProfile();
            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);

                dataGridView1.DataSource = dt;
            }
            reader.Close();
            Database.conn.Close(); 
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            
            int id = int.Parse(userIDBox.Text);
            new ViewProfileMatch(id).Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FIndProfile_Load(object sender, EventArgs e)
        {

        }
    }
}
