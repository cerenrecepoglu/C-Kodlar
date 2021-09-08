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
using System.Data.OleDb;

namespace Kitaplarla_Engelleri_Yık
{

    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
            
        SpeechSynthesizer synt = new SpeechSynthesizer();
        PromptBuilder pbuilder = new PromptBuilder();
        SpeechRecognitionEngine rengine = new SpeechRecognitionEngine();

        public static int no = 1;
        public static int i,s;

        private void Form1_Load(object sender, EventArgs e)
        {  
            tbox_password.PasswordChar = '*';
            textBox2.PasswordChar = '*';
            groupBox1.Visible = false;

            Random rastgele = new Random();
            int s = rastgele.Next(1, 5);
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\resim\\" + s + ".jpeg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            tbox_password.Clear();
            pbuilder.ClearContent();
            pbuilder.AppendText("All the numbers you have entered have been deleted. Please click again.");
            synt.Speak(pbuilder);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Exiting the application. Please wait.");
            synt.Speak(pbuilder);

            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;

            Random rastgele = new Random();
            int s = rastgele.Next(1, 5);
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\resim\\" + s + ".jpeg");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            
            pictureBox1.Visible = false;
            label10.Visible = false;
            label11.Visible = true;

            groupBox2.Visible = false;
            groupBox1.Visible = true;
            pbuilder.ClearContent();
            pbuilder.AppendText("You are redirected to the registration page");
            synt.Speak(pbuilder);   
        }
      

        private void btn_dokuz_Click(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("you pressed number 9");
            synt.Speak(pbuilder);

            Button btn = (Button)sender;
            tbox_password.Text += (btn_dokuz.Text).ToString();
        }

        private void btn_sekiz_Click(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("you pressed number 8");
            synt.Speak(pbuilder);

            Button btn = (Button)sender;
            tbox_password.Text += (btn_sekiz.Text).ToString();

        }


        private void btn_yedi_Click(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("you pressed number 7");
            synt.Speak(pbuilder);

            Button btn = (Button)sender;
            tbox_password.Text += (btn_yedi.Text).ToString();
        }

        private void btn_alti_Click(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("you pressed number 6");
            synt.Speak(pbuilder);

            Button btn = (Button)sender;
            tbox_password.Text += (btn_alti.Text).ToString();
        }



        private void btn_bes_Click(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("you pressed number 5");
            synt.Speak(pbuilder);

            Button btn = (Button)sender;
            tbox_password.Text += (btn_bes.Text).ToString();
        }



        private void btn_dort_Click(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("you pressed number 4");
            synt.Speak(pbuilder);

            Button btn = (Button)sender;
            tbox_password.Text += (btn_dort.Text).ToString();
        }


        private void btn_uc_Click(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("you pressed number 3");
            synt.Speak(pbuilder);

            Button btn = (Button)sender;
            tbox_password.Text += (btn_uc.Text).ToString();
        }

        private void btn_iki_Click(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("you pressed number 2");
            synt.Speak(pbuilder);

            Button btn = (Button)sender;
            tbox_password.Text += (btn_iki.Text).ToString();
        }


        private void btn_bir_Click(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("you pressed number 1");
            synt.Speak(pbuilder);

            Button btn = (Button)sender;
            tbox_password.Text += (btn_bir.Text).ToString();
        }

        private void btn_sifir_Click(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("you pressed number 0");
            synt.Speak(pbuilder);

            Button btn = (Button)sender;
            tbox_password.Text += (btn_dokuz.Text).ToString();
        }

        private void btn_bir_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("You are above the number 1. Press to click");
            synt.Speak(pbuilder);
        }

        private void btn_iki_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("You are above the number 2. Press to click");
            synt.Speak(pbuilder);
        }

        private void btn_uc_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("You are above the number 3. Press to click");
            synt.Speak(pbuilder);
        }

        private void btn_dort_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("You are above the number 4. Press to click");
            synt.Speak(pbuilder);
        }

        private void btn_bes_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("You are above the number 5. Press to click");
            synt.Speak(pbuilder);
        }

        private void btn_alti_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("You are above the number 6. Press to click");
            synt.Speak(pbuilder);
        }

        private void btn_yedi_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("You are above the number 7. Press to click");
            synt.Speak(pbuilder);
        }

        private void btn_sekiz_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("You are above the number 8. Press to click");
            synt.Speak(pbuilder);
        }

        private void btn_dokuz_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("You are above the number 9. Press to click");
            synt.Speak(pbuilder);
        }

        private void btn_sifir_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("You are above the number 0. Press to click");
            synt.Speak(pbuilder);
        }

        private void btn_delete_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("You are on the delete button. Press to click.");
            synt.Speak(pbuilder);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("You are logging in as admin");
            synt.Speak(pbuilder);

            Administrator ad = new Administrator();
            this.Hide();
            ad.Show();
        }

        private void btn_login_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click the button to register.");
            synt.Speak(pbuilder);
        }

        private void button12_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click the button to login as an administrator.");
            synt.Speak(pbuilder);
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Welcome to the audio library application. Follow the sounds with the mouse to use the application.");
            synt.Speak(pbuilder);
        }

        private void tbox_userName_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click enter your username to login.");
            synt.Speak(pbuilder);
        }

        private void tbox_password_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click enter your password to login.");
            synt.Speak(pbuilder);
        }

        private void button11_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to exit the application.");
            synt.Speak(pbuilder);
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            label10.Visible = true;
            label11.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                pbuilder.ClearContent();
                pbuilder.AppendText("Please fill in the blank fields");
                synt.Speak(pbuilder);
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false)
            {

                pbuilder.ClearContent();
                pbuilder.AppendText("Please enter your gender");
                synt.Speak(pbuilder);
            }
            else
            {
                string yol = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=kullanıcı.mdb");
                OleDbConnection baglanti = new OleDbConnection(yol);
                baglanti.Open();
                String ekleme = "insert into kullanıcı(sifre,kullanici_adi,cinsiyet,dogum_tarih,telefon)values(@sifre,@kullanici_adi,@cinsiyet,@dogum_tarih,@telefon)";
                OleDbCommand komut = new OleDbCommand(ekleme, baglanti);
                komut.Parameters.AddWithValue("@sifre", textBox2.Text);
                komut.Parameters.AddWithValue("@kullanici_adi", textBox1.Text);
                string cinsiyet = "";
                if (radioButton1.Checked == true)
                {
                    cinsiyet = radioButton1.Text;
                }
                else if (radioButton2.Checked == true)
                {
                    cinsiyet = radioButton2.Text;
                }
                komut.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                komut.Parameters.AddWithValue("@dogum_tarih", textBox4.Text);
                komut.Parameters.AddWithValue("@telefon", textBox3.Text);
                
                komut.ExecuteNonQuery();
                baglanti.Close();

                pbuilder.ClearContent();
                pbuilder.AppendText("Your registration is complete, you are redirected to the login page");
                synt.Speak(pbuilder);

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;

                groupBox2.Visible = true;
                groupBox1.Visible = false;

                pbuilder.ClearContent();
                pbuilder.AppendText("You are now on the login page. Please login.");
                synt.Speak(pbuilder);
            }
        }
        private void button12_MouseHover_1(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to finish your registration");
            synt.Speak(pbuilder);
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("click to login");
            synt.Speak(pbuilder);
        }      
        private void tbox_password_TextChanged_1(object sender, EventArgs e)
        {      
           string metin = tbox_password.Text;
           tbox_password.Text = "";

           for (int i = 0; i < metin.Length - 1; i++)
           {
              tbox_password.Text += metin[i].ToString();
           }
        }
        public static string ad, sifre, kad, dg, cins, tel,isim;

        private void button10_Click_1(object sender, EventArgs e)
        {
            isim = tbox_userName.Text;

            if (tbox_userName.Text == "yönetici" && tbox_password.Text == "12345")
            {
                pbuilder.ClearContent();
                pbuilder.AppendText("You are redirected to the administrator page");
                synt.Speak(pbuilder);

                Administrator ad = new Administrator();
                this.Hide();
                ad.Show();
            }
            else if (tbox_userName.Text == "" || tbox_password.Text == "")
            {
                pbuilder.ClearContent();
                pbuilder.AppendText("Please fill in the blank fields");
                synt.Speak(pbuilder);
            }
            else
            {
                OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=kullanıcı.mdb");
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("select * from kullanıcı", baglanti);
                OleDbDataReader okuma = sorgu.ExecuteReader();
                while (okuma.Read())
                {
                    if (okuma["kullanici_adi"].ToString() == tbox_userName.Text && okuma["sifre"].ToString() == tbox_password.Text)
                    {

                        ad = okuma.GetValue(0).ToString();
                        sifre = okuma.GetValue(0).ToString();

                        pbuilder.ClearContent();
                        pbuilder.AppendText("You are redirected to the login page");
                        synt.Speak(pbuilder);

                        User_Panel uP = new User_Panel();
                        uP.Show();
                        Hide();
                        break;
                    }
                    else if (okuma["kullanici_adi"].ToString() != tbox_userName.Text && okuma["sifre"].ToString() == tbox_password.Text)
                    {
                        pbuilder.ClearContent();
                        pbuilder.AppendText("You entered wrong information, please re-enter");
                        synt.Speak(pbuilder);
                        tbox_userName.Text = "";
                        tbox_password.Text = "";
                    }
                }
                baglanti.Close();
            }
        }

        private void tbox_userName_MouseHover_1(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click enter your password to login.");
            synt.Speak(pbuilder);
            
        }
        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click enter your username to register.");
            synt.Speak(pbuilder);
        }
        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click enter your password to register.");
            synt.Speak(pbuilder);
        }

        private void textBox4_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click enter your birth date to register.");
            synt.Speak(pbuilder);
        }

        private void textBox3_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click enter your telephone to register.");
            synt.Speak(pbuilder);
        }

        private void radioButton1_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Tick ​​if your gender is female.");
            synt.Speak(pbuilder);
        }

        private void radioButton2_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Tick ​​if your gender is male.");
            synt.Speak(pbuilder);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int sınır = tbox_password.TextLength;
            if (sınır > 6)
            {
                pbuilder.ClearContent();
                pbuilder.AppendText("You can enter a password with up to 5 digits.");
                synt.Speak(pbuilder);

                string metin = tbox_password.Text;
                tbox_password.Text = "";

                for (int i = 0; i < metin.Length - 1; i++)
                {
                    tbox_password.Text += metin[i].ToString();
                }
            }
        }
    }
}