using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DruidsQuest.Content.interfaces
{
    internal interface ILevel
    {
        public void Draw(SpriteBatch _spriteBatch);
        public void LoadContent(ContentManager Content);
        public void Update(GameTime gameTime);
    }
}
