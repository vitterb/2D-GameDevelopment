using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using project_take_2.Content.Animation;
using project_take_2.Content.interfaces;

namespace project_take_2.Content.Enemies
{
    public class Bear : Enemy, IEnemies
    {
        #region variables
        public static Rectangle hitbox;
        #endregion

        #region constructor
        public Bear(int x, int y, int width, int height, int limitedX1, int limitedX2)
        {
            // setting up the bear enemy

            _limitedX1 = limitedX1;
            _limitedX2 = limitedX2;
            _width = width;
            _height = height;
            _x = x;
            _y = y;

            // setting up specific offsets for bear sprite and hitbox

            HeightOffset = 50;
            widthOffset = 10;
            frameworkWidth = 277;

            // initializing bear position and bear hitbox rectangles

            positionAndSize = new Rectangle(_x, _y, _width, _height);
            hitbox = new Rectangle(0, 0, _width, _height);

            // Creating the bear annimation

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

        #region Methodes
        // configuring the hitbox
        public override void SetHitbox()
        {
            hitbox.X = positionAndSize.X + offsetX;
            hitbox.Y = positionAndSize.Y;
            hitbox.Width = positionAndSize.Width - widthOffset;
            hitbox.Height = positionAndSize.Height - HeightOffset;
        }

        public void LoadContent(ContentManager Content)
        {
            _texture = Content.Load<Texture2D>("Sprites/bear");
        }
        #endregion
    }

}
