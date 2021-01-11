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
            this.newgame = new System.Windows.Forms.Button();
            this.options = new System.Windows.Forms.Button();
            this.exitgame = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // newgame
            // 
            this.newgame.Location = new System.Drawing.Point(45, 31);
            this.newgame.Name = "newgame";
            this.newgame.Size = new System.Drawing.Size(214, 80);
            this.newgame.TabIndex = 0;
            this.newgame.Text = "New Game";
            this.newgame.UseVisualStyleBackColor = true;
            this.newgame.Click += new System.EventHandler(this.button1_Click);
            // 
            // options
            // 
            this.options.Location = new System.Drawing.Point(45, 140);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(214, 80);
            this.options.TabIndex = 1;
            this.options.Text = "Options";
            this.options.UseVisualStyleBackColor = true;
            this.options.Click += new System.EventHandler(this.button2_Click);
            // 
            // exitgame
            // 
            this.exitgame.Location = new System.Drawing.Point(45, 248);
            this.exitgame.Name = "exitgame";
            this.exitgame.Size = new System.Drawing.Size(214, 80);
            this.exitgame.TabIndex = 2;
            this.exitgame.Text = "Exit Game";
            this.exitgame.UseVisualStyleBackColor = true;
            this.exitgame.Click += new System.EventHandler(this.button3_Click);
            // 
            // menu
            // 
            this.menu.Controls.Add(this.exitgame);
            this.menu.Controls.Add(this.options);
            this.menu.Controls.Add(this.newgame);
            this.menu.Location = new System.Drawing.Point(250, 150);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(300, 350);
            this.menu.TabIndex = 3;
            this.menu.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "Main Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(180, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 50);
            this.button2.TabIndex = 5;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 526);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer1.TabIndex = 6;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menu);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form2";
            this.Text = "Form2";
            this.menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newgame;
        private System.Windows.Forms.Button options;
        private System.Windows.Forms.Button exitgame;
        private System.Windows.Forms.GroupBox menu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}