using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_take_2.Content.interfaces
{
    interface IHero
    {
        public void update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
    }
}
