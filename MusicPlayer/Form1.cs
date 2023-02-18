using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void customizeDesign()
        {
            subMenu.Visible= false;
            pnlPlaylistMenu.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void hideSubMenu()
        {
            if (subMenu.Visible == true)
            {
                subMenu.Visible = false;
            }
                if(pnlPlaylistMenu.Visible == true)
                {
                    pnlPlaylistMenu.Visible = false;
                }
            
        }

        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void Musicbtn_Click(object sender, EventArgs e)
        {
            showSubMenu(subMenu);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2());
            hideSubMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlPlaylistMenu);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openChildForm(new Form4());
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm != null)
                activeForm.Close();
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelChildForm.Controls.Add(childForm);
                panelChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
