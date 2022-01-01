using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Druids_Quest.Content.Sounds
{
    internal class SplashScreenSound
    {
        private Song song;

        public void LoadContent(ContentManager content)
        {
            //Sound effects by TunePocket – Unlimited royalty free music and sound effects for video creators
            song = content.Load<Song>("Sounds/Splashscreen");
        }
        public void Play()
        {
            MediaPlayer.IsRepeating = false;
            MediaPlayer.Play(song);
            MediaPlayer.Volume = 0.75f;
        }
        public void Stop()
        {
            MediaPlayer.Stop();
        }
    }
}
