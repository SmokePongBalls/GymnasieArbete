using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasieArbete_2018_09_04.States
{
    public abstract class State
    {
        protected ContentManager content;

        protected GraphicsDevice graphicsDevice;

        protected Game1 game1;


        public abstract void Draw(GameTime gametime, SpriteBatch spriteBatch);

        public abstract void PostUpdate(GameTime gameTime);

        public State(Game1 game1, GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.game1 = game1;

            this.graphicsDevice = graphicsDevice;

            this.content = content;
        }

        public abstract void Update(GameTime gameTime);
    }
}
