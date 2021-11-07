using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using project_take_2.Content.Enemies;
using project_take_2.Content.Hero;
using project_take_2.Content.Input;

namespace project_take_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private KeyInput keyInput;

        private const int ScreenW = 1440, ScreenH = 900;

        private Wolf wolf;
        private Texture2D wolfSprite;

        public static  Bear bear;
        private Texture2D bearSprite;

        private Eagle eagle;
        private Texture2D eagleSprite;

        private Hero hero;
        private Texture2D heroSprite;
        private Texture2D heroSpriteIdle;
        private Texture2D heroSpriteDie;

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
            wolfSprite = Content.Load<Texture2D>("Sprites/wolf2");
            bearSprite = Content.Load<Texture2D>("Sprites/bear");
            eagleSprite = Content.Load<Texture2D>("Sprites/Eagle");
            heroSprite = Content.Load<Texture2D>("Sprites/heroPosibility1");
            heroSpriteIdle = Content.Load<Texture2D>("Sprites/heroPosibilityIdle");
            heroSpriteDie = Content.Load<Texture2D>("Sprites/heroPosibilityDie");

            keyInput = new KeyInput();


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            keyInput.Update();

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
