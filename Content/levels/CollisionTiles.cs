using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project_take_2.Content.levels
{
    internal class CollisionTiles : Tiles 
    {
        #region constructor
        public CollisionTiles(int i, Rectangle newRectangle )
        {
            texture = Content.Load<Texture2D>("Sprites/Ground_grass_0001_tile");
            this.Rectangle = newRectangle;
        }
        #endregion
    }
}
