using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using project_take_2.Content.Hero;

namespace project_take_2.Content.Sounds
{
    public class Sound
    {
        private List<SoundEffect> soundeffects;
        private bool playedScream = false;
        private bool playedVictory = false;

        public bool PlayedScream { get { return playedScream; } set { playedScream = value; } }
        public bool PlayedVictory { get { return playedVictory; } set { playedVictory = value; } }

        public Sound()
        {
            soundeffects = new List<SoundEffect>();
            SoundEffect.MasterVolume = 0.1f;
        }
        public void LoadContent(ContentManager content)
        {
            // jump soundeffect by dklon (opengameart.org)
            soundeffects.Add(content.Load<SoundEffect>("Sounds/jump"));
            soundeffects.Add(content.Load<SoundEffect>("Sounds/WilhelmScream"));
            // fanfare soundeffect http://cynicmusic.com http://pixelsphere.org
            soundeffects.Add(content.Load<SoundEffect>("Sounds/victory"));
        }

        public void SoundJump()
        {
            soundeffects[0].Play();
        }

        public void Update(GameTime gametime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.Space))
                    soundeffects[0].Play();
            if (!Character.live && !playedScream)
            {
                PlayScream();
            }
            if (Character.victory && !playedVictory)
            {
                PlayVictory();
            }
        }
        public void PlayVictory()
        {
            soundeffects[2].Play();
            playedVictory = true;
        }
        public void PlayScream()
        {
            soundeffects[1].Play();
            playedScream = true;
        }
    }
}
