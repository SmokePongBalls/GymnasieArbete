using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace GymnasieArbete_2018_09_04
{
    class Planet : ObjectBase
    {

        public override void Initialize(Texture2D texture)
        {
            position = new Vector2(1920 / 2, 1080 / 2);
            radius = 150;
            thickness = 100;
            sides = 100;
            mass = 1000000;
            acceleration = 0;
            color = Color.Red;
            base.Initialize(texture);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

           //För att enkelt se den cirkulära "hitboxen"
           //MonoGame.Extended.ShapeExtensions.DrawCircle(spriteBatch, position, radius, sides, color, thickness);

            base.Draw(spriteBatch);
        }

    }
}
