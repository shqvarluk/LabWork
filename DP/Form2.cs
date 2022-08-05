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
using DP.Properties;
using System.Resources;
using System.Net.Mail;
using System.Net;
using System.Diagnostics;

namespace DP
{
    public partial class Form2 : Form
    {
        
        
        public Form2()
        {
            InitializeComponent();
        }
        string t;
        byte n = 1;
        bool isPressed = false;
        int MDX, MDY;
        Point loc;
        int number = -1;
        List<string[]> Start_Position = new List<string[]>();
        byte result = 0;
        public string NameStudent, SurnameStudent, GroupStudent;
        bool CheckPosition = false;
        public Font myfont;


        List<Bitmap> Tasks = new List<Bitmap>()
        {
           Resources.Zadanie1,
           Resources.Zadanie2,
           Resources.Zadanie3,
           Resources.Zadanie4,
           Resources.Zadanie5,
           Resources.Zadanie6,
           Resources.Zadanie7,
           Resources.Zadanie8
        };
        Point[][] Coordinates = new Point[8][];
        
        List<Control> el = new List<Control>();
        string[][] ca = new string[8][];
        string[][] Correct_Answer = new string[8][];
        
        private void Form2_Load(object sender, EventArgs e)
        {
            Correct_Answer[0] = new string[] { "TE", "HKGI", "TC", "NS", "IM", "RO" };
            Correct_Answer[1] = new string[] { "PT", "PC", "H", "HKGI", "NS", "DV" };
            Correct_Answer[2] = new string[] { "ME", "MT", "MC", "H", "HKGI", "NS", "IM", "RO" };
            Correct_Answer[3] = new string[] { "FE", "FE", "FT", "FT", "FY", "FC", "HS", "NS", "GI", "IM", "RO" };
            Correct_Answer[4] = new string[] { "LE", "FE", "FE", "LT", "FT", "FT", "LCHKGI", "NS", "IM", "RO" };
            Correct_Answer[5] = new string[] { "FE", "FE", "QE", "FT", "FT", "QT", "FY", "FC", "HS", "NS", "GI", "IM", "RO" };
            Correct_Answer[6] = new string[] { "PT", "PC", "H", "HS", "NS", "GI", "IM", "RO" };
            Correct_Answer[7] = new string[] { "PT", "PT", "PT", "HS", "PY", "PCHKGIH", "NS", "IM", "RO" };

            Coordinates[0] = new Point[] { new Point(541, 80), new Point(235, 352), new Point(327, 423), new Point(461, 350), new Point(221, 149), new Point(221, 80) };
            Coordinates[1] = new Point[] { new Point(331, 340), new Point(331, 413), new Point(239, 413), new Point(471, 413), new Point(471, 340), new Point(478, 119) };
            Coordinates[2] = new Point[] { new Point(493, 51), new Point(326, 353), new Point(326, 426), new Point(233, 426), new Point(465, 426), new Point(465, 353), new Point(252, 175), new Point(252, 143) };
            Coordinates[3] = new Point[] { new Point(169, 61), new Point(450, 50), new Point(212, 275), new Point(319, 275), new Point(268, 371), new Point(269, 415), new Point(417, 415), new Point(417, 275), new Point(465, 419), new Point(536, 88), new Point(536, 50) };
            Coordinates[4] = new Point[] { new Point(445, 67), new Point(495, 22), new Point(139, 109), new Point(192, 359), new Point(255, 359), new Point(313, 359), new Point(255, 457), new Point(422, 359), new Point(63, 161), new Point(63, 109) };
            Coordinates[5] = new Point[] { new Point(147, 67), new Point(460, 56), new Point(415, 29), new Point(195, 284), new Point(314, 284), new Point(368, 284), new Point(258, 385), new Point(258, 425), new Point(423, 425), new Point(423, 284), new Point(479, 432), new Point(557, 99), new Point(557, 56) };
            Coordinates[6] = new Point[] { new Point(267, 354), new Point(267, 447), new Point(197, 447), new Point(415, 447), new Point(416, 354), new Point(465, 450), new Point(163, 165), new Point(163, 116) };
            Coordinates[7] = new Point[] { new Point(208, 278), new Point(268, 278), new Point(342, 278), new Point(240, 350), new Point(292, 405), new Point(292, 452), new Point(417, 278), new Point(593, 100), new Point(593, 58) };

            ca[0] = new string[6];
            ca[1] = new string[6];
            ca[2] = new string[8];
            ca[3] = new string[11];
            ca[4] = new string[10];
            ca[5] = new string[13];
            ca[6] = new string[8];
            ca[7] = new string[9];

            

            foreach (Control ct in Controls)
            {
                Start_Position.Add(new string[3]);

                Start_Position[Start_Position.Count - 1][0] = Convert.ToString(ct.Location);
                Start_Position[Start_Position.Count - 1][1] = Convert.ToString(ct.Tag);
                Start_Position[Start_Position.Count - 1][2] = Convert.ToString(ct.Name);
                ct.Visible = false;
            }
            button1.Location = new Point(268, 265);
            button1.Text = "Приступить";
            button1.Size = new Size(200,75);
            button1.Visible = true;
            button1.Font = myfont;
            label1.Font = myfont;
            label1.Visible = true;
            pictureBoxSpr.Visible = true;
        }

        void MD(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPressed = true;
                MDX = e.X;
                MDY = e.Y;
                loc = (sender as PictureBox).Location;
                t = Convert.ToString((sender as PictureBox).Tag);
                (sender as PictureBox).BringToFront();
            }

            for (int i = 0; i < Start_Position.Count; i++)
            {    
                if (Start_Position[i][0] == Convert.ToString(loc) && Start_Position[i][1] == t)
                {
                    PictureBox pb = new PictureBox();
                    pb.Name = (sender as PictureBox).Name + "q";
                    pb.Size = (sender as Control).Size;
                    pb.Location = loc;
                    pb.Image = (sender as PictureBox).Image;
                    pb.Tag = (sender as PictureBox).Tag;
                    pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MD);
                    pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MM);
                    pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MU);
                    pb.Cursor = System.Windows.Forms.Cursors.Hand;
                    pb.BringToFront();
                    Controls.Add(pb);
                    el.Add(sender as PictureBox);                   
                } 
            }
        }

        

        void MM(object sender, MouseEventArgs e)
        {
            if (isPressed == true)
            {
                (sender as PictureBox).Location = new Point((sender as PictureBox).Location.X + (e.X - MDX), (sender as PictureBox).Location.Y + (e.Y - MDY));              
            }
        }

        

        void MU(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPressed = false;

                for (int i = 0; i < Coordinates[number].Length; i++)
                {
                    if ((sender as PictureBox).Location.X > ((Coordinates[number][i]).X - 25) && (sender as PictureBox).Location.Y > ((Coordinates[number][i]).Y - 16) &&
                                            (sender as PictureBox).Location.X < ((Coordinates[number][i]).X + 25) && (sender as PictureBox).Location.Y < ((Coordinates[number][i]).Y + 16))
                    {
                        (sender as PictureBox).Location = Coordinates[number][i];
                        ca[number][i] = (sender as PictureBox).Tag.ToString();
                        CheckPosition = true;
                    }
                }
                if (CheckPosition == false)
                {
                    Controls.Remove(sender as PictureBox);                   
                }
                else CheckPosition = false;

                for (int i = 0; i <= Controls.Count - 1; i++)
                {
                    if ((sender as PictureBox).Location == Controls[i].Location && (sender as PictureBox).Name != Controls[i].Name)
                    {
                        for (int j = 0; j < Start_Position.Count; j++)
                        {
                            if ((sender as PictureBox).Tag.ToString() == Start_Position[j][1])
                            {
                                string[] o = Start_Position[j][0].Split(',');
                                o[0] = o[0].Substring(3);
                                o[1] = o[1].Substring(2);
                                o[1] = o[1].Substring(0, o[1].Length - 1);
                                if ((sender as PictureBox).Location != new Point(Convert.ToInt32(o[0]), Convert.ToInt32(o[1]))) Controls.Remove(Controls[i]);
                            }
                        }
                    }
                }
            }
        }

        void Button1_Click(object sender, EventArgs e)
        {
            Controls.Remove(label1);
            button1.Location = new Point(309, 573);
            button1.Size = new Size(75, 23);
            button1.Text = "Далее";

            bool b = true;
            foreach (Control r in Controls)
            {
                r.Visible = true;
            }
            if (n == 9)
            {
                if (result >= 7) result = 5;
                else if (result == 6) result = 4;
                else if (result >= 4 && result < 6) result = 3;
                else if (result < 4) result = 2;

                if (Properties.Settings.Default["Otp"].ToString() == "True")
                {
                    MailAddress from = new MailAddress("shqvarluk98@yandex.ru", "Практическая работа");
                    MailAddress to = new MailAddress(Properties.Settings.Default["Adress"].ToString());
                    MailMessage m = new MailMessage(from, to);
                    m.Subject = "Тест";
                    m.IsBodyHtml = true;
                    m.Body = "<h2>Результат работы студента " + SurnameStudent + " " + NameStudent + " группы " + GroupStudent + " : " + result + "</h2><br>";
                    m.Body += "<hr align = center size = 2 color = grey />";
                    for (int i = 0; i < ca.Length; i++)
                    {
                        m.Body += "Задание " + (i + 1) + " ";
                        for (int j = 0; j < ca[i].Length; j++)
                        {
                            string correct = "<font color = blue>";
                            string incorrect = "<font color = red>";
                            if (ca[i][j] == Correct_Answer[i][j]) m.Body += correct + ca[i][j] + "</font> ";
                            else if (ca[i][j] == null || ca[i][j].Trim() == "") m.Body += incorrect + "x" + "</font> ";
                            else if (ca[i][j] != Correct_Answer[i][j]) m.Body += incorrect + ca[i][j] + "</font> ";
                        }
                        if (i < ca[i].Length - 1) m.Body += "<br>";
                    }
                    m.Body += "<hr align = center size = 2 color = grey /><br>";
                    m.Body += "<font color = blue>*верно</font><br><font color = red>*неверно</font><br>x - пропуск";
                    SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
                    smtp.Credentials = new NetworkCredential("shqvarluk98@yandex.ru", "vadim2010");
                    smtp.EnableSsl = true;
                    smtp.SendMailAsync(m);
                    MessageBox.Show("Задания пройдены. Результаты отправлены.");

                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    Process.GetCurrentProcess().Kill();
                }


            }
            else
            {
                if (number >= 0)
                {
                    for (int i = 0; i < ca[number].Length; i++)
                    {
                        if (ca[number][i] != Correct_Answer[number][i]) b = false;
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    panel1.BackgroundImage = Tasks[i];
                }

                for (int y = 0; y < el.Count; y++)
                {
                    Controls.Remove(el[y]);
                }

                if (n < 9) n++;

                number++;

                el.Clear();

                if (b == true) result++;

            }
        }
        void PictureBoxSpr_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.myFont = myfont;
            f4.Show();
        }
    }
}
