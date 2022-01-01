using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using DruidsQuest.Content.Animation;
using DruidsQuest.Content.Hero;


namespace DruidsQuest.Content.Enemies
{
    public class Venustrap : Enemy
    {
        #region variables
        public Rectangle plantTrapPNG;
        public int counter = 0;
        public int counter2 = 1;
        #endregion
        #region Constructor
        public Venustrap(int x, int y, int width, int height)
        {
            _width = width;
            _height = height;
            _x = x;
            _y = y;

            positionAndSize = new Rectangle(_x, _y, _width, _height);
            hitbox = new Rectangle(0, 0, _width, _height);

            plantTrapPNG = new Rectangle(0, 0, 128, 100);

            animation = new AnimationClass();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 128, 100)));
            animation.AddFrame(new AnimationFrame(new Rectangle(128, 0, 128, 100)));
            animation.AddFrame(new AnimationFrame(new Rectangle(256, 0, 128, 100)));
            animation.AddFrame(new AnimationFrame(new Rectangle(384, 0, 128, 100)));
            animation.AddFrame(new AnimationFrame(new Rectangle(512, 0, 128, 100)));
            animation.AddFrame(new AnimationFrame(new Rectangle(640, 0, 128, 100)));
        }
        #endregion
        #region Methodes
        public override void LoadContent(ContentManager Content)
        {
            _texture = Content.Load<Texture2D>("Sprites/planttrap");
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            if (hitbox.Intersects((Rectangle)Character.hitbox))
                base.Draw(_spriteBatch);
            else
                _spriteBatch.Draw(
                    _texture,
                    positionAndSize,
                    plantTrapPNG,
                    Color.White,
                    0,
                    new Vector2(0, 0),
                    flip,
                    0);
        }
        public override void SetHitbox()
        {
            hitbox.X = positionAndSize.X + 15 ;
            hitbox.Y = positionAndSize.Y;
            hitbox.Width = positionAndSize.Width - 15;
            hitbox.Height = positionAndSize.Height;
        }
        #endregion
    }
}
