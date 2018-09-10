using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasieArbete_2018_09_04
{
    class Calculator
    {
        public Vector2 gravity;
        double distance;
        float sideX, sideY, acceleration;
        double angle;
        
        public Vector2 Gravity(Vector2 position1, Vector2 position2, int mass1, int mass2, float acceleration)
        {
            gravity = Vector2.Zero;
            this.acceleration = acceleration;

            sideX = position1.X - position2.X;
            sideY = position1.Y - position2.Y;

            angle = Math.Atan2(position2.Y - position1.Y, position2.X - position1.X);

           
            distance = Math.Sqrt(Math.Pow(sideX, 2) + Math.Pow(sideY, 2));
            
            //Enhetscirkel
            gravity.X += (float)Math.Cos(angle) * this.acceleration;
            gravity.Y += (float)Math.Sin(angle) * this.acceleration;

            return gravity;
        }
    }
}
