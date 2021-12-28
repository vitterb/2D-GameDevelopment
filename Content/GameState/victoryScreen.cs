using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using project_take_2.Content.Hero;
using project_take_2.Content.Sounds;


namespace project_take_2.Content.GameState
{
    internal class victory_screen
    {
        // photograph source == https://www.huffingtonpost.co.uk/entry/hunters-rabbit-blog-team-pls-publish-friday-mar_uk_5aafef1ce4b055a5f56358e5
        #region variables
        private Texture2D victoryScreenTexture;
        private Rectangle position;
        private bool victoryScreen;
        private ContentManager _content;
        private SpriteFont font;
        private string victoryString = "          Victory";
        private Vector2 victoryPosition;
        #endregion

        #region proporties
        public bool VictoryScreen { get { return victoryScreen; } set { victoryScreen = value; } }
        #endregion

        #region constructor
        public victory_screen()
        {
            victoryScreen = false;
            position = new Rectangle(0, 0, Game1.screenW, Game1.screenH);
            victoryPosition = new Vector2(Game1.screenW/2, Game1.screenH - Game1.screenH/3);
        }
        #endregion

        #region methodes
        public void LoadContent(ContentManager content)
        {
            _content = new ContentManager(content.ServiceProvider, "Content");
            victoryScreenTexture = _content.Load<Texture2D>("Gamescreens/rabbit campfire");
            font = _content.Load<SpriteFont>("Font/Game");
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
                    victoryScreenTexture,
                    position,
                    Color.White
                );
            _spriteBatch.DrawString
                (font, victoryString, victoryPosition, Color.Azure);
            _spriteBatch.End();
        }
        public void update(GameTime gameTime)
        {
            if (Character.victory)
            {
                victoryScreen = true;
            }
        }
        #endregion
    }
}
