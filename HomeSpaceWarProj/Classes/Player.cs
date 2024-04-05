using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HomeSpaceWarProj.Classes
{
    public class Player
    {
        private Texture2D texture;
        private Vector2 position;
        private int speed;

        public Player()
        {
            texture = null;
            position = new Vector2(0, 0);
            speed = 12;
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("player");
        }
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position.X -= speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position.Y -= speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.Y += speed;
            }
            
              
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
            
            
        }
    }
}
