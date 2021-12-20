using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_take_2.Content.interfaces
{
    internal interface Ilevel
    {
        bool LevelActive  { get; set; }

        public void ResetLevel();
        public void Draw(SpriteBatch _spriteBatch);
        public void LoadContent(ContentManager Content);
        public void update(GameTime gameTime);
    }
}
