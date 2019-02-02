using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GymnasieArbete_2018_09_04
{
    class Button : Component
    {

        private MouseState currentMouse; 
        private SpriteFont font;
        private bool isHovering;
        private MouseState previousMouse;
        private Texture2D texture;


        public event EventHandler Click;

        public bool clicked { get; private set; }

        public Color penColor { get; set; }

        public Vector2 position { get; set; }   

        public Rectangle rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }

        public string text { get; set; }


        public Button(Texture2D texture, SpriteFont font)
        {
            this.texture = texture;
            this.font = font;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spritebatch)
        {
            var color = Color.White;

            if (isHovering)
            {
                color = Color.Gray;
            }

            spritebatch.Draw(texture, rectangle, color);

            if(!string.IsNullOrEmpty(text))
            {
                var x = (rectangle.X + (rectangle.Width / 2) - (font.MeasureString(text).X / 2));
                var y = (rectangle.Y + (rectangle.Height / 2) - (font.MeasureString(text).Y / 2));

                spritebatch.DrawString(font, text, new Vector2(x, y), penColor);
            }

            
        }

        public override void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            isHovering = false;

            if(mouseRectangle.Intersects(rectangle))
            {
                isHovering = true;

                if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }


            }
        }
    }
}
