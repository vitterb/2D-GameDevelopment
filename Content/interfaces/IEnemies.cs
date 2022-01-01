using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DruidsQuest.Content.interfaces
{
    interface IEnemies
    {
        
        public void Draw(SpriteBatch spriteBatch);
        public void update(GameTime gameTime);
        public void Move(int deceleration, int speed);
    }
}
