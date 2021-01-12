﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        public Form2 main;
        // Javno tako da možemo pristupati drugim elementima
        // iz svih klasa.
        public static Pacman pacman;
        public static Grid grid;
        public static Point squareSize = new Point(16, 16);
        public static Point startPoint = new Point(13, 25);

        public static RedGhost redGhost;
        public static PinkGhost pinkGhost;
        public static BlueGhost blueGhost;
        public static OrangeGhost orangeGhost;

        // Povećanje brzine po levelu.
        public static int SpeedIncPerLevel = 4;
        public static bool paused = false;

        public Form1(Form2 parent)
        {
            main = parent;
            InitializeComponent();
            formSetup();
        }

        public void formSetup()
        {
            SuspendLayout();
            this.Size = new Size(29 * squareSize.X, 37 * squareSize.Y);
            grid = new Grid(this, startPoint);
            pacman = new Pacman(this);
            redGhost = new RedGhost(this);
            pinkGhost = new PinkGhost(this);
            blueGhost = new BlueGhost(this);
            orangeGhost = new OrangeGhost(this);
            
            pacman.startTimer();
            redGhost.startTimer();
            pinkGhost.startTimer();
            blueGhost.startTimer();
            orangeGhost.startTimer();
            ResumeLayout();

            label1.Hide();
            panel1.Hide();
        }

        public static void stopGame()
        {
            pacman.stopTimer();
            redGhost.stopTimer();
            pinkGhost.stopTimer();
            blueGhost.stopTimer();
            orangeGhost.stopTimer();

            paused = true;
        }

        public static void startGame()
        {
            pacman.startTimer();
            redGhost.startTimer();
            pinkGhost.startTimer();
            blueGhost.startTimer();
            orangeGhost.startTimer();

            paused = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var key = e.KeyCode;
            if (paused && key != Keys.Escape) return;
            switch(key)
            {
                case Keys.Left:
                case Keys.A:
                    pacman.changeDirection(Pacman.Direction.Left);
                    break;
                case Keys.Up:
                case Keys.W:
                    pacman.changeDirection(Pacman.Direction.Up);
                    break;
                case Keys.Right:
                case Keys.D:
                    pacman.changeDirection(Pacman.Direction.Right);
                    break;
                case Keys.Down:
                case Keys.S:
                    pacman.changeDirection(Pacman.Direction.Down);
                    break;
                case Keys.Escape:
                    Pause();
                    break;
            }
        }
        public void Pause()
        {
            SuspendLayout();
            stopGame();
            panel1.Show();
            label1.Show();
            panel1.BringToFront();
            main.showPauseMenu();
            main.focusButton();
            ResumeLayout();
        }

        public void Unpause()
        {
            SuspendLayout();
            startGame();
            panel1.Hide();
            label1.Hide();
            main.hidePauseMenu();
            ResumeLayout();
        }
        // Funkcija koje osigurava da glavna forma prepoznaje inpute strjelica
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down);
            base.OnPreviewKeyDown(e);
        }

        // Pomoćna funkcija.
        public static int manhattanDistance(int i1, int j1, int i2, int j2)
        {
            return Math.Abs(i1 - i2) + Math.Abs(j1 - j2);
        }

        // Trajanje superKolaća, 7 sekundi na levelu 1, 0 sekundi na levelu 21 i dalje.
        public static int SuperCookieDuration
        {
            get 
            {
                return Math.Max(7000 - 350 * (Form1.pacman.Level - 1), 0);
            }
        }

        public static int PacmanDefaultSpeed
        {
            // Place holder, treba napraviti da ovisi i o tipu igre.
            get { return Math.Max(48, 160 - SpeedIncPerLevel * (Form1.pacman.Level - 1)); }
        }

        // Trajanje voća koje odmaže pacmanu, 7 sekundi.
        public static int RottenFruitDuration
        {
            get 
            {
                return 7000;
            }
        }
    }
}
