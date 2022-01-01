using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DruidsQuest.Content.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace DruidsQuest.Content.interfaces
{
    interface IHero
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
        void Collision(Enemy enemy);
    }
}
