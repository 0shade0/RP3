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
        
        protected int x, y; // Koordinate u polju.
        protected int speed = 10;
        protected Direction dir = Direction.None;
        protected PictureBox characterPictureBox = new PictureBox();
        Timer characterTimer = new Timer();

        // Konstruktor.
        public movableCharacter(Form form)
        {
            // Postavljanje timera. Event handler characterTimerTick
            // se izvodi svakih 100ms.
            characterTimer.Interval = 100;
            characterTimer.Enabled = true;
            characterTimer.Tick += new EventHandler(characterTimerTick);
            characterTimer.Start();
            characterPictureBox.BackColor = Color.Yellow;

            form.Controls.Add(characterPictureBox);
        }

        private void characterTimerTick (object sender, EventArgs e)
        {
            moveCharacter();
            drawCharacter();
        }

        // Svojstva.
        public Direction Dir
        {
            get { return dir; }
            set { dir = value; }
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public void moveCharacter()
        {
            if (dir == Direction.Left)
                x -= speed;
            else if (dir == Direction.Right)
                x += speed;
            else if (dir == Direction.Up)
                y -= speed;
            else if (dir == Direction.Down)
                y += speed;
        }

        public void drawCharacter()
        {
            characterPictureBox.Location = new Point(x, y);
        }

    }
}
