using System;
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
        // Javno tako da možemo pristupati drugim elementima
        // iz svih klasa.
        public static Pacman pacman;
        public static Grid grid;
        public static Point squareSize = new Point(16, 16);
        public static Point startPoint = new Point(13, 25);
        public Form1()
        {
            InitializeComponent();
            formSetup();
        }

        public void formSetup()
        {
            SuspendLayout();
            this.Size = new Size(29 * squareSize.X, 37 * squareSize.Y);
            grid = new Grid(this, startPoint);
            pacman = new Pacman(this);
            pacman.startTimer();
            ResumeLayout();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var key = e.KeyCode;
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
            }
        }
    }
}
