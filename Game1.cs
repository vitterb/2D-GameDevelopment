using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using project_take_2.Content.GameState;
using project_take_2.Content.Input;

namespace project_take_2
{
    public class Game1 : Game
    {
        #region variables
        public static  GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private KeyInput keyInput;

        private const int ScreenW = 1440, ScreenH = 900;

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
            
            _graphics.PreferredBackBufferWidth = ScreenW;
            _graphics.PreferredBackBufferHeight = ScreenH;
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
           
            keyInput.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            game.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
