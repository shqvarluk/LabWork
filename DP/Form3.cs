using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DP
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public Font myFont;

        void Form3_Load(object sender, EventArgs e)
        {
            label1.Font = myFont;
            label2.Font = myFont;
            label3.Font = myFont;
            button1.Font = myFont;
        }

        void Button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }
    }
}
