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

// btw im back lol
// welcome back. Was beginning to wonder if you had fallen in or not.
// hello? im here, lol
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

            drawer = new PokeDraw();
            drawer.Content = Content;
            drawer.spriteBatch = spriteBatch;
            //drawer.setMap(ref map);

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
            
            ProcessKeyboard();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //map.drawMap(spriteBatch);
            drawer.drawTiles();
            DrawPlayer();
            DrawDebug();
            spriteBatch.End();

            base.Draw(gameTime);
        }


        //This will just display Debug Info, will be modified for whatever needs
        public void DrawDebug()
        {
            spriteBatch.DrawString(font, "(" + player.Rect.X + "," + player.Rect.Y + ")", new Vector2(player.Rect.X - 30, player.Rect.Y + 30), Color.White);
            spriteBatch.DrawString(font, "moveCounter: " + player.moveCounter, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(font, "isMoving: " + player.isMoving, new Vector2(0, 30), Color.White);
        }

        //This will process all the key functions
        public void ProcessKeyboard()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) //exit
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Up)) //move up
                if (!player.isMoving)
                    if(!player.CheckCollisions("UP", graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight))
                        player.StartMove("UP");

            if (Keyboard.GetState().IsKeyDown(Keys.Down)) //move down
                if (!player.isMoving)
                    if(!player.CheckCollisions("DOWN", graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight))
                        player.StartMove("DOWN");

            if (Keyboard.GetState().IsKeyDown(Keys.Left)) //move left
                if (!player.isMoving)
                    if (!player.CheckCollisions("LEFT", graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight))
                        player.StartMove("LEFT");

            if (Keyboard.GetState().IsKeyDown(Keys.Right)) // move right
                if (!player.isMoving)
                    if (!player.CheckCollisions("RIGHT", graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight))
                        player.StartMove("RIGHT");

            player.ProcessMovements();
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
        
    }
}
