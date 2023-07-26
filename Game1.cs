using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DruidsQuest.Content.GameState;
using DruidsQuest.Content.Input;
using DruidsQuest.Content.levels;

namespace DruidsQuest
{
    public class Game1 : Game
    {
        #region variables
        public static  GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private KeyInput keyInput;
        public static int 
            screenW, 
            screenH;
        private GameState game;
        #endregion
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            screenW = _graphics.PreferredBackBufferWidth;
            screenH = _graphics.PreferredBackBufferHeight;
            _graphics.ApplyChanges();
            Window.AllowUserResizing = false;
            Window.AllowAltF4 = true;
            Window.Title = "Awesome Game";

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            keyInput = new KeyInput();
            game = new GameState();
            game.LoadContent(Content);

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            game.Update(gameTime);
            
            keyInput.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
                game.Draw(_spriteBatch);
            base.Draw(gameTime);
        }
    }
}
