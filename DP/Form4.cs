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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public Font myFont;
        void Form4_Load(object sender, EventArgs e)
        {
            label1.Font = myFont;
            label2.Font = myFont;
            label3.Font = myFont;
            label4.Font = myFont;
            label5.Font = myFont;
            button1.Font = myFont;
        }
        void Button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Close();
        }
    }
}
