using Microsoft.Xna.Framework;

namespace project_take_2.Content.Animation
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
