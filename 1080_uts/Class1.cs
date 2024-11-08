/*using _1080_uts;
using Npgsql;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Latihan_uts
{
    public partial class Form1 : Form
    {
        private string connectionString =
        "Host=localhost;Username=postgres;Password=Aditya03;Database=uts";
        public Form1()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
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
            private bool ValidateLogin(string username, string password)
            {
                bool isValid = false;
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        // Query untuk mengecek apakah username dan password cocok
                        string query = "SELECT COUNT(1) FROM akun WHERE Username =
                    @username AND Password = @password";
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
    }*//*

using System;
using System.Data;
using System.Windows.Forms;
using Npgsql; // Pastikan menggunakan library Npgsql untuk koneksi
PostgreSQL
namespace Latihan_uts
{
    public partial class Form2 : Form
    {
        private string connString =
        "Host=localhost;Username=postgres;Password=Aditya03;Database=uts
";
    public Form2()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            // Event label click jika diperlukan
        }
        // Event ketika tombol Simpan diklik
        private void button1_Click(object sender, EventArgs e)
        {
            string namaPembeli = textBox1.Text;
            decimal totalHarga;


            // Validasi input
            if (string.IsNullOrWhiteSpace(namaPembeli) ||
            !decimal.TryParse(textBox2.Text, out totalHarga))
            {
                MessageBox.Show("Nama pembeli dan total harga harus diisi dengan benar.");
            return;
            }
            DateTime tanggalPesanan = DateTime.Now;
            using (NpgsqlConnection conn = new
            NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO transaksi (nama_pembeli, total_harga, tanggal) VALUES(@nama, @total, @tanggal)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("nama", namaPembeli);
                        cmd.Parameters.AddWithValue("total", totalHarga);
                        cmd.Parameters.AddWithValue("tanggal", tanggalPesanan);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Transaksi berhasil disimpan.");
                    this.Close(); // Menutup form setelah menyimpan
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        // Event ketika tombol Batal diklik
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Menutup form tanpa menyimpan
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Event untuk teks Nama Pembeli
        }

        using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
namespace Latihan_uts
    {
        public partial class FormAdmin : Form
        {
            private string connString =
            "Host=localhost;Username=postgres;Password=Aditya03;Database=uts
";
public FormAdmin()
            {
                InitializeComponent();
                LoadRiwayatTransaksi();
            }
            private void LoadRiwayatTransaksi()
            {
                using (NpgsqlConnection conn = new
                NpgsqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT * FROM transaksi";
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(query,
                        conn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        // Menambahkan tombol Edit dan Delete di DataGridView jika
                        belum ada
                    if (!dataGridView1.Columns.Contains("Edit") && !dataGridView1.Columns.Contains("Delete"))
                        {
                            DataGridViewButtonColumn btnEdit = new
                            DataGridViewButtonColumn();
                            btnEdit.Name = "Edit";
                            btnEdit.Text = "Edit";
                            btnEdit.UseColumnTextForButtonValue = true;
                            dataGridView1.Columns.Add(btnEdit);
                            DataGridViewButtonColumn btnDelete = new
                            DataGridViewButtonColumn();
                            btnDelete.Name = "Delete";
                            btnDelete.Text = "Delete";
                            btnDelete.UseColumnTextForButtonValue = true;
                            dataGridView1.Columns.Add(btnDelete);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            private void dataGridView1_CellContentClick(object sender,
            DataGridViewCellEventArgs e)
            {
                // Pastikan kolom yang diklik adalah kolom Edit atau Delete
                if (e.RowIndex >= 0)
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                    {
                        // Dapatkan data dari baris yang dipilih
                        int transaksiID =
                        Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                        // Contoh sederhana edit: menampilkan form atau dialog edit
                        
                        FormEditTransaksi formEdit = new FormEditTransaksi(transaksiID);
                        formEdit.ShowDialog();
                        // Setelah edit selesai, refresh data
                        LoadRiwayatTransaksi();
                    }
                    else if (dataGridView1.Columns[e.ColumnIndex].Name ==
                    "Delete")
                    {
                        int transaksiID =
                        Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                        var result = MessageBox.Show("Apakah Anda yakin ingin
                        menghapus transaksi ini ? ", "Konfirmasi Hapus",
                        MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            DeleteTransaksi(transaksiID);
                            LoadRiwayatTransaksi();
                        }
                    }
                }
            }
            private void DeleteTransaksi(int transaksiID)
            {
                using (NpgsqlConnection conn = new
                NpgsqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM transaksi WHERE id = @id";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(query,
                        conn))
                        {
                            cmd.Parameters.AddWithValue("@id", transaksiID);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Data berhasil dihapus.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            // Event handler untuk tombol Add
            private void buttonAdd_Click(object sender, EventArgs e)
            {
                Form2 formTambah = new Form2();
                formTambah.ShowDialog();
                LoadRiwayatTransaksi();
            }
            private void FormAdmin_Load(object sender, EventArgs e)
            {
            }
        }
    }
*/