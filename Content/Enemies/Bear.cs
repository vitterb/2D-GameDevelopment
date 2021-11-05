using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using project_take_2.Content.Animation;
using project_take_2.Content.interfaces;

namespace project_take_2.Content.Enemies
{
    public class Bear : IEnemies
    {
        public static Rectangle positionAndSize;
        private Texture2D _texture;
        private AnimationClass animation;

        private int _width;
        private int _height;
        private int _x;
        private int _y;
        private int _speed = 1;
        private int _slowdown = 1;
        private SpriteEffects flip = SpriteEffects.None;
        public static Rectangle hitbox;
        public Bear(Texture2D texture, int x, int y, int width, int height)
        {
            _texture = texture;
            _width = width;
            _height = height;
            _x = x;
            _y = y;

            animation = new AnimationClass();
            positionAndSize = new Rectangle(_x, _y, _width, _height);
            hitbox = new Rectangle(150,150,5,5);
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

        private void Move(int deceleration, int speed)
        {
            positionAndSize.X += speed / deceleration;
            hitbox.X = positionAndSize.X;
            hitbox.Y = positionAndSize.Y;
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
        public void update(GameTime gameTime)
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
