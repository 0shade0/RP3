using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pacman
{
    // Nadklasa za sva 4 duha.
    public abstract class Ghost : movableCharacter
    {
        // Stanja u kojima duhovi mogu biti.
        public enum State
        {
            Chase,
            Flee, // Za vrijeme djelovanja super kolačića.
        }

        protected State s = State.Chase;

        // Vrijeme koliko duh ćeka prije nego što se počne kretati.
        protected int waitTreshold;

        // Vrijeme koliko je duh proveo čekajući.
        protected int waitElapsed = 0;

        // Lista smjevora poredanih po prioritetu u orginalnom pacmanu.
        protected static List<Direction> orderedDirections = new List<Direction>() { 
            Direction.Up, Direction.Left, Direction.Down, Direction.Right 
        };

        protected Random rand;

        // Označava fazu izlaženja iz kuće od duha.
        // 0 = duh je na spawn lokaciji,  3 = duh je izašao.
        protected int exitingBox = 0;

        // Koliko još duhovi trebaju bježati, u milisekundama.
        protected int remainingFleeDuration = 0;

        public Ghost(Form form) : base(form) 
        {
            // Na početku su duhovi sporiji od pacmana.
            timerInterval = 160;
            rand = new Random();
        }

        protected override void characterTimerTick(object sender, EventArgs e)
        {
            drawCharacter();
            checkSquare();
            moveCharacter();
            checkSquare();

            // Ako je duh bježao.
            if (s == State.Flee) {
                remainingFleeDuration -= characterTimer.Interval;

                if (remainingFleeDuration <= 0) s = State.Chase;
            }
        }

        public void checkSquare()
        {
            if (Form1.pacman.I == i && Form1.pacman.J == j)
			{
                if (s == State.Chase) Form1.pacman.lifeLost();
                else if (s == State.Flee)
				{
                    i = startI;
                    j = startJ;
                    s = State.Chase;
                    exitingBox = 0;
                    Form1.pacman.ateGhost();
				}
			}
        }

        public override void moveCharacter()
		{
            // Ako duh i dalje čeka u kući.
            if (waitElapsed < waitTreshold)
            {
                // Timer se ne povećava ako traje super kolačić.
                if (s == State.Chase) waitElapsed += 1;
            }

            // Ako je duh u procesu izlaženja iz kuće.
            else if (exitingBox < 3) 
            {
                currentDirection = Direction.Up;
                exitingBox += 1;
                i -= 1; // Svi duhovi se penju gore da bi izašli iz kuće.
            }

            // Ako je duh na portalu.
            // Lijevi portal se nalazi na indeksu [16, 0], a desni na [16, 27].
            // Isto kao i u movableCharacter klasi.
            else if (i == 16 && j == 0 && currentDirection == Direction.Left)
                j = 27;
            else if (i == 16 && j == 27 && currentDirection == Direction.Right)
                j = 0;

            else // Ako duh nalazi na normalnom dijelu ploče.
            {
                int ti, tj;

                if (s == State.Chase) {
                    ti = getTargetI();
                    tj = getTargetJ();
                } else { // U ovom slučaju duhovi se random ponašaju.
                    ti = rand.Next(2)*200 - 100; // -100 ili 100
                    tj = rand.Next(2)*200 - 100; // -100 ili 100
                }

            
                Direction bestDir = Direction.None;
                int bestDist = 1000000; // "Beskonačnost".
                foreach (Direction newDir in orderedDirections) {
                    // Duhovi se ne smiju okretati.
                    if (newDir == oppositeDirection(currentDirection)) continue;
                
                    if (!movePossible(newDir)) continue;

                    int ni = i, nj = j;
                    switch (newDir)
                    {
                        case Direction.Left:
                            nj -= 1;
                            break;
                        case Direction.Right:
                            nj += 1;
                            break;
                        case Direction.Up:
                            ni -= 1;
                            break;
                        case Direction.Down:
                            ni += 1;
                            break;
                    }

                    // Euklidska udaljenost.
                    int newDist = Form1.manhattanDistance(ti, tj, ni, nj);
                
                    if (newDist < bestDist) {
                        bestDist = newDist;
                        bestDir = newDir;
                    }
                }

                currentDirection = bestDir;
                switch (bestDir)
                {
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

        // Resetira duha na početak i duh čeka određeno vrijeme prije nego što se počne kretati.
        public void reset()
		{
            i = startI;
            j = startJ;
            s = State.Chase;
            exitingBox = 0;
            waitElapsed = 0;
		}

        // Poziva se kada pacman pojede super kolačić. Duh prelazi u stanje bježanja na duration milisekundi.
        public void flee(int duration) 
        {
            // Duhovi mjenjaju smjer.
            currentDirection = oppositeDirection(currentDirection);

            remainingFleeDuration = duration;
            s = State.Flee;
        }

        // Računaju kordinate do kojih duh pokušava doći.
        // Svaki duh ima svoj algoritam.
        public abstract int getTargetI();
        public abstract int getTargetJ();

    }

    public class RedGhost : Ghost 
    {
        public RedGhost(Form form) : base(form) 
        {
            waitTreshold = 0;
            
            // Placeholder.
            characterPictureBox.BackColor = Color.Red;
        }

        // Ovaj duh pokušava doći do pacmanove trenutne pozicije.
		public override int getTargetI()
		{
			return Form1.pacman.I;
		}
		public override int getTargetJ()
		{
			return Form1.pacman.J;
		}

        public override int startI 
        {
            get { return 16; }
        }
        public override int startJ 
        {
            get { return 12; }
        }
	}

    public class PinkGhost : Ghost 
    {
        public PinkGhost(Form form) : base(form) 
        {
            waitTreshold = 10;
            
            // Placeholder.
            characterPictureBox.BackColor = Color.LightPink;
        }

        // Ovaj duh pokušava doći do pozicije 4 mjesta ispred pacmana.
		public override int getTargetI()
		{
            switch(Form1.pacman.CurrentDirection)
            {
                case Direction.Up:
                    return Form1.pacman.I - 4;
                case Direction.Down:
                    return Form1.pacman.I + 4;
                default:
                    return Form1.pacman.I;
            }
		}
		public override int getTargetJ()
		{
			switch(Form1.pacman.CurrentDirection)
            {
                case Direction.Left:
                    return Form1.pacman.J - 4;
                case Direction.Right:
                    return Form1.pacman.J + 4;
                default:
                    return Form1.pacman.J;
            }
		}

        public override int startI 
        {
            get { return 16; }
        }
        public override int startJ 
        {
            get { return 13; }
        }
	}

    public class BlueGhost : Ghost 
    {
        public BlueGhost(Form form) : base(form) 
        {
            waitTreshold = 20;
            
            // Placeholder.
            characterPictureBox.BackColor = Color.LightSkyBlue;
        }

        // Ovaj duh se pokušava pozicionirati tako da je
        // pacman od prilike između njega i crvenog duha.
		public override int getTargetI()
		{
            int ti = Form1.pacman.I;
            switch(Form1.pacman.CurrentDirection)
            {
                case Direction.Up:
                    ti -= 2;
                    break;
                case Direction.Down:
                    ti += 2;
                    break;
            }
            return Form1.redGhost.I + 2 * (ti - Form1.redGhost.I);
		}
		public override int getTargetJ()
		{
            int tj = Form1.pacman.J;
            switch(Form1.pacman.CurrentDirection)
            {
                case Direction.Left:
                    tj -= 2;
                    break;
                case Direction.Right:
                    tj += 2;
                    break;
            }
            return Form1.redGhost.J + 2 * (tj - Form1.redGhost.J);
		}

        public override int startI 
        {
            get { return 16; }
        }
        public override int startJ 
        {
            get { return 14; }
        }
	}

    public class OrangeGhost : Ghost 
    {
        public OrangeGhost(Form form) : base(form) 
        {
            waitTreshold = 40;
            
            // Placeholder.
            characterPictureBox.BackColor = Color.DarkOrange;
        }

        // Ovaj duh lovi pacmanovu trenutnu poziciju dok god je
        // pacman za više od 8 polja udaljen od pacmana.
        // Inače bježi u red 100 i stupac -100.
		public override int getTargetI()
		{
            if (Form1.manhattanDistance(Form1.pacman.I, Form1.pacman.J, i, j) > 8)
            {
                return Form1.pacman.I;
            }
            else return 100;
		}
		public override int getTargetJ()
		{
            if (Form1.manhattanDistance(Form1.pacman.I, Form1.pacman.J, i, j) > 8)
            {
                return Form1.pacman.J;
            }
            else return -100;
		}

        public override int startI 
        {
            get { return 16; }
        }
        public override int startJ 
        {
            get { return 15; }
        }
	}
}

