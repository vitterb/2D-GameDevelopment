using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using project_take_2.Content.Backgrounds;
using project_take_2.Content.Enemies;
using project_take_2.Content.Hero;
using project_take_2.Content.Input;
using project_take_2.Content.interfaces;

namespace project_take_2.Content.levels
{
    public class Level1 : Ilevel
    {
        #region variables
        public Character hero;
        private Eagle
            eagle1,
            eagle2,
            eagle3;
        private Venustrap
            venus1,
            venus2,
            venus3,
            venus4;
        private Wolf
            wolf1;
        private Bear
            bear1;
        private ContentManager _content;
        private bool levelActive = false;
        private Tilemap tilemap;
        private Camera camera;
        private BackgroundDarkMystery backGround;
        #endregion
        #region properties
        public bool LevelActive { get { return levelActive; } set { levelActive = value; } }
        #endregion
        #region Constructor
        public Level1()
        {
            tilemap = new Tilemap();
            hero = new Character(0,768, 100, 100);
            eagle1 = new Eagle(800, 256, 100, 100, 0, 5500);
            eagle2 = new Eagle(1500, 256, 100, 100, 0, 5500);
            eagle3 = new Eagle(4850, 256, 100, 100, 0, 5500);
            wolf1 = new Wolf(2000, 900, 100, 100, 1664, 2100);
            bear1 = new Bear(3000, 640, 200, 200, 2304, 3230);
            venus1 = new Venustrap(4224, 815, 100, 100);
            venus2 = new Venustrap(4302, 815, 100, 100);
            venus3 = new Venustrap(4400, 815, 100, 100);
            venus4 = new Venustrap(680, 740, 100, 100);
            camera = new Camera();
            backGround = new BackgroundDarkMystery();
        }
        #endregion
        #region Methodes
        public void ResetLevel()
        {
            Character.live = true;
            Character.positionAndSize = new Rectangle(0, 768, 100, 100);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            backGround.DrawSky(_spriteBatch);
            backGround.DrawBackground(_spriteBatch);
            backGround.DrawMiddle(_spriteBatch);
            backGround.DrawForeGround(_spriteBatch);
            backGround.DrawGround(_spriteBatch);
            _spriteBatch.End();
            _spriteBatch.Begin(transformMatrix: camera.Transform);
            eagle1.Draw(_spriteBatch);
            eagle2.Draw(_spriteBatch);
            eagle3.Draw(_spriteBatch);
            wolf1.Draw(_spriteBatch);
            bear1.Draw(_spriteBatch);
            tilemap.Draw(_spriteBatch);
            venus1.Draw(_spriteBatch);
            venus2.Draw(_spriteBatch);
            venus3.Draw(_spriteBatch);
            venus4.Draw(_spriteBatch);
            hero.Draw(_spriteBatch);
            _spriteBatch.End();
        }
        public void LoadContent(ContentManager Content)
        {
            _content = new ContentManager(Content.ServiceProvider, "Content");
            backGround.LoadContent(_content);
            hero.LoadContent(_content);
            venus1.LoadContent(_content);
            venus2.LoadContent(_content);
            venus3.LoadContent(_content);
            venus4.LoadContent(_content);
            eagle1.LoadContent(_content);
            eagle2.LoadContent(_content);
            eagle3.LoadContent(_content);
            wolf1.LoadContent(_content);
            bear1.LoadContent(_content);
            Tiles.Content = Content;
            tilemap.Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,3,0,0,0,0,0,1,2,2,2,3,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,4,5,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,8,9,0,0,0,0,0,4,5,5,5,5,5,5,5,6,0,0,0,0,0,4,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,7,8,9,0,0,4,5,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,8,8,9,0,0,0,0,0,0,0,0,0,0,0,4,5,5,5,5,5,5,5,6,0,0,0,0,0,4,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,4,5,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,8,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,5,5,5,5,5,5,6,0,0,0,0,0,4,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,4,5,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,5,5,5,5,5,5,6,0,0,0,0,0,4,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,7,8,8,9,0,0,0,0,0,4,5,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,7,8,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,5,5,5,5,5,5,6,0,0,0,0,0,4,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,4,5,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,5,5,5,5,5,5,5,5,6,0,0,0,0,0,4,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,4,5,5,5,5,5,2,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,5,5,5,5,5,5,5,5,5,5,6,0,0,0,0,0,4,5,5,5,6,0,0,0,1,2,2,2,2,2,2,2,3,},
                {0,0,0,0,0,0,0,0,1,2,2,2,5,5,5,5,5,5,5,5,5,2,2,2,2,3,0,0,0,0,0,0,0,0,0,0,4,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6,0,0,0,0,0,4,5,5,5,6,0,0,0,4,5,5,5,5,5,5,5,6,},
                {1,2,2,2,2,2,2,2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6,0,0,0,0,0,0,0,0,1,2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2,2,2,2,2,5,5,5,5,6,0,0,0,4,5,5,5,5,5,5,5,6,},
                {4,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2,2,2,2,2,2,2,2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2,2,2,5,5,5,5,5,5,5,5,6,},
                {4,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6,},
                {4,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6,}
            }, 64);
        }
        public void update(GameTime gameTime)
        {
            eagle1.update(gameTime);
            eagle2.update(gameTime);
            eagle3.update(gameTime);
            venus1.update(gameTime);
            venus2.update(gameTime);
            venus3.update(gameTime);
            venus4.update(gameTime);   
            wolf1.update(gameTime);
            bear1.update(gameTime);
            foreach (CollisionTiles tile in tilemap.CollisionTiles)
            {
                hero.TerrainCollision(tile.Rectangle, tilemap.Width, tilemap.Height);
                camera.Follow(Character.positionAndSize);
            }
            hero.update(gameTime);
           
        }
        #endregion
    }
}
