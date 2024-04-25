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

namespace HomeSpaceWarProj.Classes
{
    public class Mine
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle desrect;

        private bool isAlive;
        private float Xspeed;
        private float Yspeed;

        int framewidth;
        int frameheight;

        private Rectangle sourcerect;

        //animation values
        double anitime = 0;
        double duration = 0.075;
        int framenumber;


        public int TextureHeight
        {
            get { return texture.Height; }
        }
        public int TextureWidth
        {
            get {return framewidth;}
        }
        public int PositionX
        {
            get { return (int)position.X; }
            set { position.X = value; }
            
        }
        public int PositionY
        {
            get { return (int)position.Y; }
            set { position.Y = value; }
        }
        public Rectangle Collision
        {
            get { return desrect; }
        }
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }



        
        public Mine(float Xspeed, float Yspeed)
        {
            texture = null;
            this.Xspeed = Xspeed;
            this.Yspeed = Yspeed;
            isAlive = true;
            framenumber = 0;
            framewidth = 47;
            frameheight = 61;

        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("mineAnimation");
            desrect = new Rectangle(PositionX, PositionY, framewidth, TextureHeight);
        }

        public void Update(GameTime gameTime)
        {
            position.X -= Xspeed;
            position.Y -= Yspeed;
            desrect.X = (int)position.X;
            desrect.Y = (int)position.Y;

            anitime += gameTime.TotalGameTime.TotalSeconds;
            if (anitime > duration)
            {
                framenumber++;
                anitime = 0;
            }
            if (framenumber > 7)
            {
                framenumber = 0;
            }

            sourcerect = new Rectangle(framenumber * framewidth, 0, framewidth, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position,sourcerect,  Color.White);
        }

        public void Reset(float Xspeed, float Yspeed)
        {
            texture = null;
            this.Xspeed = Xspeed;
            this.Yspeed = Yspeed;
            isAlive = true;
            framenumber = 0;
            framewidth = 47;
            frameheight = 61;

        }
}
}
