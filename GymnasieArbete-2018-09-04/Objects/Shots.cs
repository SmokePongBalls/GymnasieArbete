using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GymnasieArbete_2018_09_04
{
    class Shots : ObjectBase
    {
        Vector2 velocity;

        public override void Initialize(Texture2D texture, Vector2 position)
        {
            this.position = position;
            this.texture = texture;
            
            center = new Vector2(this.texture.Width / 2, this.texture.Height / 2);

            base.Initialize(texture, position);
        }

        public override void Update(GameTime gameTime, Vector2 gravity)
        {
            rotation = (float)Math.Atan2(velocity.X, -velocity.Y);

            position += velocity;

            velocity.X += gravity.X;
            velocity.Y += gravity.Y;
            base.Update(gameTime, gravity);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotation, center, 1f, SpriteEffects.None, 1f);
            base.Draw(spriteBatch);
        }
    }
}
