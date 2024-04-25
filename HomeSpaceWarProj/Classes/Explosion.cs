using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace HomeSpaceWarProj.Classes
{
    public class Explosion
    {
        private Vector2 position;
        private Texture2D texture;
        private int framenumber;
        private double framewidth;
        private double frameheight;

        private bool isAlive;


        private double duration; 
        private double totalTime;

        private Rectangle sourect;

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public Explosion(Vector2 position)
        {
            this.position = position;
            duration = 0.05;
            frameheight = 134;
            framewidth = 135.5;
            framenumber = 0;
            isAlive = true;
        }

        public void LoadContent(ContentManager manger)
        {
            texture = manger.Load<Texture2D>("explosion");
        }
        public void Update(GameTime gameTime)
        {
            //12 кадров
            totalTime += gameTime.ElapsedGameTime.TotalSeconds;

            if (totalTime > duration)
            {
                framenumber++;
                totalTime = 0;

            }
            sourect = new Rectangle((int)framenumber * (int)framewidth, 0, (int)framewidth, (int)frameheight);

            if (framenumber > 12)
            {
                framenumber = 0;
                isAlive = false;
            }

        }
        public void Draw(SpriteBatch spritebatch)
        {
           spritebatch.Draw(texture, new Vector2(position.X - texture.Width/2/12, position.Y - texture.Height/2 + 30), sourect, Color.White);
        }

    }
}
