using System;
using Microsoft.Xna.Framework;
using Pokemon.Core;

namespace Pokemon.Screens
{
    public enum ScreenState
    {
        TransitionOn,
        TransitionOff,
        Active,
        InActive,
        Hidden,
    }

    public abstract class GameScreen
    {
        private bool _isExiting;
        private bool _otherScreenHasFocus;
        private ScreenState _screenState = ScreenState.TransitionOn;
        private TimeSpan _transitionOffTime = TimeSpan.Zero;
        private TimeSpan _transitionOnTime = TimeSpan.Zero;
        private float _transitionPosition = 1;

        public bool IsPopup { get; protected set; }

        public TimeSpan TransitionOnTime
        {
            get { return _transitionOnTime; }
            protected set { _transitionOnTime = value; }
        }

        public TimeSpan TransitionOffTime
        {
            get { return _transitionOffTime; }
            protected set { _transitionOffTime = value; }
        }

        public float TransitionPosition
        {
            get { return _transitionPosition; }
            protected set { _transitionPosition = value; }
        }

        public float TransitionAlpha
        {
            get { return 1f - TransitionPosition; }
        }

        public ScreenState ScreenState
        {
            get { return _screenState; }
            set { _screenState = value; }
        }

        public bool IsExiting
        {
            get { return _isExiting; }
            protected internal set { _isExiting = value; }
        }

        public bool IsActive
        {
            get
            {
                return !_otherScreenHasFocus &&
                       (_screenState == ScreenState.TransitionOn ||
                        _screenState == ScreenState.Active);
            }
        }

        public ScreenManager ScreenManager { get; internal set; }

        public virtual void LoadContent()
        {
        }

        public virtual void UnloadContent()
        {
        }

        public virtual void Update(GameTime gameTime, bool otherScreenHasFocus,
                                   bool coveredByOtherScreen)
        {
            _otherScreenHasFocus = otherScreenHasFocus;

            if (_isExiting)
            {
                _screenState = ScreenState.TransitionOff;

                if (!UpdateTransition(gameTime, _transitionOffTime, 1))
                    ScreenManager.RemoveScreen(this);
            }
            else if (coveredByOtherScreen)
                _screenState = UpdateTransition(gameTime, _transitionOffTime, 1)
                                   ? ScreenState.TransitionOff
                                   : ScreenState.Hidden;
            else if (IsActive)
                _screenState = UpdateTransition(gameTime, _transitionOnTime, -1)
                                   ? ScreenState.TransitionOn
                                   : ScreenState.Active;
        }

        private bool UpdateTransition(GameTime gameTime, TimeSpan time, int direction)
        {
            float transitionDelta;

            if (time == TimeSpan.Zero)
                transitionDelta = 1;
            else
            {
                transitionDelta = (float) (gameTime.ElapsedGameTime.TotalMilliseconds /
                                           time.TotalMilliseconds);
            }

            _transitionPosition += transitionDelta * direction;

            if (((direction < 0) && (_transitionPosition <= 0)) ||
                ((direction > 0) && (_transitionPosition >= 1)))
            {
                _transitionPosition = MathHelper.Clamp(_transitionPosition, 0, 1);
                return false;
            }

            return true;
        }

        public virtual void HandleInput(InputState input)
        {
        }

        public virtual void Draw(GameTime gameTime)
        {
        }

        public void ExitScreen()
        {
            if (TransitionOffTime == TimeSpan.Zero)
                ScreenManager.RemoveScreen(this);
            else
                _isExiting = true;
        }
    }
}