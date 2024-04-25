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
    public class BackGround
    {
        private Texture2D texture;
        private int speed;

        private Vector2 position;
        private Vector2 position2;


        public BackGround()
        {
            speed = 20;
            position = new Vector2(0, 0);
            position2 = new Vector2(800, 0);
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("mainbackground");
        }
        public void Update()
        {
            position.X -= speed;
            position2.X -= speed;


            
            if (position2.X <= 0)
            {
                position.X = 0;
                position2.X = 800;
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, position, Color.White);
            spritebatch.Draw(texture, position2, Color.White);
        }

        public void Reset()
        {
            speed = 20;
            position = new Vector2(0, 0);
            position2 = new Vector2(800, 0);
        }


    }
}
