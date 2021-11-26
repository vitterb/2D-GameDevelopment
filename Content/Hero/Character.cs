using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using project_take_2.Content.Animation;
using project_take_2.Content.Enemies;
using project_take_2.Content.interfaces;


namespace project_take_2.Content.Hero
{
    public class Character : IHero
    {
        #region variables 

        private Texture2D _texture;
        private Texture2D _textureIdle;
        private Texture2D _textureDie;
        private Texture2D _textureJump;
        private HeroAnimation _heroAnimation;
        private RectangleF hitbox;
        public static RectangleF positionAndSize;
        public static RectangleF velocity;
        public static bool live = true;
        public static bool hasJumped = false;
        private int counter = 0;
        private int counter2 = 1;
        private readonly int OffsetX = 25;
        private readonly int _width;
        private readonly int _height;
        private readonly int _x;
        private readonly int _y;
        private SpriteEffects flip = SpriteEffects.None;
        private SpriteFont font;
        private Vector2 middle;
        private string gameOver = "GAME OVER";

        #endregion

        #region Constructor
        public Character( int x, int y, int width, int height)
        {   
            _width = width;
            _height = height;
            _x = x;
            _y = y;
            positionAndSize = new RectangleF(_x, _y, _width, _height);
            hitbox = new Rectangle(0, 0, _width, _height);
            _heroAnimation = new HeroAnimation();
        }
        #endregion region

        #region Methodes
        public void LoadContent(ContentManager Content)
        {
            _texture = Content.Load<Texture2D>("Sprites/heroPosibility1");
            _textureIdle = Content.Load<Texture2D>("Sprites/heroPosibilityIdle");
            _textureDie = Content.Load<Texture2D>("Sprites/heroPosibilityDie");
            _textureJump = Content.Load<Texture2D>("Sprites/heroPosibilityJump");
            font = Content.Load<SpriteFont>("Font/gameOver");
            middle = new Vector2((Game1._graphics.PreferredBackBufferWidth - (gameOver.Length*128))/2 , (Game1._graphics.PreferredBackBufferHeight - 128) /2);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left)&& live && hasJumped == false)
            {
                MoveDraw(_spriteBatch);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && live && hasJumped == false )
            {
                MoveDraw(_spriteBatch);
            }
            if (hasJumped == true && live)
            {
                JumpDraw(_spriteBatch);
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down) && live && hasJumped == false)
            {
                IdleDraw(_spriteBatch);
            }
            if (!live)
            {
                DieDraw(_spriteBatch);
            }
        }
        private void MoveDraw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                _texture,
                (Rectangle)positionAndSize,
                _heroAnimation.Walk.currentFrame.Source,
                Color.White,
                0,
                new Vector2(0, 0),
                flip,
                0);
        }
        private void JumpDraw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                _textureJump,
                (Rectangle)positionAndSize,
                _heroAnimation.Jump.currentFrame.Source,
                Color.White,
                0,
                new Vector2(0, 0),
                flip,
                0);
        }
        private void IdleDraw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                _textureIdle,
                (Rectangle)positionAndSize,
                _heroAnimation.Idle.currentFrame.Source,
                Color.White,
                0,
                new Vector2(0, 0),
                flip,
                0);
        }
        private void DieDraw(SpriteBatch _spriteBatch)
        {
            // TODO naar update
            counter2++;
            counter++;
            if (counter2 > 10)
            {
                counter = 9;
            }
            _spriteBatch.Draw(
                _textureDie,
                (Rectangle)positionAndSize,
                _heroAnimation.Death[counter],
                Color.White,
                0,
                new Vector2(0, 0),
                flip,
                0);
            _spriteBatch.DrawString(font, gameOver, middle, Color.DarkRed);
        }
        public void update(GameTime gameTime)
        {
            hitboxUpdate();

            positionAndSize.X += velocity.X;
            positionAndSize.Y += velocity.Y;

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && live )
            {
                flip = SpriteEffects.FlipHorizontally;
                _heroAnimation.Walk.Update(gameTime, 10);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && live )
            {
                flip = SpriteEffects.None;
                _heroAnimation.Walk.Update(gameTime, 10);
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down)&& live && hasJumped == false )
            {
                _heroAnimation.Idle.Update(gameTime, 6);
            }
            if (hitbox.Intersects(Bear.hitbox) || hitbox.Intersects(Wolf.hitbox)|| hitbox.Intersects(Eagle.hitbox) ||!live)
            {
                live = false;
            }
            // source = Youtube User == Oyyou 
            if(hasJumped == true)
            {                
                _heroAnimation.Jump.Update(gameTime, 6);
            }
            if (hasJumped == false)
            {
                velocity.Y = 0f;
            }
            if (positionAndSize.Y + positionAndSize.Height >= 850)
            {
                hasJumped = false;
            }
        }
        private void hitboxUpdate()
        {
            hitbox.X = positionAndSize.X + OffsetX;
            hitbox.Y = positionAndSize.Y;
            hitbox.Width = positionAndSize.Width - OffsetX ;
            hitbox.Height = positionAndSize.Height ;
        }
        #endregion
    }
}
