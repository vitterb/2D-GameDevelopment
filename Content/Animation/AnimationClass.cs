using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace project_take_2.Content.Animation
{
    public class AnimationClass
    {
        public AnimationFrame currentFrame { get; set; }

        private List<AnimationFrame> frames;
        private int counter;

        private double frameMovement = 0;
        public AnimationClass()
        {
            frames = new List<AnimationFrame>();
        }

        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            currentFrame = frames[0];
        }

        public void Update(GameTime gameTime, int _speed)
        {
            currentFrame = frames[counter];

            frameMovement += currentFrame.Source.Width * gameTime.ElapsedGameTime.TotalSeconds;
            if (frameMovement >= currentFrame.Source.Width /_speed)
            {
                counter++;
                frameMovement = 0;
            }


            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }
    }
}
