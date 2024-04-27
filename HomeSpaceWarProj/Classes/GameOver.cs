using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HomeSpaceWarProj.Classes.Additionary;
using HomeSpaceWarProj.Classes;
using System.Diagnostics.SymbolStore;

namespace HomeSpaceWarProj.Classes
{
    public class GameOver
    {
        private Texture2D texture;
        private Label labelend;
        private Label labelscore;
        public GameOver()
        {
            texture = null;
            labelend = new Label("P R E S S   S P A C E    T O   R E S T A R T", new Vector2(170, 200), Color.White);
            labelscore = new Label($"Your score was", new Vector2(170, 240), Color.White);

        }
        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("endMenu");
            labelend.LoadContent(manager);
            labelscore.LoadContent(manager);
        }

        public void Update(int count)
        {
            KeyboardState keystate = Keyboard.GetState();
            if (keystate.IsKeyDown(Keys.Space))
            {
                Game1.gameMode = SpaceWar.Classes.GameMode.Menu;
            }
            labelscore.Update($"Your score was: {count}");
                
            
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, new Vector2(0, 0), Color.White);
            labelend.Draw(spritebatch, Color.Bisque);
            labelscore.Draw(spritebatch, Color.Bisque);
        }
    }
}
