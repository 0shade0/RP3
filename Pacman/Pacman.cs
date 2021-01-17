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
        public Form1 main;
        // Mogući likovi za Pacmana.
        public enum Character
        {
            Pacman,
            MsPacman,
            ChristmasPacman
        }
        // Odabrani lik za Pacmana (iz menija).
        Character chosenCharacter;

        // Pacmanovi bodovi.
        protected int score = 0;
        // Broj pojedenih duhova u trajanju Flee stanja.
        protected int ghostsEaten = 0;
        // Pacmanovi preostali životi (ne uključujući trenutni).
        protected int lives = 2;
        // Pacman može imati najviše 10 dodatnih života.
        protected int maxLives = 10;
        // Trenutni level.
        protected int level = 1;
        // Korisnikov željeni smjer kretanja. Postaje trenutni smjer
        // kretanja tek onda kada je kretanje moguće.
        protected Direction newDirection = Direction.None;

        // Labela za bodove.
        protected Label scoreLabel = new Label();
        // Labela za trenutni level.
        protected Label levelLabel = new Label();
        // Polje picture boxeva za sličice života koje se nalaze ispod ploče.
        // Može imati najviše 10 slika, jer je to najveći mogući broj života.
        protected PictureBox[] livesPictureBoxes = new PictureBox[10];

        /// Varijable potrebne za efekte trešanja. Modifikacija
        /// dodanog broja bodova se događa u incrementScore().
        // Preostalo trajanje efekata trešnje.
        protected int cherryDuration = 0;
        protected int rottenCherryDuration = 0;

        // Je li efekt trešanja i dalje aktivan.
        protected bool isCherryActive = false;
        protected bool isRottenCherryActive = false;

        /// Varijable potrebne za efekte krušaka.
        // Preostalo trajanje efekata trešnje.
        protected int pearDuration = 0;
        protected int rottenPearDuration = 0;

        // Je li efekt trešanja i dalje aktivan.
        protected bool isPearActive = false;
        protected bool isRottenPearActive = false;

        public Pacman (Form form, Pacman.Character chosen) : base(form) 
        {
            main = form as Form1;
            // Score label.
            scoreLabel.ForeColor = Color.White;
            scoreLabel.Text = "SCORE: 0";
            scoreLabel.Location = new Point(12, 9);
            scoreLabel.BackColor = Color.DarkBlue;
            scoreLabel.Font = new Font("Microsoft Sans Serif", 16);
            //scoreLabel.AutoSize = true;
            scoreLabel.Width = form.Width / 2;
            form.Controls.Add(scoreLabel);

            // Level label.
            levelLabel.Width = form.Width / 2;
            levelLabel.ForeColor = Color.White;
            levelLabel.Text = "LEVEL: 0";
            levelLabel.TextAlign = ContentAlignment.TopRight;
            levelLabel.BackColor = Color.DarkBlue;
            levelLabel.Font = new Font("Microsoft Sans Serif", 16);
            //levelLabel.AutoSize = true;
            levelLabel.Width = form.Width / 2;
            levelLabel.Location = new Point(form.Width - levelLabel.Width - 30, 9);
            form.Controls.Add(levelLabel);

            // Ovo treba odabrati u meniju.
            chosenCharacter = chosen;
            // Učitavanje slika za Pacmana.
            if (chosenCharacter == Character.MsPacman)
            {
                characterImages[0] = new Bitmap(Properties.Resources.MsPacmanLeft);
                characterImages.Add(new Bitmap(Properties.Resources.MsPacmanLeftEat));
                characterImages.Add(new Bitmap(Properties.Resources.MsPacmanUp));
                characterImages.Add(new Bitmap(Properties.Resources.MsPacmanUpEat));
                characterImages.Add(new Bitmap(Properties.Resources.MsPacmanRight));
                characterImages.Add(new Bitmap(Properties.Resources.MsPacmanRightEat));
                characterImages.Add(new Bitmap(Properties.Resources.MsPacmanDown));
                characterImages.Add(new Bitmap(Properties.Resources.MsPacmanDownEat));
                characterImages.Add(new Bitmap(Properties.Resources.MsPacmanNone));
            }
            else if (chosenCharacter == Character.ChristmasPacman)
            {
                characterImages[0] = new Bitmap(Properties.Resources.ChristmasPacmanLeft);
                characterImages.Add(new Bitmap(Properties.Resources.ChristmasPacmanLeftEat));
                characterImages.Add(new Bitmap(Properties.Resources.ChristmasPacmanUp));
                characterImages.Add(new Bitmap(Properties.Resources.ChristmasPacmanUpEat));
                characterImages.Add(new Bitmap(Properties.Resources.ChristmasPacmanRight));
                characterImages.Add(new Bitmap(Properties.Resources.ChristmasPacmanRightEat));
                characterImages.Add(new Bitmap(Properties.Resources.ChristmasPacmanDown));
                characterImages.Add(new Bitmap(Properties.Resources.ChristmasPacmanDownEat));
                characterImages.Add(new Bitmap(Properties.Resources.ChristmasPacmanNone));
            }
            else 
            {
                characterImages[0] = new Bitmap(Properties.Resources.PacmanLeft);
                characterImages.Add(new Bitmap(Properties.Resources.PacmanLeftEat));
                characterImages.Add(new Bitmap(Properties.Resources.PacmanUp));
                characterImages.Add(new Bitmap(Properties.Resources.PacmanUpEat));
                characterImages.Add(new Bitmap(Properties.Resources.PacmanRight));
                characterImages.Add(new Bitmap(Properties.Resources.PacmanRightEat));
                characterImages.Add(new Bitmap(Properties.Resources.PacmanDown));
                characterImages.Add(new Bitmap(Properties.Resources.PacmanDownEat));
                characterImages.Add(new Bitmap(Properties.Resources.PacmanNone));
            }
            currentImage = characterImages.Count - 1;

            // Inicijaliziraj svih 10 PictureBoxeva, a slike postavi samo na
            // prvih lives sličica.
            for (int i = 0; i < 10; i++)
            {
                PictureBox life = new PictureBox();
                if (i < lives)
                    life.Image = characterImages[0];
                life.SizeMode = PictureBoxSizeMode.StretchImage;
                life.Location = new Point(Form1.squareSize.X * (i + 2), Form1.squareSize.Y * 33);
                life.Size = new Size(Form1.squareSize.X, Form1.squareSize.Y);
                life.BackColor = Color.DarkBlue;
                livesPictureBoxes[i] = life;
                form.Controls.Add(livesPictureBoxes[i]);
                livesPictureBoxes[i].BringToFront();
            }
        }

        protected override void characterTimerTick(object sender, EventArgs e)
        {
            // Ako je odabrana igra Fruit mode,
            // provjeri preostalo trajanje voća i signaliziraj završetak.
            if (Form1.chosenGameMode == Form1.GameMode.Fruit)
            {
                if (rottenCherryDuration > 0) rottenCherryDuration -= timerInterval;
                else if (isRottenCherryActive) isRottenCherryActive = false;

                if (cherryDuration > 0) cherryDuration -= timerInterval;
                else if (isCherryActive) isCherryActive = false;

                if (rottenPearDuration > 0) rottenPearDuration -= timerInterval;
                else if (isRottenPearActive)
                {
                    isRottenPearActive = false;
                    doubleSpeed();
                }

                if (pearDuration > 0) pearDuration -= timerInterval;
                else if (isPearActive)
                {
                    isPearActive = false;
                    undoIncreaseSpeedBy33Percent();
                }
            }

            moveCharacter();
            drawCharacter();
            drawGameText();
            checkSquare();
        }

        // Resetiranje Pacmana.
        public void reset()
        {
            currentImage = characterImages.Count - 1;
            i = startI;
            j = startJ;
            currentDirection = newDirection = Direction.None;
            timerInterval = Form1.PacmanDefaultSpeed;

            // Resetiraj efekte svih voća ako je način Fruit.
            if (Form1.chosenGameMode == Form1.GameMode.Fruit)
            {
                // Resetiraj efekte kruške (ako su bili aktivni).
                if (isRottenPearActive || rottenPearDuration > 0)
                    doubleSpeed();

                if (isPearActive || pearDuration > 0)
                    undoIncreaseSpeedBy33Percent();

                rottenCherryDuration = 0;
                isRottenCherryActive = false;
                Form1.rottenCherry.removeFromMap();
                cherryDuration = 0;
                isCherryActive = false;
                Form1.cherry.removeFromMap();
                rottenPearDuration = 0;
                isRottenPearActive = false;
                Form1.rottenPear.removeFromMap();
                pearDuration = 0;
                isPearActive = false;
                Form1.pear.removeFromMap();

                Form1.goldenApple.removeFromMap();                    
            }
        }

        public void drawGameText()
        {
            // Pisanje bodova.
            scoreLabel.Text = "SCORE: " + score;
            scoreLabel.BringToFront();
            // Pisanje trenutnog levela.
            levelLabel.Text = "LEVEL: " + level;
            levelLabel.BringToFront();

        }
        public void incrementScore(int x)
        {
            int pointsToAdd = x;
            // Smanji/povećaj broj bodova ako je (trula) trešnja aktivna.
            if (isCherryActive)
                pointsToAdd *= 2;
            else if (isRottenCherryActive)
                pointsToAdd /= 2;
                
            score += pointsToAdd;
        }

        public void resetGhostsEaten()
        {
            ghostsEaten = 0;
        }

        public override void moveCharacter()
        {
            // Ako Pacman čeka na promjenu smjera, provjeri je li ona moguća.
            if (newDirection != currentDirection && movePossible(newDirection))
                changeDirection(newDirection);
                
            base.moveCharacter();
            // Promijeni sliku ako se pomaknuo. Slike za Pacmana sa zatvorenim
            // ustima su postavljene na parnom indeksu i, a u istom smjeru
            // s otvorenim ustima na neparnom indeksu i+1.
            if (movePossible(currentDirection))
            {
                if (currentImage < characterImages.Count - 1)
                {
                    if (currentImage % 2 == 0)
                        currentImage += 1;
                    else
                        currentImage -= 1;
                }
            }
        }

        public override void changeDirection(Direction dir)
        {
            newDirection = dir;
            // Ako je kretanje moguće, promijeni i trenutni smjer.
            if (movePossible(dir))
            {
                bool directionChanged = currentDirection != dir;
                currentDirection = dir;

                // Promijeni sliku, ako je stvarno promjenjen smjer.
                if (directionChanged)
                    switch (currentDirection)
                    {
                        case Direction.Left:
                            currentImage = 0;
                            break;
                        case Direction.Up:
                            currentImage = 2;
                            break;
                        case Direction.Right:
                            currentImage = 4;
                            break;
                        case Direction.Down:
                            currentImage = 6;
                            break;
                    }
            }
                       
        }

        public void nextLevel()
        {
            Sounds.winSound.Play();
            level += 1;
            Form1.grid.resetGrid();
            increaseSpeed(Form1.SpeedIncPerLevel); // Dijeljivo s 4.
            this.reset(); // Resetira Pacmana.

            // Duhovi.
            Form1.redGhost.reset();
            Form1.pinkGhost.reset();
            Form1.blueGhost.reset();
            Form1.orangeGhost.reset();
        }

        public void checkSquare()
        {
            char square = Form1.grid.getSquareValue(i, j);

            if (square == '*')
                Food.eatCookie(i, j);
            else if (square == 'o')
                Food.eatSuperCookie(i, j);

            // Provjera je li se neki od duhova ovdje nalazi.
            // Ako pacman ne radi ovu provjeru može proći kroz duha.
            Form1.redGhost.checkSquare();
            Form1.pinkGhost.checkSquare();
            Form1.blueGhost.checkSquare();
            Form1.orangeGhost.checkSquare();

            // Provjera nalazi li se voće na kvadratu ako je način igre Fruit.
            if (Form1.chosenGameMode == Form1.GameMode.Fruit)
            {
                Form1.cherry.checkSquare();
                Form1.rottenCherry.checkSquare();
                Form1.pear.checkSquare();
                Form1.rottenPear.checkSquare();
                Form1.strawberry.checkSquare();
                Form1.rottenStrawberry.checkSquare();
                Form1.goldenApple.checkSquare();
            }   
        }

        public override int startI 
        {
            get { return Form1.pacmanStartPoint.Y; }
        }
        public override int startJ 
        {
            get { return Form1.pacmanStartPoint.X; }
        }

        ///
        /// Dio potreban/vezan za implementaciju duhova.
        ///

        // Ovu metodu poziva duh nakon što pojede pacmana.
        public void lifeLost()
		{
            // Resetiraj sve likove.
            this.reset(); // Resetira Pacmana.
            Form1.redGhost.reset();
            Form1.pinkGhost.reset();
            Form1.blueGhost.reset();
            Form1.orangeGhost.reset();

            // Oduzmi život.
            if (lives == 0)
            {
                Sounds.gameOverSound.Play();
                main.endGame();
                
            }
            else
            {
                Sounds.loseSound.Play();
                lives -= 1;
                livesPictureBoxes[lives].Image = null;
            }     
        }

        // Dodavanje života.
        public void addLife()
        {
            // Život se dodaje samo ako ima manje od maxLives života.
            if (lives < maxLives)
            {
                // Dodajemo samo jedan život pa ažuriraj samo zadnju sličicu.
                livesPictureBoxes[lives].Image = characterImages[0];

                lives += 1;
            }
                

        }

        public int Lives
        {
            get { return lives; }
            set
            {
                // Pacman ne može imati više od maxLives života.
                if (value <= maxLives)
                    lives = value;
            }
        }

        public int MaxLives
        {
            get { return maxLives; }
        }

        // Ovu metodu poziva duh nakon što ga pacman pojede.
        // Duh se prije poziva ove metode vraća u kuću.
        public void ateGhost()
		{
            incrementScore(Form1.blueGhost.PointsWorth * (int)Math.Pow(2, ghostsEaten));
            ++ghostsEaten;
		}

        public int Level
        {
            get { return level; }
        }

        public Character ChosenCharacter
        {
            set { chosenCharacter = value; }
            get { return chosenCharacter; }
        }

        ///
        /// Dio vezan za implementaciju voća.
        ///
        // Javljanje da je pojedena (trula) trešnja
        public void ateCherry(bool rotten)
        {
            if (rotten)
            {
                isRottenCherryActive = true;
                rottenCherryDuration = Form1.RottenFruitDuration;
            }
            else
            {
                isCherryActive = true;
                cherryDuration = Form1.SuperCookieDuration;
            }     
        }

        // Javljanje da je pojedena (trula) kruška.
        public void atePear(bool rotten)
        {
            if (rotten)
            {
                rottenPearDuration = Form1.RottenFruitDuration;
                if (!isRottenPearActive) halveSpeed();
                isRottenPearActive = true;
            }
            else
            {
                pearDuration = Form1.SuperCookieDuration;
                if (!isPearActive) increaseSpeedBy33Percent();
                isPearActive = true;
            }
        }
    }
}
