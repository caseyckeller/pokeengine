using System;
using System.Linq;
using System.Xml.Linq;
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
            XDocument xDocument = XDocument.Load("Config/game.xml");
            XElement setting = xDocument.Descendants("Settings").Single();

            Content.RootDirectory = "Content";

            _graphics = new GraphicsDeviceManager(this)
                            {
                                PreferredBackBufferWidth = Convert.ToInt32(setting.Element("Width").Value),
                                PreferredBackBufferHeight = Convert.ToInt32(setting.Element("Height").Value),
                            };

            _screenManager = new ScreenManager(this);

            var viewports = from viewport in setting.Descendants("Viewport")
                            select new
                                       {
                                           Name = viewport.Element("Name").Value,
                                           X = Convert.ToInt32(viewport.Element("X").Value),
                                           Y = Convert.ToInt32(viewport.Element("Y").Value),
                                           Width = Convert.ToInt32(viewport.Element("Width").Value),
                                           Height = Convert.ToInt32(viewport.Element("Height").Value),
                                       };

            foreach (var viewport in viewports)
                _screenManager.Viewports.Add(viewport.Name,
                                             new Viewport(viewport.X, viewport.Y, viewport.Width, viewport.Height));

            _screenManager.AddScreen(new TouchScreen());
            _screenManager.AddScreen(new OverworldScreen());

            Components.Add(_screenManager);

            IsMouseVisible = true;
            Window.Title = setting.Element("Title").Value;
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