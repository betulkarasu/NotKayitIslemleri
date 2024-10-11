using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace Not_Kayit_Sistemi
{
    public partial class Frm_Ogrenci_Detay : Form
    {
        public Frm_Ogrenci_Detay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=BETšSPC\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True;Encrypt=False");
        public string numara;
        string durum;
        private void Frm_Ogrenci_Detay_Load(object sender, EventArgs e)
        {
            lblNumara.Text = numara;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from tbl_ders where OgrNumara=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader rd = komut.ExecuteReader();
            while (rd.Read())
            {
                lblADSOYAD.Text = rd[2].ToString() + "  "+ rd[3].ToString();
                lblV1.Text = rd[4].ToString();
                lblV2.Text = rd[5].ToString();
                lblFinal.Text = rd[6].ToString();
                lblOrt.Text = rd[7].ToString();
                durum = rd[8].ToString();
            }
            baglanti.Close();
            if(durum =="True"){

                lblDurum.Text = "Geçti";
            }
            else {
                lblDurum.Text = "Kaldı";

                 }
           
                 }

        private void lblOrt_Click(object sender, EventArgs e)
        {

        }
    }
}
