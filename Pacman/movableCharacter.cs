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
        protected PictureBox characterPictureBox = new PictureBox();
        protected Grid grid;
        protected Point squareSize;
        Timer characterTimer = new Timer();

        // Konstruktor.
        public movableCharacter(Form form, Point _squareSize, Point startingPoint, Grid _grid)
        {
            // Postavljanje timera. Event handler characterTimerTick
            // se izvodi svakih 150ms. Zamišljeno je da se, kad treba promijeniti brzinu, 
            // smanjuje ili povećava characterTimer.Interval.
            characterTimer.Interval = 150;
            characterTimer.Enabled = true;
            characterTimer.Tick += new EventHandler(characterTimerTick);
            characterTimer.Start();
            characterPictureBox.BackColor = Color.Yellow;

            i = startingPoint.Y;
            j = startingPoint.X;

            grid = _grid;
            squareSize = _squareSize;

            characterPictureBox.Size = new Size(squareSize.X, squareSize.Y);
            form.Controls.Add(characterPictureBox);
            characterPictureBox.BringToFront();
        }

        private void characterTimerTick (object sender, EventArgs e)
        {
            drawCharacter();
            moveCharacter();
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
            Console.WriteLine(i.ToString() + ", " + j.ToString());
            switch (dir)
            {
                case Direction.Left:
                    return j > 0 && grid.getSquareValue(i, j - 1) == '-';
                case Direction.Right:
                    return j < 27 && grid.getSquareValue(i, j + 1) == '-';
                case Direction.Up:
                    return i > 0 && grid.getSquareValue(i - 1, j) == '-';
                case Direction.Down:
                    return i < 35 && grid.getSquareValue(i + 1, j) == '-';
                default:
                    return true;
            }
        }

        public void drawCharacter()
        {
            characterPictureBox.Location = new Point(j*squareSize.X, i*squareSize.Y);
        }

    }
}
