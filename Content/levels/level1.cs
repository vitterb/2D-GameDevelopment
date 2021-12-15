using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using project_take_2.Content.Backgrounds;
using project_take_2.Content.Hero;
using project_take_2.Content.interfaces;

namespace project_take_2.Content.levels
{
    public class Level1 : Ilevel
    {
        #region variables
        public Character hero;
        private ContentManager _content;
        private bool levelActive = false;
        private Tilemap tilemap;
        #endregion
        #region properties
        public bool LevelActive { get { return levelActive; } set { levelActive = value; } }
        #endregion
        #region Constructor
        public Level1()
        {
            tilemap = new Tilemap();
            hero = new Character(0, 0, 100, 100);   
        }
        #endregion
        #region Methodes
        public void ResetLevel()
        {
            Character.live = true;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            tilemap.Draw(_spriteBatch);
            hero.Draw(_spriteBatch);
        }
        public void LoadContent(ContentManager Content)
        {
            _content = new ContentManager(Content.ServiceProvider, "Content");
            hero.LoadContent(_content);
            Tiles.Content = Content;
            tilemap.Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            }, 64);
        }
        public void update(GameTime gameTime)
        {
            foreach (CollisionTiles tile in tilemap.CollisionTiles)
            {
                hero.TerrainCollision(tile.Rectangle, tilemap.Width, tilemap.Height);
            }
            hero.update(gameTime);
        }
        #endregion
    }
}
