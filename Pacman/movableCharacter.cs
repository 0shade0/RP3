using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Pacman
{
    public class movableCharacter
    {
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down,
            None
        }
        
        protected int i, j; // Koordinate u polju.
        protected Direction currentDirection = Direction.None;
        // Ovdje se može spremiti i više slika, za gledanje u raznim smjerovima
        // pa mijenjati u changeDirection.
        protected PictureBox characterPictureBox = new PictureBox();
        // Timer za movableCharacter objekte.
        Timer characterTimer = new Timer();
        protected int timerInterval = 150;

        // Konstruktor.
        public movableCharacter(Form form)
        {
            // Postavljanje timera. Event handler characterTimerTick
            // se izvodi svakih 150ms. Zamišljeno je da se, kad treba promijeniti brzinu, 
            // smanjuje ili povećava characterTimer.Interval.
            characterTimer.Interval = timerInterval;
            characterTimer.Tick += new EventHandler(characterTimerTick);
            characterPictureBox.BackColor = Color.Yellow;

            i = Form1.startPoint.Y;
            j = Form1.startPoint.X;

            characterPictureBox.Size = new Size(Form1.squareSize.X, Form1.squareSize.Y);
            form.Controls.Add(characterPictureBox);
            characterPictureBox.BringToFront();
        }

        public void startTimer()
        {
            characterTimer.Start();
        }

        protected virtual void characterTimerTick (object sender, EventArgs e)
        {
            drawCharacter();
            moveCharacter();
        }

        public void increaseSpeed(int x)
        {
            timerInterval -= x;
            if (timerInterval > 50)
                characterTimer.Interval = timerInterval;
        }

        public void changeDirection(Direction dir)
        {
            if (movePossible(dir))
                currentDirection = dir;
        }

        public void moveCharacter()
        {
            // Lijevi portal se nalazi na indeksu [16, 0], a desni na [16, 27]
            if (i == 16 && j == 0 && currentDirection == Direction.Left)
                j = 27;
            else if (i == 16 && j == 27 && currentDirection == Direction.Right)
                j = 0;
            else if (movePossible(currentDirection))
            {
                switch (currentDirection)
                {
                    /* Zamišljeno je da se koordinata uvijek povećava za 1, a
                    kad treba povećati brzinu, smanjuje se characterTimer.Interval. */ 
                    case Direction.Left:
                        j -= 1;
                        break;
                    case Direction.Right:
                        j += 1;
                        break;
                    case Direction.Up:
                        i -= 1;
                        break;
                    case Direction.Down:
                        i += 1;
                        break;
                }
            }
        }
        public bool movePossible(Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                    return j > 0 && Form1.grid.getSquareValue(i, j - 1) != '#';
                case Direction.Right:
                    return j < 27 && Form1.grid.getSquareValue(i, j + 1) != '#';
                case Direction.Up:
                    return i > 0 && Form1.grid.getSquareValue(i - 1, j) != '#';
                case Direction.Down:
                    return i < 35 && Form1.grid.getSquareValue(i + 1, j) != '#';
                default:
                    return true;
            }
        }

        public void drawCharacter()
        {
            characterPictureBox.Location = new Point(j* Form1.squareSize.X, i* Form1.squareSize.Y);
        }

    }
}
