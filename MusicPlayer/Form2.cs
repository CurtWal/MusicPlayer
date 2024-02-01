using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Player.uiMode = "none";
            trackVolume.Value = 50;
            lblVolume.Text = "50%";
        }
        String[] paths, files;

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void listSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player.URL = paths[listSongs.SelectedIndex];
            Player.Ctlcontrols.play();
            timer1.Start();
            try
            {
                var file = TagLib.File.Create(paths[listSongs.SelectedIndex]);
                var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                picArt.Image = Image.FromStream(new MemoryStream(bin));
            }
            catch
            {

            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Player.Ctlcontrols.stop();
            pBar.Value = 0;
            textSearch.Text = "Search";
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Player.Ctlcontrols.pause();
            textSearch.Text = "Search";
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Player.Ctlcontrols.play();
            textSearch.Text = "Search";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(listSongs.SelectedIndex < listSongs.Items.Count - 1)
            {
                listSongs.SelectedIndex = listSongs.SelectedIndex + 1;
            }
            else
            {
                // Stop the player
                Player.Ctlcontrols.stop();
            }
            textSearch.Text = "Search";
        }

        private void btnPev_Click(object sender, EventArgs e)
        {
            if (listSongs.SelectedIndex > 0)
            {
                listSongs.SelectedIndex = listSongs.SelectedIndex - 1;
            }
            else
            {
                // Stop the player
                Player.Ctlcontrols.stop();
            }
            textSearch.Text = "Search";

        }
        //private int b = 0;
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                
                //Progress bar duration of the song
                pBar.Maximum = (int)Player.Ctlcontrols.currentItem.duration;
                //Progress bar current postions of the song
                pBar.Value = (int)Player.Ctlcontrols.currentPosition;

                //Skip to next song auto 
                if (pBar.Maximum <= pBar.Value)
                {
                    btnNext.PerformClick();
                }

            }
            try
            {
                //Track the current time of the song
                lblStart.Text = Player.Ctlcontrols.currentPositionString;
                //Check to see the duration of the song
                lblEnd.Text = Player.Ctlcontrols.currentItem?.durationString.ToString();

                
                //if(lblStart.Text == lblEnd.Text)
                //{
                //    try
                //    {
                //        if (listSongs.SelectedIndex < listSongs.Items.Count - 1)
                //        {
                //            listSongs.SelectedIndex = listSongs.SelectedIndex + 1;
                //            // b = 0;
                //        }
                //        else
                //        {
                //            // Stop the player
                //            Player.Ctlcontrols.stop();
                //        }
                //    }
                //    catch
                //    {

                //    }
                //    // b = 1;
                //}
            }
            catch
            {

            }
           
        }

        private void trackVolume_Scroll(object sender, EventArgs e)
        {
            Player.settings.volume = trackVolume.Value;
            lblVolume.Text = trackVolume.Value.ToString() + "%";
        }

        private void pBar_MouseDown(object sender, MouseEventArgs e)
        {
            //Allow the user to click progress bar to skip forward and backwards in the song
            Player.Ctlcontrols.currentPosition = Player.currentMedia.duration * e.X / pBar.Width;
        }
        private void btnShuffle_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int w = paths.Length;

            while (w > 1)
            {
                w--;
                int u = random.Next(w + 1);
                string temp = paths[u];
                paths[u] = paths[w];
                paths[w] = temp;
            }

            listSongs.Items.Clear();
            foreach (string path in paths)
            {
                listSongs.Items.Add(Path.GetFileName(path));
            }


            // Reset selected index to avoid potential issues with playback state
            listSongs.SelectedIndex = 0;
        }
        private void textSearch_MouseClick(object sender, MouseEventArgs e)
        {
            textSearch.Text = "";

        }

        private void textSearch_KeyUp(object sender, KeyEventArgs e)
        {
            int index = listSongs.FindString(textSearch.Text);
            if (0 <= index)
            {
                listSongs.SelectedIndex = index;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //Code to selecte multiple files
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.SafeFileNames; //Save the names of the tracks in files array
                paths = (paths ?? Enumerable.Empty<string>()).Concat(ofd.FileNames).ToArray();//Save the names of the tracks in paths array
                //Display the music titles in listbox
                for (int i = 0; i < files.Length; i++)
                {
                    listSongs.Items.Add(files[i]); //Display songs in listbox
                }
            }
        }
    }
}
