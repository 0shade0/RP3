namespace Pacman
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.button1 = new CustomButton();
            this.button2 = new CustomButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menu = new System.Windows.Forms.Panel();
            this.exitgame = new CustomButton();
            this.options = new CustomButton();
            this.newgame = new CustomButton();
            this.button3 = new CustomButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(10, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "MAIN MENU";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            this.button1.Enter += new System.EventHandler(this.buttonEnter);
            this.button1.Leave += new System.EventHandler(this.buttonLeave);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Yellow;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(10, 189);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 50);
            this.button2.TabIndex = 5;
            this.button2.Text = "EXIT GAME";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button3_Click);
            this.button2.Enter += new System.EventHandler(this.buttonEnter);
            this.button2.Leave += new System.EventHandler(this.buttonLeave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 146);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Pacman.Resource1.pacmanLogo;
            this.pictureBox2.Location = new System.Drawing.Point(190, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(412, 101);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Pacman.Resource1.pacman;
            this.pictureBox1.Location = new System.Drawing.Point(-10, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Black;
            this.menu.BackgroundImage = global::Pacman.Resource1.border;
            this.menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menu.Controls.Add(this.exitgame);
            this.menu.Controls.Add(this.options);
            this.menu.Controls.Add(this.newgame);
            this.menu.Location = new System.Drawing.Point(234, 156);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(321, 374);
            this.menu.TabIndex = 2;
            this.menu.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.menu_PreviewKeyDown);
            // 
            // exitgame
            // 
            this.exitgame.BackColor = System.Drawing.Color.Yellow;
            this.exitgame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitgame.Font = new System.Drawing.Font("Agency FB", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitgame.Location = new System.Drawing.Point(57, 248);
            this.exitgame.Name = "exitgame";
            this.exitgame.Size = new System.Drawing.Size(214, 80);
            this.exitgame.TabIndex = 2;
            this.exitgame.Text = "EXIT GAME";
            this.exitgame.UseVisualStyleBackColor = false;
            this.exitgame.Click += new System.EventHandler(this.button3_Click);
            // 
            // options
            // 
            this.options.BackColor = System.Drawing.Color.Yellow;
            this.options.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.options.Font = new System.Drawing.Font("Agency FB", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.options.Location = new System.Drawing.Point(57, 145);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(214, 80);
            this.options.TabIndex = 1;
            this.options.Text = "OPTIONS";
            this.options.UseVisualStyleBackColor = false;
            this.options.Click += new System.EventHandler(this.button2_Click);
            // 
            // newgame
            // 
            this.newgame.BackColor = System.Drawing.Color.Yellow;
            this.newgame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newgame.Font = new System.Drawing.Font("Agency FB", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newgame.Location = new System.Drawing.Point(57, 39);
            this.newgame.Name = "newgame";
            this.newgame.Size = new System.Drawing.Size(214, 80);
            this.newgame.TabIndex = 0;
            this.newgame.Text = "NEW GAME";
            this.newgame.UseVisualStyleBackColor = false;
            this.newgame.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Yellow;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(10, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 50);
            this.button3.TabIndex = 7;
            this.button3.Text = "PLAY";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            this.button3.Enter += new System.EventHandler(this.buttonEnter);
            this.button3.Leave += new System.EventHandler(this.buttonLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(7, 152);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(145, 258);
            this.panel2.TabIndex = 8;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form2";
            this.Text = "Pac-man";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomButton newgame;
        private CustomButton options;
        private CustomButton exitgame;
        private CustomButton button1;
        private CustomButton button2;
        private CustomButton button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.Panel panel2;

        public class CustomButton : System.Windows.Forms.Button
        {
            protected override bool ShowFocusCues
            {
                get
                {
                    return false;
                }
            }
        }
    }
}