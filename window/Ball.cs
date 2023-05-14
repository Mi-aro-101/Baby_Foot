using System;
using System.Drawing;

namespace window
{
    public class Ball
    {
        // Coordinates
        int x, y;
        // Ball fast and direction
        int dx, dy;
        // Size
        int radius;
        FieldPanel greenField;

        public Ball(){}
        public Ball(int x, int y, int radius, FieldPanel fieldPanel){
            X = x;
            Y = y;
            Dx = 1;
            Dy = 1;
            Radius = radius;
            GreenField = fieldPanel;
        }

        // Drawing the ball at proper coordinates
        public void Draw(Graphics g, Brush brush){
            g.FillEllipse(brush, X, Y, Radius, Radius);
        }

        // Responsible fot the movement of the ball
        public void Move(){
            X += Dx;
            Y += Dy;
            if(X < 0 || X+Radius > GreenField.Lavany-Radius){Dx = -Dx;}
            if(Y < 0 || Y+Radius > GreenField.Sakany-Radius*2){Dy =- Dy;}
        }

        //Getters & Setters
        public int X {get; set;}
        public int Y {get; set;}
        public int Dx {get; set;}
        public int Dy {get; set;}
        public int Radius {get; set;}
        public FieldPanel GreenField {get; set;}
    }
}