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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private string connString = "Host=localhost;Username=postgres;Password=1;Database=uts";

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string judul = textBox1.Text;
            string judul1 = textBox2.Text;



            // Validasi input
            if (string.IsNullOrWhiteSpace(judul))
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
                    string query = "INSERT INTO tugas (judul, deskripsi, deadline) VALUES(@judul, @deskripsi, @deadline)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("judul",);
                        cmd.Parameters.AddWithValue("desripsi", judul);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Menutup form tanpa menyimpan
        }
    }
}
