using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StudentPortal
{
    public partial class Form1 : Form
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\StudentDatabase.accdb;Persist Security Info=True";
        private DataTable studentDataTable;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false; // Prevent auto column generation
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (var connection = new OleDbConnection(connectionString))
            {
                var command = new OleDbCommand("SELECT * FROM Student", connection);
                var adapter = new OleDbDataAdapter(command);
                studentDataTable = new DataTable();
                adapter.Fill(studentDataTable);
                dataGridView1.DataSource = studentDataTable;

                // Ensure the DataGridView columns are set up correctly
                dataGridView1.Columns.Clear();

                // Set up DataGridView columns manually
                var idColumn = new DataGridViewTextBoxColumn { DataPropertyName = "ID", HeaderText = "ID", Name = "ID", Visible = false };
                dataGridView1.Columns.Add(idColumn);
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name", Name = "Name" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Name = "Email" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Phone", HeaderText = "Phone", Name = "Phone" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Address", HeaderText = "Address", Name = "Address" });

                // Add an image column to the DataGridView
                var imageColumn = new DataGridViewImageColumn { DataPropertyName = "Image", HeaderText = "Image", Name = "Image" };
                dataGridView1.Columns.Add(imageColumn);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Handle picture box click if needed
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Handle label click if needed
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Handle label click if needed
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Handle label click if needed
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Handle text change if needed
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // Handle text change if needed
        }

        private void phonebox_TextChanged(object sender, EventArgs e)
        {
            // Handle text change if needed
        }

        private void emailbox_TextChanged(object sender, EventArgs e)
        {
            // Handle text change if needed
        }

        private void namebox_TextChanged(object sender, EventArgs e)
        {
            // Handle text change if needed
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Handle panel paint if needed
        }

        private void searchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(searchbox.Text))
                {
                    LoadData();
                }
                else
                {
                    using (var connection = new OleDbConnection(connectionString))
                    {
                        var command = new OleDbCommand("SELECT * FROM Student WHERE Name LIKE @Name OR Email = @Email OR Phone = @Phone OR Address = @Address", connection);
                        command.Parameters.AddWithValue("@Name", $"%{searchbox.Text}%");
                        command.Parameters.AddWithValue("@Email", searchbox.Text);
                        command.Parameters.AddWithValue("@Phone", searchbox.Text);
                        command.Parameters.AddWithValue("@Address", searchbox.Text);
                        var adapter = new OleDbDataAdapter(command);
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                button3.PerformClick();
            }
        }

        // Create button
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            ClearTextBoxes();
            namebox.Focus();
        }

        // Edit button
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            namebox.Focus();
        }

        // Browse button
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog filedialog = new OpenFileDialog() { Filter = "JPEG |*.jpg", ValidateNames = true, Multiselect = false })
                {
                    if (filedialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image = Image.FromFile(filedialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Save button
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    byte[] imageBytes = null;
                    if (pictureBox1.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                            imageBytes = ms.ToArray();
                        }
                    }

                    if (int.TryParse(idbox.Text, out int id))
                    {
                        // Update existing record
                        var command = new OleDbCommand("UPDATE Student SET [Name] = @Name, [Email] = @Email, [Phone] = @Phone, [Address] = @Address, [Image] = @Image WHERE ID = @ID", connection);
                        command.Parameters.AddWithValue("@Name", namebox.Text);
                        command.Parameters.AddWithValue("@Email", emailbox.Text);
                        command.Parameters.AddWithValue("@Phone", phonebox.Text);
                        command.Parameters.AddWithValue("@Address", addressbox.Text);
                        command.Parameters.AddWithValue("@Image", (object)imageBytes ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ID", id);
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        // Insert new record
                        var command = new OleDbCommand("INSERT INTO Student ([Name], [Email], [Phone], [Address], [Image]) VALUES (@Name, @Email, @Phone, @Address, @Image)", connection);
                        command.Parameters.AddWithValue("@Name", namebox.Text);
                        command.Parameters.AddWithValue("@Email", emailbox.Text);
                        command.Parameters.AddWithValue("@Phone", phonebox.Text);
                        command.Parameters.AddWithValue("@Address", addressbox.Text);
                        command.Parameters.AddWithValue("@Image", (object)imageBytes ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }

                panel1.Enabled = false;
                MessageBox.Show("Data saved successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Refresh data
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Delete button
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    if (MessageBox.Show("Are you sure you want to delete this?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (var connection = new OleDbConnection(connectionString))
                        {
                            connection.Open();
                            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                            var command = new OleDbCommand("DELETE FROM Student WHERE ID = @ID", connection);
                            command.Parameters.AddWithValue("@ID", id);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Record deleted successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Refresh data
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                idbox.Text = row.Cells["ID"].Value.ToString();
                namebox.Text = row.Cells["Name"].Value.ToString();
                emailbox.Text = row.Cells["Email"].Value.ToString();
                phonebox.Text = row.Cells["Phone"].Value.ToString();
                addressbox.Text = row.Cells["Address"].Value.ToString();

                // Convert the image byte array back to an image
                if (row.Cells["Image"].Value != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])row.Cells["Image"].Value;
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }

                panel1.Enabled = false; // Disable editing until edit button is pressed
            }
        }

        private void ClearTextBoxes()
        {
            idbox.Clear();
            namebox.Clear();
            emailbox.Clear();
            phonebox.Clear();
            addressbox.Clear();
            pictureBox1.Image = null;
        }
    }
}
