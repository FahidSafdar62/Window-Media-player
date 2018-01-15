using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Window_Media_player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] files, paths;


        private void Form1_Load(object sender, EventArgs e)
        {
// give the path of your video here
        axWindowsMediaPlayer1.URL = "Path of your video";
        // this line will automatically start your video
        axWindowsMediaPlayer1.settings.autoStart = true;
        //here the system will automatially create a thread and will keep on 
         
        axWindowsMediaPlayer1.settings.setMode("loop", true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
        
          
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.TxtPath.Text = openFileDialog1.FileName;
            }
        }

        AxWMPLib.AxWindowsMediaPlayer wmPlayer;
        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = TxtPath.Text;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            wmPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            wmPlayer.CreateControl();
            wmPlayer.enableContextMenu = false;
            ((System.ComponentModel.ISupportInitialize)(wmPlayer)).BeginInit();
            wmPlayer.Name = "wmPlayer";
            wmPlayer.Enabled = true;
            wmPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(wmPlayer);
            ((System.ComponentModel.ISupportInitialize)(wmPlayer)).EndInit();
            wmPlayer.uiMode = "none";
            wmPlayer.URL = @"C:\...";
            wmPlayer.settings.setMode("loop", true);

            wmPlayer.Ctlcontrols.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void button6_Click(object sender, EventArgs e)
        {
             OpenFileDialog openFileDialog1 = new OpenFileDialog();
             openFileDialog1.Multiselect = true;
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = openFileDialog1.SafeFileNames;
                paths = openFileDialog1.FileNames;
                for (int i = 0; i < files.Length; i++)
                {
                    listBox1.Items.Add(files[i]);
                }
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = paths[listBox1.SelectedIndex];
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void axShockwaveFlash1_Enter(object sender, EventArgs e)
        {

        }
    }
}
