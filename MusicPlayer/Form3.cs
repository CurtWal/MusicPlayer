using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MusicPlayer
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string websiteName = "https://github.com/CurtWal"; //or simply write the webiste name instead of textBox1.Text      
            System.Diagnostics.Process.Start("iexplore.exe", websiteName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string websiteName = "https://www.linkedin.com/in/curtrick-walton-553b4925a/"; //or simply write the webiste name instead of textBox1.Text      
            System.Diagnostics.Process.Start("iexplore.exe", websiteName);
        }
    }
}
