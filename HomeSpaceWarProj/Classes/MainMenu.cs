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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using SpaceWar.Classes;

namespace HomeSpaceWarProj.Classes
{
    public class MainMenu
    {
        private Label labelplay;
        private Label labelexit;
        private Label labelinfo;
        private List<Label> buttons;
        

        int selected;

        private KeyboardState prevKeyboardState;

        private Texture2D maintexture;

        public MainMenu()
        {
            buttons = new List<Label>();
            labelplay = new Label("P L A Y", new Vector2(370, 200), Color.White);
            buttons.Add(labelplay);

            labelinfo = new Label("I N F O", new Vector2(370, 240), Color.White);
            buttons.Add(labelinfo);

            labelexit = new Label("E X I T", new Vector2(370, 280), Color.White);
            buttons.Add(labelexit);
            selected = 0;
            
        }

        public void LoadContent(ContentManager manager)
        {
            
            foreach (Label l in buttons)
            {
                l.LoadContent(manager);
            }
            maintexture = manager.Load<Texture2D>("mainMenu");
        }

        public void Update()
        {
            

            KeyboardState keyboardState = Keyboard.GetState();
            if (prevKeyboardState.IsKeyDown(Keys.S) && keyboardState.IsKeyUp(Keys.S))
            {
                if (selected < buttons.Count -1) selected++;
            }

            if (prevKeyboardState.IsKeyDown(Keys.W) && keyboardState.IsKeyUp(Keys.W))
            {
                if (selected > 0) selected--;
            }

            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                if (selected == 0)
                {
                    Game1.gameMode = GameMode.Reset;


                }
                else if (selected == 1)
                {
                    Game1.gameMode = GameMode.Info;
                }
                else if (selected == 2)
                {
                    Game1.gameMode = GameMode.Exit;
                }
            }


            prevKeyboardState = keyboardState;




        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(maintexture, new Vector2(0, 0), Color.White);
            for (int i = 0; i < buttons.Count; i++) 
            {
                if (i == selected)
                {
                    buttons[i].Draw(spritebatch, Color.PeachPuff);
                }
                else
                {
                    buttons[i].Draw(spritebatch, Color.White);
                }
            }
            
        }

        public void Choosing(int choosed)
        {

        }

    }
}
