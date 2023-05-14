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

        public FieldPanel(){}
        public FieldPanel(Kianja kianja){
            Playernumber = new int[4];
            Terrain =kianja;
            Lavany = kianja.Lavany; Sakany = kianja.Sakany-100;
            But = new Tsatokazo[2];
            kianja.Players[0].PlayerController = new Taho[4];
            kianja.Players[1].PlayerController = new Taho[4];
            // The function to call as equivalence of paint function with graphics and so on
            this.Paint += Painting;
            // Set the number of player per taho
            Playernumber[0] = 1;Playernumber[1] = 3;Playernumber[2] = 5;Playernumber[3] = 3;
            // Construct the ball
            Baolina = new Ball(Lavany/2, Sakany/2, 20, this);
            // Init timer values
            InitAnimValue(); 
        }

        // Init animation handler value and variables
        public void InitAnimValue(){
            // Enable double buffering so the animation shal be very fluid
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            Timer timer = new Timer();
            timer.Interval = 5;
            // Timer_tick is the command that will be executed every interval time
            timer.Tick += Timer_tick;
            timer.Start();
        }

        // Animation Handling
        public void Timer_tick(object sender, EventArgs e){
            Baolina.Move();
            this.Invalidate();
        }

        // Paint function
        public void Painting(object sender, PaintEventArgs e){
            // using (Bitmap buffer = new Bitmap(Lavany, Sakany))
            // {
            //     // Create a Graphics object from the buffer
            //     using (Graphics g = Graphics.FromImage(buffer))
            //     {
                    // g.Clear(Color.White);
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
            //     }
            // }
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
            int t = 50;
            // Draw all the taho using a loop
            for(int i = 0 ; i < Terrain.Players[0].PlayerController.Length ; i++){
                Terrain.Players[0].PlayerController[i] = new Taho(Playernumber[i], t, 0, this);
                Terrain.Players[0].PlayerController[i].Draw(g, brush);
                t+=200;
            }
        }
        // The same as above but for player 2 as they have different color and uses different brushes
        public void DrawTahoPlayer2(Graphics g, Brush brush){
            int t = 50;
            for(int i = 0 ; i < Terrain.Players[0].PlayerController.Length ; i++){
                Terrain.Players[1].PlayerController[i] = new Taho(Playernumber[i], Terrain.Lavany-t, 0, this);
                Terrain.Players[1].PlayerController[i].Draw(g, brush);
                t+=200;
            }
        }

        // Getters & Setters
        public int Lavany {get; set;}
        public int Sakany{get; set;}    
        public Kianja Terrain {get;set;}
        public Tsatokazo[] But {get;set;}
        public static int[] Playernumber{get; set;}
        public Ball Baolina {get; set;}
    }
}