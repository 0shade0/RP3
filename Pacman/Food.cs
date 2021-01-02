using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Food
    {
        public static void eatCookie(int i, int j)
        {
            Form1.grid.decrementCntCookie();
            Form1.grid.clearSquare(i, j);
            Form1.pacman.incrementScore(10);

            if (Form1.grid.noMoreCookies())
                Form1.pacman.nextLevel();           
        }

        public static void eatSuperCookie(int i, int j)
        {
            Form1.grid.decrementCntCookie();
            Form1.grid.clearSquare(i, j);
            Form1.pacman.incrementScore(50);

            if (Form1.grid.noMoreCookies())
                Form1.pacman.nextLevel();

            Form1.redGhost.flee(Form1.SuperCookieDuration);
            Form1.pinkGhost.flee(Form1.SuperCookieDuration);
            Form1.blueGhost.flee(Form1.SuperCookieDuration);
            Form1.orangeGhost.flee(Form1.SuperCookieDuration);
        }
    }
}
