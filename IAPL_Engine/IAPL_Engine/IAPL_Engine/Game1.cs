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
        
        
        Zone map = new Zone(20, 15);
        Player player = new Player();

        Texture2D grass;
        Texture2D wall;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            // Setup graphic properties
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
            //graphics.ToggleFullScreen();
            graphics.ApplyChanges();
            
            //TEST
            setMap(ref map);
            player.setPlayerMap(ref map);
            //TEST

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("font");
            player.Texture = Content.Load<Texture2D>("debug_sprite_player");

            SetUpPlayer();
            //Test
            grass = Content.Load<Texture2D>("debug_grass_tile");
            wall = Content.Load<Texture2D>("debug_wall_tile");
            //TEST

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            
            ProcessKeyboard();
            player.ProcessMovements();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            DrawGround();
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

            if (Keyboard.GetState().IsKeyDown(Keys.Down)) //move down 2 px
                if (!player.isMoving)
                    if(!player.CheckCollisions("DOWN", graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight))
                        player.StartMove("DOWN");

            if (Keyboard.GetState().IsKeyDown(Keys.Left)) //move left 2 px
                if (!player.isMoving)
                    if (!player.CheckCollisions("LEFT", graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight))
                        player.StartMove("LEFT");

            if (Keyboard.GetState().IsKeyDown(Keys.Right)) // move right 2 px
                if (!player.isMoving)
                    if (!player.CheckCollisions("RIGHT", graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight))
                        player.StartMove("RIGHT");

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
         
        //TEST
        public void DrawGround()
        {

            for(int a = 0; a < 20; a++)
            {
                for (int b = 0; b < 15; b++)
                {
                    Rectangle place = new Rectangle(a * 32, (15*32) - (b * 32) -32, 32, 32);
                    if (map.tile[a, b].isClear())
                    {
                        spriteBatch.Draw(grass, place, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(wall, place, Color.White);
                    }
                }
            }
        }

        public static void setMap(ref Zone theMap)
        {
            for (int a = 5; a <= 15; a++)
            {
                for (int b = 5; b <= 10; b++)
                {
                    theMap.tile[a, b].setClear();
                }
            }
            theMap.tile[4, 8].setClear();
            theMap.tile[3, 8].setClear();
            theMap.tile[2, 8].setClear();
            theMap.tile[15, 11].setClear();
            theMap.tile[15, 12].setClear();
            theMap.tile[15, 13].setClear();
            theMap.tile[10, 4].setClear();
            theMap.tile[10, 3].setClear();
            theMap.tile[10, 2].setClear();
            theMap.tile[11, 2].setClear();
            theMap.tile[12, 2].setClear();
            theMap.tile[12, 3].setClear();
            theMap.tile[12, 4].setClear();
        }
        //TEST
    }
}