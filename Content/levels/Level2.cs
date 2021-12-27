﻿using Microsoft.Xna.Framework;
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
        #endregion

        #region properties
        public bool Level2Active { get { return levelActive; } set { levelActive = value; } }
        #endregion

        #region Constructor
        public Level2()
        {
            herolv2 = new Character(0, 888, 100, 100);
            enemiesLv2 = new List<Enemy>
            {
                
            };
            tilemap = new Tilemap();
            camera = new Camera();
            backGround = new BackgroundDarkMystery();
        }
        #endregion

        #region Methodes
        public void ResetLevel2()
        {
            Character.live = true;
            Character.positionAndSize = new Rectangle(0, 888, 100, 100);
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
            herolv2.Draw(_spriteBatch);
            tilemap.Draw(_spriteBatch);
            _spriteBatch.End();
        }
        public void LoadContent(ContentManager Content)
        {
            _content = new ContentManager(Content.ServiceProvider, "Content");
            backGround.LoadContent(_content);
            herolv2.LoadContent(_content);
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
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,7 ,8 ,9 ,0 ,7 ,8 ,9 ,0 ,0 ,10,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,11,5 ,5 ,5 ,5, 5 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,0 ,0 ,4 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,11,5 ,5 ,5, 5 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,1 ,2 ,15,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,7 ,9 ,0 ,0 ,0 ,0 ,7 ,8 ,9 ,0 ,0 ,0 ,0 ,0 ,0 ,11,5 ,5, 5 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,11,12,5 ,6 ,0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5, 5 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,0 ,0 ,11,13,0 ,0 ,10,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,0 ,0 ,4 ,5, 5 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,10,0 ,0 ,0 ,0 ,10,0 ,0 ,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5, 5 ,5 ,13,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5, 5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,4 ,5 ,6 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,1 ,3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,},
                {1 ,2 ,2 ,2 ,2 ,2 ,3 ,0 ,0 ,1 ,2 ,2 ,2 ,3 ,0 ,0 ,1 ,2 ,2 ,2 ,3 ,0 ,0 ,1 ,2 ,2 ,2 ,3 ,0 ,0 ,1 ,2 ,2 ,2 ,3 ,0 ,0 ,1 ,2 ,2 ,2 ,15,5, 5 ,14,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,15,5 ,14,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,15,14,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,3 ,},
                {4 ,5 ,5 ,5 ,5 ,5 ,14,2 ,2 ,15,5 ,5 ,5 ,14,2 ,2 ,15,5 ,5 ,5 ,14,2 ,2 ,15,5 ,5 ,5 ,14,2 ,2 ,15,5 ,5 ,5 ,14,2 ,2 ,5 ,5 ,5 ,5 ,5 ,5, 5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,6 ,},
                {4 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5, 5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5, 5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5, 5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,6 ,},
                {4 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5, 5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,6 ,},
            }, 64) ; ;
        }
        public void Update(GameTime gameTime)
        {
            herolv2.Update(gameTime);
            foreach (CollisionTiles tile in tilemap.CollisionTiles)
            {
                herolv2.TerrainCollision(tile.Rectangle, tilemap.Width, tilemap.Height);
                camera.Follow(Character.positionAndSize);
            }
        }
        #endregion
    }
}


