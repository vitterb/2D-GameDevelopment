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
        private bool played = false;

        public bool Played { get { return played; } set { played = value; } }

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
            if (!Character.live && !played)
            {
                soundeffects[1].Play();
                played = true;
            }
            if (Character.victory && !played)
            {
                soundeffects[2].Play();
                played = true;
            }
        }
    }
}
