using System;
using System.Windows.Forms;
using model;
using connection;
using System.Drawing;

namespace window
{
    public class Kianja : Form
    {
        int lavany, sakany;
        Mpilalao[] players;
        Lalao match;
        int isaBaolina;

        Formulaire form1;
        int score1;
        int score2;

        //Constructor
        public Kianja(){}
        public Kianja(int lavany, int sakany, Mpilalao[] mpilalao, Lalao match, int isaBaolina, Formulaire form1){
            Lavany = lavany;
            Sakany = sakany;
            Players = mpilalao;
            Match = match;
            IsaBaolina = isaBaolina;
            // While closing this window, all function DisposeAll
            Form1 = form1;
            this.FormClosing += DisposeAll;
            // Initialize each score to 0
            Score1 = 0;
            Score2 = 0;
        }

        // Setting up the GUI of the babyfoot field
        public void SetUpGUI(){
            this.Text = "Baby Foot Match";
            this.Size = new System.Drawing.Size(Lavany, Sakany);
            this.BackColor = Color.Black;

            // Adding players label
            this.PlayersLabel();
            // Label of number of the balls remaining
            this.BallLabel();
            // Displaying each score of each player label
            this.ScoreLabel();
            // Create the panel field
            FieldPanel terrain = new FieldPanel(this);
            terrain.SetUpField();
            Controls.Add(terrain);
        }

        // Function that adds label about the players
        public void PlayersLabel(){
            // Setting up label of player 1
            Label P1 = new Label(){
                Text = Players[0].AnaranaMpilalao,
                ForeColor = Color.White,
                Location = new Point(Lavany/4 -50 , 20),
            };
            // Setting up label of player 1
            Label P2 = new Label(){
                Text = Players[1].AnaranaMpilalao,
                ForeColor = Color.White,
                Location = new Point(3*(Lavany/4)-50 , 20),
            };

            Controls.Add(P1);
            Controls.Add(P2);
        }

        // Function that displays the number of the ball remaining
        public void BallLabel(){
            Label ball = new Label(){
                Text = ""+IsaBaolina,
                ForeColor = Color.White,
                Location = new Point((Lavany/2)-50, 20),
            };
            Controls.Add(ball);
        }

        // Function that will display each score label
        public void ScoreLabel(){
            Label score1 = new Label(){
                Text = ""+Score1,
                ForeColor = Color.White,
                Location = new Point(Lavany/4 -50 , 50),
            };
            Label score2 = new Label(){
                Text = ""+Score2,
                ForeColor = Color.White,
                Location = new Point(3*(Lavany/4)-50 , 50),
            };

            Controls.Add(score1);
            Controls.Add(score2);
        }

        // function called when the button closed it hit, dispose all opened window
        public void DisposeAll(object sender, FormClosingEventArgs e){
            this.Dispose();
            Form1.Dispose();
        }

        // Getters and Setters
        public int Lavany {get; set;}
        public int Sakany {get; set;}
        public Mpilalao[] Players {get; set;}
        public Lalao Match{get; set;}
        public int IsaBaolina {get; set;}
        public Formulaire Form1{get; set;}
        public int Score1{get; set;}
        public int Score2{get; set;}
    }
}