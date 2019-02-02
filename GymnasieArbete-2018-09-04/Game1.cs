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
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player1, player2;
        Planet planet;

        List<Shot> shots;
        private List<Component> gameComponents;
        circle.Circle playerHitbox, planetHitbox, player2Hitbox;
        List<circle.Circle> bulletHitbox;

        Calculator calculator;
        Color gameBakgroundColor, menuBackgroundColor;
        OutOfScreenIndicator outOfScreenIndicatorPlayer1, outOfScreenIndicatorPlayer2;

        SpriteFont font;
        Texture2D planetTexture, playerTexture, shotsTexture, outOfScreenIndicatorPlayer1Texture, outOfScreenIndicatorPlayer2Texture;
        double countdown, countdown2;

        private State currentState, nextState;

        public void ChangeState(State state)
        {
            nextState = state;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            //gör spelet till fullscreen
            Fullscreen();
            calculator = new Calculator();
            planet = new Planet();
            shots = new List<Shot>();
            outOfScreenIndicatorPlayer1 = new OutOfScreenIndicator();
            outOfScreenIndicatorPlayer2 = new OutOfScreenIndicator();

            playerHitbox = new circle.Circle();
            player2Hitbox = new circle.Circle();
            planetHitbox = new circle.Circle();
            bulletHitbox = new List<circle.Circle>();

            font = Content.Load<SpriteFont>("Font");

            countdown = 0;
            countdown2 = 0;

            playerTexture = Content.Load<Texture2D>("testSpaceship");

            planetTexture = Content.Load<Texture2D>("testPlanet");

            shotsTexture = Content.Load<Texture2D>("bullet");

            outOfScreenIndicatorPlayer1Texture = Content.Load<Texture2D>("redArrow");
            outOfScreenIndicatorPlayer2Texture = Content.Load<Texture2D>("blueArrow");
            //bör nog tas bort;

            CreatePlayer();
            CreatePlayer2();
            

            planet.Initialize(planetTexture, new Vector2(1920 / 2, 1080 / 2));

            outOfScreenIndicatorPlayer1.Initialize(outOfScreenIndicatorPlayer1Texture, player1.position);
            outOfScreenIndicatorPlayer2.Initialize(outOfScreenIndicatorPlayer2Texture, player2.position);

            gameBakgroundColor = Color.Black;
            menuBackgroundColor = Color.BurlyWood;

            
            base.Initialize();
        }

        private void HitboxUpdate()
        {
            playerHitbox.HoleInfo(player1.position.X, player1.position.Y, player1.radius * 2);
            player2Hitbox.HoleInfo(player2.position.X, player2.position.Y, player2.radius * 2);
            planetHitbox.HoleInfo(planet.center.X, planet.center.Y, planet.radius * 2);
            
        }

        private void CreatePlayer()
        {
            //skapar en instans av "player" i "game1" och dessutom så får "player" sina tangenter. 
            //Så ifall jag vill ha två stycken spelare kan jag göra en ny "player" och ge den andra tangenter.
            player1 = new Player();
            player1.Initialize(playerTexture, new Vector2(100, 100));
            player1.up = Keys.W;
            player1.down = Keys.S;
            player1.left = Keys.A;
            player1.right = Keys.D;
            player1.shot = Keys.T;
        }

        private void CreatePlayer2()
        {
            //skapar en instans av "player" i "game1" och dessutom så får "player" sina tangenter. 
            //Så ifall jag vill ha två stycken spelare kan jag göra en ny "player" och ge den andra tangenter.
            player2 = new Player();
            player2.Initialize(playerTexture, new Vector2(1820, 100));
            player2.up = Keys.Up;
            player2.down = Keys.Down;
            player2.left = Keys.Left;
            player2.right = Keys.Right;
            player2.shot = Keys.Enter;
        }

        private void Fullscreen()
        {

            //Gör så att spelet fyller hela skärmen.
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            //--
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
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

            HitboxUpdate();

            Hitbox();

            if (player1.pressedKeys.IsKeyDown(player1.shot))
            {
                countdown -= gameTime.ElapsedGameTime.TotalMilliseconds;

                if (countdown <= 0)
                {
                    shots.Add(new Shot(player1.position, shotsTexture, player1.rotation, player1.velocity));
                    //bulletHitbox.Add(new circle.Circle());
                    countdown = 500;
                }


            }
            
            if (player2.pressedKeys.IsKeyDown(player2.shot))
            {
                countdown2 -= gameTime.ElapsedGameTime.TotalMilliseconds;

                if (countdown2 <= 0)
                {
                    //lägger till fler "skott" i shots listan så att jag kan skapa pararella shots och påverka deras värden enskilt.
                    shots.Add(new Shot(player2.position, shotsTexture, player2.rotation, player2.velocity));
                   // bulletHitbox.Add(new circle.Circle());
                    countdown2 = 500;
                }


            }
            
                
            foreach (Shot shot in shots.ToArray())
            {
                //uppdaterar varje shot enskilt.
                shot.Update(gameTime, calculator.Gravity(shot.position, planet.center, (int)shot.mass, (int)planet.mass, 0.02f));

                if(shot.ShotHitbox(playerHitbox))
                {

                    player1.color = Color.Red;
                    shots.Remove(shot);

                }

                if (shot.ShotHitbox(player2Hitbox))
                {

                    player2.color = Color.Red;
                    shots.Remove(shot);
                    

                   
                }

                if (shot.ShotHitbox(planetHitbox))
                {

                    planet.color = Color.Red;
                    shots.Remove(shot);
                }
               

            }

            
                //"player" klassen tar in ett float värde och det float är uträknat av "calculator.Gravity" metoden -->
                //--> som jag använder för att räkna ut hur "players" position ska ändras relativt med det objekt som "player" ska dras mot.
                player1.Update(gameTime, calculator.Gravity(player1.position, planet.center, player1.mass, planet.mass, 0.02f));
            player2.Update(gameTime, calculator.Gravity(player2.position, planet.center, player2.mass, planet.mass, 0.02f));
            // TODO: Add your update logic here

            outOfScreenIndicatorPlayer1.Update(player1.position);
            outOfScreenIndicatorPlayer2.Update(player2.position);
            base.Update(gameTime);
        }

        private void Hitbox()
        {
            if (playerHitbox.Intersects(planetHitbox))
            {
                player1.color = Color.Blue;
            }
            if (player2Hitbox.Intersects(planetHitbox))
            {
                player2.color = Color.Blue;
            }
            
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

            planet.Draw(spriteBatch);

            outOfScreenIndicatorPlayer1.Draw(spriteBatch, player1.position);
            outOfScreenIndicatorPlayer2.Draw(spriteBatch, player2.position);

            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            
            
            spriteBatch.Draw(Content.Load<Texture2D>("face"), player1.position, Color.White);

            foreach(Shot shot in shots.ToArray())
            {

                shot.Draw(spriteBatch);

            }
            //Text som ritas ut
            spriteBatch.DrawString(font, Convert.ToString(planetTexture.Width), planet.position, Color.White);
            spriteBatch.DrawString(font, Convert.ToString("Player1"), player1.position, Color.White);
            spriteBatch.DrawString(font, Convert.ToString("Player2"), player2.position, Color.White);

           
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
