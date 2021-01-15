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
    public partial class Form3 : Form
    {
        public Form2 main;
        public Form3(Form2 parent)
        {
            main = parent;
            InitializeComponent();
            InitializeEvents();
        }

        public void focusButton()
        {
            button1.Focus();
        }

        private void InitializeEvents()
        {
            button1.GotFocus += buttonImgEnter;
            button2.GotFocus += buttonImgEnter;
            button3.GotFocus += buttonImgEnter;
            button4.GotFocus += buttonImgEnter;
            button5.GotFocus += buttonImgEnter;
            button6.GotFocus += buttonImgEnter;

            button1.LostFocus += buttonImgLeave;
            button2.LostFocus += buttonImgLeave;
            button3.LostFocus += buttonImgLeave;
            button4.LostFocus += buttonImgLeave;
            button5.LostFocus += buttonImgLeave;
            button6.LostFocus += buttonImgLeave;

            button7.GotFocus += buttonEnter;
            button8.GotFocus += buttonEnter;
            button9.GotFocus += buttonEnter;

            button7.LostFocus += buttonLeave;
            button8.LostFocus += buttonLeave;
            button9.LostFocus += buttonLeave;
        }

        private void buttonEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.GhostWhite;
        }

        private void buttonLeave(object sender, EventArgs e)
        {
            if (sender == button10) button10.BackColor = Color.Yellow;
            checkActiveButtons();
        }

        private void selectOption(object sender, EventArgs e)
        {
            Sounds.optionSound.Play();
            // button1, button2 i button3 služe za odabir lika Pacmana u Formi 3.
            // Ako nijedan od ovih nije odabran, u konstruktoru Pacmana se defaultno
            // postavlja defaultni lik.
            if (sender == button1)
                Form1.chosenPacmanCharacter = Pacman.Character.Pacman;
            else if (sender == button2)
                Form1.chosenPacmanCharacter = Pacman.Character.MsPacman;
            else if (sender == button3)
                Form1.chosenPacmanCharacter = Pacman.Character.ChristmasPacman;
            else if (sender == button4)
                Form1.chosenGhostCharacter = Ghost.Character.Default;
            else if (sender == button5)
                Form1.chosenGhostCharacter = Ghost.Character.Kanji;
            else if (sender == button6)
                Form1.chosenGhostCharacter = Ghost.Character.Christmas;
            else if (sender == button7)
                Form1.chosenGameMode = Form1.GameMode.Normal;
            else if (sender == button8)
                Form1.chosenGameMode = Form1.GameMode.Turbo;
            else if (sender == button9)
                Form1.chosenGameMode = Form1.GameMode.Fruit;

            checkActiveButtons();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            main.button1_Click_1(sender, e);
        }

        private void buttonImgLeave(object sender, EventArgs e)
        {
            checkActiveButtons();
        }

        private void buttonImgEnter(object sender, EventArgs e)
        {
            checkActiveButtons();
            Button button = sender as Button;
            button.BackColor = Color.GhostWhite;
        }

        private void checkActiveButtons()
        {
            switch (Form1.chosenPacmanCharacter)
            {
                case Pacman.Character.Pacman:
                    button1.BackColor = Color.Orange;
                    button2.BackColor = Color.Black;
                    button3.BackColor = Color.Black;
                    break;
                case Pacman.Character.MsPacman:
                    button1.BackColor = Color.Black;
                    button2.BackColor = Color.Orange;
                    button3.BackColor = Color.Black;
                    break;
                case Pacman.Character.ChristmasPacman:
                    button1.BackColor = Color.Black;
                    button2.BackColor = Color.Black;
                    button3.BackColor = Color.Orange;
                    break;
            }

            switch (Form1.chosenGhostCharacter)
            {
                case Ghost.Character.Default:
                    button4.BackColor = Color.Orange;
                    button5.BackColor = Color.Black;
                    button6.BackColor = Color.Black;
                    break;
                case Ghost.Character.Kanji:
                    button4.BackColor = Color.Black;
                    button5.BackColor = Color.Orange;
                    button6.BackColor = Color.Black;
                    break;
                case Ghost.Character.Christmas:
                    button4.BackColor = Color.Black;
                    button5.BackColor = Color.Black;
                    button6.BackColor = Color.Orange;
                    break;
            }

            switch (Form1.chosenGameMode)
            {
                case Form1.GameMode.Normal:
                    button7.BackColor = Color.Orange;
                    button8.BackColor = Color.Gray;
                    button9.BackColor = Color.Gray;
                    break;
                case Form1.GameMode.Turbo:
                    button7.BackColor = Color.Gray;
                    button8.BackColor = Color.Orange;
                    button9.BackColor = Color.Gray;
                    break;
                case Form1.GameMode.Fruit:
                    button7.BackColor = Color.Gray;
                    button8.BackColor = Color.Gray;
                    button9.BackColor = Color.Orange;
                    break;
            }
        }
    }
}
