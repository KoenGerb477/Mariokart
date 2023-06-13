using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Mariokart
{
    public partial class Form1 : Form
    {
        List <Point> trackPoints = new List <Point> ();

        List <Point> startLinePoints = new List <Point> ();

        List <PointF> roadPoints = new List<PointF> ();
        //PointF[] road = new PointF[];

        PointF[] startLine = new PointF[4]; 

        string state = "main menu";

        Rectangle player = new Rectangle();
        Rectangle pipe = new Rectangle();

        int counter = 0;
        int counter2 = 0;

        Font drawFont = new Font("Arial", 50, FontStyle.Bold);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush darkGreenBrush = new SolidBrush(Color.DarkGreen);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush grayBrush = new SolidBrush(Color.Gray);
        Pen roadPen = new Pen(Color.Gray, 1);
        Pen blackPen = new Pen (Color.Black, 1);
        Pen whitePen = new Pen(Color.White, 1);

        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;

        int playerWidth = 112;
        int playerHeight = 120;
        int horizonHeight = 753/6;

        int driveSpeed = 0;
        int driveAcceleration = 1;
        int maxAcceleration = 20;

        float turnDirection = 0;
        float turningAcceleration = 0.5f;
        int maxTurnSpeed = 12;

        bool startLineActive = true;
        bool pipeActive = false;
        bool turnRight = false;
        bool straightenOutFromRight = false;
        bool turnLeft = false;
        bool straightenOutFromLeft = false;

        int distanceDriven = 0;
        
        int pipeSize = 20;

        float perspectiveAngle = 0.5f;

        float driftAmount = 0.1f;

        float originalTrackPosition;

        Image forwardDriveMario;
        Image left1DriveMario;
        Image left2DriveMario;
        Image left3DriveMario;
        Image left4DriveMario;
        Image left5DriveMario;
        Image left6DriveMario;
        Image right1DriveMario;
        Image right2DriveMario;
        Image right3DriveMario;
        Image right4DriveMario;
        Image right5DriveMario;
        Image right6DriveMario;

        Image forwardDriveBowser;
        Image left1DriveBowser;
        Image left2DriveBowser;
        Image left3DriveBowser;
        Image left4DriveBowser;
        Image left5DriveBowser;
        Image left6DriveBowser;
        Image right1DriveBowser;
        Image right2DriveBowser;
        Image right3DriveBowser;
        Image right4DriveBowser;
        Image right5DriveBowser;
        Image right6DriveBowser;

        Image forwardDriveKoopa;
        Image left1DriveKoopa;
        Image left2DriveKoopa;
        Image left3DriveKoopa;
        Image left4DriveKoopa;
        Image left5DriveKoopa;
        Image left6DriveKoopa;
        Image right1DriveKoopa;
        Image right2DriveKoopa;
        Image right3DriveKoopa;
        Image right4DriveKoopa;
        Image right5DriveKoopa;
        Image right6DriveKoopa;

        int spinningDonkeyImage = 22;
        Image[] donkeyImages = new Image[23];

        int spinningYoshiImage = 22;
        Image[] yoshiImages = new Image[23];

        int spinningToadImage = 22;
        Image[] toadImages = new Image[23];

        int spinningLuigiImage = 22;
        Image[] luigiImages = new Image[23];

        Image forwardDrivePeach;
        Image left1DrivePeach;
        Image left2DrivePeach;
        Image left3DrivePeach;
        Image left4DrivePeach;
        Image left5DrivePeach;
        Image left6DrivePeach;
        Image right1DrivePeach;
        Image right2DrivePeach;
        Image right3DrivePeach;
        Image right4DrivePeach;
        Image right5DrivePeach;
        Image right6DrivePeach;

        Image backDrive;

        Image[] playerImage = new Image[13];

        Rectangle marioDisplay = new Rectangle();

        string characterHovered;

        public Form1()
        {
            InitializeComponent();
            player = new Rectangle((this.Width / 2) - playerWidth / 2, this.Height - playerHeight * 3 / 2, playerWidth, playerHeight);

            marioDisplay = new Rectangle(marioButton.Location, marioButton.Size);

            left6DriveMario = Properties.Resources.mario__12_;
            left5DriveMario = Properties.Resources.mario__13_;
            left4DriveMario = Properties.Resources.mario__14_;
            left3DriveMario = Properties.Resources.mario__15_;
            left2DriveMario = Properties.Resources.mario__20_;
            left1DriveMario = Properties.Resources.mario__2_;
            forwardDriveMario = Properties.Resources.mario__21_;
            right1DriveMario = Properties.Resources.mario__4_;
            right2DriveMario = Properties.Resources.mario__39_;
            right3DriveMario = Properties.Resources.mario__16_;
            right4DriveMario = Properties.Resources.mario__17_;
            right5DriveMario = Properties.Resources.mario__18_;
            right6DriveMario = Properties.Resources.mario__19_;

            left6DriveBowser= Properties.Resources.bowser__2_;
            left5DriveBowser = Properties.Resources.bowser__2_;
            left4DriveBowser = Properties.Resources.bowser__3_;
            left3DriveBowser = Properties.Resources.bowser__4_;
            left2DriveBowser = Properties.Resources.bowser__5_;
            left1DriveBowser = Properties.Resources.bowser__6_;
            forwardDriveBowser = Properties.Resources.bowser__1_;
            right1DriveBowser = Properties.Resources.bowser__7_;
            right2DriveBowser = Properties.Resources.bowser__8_;
            right3DriveBowser = Properties.Resources.bowser__9_;
            right4DriveBowser = Properties.Resources.bowser__10_;
            right5DriveBowser = Properties.Resources.bowser__11_;
            right6DriveBowser = Properties.Resources.bowser__11_;

            left6DriveKoopa= Properties.Resources.koopa__2_;
            left5DriveKoopa = Properties.Resources.koopa__2_;
            left4DriveKoopa = Properties.Resources.koopa__1_;
            left3DriveKoopa = Properties.Resources.koopa__11_;
            left2DriveKoopa = Properties.Resources.koopa__10_;
            left1DriveKoopa = Properties.Resources.koopa__9_;
            forwardDriveKoopa = Properties.Resources.koopa__3_;
            right1DriveKoopa = Properties.Resources.koopa__4_;
            right2DriveKoopa = Properties.Resources.koopa__5_;
            right3DriveKoopa = Properties.Resources.koopa__6_;
            right4DriveKoopa = Properties.Resources.koopa__7_;
            right5DriveKoopa = Properties.Resources.koopa__8_;
            right6DriveKoopa = Properties.Resources.koopa__8_;

            yoshiImages[13] = Properties.Resources.yoshi__18_;
            yoshiImages[14] = Properties.Resources.yoshi__17_;
            yoshiImages[15] = Properties.Resources.yoshi__16_;
            yoshiImages[16] = Properties.Resources.yoshi__15_;
            yoshiImages[17] = Properties.Resources.yoshi__14_;
            yoshiImages[18] = Properties.Resources.yoshi__12_;
            yoshiImages[19] = Properties.Resources.yoshi__23_;
            yoshiImages[20] = Properties.Resources.yoshi__22_;
            yoshiImages[21] = Properties.Resources.yoshi__21_;
            yoshiImages[22] = Properties.Resources.yoshi__20_;

            yoshiImages[12]= Properties.Resources.yoshi__2_;
            yoshiImages[11] = Properties.Resources.yoshi__2_;
            yoshiImages[10] = Properties.Resources.yoshi__3_;
            yoshiImages[9] = Properties.Resources.yoshi__4_;
            yoshiImages[8] = Properties.Resources.yoshi__5_;
            yoshiImages[7] = Properties.Resources.yoshi__6_;
            yoshiImages[6] = Properties.Resources.yoshi__7_;
            yoshiImages[5] = Properties.Resources.yoshi__8_;
            yoshiImages[4] = Properties.Resources.yoshi__9_;
            yoshiImages[3] = Properties.Resources.yoshi__10_;
            yoshiImages[2] = Properties.Resources.yoshi__11_;
            yoshiImages[1] = Properties.Resources.yoshi__1_;
            yoshiImages[0] = Properties.Resources.yoshi__1_;

            donkeyImages[13] = Properties.Resources.donkey__15_;
            donkeyImages[14] = Properties.Resources.donkey__14_;
            donkeyImages[15] = Properties.Resources.donkey__13_;
            donkeyImages[16] = Properties.Resources.donkey__23_;
            donkeyImages[17] = Properties.Resources.donkey__22_;
            donkeyImages[18] = Properties.Resources.donkey__21_;
            donkeyImages[19] = Properties.Resources.donkey__20_;
            donkeyImages[20] = Properties.Resources.donkey__19_;
            donkeyImages[21] = Properties.Resources.donkey__18_;
            donkeyImages[22] = Properties.Resources.donkey__17_;

            donkeyImages[12]= Properties.Resources.donkey__1_;
            donkeyImages[11] = Properties.Resources.donkey__1_;
            donkeyImages[10] = Properties.Resources.donkey__11_;
            donkeyImages[9] = Properties.Resources.donkey__10_;
            donkeyImages[8] = Properties.Resources.donkey__8_;
            donkeyImages[7] = Properties.Resources.donkey__9_;
            donkeyImages[6] = Properties.Resources.donkey__2_;
            donkeyImages[5] = Properties.Resources.donkey__3_;
            donkeyImages[4] = Properties.Resources.donkey__4_;
            donkeyImages[3] = Properties.Resources.donkey__5_;
            donkeyImages[2] = Properties.Resources.donkey__6_;
            donkeyImages[1] = Properties.Resources.donkey__7_;
            donkeyImages[0] = Properties.Resources.donkey__7_;

            luigiImages[13] = Properties.Resources.luigi__13_;
            luigiImages[14] = Properties.Resources.luigi__12_;
            luigiImages[15] = Properties.Resources.luigi__22_;
            luigiImages[16] = Properties.Resources.luigi__21_;
            luigiImages[17] = Properties.Resources.luigi__20_;
            luigiImages[18] = Properties.Resources.luigi__19_;
            luigiImages[19] = Properties.Resources.luigi__18_;
            luigiImages[20] = Properties.Resources.luigi__17_;
            luigiImages[21] = Properties.Resources.luigi__16_;
            luigiImages[22] = Properties.Resources.luigi__15_;

            luigiImages[12]= Properties.Resources.luigi__2_;
            luigiImages[11] = Properties.Resources.luigi__2_;
            luigiImages[10] = Properties.Resources.luigi__3_;
            luigiImages[9] = Properties.Resources.luigi__4_;
            luigiImages[8] = Properties.Resources.luigi__5_;
            luigiImages[7] = Properties.Resources.luigi__6_;
            luigiImages[6] = Properties.Resources.luigi__7_;
            luigiImages[5] = Properties.Resources.luigi__8_;
            luigiImages[4] = Properties.Resources.luigi__9_;
            luigiImages[3] = Properties.Resources.luigi__10_;
            luigiImages[2] = Properties.Resources.luigi__11_;
            luigiImages[1] = Properties.Resources.luigi__1_;
            luigiImages[0] = Properties.Resources.luigi__1_;

            toadImages[13] = Properties.Resources.toad__17_;
            toadImages[14] = Properties.Resources.toad__16_;
            toadImages[15] = Properties.Resources.toad__15_;
            toadImages[16] = Properties.Resources.toad__14_;
            toadImages[17] = Properties.Resources.toad__13_;
            toadImages[18] = Properties.Resources.toad__12_;
            toadImages[19] = Properties.Resources.toad__23_;
            toadImages[20] = Properties.Resources.toad__22_;
            toadImages[21] = Properties.Resources.toad__21_;
            toadImages[22] = Properties.Resources.toad__20_;

            toadImages[12]= Properties.Resources.toad__3_;
            toadImages[11] = Properties.Resources.toad__3_;
            toadImages[10] = Properties.Resources.toad__4_;
            toadImages[9] = Properties.Resources.toad__5_;
            toadImages[8] = Properties.Resources.toad__6_;
            toadImages[7] = Properties.Resources.toad__7_;
            toadImages[6] = Properties.Resources.toad__8_;
            toadImages[5] = Properties.Resources.toad__9_;
            toadImages[4] = Properties.Resources.toad__10_;
            toadImages[3] = Properties.Resources.toad__11_;
            toadImages[2] = Properties.Resources.toad__1_;
            toadImages[1] = Properties.Resources.toad__2_;
            toadImages[0] = Properties.Resources.toad__2_;

            left6DrivePeach= Properties.Resources.peach__2_;
            left5DrivePeach = Properties.Resources.peach__2_;
            left4DrivePeach = Properties.Resources.peach__3_;
            left3DrivePeach = Properties.Resources.peach__4_;
            left2DrivePeach = Properties.Resources.peach__5_;
            left1DrivePeach = Properties.Resources.peach__6_;
            forwardDrivePeach = Properties.Resources.peach__7_;
            right1DrivePeach = Properties.Resources.peach__8_;
            right2DrivePeach = Properties.Resources.peach__9_;
            right3DrivePeach = Properties.Resources.peach__10_;
            right4DrivePeach = Properties.Resources.peach__11_;
            right5DrivePeach = Properties.Resources.peach__1_;
            right6DrivePeach = Properties.Resources.peach__1_;
            /*state = "play game";
            MakeTrack();
            gameTimer.Enabled = true;*/
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (state == "main menu")
                    {
                        state = "select character";
                        Refresh();
                    }
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
            }
        }


        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (wDown == true)
            {
                MoveForward();
            }
            //else (till counter = 0) {
            //    MoveForward();
            //}

            //if(counter > max)
            //{
            //    set to max
            //}
            if (sDown == true)
            {
                MoveBackwards();
            }
            if (aDown == true && wDown == true)
            {
                MoveSideways(turningAcceleration);
            }
            if (dDown == true && wDown == true)
            {
                MoveSideways(-turningAcceleration);
            }

            if (wDown == false && driveSpeed > 0)
            {
                driveSpeed -= driveAcceleration * 2;
                MoveForward();
            }
            
            if (distanceDriven == 150)
            {
                turnRight = true;
            }
            else if (distanceDriven == 300)
            {
                straightenOutFromRight = true;
                turnRight = false;
            }
            else if (distanceDriven == 450)
            {
                turnLeft = true;
                driftAmount = -0.1f;
                straightenOutFromRight = false;
            }
            else if (distanceDriven == 600)
            {
                straightenOutFromLeft = true;
                turnLeft = false;
            }
            else if (distanceDriven == 750)
            {
                turnLeft = true;
                driftAmount = -0.1f;
                straightenOutFromLeft = false;
            }
            else if (distanceDriven == 900)
            {
                straightenOutFromLeft = true;
                turnLeft = false;
            }
            else if (distanceDriven == 950)
            {
                turnRight = true;
                driftAmount = 0.1f;
                straightenOutFromLeft = false;
            }
            else if (distanceDriven == 1200)
            {
                straightenOutFromRight = true;
                turnRight = false;
            }
            else if (distanceDriven == 1500)
            {
                distanceDriven = 0;
                counter++;
            }

            /*if (distanceDriven == 150)
            {
                pipe = new Rectangle(trackPoints[0].X - pipeSize*2, trackPoints[0].Y - pipeSize, pipeSize, pipeSize);
            }
            if (distanceDriven == 200)
            {
                pipeActive = true;
            }
            if (pipe.Y > this.Height)
            {
                pipeActive=false;

                turnRight = true;
            }*/
            if (wDown == true && aDown == dDown)
            {
                if (turnDirection > 0)
                {
                    turnDirection -= turningAcceleration;
                }
                else if (turnDirection < 0)
                {
                    turnDirection += turningAcceleration;
                }
            }

            if (counter == 3)
            {
                state = "main menu";
                gameTimer.Enabled = false;
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameTimer.Enabled == true)
            {

            }

            if (state == "main menu")
            {
                e.Graphics.DrawString("MARIOKART", drawFont, redBrush, 250, 100);
                e.Graphics.DrawString("Press SPACE to play", drawFont, redBrush, 125, 200);
            }
            else if (state == "play game")
            {
                e.Graphics.FillRectangle(greenBrush, 0, 0, Width, Height);

                for (int i = 0; i < startLinePoints.Count; i++)
                {
                    e.Graphics.DrawLine(blackPen, startLinePoints[i], startLinePoints[i+1]);
                    i++;
                }
                
                PointF[] roadArray = new PointF[roadPoints.Count];
                for (int i = 0; i < roadPoints.Count; i++)
                {
                    roadArray[i] = roadPoints[i];
                }
                e.Graphics.FillPolygon(grayBrush, roadArray);

                e.Graphics.FillPolygon(blackBrush, startLine);

                e.Graphics.FillRectangle(blueBrush, 0, 0, Width, horizonHeight);

                e.Graphics.FillRectangle(darkGreenBrush, pipe);

                e.Graphics.DrawImage(playerImage[Convert.ToInt16((turnDirection / 2) + 6)], player);
            }
            else if (state == "select character")
            {
                marioButton.Visible = true;
                bowserButton.Visible = true;
                koopaButton.Visible = true;
                peachButton.Visible = true;
                toadButton.Visible = true;
                donkeyButton.Visible = true; 
                luigiButton.Visible = true;
                yoshiButton.Visible = true;
                marioButton.Enabled = true;
                bowserButton.Enabled = true;
                peachButton.Enabled = true;
                luigiButton.Enabled = true;
                koopaButton.Enabled = true;
                yoshiButton.Enabled = true;
                donkeyButton.Enabled = true;
                toadButton.Enabled = true;

                toadButton.Image = toadImages[spinningToadImage];
                luigiButton.Image = luigiImages[spinningLuigiImage];
                donkeyButton.Image = donkeyImages[spinningDonkeyImage];
                yoshiButton.Image = yoshiImages[spinningYoshiImage];
            }
        }

        public void MakeTrack()
        {
            gameTimer.Enabled = true;
            
            float lastX = 0;
            float x = 0;
            //make road
            for (int i = this.Height; i > horizonHeight; i--)
            {
                PointF point = new PointF(x, i);
                roadPoints.Add(point);

                lastX = x;
                x += perspectiveAngle;
            }
            x = this.Width - lastX;
            for (int i = horizonHeight; i < this.Height; i++)
            {
                PointF point = new PointF(x, i);
                roadPoints.Add(point);

                x += perspectiveAngle;
            }
            originalTrackPosition = roadPoints[(roadPoints.Count-1)/2].X - roadPoints[0].X;


            startLine[0] = new PointF(roadPoints[300].X, roadPoints[300].Y);
            startLine[1] = new PointF(roadPoints[400].X, roadPoints[400].Y);
            startLine[2] = new PointF(roadPoints[roadPoints.Count - 400].X, roadPoints[roadPoints.Count - 400].Y);
            startLine[3] = new PointF(roadPoints[roadPoints.Count - 300].X, roadPoints[roadPoints.Count - 300].Y);

            /*
            //make start line
            for (int i = horizonHeight * 2; i < horizonHeight * 3; i++)
            {
                //make points for each line making the track
                Point point = new Point(-i /2 + (Width/6)*3/2, i + horizonHeight);
                startLinePoints.Add(point);

                point = new Point(i/2 +(Width / 6) * 9/2, i + horizonHeight);
                startLinePoints.Add(point);
            }*/
        }

        public void MoveForward()
        {
            if (driveSpeed < maxAcceleration)
            {
                driveSpeed += driveAcceleration;
            }

            distanceDriven++;

            if (startLineActive == true)
            {
                startLine[0].Y+=driveSpeed * 1.5f;
                startLine[1].Y+=driveSpeed;
                startLine[2].Y+=driveSpeed;
                startLine[3].Y+=driveSpeed * 1.5f;

                startLine[0].X-=(driveSpeed * 1.5f) * perspectiveAngle;
                startLine[1].X-= driveSpeed * perspectiveAngle;
                startLine[2].X+=driveSpeed * perspectiveAngle;
                startLine[3].X+=(driveSpeed * 1.5f) * perspectiveAngle;
            }

            if (turnRight == true)
            {
                if (roadPoints[roadPoints.Count/2].X <= this.Width * 2)
                {
                    float moveAmount = 0.1f;
                    for (int i = 0; i <= roadPoints.Count / 2; i++)
                    {
                        PointF point = roadPoints[i];
                        point.X += moveAmount;
                        roadPoints[i] = point;

                        moveAmount *= 1.01f;
                    }

                    moveAmount = 0.1f;
                    for (int i = roadPoints.Count - 1; i >= roadPoints.Count/2; i--)
                    {
                        PointF point = roadPoints[i];
                        point.X += moveAmount;
                        roadPoints[i] = point;

                        moveAmount *= 1.01f;
                    }
                    if (driftAmount <= 10)
                    {
                        driftAmount *= 1.1f;
                    }
                }

                for (int i = 0; i < roadPoints.Count; i++)
                {
                    PointF point = roadPoints[i];
                    point.X += driftAmount;
                    roadPoints[i] = point;
                }
            }

            if (straightenOutFromRight == true)
            {

                if (roadPoints[(roadPoints.Count-1)/2].X - roadPoints[0].X >= originalTrackPosition)
                {

                    float moveAmount = -0.1f;

                    for (int i = 0; i <= roadPoints.Count / 2; i++)
                    {
                        PointF point = roadPoints[i];
                        point.X += moveAmount;
                        roadPoints[i] = point;

                        moveAmount *= 1.01f;
                    }

                    moveAmount = -0.1f;
                    for (int i = roadPoints.Count - 1; i >= roadPoints.Count/2; i--)
                    {
                        PointF point = roadPoints[i];
                        point.X += moveAmount;
                        roadPoints[i] = point;

                        moveAmount *= 1.01f;
                    }
                }
                else
                {
                    straightenOutFromRight = false;
                }
                for (int i = 0; i < roadPoints.Count; i++)
                {
                    PointF point = roadPoints[i];
                    point.X += driftAmount;
                    roadPoints[i] = point;
                }
            }

            if (turnLeft == true)
            {
                if (roadPoints[(roadPoints.Count-1)/2].X >= -this.Width)
                {
                    float moveAmount = -0.1f;

                    for (int i = 0; i <= roadPoints.Count / 2; i++)
                    {
                        PointF point = roadPoints[i];
                        point.X += moveAmount;
                        roadPoints[i] = point;

                        moveAmount *= 1.01f;
                    }

                    moveAmount = -0.1f;
                    for (int i = roadPoints.Count - 1; i >= roadPoints.Count/2; i--)
                    {
                        PointF point = roadPoints[i];
                        point.X += moveAmount;
                        roadPoints[i] = point;

                        moveAmount *= 1.01f;
                    }

                    if (driftAmount >= -10)
                    {
                        driftAmount *= 1.1f;
                    }
                }

                for (int i = 0; i < roadPoints.Count; i++)
                {
                    PointF point = roadPoints[i];
                    point.X += driftAmount;
                    roadPoints[i] = point;
                }
            }

            if (straightenOutFromLeft == true)
            {

                if (roadPoints[(roadPoints.Count-1)/2].X - roadPoints[0].X <= originalTrackPosition)
                {

                    float moveAmount = 0.1f;

                    for (int i = 0; i <= roadPoints.Count / 2; i++)
                    {
                        PointF point = roadPoints[i];
                        point.X += moveAmount;
                        roadPoints[i] = point;

                        moveAmount *= 1.01f;
                    }

                    moveAmount = 0.1f;
                    for (int i = roadPoints.Count - 1; i >= roadPoints.Count/2; i--)
                    {
                        PointF point = roadPoints[i];
                        point.X += moveAmount;
                        roadPoints[i] = point;

                        moveAmount *= 1.01f;
                    }
                }
                else
                {
                    straightenOutFromLeft = false;
                }
                for (int i = 0; i < roadPoints.Count; i++)
                {
                    PointF point = roadPoints[i];
                    point.X += driftAmount;
                    roadPoints[i] = point;
                }

            }

            /*if (pipeActive == true)
            {
                pipeSize+=5;

                pipe.X -= driveSpeed * 2;
                pipe.Y += driveSpeed;
                pipe.Width = pipeSize;
                pipe.Height = pipeSize;
            }*/
        }

        public void MoveSideways(float turningAcceleration)
        {
            if (turnDirection < maxTurnSpeed && turnDirection > -maxTurnSpeed)
            {
                turnDirection += turningAcceleration;
            }

            for (int i = 0; i < roadPoints.Count; i++)
            {
                PointF point = roadPoints[i];
                point.X += turnDirection;
                roadPoints[i] = point;
            }

            if (startLineActive == true)
            {
                startLine[0].X += turnDirection;
                startLine[1].X += turnDirection;
                startLine[2].X += turnDirection;
                startLine[3].X += turnDirection;
            }

            /*if (pipeActive == true)
            { 
                pipe.X -= driveSpeed;
            }*/
        }

        public void MoveBackwards()
        {
            distanceDriven--;

            if (startLineActive == true)
            {
                startLine[0].Y-=driveSpeed * 1.5f;
                startLine[1].Y-=driveSpeed;
                startLine[2].Y-=driveSpeed;
                startLine[3].Y-=driveSpeed * 1.5f;

                startLine[0].X +=(driveSpeed * 1.5f) * perspectiveAngle;
                startLine[1].X += driveSpeed * perspectiveAngle;
                startLine[2].X-=driveSpeed * perspectiveAngle;
                startLine[3].X-=(driveSpeed * 1.5f) * perspectiveAngle;
            }

            /*if (pipeActive == true)
            {
                pipeSize-=5;

                pipe.X += driveSpeed * 2;
                pipe.Y -= driveSpeed;
                pipe.Width = pipeSize;
                pipe.Height = pipeSize;
            }*/
        }

        private void marioButton_Click(object sender, EventArgs e)
        {
            playerImage[0] = right6DriveMario;
            playerImage[1] = right5DriveMario;
            playerImage[2] = right4DriveMario;
            playerImage[3] = right3DriveMario;
            playerImage[4] = right2DriveMario;
            playerImage[5] = right1DriveMario;
            playerImage[6] = forwardDriveMario;
            playerImage[7] = left1DriveMario;
            playerImage[8] = left2DriveMario;
            playerImage[9] = left3DriveMario;
            playerImage[10] = left4DriveMario;
            playerImage[11] = left5DriveMario;
            playerImage[12] = left6DriveMario;

            gameTimer.Enabled = true;

            state = "play game";

            marioButton.Visible = false;
            bowserButton.Visible = false;
            peachButton.Visible = false;
            koopaButton.Visible = false;
            luigiButton.Visible = false;
            yoshiButton.Visible = false;
            donkeyButton.Visible = false;
            toadButton.Visible = false;
            marioButton.Enabled = false;
            bowserButton.Enabled = false;
            peachButton.Enabled = false;
            luigiButton.Enabled = false;
            koopaButton.Enabled = false;
            yoshiButton.Enabled = false;
            donkeyButton.Enabled = false;
            toadButton.Enabled = false;

            MakeTrack();
        }

        private void bowserButton_Click(object sender, EventArgs e)
        {
            playerImage[0] = right6DriveBowser;
            playerImage[1] = right5DriveBowser;
            playerImage[2] = right4DriveBowser;
            playerImage[3] = right3DriveBowser;
            playerImage[4] = right2DriveBowser;
            playerImage[5] = right1DriveBowser;
            playerImage[6] = forwardDriveBowser;
            playerImage[7] = left1DriveBowser;
            playerImage[8] = left2DriveBowser;
            playerImage[9] = left3DriveBowser;
            playerImage[10] = left4DriveBowser;
            playerImage[11] = left5DriveBowser;
            playerImage[12] = left6DriveBowser;

            state = "play game";

            marioButton.Visible = false;
            bowserButton.Visible = false;
            peachButton.Visible = false;
            koopaButton.Visible = false;
            luigiButton.Visible = false;
            yoshiButton.Visible = false;   
            donkeyButton.Visible = false;
            toadButton.Visible = false;
            marioButton.Enabled = false;
            bowserButton.Enabled = false;
            peachButton.Enabled = false;
            luigiButton.Enabled = false;
            koopaButton.Enabled = false;
            yoshiButton.Enabled = false;
            donkeyButton.Enabled = false;
            toadButton.Enabled = false;


            gameTimer.Enabled = true;
            MakeTrack();
        }

        private void peachButton_Click(object sender, EventArgs e)
        {
            playerImage[0] = right6DrivePeach;
            playerImage[1] = right5DrivePeach;
            playerImage[2] = right4DrivePeach;
            playerImage[3] = right3DrivePeach;
            playerImage[4] = right2DrivePeach;
            playerImage[5] = right1DrivePeach;
            playerImage[6] = forwardDrivePeach;
            playerImage[7] = left1DrivePeach;
            playerImage[8] = left2DrivePeach;
            playerImage[9] = left3DrivePeach;
            playerImage[10] = left4DrivePeach;
            playerImage[11] = left5DrivePeach;
            playerImage[12] = left6DrivePeach;

            gameTimer.Enabled = true;

            state = "play game";

            marioButton.Visible = false;
            bowserButton.Visible = false;
            peachButton.Visible = false;
            koopaButton.Visible = false;
            luigiButton.Visible = false;
            yoshiButton.Visible = false;
            donkeyButton.Visible = false;
            toadButton.Visible = false;
            marioButton.Enabled = false;
            bowserButton.Enabled = false;
            peachButton.Enabled = false;
            luigiButton.Enabled = false;
            koopaButton.Enabled = false;
            yoshiButton.Enabled = false;
            donkeyButton.Enabled = false;
            toadButton.Enabled = false;

            MakeTrack();
        }

        private void koopaButton_Click(object sender, EventArgs e)
        {
            playerImage[0] = right6DriveKoopa;
            playerImage[1] = right5DriveKoopa;
            playerImage[2] = right4DriveKoopa;
            playerImage[3] = right3DriveKoopa;
            playerImage[4] = right2DriveKoopa;
            playerImage[5] = right1DriveKoopa;
            playerImage[6] = forwardDriveKoopa;
            playerImage[7] = left1DriveKoopa;
            playerImage[8] = left2DriveKoopa;
            playerImage[9] = left3DriveKoopa;
            playerImage[10] = left4DriveKoopa;
            playerImage[11] = left5DriveKoopa;
            playerImage[12] = left6DriveKoopa;

            state = "play game";

            marioButton.Visible = false;
            bowserButton.Visible = false;
            peachButton.Visible = false;
            koopaButton.Visible = false;
            luigiButton.Visible = false;
            yoshiButton.Visible = false;
            donkeyButton.Visible = false;
            toadButton.Visible = false;
            marioButton.Enabled = false;
            bowserButton.Enabled = false;
            peachButton.Enabled = false;
            luigiButton.Enabled = false;
            koopaButton.Enabled = false;
            yoshiButton.Enabled = false;
            donkeyButton.Enabled = false;
            toadButton.Enabled = false;


            gameTimer.Enabled = true;
            MakeTrack();
        }

        private void luigiButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 12; i++)
            {
                playerImage[i] = luigiImages[i];
            }

            gameTimer.Enabled = true;

            state = "play game";

            marioButton.Visible = false;
            bowserButton.Visible = false;
            peachButton.Visible = false;
            koopaButton.Visible = false;
            luigiButton.Visible = false;
            yoshiButton.Visible = false;
            donkeyButton.Visible = false;
            toadButton.Visible = false;
            marioButton.Enabled = false;
            bowserButton.Enabled = false;
            peachButton.Enabled = false;
            luigiButton.Enabled = false;
            koopaButton.Enabled = false;
            yoshiButton.Enabled = false;
            donkeyButton.Enabled = false;
            toadButton.Enabled = false;

            MakeTrack();
        }

        private void yoshiButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 12; i++)
            {
                playerImage[i] = yoshiImages[i];
            }

            gameTimer.Enabled = true;

            state = "play game";

            marioButton.Visible = false;
            bowserButton.Visible = false;
            peachButton.Visible = false;
            koopaButton.Visible = false;
            luigiButton.Visible = false;
            yoshiButton.Visible = false;
            donkeyButton.Visible = false;
            toadButton.Visible = false;
            marioButton.Enabled = false;
            bowserButton.Enabled = false;
            peachButton.Enabled = false;
            luigiButton.Enabled = false;
            koopaButton.Enabled = false;
            yoshiButton.Enabled = false;
            donkeyButton.Enabled = false;
            toadButton.Enabled = false;

            MakeTrack();
        }

        private void donkeyButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 12; i++)
            {
                playerImage[i] = donkeyImages[i];
            }

            state = "play game";

            marioButton.Visible = false;
            bowserButton.Visible = false;
            peachButton.Visible = false;
            koopaButton.Visible = false;
            luigiButton.Visible = false;
            yoshiButton.Visible = false;
            donkeyButton.Visible = false;
            toadButton.Visible = false;
            marioButton.Enabled = false;
            bowserButton.Enabled = false;
            peachButton.Enabled = false;
            luigiButton.Enabled = false;
            koopaButton.Enabled = false;
            yoshiButton.Enabled = false;
            donkeyButton.Enabled = false;
            toadButton.Enabled = false;


            gameTimer.Enabled = true;
            MakeTrack();
        }

        private void toadButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 12; i++)
            {
                playerImage[i] = toadImages[i];
            }

            gameTimer.Enabled = true;

            state = "play game";

            marioButton.Visible = false;
            bowserButton.Visible = false;
            peachButton.Visible = false;
            koopaButton.Visible = false;
            luigiButton.Visible = false;
            yoshiButton.Visible = false;
            donkeyButton.Visible = false;
            toadButton.Visible = false;
            marioButton.Enabled = false;
            bowserButton.Enabled = false;
            peachButton.Enabled = false;
            luigiButton.Enabled = false;
            koopaButton.Enabled = false;
            yoshiButton.Enabled = false;
            donkeyButton.Enabled = false;
            toadButton.Enabled = false;

            MakeTrack();
        }

        private void toadButton_MouseHover(object sender, EventArgs e)
        {
            hoverTimer.Enabled = true;
            characterHovered = "toad";
        }

        private void toadButton_MouseLeave(object sender, EventArgs e)
        {

            hoverTimer.Enabled = false;
            spinningToadImage = 22;
            toadButton.Refresh();
        }

        private void hoverTimer_Tick(object sender, EventArgs e)
        {
            switch (characterHovered)
            {
                case "toad":
                    if (spinningToadImage == 22)
                    {
                        spinningToadImage = 0;
                    }
                    else
                    {
                        spinningToadImage++;
                    }
                    toadButton.Refresh();
                    break;
                case "luigi":
                    if (spinningLuigiImage == 22)
                    {
                        spinningLuigiImage = 0;
                    }
                    else
                    {
                        spinningLuigiImage++;
                    }
                    luigiButton.Refresh();
                    break;
                case "donkey":
                    if (spinningDonkeyImage == 22)
                    {
                        spinningDonkeyImage = 0;
                    }
                    else
                    {
                        spinningDonkeyImage++;
                    }
                    donkeyButton.Refresh();
                    break;
                case "yoshi":
                    if (spinningYoshiImage == 22)
                    {
                        spinningYoshiImage = 0;
                    }
                    else
                    {
                        spinningYoshiImage++;
                    }
                    yoshiButton.Refresh();
                    break;
            }
        }

        private void luigiButton_MouseHover(object sender, EventArgs e)
        {
            hoverTimer.Enabled = true;
            characterHovered = "luigi";
        }

        private void luigiButton_MouseLeave(object sender, EventArgs e)
        {
            hoverTimer.Enabled = false;
            spinningLuigiImage = 22;
            luigiButton.Refresh();
        }

        private void donkeyButton_MouseHover(object sender, EventArgs e)
        {
            hoverTimer.Enabled = true;
            characterHovered = "donkey";
        }

        private void donkeyButton_MouseLeave(object sender, EventArgs e)
        {
            hoverTimer.Enabled = false;
            spinningDonkeyImage = 22;
            donkeyButton.Refresh();
        }

        private void yoshiButton_MouseHover(object sender, EventArgs e)
        {
            hoverTimer.Enabled = true;
            characterHovered = "yoshi";
        }

        private void yoshiButton_MouseLeave(object sender, EventArgs e)
        {
            hoverTimer.Enabled = false;
            spinningYoshiImage = 22;
            yoshiButton.Refresh();
        }
    }
}
