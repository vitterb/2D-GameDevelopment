using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DruidsQuest.Content.levels
{
    internal class CollisionTiles : Tiles
    { 
        // source = Youtube User == Oyyou 
        #region constructor
        public CollisionTiles(int i, Rectangle newRectangle )
        {
            texture = Content.Load<Texture2D>("tileSprites/tiles"+i);
            this.Rectangle = newRectangle;
        }
        #endregion
    }
}
