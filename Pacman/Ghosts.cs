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

        // Broj bodova koje Pacman dobiva za jedenje prvog duha.
        protected int pointsWorth = 200;

        // Nalazi li se duh u tunelu.
        protected bool inTunnel = false;

        // Koliko dugo je duh još zamrznut (jer je pacman pojeo jagodu).
        protected int frozenDuration = 0;

        // Koliko dugo je duh još ubrzan (jer je pacman pojeo trulu jagodu).
        protected int strawberrieDuration = 0;

        // Je li ubrzanje od jagode i dalje aktivno.
        protected bool isStrawberrieActive = false;

        // Isto kao i u pacman klasi.
        public enum Character
        {
            Default
        }

        // Isto kao i u pacman klasi.
        // Odabrani lik za duhove (iz menija).
        public Character chosenCharacter = Character.Default;

        public Ghost(Form form) : base(form) 
        {
            // Na početku su duhovi sporiji od pacmana.
            timerInterval = 172;
            characterTimer.Interval = timerInterval;
            currentImage = 0;
            rand = new Random();
        }

        protected override void characterTimerTick(object sender, EventArgs e)
        {
            drawCharacter();
            checkSquare();
            
            // Ako je zalđen duh se ne miče, no on i dalje može pojesti pacmana.
            if (frozenDuration > 0) {
                frozenDuration -= timerInterval;
                return;
            } else moveCharacter();

            if (strawberrieDuration > 0) strawberrieDuration -= timerInterval;
            else if (isStrawberrieActive) {
                isStrawberrieActive = false;
                undoIncreaseSpeedBy50Percent();
            }
            

            // Ako je duh bježao.
            if (s == State.Flee) {
                remainingFleeDuration -= timerInterval;

                if (remainingFleeDuration <= 0) {
                    s = State.Chase;
                    doubleSpeed();
                    loadStandardImage();
                    // Resetiraj broj pojedenih duhova u Flee stanju.
                    Form1.pacman.resetGhostsEaten();
                }
            }
        }

        public void checkSquare()
        {
            if (Form1.pacman.I == i && Form1.pacman.J == j)
			{
                if (s == State.Chase) Form1.pacman.lifeLost();
                else if (s == State.Flee)
				{
                    Sounds.eatGhostSound.Play();
                    reset();
                    waitElapsed = waitTreshold - 5;
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
                loadStandardImage();
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
                loadStandardImage();
            }


            // Ako je duh ušao, tj. izašao iz tunela od portala.
            // Duhovi se miču duplo sporije u portalu.
            if (i == 16 && (j == 5 || j == 22))
                enterTunnel();
            else if (i == 16 && (j == 6 || j == 21))
                exitTunnel();
        }

        public void enterTunnel()
        {
            if (!inTunnel) {
                inTunnel = true;
                halveSpeed();
            }
        }

        public void exitTunnel()
        {
            if (inTunnel) {
                inTunnel = false;
                doubleSpeed();
            }
        }

        // Resetira duha na početak i duh čeka određeno vrijeme prije nego što se počne kretati.
        public void reset()
		{
            exitTunnel();
            i = startI;
            j = startJ;
            s = State.Chase;
            exitingBox = 0;
            waitElapsed = 0;
            remainingFleeDuration = 0;
            timerInterval = Form1.PacmanDefaultSpeed + 12; // Duhovi su sporiji od pacmana.
            characterTimer.Interval = timerInterval;
            frozenDuration = 0;
            strawberrieDuration = 0;
            isStrawberrieActive = false;
            currentImage = 0;
            currentDirection = Direction.Up;
            loadStandardImage();
		}

        // Poziva se kada pacman pojede super kolačić. Duh prelazi u stanje bježanja na duration milisekundi.
        public void flee() 
        {
            // Duhovi mjenjaju smjer.
            currentDirection = oppositeDirection(currentDirection);

            remainingFleeDuration = Form1.SuperCookieDuration;
            s = State.Flee;
            halveSpeed();
            loadFleeImage();
        }

        // Računaju kordinate do kojih duh pokušava doći.
        // Svaki duh ima svoj algoritam.
        public abstract int getTargetI();
        public abstract int getTargetJ();

        // Svojstvo za dohvaćanje pointsWorth.
        public int PointsWorth
        {
            get { return pointsWorth; }
        }

        // Promjeni izgled duha u njegovu formu kada bježi od pacmana
        // tj. pacman ga može pojesti.
        public void loadFleeImage()
        {
            currentImage = 4;
        }

        // Promjeni izgled duha u njegovu standardnu formu kada lovi pacmana.
        // Ne radi ništa ako duh bježi.
        public void loadStandardImage()
		{
            if (s == State.Flee) return;

            switch (currentDirection)
			{
                case Direction.Up:
                    currentImage = 0;
                    break;
                case Direction.Left:
                    currentImage = 1;
                    break;
                case Direction.Down:
                    currentImage = 2;
                    break;
                case Direction.Right:
                    currentImage = 3;
                    break;
            }
		}

        // Ovako se duhu javlja da je pojedena jagoda.
        public void ateStrawberrie()
        {
            frozenDuration = Form1.SuperCookieDuration;
        }

        // Ovom metodom se duhu javlja da je pojedana trula jagoda.
        public void ateRottenStrawberrie()
        {
            strawberrieDuration = Form1.RottenFruitDuration;
            increaseSpeedBy50Percent();
            isStrawberrieActive = true;
        }
    }

    public class RedGhost : Ghost 
    {
        public RedGhost(Form form) : base(form) 
        {
            waitTreshold = 0;

            if (chosenCharacter == Character.Default)
			{
                characterImages[0] = new Bitmap(Properties.Resources.RedGhostUp);
                characterImages.Add(new Bitmap(Properties.Resources.RedGhostLeft));
                characterImages.Add(new Bitmap(Properties.Resources.RedGhostDown));
                characterImages.Add(new Bitmap(Properties.Resources.RedGhostRight));
                characterImages.Add(new Bitmap(Properties.Resources.GhostFleeBlue));
                characterImages.Add(new Bitmap(Properties.Resources.GhostFleeWhite));
            }
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

            if (chosenCharacter == Character.Default)
            {
                characterImages[0] = new Bitmap(Properties.Resources.PinkGhostUp);
                characterImages.Add(new Bitmap(Properties.Resources.PinkGhostLeft));
                characterImages.Add(new Bitmap(Properties.Resources.PinkGhostDown));
                characterImages.Add(new Bitmap(Properties.Resources.PinkGhostRight));
                characterImages.Add(new Bitmap(Properties.Resources.GhostFleeBlue));
                characterImages.Add(new Bitmap(Properties.Resources.GhostFleeWhite));
            }
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

            if (chosenCharacter == Character.Default)
            {
                characterImages[0] = new Bitmap(Properties.Resources.BlueGhostUp);
                characterImages.Add(new Bitmap(Properties.Resources.BlueGhostLeft));
                characterImages.Add(new Bitmap(Properties.Resources.BlueGhostDown));
                characterImages.Add(new Bitmap(Properties.Resources.BlueGhostRight));
                characterImages.Add(new Bitmap(Properties.Resources.GhostFleeBlue));
                characterImages.Add(new Bitmap(Properties.Resources.GhostFleeWhite));
            }
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

            if (chosenCharacter == Character.Default)
            {
                characterImages[0] = new Bitmap(Properties.Resources.OrangeGhostUp);
                characterImages.Add(new Bitmap(Properties.Resources.OrangeGhostLeft));
                characterImages.Add(new Bitmap(Properties.Resources.OrangeGhostDown));
                characterImages.Add(new Bitmap(Properties.Resources.OrangeGhostRight));
                characterImages.Add(new Bitmap(Properties.Resources.GhostFleeBlue));
                characterImages.Add(new Bitmap(Properties.Resources.GhostFleeWhite));
            }
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

