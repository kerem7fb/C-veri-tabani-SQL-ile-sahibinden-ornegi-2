using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace sahibinden
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection yeni=new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\user\\Desktop\\10-M\\Sahibinden 2\\AracBilgileri.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            yeni.Open();
            string kullanici=textBox1.Text;
            string sifre=textBox2.Text;
            OleDbCommand komut = new OleDbCommand("SELECT * FROM SistemKullanicilari WHERE KullaniciAdi='" + kullanici + "' AND Sifre='" + sifre + "'", yeni);
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                Form2 bagla = new Form2();
                bagla.Show();
                this.Hide();
                MessageBox.Show("Kullanıcı Adı Ve Şifre Doğru,Sistem Sayfasına Yönlendiriliyorsunuz.");
            }
            else 
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış,Kayıt Olabilirsiniz");
            }
            yeni.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else 
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
