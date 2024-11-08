using Npgsql;
using System;
using System.Windows.Forms;
namespace _1080_uts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string connectionString =
        "Host=localhost;Username=postgres;Password=1;Database=uts";
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            if (ValidateLogin(username, password))
            {
                FormAdmin menu_utama = new FormAdmin();
                menu_utama.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau password salah");
            }
        }

        private bool ValidateLogin(string username, string password)
        {
            bool isValid = false;
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Query untuk mengecek apakah username dan password cocok
                    string query = "SELECT COUNT(1) FROM akun WHERE Username = @username AND Password = @password";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        // Menghindari SQL Injection dengan parameterized query
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        // Mengeksekusi query
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 1)
                        {
                            isValid = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return isValid;
        }
    }
}
