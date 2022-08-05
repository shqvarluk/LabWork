using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using DP.Properties;


namespace DP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();
        Font myFont;
        private void Form1_Load(object sender, EventArgs e)
        {
            byte[] fontData = Resources.GOST_type_A;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Resources.GOST_type_A.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.GOST_type_A.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            myFont = new Font(fonts.Families[0], 12.0F);

            label1.Font = myFont;
            label2.Font = myFont;
            label3.Font = myFont;
            button1.Font = myFont;
        }
        void Button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Заполните все поля!");
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
            }
            else
            {
                Form2 f2 = new Form2();
                f2.SurnameStudent = this.textBox1.Text;
                f2.NameStudent = this.textBox2.Text;
                f2.GroupStudent = this.textBox3.Text;
                f2.myfont = myFont;
                this.Hide();
                f2.Show();
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.myFont = myFont;
            f3.Show();
            this.Hide();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.myFont = myFont;
            f5.Show();
        }
    }
}
