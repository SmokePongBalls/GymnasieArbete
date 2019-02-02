using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GymnasieArbete_2018_09_04.States
{
    public class MenuState : State
    {
        private List<Component> components;

        public MenuState(Game1 game1, GraphicsDevice graphicsDevice, ContentManager content) : base(game1, graphicsDevice, content)
        {
            var buttonTexture = content.Load<Texture2D>("button");
            var buttonFont = content.Load<SpriteFont>("Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                position = new Vector2(300, 200),
                text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                position = new Vector2(300, 250),
                text = "Quit",
            };

            quitGameButton.Click += QuitGameButton_Click; ;

            components = new List<Component>()
            {
                newGameButton,
                quitGameButton,
            };
        }


        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            game1.Exit();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            //Load new game state
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach(var component in components)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }


        public override void PostUpdate(GameTime gameTime)
        {
            // Tar bort sprites ifall de inte behövs.
        }


        public override void Update(GameTime gameTime)
        {
            foreach (var component in components)
            {
                component.Update(gameTime);
            }
        }
    }
}
