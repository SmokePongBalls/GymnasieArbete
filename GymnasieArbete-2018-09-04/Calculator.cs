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
        double distance, gravitationalConstant = 0.0000000000667384;
        float sideX, sideY, acceleration, gravityPull;
        double angle;

        public Game1 Game1
        {
            get => default(Game1);
            set
            {
            }
        }

        public Vector2 Gravity(Vector2 position1, Vector2 position2, long mass1, long mass2, float acceleration)
        {
            gravity = Vector2.Zero;
            this.acceleration = acceleration;

            sideX = position1.X - position2.X;
            sideY = position1.Y - position2.Y;

            distance = Math.Sqrt(Math.Pow(sideX, 2) + Math.Pow(sideY, 2));
            //skala
            //1 pixel = 1000 meter.
            distance *= 1000;

            //tansatsen
            angle = Math.Atan2(position2.Y - position1.Y, position2.X - position1.X);
           
            gravityPull = (float)gravitationalConstant*((mass1 * mass2)/(float)distance);


            //Enhetscirkel
            gravity.X += (float)Math.Cos(angle) * gravityPull;
            gravity.Y += (float)Math.Sin(angle) * gravityPull;

            return gravity;
        }
    }
}
