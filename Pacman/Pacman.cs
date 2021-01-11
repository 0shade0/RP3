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
        // Pacmanovi bodovi.
        protected int score = 0;
        // Broj pojedenih duhova u trajanju Flee stanja.
        protected int ghostsEaten = 0;
        // Pacmanovi preostali životi (ne uključujući trenutni).
        protected int lives = 2;
        // Trenutni level.
        protected int level = 1;
        // Korisnikov željeni smjer kretanja. Postaje trenutni smjer
        // kretanja tek onda kada je kretanje moguće.
        protected Direction newDirection = Direction.None;

        // Labela za bodove.
        protected Label scoreLabel = new Label();
        // Labela za trenutni level.
        protected Label levelLabel = new Label();
        // Picture boxevi za sličice života koje se nalaze ispod ploče. 
        protected List<PictureBox> livesPictureBoxes = new List<PictureBox>();

        public Pacman (Form form) : base(form) 
        {

            // Score label.
            scoreLabel.ForeColor = Color.White;
            scoreLabel.Text = "Score: 0";
            scoreLabel.Location = new Point(12, 9);
            scoreLabel.BackColor = Color.DarkBlue;
            scoreLabel.Font = new Font("Arial", 16);
            scoreLabel.AutoSize = true;
            form.Controls.Add(scoreLabel);

            // Level label.
            levelLabel.Width = form.Width / 2;
            levelLabel.ForeColor = Color.White;
            levelLabel.Text = "Level: 0";
            levelLabel.TextAlign = ContentAlignment.TopRight;
            levelLabel.BackColor = Color.DarkBlue;
            levelLabel.Font = new Font("Arial", 16);
            levelLabel.AutoSize = true;
            levelLabel.Location = new Point(form.Width - levelLabel.Width - 12, 9);
            form.Controls.Add(levelLabel);

            // PictureBoxevi za živote.
            for (int i = 0; i < lives; i++)
            {
                PictureBox life = new PictureBox();
                life.Image = Properties.Resources.PacmanLeft;
                life.SizeMode = PictureBoxSizeMode.StretchImage;
                life.Location = new Point(Form1.squareSize.X * (i + 2), Form1.squareSize.Y * 33);
                life.Size = new Size(Form1.squareSize.X, Form1.squareSize.Y);
                life.BackColor = Color.DarkBlue;
                livesPictureBoxes.Add(life);
                form.Controls.Add(livesPictureBoxes[i]);
                livesPictureBoxes[i].BringToFront();
            }


            // Učitavanje slika za Pacmana.
            // Ovo treba obrisati kad se obriše ono iz movableCharacter konstruktora.
            characterImages[0] = new Bitmap(Properties.Resources.PacmanLeft);
            characterImages.Add(new Bitmap(Properties.Resources.PacmanLeftEat));
            characterImages.Add(new Bitmap(Properties.Resources.PacmanUp));
            characterImages.Add(new Bitmap(Properties.Resources.PacmanUpEat));
            characterImages.Add(new Bitmap(Properties.Resources.PacmanRight));
            characterImages.Add(new Bitmap(Properties.Resources.PacmanRightEat));
            characterImages.Add(new Bitmap(Properties.Resources.PacmanDown));
            characterImages.Add(new Bitmap(Properties.Resources.PacmanDownEat));
            characterImages.Add(new Bitmap(Properties.Resources.PacmanNone));
            currentImage = characterImages.Count - 1;
        }

        protected override void characterTimerTick(object sender, EventArgs e)
        {
            drawCharacter();
            drawGameText();
            checkSquare();
            moveCharacter();
        }

        public void reset()
        {
            currentImage = characterImages.Count - 1;
            i = startI;
            j = startJ;
            currentDirection = newDirection = Direction.None;
        }

        public void drawGameText()
        {
            // Pisanje bodova.
            scoreLabel.Text = "Score: " + score;
            scoreLabel.BringToFront();
            // Pisanje trenutnog levela.
            levelLabel.Text = "Level: " + level;
            levelLabel.BringToFront();

        }
        public void incrementScore(int x)
        {
            score += x;
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
                currentDirection = dir;
                // Promijeni sliku.
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
            reset(); // Resetira Pacmana.

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
        }

        public override int startI 
        {
            get { return Form1.startPoint.Y; }
        }
        public override int startJ 
        {
            get { return Form1.startPoint.X; }
        }

        ///
        /// Dio potreban/vezan za implementaciju duhova.
        ///

        // Ovu metodu poziva duh nakon što pojede pacmana.
        public void lifeLost()
		{
            // Resetiraj sve likove.
            reset(); // Resetira Pacmana.
            Form1.redGhost.reset();
            Form1.pinkGhost.reset();
            Form1.blueGhost.reset();
            Form1.orangeGhost.reset();

            // Oduzmi život.
            if (lives == 0)
            {
                Sounds.gameOverSound.Play();
                // TODO: Game Over.
            }
            else
            {
                Sounds.loseSound.Play();
                lives -= 1;
                livesPictureBoxes[lives].Image = null;
            }
                
        }

        public int Lives
        {
            get { return lives; }
        }

        // Ovu metodu poziva duh nakon što ga pacman pojede.
        // Duh se prije poziva ove metode vraća u kuću.
        public void ateGhost()
		{
            Console.WriteLine("Adding to score: " + (Form1.blueGhost.PointsWorth * (int)Math.Pow(2, ghostsEaten)).ToString());
            incrementScore(Form1.blueGhost.PointsWorth * (int)Math.Pow(2, ghostsEaten));
            ++ghostsEaten;
		}

        public int Level
        {
            get { return level; }
        }
    }
}
