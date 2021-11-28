using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_take_2.Content.GameState
{
    public class splashscreen :GameState
    {
        KeyboardState keyboardState;
        SpriteFont spriteFont;
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
            if (spriteFont == null)
            {
                spriteFont = content.Load<SpriteFont>("Font/game");
            }
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Z))
                ScreenManager.Instance.AddScreen(new Start());
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.DrawString(spriteFont, "SplashScreen", new Vector2(100, 100), Color.Black);
        }
        //private Texture2D splashscreenTexture;
        //private Vector2 position;
        //private double timer;
        //private bool splash;
        //public void LoadContent(ContentManager content)
        //{
        //    splashscreenTexture = content.Load<Texture2D>("Gamescreens/SplashTemp");
        //    timer = 0;
        //    splash = true;
        //}
        //public bool Splash { get { return splash; }}
        //public void Draw(SpriteBatch _spriteBatch)
        //{
        //    _spriteBatch.Draw
        //        (
        //            splashscreenTexture,
        //            position,
        //            Color.White
        //        );
        //}
        //public void update(GameTime gameTime)
        //{
        //    timer++;
        //    if (timer == 250)
        //    {
        //        splash = false;
        //    }
        //}
    }
}
