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
    public partial class User_Panel : Form
    {
        public User_Panel()
        {
            InitializeComponent();
        }
        SpeechSynthesizer synt = new SpeechSynthesizer();
        PromptBuilder pbuilder = new PromptBuilder();
        SpeechRecognitionEngine rengine = new SpeechRecognitionEngine();
        private void btn_exit(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Exiting the application. Please wait.");
            synt.Speak(pbuilder);

            Application.Exit();
        }
        SpeechRecognitionEngine ren = new SpeechRecognitionEngine();
        private void button3_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            button3.Visible = false;

            Grammar gr = new DictationGrammar();
            ren.LoadGrammar(gr);
            try
            {
                ren.SetInputToDefaultAudioDevice();
                RecognitionResult r = ren.Recognize();
                richTextBox1.Text = "";
                richTextBox1.Text = r.Text;
            }
            catch
            {
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button9.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Going back to the login screen. Please wait.");
            synt.Speak(pbuilder);

            Login lg = new Login();
            this.Hide();
            lg.Show();
        }
        public static string kullanici,kad,dg,cins,tel;
        private void User_Panel_Load(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=kullanıcı.mdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("select * from kullanıcı", baglanti);
            OleDbDataReader okuma = sorgu.ExecuteReader();
            while (okuma.Read())
            {
               if (okuma["kullanici_adi"].ToString() == Login.isim)
               {
                    kad = okuma.GetValue(1).ToString();
                    dg = okuma.GetValue(2).ToString();
                    cins = okuma.GetValue(3).ToString();
                    tel = okuma.GetValue(4).ToString();
                    break;
                }                             
            }
            baglanti.Close();

            label7.Text = kad;
            label9.Text = dg;
            label10.Text = cins;
            label11.Text = tel;

            kullanici = label7.Text;

            button5.Enabled = false;
            richTextBox1.Text = "Write your story here...";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("You are redirected to the list of books.");
            synt.Speak(pbuilder);

            Book_Panel bP = new Book_Panel();
            this.Hide();
            bP.Show();
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to exit the application.");
            synt.Speak(pbuilder);
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to return to the login screen.");
            synt.Speak(pbuilder);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to go to the list of books.");
            synt.Speak(pbuilder);
        }
        private void User_Panel_Shown(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Welcome to the user panel. Here you can view your book list and write your own story. Have fun.");
            synt.Speak(pbuilder);
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("click to make sound record.");
            synt.Speak(pbuilder);
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("click to stop recording.");
            synt.Speak(pbuilder);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            button9.Visible = false; 

            SpVoice ses = new SpVoice();
            ses.Speak(richTextBox1.Text);
        }
        private void button9_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to listen to the sound recording.");
            synt.Speak(pbuilder);
        }
        public static string kitap;
        private void button13_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=kitap.mdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("select * from kitap", baglanti);
            OleDbDataReader okuma = sorgu.ExecuteReader();
            while (okuma.Read())
            {
                kitap = okuma.GetValue(1).ToString();
                listBox1.Items.Add(kitap);
            }
            baglanti.Close();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=kitap.mdb");
        OleDbCommand komut = new OleDbCommand();

        private void button12_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete from kitap where kitap_adi ='" + listBox1.SelectedItem + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            listBox1.Items.Remove(listBox1.SelectedItem);
            pbuilder.ClearContent();
            pbuilder.AppendText("the book you selected has been deleted");
            synt.Speak(pbuilder);
        }

        private void button12_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Please select the book you want to delete from the list. Press this button after selecting.");
            synt.Speak(pbuilder);
        }

        private void button13_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to list your books.");
            synt.Speak(pbuilder);
        }

        private void listBox1_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("List section with books.");
            synt.Speak(pbuilder);
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(listBox1.SelectedItem.ToString());
        }
    }
}