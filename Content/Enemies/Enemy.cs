using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using project_take_2.Content.Animation;
using project_take_2.Content.interfaces;

namespace project_take_2.Content.Enemies
{
    public abstract class Enemy : IEnemies
    {
        #region variables 
        protected Rectangle hitbox;
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
            frameworkX = 250,
            frameworkY,
            frameworkWidth = 260,
            frameworkHeight = 225,
            frameworkXb = 1042,
            offsetX,
            offsetY,
            _limitedX1,
            _limitedX2;
        protected SpriteEffects 
            flip = SpriteEffects.None;
        #endregion
        public Rectangle Hitbox { get { return hitbox; } set { hitbox = value; } }
        #region methodes

        // Drawing the sprite no need to touch this!
        public virtual void Draw(SpriteBatch _spriteBatch)
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

        // Moving the Enemy use speed and deceleration use override!
        public virtual void Move(int deceleration, int speed)
        {
            positionAndSize.X += speed / deceleration;
        }

        // Updating the Enemy 
        public virtual void update(GameTime gameTime)
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

        public virtual void SetHitbox()
        {
            // update in the class of the enemy.
        }
        public virtual void LoadContent(ContentManager content) { }
        #endregion
    }
}
