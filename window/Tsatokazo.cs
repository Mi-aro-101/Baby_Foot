using System;
using System.Drawing;

namespace window
{
    public class Tsatokazo
    {
        // Coordinate of tsatikazo
        int x, y;
        // Size
        int lavany, sakany;

        // Contructor
        public Tsatokazo(){}
        public Tsatokazo(int x, int y, int lavany, int sakany){
            X = x;   
            Y = y;
            Lavany = lavany;
            Sakany = sakany;     
        }

        public void Draw(Graphics g, Pen pen){
            g.DrawRectangle(pen, X, Y, Lavany, Sakany);
        }

        // Getters & Setters
        public int X {get; set;}
        public int Y {get; set;}
        public int Lavany {get; set;}
        public int Sakany{get; set;}
    }
}