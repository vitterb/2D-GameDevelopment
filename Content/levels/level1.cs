using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using project_take_2.Content.Backgrounds;
using project_take_2.Content.Enemies;
using project_take_2.Content.Hero;
using project_take_2.Content.Input;
using project_take_2.Content.interfaces;
using System.Collections.Generic;

namespace project_take_2.Content.levels
{
    public class Level1 : Ilevel
    {
        #region variables
        public Character hero;
        public List<Enemy> enemies;
        private Bunny bunny;
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
            enemies = new List<Enemy>();
            enemies.Add(new Eagle(800, 256, 100, 100, 0, 5500));
            enemies.Add(new Eagle(1500, 256, 100, 100, 0, 5500));
            enemies.Add(new Eagle(4850, 256, 100, 100, 0, 5500));
            enemies.Add(new Wolf(2000, 900, 100, 100, 1664, 2100));
            enemies.Add(new Wolf(4900, 900, 100, 100, 4880, 4945));
            enemies.Add(new Bear(3000, 640, 200, 200, 2304, 3230));
            enemies.Add(new Venustrap(4224, 815, 100, 100));
            enemies.Add(new Venustrap(4302, 815, 100, 100));
            enemies.Add(new Venustrap(4400, 815, 100, 100));
            enemies.Add(new Venustrap(680, 740, 100, 100));
            camera = new Camera();
            backGround = new BackgroundDarkMystery();
            bunny = new Bunny(5400, 735, 50, 50, 5060, 5500);
        }
        #endregion

        #region Methodes
        public void ResetLevel()
        {
            Character.positionAndSize = new Rectangle(0, 768, 100, 100);
            Character.live = true;
            Character.victory = false;
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
            tilemap.Draw(_spriteBatch);
            foreach (var enemy in enemies)
                enemy.Draw(_spriteBatch);
            bunny.Draw(_spriteBatch);
            hero.Draw(_spriteBatch);
            _spriteBatch.End();
        }
        public void LoadContent(ContentManager Content)
        {
            _content = new ContentManager(Content.ServiceProvider, "Content");
            backGround.LoadContent(_content);
            hero.LoadContent(_content);
            bunny.LoadContent(_content);
            foreach (var enemy in enemies)
                enemy.LoadContent(_content);
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
                {4,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6,},
                
            }, 64);
        }
        public void update(GameTime gameTime)
        {
            bunny.update(gameTime);
            foreach (var enemy in enemies)
            {
                enemy.update(gameTime);
                hero.collision(enemy);
            }
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
