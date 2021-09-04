using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Namespace
{
    public class Controller : Game
    {
        public static Random Random = new Random();

        public static Controller Instance;

        private GraphicsDeviceManager Graphics;

        public Controller() : base()
        {
            Instance = this;
            IsMouseVisible = true;
            Graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            base.Initialize();
            Graphics.PreferredBackBufferWidth = 1280;
            Graphics.PreferredBackBufferHeight = 720;
            Graphics.ApplyChanges();

            KInput.Initialize();
            MInput.Initialize();
            Render.Initialize(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            KInput.Update();
            MInput.Update();

            //update your stuff here
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.Black);
            Render.Begin();
            //draw your stuff here
            Render.End();
        }
    }
}
