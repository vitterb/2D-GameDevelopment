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
        private Texture2D _texture;
        private Texture2D _textureIdle;
        private Texture2D _textureDie;
        private AnimationClass animation;
        private AnimationClass animationIdle;
        private AnimationClass animationDie;
        private Rectangle[] array = new Rectangle[10];
        private Rectangle hitbox;
        private bool live = true;
        private int counter = 0;
        private int counter2 = 1;

        private int _width;
        private int _height;
        private int _x;
        private int _y;
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
            hitbox = new Rectangle(0, 0, _width, _height);
            animation.AddFrame(new AnimationFrame(new Rectangle(50, 50, 833, 292)));
            animation.AddFrame(new AnimationFrame(new Rectangle(883, 50, 833, 292)));
            animation.AddFrame(new AnimationFrame(new Rectangle(50, 342, 833, 292)));
            animation.AddFrame(new AnimationFrame(new Rectangle(883, 342, 833, 292)));
            animation.AddFrame(new AnimationFrame(new Rectangle(50, 634, 833, 292)));
            animation.AddFrame(new AnimationFrame(new Rectangle(883, 634, 833, 292)));
            animation.AddFrame(new AnimationFrame(new Rectangle(50, 926, 833, 292)));
            animation.AddFrame(new AnimationFrame(new Rectangle(883, 926, 833, 292)));
            animation.AddFrame(new AnimationFrame(new Rectangle(50, 1218, 833, 292)));
            animation.AddFrame(new AnimationFrame(new Rectangle(883, 1218, 833, 292)));
            animationIdle = new AnimationClass();
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(50, 50, 833, 292)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(883, 50, 833, 292)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(50, 342, 833, 292)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(883, 342, 833, 292)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(50, 634, 833, 292)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(883, 634, 833, 292)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(50, 926, 833, 292)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(883, 926, 833, 292)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(50, 1218, 833, 292)));
            animationIdle.AddFrame(new AnimationFrame(new Rectangle(883, 1218, 833, 292)));

            array[0] = new Rectangle(50, 50, 833, 292);
            array[1] = new Rectangle(883, 50, 833, 292);
            array[2] = new Rectangle(50, 342, 833, 292);
            array[3] = new Rectangle(883, 342, 833, 292);
            array[4] = new Rectangle(50, 634, 833, 292);
            array[5] = new Rectangle(883, 634, 833, 292);
            array[6] = new Rectangle(50, 926, 833, 292);
            array[7] = new Rectangle(883, 926, 833, 292);
            array[8] = new Rectangle(50, 1218, 833, 292);
            array[9] = new Rectangle(883, 1218, 833, 292);
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
            if (hitbox.Intersects(Bear.hitbox) || !live)
            {
                live = false;
            }
        }
        private void hitboxUpdate()
        {
            hitbox.X = positionAndSize.X -185;
            hitbox.Y = positionAndSize.Y -185;
        }
    }
}
