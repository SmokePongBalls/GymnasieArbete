﻿using Microsoft.Xna.Framework;
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
        public Keys up, down, left, right;
        KeyboardState pressedKeys;
        Planet planet;
        Texture2D texture;


        public override void Initialize(Texture2D texture)
        {
            position = new Vector2(20, 20);
            planet = new Planet();
            this.texture = texture;
            center = new Vector2(this.texture.Width / 2, this.texture.Height / 2);
            radius = 45;
            rotation = 0;
            thickness = 20;
            sides = 20;
            mass = 5;
            color = Color.Red;
            acceleration = 0.5;
            base.Initialize(texture);
        }



        public override void Draw(SpriteBatch spriteBatch)
        {
            //MonoGame.Extended.ShapeExtensions.DrawCircle(spriteBatch, position, radius, sides, color, thickness);

            spriteBatch.Draw(texture, position, null, Color.White, rotation, center, 1f, SpriteEffects.None, 1f);

            base.Draw(spriteBatch);
        }


        public override void Update(GameTime gameTime, Vector2 gravityTemp)
        {
            pressedKeys = Keyboard.GetState();
            KeyActions(gameTime);
            Boundaries();
            position += velocity;
            //position += gravityTemp;
        }

        private void Boundaries()
        {
            if (position.X < -50)
            {
                position.X = 1970;
            }

            if (position.X > 1970)
            {
                position.X = -50;
            }

            if (position.Y < -50)
            {
                position.Y = 1130;
            }

            if (position.Y > 1130)
            {
                position.Y = -50;
            }
        }

        private void KeyActions(GameTime gameTime)
        {
            if (pressedKeys.IsKeyDown(up))
            {
                velocity.Y -= (float)acceleration;
            }

            if (pressedKeys.IsKeyDown(left))
            {
                rotation -= (float)0.1;
                velocity.X -= (float)acceleration;
            }

            if (pressedKeys.IsKeyDown(down))
            {
                velocity.Y += (float)acceleration;
            }

            if (pressedKeys.IsKeyDown(right))
            {
                rotation += (float)0.1;
                velocity.X += (float)acceleration;

            }
        }

    }
}
