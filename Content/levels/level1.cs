using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using project_take_2.Content.Backgrounds;
using project_take_2.Content.Enemies;
using project_take_2.Content.Hero;

namespace project_take_2.Content.levels
{
    public class level1
    {
        #region variables
        private Wolf wolf;
        private Eagle eagle;
        public Character hero;
        private BackgroundDarkMystery background1;

        #endregion

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
            hero = new Character(10, 650, 200, 200);
            hero.LoadContent(Content);
            eagle = new Eagle(20, 400, 150, 150);
            eagle.LoadContent(Content);
            wolf = new Wolf(500, 710, 200, 200);
            wolf.LoadContent(Content);
            background1 = new BackgroundDarkMystery();
            background1.LoadContent(Content);
        }
        public void update(GameTime gameTime) 
        {
            hero.update(gameTime);
            eagle.update(gameTime);
            wolf.update(gameTime);
        }

    }
}
