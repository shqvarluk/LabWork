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
    public partial class Form5 : Form
    {
        
        public Form5()
        {
            InitializeComponent();
        }
        public Font myFont;
        void Form5_Load(object sender, EventArgs e)
        {
            label1.Font = myFont;
            label2.Font = myFont;
            button1.Font = myFont;
        }
        void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == Properties.Settings.Default["Login"].ToString() && textBox2.Text == Properties.Settings.Default["Password"].ToString())
            {
                Form6 f6 = new Form6();
                f6.myFont = myFont;
                f6.Show();
                this.Close();
            }
            else
            {
                textBox1.Text = null;
                textBox2.Text = null;
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        
    }
}
