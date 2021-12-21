﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using project_take_2.Content.Hero;
using project_take_2.Content.levels;

namespace project_take_2.Content.GameState
{
    public class GameState
    {
        #region Variables
        private readonly Splashscreen splash;
        private readonly victory_screen victory;
        private readonly Start start;
        private readonly Level1 lv1;
        private readonly Level2 lv2;
        private int counter = 1;
        private ContentManager _content;

        #endregion
        #region Constructor
        public GameState()
        { 
            splash = new Splashscreen();
            start = new Start();
            lv1 = new Level1();
            lv2 = new Level2();
            victory = new victory_screen();
        }
        #endregion
        #region Methodes
        public void Draw(SpriteBatch _spriteBatch)
        {
            if (splash.Splash)
            {
                splash.Draw(_spriteBatch);
            }
            else if (!splash.Splash)
            {
                if (start.Menu)
                {
                    start.Draw(_spriteBatch);
                }
                else if (victory.VictoryScreen)
                {
                    victory.Draw(_spriteBatch);
                }
                else if (lv1.LevelActive)
                {
                    lv1.Draw(_spriteBatch);
                }

            }
        }
        public void Update(GameTime gameTime)
        {
            if (splash.Splash)
                splash.update(gameTime);
            else
                splash.UnloadContent();
            if (start.Menu)
            {
                start.Update(gameTime);
            }
            if (start.Button1)
            {
                lv1.LevelActive = true;
            }
            if (lv1.LevelActive)
            {
                lv1.update(gameTime);
            }
            if (!Character.live || Character.victory)
            {
                counter++;
                if (counter == 350)
                {
                    victory.VictoryScreen = false;
                    start.Menu = true;
                    lv1.LevelActive = false;
                    lv1.ResetLevel();
                }
            }
            if (Character.live && !Character.victory)
                counter = 0;
            if (Character.victory)
            {
                lv1.LevelActive = false;
                victory.VictoryScreen = true;
            }
        }
        public void LoadContent(ContentManager content)
        {
            _content = new ContentManager(content.ServiceProvider, "Content");
            splash.LoadContent(_content);
            start.LoadContent(content);
            lv1.LoadContent(content);
            victory.LoadContent(content);
        } 
        #endregion
    }
}
