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
        Vector2 gravityTemp;

        public Vector2 Gravity(Vector2 position1, Vector2 position2, int mass1, int mass2)
        {
            /*
            if (position1.X < position2.X)
            {
                gravityTemp.X = 5;
                return gravityTemp;
            }

            if (position2.X < position1.X)
            {
                gravityTemp.X = -5;
                return gravityTemp;
            }

            if (position1.Y < position2.Y)
            {
                gravityTemp.X = 5;
                return gravityTemp;
            }

            if (position2.Y < position1.Y)
            {
                gravityTemp.Y = -5;
                return gravityTemp;
            }
            */
            gravityTemp = Vector2.Zero;
            return gravityTemp;
        }
    }
}
