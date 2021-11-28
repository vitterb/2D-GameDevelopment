using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics; 
using System.Collections.Generic;


namespace project_take_2.Content.GameState
{
    public class ScreenManager
    {
        #region Variables

        private ContentManager content;

        private GameState CurrentScreen;
        private GameState newScreen;
        // Screenmanger instance

        private static ScreenManager instance;

        // Screen Stack

        Stack<GameState> screenStack = new Stack<GameState>();

        //screen width and height

        private Vector2 dimensions;

        #endregion
        #region Properties
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }

        public Vector2 Dimensions
        {
            get { return dimensions; }
            set { dimensions = value; }
        }

        #endregion

        #region Methodes

        public void AddScreen(GameState gameState)
        {
            newScreen = gameState;
            screenStack.Push(gameState);
            CurrentScreen.UnloadContent();
            CurrentScreen = newScreen;
            CurrentScreen.LoadContent(content);
        }
        public void Initialize() { }
        public void LoadContent(ContentManager Content) 
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            CurrentScreen.LoadContent(content);
        }
        public void Update(GameTime gameTime) 
        {
            CurrentScreen.Update(gameTime);
        }
        public void Draw(SpriteBatch spritebatch) 
        { 
            CurrentScreen.Draw(spritebatch);
        }
        #endregion
    }
}
