using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace WhackAMole
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D textureBackground;
        Vector2 backgroundpos = new Vector2(0, 0);
        Texture2D GameOverTex;
        Texture2D malletTex;
        Rectangle malletRect;
        int moleKoTimer = 100;
        SpriteFont spriteFont;
        Mole mole;
        //Hole hole;
        //Foreground foreground;
        Texture2D moleTexture;
        Vector2 molepos;
        Texture2D holeTex;
        Texture2D foregroundTex;
        Rectangle boundingBox;
        int stopX;
        int stopY;
        int windowWidth = 650;
        int windowHeight = 1000;
        Random rand = new Random();
        float moleTimer; // tid för molevadarna
        float gameOverTimer;
        float spawnTimer = 2;


        //Texture2D malletTex;

        MouseState mouseState, previousMouseState;
        bool isVisible;
        int lives = 5;
        int score;
        bool isClicked;


        Mole[,] nymole; //skapar 2D array för Mole
        Hole[,] nyhole; // skapar 2D array för 3x3 matris for håll
        Foreground[,] nyforeground; // skapar 2D array för foreground


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.PreferredBackBufferWidth = windowWidth;
            graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            if (isClicked)
            {
                IsMouseVisible = true;
            }
            //IsMouseVisible = true;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            gameOverTimer = 10;

            //stopY = windowHeight;
            //stopX = windowWidth;
            //graphics.ApplyChanges();

            textureBackground = Content.Load<Texture2D>(@"background");
            holeTex = Content.Load<Texture2D>(@"hole (1)");
            foregroundTex = Content.Load<Texture2D>(@"hole_foreground");
            moleTexture = Content.Load<Texture2D>("mole");
            spriteFont = Content.Load<SpriteFont>("spriteFont");
            GameOverTex = Content.Load<Texture2D>(@"game-over");
            malletTex = Content.Load<Texture2D>(@"mallet");


            nyforeground = new Foreground[3, 3];
            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                    int x = a * 200 + 50;
                    int y = b * 300 + 160;
                    nyforeground[a, b] = new Foreground(foregroundTex, x, y);
                }
            }

            nyhole = new Hole[3, 3];

            for (int n = 0; n < 3; n++)
            {
                for (int m = 0; m < 3; m++)
                {
                    int x = n * 200 + 50;
                    int y = m * 300 + 160;
                    nyhole[n, m] = new Hole(holeTex, x, y);
                }
            }


            nymole = new Mole[3, 3]; //skapar 2D array

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int x = j * 200 + 50;
                    int y = i * 300 + 160;
                    boundingBox = new Rectangle(x, y, 20, 20);
                    nymole[i, j] = new Mole(moleTexture, x, y, new Vector2(0, -1), boundingBox);
                }
            }


            molepos = new Vector2(stopX / 2 - 80, stopY / 2 - 40);
            Vector2 pos = new Vector2(stopY);
            Vector2 moleVelocity = new Vector2(1, 1);

            boundingBox = new Rectangle(stopX / 2 - 10, stopY / 2 - 10, 20, 20);

            mole = new Mole(moleTexture, (int)molepos.X, (int)molepos.Y, moleVelocity, boundingBox);

            mouseState = Mouse.GetState();
            //textureBackground = Content.Load<Texture2D>(@"background");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //if (gameOverTimer > 10)
            //{
            //    spawnTimer = 0.5f;
            //}
            if (gameOverTimer > 0) // att spelet skall spelas under en viss tid .  - Float tid: --< . + float tid: <---
            {
                gameOverTimer = gameOverTimer - (float)gameTime.ElapsedGameTime.TotalSeconds;                              
                
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                        Exit();

                    previousMouseState = mouseState;
                    mouseState = Mouse.GetState();
                    malletRect = new Rectangle(mouseState.X - malletTex.Width / 2, mouseState.Y - malletTex.Height / 2, 
                                                malletTex.Width, malletTex.Height); //ersätter muset mot mallet


                    moleTimer = moleTimer + (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (moleTimer > spawnTimer) // vart 1:a sek skall en ny molvad dyka upp
                    {
                        nymole[rand.Next(0, 3), rand.Next(0, 3)].isVisible = true; //random position för molvadarna
                        moleTimer = 0;
                    }

                    for (int i = 0; i < nymole.GetLength(0); i++)
                    {
                        for (int j = 0; j < nymole.GetLength(1); j++)
                        {
                         nymole[i, j].Update(mouseState, previousMouseState, ref score, ref gameOverTimer); // ref score: hämtar mouseStaten fråm moleklassen
                        }
                    }
                



            }

            base.Update(gameTime);

        }




        //mole.Update(stopX,stopY);





        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGreen);

            spriteBatch.Begin();

            spriteBatch.Draw(textureBackground, backgroundpos, Color.White);

            //foreground.GetLength(0) används för att få storleken av arrayas
            // första deminsion

            //balls.GetLength(1) används för att få storleken av 
            // arrays andra deminsion

            for (int n = 0; n < nyhole.GetLength(0); n++)
            {

                for (int m = 0; m < nyhole.GetLength(1); m++)
                {
                    nyhole[n, m].Draw(spriteBatch);

                }

            }

            for (int i = 0; i < nymole.GetLength(0); i++)
            {
                for (int j = 0; j < nymole.GetLength(1); j++)
                {
                    nymole[i, j].Draw(spriteBatch);
                }
            }

            for (int a = 0; a < nyforeground.GetLength(0); a++)
            {
                for (int b = 0; b < nyforeground.GetLength(1); b++)
                {
                    nyforeground[a, b].Draw(spriteBatch);
                }
            }
        
            if(gameOverTimer < 0)
             {
                spriteBatch.Draw(GameOverTex, new Vector2(0, 0), Color.White);
            }

            spriteBatch.Draw(malletTex, malletRect, Color.White);




            spriteBatch.DrawString(spriteFont, "Tid kvar: " + gameOverTimer, Vector2.Zero, Color.Black);
            spriteBatch.DrawString(spriteFont, "Score " + score, new Vector2(0, 30), Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);

        }
    }
}
