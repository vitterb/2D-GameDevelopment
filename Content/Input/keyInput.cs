using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using project_take_2.Content.Hero;
using project_take_2.Content.interfaces;


namespace project_take_2.Content.Input
{
    public class KeyInput : IInput
    {
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Hero.Hero.positionAndSize.Y -= 1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Hero.Hero.positionAndSize.Y += 1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Hero.Hero.positionAndSize.X -= 1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Hero.Hero.positionAndSize.X += 1;
            }
        }
    }
}
