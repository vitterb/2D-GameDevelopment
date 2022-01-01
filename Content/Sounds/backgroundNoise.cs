using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace DruidsQuest.Content.Sounds
{
    internal class BackgroundNoise
    {
        private Song song;

        public void LoadContent(ContentManager content)
        {
            song = content.Load<Song>("Sounds/Forest");
        }
        public void Play()
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);
            MediaPlayer.Volume = 0.25f;
        }
        public void Stop()
        {
            MediaPlayer.IsRepeating = false;
            MediaPlayer.Stop();
        }
    }
}
