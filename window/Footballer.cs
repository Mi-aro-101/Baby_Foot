using System;
using System.Drawing;

namespace window
{
    public class Footballer
    {
        // Coordinates
        int x, y;
        //Size
        int lavany, sakany;

        // Constructor
        public Footballer(){}
        public Footballer(int x, int y){
            X = x;
            Y = y;
            Lavany = 30;
            Sakany = 10;
        }

        // Draw this component
        public void Draw(Graphics g, Brush brush){
            g.FillEllipse(brush, X, Y, Lavany, Sakany);
        }
        // responsible of every footballer move
        public void MoveUp(){
            Y -= 5;
        }

        public void MoveDown(){
            Y += 5;
        }

        // Getters & Setters
        public int X {get; set;}
        public int Y {get; set;}
        public int Lavany {get; set;}
        public int Sakany {get; set;}    }
}