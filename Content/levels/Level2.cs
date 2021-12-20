using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_take_2.Content.levels
{
    public class Level2
    {
        private Tilemap tilemap;
        public Level2()
        {
            tilemap = new Tilemap();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            tilemap.Draw(_spriteBatch);
        }
        public void loadContent(ContentManager Content)
        {
            Tiles.Content = Content;
            tilemap.Generate(new int[,]
            {
                {0,0,0,0,},
                {0,0,0,0,},
                {0,0,0,0,},
                {0,0,0,0,},
                {1,1,1,1,},
            }, 64);
        }
    }
}
