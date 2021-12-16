using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using project_take_2.Content.Animation;
using project_take_2.Content.Enemies;
using project_take_2.Content.interfaces;
using static project_take_2.Content.levels.RectangleHelper;
using static project_take_2.Content.Hero.CharacterState;

namespace project_take_2.Content.Hero
{
    public class Character : IHero
    {
        #region variables 
        private HeroState _state;
        private HeroState currentState;
        private Texture2D 
            _texture,
            _textureIdle,
            _textureDie,
            _textureJump;
        private HeroAnimation 
            _heroAnimation;
        public static RectangleF
            hitbox,
            positionAndSize,
            velocity;
        public static bool 
            live = true,
            hasAttacked,
            hasJumped = false;
        private int
            counter = 0,
            counter2 = 1;
        private int 
            OffsetX = 25,
            _width,
            _height,
            _x,
            _y;
        private SpriteEffects 
            flip = SpriteEffects.None;
        private SpriteFont 
            font;
        private Vector2 
            middle;
        private string 
            gameOver = "GAME OVER";
        #endregion

        #region Constructor
        public Character( int x, int y, int width, int height)
        {   
            _width = width;
            _height = height;
            _x = x;
            _y = y;
            positionAndSize = new RectangleF(_x, _y, _width, _height);
            hitbox = new Rectangle(0, 0, _width, _height);
            _heroAnimation = new HeroAnimation();
        }
        #endregion region
        #region Methodes
        public void LoadContent(ContentManager Content)
        {
            _state = HeroState.idle;
            _texture = Content.Load<Texture2D>("Sprites/heroPosibility1");
            _textureIdle = Content.Load<Texture2D>("Sprites/heroPosibilityIdle");
            _textureDie = Content.Load<Texture2D>("Sprites/heroPosibilityDie");
            _textureJump = Content.Load<Texture2D>("Sprites/heroPosibilityJump");
            font = Content.Load<SpriteFont>("Font/gameOver");
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            switch (currentState)
            {
                case HeroState.idle:
                    _spriteBatch.Draw(
                        _textureIdle,
                        (Rectangle)positionAndSize,
                        _heroAnimation.Idle.currentFrame.Source,
                        Color.White,
                        0,
                        new Vector2(0, 0),
                        flip,
                        0);
                    break;
                case HeroState.walk:
                    _spriteBatch.Draw(
                        _texture,
                        (Rectangle)positionAndSize,
                        _heroAnimation.Walk.currentFrame.Source,
                        Color.White,
                        0,
                        new Vector2(0, 0),
                        flip,
                        0);
                    break;
                case HeroState.dead:
                    _spriteBatch.Draw(
                        _textureDie,
                        (Rectangle)positionAndSize,
                        _heroAnimation.Death[counter],
                        Color.White,
                        0,
                        new Vector2(0, 0),
                        flip,
                        0);
                    _spriteBatch.DrawString(font, gameOver, middle, Color.DarkRed);
                    break;
                case HeroState.jump:
                    _spriteBatch.Draw(
                        _textureJump,
                        (Rectangle)positionAndSize,
                        _heroAnimation.Jump.currentFrame.Source,
                        Color.White,
                        0,
                        new Vector2(0, 0),
                        flip,
                        0);
                    break;
                case HeroState.attack:
                    break;
                default:
                    break;
            }
        }
        public void update(GameTime gameTime)
        {
            currentState = SetState(_state);
            hitboxUpdate();
            counter2++;
            counter++;
            if (counter2 > 10)
            {
                counter = 9;
            }
            positionAndSize.X += velocity.X;
            positionAndSize.Y += velocity.Y;
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && live )
            {
                flip = SpriteEffects.FlipHorizontally;
                _heroAnimation.Walk.Update(gameTime, 10);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && live )
            {
                flip = SpriteEffects.None;
                _heroAnimation.Walk.Update(gameTime, 10);
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down)&& live && hasJumped == false )
                _heroAnimation.Idle.Update(gameTime, 6);
            if (hitbox.Intersects(Bear.hitbox) || hitbox.Intersects(Wolf.hitbox)|| hitbox.Intersects(Eagle.hitbox) ||hitbox.Intersects(Venustrap.hitbox)||!live)
                live = false;
            // source = Youtube User == Oyyou 
            if(hasJumped)
                _heroAnimation.Jump.Update(gameTime, 6);
            if (!hasJumped)
                velocity.Y = 10f;
            middle.Y = positionAndSize.Y - 50;
            middle.X = positionAndSize.X - 100;
        }
        private void hitboxUpdate()
        {
            hitbox.X = positionAndSize.X + OffsetX;
            hitbox.Y = positionAndSize.Y;
            hitbox.Width = positionAndSize.Width - OffsetX ;
            hitbox.Height = positionAndSize.Height ;
        }
        public void TerrainCollision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (((Rectangle)hitbox).TouchTopOf(newRectangle)){
                hitbox.Y = newRectangle.Y- hitbox.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }
            if (((Rectangle)hitbox).TouchLeftOf(newRectangle))
            {
                positionAndSize.X = newRectangle.X - hitbox.Width - 2 ;
            }
            if (((Rectangle)hitbox).TouchRightOf(newRectangle))
            {
                positionAndSize.X = newRectangle.X + newRectangle.Width + 2 ;
            }
            if (((Rectangle)hitbox).TouchBottomOf(newRectangle))
            {
                velocity.Y = 1f;
            }
            if (positionAndSize.X < 0) positionAndSize.X = 0;
            if (positionAndSize.X > xOffset - hitbox.Width) positionAndSize.X = xOffset - hitbox.Width;
            if (hitbox.Y < 0) velocity.Y = 1f;
            if (positionAndSize.Y > yOffset - hitbox.Height) positionAndSize.Y = yOffset - hitbox.Height;
        }
        #endregion
    }
}
