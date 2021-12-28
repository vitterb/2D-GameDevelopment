using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using project_take_2.Content.Sounds;

namespace project_take_2.Content.GameState
{
    public class Splashscreen
    {
        #region Variables
        private Texture2D splashscreenTexture;
        private Rectangle position;
        private double timer;
        private bool splash;
        private ContentManager _content;
        #endregion

        #region proporties
        public bool Splash { get { return splash; } } 
        #endregion

        #region Constructor
        public Splashscreen()
        {
            timer = 0;
            splash = true;
            position = new Rectangle(0, 0, Game1.screenW, Game1.screenH);
        }
        #endregion

        #region methodes
        public void LoadContent(ContentManager content)
        {
            _content = new ContentManager(content.ServiceProvider, "Content");
            splashscreenTexture = _content.Load<Texture2D>("Gamescreens/Logo");
        }
        public void UnloadContent()
        {
            _content.Unload();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw
                (
                    splashscreenTexture,
                    position,
                    Color.White
                );
            _spriteBatch.End();
        }
        public void update(GameTime gameTime)
        {
            timer++;
            if (timer == 250)
            {
                splash = false;
            }
        } 
        #endregion
    }
}
