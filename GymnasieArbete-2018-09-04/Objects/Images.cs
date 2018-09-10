using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasieArbete_2018_09_04
{
    class Images
    {

        Vector2 playerPosition, planetPosition;
        Texture2D playerTexture, planetTexture;

        public void Initialize(Texture2D playertexture, Texture2D planettexture)
        {

            playerTexture = playertexture;
            planetTexture = planettexture;

        }

        public void Update(Player player, Planet planet)
        {
            planetPosition = new Vector2(planet.position.X - planetTexture.Width / 2, planet.position.Y - planetTexture.Height / 2);
            playerPosition = player.position;            

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(planetTexture,planetPosition, Color.White);
            //spriteBatch.Draw(playerTexture, new Vector2 (playerPosition.X - playerTexture.Width, playerPosition.Y - playerTexture.Height), Color.White);

        }

    }
}
