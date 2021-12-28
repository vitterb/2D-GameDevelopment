using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using project_take_2.Content.Backgrounds;
using project_take_2.Content.Enemies;
using project_take_2.Content.Hero;
using project_take_2.Content.Input;
using project_take_2.Content.interfaces;
using System.Collections.Generic;
using project_take_2.Content.Sounds;

namespace project_take_2.Content.levels
{
    public class Level1 : ILevel
    {
        #region variables
        private Character herolv1;
        public List<Enemy> enemieslv1;
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
        public bool Level1Active { get { return levelActive; } set { levelActive = value; } }
        public Character Herolv1 { get { return herolv1; } set { herolv1 = value; } }
        #endregion

        #region Constructor
        public Level1()
        {
            backgroundNoise = new BackgroundNoise();
            sound = new Sound();
            tilemap = new Tilemap();
            herolv1 = new Character(0,720, 100, 100);
            enemieslv1 = new List<Enemy>
            {
                new Eagle(800, 256, 100, 100, 0, 5500),
                new Eagle(1500, 256, 100, 100, 0, 5500),
                new Eagle(4850, 256, 100, 100, 0, 5500),
                new Wolf(2000, 900, 100, 100, 1664, 2100),
                new Wolf(4900, 900, 100, 100, 4880, 4945),
                new Bear(3000, 640, 200, 200, 2304, 3230),
                new Venustrap(4224, 815, 100, 100),
                new Venustrap(4302, 815, 100, 100),
                new Venustrap(4400, 815, 100, 100),
                new Venustrap(680, 740, 100, 100)
            };
            camera = new Camera();
            backGround = new BackgroundDarkMystery();
            bunny = new Bunny(5400, 735, 50, 50, 5060, 5500);
        }
        #endregion

        #region Methodes
        public void ResetLevel()
        {
            herolv1.Live = true;
            herolv1.PositionAndSize = new Rectangle(0, 720, 100, 100);
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
            tilemap.Draw(_spriteBatch);
            foreach (var enemy in enemieslv1)
                enemy.Draw(_spriteBatch);
            bunny.Draw(_spriteBatch);
            herolv1.Draw(_spriteBatch);
            _spriteBatch.End();
        }
        public void UnloadContent()
        {
            _content.Unload();
        }
        public void LoadContent(ContentManager Content)
        {
            _content = new ContentManager(Content.ServiceProvider, "Content");
            backgroundNoise.LoadContent(_content);
            sound.LoadContent(_content);
            backGround.LoadContent(_content);
            herolv1.LoadContent(_content);
            bunny.LoadContent(_content);
            foreach (var enemy in enemieslv1)
                enemy.LoadContent(_content);
            Tiles.Content = _content;
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
                {0,0,0,0,0,0,0,0,0,0,0,0,4,5,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,15,5,5,5,5,5,5,5,6,0,0,0,0,0,4,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,4,5,5,5,5,14,2,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,15,5,5,5,5,5,5,5,5,5,5,6,0,0,0,0,0,4,5,5,5,6,0,0,0,1,2,2,2,2,2,2,2,3,},
                {0,0,0,0,0,0,0,0,1,2,2,2,15,5,5,5,5,5,5,5,14,2,2,2,2,3,0,0,0,0,0,0,0,0,0,0,4,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6,0,0,0,0,0,4,5,5,5,6,0,0,0,4,5,5,5,5,5,5,5,6,},
                {1,2,2,2,2,2,2,2,15,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6,0,0,0,0,0,0,0,0,1,2,15,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,14,2,2,2,2,2,15,5,5,5,6,0,0,0,4,5,5,5,5,5,5,5,6,},
                {4,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,14,2,2,2,2,2,2,2,2,15,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,14,2,2,2,15,5,5,5,5,5,5,5,6,},
                {4,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6,},
                {4,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6,},
                
            }, 64);
        }
        public void Update(GameTime gameTime)
        {
            sound.Update(gameTime);
            if (!MediaPlayer.IsRepeating)
                backgroundNoise.Play();
            if (!Character.live || Character.victory)
                backgroundNoise.Stop();
            herolv1.Update(gameTime);
            bunny.Update(gameTime);
            foreach (var enemy in enemieslv1)
            {
                enemy.update(gameTime);
                herolv1.Collision(enemy);
            }
            foreach (CollisionTiles tile in tilemap.CollisionTiles)
            {
                herolv1.TerrainCollision(tile.Rectangle, tilemap.Width, tilemap.Height);
                camera.Follow(Character.positionAndSize);
            }           
        }
        #endregion
    }
}
