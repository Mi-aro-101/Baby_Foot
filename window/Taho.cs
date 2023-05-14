using System;
using System.Drawing;

namespace window
{
    public class Taho
    {
        int x, y;
        int lavany, sakany;
        Footballer[] footballPlayer;

        bool isUp, isDown;

        // Constructor
        public Taho(){}
        public Taho(int footballerNumber, int x, int y, FieldPanel fieldPanel){
            X = x;
            Y = y;
            Lavany = 5;
            Sakany = fieldPanel.Sakany;
            // Set the number of footballer in contained in this Taho
            FootballPlayer = new Footballer[footballerNumber];
            // Initialize player of the Taho
            for(int i = 0 ; i < FootballPlayer.Length ; i++){
                int a = X;
                int b = (Sakany/(FootballPlayer.Length+1))+((Sakany/(FootballPlayer.Length+1)*i));
                FootballPlayer[i] = new Footballer(a, b-25); 
            }
            IsUp = false ; IsDown = false;
        }

        public void Draw(Graphics g, Brush brush){
            g.FillRectangle(brush, X, Y, Lavany, Sakany);
            // Paint the footballers with it
            for(int i = 0 ; i < FootballPlayer.Length ; i++){
                FootballPlayer[i].Draw(g, brush);
            }
        }

        // All footbaler in this taho move simultaneously
        public void MoveUp(){
            for(int i = 0 ; i < FootballPlayer.Length ; i++){
                FootballPlayer[i].MoveUp();
            }
        }
        public void MoveDown(){
            for(int i = 0 ; i < FootballPlayer.Length ; i++){
                FootballPlayer[i].MoveDown();
            }
        }

        //Getters & Setters
        public int X {get; set;}
        public int Y {get; set;}
        public int Lavany {get; set;}
        public int Sakany {get; set;}
        public Footballer[] FootballPlayer{get; set;}

        public bool IsUp {get; set;}
        public bool IsDown {get; set;}
    }
}