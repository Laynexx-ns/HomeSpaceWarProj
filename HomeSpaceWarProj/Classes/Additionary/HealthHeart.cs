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


namespace HomeSpaceWarProj.Classes.Additionary
{
    class HealthHeart
    {
        private Vector2 position;
        private Texture2D texture;

        public HealthHeart(Vector2 position)
        {
            this.position = position;
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("heart2x");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
        
    }
}
