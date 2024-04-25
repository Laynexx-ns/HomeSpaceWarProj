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
using HomeSpaceWarProj.Classes.Additionary;
using SpaceWar.Classes;

namespace HomeSpaceWarProj.Classes
{
    class HUD
    {
        List<HealthHeart> hearts = new List<HealthHeart>();
        private const int maxHeartsCount = 5;

        private int currentHeartCount;
 
        private Vector2 heartpos;

        public HUD()
        {
            currentHeartCount = 5;
            heartpos = new Vector2(0, 10);
        }

        public void ReactionOnPlayerTakeDamage()
        {
            currentHeartCount--;
            
            if (currentHeartCount > 0)
            {
                hearts.Remove(hearts[currentHeartCount]);
            }
            

            else Game1.gameMode = GameMode.GameOver;
        }
        
        public void LoadContent(ContentManager manager)
        {
            
            for (int i = 0; i < maxHeartsCount; i++)
            {
                HealthHeart heart = new HealthHeart(new Vector2(25 * i+1, heartpos.Y));
                heart.LoadContent(manager);
                hearts.Add(heart);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < currentHeartCount; i++)
            {
                hearts[i].Draw(spriteBatch);
            }
        }

        public void Reset(ContentManager manager)
        {
            currentHeartCount = maxHeartsCount;
            heartpos = new Vector2(0, 10);
            
            LoadContent(manager);
        }

    }
}
