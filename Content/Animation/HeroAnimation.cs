using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DruidsQuest.Content.Animation
{
    public class HeroAnimation
    {
        #region Variables
        private readonly int 
            frameworkwidth = 250,
            frameworkHeight = 200,
            frameworkX = 300,
            frameworkXb = 1133;
        private readonly AnimationClass 
            walkAnimation,
            idleAnimation,
            jumpAnimation;
        private readonly Rectangle[] 
            death = new Rectangle[10];
        #endregion
        #region Properties
        public AnimationClass Walk { get { return walkAnimation; } }
        public AnimationClass Idle { get { return idleAnimation; } }
        public AnimationClass Jump { get { return jumpAnimation; } }
        public Rectangle[] Death { get { return death; } } 
        #endregion
        public HeroAnimation()
        {
            #region Walk
            walkAnimation = new AnimationClass();
            walkAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 50, frameworkwidth, frameworkHeight)));
            walkAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 50, frameworkwidth, frameworkHeight)));
            walkAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 342, frameworkwidth, frameworkHeight)));
            walkAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 342, frameworkwidth, frameworkHeight)));
            walkAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 634, frameworkwidth, frameworkHeight)));
            walkAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 634, frameworkwidth, frameworkHeight)));
            walkAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 926, frameworkwidth, frameworkHeight)));
            walkAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 926, frameworkwidth, frameworkHeight)));
            walkAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 1218, frameworkwidth, frameworkHeight)));
            walkAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 1218, frameworkwidth, frameworkHeight)));
            #endregion

            #region Idle
            idleAnimation = new AnimationClass();
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 50, frameworkwidth, frameworkHeight)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 50, frameworkwidth, frameworkHeight)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 342, frameworkwidth, frameworkHeight)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 342, frameworkwidth, frameworkHeight)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 634, frameworkwidth, frameworkHeight)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 634, frameworkwidth, frameworkHeight)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 926, frameworkwidth, frameworkHeight)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 926, frameworkwidth, frameworkHeight)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 1218, frameworkwidth, frameworkHeight)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 1218, frameworkwidth, frameworkHeight)));
            #endregion

            #region Jump
            jumpAnimation = new AnimationClass();
            jumpAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 0, frameworkwidth, frameworkHeight + 65)));
            jumpAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 0, frameworkwidth, frameworkHeight + 65)));
            jumpAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 292, frameworkwidth, frameworkHeight + 65)));
            jumpAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 292, frameworkwidth, frameworkHeight + 65)));
            jumpAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 584, frameworkwidth, frameworkHeight + 65)));
            jumpAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 584, frameworkwidth, frameworkHeight + 65)));
            jumpAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 876, frameworkwidth, frameworkHeight + 65)));
            jumpAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 876, frameworkwidth, frameworkHeight + 65)));
            jumpAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkX, 1168, frameworkwidth, frameworkHeight + 65)));
            jumpAnimation.AddFrame(new AnimationFrame(new Rectangle(frameworkXb, 1168, frameworkwidth, frameworkHeight + 65)));
            #endregion

            #region Death
            death[0] = new Rectangle(frameworkX, 50, frameworkwidth + 25, frameworkHeight + 10);
            death[1] = new Rectangle(frameworkXb, 50, frameworkwidth + 25, frameworkHeight + 10);
            death[2] = new Rectangle(frameworkX, 342, frameworkwidth + 25, frameworkHeight + 10);
            death[3] = new Rectangle(frameworkXb, 342, frameworkwidth + 25, frameworkHeight + 10);
            death[4] = new Rectangle(frameworkX, 634, frameworkwidth + 25, frameworkHeight + 10);
            death[5] = new Rectangle(frameworkXb, 634, frameworkwidth + 25, frameworkHeight + 10);
            death[6] = new Rectangle(frameworkX, 926, frameworkwidth + 25, frameworkHeight + 10);
            death[7] = new Rectangle(frameworkXb, 926, frameworkwidth + 25, frameworkHeight + 10);
            death[8] = new Rectangle(frameworkX, 1218, frameworkwidth + 25, frameworkHeight + 10);
            death[9] = new Rectangle(frameworkXb, 1218, frameworkwidth + 25, frameworkHeight + 10); 
            #endregion
        }
    }
}
