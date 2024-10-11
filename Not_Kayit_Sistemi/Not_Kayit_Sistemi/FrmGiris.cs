using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Not_Kayit_Sistemi
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Ogrenci_Detay fr = new Frm_Ogrenci_Detay();
           
            fr.numara = maskedTextBox1.Text;
            fr.Show();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text== "0000")
            {
                Ogretmen_islem_Sayfasi ogr = new Ogretmen_islem_Sayfasi();
                ogr.Show();
                this.Hide();
            }
        }
    }
}
