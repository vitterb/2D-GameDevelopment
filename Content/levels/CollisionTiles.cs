using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project_take_2.Content.levels
{
    internal class CollisionTiles : Tiles 
    {
        #region constructor
        public CollisionTiles(int i, Rectangle newRectangle )
        {
            texture = Content.Load<Texture2D>("tileSprites/tiles"+i);
            this.Rectangle = newRectangle;
        }
        #endregion
    }
}
