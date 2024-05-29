<<<<<<< HEAD
﻿using System;
=======
﻿using matomonial_management_system.Session;
using System;
>>>>>>> 4185212 (final change)
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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            new ViewProfiles().Show();
        }
<<<<<<< HEAD
=======

        private void materialButton1_Click(object sender, EventArgs e)
        {
            SessionData.key.Remove("id");
            this.Close();
            new Login().Show();
        }
>>>>>>> 4185212 (final change)
    }
}
