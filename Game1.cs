using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using project_take_2.Content.Enemies;
using project_take_2.Content.Hero;
using project_take_2.Content.Input;
using project_take_2.Content.levels;

namespace project_take_2
{
    public class Game1 : Game
    {
        public static  GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private KeyInput keyInput;

        private const int ScreenW = 1440, ScreenH = 900;

        private Wolf wolf;
        private Eagle eagle;
        private Bear bear;
        private Hero hero;

        private Texture2D testblock;
        public static  Rectangle testblockRec;

        public static Color testcolor = Color.Azure;
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
            // TODO: use this.Content to load your game content here

            hero = new Hero(10, 10, 150, 150);
            hero.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            hero.update(gameTime);

            keyInput.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            hero.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
