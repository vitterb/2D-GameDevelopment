using Microsoft.Xna.Framework.Input;
using project_take_2.Content.interfaces;


namespace project_take_2.Content.Input
{
    public class KeyInput : IInput
    {
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up)&& Hero.Hero.live && Hero.Hero.hasJumped == false || Keyboard.GetState().IsKeyDown(Keys.Space) && Hero.Hero.live && Hero.Hero.hasJumped == false)
            {
                Hero.Hero.positionAndSize.Y -= 5f;
                Hero.Hero.velocity.Y = -5f;
                Hero.Hero.hasJumped = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left) && Hero.Hero.live)
            {
                Hero.Hero.velocity.X -= 0.10f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) && Hero.Hero.live)
            {
                Hero.Hero.velocity.X += 0.10f;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right)) 
            {
                Hero.Hero.velocity.X = 0f;
            };
            if (Hero.Hero.hasJumped)
            {
                float i = 1;
                Hero.Hero.velocity.Y += 0.1f * i;
            }
        }
    }
}
