using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xna.Framework.Input;

namespace Pokemon.Core
{
    public class InputState
    {
        public readonly Dictionary<string, Keys> KeyMap = new Dictionary<string, Keys>();
        public KeyboardState CurrentKeyboardState;
        public KeyboardState LastKeyboardState;

        public InputState()
        {
            CurrentKeyboardState = new KeyboardState();
            LastKeyboardState = new KeyboardState();
        }

        public bool KeyRepeat { get; set; }

        public void Initialize()
        {
            IEnumerable keys = from key in XElement.Load("Config/input.xml").Elements("Key") select key;

            foreach (XElement key in keys)
            {
                XAttribute xAttribute = key.Attribute("name");
                if (xAttribute != null) KeyMap.Add(xAttribute.Value, (Keys) Enum.Parse(typeof (Keys), key.Value));
            }
        }

        public void Update()
        {
            LastKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();
        }

        public bool IsKeyPressed(Keys key)
        {
            if (KeyRepeat)
                return CurrentKeyboardState.IsKeyDown(key);

            return (CurrentKeyboardState.IsKeyDown(key) &&
                    LastKeyboardState.IsKeyUp(key));
        }

        public bool IsStartPressed()
        {
            return IsKeyPressed(KeyMap["Start"]);
        }

        public bool IsSelectPressed()
        {
            return IsKeyPressed(KeyMap["Select"]);
        }

        public bool IsAPressed()
        {
            return IsKeyPressed(KeyMap["A"]);
        }

        public bool IsBPressed()
        {
            return IsKeyPressed(KeyMap["B"]);
        }

        public bool IsXPressed()
        {
            return IsKeyPressed(KeyMap["X"]);
        }

        public bool IsYPressed()
        {
            return IsKeyPressed(KeyMap["Y"]);
        }

        public bool IsLPressed()
        {
            return IsKeyPressed(KeyMap["L"]);
        }

        public bool IsRPressed()
        {
            return IsKeyPressed(KeyMap["R"]);
        }

        public bool IsUpPressed()
        {
            return IsKeyPressed(KeyMap["Up"]);
        }

        public bool IsDownPressed()
        {
            return IsKeyPressed(KeyMap["Down"]);
        }

        public bool IsLeftPressed()
        {
            return IsKeyPressed(KeyMap["Left"]);
        }

        public bool IsRightPressed()
        {
            return IsKeyPressed(KeyMap["Right"]);
        }
    }
}