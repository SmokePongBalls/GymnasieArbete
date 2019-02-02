using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasieArbete_2018_09_04
{
    class OutOfScreenIndicator : ObjectBase
    {
        
        Vector2 centerOfScreen;
        double angle;

        public Game1 Game1
        {
            get => default(Game1);
            set
            {
            }
        }

        public override void Initialize(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            color = Color.White;
            center = new Vector2(this.texture.Width / 2, this.texture.Height / 2);
            centerOfScreen = new Vector2(1920 / 2, 1080 / 2);
            base.Initialize(texture, position);
        }

        public void Draw (SpriteBatch spriteBatch, Vector2 playerPosition)
        {

            angle = Math.Atan2(centerOfScreen.Y - position.Y, centerOfScreen.X - position.X);

            spriteBatch.Draw(texture, centerOfScreen, null, color, (float)angle, center, 5f, SpriteEffects.FlipHorizontally, 1f);

            //alla hörn. 
            //--
            if (position.Y > 1080 && playerPosition.X < 0)
            {

                spriteBatch.Draw(texture, new Vector2(0 + texture.Width - 20, 1080 - texture.Height), null, color, (float)angle, center, 1f, SpriteEffects.FlipHorizontally, 1f);
            }

            if (position.Y < 0 && playerPosition.X < 0)
            {

                spriteBatch.Draw(texture, new Vector2(0 + texture.Width - 20, 0 + texture.Height), null, color, (float)angle, center, 1f, SpriteEffects.FlipHorizontally, 1f);
            }

            if (position.Y < 0 && playerPosition.X > 1920)
            {

                spriteBatch.Draw(texture, new Vector2(1920 - texture.Width + 20, 0 + texture.Height), null, color, (float)angle, center, 1f, SpriteEffects.FlipHorizontally, 1f);
            }

            if (position.Y > 1080 && playerPosition.X > 1920)
            {

                spriteBatch.Draw(texture, new Vector2(1920 - texture.Width + 20, 1080 - texture.Height), null, color, (float)angle, center, 1f, SpriteEffects.FlipHorizontally, 1f);
            }
            //--

            //alla fyra sidor
            //--
            if (playerPosition.X < 0 && position.Y > 0 && position.Y < 1080)
            {
                spriteBatch.Draw(texture,new Vector2(texture.Width,position.Y), null, color, (float)angle, center, 1f, SpriteEffects.FlipHorizontally, 1f);
            }
           
            if (playerPosition.X > 1920 && position.Y < 1080 && position.Y > 0)
            {
                spriteBatch.Draw(texture, new Vector2(1920-texture.Width, position.Y), null, color, (float)angle, center, 1f, SpriteEffects.FlipHorizontally, 1f);
            }

            if (position.Y < 0 && playerPosition.X > 0 && playerPosition.X < 1920)
            {
                spriteBatch.Draw(texture, new Vector2(position.X, texture.Height), null, color, (float)angle, center, 1f, SpriteEffects.FlipHorizontally, 1f);
            }

            if (position.Y > 1080 && playerPosition.X < 1920 && position.X > 0)
            {
                spriteBatch.Draw(texture, new Vector2(position.X, 1080-texture.Height), null, color, (float)angle, center, 1f, SpriteEffects.FlipHorizontally, 1f);
            }
            //--
            
        }

        public void Update (Vector2 position)
        {
            this.position = position;

        }
    }
}
