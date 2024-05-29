using matomonial_management_system.Interfaces;
using matomonial_management_system.Session;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace matomonial_management_system.databases
{
    internal class DatabaseOperation : DatabaseInterface
    {
        private SqlConnection conn = DatabaseConnection.Instance.Connection;

  
        public SqlCommand SqlCommand(String query)
        {
            SqlCommand command = new SqlCommand(query, conn);
            return command;
        }
        public int delete(string tableName,int ID)
        {
            string deleteQuery = "DELETE FROM User WHERE ID = @ID";
            SqlCommand delete =this.SqlCommand(deleteQuery);
            delete.Parameters
                  .AddWithValue("@ID", ID);
            return delete.ExecuteNonQuery();
        }

        public int deleteAll()
        {
            return 0;
        }

        public void insert()
        {
           
        }

        public SqlDataReader select(string tableName)
        {
            string selectQuery = "SELECT * FROM "+tableName;
            //this.SqlCommand(selectQuery);

            SqlDataReader reader = this.SqlCommand(selectQuery).ExecuteReader();
            return reader;
        }

        public void update()
        {
        
        }

        internal int checkLogin(string email, string password, string table)
        {
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM " + table + " WHERE email=@email AND password=@password", conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }
        internal int GetID(string table,string email,string FieldName)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT "+ FieldName + " FROM " + table + " WHERE email=@email", conn);
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataReader reader = cmd.ExecuteReader();
                int id;
                while (reader.Read())
                {
                     id = reader.GetInt32(0);

                    return id;
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }
<<<<<<< HEAD
       public void  CreateProfile(int age, double height, string education, string occupation, string gender, string religion, string ethnicity, string matarialStatus, string aboutme)
       {
            string query = "INSERT INTO Profiles (UserID, gender, age, Religion, Occupation, Education, Height, MaritalStatus, about_me, ethnicity) \r\nVALUES (@UserID, @gender, @age, @Religion, @Occupation, @Education, @Height, @MaritalStatus, @about_me, @ethnicity)";
=======

        internal SqlDataReader GetMatchingByID(int id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT users.userid,username,name,email,phone FROM users INNER JOIN Matching ON users.UserID = Matching.User2ID WHERE Matching.User1ID = @UserID", conn);
                cmd.Parameters.AddWithValue("@UserID", id);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return null;
        }

        public void  CreateProfile(int age, double height, string education, string occupation, string gender, string religion, string ethnicity, string matarialStatus, string aboutme)
       {
            string query = "INSERT INTO Profiles (UserID, gender, age, Religion, Occupation, Education, Height, MaritalStatus, about_me, ethnicity) VALUES (@UserID, @gender, @age, @Religion, @Occupation, @Education, @Height, @MaritalStatus, @about_me, @ethnicity)";
>>>>>>> 4185212 (final change)
            conn.Open();
            // Create a new command based on the query and connection
            SqlCommand command = new SqlCommand(query, conn);

            // Add parameter values to the command
            command.Parameters.AddWithValue("@UserID", SessionData.key["id"]);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@age", age);
            command.Parameters.AddWithValue("@Religion", religion);
            command.Parameters.AddWithValue("@Occupation", occupation);
            command.Parameters.AddWithValue("@Education", education);
            command.Parameters.AddWithValue("@Height", height);
            command.Parameters.AddWithValue("@MaritalStatus", matarialStatus);
            command.Parameters.AddWithValue("@about_me", aboutme);
            command.Parameters.AddWithValue("@ethnicity", ethnicity);

<<<<<<< HEAD
            // Execute the query
=======
            // Execute the queryss
>>>>>>> 4185212 (final change)
            int result = command.ExecuteNonQuery();
            conn.Close();
            // Check if the insert was successful
            if (result > 0)
            {
                MessageBox.Show("Data upated successfully.");
            }
            else
            {
                MessageBox.Show("Failed to update data.");
            }
        }
        internal int getID1(string table, int id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT UserID FROM " + table + " WHERE UserID=@UserID", conn);
                cmd.Parameters.AddWithValue("@UserID", id);
                SqlDataReader reader = cmd.ExecuteReader();
                int id1;
                while (reader.Read())
                {
                    id1 = reader.GetInt32(0);

                    return id1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }
        internal bool HasProfile(int id)
        {
            int x= getID1("profiles", id); 
            if (x > 0) { 
                return true;
            }
            return false;
        }

        internal Dictionary<string,string> SelectProfileByID(int id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Profiles WHERE UserID=@UserID", conn);
                cmd.Parameters.AddWithValue("@UserID", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dictionary<string,string> profile = new Dictionary<string,string>();
                    profile.Add("gender", reader.GetString(2));
                    profile.Add("age",reader.GetInt32(3).ToString());
                    profile.Add("height", reader.GetDouble(4).ToString());
                    profile.Add("education", reader.GetString(5).ToString());
                    profile.Add("occupation", reader.GetString(6));
                    profile.Add("religion", reader.GetString(7));
                    profile.Add("ethincity", reader.GetString(8));
                    profile.Add("mataril1", reader.GetString(9));
                    profile.Add("about_me1", reader.GetString(10));
                    return profile;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        internal void UpdateProfile(int age, double height, string education, string occupation, string gender, string religion, string ethnicity, string matarialStatus, string aboutme)
        {
            try
            {
                conn.Open();
                string query = "UPDATE Profiles SET gender = @gender,age = @age,Religion = @Religion,Occupation = @Occupation,Education = @Education, Height = @Height, MaritalStatus = @MaritalStatus,about_me = @about_me, ethnicity = @ethnicity WHERE UserID = @UserID";
                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.AddWithValue("@UserID", SessionData.key["id"]);
                command.Parameters.AddWithValue("@gender", gender);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@Religion", religion);
                command.Parameters.AddWithValue("@Occupation", occupation);
                command.Parameters.AddWithValue("@Education", education);
                command.Parameters.AddWithValue("@Height", height);
                command.Parameters.AddWithValue("@MaritalStatus", matarialStatus);
                command.Parameters.AddWithValue("@about_me", aboutme);
                command.Parameters.AddWithValue("@ethnicity", ethnicity);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Data inserted successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to insert data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
         
        }

        internal void Close()
        {
            conn.Close();
        }

        internal SqlDataReader getProfile()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Users.name ,Profiles.userid,Profiles.gender,Profiles.age,Profiles.height,Profiles.education,Profiles.Occupation,Profiles.religion ,Profiles.MaritalStatus FROM Profiles INNER JOIN Users ON users.userid = Profiles.userid", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
            return null;
        }

        internal SqlDataReader getProfilebyID(int v)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Users.name ,Profiles.userid,Profiles.gender,Profiles.age,Profiles.height,Profiles.education,Profiles.Occupation,Profiles.religion ,Profiles.MaritalStatus FROM Profiles INNER JOIN Users ON users.userid = Profiles.userid WHERE Profiles.UserID =@UserID;", conn);
                cmd.Parameters.AddWithValue("@UserID", v);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return null;
        }

        internal void signUp(string name, string email, string phone, string username, string password)
        {
            conn.Close();
            conn.Open();
            string query = "INSERT INTO Users(name, email, phone, username, password) VALUES(@name, @email, @phone, @username, @password);";
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            int result = command.ExecuteNonQuery();
            // Check if the insert was successful
            if (result > 0)
            {
                MessageBox.Show("User created successfully.");
                SessionData.key.Add("id",GetID("Users", email, "email").ToString());
                new Home().Show();
            }
            else
            {
                MessageBox.Show("Failed to create User.");
            }
            conn.Close();
        }

        internal void insertMatch(int id1, int id2)
        {
            conn.Open();
            string query = "INSERT INTO Matching(User1ID, User2ID) VALUES(@User1ID, @User1ID);";
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@User1ID", id1);
            command.Parameters.AddWithValue("@User2ID", id2);

            int result = command.ExecuteNonQuery();
            // Check if the insert was successful
            conn.Close();
            if (result > 0)
            {
                MessageBox.Show("Matching added successfully.");
                new Home().Show();
            }
            else
            {
                MessageBox.Show("Failed to Match User.");
            }
        
        }
    }
}
