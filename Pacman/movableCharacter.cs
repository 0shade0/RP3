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
        // Nova lista u koje spremamo slike, za sad korišteno samo za Pacmana.
        protected List<Bitmap> characterImages = new List<Bitmap>();
        protected int currentImage; // Indeks trenutne slike u listi.
        // Timer za movableCharacter objekte.
        protected Timer characterTimer = new Timer();
        protected int timerInterval = 160; // Dijeljivo sa 4!

        // Konstruktor.
        public movableCharacter(Form form)
        {
            // Postavljanje timera. Event handler characterTimerTick
            // se izvodi svakih 150ms. Zamišljeno je da se, kad treba promijeniti brzinu, 
            // smanjuje ili povećava characterTimer.Interval.
            characterTimer.Interval = timerInterval;
            characterTimer.Tick += new EventHandler(characterTimerTick);

            // Pacman, duhovi i voće overridaju ovu metodu sa svojim startnim kordinatama. 
            i = startI;
            j = startJ;
           
            characterPictureBox.Size = new Size(Form1.squareSize.X, Form1.squareSize.Y);
            // Likovi su crtani na svojim početnim pozicijama (inače ih slika u gornjem lijevom kutu).
            characterPictureBox.Location = new Point(j * Form1.squareSize.X, i * Form1.squareSize.Y);
            characterPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            // Ovdje je bezveze dodan neki prvi element u characterImages, da ne bi došlo do grešaka.
            // Treba obrisati kad se dodaju stvarne slike.
            characterImages.Add(Properties.Resources.cookieImage);
            currentImage = 0;

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
            if (timerInterval >= 48)
                characterTimer.Interval = timerInterval;
        }

        public void halveSpeed()
        {
            timerInterval *= 2;
            characterTimer.Interval *= 2;
        }

        public void doubleSpeed()
        {
            timerInterval /= 2;
            characterTimer.Interval /= 2;
        }
        public virtual void changeDirection(Direction dir)
        {
            if (movePossible(dir))
                currentDirection = dir;
        }

        public virtual void moveCharacter()
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
            // Ažuriranje pozicije i slike.
            characterPictureBox.Location = new Point(j* Form1.squareSize.X, i* Form1.squareSize.Y);
            characterPictureBox.Image = characterImages[currentImage];
        }

        ///
        /// Dio potreban/vezan za implementaciju duhova.
        ///

        // Služi duhovima za pristup pacmanovoj lokaciji.
        public int I
		{
            get { return i; }
		}
        public int J
		{
            get { return j; }
		}

        // Služi duhovima za pristup pacmanovom smjeru kretanja,
        public Direction CurrentDirection 
        {
            get { return currentDirection; }
        }

        public Direction oppositeDirection(Direction dir)
		{
            switch(dir)
            {
                case Direction.Left:
                    return Direction.Right;
                case Direction.Right:
                    return Direction.Left;
                case Direction.Up:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Up;
                default:
                    return Direction.None;
            }
        }

        // Početne koordinate, podklase ovu metodu overridaju sa svojim početnim koordinatama.
        public virtual int startI 
        {
            get { return 0; }
        }
        public virtual int startJ 
        {
            get { return 0; }
        }
    }
}
