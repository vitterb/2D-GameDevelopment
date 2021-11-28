using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_take_2.Content.GameState
{
    public class splashscreen
    {
        private Texture2D splashscreenTexture;
        private Vector2 position;
        private double timer;
        private bool splash;
        public void LoadContent(ContentManager content)
        {
            splashscreenTexture = content.Load<Texture2D>("Gamescreens/SplashTemp");
            timer = 0;
            splash = true;
        }
        public bool Splash { get { return splash; }}
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw
                (
                    splashscreenTexture,
                    position,
                    Color.White
                );
        }
        public void update(GameTime gameTime)
        {
            timer++;
            if (timer == 250)
            {
                splash = false;
            }
        }
    }
}
