﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using project_take_2.Content.Animation;
using project_take_2.Content.interfaces;

namespace project_take_2.Content.Enemies
{
    public class Enemy : IEnemies
    {
        protected Rectangle positionAndSize;
        public static Rectangle hitbox;
        protected Texture2D _texture;
        protected AnimationClass animation;

        protected int _width;
        protected int _height;
        protected int _x;
        protected int _y;
        protected int _speed = 1;
        protected int _slowdown = 1;
        protected int widthOffset = 10;
        protected int HeightOffset = 50;
        protected int frameworkX = 250;
        protected int frameworkY;
        protected int frameworkWidth = 260;
        protected int frameworkHeight = 225;
        protected int frameworkXb = 1042;
        protected int offsetX;
        protected int offsetY;
        protected SpriteEffects flip = SpriteEffects.None;
        
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

        public virtual void Move(int deceleration, int speed)
        {
            positionAndSize.X += speed / deceleration;
            hitbox.Y = positionAndSize.Y;
            hitbox.X = positionAndSize.X;
            hitbox.Width = positionAndSize.Width;
            hitbox.Height = positionAndSize.Height;
        }

        public virtual void update(GameTime gameTime)
        {
            Move(_slowdown, _speed);
            if (positionAndSize.X >= 824)
            {
                _speed *= -1;
                flip = SpriteEffects.FlipHorizontally;
            }
            if (positionAndSize.X <= 0)
            {
                _speed *= -1;
                flip = SpriteEffects.None;
            }
            animation.Update(gameTime, 6);
        }
    }
}