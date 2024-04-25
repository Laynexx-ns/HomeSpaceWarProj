using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Accessibility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using SharpDX.WIC;

namespace HomeSpaceWarProj.Classes
{
    class InfoMenu
    {
        private Texture2D texture;
        private Player player;
        private Vector2 position = new Vector2(0, 0);




        public InfoMenu()
        {
            player = new Player(new Vector2(500, 200));
        }


        public void Update(ContentManager manager, GameTime gameTime)
        {
            player.Update(manager, gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Game1.gameMode = SpaceWar.Classes.GameMode.Menu;
            }
        }
        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("InfoMenu");
            player.LoadContent(manager);
        }
        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(texture, position, Color.White);
            player.Draw(sprite);
        }


    }
}
