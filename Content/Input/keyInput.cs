using Microsoft.Xna.Framework.Input;
using DruidsQuest.Content.interfaces;
using Microsoft.Xna.Framework;
using DruidsQuest.Content.Sounds;

namespace DruidsQuest.Content.Input
{
    public class KeyInput : IInput
    {
        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up)&& Hero.Character.live && Hero.Character.hasJumped == false || Keyboard.GetState().IsKeyDown(Keys.Space) && Hero.Character.live && Hero.Character.hasJumped == false)
            {
                Hero.Character.positionAndSize.Y -= 15f;
                Hero.Character.velocity.Y = -7.75f;
                Hero.Character.hasJumped = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left) && Hero.Character.live)
            {
                Hero.Character.velocity.X -= (float)gameTime.ElapsedGameTime.TotalMilliseconds / 350;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) && Hero.Character.live)
            {
                Hero.Character.velocity.X += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 350;
            }

            // source = Youtube User == Oyyou 

            else if (Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right)) 
            {
                Hero.Character.velocity.X = 0f;
            };
            if (Hero.Character.hasJumped)
            {
                float i = 1;
                Hero.Character.velocity.Y += 0.15f * i;
            }
        }
    }
}
