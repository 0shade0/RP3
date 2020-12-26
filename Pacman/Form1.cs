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
        public Form1()
        {
            InitializeComponent();
            pacman = new Pacman(this);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                pacman.Dir = Pacman.Direction.Left;
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                pacman.Dir = Pacman.Direction.Up;
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                pacman.Dir = Pacman.Direction.Right;
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                pacman.Dir = Pacman.Direction.Down;
        }
    }
}
