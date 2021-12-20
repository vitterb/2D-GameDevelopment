using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace project_take_2.Content.levels
{
    internal class Tiles
    {
        // source = Youtube User == Oyyou 
        #region variables
        protected Texture2D texture;
        private Rectangle rectangle;
        private static ContentManager content;
        #endregion

        #region proporties
        public Rectangle Rectangle 
        {
            get { return rectangle; } 
            protected set { rectangle = value; }
        }
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }
        #endregion

        #region methodes
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White); 
        }
        #endregion
    }
}
