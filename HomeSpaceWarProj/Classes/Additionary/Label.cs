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
    public class Label
    {
        private string text;
        private Vector2 position;
        private Color color;
        private SpriteFont font;

        public Label(string text, Vector2 position, Color color)
        {
            this.text = text;
            this.position = position;
            this.color = color;
            font = null;
        }

        public void LoadContent(ContentManager manager)
        {
            font = manager.Load<SpriteFont>("gameFont");
        }

        public void Update(string text)
        {
            this.text = text;
        }

        public void Draw(SpriteBatch spritebatch , Color ccolor)
        {
            spritebatch.DrawString(font, text, position, ccolor);
        }
    }
}
