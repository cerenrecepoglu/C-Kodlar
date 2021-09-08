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
    public partial class Book_Panel : Form
    {
        public Book_Panel()
        {
            InitializeComponent();
        }
        SpeechSynthesizer synt = new SpeechSynthesizer();
        PromptBuilder pbuilder = new PromptBuilder();
        SpeechRecognitionEngine rengine = new SpeechRecognitionEngine();

        private void button1_Click(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Exiting the application. Please wait.");
            synt.Speak(pbuilder);

            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Going back to the login screen. Please wait.");
            synt.Speak(pbuilder);

            User_Panel uP = new User_Panel();
            this.Hide();
            uP.Show();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to exit the application.");
            synt.Speak(pbuilder);
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to return to the login screen.");
            synt.Speak(pbuilder);
        }
        private void button7_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to listen to the summary of the book.");
            synt.Speak(pbuilder);
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to add your book to the list.");
            synt.Speak(pbuilder);
        }
        public static string kitapadi;
        private void button8_Click(object sender, EventArgs e)
        {
            kitapadi = label7.Text;

            string yol = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=kitap.mdb");
            OleDbConnection baglanti = new OleDbConnection(yol);
            baglanti.Open();
            String ekleme = "insert into kitap(kitap_adi,kullanici_adi)values(@kitap_adi,@kullanici_adi)"; ;
            OleDbCommand komut = new OleDbCommand(ekleme, baglanti);
            komut.Parameters.AddWithValue("@kitap_adi", label7.Text);
            komut.Parameters.AddWithValue("@kullanici_adi", User_Panel.kullanici);
            komut.ExecuteNonQuery();
            baglanti.Close();

            pbuilder.ClearContent();
            pbuilder.AppendText("Your book has been added to the list.");
            synt.Speak(pbuilder);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("George Orwell's 1984 book.");
            synt.Speak(pbuilder);
        }
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("What is Subjectivity by Jean Paul Sartre.");
            synt.Speak(pbuilder);
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("franz kafka's metamorphosis book.");
            synt.Speak(pbuilder);
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Wolfgang borchert's The Man Outside.");
            synt.Speak(pbuilder);
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Caligula by Albert Camus.");
            synt.Speak(pbuilder);
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("George Orwell's Down and Out in Paris and London.");
            synt.Speak(pbuilder);
        }

        private void button14_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to view the 1984 book.");
            synt.Speak(pbuilder);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to view what is subjectivity book.");
            synt.Speak(pbuilder);
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to view metamorphosis book.");
            synt.Speak(pbuilder);
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to view the book The Man Outside.");
            synt.Speak(pbuilder);
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to view Caligula's book.");
            synt.Speak(pbuilder);
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Click to view the book Down and Out in Paris and London.");
            synt.Speak(pbuilder);
        }
        private void Book_Panel_Shown(object sender, EventArgs e)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText("Welcome to the panel of books. You can add the book you want to your list.");
            synt.Speak(pbuilder);

        }

        private void button14_Click(object sender, EventArgs e)
        {
            pictureBox7.BackgroundImage = pictureBox1.BackgroundImage;
            label7.Text = "1984";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox7.BackgroundImage = pictureBox2.BackgroundImage;
            label7.Text = "What Is Subjectivity ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox7.BackgroundImage = pictureBox3.BackgroundImage;
            label7.Text = "Metamorphosis";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox7.BackgroundImage = pictureBox4.BackgroundImage;
            label7.Text = "The Man Outside";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox7.BackgroundImage = pictureBox5.BackgroundImage;
            label7.Text = "Caligula";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox7.BackgroundImage = pictureBox6.BackgroundImage;
            label7.Text = "Down and Out in Paris and London";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if(label7.Text=="1984")
            {
                pbuilder.ClearContent();
                pbuilder.AppendText("1984 is a dystopian novella by George Orwell " +
                    "published in 1949, which follo the life of Winston Smith, " +
                    "a low ranking member of ‘the Party’, who isfrustrated by the " +
                    "omnipresent eyes of the party, and its ominous ruler BigBrother." +
                    "‘Big Brother’ controls every aspect of people’s lives.It has invented " +
                    "thelanguage ‘Newspeak’ in an attempt to completely eliminate political " +
                    "rebellion;created ‘Throughtcrimes’ to stop people even thinking of things " +
                    "considered rebellious.The party controls what people read, speak, say " +
                    "and do with thethreat that if they disobey, they will be sent to the " +
                    "dreaded Room 101 as alooming punishment.");
                synt.Speak(pbuilder);
            }
            else if(label7.Text== "What Is Subjectivity")
            {
                pbuilder.ClearContent();
                pbuilder.AppendText("Jean-Paul Sartre was an intellectual powerhouse, " +
                    "even in his own time. He moved people, both scholars and non - " +
                    "scholars alike, by the power of his ideas and his tremendously " +
                    "powerful way of expressing them.He blurred all category boundaries" +
                    " and violated conventional mores.He even turned down a Nobel prize " +
                    "on principle.This book documents a philosophical exchange over a " +
                    "topic as big as the very significance of Sartre’s work in light of " +
                    "Sartre’s own commitment to Marxism.How can his Marxism make sense in " +
                    "the light of his existential philosophy ? ");
                synt.Speak(pbuilder);
            }
            else if(label7.Text== "Metamorphosis")
            {
                pbuilder.ClearContent();
                pbuilder.AppendText("Gregor Samsa, a traveling salesman, " +
                    "wakes up in his bed to find himself transformed into a " +
                    "large insect.He looks around his room, which appears normal, " +
                    "and decides to go back to sleep to forget about what has happened. " +
                    "He attempts to roll over, only to discover that he cannot due to " +
                    "his newbody—he is stuck on his hard, convex back.He tries to scratch " +
                    "an itch on his stomach, but when he touches himself with one of " +
                    "his many new legs, he is disgusted.He reflects on how dreary life as " +
                    "a traveling salesman is and how he would quit if his parents and " +
                    "sister did not depend so much on his income. He turns to the clock " +
                    "and sees that he has overslept and missed his train to.");
                synt.Speak(pbuilder);
            }
            else if(label7.Text== "The Man Outside")
            {
                pbuilder.ClearContent();
                pbuilder.AppendText("It made its debut on German radio on " +
                    "13 February 1947. The Man Outside describes the " +
                    "hopelessness of a post - war soldier called Beckmann " +
                    "who returns from Russia to find that he has lost his " +
                    "wife and his home, as well as his illusions and beliefs." +
                    "He finds every door he comes to closed; even nature seems to reject him.");
                synt.Speak(pbuilder);
            }
            else if(label7.Text== "Caligula")
            {
                pbuilder.ClearContent();
                pbuilder.AppendText("Caligula is the story of a superior suicide. " +
                    "It is the story of the most human and the most tragic of errors." +
                    "Unfaithful to man, loyal to himself, Caligula consents to die " +
                    "for having understood that no one can save himself all alone and " +
                    "that one cannot be free in opposition to other men.");
                synt.Speak(pbuilder);
            }
            else
            {
                pbuilder.ClearContent();
                pbuilder.AppendText("Down and Out in Paris and London is a " +
                    "memoir of the famous writer, George Orwell, during his " +
                    "early years as a writer.The book follows his life when he " +
                    "was in his twenties, and living in Paris in London.At the " +
                    "beginning of the memoir, he is living in a run - down hotel " +
                    "in Paris.Orwell often notes how poor his life is during the novel - " +
                    "both in friends and in money.He gets about six francs per day, " +
                    "which is enough for him to buy some food, which, considering " +
                    "that the hotel he lives in is infested with bugs, will probably " +
                    "go bad within 24 hours, and perhaps some extra money to buy a newspaper and some books");
                synt.Speak(pbuilder);
            }
        }
    }
}
