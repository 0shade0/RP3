using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pacman
{
    public abstract class Fruit : movableCharacter
    {
        // Je li voće trulo.
        protected bool rotten;
        // Preostalo vrijeme postojanja voća na ekranu.
        protected int remainingTimeOnScreen = Form1.FruitOnScreenDuration;
        // Voće se samo pojavljuje u nasumičnom trenutku.
        protected Random rand;

        public Fruit(Form form, bool _rotten) : base(form)
        {
            rotten = _rotten;
            // Sakrij voće.
            characterPictureBox.Visible = false;
        }

        // Početne koordinate voća su (0, 0) (postavljaju se u
        // movableCharacter konstruktoru). Ta pozicija
        // također označava da voće trenutno nije na ekranu.
        public void removeFromMap()
        {
            i = 0; j = 0;
            characterPictureBox.Visible = false;
        }

        // Je li voće trenutno na ekranu.
        public bool OnScreen
        {
            get
            {
                return (i == 0) && (j == 0);
            }
        }

        protected override void characterTimerTick(object sender, EventArgs e)
        {
            drawCharacter();
            checkSquare();
            moveCharacter();
            // Voće treba nestati za 25 sekundi.
            if (remainingTimeOnScreen > 0) remainingTimeOnScreen -= timerInterval;
            else removeFromMap();

            // Voće se samo brine za pojavu na ekranu. Ako već nije na ekranu,
            // automatski se pojavljuje.
            if (!OnScreen)
            {
                // TO DO.
            }
        }

        // Za testiranje, pojavljuje se na koordinatama (i, j).
        public void appear(int _i, int _j)
        {
            i = _i;
            j = _j;
            characterPictureBox.Visible = true;
        }

        public abstract void checkSquare();
    }

    public class Strawberry : Fruit
    {
        public Strawberry(Form form, bool _rotten) : base(form, _rotten)
        {
            if (_rotten)
                characterImages[0] = Properties.Resources.StrawberryRotten;
            else
                characterImages[0] = Properties.Resources.Strawberry;
        }

        public override void checkSquare()
        {
            if (Form1.pacman.I == i && Form1.pacman.J == j)
            {
                // Javi duhovima da je jagoda pojedena.
                if (rotten)
                {
                    Form1.blueGhost.ateRottenStrawberrie();
                    Form1.pinkGhost.ateRottenStrawberrie();
                    Form1.orangeGhost.ateRottenStrawberrie();
                    Form1.redGhost.ateRottenStrawberrie();
                }
                else
                {
                    Form1.blueGhost.ateStrawberrie();
                    Form1.pinkGhost.ateStrawberrie();
                    Form1.orangeGhost.ateStrawberrie();
                    Form1.redGhost.ateStrawberrie();
                }
                removeFromMap();
            }
        }
    }

    public class Cherry : Fruit
    {
        public Cherry(Form form, bool _rotten) : base(form, _rotten)
        {
            if (_rotten)
                characterImages[0] = Properties.Resources.CherriesRotten;
            else
                characterImages[0] = Properties.Resources.Cherries;
        }

        public override void checkSquare()
        {
            if (Form1.pacman.I == i && Form1.pacman.J == j)
            {
                // Javi Pacmanu da je trešnja pojedena.
                Form1.pacman.ateCherry(rotten);
                removeFromMap();
            }
        }
    }

    public class Pear : Fruit
    {
        public Pear(Form form, bool _rotten) : base(form, _rotten)
        {
            if (_rotten)
                characterImages[0] = Properties.Resources.PearRotten;
            else
                characterImages[0] = Properties.Resources.Pear;
        }
        public override void checkSquare()
        {
            if (Form1.pacman.I == i && Form1.pacman.J == j)
            {
                // Javi Pacmanu da je kruška pojedena.
                Form1.pacman.atePear(rotten);
                removeFromMap();
            }
        }

    }

    public class GoldenApple : Fruit
    {
        // Zlatna jabuka ne može biti trula.
        public GoldenApple(Form form, bool _rotten) : base(form, false)
        {
            characterImages[0] = Properties.Resources.AppleGolden;
        }

        public override void checkSquare()
        {
            if (Form1.pacman.I == i && Form1.pacman.J == j)
            {
                // Dodaj život Pacmanu.
                Form1.pacman.addLife();
                removeFromMap();
            }
        }
    }



}
