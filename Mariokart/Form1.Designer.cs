namespace Mariokart
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.bowserButton = new System.Windows.Forms.Button();
            this.marioButton = new System.Windows.Forms.Button();
            this.luigiButton = new System.Windows.Forms.Button();
            this.yoshiButton = new System.Windows.Forms.Button();
            this.donkeyButton = new System.Windows.Forms.Button();
            this.toadButton = new System.Windows.Forms.Button();
            this.peachButton = new System.Windows.Forms.Button();
            this.koopaButton = new System.Windows.Forms.Button();
            this.hoverTimer = new System.Windows.Forms.Timer(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.leaderboardLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 12;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // bowserButton
            // 
            this.bowserButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bowserButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bowserButton.Location = new System.Drawing.Point(623, 154);
            this.bowserButton.Name = "bowserButton";
            this.bowserButton.Size = new System.Drawing.Size(200, 200);
            this.bowserButton.TabIndex = 0;
            this.bowserButton.UseVisualStyleBackColor = true;
            this.bowserButton.Visible = false;
            this.bowserButton.Click += new System.EventHandler(this.bowserButton_Click);
            this.bowserButton.MouseLeave += new System.EventHandler(this.bowserButton_MouseLeave);
            this.bowserButton.MouseHover += new System.EventHandler(this.bowserButton_MouseHover);
            // 
            // marioButton
            // 
            this.marioButton.BackColor = System.Drawing.Color.Transparent;
            this.marioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.marioButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.marioButton.Location = new System.Drawing.Point(78, 154);
            this.marioButton.Name = "marioButton";
            this.marioButton.Size = new System.Drawing.Size(200, 200);
            this.marioButton.TabIndex = 1;
            this.marioButton.UseVisualStyleBackColor = false;
            this.marioButton.Visible = false;
            this.marioButton.Click += new System.EventHandler(this.marioButton_Click);
            this.marioButton.MouseLeave += new System.EventHandler(this.marioButton_MouseLeave);
            this.marioButton.MouseHover += new System.EventHandler(this.marioButton_MouseHover);
            // 
            // luigiButton
            // 
            this.luigiButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.luigiButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.luigiButton.Location = new System.Drawing.Point(78, 390);
            this.luigiButton.Name = "luigiButton";
            this.luigiButton.Size = new System.Drawing.Size(200, 200);
            this.luigiButton.TabIndex = 6;
            this.luigiButton.UseVisualStyleBackColor = true;
            this.luigiButton.Visible = false;
            this.luigiButton.Click += new System.EventHandler(this.luigiButton_Click);
            this.luigiButton.MouseLeave += new System.EventHandler(this.luigiButton_MouseLeave);
            this.luigiButton.MouseHover += new System.EventHandler(this.luigiButton_MouseHover);
            // 
            // yoshiButton
            // 
            this.yoshiButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.yoshiButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.yoshiButton.Location = new System.Drawing.Point(334, 390);
            this.yoshiButton.Name = "yoshiButton";
            this.yoshiButton.Size = new System.Drawing.Size(200, 200);
            this.yoshiButton.TabIndex = 5;
            this.yoshiButton.UseVisualStyleBackColor = true;
            this.yoshiButton.Visible = false;
            this.yoshiButton.Click += new System.EventHandler(this.yoshiButton_Click);
            this.yoshiButton.MouseLeave += new System.EventHandler(this.yoshiButton_MouseLeave);
            this.yoshiButton.MouseHover += new System.EventHandler(this.yoshiButton_MouseHover);
            // 
            // donkeyButton
            // 
            this.donkeyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.donkeyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.donkeyButton.Location = new System.Drawing.Point(623, 390);
            this.donkeyButton.Name = "donkeyButton";
            this.donkeyButton.Size = new System.Drawing.Size(200, 200);
            this.donkeyButton.TabIndex = 10;
            this.donkeyButton.UseVisualStyleBackColor = true;
            this.donkeyButton.Visible = false;
            this.donkeyButton.Click += new System.EventHandler(this.donkeyButton_Click);
            this.donkeyButton.MouseLeave += new System.EventHandler(this.donkeyButton_MouseLeave);
            this.donkeyButton.MouseHover += new System.EventHandler(this.donkeyButton_MouseHover);
            // 
            // toadButton
            // 
            this.toadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.toadButton.Location = new System.Drawing.Point(908, 390);
            this.toadButton.Name = "toadButton";
            this.toadButton.Size = new System.Drawing.Size(200, 200);
            this.toadButton.TabIndex = 9;
            this.toadButton.UseVisualStyleBackColor = true;
            this.toadButton.Visible = false;
            this.toadButton.Click += new System.EventHandler(this.toadButton_Click);
            this.toadButton.MouseLeave += new System.EventHandler(this.toadButton_MouseLeave);
            this.toadButton.MouseHover += new System.EventHandler(this.toadButton_MouseHover);
            // 
            // peachButton
            // 
            this.peachButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.peachButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.peachButton.Location = new System.Drawing.Point(334, 154);
            this.peachButton.Name = "peachButton";
            this.peachButton.Size = new System.Drawing.Size(200, 200);
            this.peachButton.TabIndex = 8;
            this.peachButton.UseVisualStyleBackColor = true;
            this.peachButton.Visible = false;
            this.peachButton.Click += new System.EventHandler(this.peachButton_Click);
            this.peachButton.MouseLeave += new System.EventHandler(this.peachButton_MouseLeave);
            this.peachButton.MouseHover += new System.EventHandler(this.peachButton_MouseHover);
            // 
            // koopaButton
            // 
            this.koopaButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.koopaButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.koopaButton.Location = new System.Drawing.Point(908, 154);
            this.koopaButton.Name = "koopaButton";
            this.koopaButton.Size = new System.Drawing.Size(200, 200);
            this.koopaButton.TabIndex = 7;
            this.koopaButton.UseVisualStyleBackColor = true;
            this.koopaButton.Visible = false;
            this.koopaButton.Click += new System.EventHandler(this.koopaButton_Click);
            this.koopaButton.MouseLeave += new System.EventHandler(this.koopaButton_MouseLeave);
            this.koopaButton.MouseHover += new System.EventHandler(this.koopaButton_MouseHover);
            // 
            // hoverTimer
            // 
            this.hoverTimer.Tick += new System.EventHandler(this.hoverTimer_Tick);
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Black;
            this.titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleLabel.Font = new System.Drawing.Font("Comic Sans MS", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.titleLabel.Location = new System.Drawing.Point(204, 49);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(769, 71);
            this.titleLabel.TabIndex = 11;
            this.titleLabel.Text = "Racing Karts and Also Mario";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitButton
            // 
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(272, 541);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(200, 122);
            this.exitButton.TabIndex = 13;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Visible = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // playButton
            // 
            this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(716, 541);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(200, 122);
            this.playButton.TabIndex = 14;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Visible = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nextButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextButton.Location = new System.Drawing.Point(951, 606);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(200, 122);
            this.nextButton.TabIndex = 15;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Visible = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // leaderboardLabel
            // 
            this.leaderboardLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.leaderboardLabel.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboardLabel.Location = new System.Drawing.Point(204, 138);
            this.leaderboardLabel.Name = "leaderboardLabel";
            this.leaderboardLabel.Size = new System.Drawing.Size(769, 452);
            this.leaderboardLabel.TabIndex = 16;
            this.leaderboardLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.donkeyButton);
            this.Controls.Add(this.toadButton);
            this.Controls.Add(this.peachButton);
            this.Controls.Add(this.koopaButton);
            this.Controls.Add(this.luigiButton);
            this.Controls.Add(this.yoshiButton);
            this.Controls.Add(this.marioButton);
            this.Controls.Add(this.bowserButton);
            this.Controls.Add(this.leaderboardLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button bowserButton;
        private System.Windows.Forms.Button marioButton;
        private System.Windows.Forms.Button luigiButton;
        private System.Windows.Forms.Button yoshiButton;
        private System.Windows.Forms.Button donkeyButton;
        private System.Windows.Forms.Button toadButton;
        private System.Windows.Forms.Button peachButton;
        private System.Windows.Forms.Button koopaButton;
        private System.Windows.Forms.Timer hoverTimer;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label leaderboardLabel;
    }
}

