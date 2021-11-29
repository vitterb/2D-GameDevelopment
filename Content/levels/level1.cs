using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using project_take_2.Content.Backgrounds;
using project_take_2.Content.Enemies;
using project_take_2.Content.Hero;

namespace project_take_2.Content.levels
{
    public class Level1
    {
        #region variables
        private Wolf wolf;
        private Eagle eagle;
        public Character hero;
        private BackgroundDarkMystery background1;
        private ContentManager _content;
        private bool levelActive = false;
        #endregion
        #region properties
        public bool LevelActive { get { return levelActive; } set { levelActive = value; } }
        #endregion
        #region Constructor
        public Level1()
        {
            hero = new Character(10, 650, 200, 200);
            eagle = new Eagle(20, 400, 150, 150);
            wolf = new Wolf(500, 710, 200, 200);
            background1 = new BackgroundDarkMystery();

        }
        #endregion
        #region Methodes
        public void ResetLevel()
        {
            Character.live = true;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            background1.DrawSky(_spriteBatch);
            background1.DrawBackground(_spriteBatch);
            background1.DrawMiddle(_spriteBatch);
            background1.DrawForeGround(_spriteBatch);
            hero.Draw(_spriteBatch);
            eagle.Draw(_spriteBatch);
            wolf.Draw(_spriteBatch);
            background1.DrawGround(_spriteBatch);
        }
        public void LoadContent(ContentManager Content)
        {
            _content = new ContentManager(Content.ServiceProvider, "Content");
            hero.LoadContent(_content);
            eagle.LoadContent(_content);
            wolf.LoadContent(_content);
            background1.LoadContent(_content);
        }
        public void UnloadContent() 
        {
            _content.Unload();
        }
        public void update(GameTime gameTime)
        {
            hero.update(gameTime);
            eagle.update(gameTime);
            wolf.update(gameTime);
        }
        #endregion
    }
}
