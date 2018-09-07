using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasieArbete_2018_09_04
{
    class circle
    {
        public struct Circle
        {
            public float Diameter { get; set; }
            public float X { get; set; }
            public float Y { get; set; }

            public void HoleInfo(float x, float y, float diameter)
            {
                X = x;
                Y = y;
                Diameter = diameter;
            }

            public bool Intersects(Circle other)
            {
                float holeSize = (this.Diameter + other.Diameter) / 2;
                float deltaX = this.X - other.X;
                float deltaY = this.Y - other.Y;
                return (holeSize * holeSize > deltaX * deltaX + deltaY * deltaY);
            }

        }


    }
}
            
            

            

   
