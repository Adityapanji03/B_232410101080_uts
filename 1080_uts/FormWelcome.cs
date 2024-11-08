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
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 menu_utama = new Form1();
            menu_utama.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormRegister menu_utama = new FormRegister();
            menu_utama.Show();
            this.Hide();
        }
    }
}
