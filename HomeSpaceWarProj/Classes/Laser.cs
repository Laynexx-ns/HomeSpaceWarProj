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
using SharpDX.MediaFoundation.DirectX;

namespace HomeSpaceWarProj.Classes
{
    public class Laser
    {
        private Texture2D texture;
        private Vector2 position;    
        private Vector2 givenposition;
        private Rectangle desrect;

        private bool isAlive;

        private int speed;

        public int TextureWidth
        {
            get { return texture.Width; }
        }
        public int TextureHeight
        {
            get { return texture.Height; }
        }
        public int PositionX
        {
            get { return (int)position.X; }
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
        

        public Laser(Vector2 position)
        {
            speed = 20;
            texture = null;
            givenposition = position;
            desrect = new Rectangle(-200, -200, 0, 0);
            isAlive = true;
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("laser");
            this.position.X = givenposition.X + this.TextureWidth;
            this.position.Y = givenposition.Y + texture.Height;
            desrect.X = (int)givenposition.X + this.TextureWidth;
            desrect.Y = (int)givenposition.Y + texture.Height;
            desrect.Width = texture.Width; 
            desrect.Height = texture.Height;
        }
        public void Update()
        {
            position.X += speed;
            desrect.X = (int)position.X;

        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, position, color: Microsoft.Xna.Framework.Color.IndianRed);
        }

    }
}
