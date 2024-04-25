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


        //playerskills
        Label labelattackspeed;
        Label labelshotgun;

        Color green = Color.GreenYellow;
        Color red = Color.Red;

        double attackspeedtime;
        double shotguntime;

        bool rage;
        bool shotgun;


        public HUD()
        {
            currentHeartCount = 5;
            heartpos = new Vector2(0, 10);
            labelattackspeed = new Label("Rage: 0", new Vector2(10, 400), Color.GreenYellow);
            labelshotgun = new Label("Shotgun: 0", new Vector2(200, 400), Color.GreenYellow);
            attackspeedtime = 0;
            shotguntime = 0;
            rage = false;
            shotgun = false;
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

        public void ReactionOnPlayerRage()
        {
            rage = true;
        }
        public void ReactionOnPlayerShotGun()
        {
            shotgun = true;
        }

        public void Update(GameTime gameTime)
        {

            if (rage)
            {
                attackspeedtime += gameTime.ElapsedGameTime.TotalSeconds;
                labelattackspeed.Update($"Rage: {((int)(10 - attackspeedtime)).ToString()}");
                if ((10 - attackspeedtime) < 0)
                {
                    rage = false;
                    attackspeedtime = 0;
                }
            }
            else
            {
                labelattackspeed.Update("Shotgun: 0");
            }
            if (shotgun)
            {
                shotguntime += gameTime.ElapsedGameTime.TotalSeconds;
                labelshotgun.Update($"Shotgun: {((int)(5 - shotguntime)).ToString()}");
                if ((5 - shotguntime) < 0)
                {
                    shotgun = false;
                    shotguntime = 0;
                }
            }
            else
            {
                labelshotgun.Update("Shotgun: 0");
            }

            
            
            
            
         
        }
        
        public void LoadContent(ContentManager manager)
        {
            
            for (int i = 0; i < maxHeartsCount; i++)
            {
                HealthHeart heart = new HealthHeart(new Vector2(25 * i+1, heartpos.Y));
                heart.LoadContent(manager);
                hearts.Add(heart);
            }
            labelshotgun.LoadContent(manager);
            labelattackspeed.LoadContent(manager);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < currentHeartCount; i++)
            {
                hearts[i].Draw(spriteBatch);
            }
            if (!rage)
            {
                labelattackspeed.Draw(spriteBatch, green);
            }
            else
            {
                labelattackspeed.Draw(spriteBatch, red);
            }

            if (!shotgun)
            {
                labelshotgun.Draw(spriteBatch, green);
            }
            else
            {
                labelshotgun.Draw(spriteBatch, red);
            }
        }

        public void Reset(ContentManager manager)
        {
            currentHeartCount = maxHeartsCount;
            heartpos = new Vector2(0, 10);
            
            LoadContent(manager);
            currentHeartCount = 5;
            heartpos = new Vector2(0, 10);
            labelattackspeed = new Label("Rage: 0", new Vector2(10, 400), Color.GreenYellow);
            labelshotgun = new Label("Shotgun: 0", new Vector2(200, 400), Color.GreenYellow);
            attackspeedtime = 0;
            shotguntime = 0;
            rage = false;
            shotgun = false;
        }

    }
}
