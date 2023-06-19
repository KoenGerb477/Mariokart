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
            this.label1 = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.donkeyButton);
            this.Controls.Add(this.toadButton);
            this.Controls.Add(this.peachButton);
            this.Controls.Add(this.koopaButton);
            this.Controls.Add(this.luigiButton);
            this.Controls.Add(this.yoshiButton);
            this.Controls.Add(this.marioButton);
            this.Controls.Add(this.bowserButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label1;
    }
}

