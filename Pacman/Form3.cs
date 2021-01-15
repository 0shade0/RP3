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
            Button button = sender as Button;
            button.BackColor = Color.Yellow;
        }

        private void selectOption(object sender, EventArgs e)
        {
            Sounds.optionSound.Play();
            // button1, button2 i button3 služe za odabir lika Pacmana u Formi 3.
            // Ako nijedan od ovih nije odabran, u konstruktoru Pacmana se defaultno
            // postavlja defaultni lik.
            if (sender == button1)
                Form2.pacmanChosenCharacter = Pacman.Character.Pacman;
            else if (sender == button2)
                Form2.pacmanChosenCharacter = Pacman.Character.MsPacman;
            else if (sender == button3)
                Form2.pacmanChosenCharacter = Pacman.Character.ChristmasPacman;
            else if (sender == button4)
                Form2.ghostChosenCharacter = Ghost.Character.Default;
            else if (sender == button5)
                Form2.ghostChosenCharacter = Ghost.Character.Kanji;
            else if (sender == button6)
                Form2.ghostChosenCharacter = Ghost.Character.Christmas;
            else if (sender == button7)
                Form2.chosenGameType = Form1.GameType.Normal;
            else if (sender == button8)
                Form2.chosenGameType = Form1.GameType.Turbo;
            else if (sender == button9)
                Form2.chosenGameType = Form1.GameType.Fruit;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            main.button1_Click_1(sender, e);
        }

        private void buttonImgLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.Black;
        }

        private void buttonImgEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.GhostWhite;
        }

        private void closeHelpButton_Click(object sender, EventArgs e)
        {
            helpPanel.Visible = false;
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            helpPanel.Visible = true;
        }
    }
}
