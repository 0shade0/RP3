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
        private Form1 activeGame;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
        public Form2()
        {
            InitializeComponent();
            InitializeMusic();
            SetMusic("Focus");
            InitializeButtons();
            Sounds.InitializeSounds();
        }

        public void focusButton()
        {
            button3.Focus();
        }

        public void showPauseMenu()
        {
            panel2.Show();
            button1.Show();
            button2.Show();
            button3.Show();
        }

        public void hidePauseMenu()
        {
            button1.Hide();
            button2.Hide();
            button3.Hide();
            panel2.Hide();
        }

        public void setGameover()
        {
            activeGame.setGameover();
            button3.Text = "RESET";
            button3.Click -= button3_Click_1;
            button3.Click += button3_Click_2;
        }

        public void setPause()
        {
            activeGame.setPause();
            button3.Text = "PLAY";
            button3.Click -= button3_Click_2;
            button3.Click += button3_Click_1;
        }


        private void InitializeButtons()
        {
            hidePauseMenu();

            newgame.GotFocus += buttonEnter;
            options.GotFocus += buttonEnter;
            exitgame.GotFocus += buttonEnter;

            newgame.LostFocus += buttonLeave;
            options.LostFocus += buttonLeave;
            exitgame.LostFocus += buttonLeave;
        }

        private void InitializeMusic()
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
            activeGame = new Form1(this);
            activeGame.TopLevel = false;
            this.Controls.Add(activeGame);
            activeGame.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            activeGame.Left = (this.ClientSize.Width - activeGame.Width) / 2;
            activeGame.Show();
            activeGame.Focus();
            activeGame.KeyPreview = true;
            panel1.Hide();
            setPause();
            Form1.startGame();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sounds.menuSound.Play();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            Sounds.menuSound.Play();
            menu.Hide();
            panel1.Hide();
            Form3 activeGame = new Form3(this);
            activeGame.TopLevel = false;
            this.Controls.Add(activeGame);
            activeGame.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            activeGame.Left = (this.ClientSize.Width - activeGame.Width) / 2;
            activeGame.Top = (this.ClientSize.Height - activeGame.Height) / 2;
            activeGame.Show();
            ResumeLayout();

            activeGame.focusButton();
        }

        public void button1_Click_1(object sender, EventArgs e)
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
            hidePauseMenu();
            panel1.Show();
            newgame.Focus();
        }

        private void buttonEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.GhostWhite;
        }

        private void buttonLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.Yellow;
        }

        private void menu_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down);
            Sounds.eatSound.Play();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Sounds.menuSound.Play();
            if (activeGame != null) activeGame.Unpause();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Sounds.menuSound.Play();
            Sounds.disableMenuSounds();
            Form1.stopGame();
            activeGame.Dispose();
            button1_Click(sender, e);
            Sounds.enableMenuSounds();
        }
    }
}
