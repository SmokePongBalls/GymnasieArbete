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
        Player player, player2;
        Planet planet;
        List<Shot> shots;
        List<circle.Circle> bulletHitbox;
        Calculator calculator;
        Color backgroundColor;
        circle.Circle playerHitbox, planetHitbox, player2Hitbox;
        SpriteFont font;
        Texture2D planetTexture, playerTexture, shotsTexture;
        double countdown, countdown2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            Fullscreen();
            calculator = new Calculator();
            planet = new Planet();
            shots = new List<Shot>();

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
            //bör nog tas bort;

            CreatePlayer();
            CreatePlayer2();
            

            planet.Initialize(planetTexture, new Vector2(1920 / 2, 1080 / 2));

            backgroundColor = Color.Black;


            base.Initialize();
        }

        private void HitboxUpdate()
        {
            playerHitbox.HoleInfo(player.position.X, player.position.Y, player.radius * 2);
            player2Hitbox.HoleInfo(player2.position.X, player2.position.Y, player2.radius * 2);
            planetHitbox.HoleInfo(planet.center.X, planet.center.Y, planet.radius * 2);
            
        }

        private void CreatePlayer()
        {
            //skapar en instans av "player" i "game1" och dessutom så får "player" sina tangenter. 
            //Så ifall jag vill ha två stycken spelare kan jag göra en ny "player" och ge den andra tangenter.
            player = new Player();
            player.Initialize(playerTexture, new Vector2(100, 100));
            player.up = Keys.W;
            player.down = Keys.S;
            player.left = Keys.A;
            player.right = Keys.D;
            player.shot = Keys.T;
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
            
            // TODO: use this.Content to load your game content here
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

            HitboxUpdate();

            Hitbox();

            if (player.pressedKeys.IsKeyDown(player.shot))
            {
                countdown -= gameTime.ElapsedGameTime.TotalMilliseconds;

                if (countdown <= 0)
                {
                    shots.Add(new Shot(player.position, shotsTexture, player.rotation, player.velocity));
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
                shot.Update(gameTime, calculator.Gravity(shot.position, planet.center, shot.mass, planet.mass, 0.02f));

                if(shot.ShotHitbox(playerHitbox))
                {

                    player.color = Color.Red;
                    shots.Remove(shot);
                    player.texture = Content.Load<Texture2D>("bullet");
                    
                    shotsTexture = Content.Load<Texture2D>("testSpaceship");

                }

                if (shot.ShotHitbox(player2Hitbox))
                {

                    player2.color = Color.Red;
                    shots.Remove(shot);
                    player2.texture = Content.Load<Texture2D>("bullet");

                    shotsTexture = Content.Load<Texture2D>("testSpaceship");
                }

                if (shot.ShotHitbox(planetHitbox))
                {

                    planet.color = Color.Red;
                    shots.Remove(shot);
                }
               

            }

            
                //"player" klassen tar in ett float värde och det float är uträknat av "calculator.Gravity" metoden -->
                //--> som jag använder för att räkna ut hur "players" position ska ändras relativt med det objekt som "player" ska dras mot.
                player.Update(gameTime, calculator.Gravity(player.position, planet.center, player.mass, planet.mass, 0.02f));
            player2.Update(gameTime, calculator.Gravity(player2.position, planet.center, player2.mass, planet.mass, 0.02f));
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        private void Hitbox()
        {
            if (playerHitbox.Intersects(planetHitbox))
            {
                player.color = Color.Blue;
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
            GraphicsDevice.Clear(backgroundColor);

            spriteBatch.Begin();

            planet.Draw(spriteBatch);          
            
            player.Draw(spriteBatch);
            player2.Draw(spriteBatch);

            foreach(Shot shot in shots.ToArray())
            {

                shot.Draw(spriteBatch);

            }

            spriteBatch.DrawString(font, Convert.ToString("Player1"), player.position, Color.White);
            spriteBatch.DrawString(font, Convert.ToString("Player2"), player2.position, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
