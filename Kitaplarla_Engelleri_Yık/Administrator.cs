using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition; //verdiğimiz komutu anlaması için
using System.Speech.Synthesis; //konuşmamızın sese dönüşmesi için
using System.Threading;
using System.Diagnostics; //sesli bir komutla program açtırma
using System.Speech;
using SpeechLib;
using System.Data.OleDb;

namespace Kitaplarla_Engelleri_Yık
{
    public partial class Administrator : Form
    {
        public Administrator()
        {
            InitializeComponent();
        }
        SpeechSynthesizer synt = new SpeechSynthesizer();
        PromptBuilder pbuilder = new PromptBuilder();
        SpeechRecognitionEngine rengine = new SpeechRecognitionEngine();
        private void button8_Click(object sender, EventArgs e)
        {

            pbuilder.ClearContent();
            pbuilder.AppendText("Exiting the application. Please wait.");
            synt.Speak(pbuilder);

            Application.Exit();
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to exit the application.");
            synt.Speak(pbuilder);
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=kitapbilgi.mdb");
        OleDbCommand komut = new OleDbCommand();
        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update kitapbilgi set kitap_adi='" + textBox7.Text + "',yazar_adi='" + textBox11.Text + "'where id='" + textBox3.Text + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            textBox3.Text = "";
            textBox7.Text = "";
            textBox11.Text = "";
            MessageBox.Show("Kitap kaydı güncellenmiştir");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            String ekleme = "insert into kitapbilgi(id,kitap_adi,yazar_adi)values(@id,@kitap_adi,@yazar_adi)";
            OleDbCommand komut = new OleDbCommand(ekleme, baglanti);
            komut.Parameters.AddWithValue("@id", textBox1.Text);
            komut.Parameters.AddWithValue("@kitap_adi", textBox5.Text);        
            komut.Parameters.AddWithValue("@yazar_adi", textBox9.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Text = "";
            textBox5.Text = "";
            textBox9.Text = "";
            MessageBox.Show("Kitap kaydı eklenmiştir");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete from kitapbilgi where id ='" + textBox2.Text + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            textBox2.Text = "";
            textBox6.Text = "";
            textBox10.Text = "";
            MessageBox.Show("Kitap kaydı silinmiştir");
        }
        public static string list;
        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("select * from kitapbilgi", baglanti);
            OleDbDataReader okuma = sorgu.ExecuteReader();
            while (okuma.Read())
            {
                if(okuma["id"].ToString() ==textBox4.Text)
                {
                    list = okuma.GetValue(0).ToString() + " " + okuma.GetValue(1).ToString() + " " + okuma.GetValue(2).ToString();
                    listBox1.Items.Add(list);
                    break;
                }
            }
            baglanti.Close();
            textBox4.Text = "";
            textBox8.Text = "";
            textBox12.Text = "";
            MessageBox.Show("Kitap kaydı listelenmiştir");
        }
    }
}
