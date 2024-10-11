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

namespace Not_Kayit_Sistemi
{
    public partial class Ogretmen_islem_Sayfasi : Form
    {
        public Ogretmen_islem_Sayfasi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=BETšSPC\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True;Encrypt=False");
        private void Ogretmen_islem_Sayfasi_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dbNotKayitDataSet1.Tbl_ders' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_dersTableAdapter.Fill(this.dbNotKayitDataSet1.Tbl_ders);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand KomutKaydet = new SqlCommand("insert into tbl_ders (OGRnumara, ograd, ogrsoyad) values (@p1, @p2, @p3)", baglanti);
            KomutKaydet.Parameters.AddWithValue("@p1", mskNumara.Text);
            KomutKaydet.Parameters.AddWithValue("@p2", txtAd.Text);
            KomutKaydet.Parameters.AddWithValue("@p3", txtSoyad.Text);
          
            KomutKaydet.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.tbl_dersTableAdapter.Fill(this.dbNotKayitDataSet1.Tbl_ders);

            

            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            mskNumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtV1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtV2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtFinal.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }
        //(v1 * 0.30) + (v2 * 0.30) + (f * 0.40)
        private void button2_Click(object sender, EventArgs e)
        {
            double ortalama, v1,v2, f;
            string durum;
            v1 = Convert.ToDouble(txtV1.Text);
            v2 = Convert.ToDouble(txtV2.Text);
            f = Convert.ToDouble(txtFinal.Text);
            ortalama = (v1 + v2 + f) / 3;
            lblOrt.Text = ortalama.ToString();

            if (ortalama >= 50)
            {
                durum = "True";

            }
            else
            {
                durum = "False";
            }
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update tbl_ders set ogrS1=@p1, ogrS2=@p2, ogr3=@p3, ortalama=@p4, durum=@p5 where OgrNumara=@p6" , baglanti);
            komut.Parameters.AddWithValue("@p1", txtV1.Text);
            komut.Parameters.AddWithValue("@p2", txtV2.Text);
            komut.Parameters.AddWithValue("@p3", txtFinal.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(lblOrt.Text));
            komut.Parameters.AddWithValue("@p5", durum);
            komut.Parameters.AddWithValue("@p6", mskNumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Notları Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); ;
            this.tbl_dersTableAdapter.Fill(this.dbNotKayitDataSet1.Tbl_ders);

            baglanti.Open();
            SqlCommand gecen = new SqlCommand("Select COUNT (*) from Tbl_ders where Durum='True'\r\n\r\n", baglanti);
            SqlDataReader dr = gecen.ExecuteReader();
            while (dr.Read())
            {
                lblGecen.Text = dr[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand kalan = new SqlCommand("Select COUNT (*) from Tbl_ders where Durum='False'", baglanti);
            SqlDataReader dr1 = kalan.ExecuteReader();
            while (dr1.Read())
            {
                lblKalan.Text = dr1[0].ToString();
            }
            baglanti.Close();

        }
    }
}
