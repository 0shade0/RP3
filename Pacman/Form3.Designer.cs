namespace Pacman
{
    partial class Form3
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.helpPanel = new System.Windows.Forms.Panel();
			this.helpGoldenAppleTextbox = new System.Windows.Forms.TextBox();
			this.helpRottenStrawberryTextbox = new System.Windows.Forms.TextBox();
			this.helpStrawberryTextbox = new System.Windows.Forms.TextBox();
			this.helpRottenPearTextbox = new System.Windows.Forms.TextBox();
			this.helpPearTextbox = new System.Windows.Forms.TextBox();
			this.helpRottenCherryTextbox = new System.Windows.Forms.TextBox();
			this.helpCherryTextbox = new System.Windows.Forms.TextBox();
			this.helpGoldenApplePictureBox = new System.Windows.Forms.PictureBox();
			this.helpRottenStrawberryPictureBox = new System.Windows.Forms.PictureBox();
			this.helpStrawberryPictureBox = new System.Windows.Forms.PictureBox();
			this.helpRottenPearPictureBox = new System.Windows.Forms.PictureBox();
			this.helpPearPictureBox = new System.Windows.Forms.PictureBox();
			this.helpRottenCherryPictureBox = new System.Windows.Forms.PictureBox();
			this.helpCherryPictureBox = new System.Windows.Forms.PictureBox();
			this.helpFruitTextBox = new System.Windows.Forms.TextBox();
			this.helpFruitHeaderTextBox = new System.Windows.Forms.TextBox();
			this.helpTurboTextBox = new System.Windows.Forms.TextBox();
			this.closeHelpButton = new System.Windows.Forms.Button();
			this.helpTurboHeaderTextBox = new System.Windows.Forms.TextBox();
			this.helpButton = new System.Windows.Forms.Button();
			this.helpPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.helpGoldenApplePictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.helpRottenStrawberryPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.helpStrawberryPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.helpRottenPearPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.helpPearPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.helpRottenCherryPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.helpCherryPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.Black;
			this.button4.BackgroundImage = global::Pacman.Properties.Resources.BlueGhostLeft;
			this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.Location = new System.Drawing.Point(408, 55);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(120, 90);
			this.button4.TabIndex = 7;
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.selectOption);
			this.button4.Enter += new System.EventHandler(this.buttonImgEnter);
			this.button4.Leave += new System.EventHandler(this.buttonImgLeave);
			// 
			// button5
			// 
			this.button5.BackgroundImage = global::Pacman.Properties.Resources.RedKanji;
			this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button5.Location = new System.Drawing.Point(408, 147);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(120, 90);
			this.button5.TabIndex = 8;
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.selectOption);
			this.button5.Enter += new System.EventHandler(this.buttonImgEnter);
			this.button5.Leave += new System.EventHandler(this.buttonImgLeave);
			// 
			// button6
			// 
			this.button6.BackgroundImage = global::Pacman.Properties.Resources.PinkCGhostLeft;
			this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button6.Location = new System.Drawing.Point(408, 235);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(120, 90);
			this.button6.TabIndex = 9;
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.selectOption);
			this.button6.Enter += new System.EventHandler(this.buttonImgEnter);
			this.button6.Leave += new System.EventHandler(this.buttonImgLeave);
			// 
			// button9
			// 
			this.button9.BackColor = System.Drawing.Color.Yellow;
			this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button9.Location = new System.Drawing.Point(221, 238);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(148, 50);
			this.button9.TabIndex = 6;
			this.button9.Text = "FRUIT";
			this.button9.UseVisualStyleBackColor = false;
			this.button9.Click += new System.EventHandler(this.selectOption);
			// 
			// button8
			// 
			this.button8.BackColor = System.Drawing.Color.Yellow;
			this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button8.Location = new System.Drawing.Point(221, 167);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(148, 50);
			this.button8.TabIndex = 5;
			this.button8.Text = "TURBO";
			this.button8.UseVisualStyleBackColor = false;
			this.button8.Click += new System.EventHandler(this.selectOption);
			// 
			// button7
			// 
			this.button7.BackColor = System.Drawing.Color.Yellow;
			this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button7.Location = new System.Drawing.Point(221, 98);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(148, 50);
			this.button7.TabIndex = 4;
			this.button7.Text = "NORMAL";
			this.button7.UseVisualStyleBackColor = false;
			this.button7.Click += new System.EventHandler(this.selectOption);
			// 
			// button3
			// 
			this.button3.BackgroundImage = global::Pacman.Properties.Resources.ChristmasPacmanRight;
			this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Location = new System.Drawing.Point(60, 235);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(120, 90);
			this.button3.TabIndex = 2;
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.selectOption);
			this.button3.Enter += new System.EventHandler(this.buttonImgEnter);
			this.button3.Leave += new System.EventHandler(this.buttonImgLeave);
			// 
			// button2
			// 
			this.button2.BackgroundImage = global::Pacman.Properties.Resources.MsPacmanRight;
			this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(60, 141);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(120, 90);
			this.button2.TabIndex = 1;
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.selectOption);
			this.button2.Enter += new System.EventHandler(this.buttonImgEnter);
			this.button2.Leave += new System.EventHandler(this.buttonImgLeave);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Black;
			this.button1.BackgroundImage = global::Pacman.Properties.Resources.PacmanRight;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(60, 55);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 90);
			this.button1.TabIndex = 0;
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.selectOption);
			this.button1.Enter += new System.EventHandler(this.buttonImgEnter);
			this.button1.Leave += new System.EventHandler(this.buttonImgLeave);
			// 
			// button10
			// 
			this.button10.BackColor = System.Drawing.Color.Yellow;
			this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button10.Location = new System.Drawing.Point(197, 368);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(203, 76);
			this.button10.TabIndex = 0;
			this.button10.Text = "MAIN MENU";
			this.button10.UseVisualStyleBackColor = false;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			this.button10.Enter += new System.EventHandler(this.buttonEnter);
			this.button10.Leave += new System.EventHandler(this.buttonLeave);
			// 
			// helpPanel
			// 
			this.helpPanel.BackgroundImage = global::Pacman.Resource1.border_r;
			this.helpPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.helpPanel.Controls.Add(this.helpGoldenAppleTextbox);
			this.helpPanel.Controls.Add(this.helpRottenStrawberryTextbox);
			this.helpPanel.Controls.Add(this.helpStrawberryTextbox);
			this.helpPanel.Controls.Add(this.helpRottenPearTextbox);
			this.helpPanel.Controls.Add(this.helpPearTextbox);
			this.helpPanel.Controls.Add(this.helpRottenCherryTextbox);
			this.helpPanel.Controls.Add(this.helpCherryTextbox);
			this.helpPanel.Controls.Add(this.helpGoldenApplePictureBox);
			this.helpPanel.Controls.Add(this.helpRottenStrawberryPictureBox);
			this.helpPanel.Controls.Add(this.helpStrawberryPictureBox);
			this.helpPanel.Controls.Add(this.helpRottenPearPictureBox);
			this.helpPanel.Controls.Add(this.helpPearPictureBox);
			this.helpPanel.Controls.Add(this.helpRottenCherryPictureBox);
			this.helpPanel.Controls.Add(this.helpCherryPictureBox);
			this.helpPanel.Controls.Add(this.helpFruitTextBox);
			this.helpPanel.Controls.Add(this.helpFruitHeaderTextBox);
			this.helpPanel.Controls.Add(this.helpTurboTextBox);
			this.helpPanel.Controls.Add(this.closeHelpButton);
			this.helpPanel.Controls.Add(this.helpTurboHeaderTextBox);
			this.helpPanel.Location = new System.Drawing.Point(50, 46);
			this.helpPanel.Name = "helpPanel";
			this.helpPanel.Size = new System.Drawing.Size(488, 417);
			this.helpPanel.TabIndex = 10;
			this.helpPanel.Visible = false;
			// 
			// helpGoldenAppleTextbox
			// 
			this.helpGoldenAppleTextbox.AcceptsTab = true;
			this.helpGoldenAppleTextbox.BackColor = System.Drawing.Color.Black;
			this.helpGoldenAppleTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.helpGoldenAppleTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.helpGoldenAppleTextbox.ForeColor = System.Drawing.Color.White;
			this.helpGoldenAppleTextbox.Location = new System.Drawing.Point(67, 337);
			this.helpGoldenAppleTextbox.Multiline = true;
			this.helpGoldenAppleTextbox.Name = "helpGoldenAppleTextbox";
			this.helpGoldenAppleTextbox.ReadOnly = true;
			this.helpGoldenAppleTextbox.Size = new System.Drawing.Size(283, 16);
			this.helpGoldenAppleTextbox.TabIndex = 18;
			this.helpGoldenAppleTextbox.Text = "Player recieves an extra life";
			// 
			// helpRottenStrawberryTextbox
			// 
			this.helpRottenStrawberryTextbox.AcceptsTab = true;
			this.helpRottenStrawberryTextbox.BackColor = System.Drawing.Color.Black;
			this.helpRottenStrawberryTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.helpRottenStrawberryTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.helpRottenStrawberryTextbox.ForeColor = System.Drawing.Color.White;
			this.helpRottenStrawberryTextbox.Location = new System.Drawing.Point(67, 304);
			this.helpRottenStrawberryTextbox.Multiline = true;
			this.helpRottenStrawberryTextbox.Name = "helpRottenStrawberryTextbox";
			this.helpRottenStrawberryTextbox.ReadOnly = true;
			this.helpRottenStrawberryTextbox.Size = new System.Drawing.Size(283, 16);
			this.helpRottenStrawberryTextbox.TabIndex = 17;
			this.helpRottenStrawberryTextbox.Text = "Increases ghosts\' speed";
			// 
			// helpStrawberryTextbox
			// 
			this.helpStrawberryTextbox.AcceptsTab = true;
			this.helpStrawberryTextbox.BackColor = System.Drawing.Color.Black;
			this.helpStrawberryTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.helpStrawberryTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.helpStrawberryTextbox.ForeColor = System.Drawing.Color.White;
			this.helpStrawberryTextbox.Location = new System.Drawing.Point(67, 273);
			this.helpStrawberryTextbox.Multiline = true;
			this.helpStrawberryTextbox.Name = "helpStrawberryTextbox";
			this.helpStrawberryTextbox.ReadOnly = true;
			this.helpStrawberryTextbox.Size = new System.Drawing.Size(283, 16);
			this.helpStrawberryTextbox.TabIndex = 16;
			this.helpStrawberryTextbox.Text = "Freezes the ghosts\r\n\r\n\r\n";
			// 
			// helpRottenPearTextbox
			// 
			this.helpRottenPearTextbox.AcceptsTab = true;
			this.helpRottenPearTextbox.BackColor = System.Drawing.Color.Black;
			this.helpRottenPearTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.helpRottenPearTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.helpRottenPearTextbox.ForeColor = System.Drawing.Color.White;
			this.helpRottenPearTextbox.Location = new System.Drawing.Point(67, 244);
			this.helpRottenPearTextbox.Multiline = true;
			this.helpRottenPearTextbox.Name = "helpRottenPearTextbox";
			this.helpRottenPearTextbox.ReadOnly = true;
			this.helpRottenPearTextbox.Size = new System.Drawing.Size(283, 16);
			this.helpRottenPearTextbox.TabIndex = 15;
			this.helpRottenPearTextbox.Text = "Decreases player\'s speed\r\n\r\n\r\n";
			// 
			// helpPearTextbox
			// 
			this.helpPearTextbox.AcceptsTab = true;
			this.helpPearTextbox.BackColor = System.Drawing.Color.Black;
			this.helpPearTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.helpPearTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.helpPearTextbox.ForeColor = System.Drawing.Color.White;
			this.helpPearTextbox.Location = new System.Drawing.Point(67, 212);
			this.helpPearTextbox.Multiline = true;
			this.helpPearTextbox.Name = "helpPearTextbox";
			this.helpPearTextbox.ReadOnly = true;
			this.helpPearTextbox.Size = new System.Drawing.Size(283, 16);
			this.helpPearTextbox.TabIndex = 14;
			this.helpPearTextbox.Text = "Increases player\'s speed\r\n\r\n\r\n";
			// 
			// helpRottenCherryTextbox
			// 
			this.helpRottenCherryTextbox.AcceptsTab = true;
			this.helpRottenCherryTextbox.BackColor = System.Drawing.Color.Black;
			this.helpRottenCherryTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.helpRottenCherryTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.helpRottenCherryTextbox.ForeColor = System.Drawing.Color.White;
			this.helpRottenCherryTextbox.Location = new System.Drawing.Point(67, 181);
			this.helpRottenCherryTextbox.Multiline = true;
			this.helpRottenCherryTextbox.Name = "helpRottenCherryTextbox";
			this.helpRottenCherryTextbox.ReadOnly = true;
			this.helpRottenCherryTextbox.Size = new System.Drawing.Size(283, 16);
			this.helpRottenCherryTextbox.TabIndex = 13;
			this.helpRottenCherryTextbox.Text = "Halves points gained for eating edibles\r\n\r\n\r\n";
			// 
			// helpCherryTextbox
			// 
			this.helpCherryTextbox.AcceptsTab = true;
			this.helpCherryTextbox.BackColor = System.Drawing.Color.Black;
			this.helpCherryTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.helpCherryTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.helpCherryTextbox.ForeColor = System.Drawing.Color.White;
			this.helpCherryTextbox.Location = new System.Drawing.Point(67, 151);
			this.helpCherryTextbox.Multiline = true;
			this.helpCherryTextbox.Name = "helpCherryTextbox";
			this.helpCherryTextbox.ReadOnly = true;
			this.helpCherryTextbox.Size = new System.Drawing.Size(285, 16);
			this.helpCherryTextbox.TabIndex = 12;
			this.helpCherryTextbox.Text = "Doubles points gained for eating edibles\r\n\r\n";
			// 
			// helpGoldenApplePictureBox
			// 
			this.helpGoldenApplePictureBox.Image = global::Pacman.Properties.Resources.AppleGolden;
			this.helpGoldenApplePictureBox.Location = new System.Drawing.Point(36, 332);
			this.helpGoldenApplePictureBox.Name = "helpGoldenApplePictureBox";
			this.helpGoldenApplePictureBox.Size = new System.Drawing.Size(25, 25);
			this.helpGoldenApplePictureBox.TabIndex = 11;
			this.helpGoldenApplePictureBox.TabStop = false;
			// 
			// helpRottenStrawberryPictureBox
			// 
			this.helpRottenStrawberryPictureBox.Image = global::Pacman.Properties.Resources.StrawberryRotten;
			this.helpRottenStrawberryPictureBox.Location = new System.Drawing.Point(36, 301);
			this.helpRottenStrawberryPictureBox.Name = "helpRottenStrawberryPictureBox";
			this.helpRottenStrawberryPictureBox.Size = new System.Drawing.Size(25, 25);
			this.helpRottenStrawberryPictureBox.TabIndex = 10;
			this.helpRottenStrawberryPictureBox.TabStop = false;
			// 
			// helpStrawberryPictureBox
			// 
			this.helpStrawberryPictureBox.Image = global::Pacman.Properties.Resources.Strawberry;
			this.helpStrawberryPictureBox.Location = new System.Drawing.Point(36, 270);
			this.helpStrawberryPictureBox.Name = "helpStrawberryPictureBox";
			this.helpStrawberryPictureBox.Size = new System.Drawing.Size(25, 25);
			this.helpStrawberryPictureBox.TabIndex = 9;
			this.helpStrawberryPictureBox.TabStop = false;
			// 
			// helpRottenPearPictureBox
			// 
			this.helpRottenPearPictureBox.Image = global::Pacman.Properties.Resources.PearRotten;
			this.helpRottenPearPictureBox.Location = new System.Drawing.Point(36, 239);
			this.helpRottenPearPictureBox.Name = "helpRottenPearPictureBox";
			this.helpRottenPearPictureBox.Size = new System.Drawing.Size(25, 25);
			this.helpRottenPearPictureBox.TabIndex = 8;
			this.helpRottenPearPictureBox.TabStop = false;
			// 
			// helpPearPictureBox
			// 
			this.helpPearPictureBox.Image = global::Pacman.Properties.Resources.Pear;
			this.helpPearPictureBox.Location = new System.Drawing.Point(36, 208);
			this.helpPearPictureBox.Name = "helpPearPictureBox";
			this.helpPearPictureBox.Size = new System.Drawing.Size(25, 25);
			this.helpPearPictureBox.TabIndex = 7;
			this.helpPearPictureBox.TabStop = false;
			// 
			// helpRottenCherryPictureBox
			// 
			this.helpRottenCherryPictureBox.Image = global::Pacman.Properties.Resources.CherriesRotten;
			this.helpRottenCherryPictureBox.Location = new System.Drawing.Point(36, 177);
			this.helpRottenCherryPictureBox.Name = "helpRottenCherryPictureBox";
			this.helpRottenCherryPictureBox.Size = new System.Drawing.Size(25, 25);
			this.helpRottenCherryPictureBox.TabIndex = 6;
			this.helpRottenCherryPictureBox.TabStop = false;
			// 
			// helpCherryPictureBox
			// 
			this.helpCherryPictureBox.Image = global::Pacman.Properties.Resources.Cherries;
			this.helpCherryPictureBox.Location = new System.Drawing.Point(36, 146);
			this.helpCherryPictureBox.Name = "helpCherryPictureBox";
			this.helpCherryPictureBox.Size = new System.Drawing.Size(25, 25);
			this.helpCherryPictureBox.TabIndex = 5;
			this.helpCherryPictureBox.TabStop = false;
			// 
			// helpFruitTextBox
			// 
			this.helpFruitTextBox.AcceptsTab = true;
			this.helpFruitTextBox.BackColor = System.Drawing.Color.Black;
			this.helpFruitTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.helpFruitTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.helpFruitTextBox.ForeColor = System.Drawing.Color.White;
			this.helpFruitTextBox.Location = new System.Drawing.Point(36, 105);
			this.helpFruitTextBox.Multiline = true;
			this.helpFruitTextBox.Name = "helpFruitTextBox";
			this.helpFruitTextBox.ReadOnly = true;
			this.helpFruitTextBox.Size = new System.Drawing.Size(426, 40);
			this.helpFruitTextBox.TabIndex = 4;
			this.helpFruitTextBox.Text = "In Fruit mode, various fruits appear on the map at random times. Different types " +
    "of fruits have different effects:\r\n";
			// 
			// helpFruitHeaderTextBox
			// 
			this.helpFruitHeaderTextBox.AcceptsTab = true;
			this.helpFruitHeaderTextBox.BackColor = System.Drawing.Color.Black;
			this.helpFruitHeaderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.helpFruitHeaderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.helpFruitHeaderTextBox.ForeColor = System.Drawing.Color.White;
			this.helpFruitHeaderTextBox.Location = new System.Drawing.Point(36, 80);
			this.helpFruitHeaderTextBox.Multiline = true;
			this.helpFruitHeaderTextBox.Name = "helpFruitHeaderTextBox";
			this.helpFruitHeaderTextBox.ReadOnly = true;
			this.helpFruitHeaderTextBox.Size = new System.Drawing.Size(127, 22);
			this.helpFruitHeaderTextBox.TabIndex = 3;
			this.helpFruitHeaderTextBox.Text = "FRUIT MODE";
			// 
			// helpTurboTextBox
			// 
			this.helpTurboTextBox.AcceptsTab = true;
			this.helpTurboTextBox.BackColor = System.Drawing.Color.Black;
			this.helpTurboTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.helpTurboTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.helpTurboTextBox.ForeColor = System.Drawing.Color.White;
			this.helpTurboTextBox.Location = new System.Drawing.Point(36, 52);
			this.helpTurboTextBox.Multiline = true;
			this.helpTurboTextBox.Name = "helpTurboTextBox";
			this.helpTurboTextBox.ReadOnly = true;
			this.helpTurboTextBox.Size = new System.Drawing.Size(426, 22);
			this.helpTurboTextBox.TabIndex = 2;
			this.helpTurboTextBox.Text = "In Turbo mode, both the player and ghosts move faster.";
			// 
			// closeHelpButton
			// 
			this.closeHelpButton.BackColor = System.Drawing.Color.Yellow;
			this.closeHelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.closeHelpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.closeHelpButton.Location = new System.Drawing.Point(356, 347);
			this.closeHelpButton.Name = "closeHelpButton";
			this.closeHelpButton.Size = new System.Drawing.Size(106, 34);
			this.closeHelpButton.TabIndex = 1;
			this.closeHelpButton.Text = "CLOSE";
			this.closeHelpButton.UseVisualStyleBackColor = false;
			this.closeHelpButton.Click += new System.EventHandler(this.closeHelpButton_Click);
			// 
			// helpTurboHeaderTextBox
			// 
			this.helpTurboHeaderTextBox.AcceptsTab = true;
			this.helpTurboHeaderTextBox.BackColor = System.Drawing.Color.Black;
			this.helpTurboHeaderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.helpTurboHeaderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.helpTurboHeaderTextBox.ForeColor = System.Drawing.Color.White;
			this.helpTurboHeaderTextBox.Location = new System.Drawing.Point(36, 30);
			this.helpTurboHeaderTextBox.Multiline = true;
			this.helpTurboHeaderTextBox.Name = "helpTurboHeaderTextBox";
			this.helpTurboHeaderTextBox.ReadOnly = true;
			this.helpTurboHeaderTextBox.Size = new System.Drawing.Size(127, 22);
			this.helpTurboHeaderTextBox.TabIndex = 0;
			this.helpTurboHeaderTextBox.Text = "TURBO MODE";
			// 
			// helpButton
			// 
			this.helpButton.BackColor = System.Drawing.Color.Black;
			this.helpButton.BackgroundImage = global::Pacman.Resource1.HelpIcon;
			this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.helpButton.FlatAppearance.BorderSize = 0;
			this.helpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.helpButton.Location = new System.Drawing.Point(270, 35);
			this.helpButton.Name = "helpButton";
			this.helpButton.Size = new System.Drawing.Size(50, 50);
			this.helpButton.TabIndex = 11;
			this.helpButton.Text = "Help";
			this.helpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.helpButton.UseVisualStyleBackColor = false;
			this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
			// 
			// Form3
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImage = global::Pacman.Resource1.border_r;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(584, 511);
			this.Controls.Add(this.helpPanel);
			this.Controls.Add(this.helpButton);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button6);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form3";
			this.Text = "Form3";
			this.helpPanel.ResumeLayout(false);
			this.helpPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.helpGoldenApplePictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.helpRottenStrawberryPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.helpStrawberryPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.helpRottenPearPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.helpPearPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.helpRottenCherryPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.helpCherryPictureBox)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Panel helpPanel;
        private System.Windows.Forms.TextBox helpTurboHeaderTextBox;
        private System.Windows.Forms.Button closeHelpButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.TextBox helpGoldenAppleTextbox;
        private System.Windows.Forms.TextBox helpRottenStrawberryTextbox;
        private System.Windows.Forms.TextBox helpStrawberryTextbox;
        private System.Windows.Forms.TextBox helpRottenPearTextbox;
        private System.Windows.Forms.TextBox helpPearTextbox;
        private System.Windows.Forms.TextBox helpRottenCherryTextbox;
        private System.Windows.Forms.TextBox helpCherryTextbox;
        private System.Windows.Forms.PictureBox helpGoldenApplePictureBox;
        private System.Windows.Forms.PictureBox helpRottenStrawberryPictureBox;
        private System.Windows.Forms.PictureBox helpStrawberryPictureBox;
        private System.Windows.Forms.PictureBox helpRottenPearPictureBox;
        private System.Windows.Forms.PictureBox helpPearPictureBox;
        private System.Windows.Forms.PictureBox helpRottenCherryPictureBox;
        private System.Windows.Forms.PictureBox helpCherryPictureBox;
        private System.Windows.Forms.TextBox helpFruitTextBox;
        private System.Windows.Forms.TextBox helpFruitHeaderTextBox;
        private System.Windows.Forms.TextBox helpTurboTextBox;
    }
}