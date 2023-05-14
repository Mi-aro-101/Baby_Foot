using System;
using System.Windows.Forms;
using System.Drawing;

namespace window
{
    public class FieldPanel : Panel
    {
        int lavany, sakany;
        Kianja terrain;
        // Goals [But] na tsatokazo
        Tsatokazo[] but;

        // Number of player per Taho
        static int[] playernumber;
        // The Ball during the match
        Ball baolina;

        // Taho actif
        int actif1;
        int actif2;

        int x;

        public FieldPanel(){}
        public FieldPanel(Kianja kianja){
            Playernumber = new int[4];
            Terrain = kianja;
            Terrain.Focus();
            Lavany = kianja.Lavany; Sakany = kianja.Sakany-100;
            But = new Tsatokazo[2];
            kianja.Players[0].PlayerController = new Taho[4];
            kianja.Players[1].PlayerController = new Taho[4];
            // The function to call as equivalence of paint function with graphics and so on
            this.Paint += Painting;
            // Set the number of player per taho
            Playernumber[0] = 1 ; Playernumber[1] = 3 ; Playernumber[2] = 5 ; Playernumber[3] = 3;
            // Init all Taho
            InitTaho1(); InitTaho2();
            // Construct the ball
            Baolina = new Ball(Lavany/2, Sakany/2, 20, this);

            // Call the button affectation function
            SetUpButton();

            // Init timer values for animation handler
            InitAnimValue(); 

            Actif1 = 0;
            Actif2 = 0;

        }

        // Button Function affectation
        public void SetUpButton(){
            Terrain.KeyPreview = true;
            Terrain.PreviewKeyDown += KeyPressed;
            Terrain.KeyUp += KeyReleased; 
        }

        // Functions that are responsible of each key event pressed
        public void KeyPressed(object sender, PreviewKeyDownEventArgs  e){
            // Managing the movement of each Taho for player 1
            if(e.KeyCode == Keys.Down){
                Terrain.Players[0].PlayerController[Actif1].IsDown = true;
            }
            if(e.KeyCode == Keys.Up){
                Terrain.Players[0].PlayerController[Actif1].IsUp = true;
            }
            if(e.KeyCode == Keys.Right && Actif1 < Terrain.Players[0].PlayerController.Length){Actif1+=1;}
            if(e.KeyCode == Keys.Left && Actif1 > 0){Actif1-=1;}

            // Managing the movement of each Taho for player2
            if(e.KeyCode == Keys.S){
                Terrain.Players[1].PlayerController[Actif2].IsDown = true;
            }
            if(e.KeyCode == Keys.Z){
                Terrain.Players[1].PlayerController[Actif2].IsUp = true;
            }
            if(e.KeyCode == Keys.Q && Actif2 < Terrain.Players[1].PlayerController.Length){Actif2+=1;}
            if(e.KeyCode == Keys.D && Actif2 > 0){Actif2-=1;}
        }

        public void KeyReleased(object sender, KeyEventArgs  e){
            if(e.KeyCode == Keys.Down){
                Terrain.Players[0].PlayerController[Actif1].IsDown = false;
            }
            if(e.KeyCode == Keys.Up){
                Terrain.Players[0].PlayerController[Actif1].IsUp = false;
            }

            if(e.KeyCode == Keys.S){
                Terrain.Players[1].PlayerController[Actif2].IsDown = false;
            }
            if(e.KeyCode == Keys.Z){
                Terrain.Players[1].PlayerController[Actif2].IsUp = false;
            }
        }


        // Init animation handler value and variables
        public void InitAnimValue(){
            // Enable double buffering so the animation shall be very fluid
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            Timer timer = new Timer();
            timer.Interval = 5;
            // Timer_tick is the command that will be executed every interval time
            timer.Tick += Timer_tick;
            timer.Start();
        }

        public void InitTaho1(){
            int t = 50;
            // Draw all the taho using a loop
            for(int i = 0 ; i < Terrain.Players[0].PlayerController.Length ; i++){
                Terrain.Players[0].PlayerController[i] = new Taho(Playernumber[i], t, 0, this);
                t+=200;
            }
        }

        public void InitTaho2(){
            int t = 50;
            for(int i = 0 ; i < Terrain.Players[0].PlayerController.Length ; i++){
                Terrain.Players[1].PlayerController[i] = new Taho(Playernumber[i], Terrain.Lavany-t, 0, this);
                t+=200;
            }
        }

        // Animation Handling
        public void Timer_tick(object sender, EventArgs e){
            // For the ball movement
            Baolina.Move();            
            
            if(Terrain.Players[0].PlayerController[Actif1].IsDown){
                Terrain.Players[0].PlayerController[Actif1].MoveDown();
            }
            if(Terrain.Players[0].PlayerController[Actif1].IsUp){
                Terrain.Players[0].PlayerController[Actif1].MoveUp();
            }

            if(Terrain.Players[1].PlayerController[Actif2].IsDown){
                Terrain.Players[1].PlayerController[Actif2].MoveDown();
            }
            if(Terrain.Players[1].PlayerController[Actif2].IsUp){
                Terrain.Players[1].PlayerController[Actif2].MoveUp();
            }

            this.Invalidate();
        }

        // Paint function
        public void Painting(object sender, PaintEventArgs e){
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.White);
            // Brush use to paint player 1 taho
            Brush brush1 = Brushes.Blue;
            // Brush use to paint player 2 taho
            Brush brush2 = Brushes.Red;
            // Brush for the ball
            Brush brushBall = Brushes.White;

            // Draw but or tsatokazo
            Tsatokazo(g, pen);
            // Draw the players footballer controller
            DrawTahoPlayer1(g, brush1);
            DrawTahoPlayer2(g, brush2);
            // Draw Ball
            Baolina.Draw(g, brushBall);
        }

        //Setting up the field
        public void SetUpField(){
            this.Size = new Size(Lavany, Sakany);
            this.BackColor = Color.Green;
            this.Location = new Point(0, 100);
        }

        // Draw tsatokazo na but
        public void Tsatokazo(Graphics g, Pen pen){
            // Init tsatokazo class and setting their coordinates and size
            But[0] = new Tsatokazo(0, Sakany/3-20, 80, Sakany/3);
            But[1] = new Tsatokazo(Lavany-100, Sakany/3-20, 80, Sakany/3);
            // Draw tsatokazo
            But[0].Draw(g, pen);
            But[1].Draw(g, pen);
        } 

        // Draw Taho na Playercontroller with their actual footballer pour joueur1
        public void DrawTahoPlayer1(Graphics g, Brush brush){
            // Draw all the taho using a loop
            for(int i = 0 ; i < Terrain.Players[0].PlayerController.Length ; i++){
                Terrain.Players[0].PlayerController[i].Draw(g, brush);
            }
        }

        // The same as above but for player 2 as they have different color and uses different brushes
        public void DrawTahoPlayer2(Graphics g, Brush brush){
            for(int i = 0 ; i < Terrain.Players[0].PlayerController.Length ; i++){
                Terrain.Players[1].PlayerController[i].Draw(g, brush);
            }
        }

        // Getters & Setters
        public int Lavany {get; set;}
        public int Sakany{get; set;}    
        public Kianja Terrain {get;set;}
        public Tsatokazo[] But {get;set;}
        public static int[] Playernumber{get; set;}
        public Ball Baolina {get; set;}
        public int Actif1 {get; set;}
        public int Actif2 {get; set;}
    }
}