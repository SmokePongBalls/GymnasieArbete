using GymnasieArbete_2018_09_04.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace GymnasieArbete_2018_09_04
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

       
        SpriteFont font;
        
        private State currentState, nextState;

        public void ChangeState(State state)
        {
            nextState = state;
        }

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {

            font = Content.Load<SpriteFont>("Font");


            gameBakgroundColor = Color.Black;
            menuBackgroundColor = Color.BurlyWood;

            IsMouseVisible = true;

            base.Initialize();
        }

       
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public static void LoadContent()
        {
          
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var randomButton = new Button(Content.Load<Texture2D>("button"), Content.Load<SpriteFont>("Font"))
            {
                position = new Vector2(350, 200),
                text = "Random",
            };

            randomButton.Click += RandomButton_Click;

            var quitButton = new Button(Content.Load<Texture2D>("button"), Content.Load<SpriteFont>("Font"))
            {
                position = new Vector2(350, 250),
                text = "Quit",
            };

            quitButton.Click += QuitButton_Click;

            gameComponents = new List<Component>()
            {
                randomButton,
                quitButton,
            };


            // TODO: use this.Content to load your game content here
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void RandomButton_Click(object sender, EventArgs e)
        {
            var random = new Random();

            menuBackgroundColor = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var component in gameComponents)
            {
                component.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(menuBackgroundColor);

            spriteBatch.Begin();

            foreach (var component in gameComponents)
            {
                component.Draw(gameTime, spriteBatch);
            }

            

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
