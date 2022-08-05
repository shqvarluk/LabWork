using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DP.Properties;

namespace DP
{
    public partial class Form6 : Form
    {
        
        public Form6()
        {
            InitializeComponent();
        }
        public Font myFont;
        private void Form6_Load(object sender, EventArgs e)
        {
            label1.Font = myFont;
            label2.Font = myFont;
            label3.Font = myFont;
            label4.Font = myFont;
            label5.Font = myFont;
            button1.Font = myFont;
            button2.Font = myFont;
            checkBox1.Font = myFont;
            tabControl1.Font = myFont;
            if (Properties.Settings.Default["Adress"].ToString() != null)
            {
                textBox1.Text = Properties.Settings.Default["Adress"].ToString();
            }
            if (Properties.Settings.Default["Otp"].ToString() != null && Properties.Settings.Default["Otp"].ToString() == "True") label2.Text = "Включена";
            else label2.Text = "Выключена";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null) Properties.Settings.Default["Adress"] = textBox1.Text;
            if (checkBox1.Checked == true) Properties.Settings.Default["Otp"] = true;
            else Properties.Settings.Default["Otp"] = false;
            Properties.Settings.Default.Save();
            textBox1.Text = Properties.Settings.Default["Adress"].ToString();
            if (Properties.Settings.Default["Otp"].ToString() == "False") label2.Text = "Выключена";
            else label2.Text = "Включена";
            MessageBox.Show("Настройки почты успешно изменены!");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null && textBox3.Text != null && textBox4.Text != null && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "")
            {
                if (textBox3.Text == textBox4.Text)
                {
                    Properties.Settings.Default["Login"] = textBox2.Text;
                    Properties.Settings.Default["Password"] = textBox3.Text;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Данные для входа успешно изменены!");
                }
                else MessageBox.Show("Парли не совпадают!");
            }
            else MessageBox.Show("Поля не заполнены!");
        }
    }
}
