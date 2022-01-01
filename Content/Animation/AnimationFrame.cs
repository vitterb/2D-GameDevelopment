//code by Tom Peeters

using Microsoft.Xna.Framework;

namespace DruidsQuest.Content.Animation
{
    public class AnimationFrame
    {
        public Rectangle Source { get; set; }

        public AnimationFrame(Rectangle rectangle)
        {
            Source = rectangle;
        }
    }
}
