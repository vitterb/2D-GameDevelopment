using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace project_take_2.Content.GameState
{
    public class Start : GameState
    {
        #region variables
        //private Texture2D StartscreenTexture;
        //private Texture2D buttonStartLevel1;
        //private Texture2D buttonStartLevel2;
        //private Rectangle positionButton1;
        //private Rectangle positionButton2;
        //private Vector2 lvl1;
        //private Vector2 lvl2;
        //private Vector2 StartScreenVector;
        //private string lv1 = "Level1";
        //private string lv2 = "Level2";
        //private SpriteFont font;
        //private bool start = true;
        //private bool start1 = false;
        //private bool start2 = false;
        //private MouseState mouseState;
        //private Color color1;
        //private Color color2;
        KeyboardState keyboardState;
        SpriteFont spriteFont;

        #endregion
        #region propo
        //public bool Startmenu { get { return start; } set { start = value; } }
        //public  bool Start1 {get { return start1; } set { start1 = value; }}

        //public bool Start2 { get { return start2; } }
        #endregion
        #region methodes
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
            if (spriteFont == null)
            {
                spriteFont = content.Load<SpriteFont>("Font/game");
            }
            //StartscreenTexture = content.Load<Texture2D>("BackGrounds/Cartoon_Forest_BG_01");
            //buttonStartLevel1 = content.Load<Texture2D>("buttons/map");
            //buttonStartLevel2 = content.Load<Texture2D>("buttons/bag");
            //positionButton1 = new Rectangle(300, 200, 200, 200);
            //positionButton2 = new Rectangle(940,200,200,200);
            //lvl1 = new Vector2(300, 450);
            //lvl2 = new Vector2(940, 450);
            //StartScreenVector = new Vector2(0, 0);
            //font = content.Load<SpriteFont>("Font/game");
            //color1 = Color.White;
            //color2 = Color.White;   
        }
        public override void Draw(SpriteBatch _spriteBatch) 
        {
                _spriteBatch.DrawString(spriteFont, "TitleScreen", new Vector2(100, 100), Color.Black);
            //_spritebatch.Draw(StartscreenTexture,StartScreenVector,Color.White);
            //_spritebatch.Draw(buttonStartLevel1,positionButton1, color1);
            //_spritebatch.Draw(buttonStartLevel2, positionButton2, color2);
            //_spritebatch.DrawString(font, lv1, lvl1, Color.Azure);
            //_spritebatch.DrawString(font, lv2, lvl2, Color.Azure);
        }
        public override void Update(GameTime gameTime) 
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Enter))
                ScreenManager.Instance.AddScreen(new splashscreen());
            //mouseState = Mouse.GetState();
            //var mouseRect = new Rectangle(mouseState.X, mouseState.Y, 1, 1);

            //if (mouseRect.Intersects(positionButton1))
            //{
            //    color1 = Color.Gold;

            //    if (mouseState.LeftButton == ButtonState.Pressed)
            //    {
            //        start = false;
            //        start1 = true;
            //    }
            //}
            //else { color1 = Color.White; }
            //if (mouseRect.Intersects(positionButton2))
            //{
            //    color2 = Color.Gold;
            //}
            //else { color2 = Color.White; }
        }
        #endregion
    }


}
