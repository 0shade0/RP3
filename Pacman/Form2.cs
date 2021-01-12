using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pacman
{
    public partial class Form2 : Form
    {
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
        public Form2()
        {
            InitializeComponent();
            InitializeMusic();
            SetMusic("Focus");
            Sounds.InitializeSounds();

            button1.Hide();
            button2.Hide();
        }

        public void InitializeMusic()
        {
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Visible = false;

            this.Controls.Add(this.mediaPlayer);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
        }
        public void SetMusic(string name)
        {
            mediaPlayer.settings.setMode("Loop", true);
            mediaPlayer.settings.volume = 25;
            string path = Path.GetFullPath(Path.Combine(System.Windows.Forms.Application.StartupPath, @"../../Resources/"));
            mediaPlayer.URL = path + name + ".mp3";
            mediaPlayer.Ctlcontrols.play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sounds.menuSound.Play();
            SetMusic("Valor");
            menu.Hide();
            Form1 objForm = new Form1();
            objForm.TopLevel = false;
            this.Controls.Add(objForm);
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Left = (this.ClientSize.Width - objForm.Width) / 2;
            objForm.Show();
            objForm.Focus();
            objForm.KeyPreview = true;
            button1.Show();
            Form1.startGame();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sounds.menuSound.Play();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sounds.menuSound.Play();
            menu.Hide();
            Form3 objForm = new Form3();
            objForm.TopLevel = false;
            this.Controls.Add(objForm);
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Left = (this.ClientSize.Width - objForm.Width) / 2;
            objForm.Top = (this.ClientSize.Height - objForm.Height) / 2;
            objForm.Show();
            button1.Show();
            button2.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Sounds.menuSound.Play();
            foreach (Control obj in this.Controls)
                if (obj.GetType() == typeof(Form3)) obj.Dispose();
                else
                    if (obj.GetType() == typeof(Form1))
                    {
                        Form1.stopGame();
                        obj.Dispose();
                        SetMusic("Focus");
                    }

            menu.Show();
            button1.Hide();
            button2.Hide();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
