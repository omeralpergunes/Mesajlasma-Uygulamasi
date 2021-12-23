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
    public partial class MesajUygulaması2 : Form
    {
        public MesajUygulaması2()
        {
            InitializeComponent();
        }

        public string numara;

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-T6JACR2\SQLEXPRESS;Initial Catalog=kavt;Integrated Security=True");
           
        void gelenkutusu()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from TBLMESAJLAR where alıcı=" + numara, baglanti);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        void gidenkutusu()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from TBLMESAJLAR where gonderen=" + numara, baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }
        private void MesajUygulaması2_Load(object sender, EventArgs e)
        {
            LblNumara.Text = numara;
            gelenkutusu();

            gidenkutusu();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Ad,Soyad from TBLKISILER where numara=" + numara, baglanti);
            SqlDataReader dre = komut.ExecuteReader();
            while (dre.Read())
            {
                LblAdSoyad.Text = dre[0] + " " + dre[1];
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLMESAJLAR (gonderen,alıcı,baslık,ıcerık) values (@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            komut.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p3", textBox1.Text);
            komut.Parameters.AddWithValue("@p4", richTextBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarılı");
            gidenkutusu();
        }
    }
}
