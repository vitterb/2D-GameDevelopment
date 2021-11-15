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
        #region variables
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

            hero = new Hero(10, 400, 200, 200);
            hero.LoadContent(Content);
            eagle = new Eagle(20, 20, 100, 100);
            eagle.LoadContent(Content);
            wolf = new Wolf(500, 700, 100, 100);
            wolf.LoadContent(Content);
            bear = new Bear(900, 700,100,100);
            bear.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            hero.update(gameTime);
            eagle.update(gameTime);
            wolf.update(gameTime);
            bear.update(gameTime);

            keyInput.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            hero.Draw(_spriteBatch);
            eagle.Draw(_spriteBatch);
            wolf.Draw(_spriteBatch);
            bear.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
