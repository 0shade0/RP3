﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
 
namespace Pacman
{
    public class Pacman : movableCharacter
    {
        protected int score = 0;
        protected int lives = 3;
        protected int level = 1;

        protected Label scoreLabel = new Label();
        protected Label levelLabel = new Label();
        public Pacman (Form form) : base(form) 
        {

            // Score label.
            scoreLabel.ForeColor = Color.White;
            scoreLabel.Text = "Score: 0";
            scoreLabel.Location = new Point(12, 9);
            scoreLabel.BackColor = Color.DarkBlue;
            scoreLabel.Font = new Font("Arial", 16);
            scoreLabel.AutoSize = true;
            form.Controls.Add(scoreLabel);

            // Level label.
            levelLabel.Width = form.Width / 2;
            levelLabel.ForeColor = Color.White;
            levelLabel.Text = "Level: 0";
            levelLabel.TextAlign = ContentAlignment.TopRight;
            levelLabel.BackColor = Color.DarkBlue;
            levelLabel.Font = new Font("Arial", 16);
            levelLabel.AutoSize = true;
            levelLabel.Location = new Point(form.Width - levelLabel.Width - 12, 9);
            form.Controls.Add(levelLabel);
        }

        protected override void characterTimerTick(object sender, EventArgs e)
        {
            drawCharacter();
            drawScoreAndLevel();
            checkSquare();
            moveCharacter();
        }

        public void drawScoreAndLevel()
        {
            scoreLabel.Text = "Score: " + score;
            scoreLabel.BringToFront();
            levelLabel.Text = "Level: " + level;
            levelLabel.BringToFront();
        }
        public void incrementScore(int x)
        {
            score += x;
        }

        public void nextLevel()
        {
            level += 1;
            Form1.grid.resetGrid();
            increaseSpeed(5);
            i = Form1.startPoint.Y;
            j = Form1.startPoint.X;
            currentDirection = Direction.None;

            // TODO: Resetirati duhove i ostalo što treba.
        }

        public void checkSquare()
        {
            char square = Form1.grid.getSquareValue(i, j);

            if (square == '*')
                Food.eatCookie(i, j);
            else if (square == 'o')
                Food.eatSuperCookie(i, j);
        }
    }
}