using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using DruidsQuest.Content.Sounds;
using Druids_Quest.Content.Sounds;

namespace DruidsQuest.Content.GameState
{
    public class Splashscreen
    {
        #region Variables
        private Texture2D splashscreenTexture;
        private Rectangle position;
        private double timer;
        private bool splash;
        private ContentManager _content;
        private SplashScreenSound sound;
        private bool PlaySound = true;
        
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
            sound = new SplashScreenSound();   
        }
        #endregion

        #region methodes
        public void LoadContent(ContentManager content)
        {
            _content = new ContentManager(content.ServiceProvider, "Content");
            splashscreenTexture = _content.Load<Texture2D>("Gamescreens/Logo");
            sound.LoadContent(_content);

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
        public void Update(GameTime gameTime)
        {
            timer++;
            if (timer == 680)
            {
                splash = false;
            }
            if (PlaySound)
            {
                sound.Play();
                PlaySound = false;
            }
        } 
        #endregion
    }
}
