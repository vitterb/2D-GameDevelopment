using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        private const int ScreenW = 1024, ScreenH = 768;

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
            

            eagle = new Eagle(eagleSprite, 0, 0, 200, 200);
            wolf = new Wolf(wolfSprite, 0, 100, 200, 200);
            bear = new Bear(bearSprite, 300, 200, 200, 200);
            hero = new Hero(heroSprite,heroSpriteIdle,heroSpriteDie, 0, 400, 200, 200);
            keyInput = new KeyInput();


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            eagle.update(gameTime);
            wolf.update(gameTime);
            bear.update(gameTime);
            hero.update(gameTime);
            keyInput.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            
            eagle.Draw(_spriteBatch);
            wolf.Draw(_spriteBatch);
            bear.Draw(_spriteBatch);
            hero.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
