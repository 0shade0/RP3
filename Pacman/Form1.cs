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
        Pacman pacman;
        Grid grid;
        Point squareSize = new Point(16, 16);
        public Form1()
        {
            InitializeComponent();
            formSetup();
        }

        public void formSetup()
        {
            this.Size = new Size(29 * squareSize.X, 37 * squareSize.Y);
            grid = new Grid(this, squareSize);
            pacman = new Pacman(this, squareSize, new Point(13, 25), grid);
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
