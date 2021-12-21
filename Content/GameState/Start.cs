using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace project_take_2.Content.GameState
{
    public class Start
    {
        #region variables
        private Texture2D 
            StartscreenTexture,
            buttonStartLevel1,
            buttonStartLevel2;
        private Rectangle 
            positionButton1,
            positionButton2;
        private Vector2
            lvlString1,
            lvlString2,
            gameString;
        private Rectangle
        StartScreenVector;
        private string 
            lv1 = "Level1",
            lv2 = "Level2",
            gameTitle = "DruidsQuest";
        private SpriteFont 
            font;
        private bool
            menu = true,
            button1 = false,
            button2 = false;
        private MouseState 
            mouseState;
        private Color 
            color1,
            color2;
        private ContentManager _content;

        #endregion

        #region properties
        public bool Menu { get { return menu; } set { menu = value; } }
        public  bool Button1 {get { return button1; } set { button1 = value; }}
        public bool Button2 { get { return button2; } set { button2 = value; }}
        #endregion

        #region Constructor
        public Start()
        {
            positionButton1 = new Rectangle(150, 200, 100, 100);
            positionButton2 = new Rectangle(550, 200, 100, 100);
            lvlString1 = new Vector2(100, 310);
            lvlString2 = new Vector2(500, 310);
            gameString = new Vector2(Game1.screenW / 4, 100);
            StartScreenVector = new Rectangle(0, 0,Game1.screenW, Game1.screenH);
            color1 = Color.White;
            color2 = Color.White;
        }
        #endregion

        #region methodes
        public void LoadContent(ContentManager content)
        {
            _content = new ContentManager(content.ServiceProvider, "Content");
            StartscreenTexture = _content.Load<Texture2D>("BackGrounds/Cartoon_Forest_BG_01");
            buttonStartLevel1 = _content.Load<Texture2D>("buttons/map");
            buttonStartLevel2 = _content.Load<Texture2D>("buttons/bag");
            font = _content.Load<SpriteFont>("Font/game");
        }
        public void Draw(SpriteBatch _spritebatch) 
        {
            _spritebatch.Begin();
            _spritebatch.Draw(StartscreenTexture,StartScreenVector,Color.White);
            _spritebatch.Draw(buttonStartLevel1,positionButton1, color1);
            _spritebatch.Draw(buttonStartLevel2, positionButton2, color2);
            _spritebatch.DrawString(font, lv1,lvlString1, Color.Azure);
            _spritebatch.DrawString(font, lv2,lvlString2, Color.Azure);
            _spritebatch.DrawString(font, gameTitle,gameString,Color.Azure);
            _spritebatch.End();
        }
        public void Update(GameTime gameTime) 
        {
            mouseState = Mouse.GetState();
            var mouseRect = new Rectangle(mouseState.X, mouseState.Y, 1, 1);

            if (mouseRect.Intersects(positionButton1))
            {
                color1 = Color.Gold;
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    menu = false;
                    button1 = true;
                }
            }
            else 
                color1 = Color.White;
            if (mouseRect.Intersects(positionButton2))
            {
                color2 = Color.Gold;
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    menu = false;
                    button2 = true;
                }
            }
            else
                color2 = Color.White; 
        }
        #endregion
    }
}
