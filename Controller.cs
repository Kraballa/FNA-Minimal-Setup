using Microsoft.Xna.Framework;
using Namespace.Util;

namespace Namespace
{
    public class Controller : Game
    {
        public const int Width = 1280;
        public const int Height = 720;

        public static Controller Instance;

        public Camera Camera;

        private GraphicsDeviceManager Graphics;

        public Controller() : base()
        {
            Instance = this;
            IsMouseVisible = true;
            Graphics = new GraphicsDeviceManager(this);
            Camera = new Camera();
        }

        protected override void Initialize()
        {
            base.Initialize();
            Graphics.PreferredBackBufferWidth = Width;
            Graphics.PreferredBackBufferHeight = Height;
            Graphics.ApplyChanges();

            KInput.Initialize();
            MInput.Initialize();
            CInput.Initialize();
            Render.Initialize(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Time.Update(gameTime);
            KInput.Update();
            MInput.Update();
            CInput.Update();
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
