using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using DruidsQuest.Content.Animation;
using DruidsQuest.Content.interfaces;

namespace DruidsQuest.Content.Enemies
{
    class Eagle : Enemy, IEnemies
    {
        #region constructor
        public Eagle(int x, int y, int width, int height, int limitedX1, int limitedX2)
        {
            _limitedX1 = limitedX1;
            _limitedX2 = limitedX2;
            _width = width;
            _height = height;
            _x = x;
            _y = y;

            widthOffset = 74;
            HeightOffset = 80;
            offsetX = 37;

            positionAndSize = new Rectangle(_x, _y, _width, _height);
            hitbox = new Rectangle(0, 0, _width/2, _height/2);

            animation = new AnimationClass();
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 152, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 152, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 527, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 527, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 902, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 902, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 1277, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 1277, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 1652, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 1652, frameworkWidth, frameworkHeight)));
        }
        #endregion

        #region methodes
        public override void Move(int deceleration, int speed)
        {
            positionAndSize.X += speed / deceleration;
        }
        public override void SetHitbox()
        {
            hitbox.X = positionAndSize.X + offsetX;
            hitbox.Y = positionAndSize.Y;
            hitbox.Width = positionAndSize.Width - widthOffset;
            hitbox.Height = positionAndSize.Height - HeightOffset;
        }

        public override void LoadContent(ContentManager Content)
        {
            _texture = Content.Load<Texture2D>("Sprites/Eagle");
        }
        #endregion
    }
}
