using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasieArbete_2018_09_04
{
    class Player : ObjectBase
    {
        public Vector2 velocity;
        public Keys up, down, left, right, shot;
        public KeyboardState pressedKeys;

        public Game1 Game1
        {
            get => default(Game1);
            set
            {
            }
        }

        public override void Initialize(Texture2D texture, Vector2 position)
        {
            this.position = position;
            this.texture = texture;
            center = new Vector2(this.texture.Width / 2, this.texture.Height / 2);
            radius = 30;
            rotation = 0;
            thickness = 20;
            sides = 20;
            mass = 9000;
            color = Color.White;
            acceleration = 0.02;//0.03

            base.Initialize(texture, position);
        }



        public override void Draw(SpriteBatch spriteBatch)
        {

            //För att enkelt se den cirkulära "hitboxen"
            //MonoGame.Extended.ShapeExtensions.DrawCircle(spriteBatch, position, radius, sides, color, thickness);

            spriteBatch.Draw(texture, position, null, color, rotation, center, 0.3f, SpriteEffects.None, 1f);

            base.Draw(spriteBatch);
        }


        public override void Update(GameTime gameTime, Vector2 gravity)
        {
            pressedKeys = Keyboard.GetState();

            KeyActions(gameTime); 

            Movement(gravity);
        }

        private void Movement(Vector2 gravity)
        {
            position += velocity;
            
            velocity.X += gravity.X;
            velocity.Y += gravity.Y;
        }

        private void KeyActions(GameTime gameTime)
        {
            //velocity = Vector2.Zero;

            if (pressedKeys.IsKeyDown(up))
            {

                velocity.X += (float)Math.Cos(rotation) * (float)acceleration;

                velocity.Y += (float)Math.Sin(rotation) * (float)acceleration;
            }

            if (pressedKeys.IsKeyDown(left))
            {
                rotation -= (float)0.1;
                if (rotation > MathHelper.Pi)
                {
                    rotation -= MathHelper.TwoPi;
                }
            }

            //har kvar denna ifall jag vill använda den
            if (pressedKeys.IsKeyDown(down))
            {
            }

            if (pressedKeys.IsKeyDown(right))
            {
                rotation += (float)0.1;

                if (rotation < -MathHelper.Pi)
                {
                    rotation += MathHelper.TwoPi;
                }
            }



        }

    }
}
