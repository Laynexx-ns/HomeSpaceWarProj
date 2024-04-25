using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HomeSpaceWarProj.Classes;
using HomeSpaceWarProj.Classes.Additionary;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Content;
using SpaceWar.Classes;

namespace HomeSpaceWarProj
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Mine mine;
        
        

        //Дополнительно
        int screenwidth;
        int screenheight;
        private int mineAmount;

        MainMenu mainMenu;
        public static GameMode gameMode;
        

        //objects
        Player player;
        BackGround backGround;
        private List<Mine> mines;
        private List<Explosion> explosions;
        HUD hud;
        GameOver gameOver;

        Label labelscore;
        int count = 0;




        public Game1()
        {
            screenwidth = 800;
            screenheight = 450;


            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            _graphics.PreferredBackBufferHeight = screenheight;
            _graphics.PreferredBackBufferWidth = screenwidth;
            
        }

        protected override void Initialize()
        {
            mineAmount = 18;

            gameMode = GameMode.Menu;
            mainMenu = new MainMenu();
            player = new Player(screenwidth, screenheight);
            backGround = new BackGround();
            mines = new List<Mine>();
            explosions = new List<Explosion>();
            labelscore = new Label($"Score: {count}", new Vector2(650,  10), Color.White);    
            hud = new HUD();
            gameOver = new GameOver();

            player.TakeDamage += hud.ReactionOnPlayerTakeDamage;
            base.Initialize();
        }

        public void Reset(ContentManager manager)
        {
            player.Reset(screenwidth, screenheight);
            backGround.Reset();
            hud.Reset(manager);
            mines = new List<Mine>();
            explosions = new List<Explosion>();
            LoadContent();
            count = 0;
            
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            backGround.LoadContent(Content);
            player.LoadContent(Content);
            labelscore.LoadContent(Content);
            mainMenu.LoadContent(Content);
            hud.LoadContent(Content);
            gameOver.LoadContent(Content);
            
            for (int i = 0; i< mineAmount; i++)
            {
                GenerateMine();
            }
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch (gameMode)
            {
                case GameMode.Menu:
                    mainMenu.Update();
                    break;
                case GameMode.Playing:        
                    player.Update(Content, gameTime);
                    backGround.Update();
                    MineUpdate(gameTime);
                    UpdateExplosions(gameTime);
                    CheckCollision();
                    labelscore.Update($"Score: {count}");
                    
                    break;
                case GameMode.Exit:
                    Exit();
                    break;
                case GameMode.GameOver:
                    gameOver.Update();
                     break;
                case GameMode.Reset:
                    Reset(Content);
                    gameMode = GameMode.Playing;
                    break;
            }
            
            /*foreach(var m in mines)
            {
                m.Update();
            }*/

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();


            switch (gameMode)
            {
                case GameMode.Menu:
                    mainMenu.Draw(_spriteBatch);
                    break;
                case GameMode.Playing:
                    backGround.Draw(_spriteBatch);
                    player.Draw(_spriteBatch);

                    foreach (var m in mines)
                    {
                        m.Draw(_spriteBatch);
                    }
                    foreach (var exp in explosions)
                    {
                        exp.Draw(_spriteBatch);
                    }
                    labelscore.Draw(_spriteBatch, Color.Thistle);
                    hud.Draw(_spriteBatch);
                    break;
                case GameMode.Exit:
                    break;
                case GameMode.GameOver:
                    gameOver.Draw(_spriteBatch);
                    
                  
                    break;
            }
            
            

            _spriteBatch.End();
            base.Draw(gameTime);
        }



        private void GenerateMine()
        {
            
            Random random = new Random();

            float speed = random.Next(6, 12);
            float Yspeed = random.Next(-1, 2);
            Mine mine = new Mine(speed, Yspeed);
            
            mine.LoadContent(Content);
         
            int posX = random.Next(0, 800) + 800 + mine.TextureWidth;
            int posY = random.Next(0, 450 - mine.TextureHeight);

            mine.PositionX = posX;
            mine.PositionY = posY;
                
            mines.Add(mine);
            
        }

        public void MineUpdate(GameTime gameTime)
        {
            for (int i = 0; i < mines.Count; i++)
            {
                Mine m = mines[i];
                if (m.PositionX < 0 - m.TextureWidth)
                {
                    mines.Remove(m);
                    GenerateMine();
                    i--;
                }
                m.Update(gameTime);
                if (m.IsAlive == false)
                {
                    mines.Remove(m);
                    i--;
                    GenerateMine();
                }

            }

            
        }
       


        public void CheckCollision()
        {
            foreach (Mine m in mines)
            {
                foreach (Laser l in player.laserlist)
                {
                    if (l.Collision.Intersects(m.Collision))
                    {
                        m.IsAlive = false;
                        l.IsAlive = false;
                        SetExplosion(new Vector2(m.PositionX, m.PositionY));
                        count++;
                    }

                }
                if (m.Collision.Intersects(player.Collision))
                {
                    m.IsAlive = false;
                    SetExplosion(new Vector2(m.PositionX, m.PositionY));
                    player.Damage();
                }
                //if (m.Collision.Intersects(plauyer.Collision))
               
            }
        }
        public void SetExplosion(Vector2 position)
        {
            Explosion exp = new Explosion(position);
            exp.LoadContent(Content);
            explosions.Add(exp);
            
        }
        public void UpdateExplosions(GameTime gameTime)
        {
            for (int i = 0; i <  explosions.Count; i++)
            {
                Explosion e = explosions[i];
                e.Update(gameTime);
                if (e.IsAlive == false)
                {
                    explosions.Remove(e);
                    i -= 1;
                }
            }
        }



    }
}