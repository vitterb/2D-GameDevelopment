﻿using Microsoft.Xna.Framework.Input;


namespace project_take_2.Content.Hero
{
    public class CharacterState
    {
        #region Variables
        public enum HeroState { idle, walk, dead, jump, attack}
        private HeroState state;
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
            if (Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down) && Character.live && !Character.hasJumped)
            {
                state = HeroState.idle;
            }
            if (!Character.live)
            {
                state = HeroState.dead;
            }
            if(Character.hasAttacked)
            {
                state = HeroState.attack;
            }
            return state;
        }
    }
}
