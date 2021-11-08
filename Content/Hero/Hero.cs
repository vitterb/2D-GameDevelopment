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
    public class Hero : IHero
    {
        #region variables 
        private Texture2D _texture;
        private Texture2D _textureIdle;
        private Texture2D _textureDie;
        private Texture2D _textureJump;
        private readonly AnimationClass animation;
        private readonly AnimationClass animationIdle;
        private readonly AnimationClass animationJump;
        private readonly Rectangle[] array = new Rectangle[10];
        private RectangleF hitbox;
        public static RectangleF positionAndSize;
        public static RectangleF velocity;
        public static bool live = true;
        public static bool hasJumped = false;
        private int counter = 0;
        private int counter2 = 1;
        private readonly int OffsetX = 25;
        private readonly int frameworkwidth = 250;
        private readonly int frameworkHeight = 200;
        private readonly int frameworkX = 300;
        private readonly int frameworkXb = 1133;
        private readonly int _width;
        private readonly int _height;
        private readonly int _x;
        private readonly int _y;
        private SpriteEffects flip = SpriteEffects.None;
        #endregion
        #region Constructor
        public Hero( int x, int y, int width, int height)
        {   
            _width = width;
            _height = height;
            _x = x;
            _y = y;

            animation = new AnimationClass();
            positionAndSize = new RectangleF(_x, _y, _width, _height);
            hitbox = new Rectangle(0, 0, _width, _height);
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 50, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 50, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 342, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 342, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 634, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 634, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 926, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 926, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 1218, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 1218, frameworkwidth, frameworkHeight)));
            animationIdle = new AnimationClass();
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 50, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 50, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 342, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 342, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 634, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 634, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 926, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 926, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 1218, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 1218, frameworkwidth, frameworkHeight)));
            animationJump = new AnimationClass();
            animationJump.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 50, frameworkwidth, frameworkHeight)));
            animationJump.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 50, frameworkwidth, frameworkHeight)));
            animationJump.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 342, frameworkwidth, frameworkHeight)));
            animationJump.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 342, frameworkwidth, frameworkHeight)));
            animationJump.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 634, frameworkwidth, frameworkHeight)));
            animationJump.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 634, frameworkwidth, frameworkHeight)));
            animationJump.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 926, frameworkwidth, frameworkHeight)));
            animationJump.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 926, frameworkwidth, frameworkHeight)));
            animationJump.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 1218, frameworkwidth, frameworkHeight)));
            animationJump.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 1218, frameworkwidth, frameworkHeight)));

            array[0] = new Rectangle(frameworkX, 50, frameworkwidth, frameworkHeight);
            array[1] = new Rectangle(frameworkXb, 50, frameworkwidth, frameworkHeight);
            array[2] = new Rectangle(frameworkX, 342, frameworkwidth, frameworkHeight);
            array[3] = new Rectangle(frameworkXb, 342, frameworkwidth, frameworkHeight);
            array[4] = new Rectangle(frameworkX, 634, frameworkwidth, frameworkHeight);
            array[5] = new Rectangle(frameworkXb, 634, frameworkwidth, frameworkHeight);
            array[6] = new Rectangle(frameworkX, 926, frameworkwidth, frameworkHeight);
            array[7] = new Rectangle(frameworkXb, 926, frameworkwidth, frameworkHeight);
            array[8] = new Rectangle(frameworkX, 1218, frameworkwidth, frameworkHeight);
            array[9] = new Rectangle(frameworkXb, 1218, frameworkwidth, frameworkHeight);
        }
        #endregion region
        #region Methodes
        public void LoadContent(ContentManager Content)
        {
            _texture = Content.Load<Texture2D>("Sprites/heroPosibility1");
            _textureIdle = Content.Load<Texture2D>("Sprites/heroPosibilityIdle");
            _textureDie = Content.Load<Texture2D>("Sprites/heroPosibilityDie");
            _textureJump = Content.Load<Texture2D>("Sprites/heroPosibilityJump");
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left)&& live && hasJumped == false)
            {
                MoveDraw(_spriteBatch);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && live && hasJumped == false)
            {
                MoveDraw(_spriteBatch);
            }
            if (hasJumped)
            {
                JumpDraw(_spriteBatch);
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down) && live)
            {
                IdleDraw(_spriteBatch);
            }
            if (hitbox.Intersects(Bear.hitbox))
            {
                DieDraw(_spriteBatch);
            }
        }

        private void MoveDraw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                _texture,
                (Rectangle)positionAndSize,
                animation.currentFrame.Source,
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
                animationIdle.currentFrame.Source,
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
                animationIdle.currentFrame.Source,
                Color.White,
                0,
                new Vector2(0, 0),
                flip,
                0);
        }
        private void DieDraw(SpriteBatch _spriteBatch)
        {
            counter2++;
            counter++;
            if (counter2 > 10)
            {
                counter = 9;
            }
            _spriteBatch.Draw(
                _textureDie,
                (Rectangle)positionAndSize,
                array[counter],
                Color.White,
                0,
                new Vector2(0, 0),
                flip,
                0);
        }

        public void update(GameTime gameTime)
        {
            hitboxUpdate();
            positionAndSize.Y += velocity.Y;
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && live)
            {
                flip = SpriteEffects.FlipHorizontally;
                animation.Update(gameTime, 6);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && live)
            {
                flip = SpriteEffects.None;
                animation.Update(gameTime, 6);
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down)&& live )
            {
                animationIdle.Update(gameTime, 6);
            }
            if (hitbox.Intersects(Bear.hitbox) || hitbox.Intersects(Wolf.hitbox)|| hitbox.Intersects(Eagle.hitbox) ||!live)
            {
                live = false;
            }
            if(hasJumped == true)
            {
                float i = 1;
                velocity.Y += 0.15f * i;
            }
            if (hasJumped == false)
            {
                velocity.Y = 0f;
            }
            if (positionAndSize.Y + positionAndSize.Height >= 750)
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
