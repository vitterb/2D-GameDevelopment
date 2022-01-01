using Microsoft.Xna.Framework.Input;


namespace DruidsQuest.Content.Hero
{
    public class CharacterState
    {
        #region Variables
        public enum HeroState { idle, walk, dead, jump, victory}
        private HeroState state;
        #endregion

        #region proporties
        public HeroState State { get { return state; } set { state = value; } }
        #endregion

        public static HeroState SetState(HeroState state)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && Character.live && !Character.hasJumped)
            {
                state = HeroState.walk;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && Character.live && !Character.hasJumped)
            {
                state = HeroState.walk;
            }
            if (Character.hasJumped && Character.live)
            {
                state = HeroState.jump;
            }
            if (Character.velocity.Y != 0 )
            {
                state = HeroState.jump;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down) && Character.live && !Character.hasJumped)
            {
                state = HeroState.idle;
            }
            if (!Character.live)
            {
                state = HeroState.dead;
            }
            return state;
        }
    }
}
