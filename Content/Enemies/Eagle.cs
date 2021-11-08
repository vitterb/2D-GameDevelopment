using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using project_take_2.Content.Animation;

namespace project_take_2.Content.Enemies
{
    class Eagle : Enemy
    {
        public static Rectangle hitbox;
        private Texture2D eagleSprite;
        public Eagle(int x, int y, int width, int height)
        {
            _texture = eagleSprite;
            _width = width;
            _height = height;
            _x = x;
            _y = y;

            widthOffset = 74;
            HeightOffset = 80;
            offsetX = 37;

            positionAndSize = new Rectangle(_x, _y, _width, _height);
            hitbox = new Rectangle(0, 0, _width, _height);

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

        public void LoadContent(ContentManager Content)
        {
            eagleSprite = Content.Load<Texture2D>("Sprites/Eagle");
        }
    }
}
