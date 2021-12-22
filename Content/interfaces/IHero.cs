using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using project_take_2.Content.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_take_2.Content.interfaces
{
    interface IHero
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
        void Collision(Enemy enemy);
    }
}
