using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MesajUygulaması
{
    public partial class MesajUygulaması : Form
    {
        public MesajUygulaması()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-T6JACR2\SQLEXPRESS;Initial Catalog=kavt;Integrated Security=True");
        //Data Source=DESKTOP-T6JACR2\SQLEXPRESS;Initial Catalog=kavt;Integrated Security=True
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLKISILER where NUMARA=@P1 AND SIFRE=@P2", baglanti);
            komut.Parameters.AddWithValue("@P1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@P2", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MesajUygulaması2  msj = new MesajUygulaması2();
                msj.numara = maskedTextBox1.Text;
                msj.Show();

            }
            else
            {
                MessageBox.Show("Hatalı Bilgi");
            }
            baglanti.Close();
        }
    }
}
