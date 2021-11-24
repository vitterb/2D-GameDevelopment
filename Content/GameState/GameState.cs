using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using project_take_2.Content.levels;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_take_2.Content.GameState
{
    public class GameState
    {
        private splashscreen splash;
        private Start start;
        private level1 lv1;

        public GameState()
        {
            splash = new splashscreen();
            start = new Start();
            lv1 = new level1();
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (splash.Splash)
            {
                splash.Draw(_spriteBatch);
            }
            else if (!splash.Splash)
            {
                if (start.Startmenu)
                {
                    start.Draw(_spriteBatch);
                }
                if (start.Start1)
                {
                    lv1.Draw(_spriteBatch);
                }
            }
            
        }
        public void Update(GameTime gameTime)
        {
            if (splash.Splash)
            {
                splash.update(gameTime);
            }
            if (start.Startmenu)
            {
                start.Update(gameTime);
            }
            if (start.Start1)
            {
                lv1.update(gameTime);
            }
        }
        public void LoadContent(ContentManager content)
        {
            splash.LoadContent(content);
            start.LoadContent(content);
            lv1.LoadContent(content);
        }
    }
}
