﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using project_take_2.Content.Hero;
using project_take_2.Content.levels;


namespace project_take_2.Content.GameState
{
    public class GameState
    {
        private splashscreen splash;
        private Start start;
        private level1 lv1;
        private int counter = 1;
        protected ContentManager content;
        public GameState() { }
        public void Initialize() { }

        public virtual void Draw(SpriteBatch _spriteBatch)
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
                if (!Character.live)
                {
                    if (counter == 1000)
                    {
                        start.Start1 = false;
                        start.Startmenu = true;
                        Character.live = true;
                        Character.positionAndSize = new Rectangle(10, 650, 200, 200);
                    }
                }
            }
        }
        public virtual void Update(GameTime gameTime)
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
            if (!Character.live)
            {
                counter++;
            }
        }
        public virtual void LoadContent(ContentManager Content)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
        }
        public virtual void UnloadContent()
        {
            content.Unload();
        } 
    }
}
