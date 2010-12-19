using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using IAPL.Pokemon_Library;
using IAPL.Map;

namespace IAPL_Engine
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        PokeDraw drawer;

        #region TestStuff
        Map.Map _map = new Map.Map();

        Zone map = new Zone(20, 15);
        #endregion

        Player player = new Player();
        KeyboardHandler keyboardHandler;

        #region FPS Benchmarking
        int frameRate = 0;
        int frameCounter = 0;
        TimeSpan elapsedTime = TimeSpan.Zero;
        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            // Setup graphic properties.
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
            //graphics.ToggleFullScreen();
            graphics.ApplyChanges();

            #region TEST
            map.setMap();
            player.setPlayerMap(ref map);
            #endregion

            drawer = new PokeDraw(GraphicsDevice);
            drawer.Content = Content;
            drawer.spriteBatch = spriteBatch;
            //drawer.setMap(ref map);

            keyboardHandler = new KeyboardHandler(player);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            drawer.Content = Content;
            drawer.setMapAndBatch(ref map, ref spriteBatch);

            font = Content.Load<SpriteFont>("font");

            player.Texture = Content.Load<Texture2D>("WorldObject/Player/debug_sprite_player");
            drawer.loadTextures();

            SetUpPlayer();

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {

            keyboardHandler.ProcessKeyboard();

            UpdateFPS(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            drawer.drawTiles();
            DrawPlayer();
            DrawDebug();

            spriteBatch.End();

            base.Draw(gameTime);
        }


        //This will just display Debug Info, will be modified for whatever needs
        public void DrawDebug()
        {
            frameCounter++;

            string fps = string.Format("fps: {0}", frameRate);

            spriteBatch.DrawString(font, fps, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(font, "(" + player.Rect.X + "," + player.Rect.Y + ")", new Vector2(player.Rect.X - 30, player.Rect.Y + 30), Color.White);
            
        }

        //This sets up the player rectangle, which holds information like Texture2D's and Position
        public void SetUpPlayer()
        {
            player.Rect.X = ((graphics.PreferredBackBufferWidth / 2) - player.Texture.Width);
            player.Rect.Y = ((graphics.PreferredBackBufferHeight / 2) - (player.Texture.Height / 2));
            player.Rect.Width = player.Texture.Width;
            player.Rect.Height = player.Texture.Height;
        }

        //This just Draws the player's Rectangle using the player's Texture2D
        public void DrawPlayer()
        {
            spriteBatch.Draw(player.Texture, player.Rect, Color.White);
        }

        public void UpdateFPS(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }

        }
        
    }
}
