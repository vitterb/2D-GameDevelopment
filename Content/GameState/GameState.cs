using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using DruidsQuest.Content.Hero;
using DruidsQuest.Content.levels;

namespace DruidsQuest.Content.GameState
{
    public class GameState
    {
        #region Variables
        private readonly Splashscreen splash;
        private readonly victory_screen victory;
        private readonly Start start;
        private Level1 lv1;
        private Level2 lv2;
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
                splash.Draw(_spriteBatch);
            else if (!splash.Splash)
            {
                if (start.Menu)
                    start.Draw(_spriteBatch);
                else if (victory.VictoryScreen)
                    victory.Draw(_spriteBatch);
                else if (lv1.Level1Active && !lv2.Level2Active)
                    lv1.Draw(_spriteBatch);
                else if (lv2.Level2Active && !lv1.Level1Active)
                    lv2.Draw(_spriteBatch);
            }
        }
        public void Update(GameTime gameTime)
        {
            if (splash.Splash)
                splash.update(gameTime);
            else
                splash.UnloadContent();
            if (start.Menu)
                start.Update(gameTime);
            if (start.Button1)
            {
                loadLevel1();
                lv1.Level1Active = true;
            }
            if (lv1.Level1Active && !lv2.Level2Active)
                lv1.Update(gameTime);
            if (start.Button2)
            { 
                LoadLevel2();
                lv2.Level2Active = true;
            }
            if (lv2.Level2Active && !lv1.Level1Active)
                lv2.Update(gameTime);
            if (!Character.live || Character.victory)
            {
                if(Character.victory)
                victory.VictoryScreen = true;
                counter++;
                if (counter >= 500)
                {
                    victory.VictoryScreen = false;
                    start.Menu = true;
                    if (lv1.Level1Active)
                    {
                        lv1.Level1Active = false;
                        lv1.ResetLevel();
                    }
                    if (lv2.Level2Active)
                    {
                        lv2.Level2Active = false;
                        lv2.ResetLevel2();
                    }
                    Character.victory = false;
                    lv1.Level1Active = false;
                    lv2.Level2Active = false;
                }
            }
            if (Character.live && !Character.victory)
                counter = 0;
        }
        public void LoadContent(ContentManager content)
        {
            _content = new ContentManager(content.ServiceProvider, "Content");
            splash.LoadContent(_content);
            start.LoadContent(content);
            lv1.LoadContent(content);
            lv2.LoadContent(content);
            victory.LoadContent(content);
        } 
        public void loadLevel1()
        {
            lv1.UnloadContent();
            lv1 = new Level1();
            lv1.LoadContent(_content);
            start.Button1 = false;
        }
        public void LoadLevel2()
        {
            lv2.UnLoadContent();
            lv2 = new Level2();
            lv2.LoadContent(_content);
            start.Button2 = false;
        }
        #endregion
    }
}
