using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GymnasieArbete_2018_09_04
{
    class Shot : ObjectBase
    {
        circle.Circle hitbox;
        Vector2 velocity;
       
        
        bool activated;

        public Shot(Vector2 position, Texture2D texture, float rotation, Vector2 playerVelocity)
        {
            //intierar alla värden och dessutom tar in players rotation för att rätt hastighet
            this.position = position;
            this.texture = texture;
            acceleration = 10;
            radius = 8;
            thickness = 10;
            sides = 10;
            mass = 100000;
            color = Color.Red;
            activated = false;
            hitbox = new circle.Circle();

            this.rotation = rotation;
            this.velocity.X = (float)Math.Cos(rotation) * (float)acceleration;
            this.velocity.Y = (float)Math.Sin(rotation) * (float)acceleration;

            this.position += this.velocity *5f;
            this.velocity += playerVelocity;
            
            center = new Vector2(this.texture.Width / 2 + 50, this.texture.Height / 2 + 10);
        }

        public Game1 Game1
        {
            get => default(Game1);
            set
            {
            }
        }

        public override void Update(GameTime gameTime, Vector2 gravity)
        {
            rotation = (float)Math.Atan2(velocity.Y, velocity.X);
           
            base.rotation = rotation;

            position += velocity;

            velocity.X += gravity.X;
            velocity.Y += gravity.Y;

            base.Update(gameTime, gravity);
        }

        public bool ShotHitbox(circle.Circle otherHitbox)
        {

            hitbox.HoleInfo(position.X, position.Y, radius * 2);

            if(!hitbox.Intersects(otherHitbox))
            {
                activated = true;
            }

            if (activated)
            {
                return hitbox.Intersects(otherHitbox);
            }
            else
            {
                return false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //för att rita ut hitboxen
            //MonoGame.Extended.ShapeExtensions.DrawCircle(spriteBatch, position, radius, sides, color, thickness);
            spriteBatch.Draw(texture, position, null, Color.White, base.rotation, center, 0.1f, SpriteEffects.None, 1f);

            
            base.Draw(spriteBatch);
        }
    }
}
