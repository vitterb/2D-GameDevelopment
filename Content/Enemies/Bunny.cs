﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using project_take_2.Content.Animation;

namespace project_take_2.Content.Enemies
{
    class Bunny : Enemy
    {
        #region variables
        public static Rectangle hitbox;
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
        public override void Move(int deceleration, int speed)
        {
            positionAndSize.X += speed / deceleration;
        }
        public override void SetHitbox()
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
        #endregion

    }
}