﻿using System;
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
using SharpDX.Direct3D9;
using SharpDX.WIC;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using HomeSpaceWarProj.Classes.Additionary;

namespace HomeSpaceWarProj.Classes
{
    public class Player
    {
        private Texture2D texture;
        private Vector2 position;
        private int speed;
        private Rectangle desrect;

        Color green = Color.GreenYellow;
        Color red = Color.Red;
        public List<Laser> laserlist;

        

        

        private int time;
        private double anitime = 0;
        private double duration = 0.075;
        //skills
        private double skill_shotguntime;
        private double skill_attackspeedtime;
        private bool skill_shotgunCanBeUsed;
        private bool skill_attackspeedCanBeUsed;

        private int attackspeed = 25;

        private int xborder;

        private int currentframe;
        private const int framewidth = 115;
        private const int frameheigth = 69;

        //events
        public event Action TakeDamage;
        public event Action UseShotGun;
        public event Action UseAttackSpeed;
        //collision
        private Rectangle sourserect;



        //размеры окна
        int screenwidth;
        int screenheight;


        public Rectangle Collision
        {
            get { return desrect; }
        }


        public Player(int screenwidth, int screenheight)
        {
            xborder = 0;
            texture = null;
            position = new Vector2(10, 0);
            speed = 12;
            currentframe = 0;
            this.screenheight = screenheight;
            this.screenwidth = screenwidth;
            time = 0;
            laserlist = new List<Laser>();
            skill_shotguntime = 0;
            skill_attackspeedtime = 0;
            skill_shotgunCanBeUsed = true;
            skill_attackspeedCanBeUsed = true;
            attackspeed = 25;

            

        }

        public Player(Vector2 position, int xborder)  : this(800, 450)
        {
            this.position = position;
            this.xborder = xborder;
            
        }


        public void LoadContent(ContentManager manager)
        {
            
            texture = manager.Load<Texture2D>("shipAnimation");
            desrect = new Rectangle((int)position.X, (int)position.Y, framewidth, texture.Height);
        }
        public void Update(ContentManager manager, GameTime gameTime)
        {
            //
            
            
            
            //

            desrect.X = (int)position.X;
            desrect.Y = (int)position.Y;

            skill_shotguntime += gameTime.ElapsedGameTime.TotalSeconds;
            skill_attackspeedtime += gameTime.ElapsedGameTime.TotalSeconds;

            if (skill_shotguntime > 5)
            {
                skill_shotgunCanBeUsed = true;
            }
            if (skill_attackspeedtime > 10)
            {
                skill_attackspeedCanBeUsed = true;
            }
            if (!skill_attackspeedCanBeUsed && skill_attackspeedtime >=5)
            {
                attackspeed = 25;
            }

            ////anim
            Animation(gameTime);
            ////

            time++;
            if (time >= attackspeed)
            {
                time = 0;
                Laser laser = new Laser(position);
                laser.LoadContent(manager);
                laserlist.Add(laser);
            }
            //moving
            if (Keyboard.GetState().IsKeyDown(Keys.D) && position.X < screenwidth - framewidth)
            {
                position.X += speed;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && position.X > -10 && position.X > xborder)
            {
                position.X -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) && position.Y > 0)
            {
                position.Y -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && position.Y < screenheight - texture.Height)
            {
                position.Y += speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                if (skill_shotgunCanBeUsed)
                {
                    ShotGun_Blast(manager);
                    skill_shotgunCanBeUsed = false;
                    skill_shotguntime = 0;
                }
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                if (skill_attackspeedCanBeUsed)
                {
                    Skill_AttackSpeedBooster();
                    
                    skill_attackspeedCanBeUsed = false;
                    skill_attackspeedtime = 0;

                }

            }


            for (int i = 0; i < laserlist.Count; i++)
            {
                Laser l = laserlist[i];
                if (l.PositionX > screenwidth + texture.Width || l.IsAlive == false)
                {
                    laserlist.Remove(l);
                    i--;
                }
                else
                {
                    l.Update();
                }

                
            }
            sourserect = new Rectangle(currentframe * framewidth, 0, framewidth, frameheigth);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position ,sourserect, Color.White);
            

            
            

            foreach (Laser l in laserlist)
            {
                l.Draw(spriteBatch);
            }
            
        }

        public void Damage()
        {
            if (TakeDamage != null)
            {
                TakeDamage();
            }
        }

        public void Reset(int screenwidth, int screenheight)
        {
            texture = null;
            position = new Vector2(10, 0);
            speed = 12;
            currentframe = 0;
            this.screenheight = screenheight;
            this.screenwidth = screenwidth;
            time = 0;
            laserlist = new List<Laser>();
            skill_shotguntime = 0;
            skill_attackspeedtime = 0;
            skill_shotgunCanBeUsed = true;
            skill_attackspeedCanBeUsed = true;
            attackspeed = 25;

            
        }

        public void ShotGun_Blast(ContentManager manager)
        {
            
            int distanceY = -100;
            for (int i = 0; i < 10; i++)
            {
                Laser l = new Laser(new Vector2(position.X, position.Y + distanceY));
                l.LoadContent(manager);
                laserlist.Add(l);
                distanceY += 25;
            }
            if (UseShotGun != null)
            {
                UseShotGun();
            }


        }
        public void Skill_AttackSpeedBooster()
        {
            attackspeed = 4;
            if (UseAttackSpeed != null)
            {
                UseAttackSpeed();
            }
        }

        public void Animation(GameTime gameTime)
        {
            anitime += gameTime.ElapsedGameTime.TotalSeconds;
            if (anitime > duration)
            {
                currentframe++;
                anitime = 0;

            }

            if (currentframe > 7)
            {
                currentframe = 0;
            }
        }

    }
}
