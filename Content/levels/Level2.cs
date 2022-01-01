using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using DruidsQuest.Content.Backgrounds;
using DruidsQuest.Content.Enemies;
using DruidsQuest.Content.Hero;
using DruidsQuest.Content.Input;
using DruidsQuest.Content.interfaces;
using DruidsQuest.Content.Sounds;
using System.Collections.Generic;


namespace DruidsQuest.Content.levels
{
    public class Level2 :ILevel
    {

        #region variables
        private readonly Character herolv2;
        public List<Enemy> enemiesLv2;
        private readonly Bunny bunny;
        private ContentManager _content;
        private bool levelActive = false;
        private readonly Tilemap tilemap;
        private readonly Camera camera;
        private readonly BackgroundDarkMystery backGround;
        private readonly BackgroundNoise backgroundNoise;
        private readonly Sound sound;
        #endregion

        #region properties
        public bool Level2Active { get { return levelActive; } set { levelActive = value; } }
        #endregion

        #region Constructor
        public Level2()
        {
            backgroundNoise = new BackgroundNoise();
            sound = new Sound();
            herolv2 = new Character(0, 1000, 100, 100);
            bunny = new Bunny(4550, 90, 50, 50, 4550, 4700);
            enemiesLv2 = new List<Enemy>
            {
                new Venustrap(465,1130,100,100),
                new Venustrap(905,1130,100,100),
                new Venustrap(1350,1130,100,100),
                new Venustrap(1810,1130,100,100),
                new Venustrap(2250,1130,100,100),
                new Wolf(480,260,100,100,480,3100),
                new Wolf(1500,260,100,100,480,3100),
                new Wolf(2685,260,100,100,480,3100),
                new Wolf(3000,260,100,100,480,3100),
                new Eagle(0,60,100,100,0,4250),
                new Eagle(1000,60,100,100,0,4250),
                new Eagle(2000,60,100,100,0,4250),
                new Bear(3000,1025,200,200,3000,3750),
                new Bear(5000,1025,200,200,4850,5450)
                
            };
            tilemap = new Tilemap();
            camera = new Camera();
            backGround = new BackgroundDarkMystery();
        }
        #endregion

        #region Methodes
        public void ResetLevel2()
        {
            herolv2.Live= true;
            herolv2.PositionAndSize = new Rectangle(0, 1000, 100, 100);
            sound.PlayedVictory = false;
            sound.PlayedScream = false;
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
            bunny.Draw(_spriteBatch);
            foreach (var item in enemiesLv2)
                item.Draw(_spriteBatch);
            tilemap.Draw(_spriteBatch);
            herolv2.Draw(_spriteBatch);
            _spriteBatch.End();
        }
        public void UnLoadContent()
        {
            _content.Unload();
        }
        public void LoadContent(ContentManager Content)
        {
            backgroundNoise.LoadContent(Content);
            sound.LoadContent(Content);
            _content = new ContentManager(Content.ServiceProvider, "Content");
            backGround.LoadContent(_content);
            bunny.LoadContent(_content);
            herolv2.LoadContent(_content);
            foreach (var item in enemiesLv2)
                item.LoadContent(_content);
            Tiles.Content = Content;
            tilemap.Generate(new int[,]
            {
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0, 0, 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,1 ,3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0, 0, 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0, 0, 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,14,2 ,2 ,3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0, 0, 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,12,12,13,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0, 0, 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,1 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2, 2, 2 ,2 ,2 ,2 ,2 ,2 ,3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,1 ,2 ,2 ,2 ,3 ,0 ,0 ,4 ,6 ,0 ,0 ,0 ,0 ,7 ,9 ,0 ,0 ,7 ,9 ,0 ,0 ,10,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,11,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,5 ,5 ,5 ,5 ,5, 5 ,5, 5, 5 ,5 ,5 ,5 ,5 ,5 ,13,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,5 ,5 ,13,0 ,0 ,4 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,11,5 ,5 ,5 ,5 ,5 ,5, 5, 5 ,5 ,5 ,5 ,5 ,13,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,0 ,4 ,5 ,5 ,13,0 ,0 ,0 ,4 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,10,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,5 ,5 ,5 ,5 ,5, 5 ,5 ,5 ,5 ,13,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,0 ,0 ,4 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,10,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,11,5 ,5 ,5 ,5 ,5 ,5, 5 ,5 ,5 ,13,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,0 ,0 ,4 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,7 ,8 ,9 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,11,5 ,5 ,5 ,5 ,5, 5 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,0 ,0 ,4 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,7 ,8 ,9 ,0 ,7 ,8 ,9 ,0 ,0 ,10,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,11,5 ,5 ,5 ,5, 5 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,0 ,0 ,4 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,11,5 ,5 ,5, 5 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,1 ,2 ,15,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,7 ,9 ,0 ,0 ,0 ,0 ,7 ,8 ,9 ,0 ,0 ,0 ,0 ,0 ,0 ,11,5 ,5, 5 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,11,12,5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5, 5 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,0 ,0 ,11,13,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,0 ,0 ,4 ,5, 5 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,0 ,0 ,10,0 ,0 ,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,1 ,3 ,0 ,10,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5, 5 ,5 ,13,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5, 5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {1 ,2 ,2 ,2 ,2 ,2 ,3 ,0 ,0 ,1 ,2 ,2 ,2 ,3 ,0 ,0 ,1 ,2 ,2 ,2 ,3 ,0 ,0 ,1 ,2 ,2 ,2 ,3 ,0 ,0 ,1 ,2 ,2 ,2 ,3 ,0 ,0 ,1 ,2 ,2 ,2 ,15,5, 5 ,14,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,15,5 ,14,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,15,14,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,3 ,},
                {4 ,5 ,5 ,5 ,5 ,5 ,14,2 ,2 ,15,5 ,5 ,5 ,14,2 ,2 ,15,5 ,5 ,5 ,14,2 ,2 ,15,5 ,5 ,5 ,14,2 ,2 ,15,5 ,5 ,5 ,14,2 ,2 ,5 ,5 ,5 ,5 ,5 ,5, 5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,6 ,},
                {4 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5, 5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5, 5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5, 5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,6 ,},
                {4 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5, 5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,6 ,},
            }, 64) ; ;
        }
        public void Update(GameTime gameTime)
        {
            bunny.Update(gameTime);
            sound.Update(gameTime);
            if (!MediaPlayer.IsRepeating)
                backgroundNoise.Play();
            if (!herolv2.Live || herolv2.Victory)
                backgroundNoise.Stop();
            herolv2.Update(gameTime);
            foreach (var enemy in enemiesLv2)
            {
                enemy.update(gameTime);
                herolv2.Collision(enemy);
            }
            foreach (CollisionTiles tile in tilemap.CollisionTiles)
            {
                herolv2.TerrainCollision(tile.Rectangle, tilemap.Width, tilemap.Height);
                camera.Follow(Character.positionAndSize);
            }
        }
        #endregion
    }
}


