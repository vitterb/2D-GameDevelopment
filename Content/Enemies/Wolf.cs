using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using project_take_2.Content.Animation;

namespace project_take_2.Content.Enemies
{
    class Wolf : Enemy
    {
        #region variables
        public static Rectangle hitbox;
        #endregion

        #region constructor
        public Wolf(int x, int y, int width, int height)
        {
            _width = width;
            _height = height;
            _x = x;
            _y = y;
            
            positionAndSize = new Rectangle(_x, _y, _width, _height);
            hitbox = new Rectangle(0, 0, _width/2, _height/2);

            animation = new AnimationClass();
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 167, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 167, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 542, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 542, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 917, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 917, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 1292, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 1292, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 1667, frameworkWidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 1667, frameworkWidth, frameworkHeight)));
        }

        #endregion

        #region methodes
        public override void Move(int deceleration, int speed)
        {
            positionAndSize.X += speed / deceleration;
        }
        public override void SetHitbox()
        {
            hitbox.X = positionAndSize.X;
            hitbox.Y = positionAndSize.Y;
            hitbox.Width = positionAndSize.Width - widthOffset;
            hitbox.Height = positionAndSize.Height - HeightOffset;
        }
        public void LoadContent(ContentManager Content)
        {
            _texture = Content.Load<Texture2D>("Sprites/wolf2");
        }
        #endregion
    }
}
