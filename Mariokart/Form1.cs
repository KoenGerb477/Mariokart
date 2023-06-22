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
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Media;
using System.IO;

namespace Mariokart
{
    public partial class Form1 : Form
    {
        int engineTimer = 25;

        List<Point> trackPoints = new List<Point>();
        List<PointF> roadPoints = new List<PointF>();

        PointF[] startLine = new PointF[4];

        string state = "main menu";

        Rectangle player = new Rectangle();

        Rectangle grass = new Rectangle();

        Rectangle playerTracker = new Rectangle();

        int counter = 0;

        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        TextureBrush grassBrush;
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush grayBrush = new SolidBrush(Color.Gray);
        SolidBrush darkGrayBrush = new SolidBrush(Color.DarkGray);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        TextureBrush roadBrush;

        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;

        const int playerWidth = 140;
        const int playerHeight = 150;
        int horizonHeight;

        float driveSpeed = 0;
        const float driveAcceleration = 0.25f;
        float maxSpeed = 20;

        float turnDirection = 0;
        const float turningAcceleration = 0.5f;
        const int maxTurnSpeed = 24;

        bool startLineActive = true;
        bool turnRight = false;
        bool straightenOutFromRight = false;
        bool turnLeft = false;
        bool straightenOutFromLeft = false;

        float distanceDriven = 2;
        float totalDistance = 1;
        int distancePerW = 4;

        List<float>npcDistance = new List<float>();
        List<string>npcName =  new List<string>();
        List<int> npcSpeed = new List<int>();
        List<int> npcX = new List<int>();
        List<int> rightOrLeftMovement = new List<int>();
        List<int> npcBaseLineSpeed = new List<int>();
        List<string> npcToDraw = new List<string>();
        List<Rectangle> npcDrawPosition= new List<Rectangle>();

        List<string> leaderboard = new List<string>();
        List<string> time = new List<string>();

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

        string characterSelected;

        Stopwatch playerStopwatch = new Stopwatch();

        Random randGen =   new Random();

        int tickCounter = 0;

        List <Rectangle> powerUpCubes = new List<Rectangle>();

        System.Windows.Media.MediaPlayer coconutMall = new System.Windows.Media.MediaPlayer();
        System.Windows.Media.MediaPlayer finalLap = new System.Windows.Media.MediaPlayer();
        System.Windows.Media.MediaPlayer mainMenu = new System.Windows.Media.MediaPlayer();
        System.Windows.Media.MediaPlayer results = new System.Windows.Media.MediaPlayer();

        System.Windows.Media.MediaPlayer engineSound = new System.Windows.Media.MediaPlayer(); 
        System.Windows.Media.MediaPlayer thudSound = new System.Windows.Media.MediaPlayer(); 
        System.Windows.Media.MediaPlayer clickSound = new System.Windows.Media.MediaPlayer();

        public Form1()
        {
            InitializeComponent();
            horizonHeight = this.Height/6;

            coconutMall.Open(new Uri(Application.StartupPath + "/Resources/Coconut Mall.mp3"));
            coconutMall.MediaEnded += new EventHandler(coconutMallMedia_MediaEnded);

            mainMenu.Open(new Uri(Application.StartupPath + "/Resources/Main Menu.mp3"));
            mainMenu.MediaEnded += new EventHandler(mainMenuMedia_MediaEnded);
            mainMenu.Play(); 
            
            finalLap.Open(new Uri(Application.StartupPath + "/Resources/Coconut Mall (Final Lap).mp3"));
            finalLap.MediaEnded += new EventHandler(finalLapMedia_MediaEnded);

            results.Open(new Uri(Application.StartupPath + "/Resources/Victory & Winning Results.mp3"));
            results.MediaEnded += new EventHandler(resultsMedia_MediaEnded);

            engineSound.Open(new Uri(Application.StartupPath + "/Resources/170248__enduringautomotive__main-engine-[AudioTrimmer.com].wav"));
            thudSound.Open(new Uri(Application.StartupPath + "/Resources/thud1.wav"));
            clickSound.Open(new Uri(Application.StartupPath + "/Resources/menuselect.wav"));

            player = new Rectangle((this.Width / 2) - playerWidth / 2, this.Height - playerHeight * 3 / 2, playerWidth, playerHeight);

            grass = new Rectangle(0 - this.Width, 0 - this.Height, this.Width * 2, this.Height *2);

            playerTracker = new Rectangle(this.Width - 50, 30, 20, this.Height - 60);

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

            grassBrush = new TextureBrush(Properties.Resources.grassTextureFr);
            roadBrush = new TextureBrush(Properties.Resources.RoadTexture);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
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
            if ((wDown == true || sDown == true) && engineTimer < 0)
            {
                engineTimer = 20;
                engineSound.Play();
            }
            else if (engineTimer < 5)
            {
                engineTimer--;
                engineSound.Stop();
            }
            else
            {
                engineTimer--;
            }

            //move player
            if (wDown == true || driveSpeed > 0)
            {
                MoveForward();
            }
            if (sDown == true)
            {
                MoveBackwards();
            }
            if (wDown == true && aDown == dDown)
            {          
                if (turnDirection > 0)
                {
                    turnDirection -= turningAcceleration * 2;
                }
                else if (turnDirection < 0)
                {
                    turnDirection += turningAcceleration * 2;
                }

                if (turnDirection > 0 && driveSpeed > 0)
                {
                    MoveSideways(turningAcceleration);
                }
                if (turnDirection < 0 && driveSpeed > 0)
                {
                    MoveSideways(-turningAcceleration);
                }
            }
            else
            {
                if (aDown == true && driveSpeed > 0)
                {
                    MoveSideways(turningAcceleration);
                }
                if (dDown == true && driveSpeed > 0)
                {
                    MoveSideways(-turningAcceleration);
                }
            }

            //if on grass go slower
            PointF pointL = new PointF (0,0);
            PointF pointR = new PointF(0,0);
            int c = 0;
            foreach (PointF roadPoint in roadPoints)
            {
                if (roadPoint.Y == (playerHeight + player.Y))
                {
                    if (c == 0)
                    {
                        pointL = roadPoint;
                        c++;
                    }
                    else
                    {
                        pointR = roadPoint;
                    }
                }
            }

            if (pointL.X > player.X || pointR.X < player.X + playerWidth)
            {
                maxSpeed = 10;
                distancePerW = 1;   
            }
            else
            {
                maxSpeed = 20;
                distancePerW = 2;    
            }
            

            //track sequence
            if (distanceDriven % 2 != 0 && distancePerW == 2)
            {
                distanceDriven--;
            }
            switch (distanceDriven)
            {
                case 300:
                    turnRight = true;
                    break;
                case 600:
                    straightenOutFromRight = true;
                    turnRight = false;
                    MakePowerUps();
                    break;
                case 900:
                    turnLeft = true;
                    driftAmount = -0.1f;
                    straightenOutFromRight = false;
                    break;
                case 1200:
                    straightenOutFromLeft = true;
                    turnLeft = false;
                    MakePowerUps();
                    break;
                case 1500:
                    turnLeft = true;
                    driftAmount = -0.1f;
                    straightenOutFromLeft = false;
                    break;
                case 1800:
                    straightenOutFromLeft = true;
                    turnLeft = false;
                    MakePowerUps();
                    break;
                case 2100:
                    turnRight = true;
                    driftAmount = 0.1f;
                    straightenOutFromLeft = false;
                    break;
                case 2400:
                    straightenOutFromRight = true;
                    turnRight = false;
                    MakePowerUps();
                    break;
                case 2700:
                    turnLeft = true;
                    driftAmount = -0.1f;
                    straightenOutFromLeft = false;
                    break;
                case 3000:
                    straightenOutFromLeft = true;
                    turnLeft = false;
                    MakePowerUps();
                    break;
                case 3300:
                    turnRight = true;
                    driftAmount = 0.1f;
                    straightenOutFromLeft = false;
                    break;
                case 3600:
                    straightenOutFromRight = true;
                    turnRight = false;
                    MakePowerUps();
                    break;
                case 3900:
                    turnRight = true;
                    driftAmount = 0.1f;
                    straightenOutFromLeft = false;
                    break;
                case 4200:
                    straightenOutFromRight = true;
                    turnRight = false;
                    break;
                case 4500:
                    distanceDriven = 0;
                    MakeStartLine();
                    while (startLine[0].Y > horizonHeight)
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
                    startLineActive = true;
                    counter++;
                    break;
                default: break;
            }

            if (counter == 0)
            {
                totalDistance = distanceDriven;
            }
            else if (counter == 1)
            {
                totalDistance = distanceDriven + 4500;
            }
            else if (counter == 2)
            {
                totalDistance = distanceDriven + 9000;
                finalLap.Play();
                coconutMall.Stop();
            }
            //3 laps and then end game
            else
            {
                finalLap.Stop();
                results.Play();

                leaderboard.Add(characterSelected);
                
                playerStopwatch.Stop();
                time.Add(playerStopwatch.Elapsed.ToString(@"m\:ss"));
                Int64 playerTime = playerStopwatch.ElapsedMilliseconds;

                for (int i = 0; i < npcName.Count; i++)
                {
                    if (npcName[i] == "done")
                    {
                        npcDistance.RemoveAt(i);
                        npcSpeed.RemoveAt(i);
                        npcName.RemoveAt(i);
                        i--;
                    }
                }
                for (int i = 0; i < npcName.Count; i++)
                {
                    string fastestNPC = "";
                    int fastestTime = 0;
                    int rememberJ = 0;
                    for (int j = 0; j < npcDistance.Count; j++)
                    {
                        if (Convert.ToInt32(playerTime) + Convert.ToInt32(13500 - npcDistance[j])/npcSpeed[j] > fastestTime)
                        {
                            fastestTime = Convert.ToInt32(playerTime) + Convert.ToInt32(13500 - npcDistance[j])/npcSpeed[j];
                            fastestNPC = npcName[j];
                            rememberJ = j;
                        }
                    }
                    leaderboard.Add(fastestNPC);
                    TimeSpan timeSpan = TimeSpan.FromMilliseconds(fastestTime);
                    time.Add(timeSpan.ToString(@"m\:ss"));
                    npcDistance.RemoveAt(rememberJ); 
                    npcName.RemoveAt(rememberJ);
                    npcSpeed.RemoveAt(rememberJ);
                    i--;
                }

                state = "leaderboard";
                playerStopwatch.Stop();
                gameTimer.Enabled = false;
            }

            //keep track of NPC positions
            for (int i = 0; i < npcName.Count; i++)
            {
                npcDistance[i] += npcSpeed[i];

                if (npcDistance[i] - totalDistance > -50 && npcDistance[i] - totalDistance < 200)
                {
                    npcToDraw.Add(npcName[i]);

                    int y = Convert.ToInt32(this.Height - ((this.Height-playerHeight)*((npcDistance[i]-totalDistance)/200)));
                    int size = Convert.ToInt32((y + playerHeight)/((player.Y - horizonHeight)/(playerHeight/2)));

                    pointL = new PointF(0, 0);
                    pointR = new PointF(0, 0);
                    c = 0;
                    foreach (PointF roadPoint in roadPoints)
                    {
                        if (Convert.ToInt32(roadPoint.Y) == y)
                        {
                            if (c == 0)
                            {
                                pointL = roadPoint;
                                c++;
                            }
                            else
                            {
                                pointR = roadPoint;
                            }
                        }
                    }

                    int random;
                    if (rightOrLeftMovement[i] == -1)
                    {
                        random = randGen.Next(0, 6);

                        if (random + npcX[i] + ((pointL.X + pointR.X)/2) > pointR.X - size)
                        {
                            random = -random;
                            rightOrLeftMovement[i] *= -1;

                            npcX[i] = Convert.ToInt32(pointR.X - size) - Convert.ToInt32((pointL.X + pointR.X)/2);
                        }
                    }
                    else
                    {
                        random = randGen.Next(-5, 1);

                        if (random + npcX[i] + ((pointL.X + pointR.X)/2)< pointL.X)
                        {
                            random = -random;
                            rightOrLeftMovement[i] *= -1;

                            npcX[i] = - (Convert.ToInt32((pointL.X + pointR.X)/2) - Convert.ToInt32(pointL.X));
                        }
                    }

                    npcX[i] += random;

                    int x = Convert.ToInt32(pointL.X + pointR.X)/2 + npcX[i];

                    Rectangle npcPosition = new Rectangle(x, y, size, size);
                    npcDrawPosition.Add(npcPosition);
                }

                //make random npc speed
                if (tickCounter % 100 == 0)
                {
                    npcSpeed[i] = randGen.Next(npcBaseLineSpeed[i] - 3, npcBaseLineSpeed[i] +3);
                    if (npcSpeed[i] < 1)
                    {
                        npcSpeed[i] = 1;
                    }
                }
                if ((npcDistance[i] - totalDistance) % 100 == 0 && npcDistance[i] - totalDistance > 0)
                {
                    npcBaseLineSpeed[i]--;
                }
                else if ((npcDistance[i] - totalDistance) % 300 == 0 && npcDistance[i] - totalDistance < 0)
                {
                    npcBaseLineSpeed[i]++;
                }

                //when npc finishes race mark them as done and record time
                if (npcDistance[i] > 13500 && npcName[i] != "done")
                {
                    leaderboard.Add(npcName[i]);
                    time.Add(playerStopwatch.Elapsed.ToString(@"m\:ss"));
                    npcName[i] = "done";
                }
            }

            //if collide with npc slow down
            for (int i = 0; i < npcDrawPosition.Count; i++)
            {
                if (npcDrawPosition[i].IntersectsWith(player))
                {
                    thudSound.Play();

                    if (npcDrawPosition[i].Y < player.Y + playerHeight/2)                    {
                        driveSpeed = 0;
                        distancePerW = 0;
                    }
                    else if (npcDrawPosition[i].Y > player.Y - playerHeight * 3/2) 
                    {
                        npcSpeed[i] = 0;
                    }
                    if (npcDrawPosition[i].X - npcDrawPosition[i].Width / 2 < player.X && npcDrawPosition[i].Y < player.Y + playerHeight/4 && npcDrawPosition[i].Y > player.Y + playerHeight* 3/4)
                    {
                        Rectangle temp = npcDrawPosition[i];
                        temp.X = player.X - player.Width;
                        npcDrawPosition[i] = temp;

                        if (turnDirection > -maxTurnSpeed)
                        {
                            turnDirection--;
                        }
                    }
                    else if (npcDrawPosition[i].X + npcDrawPosition[i].Width / 2 > player.X && npcDrawPosition[i].Y < player.Y + playerHeight/4 && npcDrawPosition[i].Y > player.Y + playerHeight* 3/4)
                    {
                        Rectangle temp = npcDrawPosition[i];
                        temp.X = player.X + player.Width;
                        npcDrawPosition[i] = temp;

                        if (turnDirection < maxTurnSpeed)
                        {
                            turnDirection++;
                        }
                    }
                }
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (state == "main menu")
            {
                e.Graphics.DrawImage(Properties.Resources.MarioKartBackgroundImage, 0, 0, Width, Height);

                titleLabel.Visible = true;
                titleLabel.Text = "Racing Karts and Also Mario";
                nextButton.Visible = false;
                nextButton.Enabled = false;

                leaderboardLabel.Visible = false;
                timeLabel.Visible = false;

                playButton.Visible = true;
                playButton.Enabled = true;
                exitButton.Visible = true;
                exitButton.Enabled = true;
            }
            else if (state == "play game")
            {
                titleLabel.Visible = false;

                e.Graphics.FillRectangle(greenBrush, grass);

                PointF[] roadArray = new PointF[roadPoints.Count];
                for (int i = 0; i < roadPoints.Count; i++)
                {
                    roadArray[i] = roadPoints[i];
                }
                e.Graphics.FillPolygon(grayBrush, roadArray);

                if (startLineActive == true)
                {
                    e.Graphics.FillPolygon(blackBrush, startLine);
                }

                e.Graphics.DrawImage(Properties.Resources.skyImage, 0, 0, this.Width*2, horizonHeight);

                if (npcToDraw.Count > 0)
                {
                    for (int i = 0; i < npcToDraw.Count; i++)
                    {
                        int furthestDistance = this.Height;
                        int rememberJ = 0;

                        for (int j = 0; j < npcDrawPosition.Count; j++)
                        {
                            if (npcDrawPosition[j].Y < furthestDistance)
                            {
                                furthestDistance = npcDrawPosition[j].Y;
                                rememberJ = j;
                            }
                        }

                        switch (npcToDraw[rememberJ])
                        {
                            case "bowser":
                                e.Graphics.DrawImage(bowserImages[6], npcDrawPosition[rememberJ]);
                                break;
                            case "mario":
                                e.Graphics.DrawImage(marioImages[6], npcDrawPosition[rememberJ]);
                                break;
                            case "luigi":
                                e.Graphics.DrawImage(luigiImages[6], npcDrawPosition[rememberJ]);
                                break;
                            case "toad":
                                e.Graphics.DrawImage(toadImages[6], npcDrawPosition[rememberJ]);
                                break;
                            case "donkey":
                                e.Graphics.DrawImage(donkeyImages[6], npcDrawPosition[rememberJ]);
                                break;
                            case "koopa":
                                e.Graphics.DrawImage(koopaImages[6], npcDrawPosition[rememberJ]);
                                break;
                            case "peach":
                                e.Graphics.DrawImage(peachImages[6], npcDrawPosition[rememberJ]);
                                break;
                            case "yoshi":
                                e.Graphics.DrawImage(yoshiImages[6], npcDrawPosition[rememberJ]);
                                break;
                        }
                        npcToDraw.RemoveAt(rememberJ);
                        npcDrawPosition.RemoveAt(rememberJ);
                        npcToDraw.Add(null);
                        npcDrawPosition.Add(new Rectangle (0, this.Height, 0, 0));
                    }
                }
                npcToDraw.Clear();
                npcDrawPosition.Clear();

                e.Graphics.DrawImage(playerImage[Convert.ToInt16((turnDirection / 4) + 6)], player);

                e.Graphics.FillRectangle(darkGrayBrush, playerTracker);
                
                for (int i = 0; i < npcName.Count; i++)
                {
                    switch (npcName[i])
                    {
                        case "bowser":
                            e.Graphics.DrawImage(bowserImages[18], playerTracker.X, (playerTracker.Y + playerTracker.Height) - (npcDistance[i]/4500) * (playerTracker.Height/3), 20, 20);
                            break;
                        case "mario":
                            e.Graphics.DrawImage(marioImages[18], playerTracker.X, (playerTracker.Y + playerTracker.Height) - (npcDistance[i]/4500) * (playerTracker.Height/3), 20, 20);
                            break;
                        case "luigi":
                            e.Graphics.DrawImage(luigiImages[18], playerTracker.X, (playerTracker.Y + playerTracker.Height) - (npcDistance[i]/4500) * (playerTracker.Height/3), 20, 20);
                            break;
                        case "toad":
                            e.Graphics.DrawImage(toadImages[18], playerTracker.X, (playerTracker.Y + playerTracker.Height) - (npcDistance[i]/4500) * (playerTracker.Height/3), 20, 20);
                            break;
                        case "donkey":
                            e.Graphics.DrawImage(donkeyImages[18], playerTracker.X, (playerTracker.Y + playerTracker.Height) - (npcDistance[i]/4500) * (playerTracker.Height/3), 20, 20);
                            break;
                        case "koopa":
                            e.Graphics.DrawImage(koopaImages[18], playerTracker.X, (playerTracker.Y + playerTracker.Height) - (npcDistance[i]/4500) * (playerTracker.Height/3), 20, 20);
                            break;
                        case "peach":
                            e.Graphics.DrawImage(peachImages[18], playerTracker.X, (playerTracker.Y + playerTracker.Height) - (npcDistance[i]/4500) * (playerTracker.Height/3), 20, 20);
                            break;
                        case "yoshi":
                            e.Graphics.DrawImage(yoshiImages[18], playerTracker.X, (playerTracker.Y + playerTracker.Height) - (npcDistance[i]/4500) * (playerTracker.Height/3), 20, 20);
                            break;
                    }
                }

                switch (characterSelected)
                {
                    case "bowser":
                        e.Graphics.DrawImage(bowserImages[18], playerTracker.X, (playerTracker.Y + playerTracker.Height) - (totalDistance/4500) * (playerTracker.Height/3), 20, 20);
                        break;
                    case "mario":
                        e.Graphics.DrawImage(marioImages[18], playerTracker.X, (playerTracker.Y + playerTracker.Height) - (totalDistance/4500) * (playerTracker.Height/3), 20, 20);
                        break;
                    case "luigi":
                        e.Graphics.DrawImage(luigiImages[18], playerTracker.X, (playerTracker.Y + playerTracker.Height) - (totalDistance/4500) * (playerTracker.Height/3), 20, 20);
                        break;
                    case "toad":
                        e.Graphics.DrawImage(toadImages[18], playerTracker.X, (playerTracker.Y + playerTracker.Height) - (totalDistance/4500) * (playerTracker.Height/3), 20, 20);
                        break;
                    case "donkey":
                        e.Graphics.DrawImage(donkeyImages[18], playerTracker.X, (playerTracker.Y + playerTracker.Height) - (totalDistance/4500) * (playerTracker.Height/3), 20, 20);
                        break;
                    case "koopa":
                        e.Graphics.DrawImage(koopaImages[18], playerTracker.X, (playerTracker.Y + playerTracker.Height) - (totalDistance/4500) * (playerTracker.Height/3), 20, 20);
                        break;
                    case "peach":
                        e.Graphics.DrawImage(peachImages[18], playerTracker.X, (playerTracker.Y + playerTracker.Height) - (totalDistance/4500) * (playerTracker.Height/3), 20, 20);
                        break;
                    case "yoshi":
                        e.Graphics.DrawImage(yoshiImages[18], playerTracker.X, (playerTracker.Y + playerTracker.Height) - (totalDistance/4500) * (playerTracker.Height/3), 20, 20);
                        break;
                }
            }
            else if (state == "select character")
            {
                titleLabel.Visible = true;
                titleLabel.Text = "Select Your Character";

                playButton.Visible = false;
                playButton.Enabled = false;
                exitButton.Visible = false;
                exitButton.Enabled = false;

                e.Graphics.DrawImage(Properties.Resources.MarioKartBackgroundImage, 0, 0, Width, Height);

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
            else if (state == "leaderboard")
            {
                titleLabel.Visible = true;
                titleLabel.Text = "Standings";

                leaderboardLabel.Visible = true;
                timeLabel.Visible = true;

                e.Graphics.DrawImage(Properties.Resources.MarioKartBackgroundImage, 0, 0, Width, Height);

                nextButton.Visible = true;
                nextButton.Enabled = true;

                int position = 1;
                string characterName = "";
                for (int i = 0; i < leaderboard.Count; i++)
                {
                    switch (leaderboard[i])
                    {
                        case "bowser":
                            characterName = "Bowser";
                            break;
                        case "mario":
                            characterName = "Mario";
                            break;
                        case "luigi":
                            characterName = "Luigi";
                            break;
                        case "toad":
                            characterName = "Toad";
                            break;
                        case "donkey":
                            characterName = "Donkey Kong";
                            break;
                        case "koopa":
                            characterName = "Koopa Troopa";
                            break;
                        case "peach":
                            characterName = "Princess Peach";
                            break;
                        case "yoshi":
                            characterName = "Yoshi";
                            break;
                    }

                    leaderboardLabel.Text += $"{position}. {characterName}\n";
                    timeLabel.Text += $"{time[i]}\n";
                    position++;
                }
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
        }

        public void MoveForward()
        {
            
            distanceDriven+=distancePerW;

            if (wDown == true && driveSpeed < maxSpeed)
            {
                driveSpeed += driveAcceleration;
            }
            else if (wDown == true && driveSpeed > maxSpeed)
            {
                driveSpeed -= driveAcceleration;
            }
            else if (wDown == false && driveSpeed > 0)
            {
                driveSpeed -= driveAcceleration;
            }

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

                if (startLine[1].Y > this.Height)
                {
                    startLineActive = false;
                }
            }

            if (turnRight == true)
            {
                if (roadPoints[roadPoints.Count/2].X <= this.Width * 2)
                {
                    float moveAmount = 0.01f;
                    for (int i = 0; i <= roadPoints.Count / 2; i++)
                    {
                        PointF point = roadPoints[i];
                        point.X += moveAmount;
                        roadPoints[i] = point;

                        moveAmount *= 1.01f;
                    }

                    moveAmount = 0.01f;
                    for (int i = roadPoints.Count - 1; i >= roadPoints.Count/2; i--)
                    {
                        PointF point = roadPoints[i];
                        point.X += moveAmount;
                        roadPoints[i] = point;

                        moveAmount *= 1.01f;
                    }
                    if (driftAmount <= 10)
                    {
                        driftAmount *= 1.25f;
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
                    float moveAmount = -0.01f;

                    for (int i = 0; i <= roadPoints.Count / 2; i++)
                    {
                        PointF point = roadPoints[i];
                        point.X += moveAmount;
                        roadPoints[i] = point;

                        moveAmount *= 1.01f;
                    }

                    moveAmount = -0.01f;
                    for (int i = roadPoints.Count - 1; i >= roadPoints.Count/2; i--)
                    {
                        PointF point = roadPoints[i];
                        point.X += moveAmount;
                        roadPoints[i] = point;

                        moveAmount *= 1.01f;
                    }

                    if (driftAmount >= -10)
                    {
                        driftAmount *= 1.25f;
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
        }

        private void marioButton_Click(object sender, EventArgs e)
        {
            clickSound.Play();

            for (int i = 0; i <= 12; i++)
            {
                playerImage[i] = marioImages[i];
            }
            characterSelected = "mario";

            StartTheGame();
        }

        private void bowserButton_Click(object sender, EventArgs e)
        {
            clickSound.Play();

            for (int i = 0; i <= 12; i++)
            {
                playerImage[i] = bowserImages[i];
            }
            characterSelected = "bowser";

            StartTheGame();
        }

        private void peachButton_Click(object sender, EventArgs e)
        {
            clickSound.Play();

            for (int i = 0; i <= 12; i++)
            {
                playerImage[i] = peachImages[i];
            }
            characterSelected = "peach";

            StartTheGame();
        }

        private void koopaButton_Click(object sender, EventArgs e)
        {
            clickSound.Play();

            for (int i = 0; i <= 12; i++)
            {
                playerImage[i] = koopaImages[i];
            }
            characterSelected = "koopa";

            StartTheGame();
        }

        private void luigiButton_Click(object sender, EventArgs e)
        {
            clickSound.Play();

            for (int i = 0; i <= 12; i++)
            {
                playerImage[i] = luigiImages[i];
            }
            characterSelected = "luigi";

            StartTheGame();
        }

        private void yoshiButton_Click(object sender, EventArgs e)
        {
            clickSound.Play();

            for (int i = 0; i <= 12; i++)
            {
                playerImage[i] = yoshiImages[i];
            }
            characterSelected = "yoshi";

            StartTheGame();
        }

        private void donkeyButton_Click(object sender, EventArgs e)
        {
            clickSound.Play();

            for (int i = 0; i <= 12; i++)
            {
                playerImage[i] = donkeyImages[i];
            }
            characterSelected = "donkey";

            StartTheGame();
        }

        private void toadButton_Click(object sender, EventArgs e)
        {
            clickSound.Play();

            for (int i = 0; i <= 12; i++)
            {
                playerImage[i] = toadImages[i];
            }
            characterSelected = "toad";

            StartTheGame();
        }

        private void toadButton_MouseHover(object sender, EventArgs e)
        {
            hoverTimer.Enabled = true;
            characterSelected = "toad";
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
            characterSelected = "luigi";
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
            characterSelected = "donkey";
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
            characterSelected = "yoshi";
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
            characterSelected = "mario";
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
            characterSelected = "peach";
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
            characterSelected = "bowser";
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
            characterSelected = "koopa";
        }

        private void koopaButton_MouseLeave(object sender, EventArgs e)
        {
            hoverTimer.Enabled = false;
            spinningKoopaImage = 22;
            koopaButton.Refresh();
        }

        private void hoverTimer_Tick(object sender, EventArgs e)
        {
            switch (characterSelected)
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

        public void StartTheGame()
        {
            coconutMall.Play();
            mainMenu.Stop();

            gameTimer.Enabled = true;

            trackPoints.Clear();
            roadPoints.Clear();

            counter = 0;

            state = "play game";

            driveSpeed = 0;
            turnDirection = 0;

            startLineActive = true;
            turnRight = false;
            straightenOutFromRight = false;
            turnLeft = false;
            straightenOutFromLeft = false;

            distanceDriven = 2;
            totalDistance = 1;

            perspectiveAngle = 0.5f;

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

            powerUpCubes.Clear();
            npcDistance.Clear();
            npcName.Clear();
            npcSpeed.Clear();
            npcToDraw.Clear();
            npcDrawPosition.Clear();
            npcX.Clear();

            for (int i = 0; i < 8; i++)
            {
                //set distances to 0
                npcDistance.Add(1);
            }
            //choose random characters for npc's
            npcName.Add("bowser");
            npcName.Add("mario");
            npcName.Add("luigi");
            npcName.Add("toad");
            npcName.Add("yoshi");
            npcName.Add("koopa");
            npcName.Add("peach");
            npcName.Add("donkey");

            for (int j = 0; j < npcName.Count; j++)
            {
                if (npcName[j] == characterSelected)
                {
                    npcName.RemoveAt(j);
                    npcDistance.RemoveAt(j);
                }
            }
            for (int i = 0; i < npcName.Count; i++)
            {
                npcBaseLineSpeed.Add(randGen.Next(1, 5));
                npcSpeed.Add(npcBaseLineSpeed[i]);
            }
            int c = 0;
            for (int i = 0; i < npcName.Count; i++)
            {
                if (c % 2 == 0)
                {
                    npcX.Add(-250);
                    rightOrLeftMovement.Add(-1);
                }
                else
                {
                    npcX.Add(200);
                    rightOrLeftMovement.Add(1);
                }
                c++;
            }

            playerStopwatch.Start();

            MakeTrack();
            MakeStartLine();
        }

        public void MakeStartLine()
        {
            startLine[0] = new PointF(roadPoints[300].X, roadPoints[300].Y);
            startLine[1] = new PointF(roadPoints[400].X, roadPoints[400].Y);
            startLine[2] = new PointF(roadPoints[roadPoints.Count - 400].X, roadPoints[roadPoints.Count - 400].Y);
            startLine[3] = new PointF(roadPoints[roadPoints.Count - 300].X, roadPoints[roadPoints.Count - 300].Y);
        }

        public void MakePowerUps()
        {
            //powerUpCubes.Add(new Rectangle())
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            clickSound.Play();

            results.Stop();
            mainMenu.Play();
            
            state = "main menu";
            Refresh();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            clickSound.Play();

            state = "select character";
            Refresh();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            Application.Exit();
        }

        private void mainMenuMedia_MediaEnded(object sender, EventArgs e)
        {
            mainMenu.Stop();
            mainMenu.Play();
        }
        private void coconutMallMedia_MediaEnded(object sender, EventArgs e)
        {
            coconutMall.Stop();
            coconutMall.Play();
        }
        private void resultsMedia_MediaEnded(object sender, EventArgs e)
        {
            results.Stop();
            results.Play();
        }
        private void finalLapMedia_MediaEnded(object sender, EventArgs e)
        {
            finalLap.Stop();
            finalLap.Play();
        }
    }
}