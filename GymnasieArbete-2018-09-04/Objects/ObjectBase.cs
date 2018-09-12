using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasieArbete_2018_09_04
{
    class ObjectBase
    {
        public Vector2 position, center;
        public Texture2D texture;
        public float radius, thickness, rotation;
        public int sides, mass;
        public double acceleration;
        public Color color;

        public virtual void Initialize(Texture2D texture, Vector2 position)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {



        }

        public virtual void Update(GameTime gameTime, Vector2 gravityTemp)
        {


        }


    }
}
