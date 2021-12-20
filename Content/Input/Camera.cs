using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using project_take_2.Content.Hero;

namespace project_take_2.Content.Input
{
    public class Camera
    {
        // source = Youtube User == Oyyou 
        #region variables
        private Matrix transform;
        #endregion
        #region proporties
        public Matrix Transform
        {
            get { return transform; }
            private set { transform = value; }
        }
        #endregion
        #region methodes
        public void Follow(RectangleF rectangleF)
        {
            var offSet = Matrix.CreateTranslation(Game1.screenW / 2, Game1.screenH / 1.5f, 0);

            var position = Matrix.CreateTranslation(-rectangleF.X - (rectangleF.Width / 2), -rectangleF.Y - (rectangleF.Height / 2), 0);

            Transform = position * offSet;
        }
        #endregion
    }
}
