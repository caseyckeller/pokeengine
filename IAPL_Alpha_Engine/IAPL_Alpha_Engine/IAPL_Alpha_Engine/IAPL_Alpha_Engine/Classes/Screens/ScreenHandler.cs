using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace IAPL_Alpha_Engine.Classes.Screens
{
    static class ScreenHandler
    {

        public struct Textures
        {

            public static Texture2D DialogueBox;
            public static Texture2D YesNoBox;
            public static Texture2D OptionsBox;
            public static Texture2D GameMenuBox;
            public static Texture2D TitleMenuBox;

            public static Texture2D Marker;
        }

        public struct Rectangles
        {
            public static Rectangle DialogueBox = new Rectangle(320 - (Textures.DialogueBox.Width / 2), 480 - Textures.DialogueBox.Height, Textures.DialogueBox.Width, Textures.DialogueBox.Height);
            public static Rectangle YesNoBox = new Rectangle(DialogueBox.Right - Textures.YesNoBox.Width, DialogueBox.Top - Textures.YesNoBox.Height, Textures.YesNoBox.Width, Textures.YesNoBox.Height);
            public static Rectangle OptionsBox = new Rectangle(0, 0, Textures.OptionsBox.Width, Textures.OptionsBox.Height);
            public static Rectangle GameMenuBox = new Rectangle(640 - Textures.GameMenuBox.Width, 0, Textures.GameMenuBox.Width, Textures.GameMenuBox.Height);
            public static Rectangle TitleMenuBox = new Rectangle(20, 20, Textures.TitleMenuBox.Width, Textures.TitleMenuBox.Height);

            public static Rectangle Marker = new Rectangle(0, 0, Textures.Marker.Width, Textures.Marker.Height);
        }

        public struct Visible
        {
            public static bool DialogueBox = false;
            public static bool YesNoBox = false;
            public static bool OptionsBox = false;
            public static bool GameMenuBox = false;
            public static bool TitleMenuBox = false;

            public static bool Marker = false;
        }

        public struct Sounds
        {
            public static SoundEffect Marker_Up;
            public static SoundEffect Marker_Down;
            public static SoundEffect Menu_Select;
        }

        static GraphicsDeviceManager graphics;
        static SpriteBatch spriteBatch;
        static ContentManager content;
        static SpriteFont font;

        static private int animateLength = 0;
        static private int currentAnimateIndex = 0;
        static private string animateStringOne = "";
        static private string animateStringTwo = "";
        static private int maxLineLength = 11;
        static private int animateLines = 0;
        static private string stringtobeAnimated = null;
        static private bool dboxSent = false;
        static private bool isAnimating = false;

        public static ActiveScreen activeScreen { get; set; }

        public enum ActiveScreen { Title, Game }

        /// <summary>
        /// Initializes the Screen handler and starts the game.
        /// </summary>
        static public void Initialize(GraphicsDeviceManager g, SpriteBatch s, ContentManager c, SpriteFont f)
        {
            graphics = g;
            spriteBatch = s;
            content = c;
            font = f;

            activeScreen = ActiveScreen.Title;
            TitleScreen.Initialize(g,s,c,f);
            DialogBox.Initialize(g,s,c,f);
            TitleScreen.LoadContent();
        }

        /// <summary>
        /// Load's the content of the ScreenHandler class
        /// </summary>
        static public void LoadContent()
        {
            Textures.DialogueBox = content.Load<Texture2D>(@"Textures\Textboxes\A\DialogueBoxA");
            Textures.YesNoBox = content.Load<Texture2D>(@"Textures\Textboxes\A\YesNoBoxA");
            Textures.OptionsBox = content.Load<Texture2D>(@"Textures\Textboxes\A\OptionsBoxA");
            Textures.GameMenuBox = content.Load<Texture2D>(@"Textures\Textboxes\A\GameMenuBoxA");
            Textures.TitleMenuBox = content.Load<Texture2D>(@"Textures\Textboxes\A\TitleMenuBoxA");

            Textures.Marker = content.Load<Texture2D>(@"Textures\Textboxes\Marker");

            Sounds.Marker_Up = content.Load<SoundEffect>(@"SoundEffects\Menu\marker_up");
            Sounds.Marker_Down = content.Load<SoundEffect>(@"SoundEffects\Menu\marker_down");
            Sounds.Menu_Select = content.Load<SoundEffect>(@"SoundEffects\Menu\menu_select");
        }

        /// <summary>
        /// Calls the active screen's update function
        /// </summary>
        static public void Update()
        {
            switch (activeScreen)
            {
                case ActiveScreen.Title:
                    TitleScreen.Update();
                    break;

                case ActiveScreen.Game:
                    GameScreen.Update();
                    break;
            }
        }

        /// <summary>
        /// Calls the active screen's draw function
        /// </summary>
        static public void Draw()
        {
            if (DialogBox.isVisible)
                DialogBox.Draw();
            if (Visible.YesNoBox)
                spriteBatch.Draw(ScreenHandler.Textures.YesNoBox, ScreenHandler.Rectangles.YesNoBox, Color.White);
            if (Visible.OptionsBox)
                spriteBatch.Draw(ScreenHandler.Textures.OptionsBox, ScreenHandler.Rectangles.OptionsBox, Color.White);
            if (Visible.GameMenuBox)
                spriteBatch.Draw(ScreenHandler.Textures.GameMenuBox, ScreenHandler.Rectangles.GameMenuBox, Color.White);
            if (Visible.TitleMenuBox)
                spriteBatch.Draw(ScreenHandler.Textures.TitleMenuBox, ScreenHandler.Rectangles.TitleMenuBox, Color.White);
            if (Visible.Marker)
                spriteBatch.Draw(ScreenHandler.Textures.Marker, ScreenHandler.Rectangles.Marker, Color.White);

            switch (activeScreen)
            {
                case ActiveScreen.Title:
                    TitleScreen.Draw();
                    break;

                case ActiveScreen.Game:
                    GameScreen.Draw();
                    break;
            }
        }

        static public void SendDialogueBox(string s)
        {
            dboxSent = true;
            stringtobeAnimated = s;
            animateLength = s.Length;
            animateLines = 1;

        }

        static public void CheckDialogueBox()
        {
            if (dboxSent)
            {
                Visible.DialogueBox = true;
                isAnimating = true;
            }

            AnimateText(stringtobeAnimated);
        }

        static private void AnimateText(string s)
        {
            if (currentAnimateIndex < animateLength)
            {
                if (currentAnimateIndex <= 11)
                    animateStringOne = s.Substring(0, currentAnimateIndex);
                else
                {
                    animateStringOne = s.Substring(0, 11);
                    if (currentAnimateIndex <= 22)
                        animateStringTwo = s.Substring(12, currentAnimateIndex);
                    else
                    {
                        animateStringOne = animateStringTwo;
                    }
                }
            }
        }
    }
}
