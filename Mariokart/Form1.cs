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
        bool turnRight = false;
        bool straightenOutFromRight = false;
        bool turnLeft = false;
        bool straightenOutFromLeft = false;

        int distanceDriven = 0;
        
        float perspectiveAngle = 0.5f;

        float driftAmount = 0.1f;

        float originalTrackPosition;

        int spinningMarioImage = 22;
        Image[] marioImages = new Image[23];

        int spinningBowserImage = 22;
        Image[] bowserImages = new Image[23];

        int spinningKoopaImage = 22;
        Image[] koopaImages = new Image[23];

        int spinningDonkeyImage = 22;
        Image[] donkeyImages = new Image[23];

        int spinningYoshiImage = 22;
        Image[] yoshiImages = new Image[23];

        int spinningToadImage = 22;
        Image[] toadImages = new Image[23];

        int spinningLuigiImage = 22;
        Image[] luigiImages = new Image[23];

        int spinningPeachImage = 22;
        Image[] peachImages = new Image[23];

        Image[] playerImage = new Image[13];

        string characterHovered;

        public Form1()
        {
            InitializeComponent();
            player = new Rectangle((this.Width / 2) - playerWidth / 2, this.Height - playerHeight * 3 / 2, playerWidth, playerHeight);

            marioImages[13] = Properties.Resources.mario__7_;
            marioImages[14] = Properties.Resources.mario__6_;
            marioImages[15] = Properties.Resources.mario__5_;
            marioImages[16] = Properties.Resources.mario__4_1;
            marioImages[17] = Properties.Resources.mario__3_;
            marioImages[18] = Properties.Resources.mario__1_;
            marioImages[19] = Properties.Resources.mario__24_;
            marioImages[20] = Properties.Resources.mario__23_;
            marioImages[21] = Properties.Resources.mario__11_;
            marioImages[22] = Properties.Resources.mario__10_;

            marioImages[12]= Properties.Resources.mario__12_;
            marioImages[11] = Properties.Resources.mario__13_;
            marioImages[10] = Properties.Resources.mario__14_;
            marioImages[9] = Properties.Resources.mario__15_;
            marioImages[8] = Properties.Resources.mario__20_;
            marioImages[7] = Properties.Resources.mario__2_;
            marioImages[6] = Properties.Resources.mario__21_;
            marioImages[5] = Properties.Resources.mario__4_;
            marioImages[4] = Properties.Resources.mario__39_;
            marioImages[3] = Properties.Resources.mario__16_;
            marioImages[2] = Properties.Resources.mario__17_;
            marioImages[1] = Properties.Resources.mario__18_;
            marioImages[0] = Properties.Resources.mario__19_;

            bowserImages[13] = Properties.Resources.bowser__18_;
            bowserImages[14] = Properties.Resources.bowser__17_;
            bowserImages[15] = Properties.Resources.bowser__16_;
            bowserImages[16] = Properties.Resources.bowser__15_;
            bowserImages[17] = Properties.Resources.bowser__14_;
            bowserImages[18] = Properties.Resources.bowser__12_;
            bowserImages[19] = Properties.Resources.bowser__23_;
            bowserImages[20] = Properties.Resources.bowser__22_;
            bowserImages[21] = Properties.Resources.bowser__21_;
            bowserImages[22] = Properties.Resources.bowser__20_;

            bowserImages[12]= Properties.Resources.bowser__2_;
            bowserImages[11] = Properties.Resources.bowser__2_;
            bowserImages[10] = Properties.Resources.bowser__3_;
            bowserImages[9] = Properties.Resources.bowser__4_;
            bowserImages[8] = Properties.Resources.bowser__5_;
            bowserImages[7] = Properties.Resources.bowser__6_;
            bowserImages[6] = Properties.Resources.bowser__1_;
            bowserImages[5] = Properties.Resources.bowser__7_;
            bowserImages[4] = Properties.Resources.bowser__8_;
            bowserImages[3] = Properties.Resources.bowser__9_;
            bowserImages[2] = Properties.Resources.bowser__10_;
            bowserImages[1] = Properties.Resources.bowser__11_;
            bowserImages[0] = Properties.Resources.bowser__11_;

            koopaImages[13] = Properties.Resources.koopa__15_;
            koopaImages[14] = Properties.Resources.koopa__14_;
            koopaImages[15] = Properties.Resources.koopa__13_;
            koopaImages[16] = Properties.Resources.koopa__12_;
            koopaImages[17] = Properties.Resources.koopa__23_;
            koopaImages[18] = Properties.Resources.koopa__22_;
            koopaImages[19] = Properties.Resources.koopa__21_;
            koopaImages[20] = Properties.Resources.koopa__20_;
            koopaImages[21] = Properties.Resources.koopa__19_;
            koopaImages[22] = Properties.Resources.koopa__18_;

            koopaImages[12]= Properties.Resources.koopa__2_;
            koopaImages[11] = Properties.Resources.koopa__2_;
            koopaImages[10] = Properties.Resources.koopa__1_;
            koopaImages[9] = Properties.Resources.koopa__11_;
            koopaImages[8] = Properties.Resources.koopa__10_;
            koopaImages[7] = Properties.Resources.koopa__9_;
            koopaImages[6] = Properties.Resources.koopa__3_;
            koopaImages[5] = Properties.Resources.koopa__4_;
            koopaImages[4] = Properties.Resources.koopa__5_;
            koopaImages[3] = Properties.Resources.koopa__6_;
            koopaImages[2] = Properties.Resources.koopa__7_;
            koopaImages[1] = Properties.Resources.koopa__8_;
            koopaImages[0] = Properties.Resources.koopa__8_;

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

            peachImages[13] = Properties.Resources.peach__18_;
            peachImages[14] = Properties.Resources.peach__17_;
            peachImages[15] = Properties.Resources.peach__16_;
            peachImages[16] = Properties.Resources.peach__15_;
            peachImages[17] = Properties.Resources.peach__14_;
            peachImages[18] = Properties.Resources.peach__12_;
            peachImages[19] = Properties.Resources.peach__23_;
            peachImages[20] = Properties.Resources.peach__22_;
            peachImages[21] = Properties.Resources.peach__21_;
            peachImages[22] = Properties.Resources.peach__20_;

            peachImages[12]= Properties.Resources.peach__2_;
            peachImages[11] = Properties.Resources.peach__2_;
            peachImages[10] = Properties.Resources.peach__3_;
            peachImages[9] = Properties.Resources.peach__4_;
            peachImages[8] = Properties.Resources.peach__5_;
            peachImages[7] = Properties.Resources.peach__6_;
            peachImages[6] = Properties.Resources.peach__7_;
            peachImages[5] = Properties.Resources.peach__8_;
            peachImages[4] = Properties.Resources.peach__9_;
            peachImages[3] = Properties.Resources.peach__10_;
            peachImages[2] = Properties.Resources.peach__11_;
            peachImages[1] = Properties.Resources.peach__1_;
            peachImages[0] = Properties.Resources.peach__1_;
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
            if (wDown == true || driveSpeed > 0)
            {
                MoveForward();

            }
            if (sDown == true)
            {
                MoveBackwards();
            }
            if (aDown == true && driveSpeed > 0)
            {
                MoveSideways(turningAcceleration);
            }
            if (dDown == true && driveSpeed > 0)
            {
                MoveSideways(-turningAcceleration);
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
                bowserButton.Image = bowserImages[spinningBowserImage];
                marioButton.Image = marioImages[spinningMarioImage];
                koopaButton.Image = koopaImages[spinningKoopaImage];
                peachButton.Image = peachImages[spinningPeachImage];
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
            if (wDown == true && driveSpeed < maxAcceleration)
            {
                driveSpeed += driveAcceleration;
            }
            else if (wDown == false && driveSpeed > 0)
            {
                driveSpeed -= driveAcceleration;
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
            for (int i = 0; i <= 12; i++)
            {
                playerImage[i] = marioImages[i];
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

        private void bowserButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 12; i++)
            {
                playerImage[i] = bowserImages[i];
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

        private void peachButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 12; i++)
            {
                playerImage[i] = peachImages[i];
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

        private void koopaButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 12; i++)
            {
                playerImage[i] = koopaImages[i];
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

        private void marioButton_MouseHover(object sender, EventArgs e)
        {
            hoverTimer.Enabled = true;
            characterHovered = "mario";
        }

        private void marioButton_MouseLeave(object sender, EventArgs e)
        {
            hoverTimer.Enabled = false;
            spinningMarioImage = 22;
            marioButton.Refresh();
        }

        private void peachButton_MouseHover(object sender, EventArgs e)
        {
            hoverTimer.Enabled = true;
            characterHovered = "peach";
        }

        private void peachButton_MouseLeave(object sender, EventArgs e)
        {
            hoverTimer.Enabled = false;
            spinningPeachImage = 22;
            peachButton.Refresh();
        }

        private void bowserButton_MouseHover(object sender, EventArgs e)
        {
            hoverTimer.Enabled = true;
            characterHovered = "bowser";
        }

        private void bowserButton_MouseLeave(object sender, EventArgs e)
        {
            hoverTimer.Enabled = false;
            spinningBowserImage = 22;
            bowserButton.Refresh();
        }

        private void koopaButton_MouseHover(object sender, EventArgs e)
        {
            hoverTimer.Enabled = true;
            characterHovered = "koopa";
        }

        private void koopaButton_MouseLeave(object sender, EventArgs e)
        {
            hoverTimer.Enabled = false;
            spinningKoopaImage = 22;
            koopaButton.Refresh();
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
                case "mario":
                    if (spinningMarioImage == 22)
                    {
                        spinningMarioImage = 0;
                    }
                    else
                    {
                        spinningMarioImage++;
                    }
                    marioButton.Refresh();
                    break;
                case "bowser":
                    if (spinningBowserImage == 22)
                    {
                        spinningBowserImage = 0;
                    }
                    else
                    {
                        spinningBowserImage++;
                    }
                    bowserButton.Refresh();
                    break;
                case "koopa":
                    if (spinningKoopaImage == 22)
                    {
                        spinningKoopaImage = 0;
                    }
                    else
                    {
                        spinningKoopaImage++;
                    }
                    koopaButton.Refresh();
                    break;
                case "peach":
                    if (spinningPeachImage == 22)
                    {
                        spinningPeachImage = 0;
                    }
                    else
                    {
                        spinningPeachImage++;
                    }
                    peachButton.Refresh();
                    break;
            }
        }

    }
}
