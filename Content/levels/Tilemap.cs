using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace project_take_2.Content.levels
{
    internal class Tilemap
    {
        // source = Youtube User == Oyyou 
        #region variables
        private readonly List<CollisionTiles> collisionTiles = new List<CollisionTiles>();
        private int width, height;
        #endregion

        #region Proporties
        public List<CollisionTiles> CollisionTiles
        {
            get { return collisionTiles; }
        }
        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }
        #endregion
        public Tilemap() { }
        public void Generate(int[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];

                    if (number > 0)
                        collisionTiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size)));

                    width = (x + 1) * size;
                    height = (x + 1) * size;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionTiles tile in collisionTiles)
                tile.Draw(spriteBatch);
        }
    }
} 
