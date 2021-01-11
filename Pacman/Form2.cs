﻿using System;
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
        public Form2()
        {
            InitializeComponent();
            Sounds.InitializeSounds();
            SetMusic("Focus");

            button1.Hide();
            button2.Hide();
            Form1.paused = true;
        }

        private void SetMusic(string name)
        {
            axWindowsMediaPlayer1.settings.setMode("Loop", true);
            axWindowsMediaPlayer1.settings.volume = 25;
            string path = Path.GetFullPath(Path.Combine(System.Windows.Forms.Application.StartupPath, @"../../Resources/"));
            axWindowsMediaPlayer1.URL = path + name + ".mp3";
            axWindowsMediaPlayer1.Ctlcontrols.play();
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
            if(!Form1.paused) SetMusic("Focus");
            foreach (Control obj in this.Controls)
                if (obj.GetType() == typeof(Form3)) obj.Dispose();
                else
                    if (obj.GetType() == typeof(Form1))
                    {
                        Form1.stopGame();
                        obj.Dispose();
                    }

            menu.Show();
            button1.Hide();
            button2.Hide();
        }
    }
}
