using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_Otomasyonu
{
    public partial class Login : Form
    {
        MySqlConnection con = new MySqlConnection("Server=auth-db1017.hstgr.io;Database=u918363033_kutuphane;user=u918363033_kutuphane;Pwd=Cumhuriyet21;");
        MySqlCommand cmd;
        MySqlDataReader dr;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM admin_kullanicilar where admin_k=@k AND admin_s=@sifre";
            cmd = new MySqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@k", admin_k.Text);
            cmd.Parameters.AddWithValue("@sifre", admin_s.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                admin_panel admin_Panel = new admin_panel();
                admin_Panel.Show();
                this.Hide();
            }
            /*
            else
            {
                bildiri_label.Text = "Bilgileri Kontrol Edin !";
            }
            */
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
