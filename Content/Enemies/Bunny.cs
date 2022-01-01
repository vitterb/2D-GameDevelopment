using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using DruidsQuest.Content.Animation;

namespace DruidsQuest.Content.Enemies
{
    class Bunny 
    {
        #region variables
        public static Rectangle hitbox;
        protected Rectangle
            positionAndSize;
        protected Texture2D
            _texture;
        protected AnimationClass
            animation;
        protected int
            _width,
            _height,
            _x,
            _y,
            _speed = 1,
            _slowdown = 1,
            widthOffset = 10,
            HeightOffset = 50,
            frameworkWidth = 260,
            frameworkHeight = 225,
            frameworkXb = 1042,
            _limitedX1,
            _limitedX2;
        protected SpriteEffects
            flip = SpriteEffects.None;
        #endregion
        #region constructor
        public Bunny(int x, int y, int width, int height, int limitedX1, int limitedX2)
        {
            _limitedX1 = limitedX1;
            _limitedX2 = limitedX2;
            _width = width;
            _height = height;
            _x = x;
            _y = y;
            positionAndSize = new Rectangle(_x, _y, _width, _height);
            hitbox = new Rectangle(0, 0, _width, _height);
            frameworkWidth = 38;
            frameworkHeight = 38;
            _speed = 2;
            animation = new AnimationClass();
            animation.AddFrame(new AnimationFrame(new Rectangle(13, 211, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(53, 211, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(93, 211, frameworkWidth, frameworkHeight)));
        }

        #endregion

        #region methodes
        public void Move(int deceleration, int speed)
        {
            positionAndSize.X += speed / deceleration;
        }
        public void SetHitbox()
        {
            hitbox.X = positionAndSize.X + widthOffset;
            hitbox.Y = positionAndSize.Y - HeightOffset;
            hitbox.Width = positionAndSize.Width - widthOffset;
            hitbox.Height = positionAndSize.Height - HeightOffset;
        }
        public void LoadContent(ContentManager Content)
        {
            _texture = Content.Load<Texture2D>("Sprites/bunnySprite");
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                _texture,
                positionAndSize,
                animation.currentFrame.Source,
                Color.White,
                0,
                new Vector2(0, 0),
                flip,
                0);
        }
        public void Update(GameTime gameTime)
        {
            SetHitbox();
            Move(_slowdown, _speed);
            if (positionAndSize.X >= _limitedX1)
            {
                _speed *= -1;
                if (flip == SpriteEffects.None)
                    flip = SpriteEffects.FlipHorizontally;
                else
                    flip = SpriteEffects.None;
            }
            if (positionAndSize.X <= _limitedX2)
            {
                _speed *= -1;
                if (flip == SpriteEffects.None)
                    flip = SpriteEffects.FlipHorizontally;
                else
                    flip = SpriteEffects.None;
            }
            animation.Update(gameTime, 6);
        }
        #endregion

    }
}
