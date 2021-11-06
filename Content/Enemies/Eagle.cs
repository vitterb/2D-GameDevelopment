using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using project_take_2.Content.Animation;

namespace project_take_2.Content.Enemies
{
    class Eagle : Enemy
    {
        public static Rectangle hitbox;
        public Eagle(Texture2D texture, int x, int y, int width, int height)
        {
            _texture = texture;
            _width = width;
            _height = height;
            _x = x;
            _y = y;

            positionAndSize = new Rectangle(_x, _y, _width, _height);
            hitbox = new Rectangle(0, 0, _width, _height);

            animation = new AnimationClass();
            animation.AddFrame(new AnimationFrame(new Rectangle(100, 100, 792, 375)));
            animation.AddFrame(new AnimationFrame(new Rectangle(892, 100, 792, 375)));
            animation.AddFrame(new AnimationFrame(new Rectangle(100, 475, 792, 375)));
            animation.AddFrame(new AnimationFrame(new Rectangle(892, 475, 792, 375)));
            animation.AddFrame(new AnimationFrame(new Rectangle(100, 850, 792, 375)));
            animation.AddFrame(new AnimationFrame(new Rectangle(892, 850, 792, 375)));
            animation.AddFrame(new AnimationFrame(new Rectangle(100, 1225, 792, 375)));
            animation.AddFrame(new AnimationFrame(new Rectangle(892, 1225, 792, 375)));
            animation.AddFrame(new AnimationFrame(new Rectangle(100, 1600, 792, 375)));
            animation.AddFrame(new AnimationFrame(new Rectangle(892, 1600, 792, 375)));
        }
        public override void Move(int deceleration, int speed)
        {
            positionAndSize.X += speed / deceleration;
            hitbox.X = positionAndSize.X;
            hitbox.Y = positionAndSize.Y;
        }
    }
}
