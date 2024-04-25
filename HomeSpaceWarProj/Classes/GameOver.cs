using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Accessibility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceWar.Classes;

namespace HomeSpaceWarProj.Classes
{
    public class GameOver
    {
        private Texture2D texture;

        public GameOver()
        {
            texture = null;
        }
        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("endMenu");
        }

        public void Update()
        {
            KeyboardState keystate = Keyboard.GetState();
            if (keystate.IsKeyDown(Keys.Space))
            {
                Game1.gameMode = GameMode.Menu;
            }
                
            
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, new Vector2(0, 0), Color.White);  
        }
    }
}
