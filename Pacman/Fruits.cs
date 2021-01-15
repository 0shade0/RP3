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
        protected static Random rand;
        // Enumeracija smjerova u polju, za nasumično biranje.
        protected static Pacman.Direction[] directions = {
            Pacman.Direction.Left,
            Pacman.Direction.Up,
            Pacman.Direction.Right,
            Pacman.Direction.Down
        };

        public Fruit(Form form, bool _rotten) : base(form)
        {
            rotten = _rotten;
            // Sakrij voće.
            characterPictureBox.Visible = false;
            rand = new Random();

            // Nasumično odaberi smjer kretanja.
            int directionIndex = rand.Next(0, 4);
            currentDirection = directions[directionIndex];

            // Voće se miče sporije od ostalih likova.
            timerInterval = 500;
            characterTimer.Interval = timerInterval;
        }

        // Početne koordinate voća su (0, 0) (postavljaju se u
        // movableCharacter konstruktoru). Ta pozicija
        // također označava da voće trenutno nije na ekranu.
        public void removeFromMap()
        {
            characterPictureBox.Visible = false;
            i = 0; j = 0;
        }

        // Je li voće trenutno na ekranu.
        public bool OnScreen
        {
            get
            {
                return i != 0 || j != 0;
            }
        }

        public bool Rotten
        {
            get { return rotten; }
        }

        protected override void characterTimerTick(object sender, EventArgs e)
        {
            drawCharacter();
            checkSquare();
            moveCharacter();
            // Voće treba nestati za 25 sekundi.
            if (remainingTimeOnScreen > 0) remainingTimeOnScreen -= timerInterval;
            else if (this.OnScreen) removeFromMap();

            // Voće se samo brine za pojavu na ekranu. Ako već nije na ekranu,
            // automatski se pojavljuje. Ne može se pojaviti na poljima gdje
            // je zid ili neko drugo voće.
            if (!OnScreen)
                randomFruitGenerator();
        }

        public override void moveCharacter()
        {
            // Ako je trenutno na ekranu i ne može se kretati, odaberi novi smjer kretanja.
            if (this.OnScreen && !movePossible(currentDirection))
            {
                int directionIndex = rand.Next(0, 4);
                while (!movePossible(directions[directionIndex]))
                    directionIndex = rand.Next(0, 4);
                currentDirection = directions[directionIndex];
            }
            base.moveCharacter();
        }

        public virtual void randomFruitGenerator()
        {
            int randomNumber = rand.Next(0, 60000 / timerInterval);
            if (randomNumber == 0)
            {
                int newI = rand.Next(0, 35);
                int newJ = rand.Next(0, 27);
                while (!viableLocation(newI, newJ))
                {
                    newI = rand.Next(0, 35);
                    newJ = rand.Next(0, 27);
                }
                appear(newI, newJ);
            }
        }

        // Voće se pojavljuje se na koordinatama (i, j).
        public void appear(int _i, int _j)
        {
            i = _i;
            j = _j;
            this.drawCharacter();// Inače se prvo pojavi na (0, 0).
            characterPictureBox.Visible = true;
            characterPictureBox.BringToFront();
            remainingTimeOnScreen = Form1.FruitOnScreenDuration;
        }

        // Sva voća koja nasljeđuju prerađuju checkSquare().
        public abstract void checkSquare();

        // Voće se smije pojaviti na kvadratima na kojima nije
        // zid i neko drugo voće.
        public bool viableLocation(int i, int j)
        {
            bool noWall = Form1.grid.getSquareValue(i, j) != '#';
            bool noStrawberry = Form1.strawberry.i != i || Form1.strawberry.j != j;
            bool noRottenStrawberry = Form1.rottenStrawberry.i != i || Form1.rottenStrawberry.j != j;
            bool noPear = Form1.pear.i != i || Form1.pear.j != j;
            bool noRottenPear = Form1.rottenPear.i != i || Form1.rottenPear.j != j;
            bool noCherry = Form1.cherry.i != i || Form1.cherry.j != j;
            bool noRottenCherry = Form1.rottenCherry.i != i || Form1.rottenCherry.j != j;
            bool noGoldenApple = Form1.goldenApple.i != i || Form1.goldenApple.j != j;

            return noWall && noGoldenApple
                && noStrawberry && noRottenStrawberry
                && noPear && noRottenPear
                && noCherry && noRottenCherry;
        }
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
                if (rotten) Sounds.eatRottenSound.Play();
                else Sounds.eatFruitSound.Play();
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
                if (rotten) Sounds.eatRottenSound.Play();
                else Sounds.eatFruitSound.Play();
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
                if (rotten) Sounds.eatRottenSound.Play();
                else Sounds.eatFruitSound.Play();
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
                Sounds.eatAppleSound.Play();
                // Dodaj život Pacmanu.
                Form1.pacman.addLife();
                removeFromMap();
            }
        }

        public override void randomFruitGenerator()
        {
            int randomNumber = rand.Next(0, 5 * (60000 / timerInterval));
            if (randomNumber == 0)
            {
                int newI = rand.Next(0, 35);
                int newJ = rand.Next(0, 27);
                while (!viableLocation(newI, newJ))
                {
                    newI = rand.Next(0, 35);
                    newJ = rand.Next(0, 27);
                }
                appear(newI, newJ);
            }
        }
    }



}
