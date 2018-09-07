using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GymnasieArbete_2018_09_04
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        Planet planet;
        Calculator calculator;
        Images images;
        Color backgroundColor;
        circle.Circle hitbox, hitbox2;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            //Fullscreen();
            images = new Images();
            calculator = new Calculator();
            planet = new Planet();
            hitbox = new circle.Circle();

            //bör nog tas bort;
            images.Initialize(Content.Load<Texture2D>("testSpaceship"), Content.Load<Texture2D>("testPlanet"));

            CreatePlayer();

            planet.Initialize(Content.Load<Texture2D>("testPlanet"));

            backgroundColor = Color.Black;

            hitbox.HoleInfo(player.position.X, player.position.Y, player.radius * 2);
            hitbox.HoleInfo(planet.position.X, planet.position.Y, planet.radius * 2);


            base.Initialize();
        }

        private void CreatePlayer()
        {
            //skapar en instans av "player" i "game1" och dessutom så får "player" sina tangenter. 
            //Så ifall jag vill ha två stycken spelare kan jag göra en ny "player" och ge den andra tangenter.
            player = new Player();
            player.Initialize(Content.Load<Texture2D>("testSpaceship"));
            player.up = Keys.W;
            player.down = Keys.S;
            player.left = Keys.A;
            player.right = Keys.D;
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

            

            //"player" klassen tar in ett float värde och det float är uträknat av "calculator.Gravity" metoden 
            //som jag använder för att räkna ut hur "players" position ska ändras relativt med det objekt som "player" ska dras mot.
            player.Update(gameTime, calculator.Gravity(player.position, planet.position, player.mass, planet.mass));
            images.Update(player, planet);
            // TODO: Add your update logic here

            base.Update(gameTime);
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
            images.Draw(spriteBatch);
            player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
