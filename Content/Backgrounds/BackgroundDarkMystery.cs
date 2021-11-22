using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace project_take_2.Content.Backgrounds
{
    public class BackgroundDarkMystery
    {
        #region variables
        protected Texture2D background;
        protected Texture2D foreground;
        protected Texture2D middle;
        protected Texture2D sky;
        protected Texture2D ground;
        protected Vector2 positionSky;
        protected Vector2 positionGround;
        protected Vector2 positionForeGround;
        protected Vector2 positionMiddle;
        protected Vector2 positionBackground;
        #endregion
        #region constructor
        public BackgroundDarkMystery() 
        {
            positionSky = new Vector2(0f);
            positionGround = new Vector2(0f,-25f);
            positionForeGround = new Vector2(0f, 5f);
            positionMiddle = new Vector2(0f);
            positionBackground = new Vector2(0f);
            
        }
        #endregion
        #region methodes
        public void LoadContent(ContentManager Content)
        {
            background = Content.Load<Texture2D>("Backgrounds/BG");
            foreground = Content.Load<Texture2D>("Backgrounds/Foreground");
            middle = Content.Load<Texture2D>("Backgrounds/Middle");
            sky = Content.Load<Texture2D>("Backgrounds/sky");
            ground = Content.Load<Texture2D>("Backgrounds/Ground_01");
        }

        public void DrawSky(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                sky,
                positionSky,
                Color.White
                );
        }
        public void DrawGround(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                ground,
                positionGround,
                Color.White
                );
        }
        public void DrawForeGround(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                foreground,
                positionForeGround,
                Color.White
                );
        }
        public void DrawMiddle(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                middle,
                positionMiddle,
                Color.White
                );
        }
        public void DrawBackground(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                background,
                positionBackground,
                Color.White
                );
        }

        #endregion
    }
}
