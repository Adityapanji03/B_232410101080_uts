using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1080_uts
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
            LoadRiwayatTransaksi();
        }
        private string connString = "Host=localhost;Username=postgres;Password=1;Database=uts";

        private void LoadRiwayatTransaksi()
        {
            using (NpgsqlConnection conn = new
            NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM tugas";
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(query,
                    conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // Menambahkan tombol Edit dan Delete di DataGridView jika
                    
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


                    LoadRiwayatTransaksi();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name ==
                "Delete")
                {
                    int transaksiID =
                    Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                    var result = MessageBox.Show("Apakah Anda yakin ingin menghapus transaksi ini ? ", "Konfirmasi Hapus",

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
        /*        private void DeleteTransaksi(int transaksiID)
                {
                    using (NpgsqlConnection conn = new
                    NpgsqlConnection(connString))
                    {
                        try
                        {
                            conn.Open();
                            string query = "DELETE FROM tugas WHERE id = @id";
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
                }*/
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 menu_utama = new Form2();
            menu_utama.Show();
            this.Hide();

        }

    }
}
