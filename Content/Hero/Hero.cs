using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using project_take_2.Content.Animation;
using project_take_2.Content.Enemies;
using project_take_2.Content.interfaces;


namespace project_take_2.Content.Hero
{
    public class Hero : IHero
    {
        public static Rectangle positionAndSize; 
        private readonly Texture2D _texture;
        private readonly Texture2D _textureIdle;
        private readonly Texture2D _textureDie;
        private readonly AnimationClass animation;
        private readonly AnimationClass animationIdle;
        private readonly Rectangle[] array = new Rectangle[10];
        private Rectangle hitbox;
        public static bool live = true;
        private int counter = 0;
        private int counter2 = 1;
        private readonly int OffsetX = 25;
        private readonly int frameworkwidth = 250;
        private readonly int frameworkHeight = 200;
        private readonly int frameworkX = 300;
        private readonly int frameworkXb = 1133;
        private readonly int _width;
        private readonly int _height;
        private readonly int _x;
        private readonly int _y;
        private SpriteEffects flip = SpriteEffects.None;
        
        public Hero(Texture2D textureWalking,Texture2D textureIdle, Texture2D textureDie, int x, int y, int width, int height)
        {
            _texture = textureWalking;
            _textureIdle = textureIdle;
            _textureDie = textureDie;
            _width = width;
            _height = height;
            _x = x;
            _y = y;
            
            animation = new AnimationClass();
            positionAndSize = new Rectangle(_x, _y, _width, _height);
            hitbox = new Rectangle(0, 0, _texture.Width/2, _texture.Height/2);
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 50, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 50, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 342, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 342, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 634, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 634, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 926, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 926, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 1218, frameworkwidth, frameworkHeight)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 1218, frameworkwidth, frameworkHeight)));
            animationIdle = new AnimationClass();
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 50, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 50, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 342, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 342, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 634, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 634, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 926, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 926, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 1218, frameworkwidth, frameworkHeight)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 1218, frameworkwidth, frameworkHeight)));

            array[0] = new Rectangle(frameworkX, 50, frameworkwidth, frameworkHeight);
            array[1] = new Rectangle(frameworkXb, 50, frameworkwidth, frameworkHeight);
            array[2] = new Rectangle(frameworkX, 342, frameworkwidth, frameworkHeight);
            array[3] = new Rectangle(frameworkXb, 342, frameworkwidth, frameworkHeight);
            array[4] = new Rectangle(frameworkX, 634, frameworkwidth, frameworkHeight);
            array[5] = new Rectangle(frameworkXb, 634, frameworkwidth, frameworkHeight);
            array[6] = new Rectangle(frameworkX, 926, frameworkwidth, frameworkHeight);
            array[7] = new Rectangle(frameworkXb, 926, frameworkwidth, frameworkHeight);
            array[8] = new Rectangle(frameworkX, 1218, frameworkwidth, frameworkHeight);
            array[9] = new Rectangle(frameworkXb, 1218, frameworkwidth, frameworkHeight);
        }
       
        public void Draw(SpriteBatch _spriteBatch)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left)&& live )
            {
                MoveDraw(_spriteBatch);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && live )
            {
                MoveDraw(_spriteBatch);
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down) && live)
            {
                IdleDraw(_spriteBatch);
            }
            if (hitbox.Intersects(Bear.hitbox))
            {
                DieDraw(_spriteBatch);
            }
        }

        private void MoveDraw(SpriteBatch _spriteBatch)
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
        private void IdleDraw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                _textureIdle,
                positionAndSize,
                animationIdle.currentFrame.Source,
                Color.White,
                0,
                new Vector2(0, 0),
                flip,
                0);
        }
        private void DieDraw(SpriteBatch _spriteBatch)
        {
            counter2++;
            counter++;
            if (counter2 > 10)
            {
                counter = 9;
            }
            _spriteBatch.Draw(
                _textureDie,
                positionAndSize,
                array[counter],
                Color.White,
                0,
                new Vector2(0, 0),
                flip,
                0);
        }

        public void update(GameTime gameTime)
        {
            hitboxUpdate();
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && live)
            {
                flip = SpriteEffects.FlipHorizontally;
                animation.Update(gameTime, 6);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && live)
            {
                flip = SpriteEffects.None;
                animation.Update(gameTime, 6);
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down)&& live )
            {
                animationIdle.Update(gameTime, 6);
            }
            if (hitbox.Intersects(Enemy.hitbox) || !live)
            {
                live = false;
            }
        }
        private void hitboxUpdate()
        {
            hitbox.X = positionAndSize.X + OffsetX;
            hitbox.Y = positionAndSize.Y;
            hitbox.Width = positionAndSize.Width - OffsetX ;
            hitbox.Height = positionAndSize.Height ;
        }
    }
}
