using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pokemon.Core;

namespace Pokemon.Screens
{
    internal class TouchScreen : GameScreen
    {
        private ContentManager _content;
        private Texture2D _texture2D;

        public TouchScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(0);
            TransitionOffTime = TimeSpan.FromSeconds(0);
        }

        public override void LoadContent()
        {
            if (_content == null)
                _content = new ContentManager(ScreenManager.Game.Services, "Content");

            _texture2D = _content.Load<Texture2D>("bottom");

            ScreenManager.Game.ResetElapsedTime();
        }

        public override void UnloadContent()
        {
            _content.Unload();
        }

        public override void HandleInput(InputState input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            if (input.IsStartPressed())
            {
                ScreenState = ScreenState.InActive;
                foreach (var screen in ScreenManager.GetScreens().OfType<OverworldScreen>())
                {
                    screen.ScreenState = ScreenState.Active;
                }
            }
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                    bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);
        }

        public override void Draw(GameTime gameTime)
        {
            Viewport viewport = ScreenManager.BottomViewPort;

            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();

            spriteBatch.Draw(_texture2D, new Rectangle(viewport.X, viewport.Y, viewport.Width, viewport.Height),
                             Color.White);
            spriteBatch.End();
        }
    }
}