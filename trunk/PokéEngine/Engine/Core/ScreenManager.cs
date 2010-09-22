using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pokemon.Screens;

namespace Pokemon.Core
{
    public class ScreenManager : DrawableGameComponent
    {
        private readonly InputState _input = new InputState();
        private readonly List<GameScreen> _screens = new List<GameScreen>();
        private readonly List<GameScreen> _screensToUpdate = new List<GameScreen>();
        private Texture2D _blankTexture;
        private bool _isInitialized;
        private bool _traceEnabled;

        public ScreenManager(Game game)
            : base(game)
        {
        }

        public Viewport BottomViewPort { get; set; }
        public Viewport TopViewPort { get; set; }

        public SpriteBatch SpriteBatch { get; private set; }

        public SpriteFont Font { get; private set; }

        public bool TraceEnabled
        {
            get { return _traceEnabled; }
            set { _traceEnabled = value; }
        }

        public override void Initialize()
        {
            base.Initialize();

            _input.Initialize();

            _isInitialized = true;
        }

        protected override void LoadContent()
        {
            ContentManager content = Game.Content;

            SpriteBatch = new SpriteBatch(GraphicsDevice);
            //Font = content.Load<SpriteFont>("menufont");
            _blankTexture = content.Load<Texture2D>("blank");

            foreach (GameScreen screen in _screens)
                screen.LoadContent();
        }

        protected override void UnloadContent()
        {
            foreach (GameScreen screen in _screens)
                screen.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            _input.Update();

            _screensToUpdate.Clear();

            foreach (GameScreen screen in _screens)
                _screensToUpdate.Add(screen);

            bool otherScreenHasFocus = !Game.IsActive;
            bool coveredByOtherScreen = false;

            while (_screensToUpdate.Count > 0)
            {
                GameScreen screen = _screensToUpdate[_screensToUpdate.Count - 1];

                _screensToUpdate.RemoveAt(_screensToUpdate.Count - 1);

                screen.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

                if (screen.ScreenState == ScreenState.TransitionOn ||
                    screen.ScreenState == ScreenState.Active)
                {
                    if (!otherScreenHasFocus)
                    {
                        screen.HandleInput(_input);

                        otherScreenHasFocus = true;
                    }

                    if (!screen.IsPopup)
                        coveredByOtherScreen = true;
                }
            }

            if (_traceEnabled)
                TraceScreens();
        }

        private void TraceScreens()
        {
            Debug.WriteLine(string.Join(", ", _screens.Select(screen => screen.GetType().Name).ToArray()));
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (GameScreen screen in _screens)
            {
                if (screen.ScreenState == ScreenState.Hidden)
                    continue;

                screen.Draw(gameTime);
            }
        }

        public void AddScreen(GameScreen screen)
        {
            screen.ScreenManager = this;
            screen.IsExiting = false;

            if (_isInitialized)
                screen.LoadContent();

            _screens.Add(screen);
        }

        public void RemoveScreen(GameScreen screen)
        {
            if (_isInitialized)
                screen.UnloadContent();

            _screens.Remove(screen);
            _screensToUpdate.Remove(screen);
        }

        public IEnumerable<GameScreen> GetScreens()
        {
            return _screens.ToArray();
        }

        public void FadeBackBufferToBlack(float alpha)
        {
            Viewport viewport = GraphicsDevice.Viewport;

            SpriteBatch.Begin();

            SpriteBatch.Draw(_blankTexture,
                              new Rectangle(0, 0, viewport.Width, viewport.Height),
                              Color.Black * alpha);

            SpriteBatch.End();
        }
    }
}