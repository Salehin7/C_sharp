using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using MaterialSkin.Controls;
using matomonial_management_system.Session;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;

namespace matomonial_management_system.databases
{
    internal sealed class Database
    {
        public static DatabaseOperation conn;

        public static void setUp()
        {
            if (conn == null)
            {
                conn = new DatabaseOperation();
            }
        }
        public static SqlCommand sqlcommand(string queryString)
        {
            return conn.SqlCommand(queryString);
        }
        public static SqlDataReader selectAll(string tableName)
        {
            return conn.select(tableName);
        }
        public static int deleteByID(string tableName, int ID)
        {
            return conn.delete(tableName, ID);
        }
        public static int login(string email, string password, string usercontrol)
        {
            string table;
            if (usercontrol == "Admin")
            {
                table = "Admin";
            }
            else
            {
                table = "Users";
            }
            return conn.checkLogin(email, password, table);
        }

        internal static void CreateProfile(int age, double height, string education, string occupation, string gender, string religion, string ethnicity, string matarialStatus, string aboutme)
        {
            conn.CreateProfile(age, height, education, occupation, gender, religion, ethnicity, matarialStatus, aboutme);
        }

        internal static bool CheckHasProfile()
        {
            return conn.HasProfile(int.Parse(SessionData.key["id"]));
        }

        internal static Dictionary<string,string> viewProfile(int id )
        {
           return conn.SelectProfileByID(id);
        }

        internal static void UpdateProfile(int age, double height, string education, string occupation, string gender, string religion, string ethnicity, string matarialStatus, string aboutme)
        {
            conn.UpdateProfile(age, height, education, occupation, gender, religion, ethnicity, matarialStatus, aboutme);
        }
        internal static SqlDataReader getProfile()
        {
           return conn.getProfile();
        }

        internal static SqlDataReader getProfilebyID(int v)
        {
            return conn.getProfilebyID(v);
        }
        internal static void signUp(string name, string email, string phone, string username, string password)
        {
            conn.signUp( name,  email,  phone,  username,  password);
        }

        internal static void insertMarch(int id1, int id2)
        {
            conn.insertMatch(id1,id2);
        }
<<<<<<< HEAD
=======
        internal static SqlDataReader GetMatchingByID(int id)
        {
            return conn.GetMatchingByID(id);
        }
>>>>>>> 4185212 (final change)
    }
}