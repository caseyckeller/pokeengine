using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pokemon.Core;
using Pokemon.Screens;

namespace Pokemon
{
    public class Pokemon : Game
    {
        private static readonly string[] PreloadAssets =
            {
                "gradient",
            };

        private readonly GraphicsDeviceManager _graphics;
        private readonly ScreenManager _screenManager;

        public Pokemon()
        {
            Content.RootDirectory = "Content";

            _graphics = new GraphicsDeviceManager(this)
                            {
                                PreferredBackBufferWidth = 512,
                                PreferredBackBufferHeight = 768,
                            };

            IsMouseVisible = true;
            Window.Title = "PokéEngine";

            _screenManager = new ScreenManager(this)
                                 {
                                     GameViewPort = new Viewport(0, 0, 512, 384),
                                     TouchViewPort = new Viewport(0, 384, 512, 384)
                                 };

            _screenManager.AddScreen(new TouchScreen());
            _screenManager.AddScreen(new OverworldScreen());
            Components.Add(_screenManager);
        }

        protected override void LoadContent()
        {
            //foreach (string asset in PreloadAssets)
            //    Content.Load<object>(asset);
        }

        protected override void Draw(GameTime gameTime)
        {
            _graphics.GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }
    }

    internal static class Program
    {
        private static void Main()
        {
            using (var game = new Pokemon())
                game.Run();
        }
    }
}