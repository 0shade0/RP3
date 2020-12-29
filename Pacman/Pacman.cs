using System;
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
        public Pacman (Form form, Point squareSize, Point startingPoint, Grid grid) : base(form, squareSize, startingPoint, grid)
        {

        }
    }
}
