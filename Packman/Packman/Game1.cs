using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Collections.Generic;

namespace Packman {
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D spriteSheet, tileSheet, texWall, meny;
        bool gameOver, isStart;
        Rectangle rectPac, superSheet, pacSheet, boomRect;
        Field field;
        Objects objects;
        Objects_Food objectsF;
        Objects_Pacman objectsP;
        Objects_Ghost objectsG;
        public List<Rectangle> rectTileList;
        List<int> scoreList;
        List<Field> fieldList;
        List<Objects> gameObjects;
        SpriteFont spriteFont;
        String txtScore,txtHighScore;
        int life, score, superPac, highScore;
        public List<String> listTile;
        public String textTile;
        public StringReader strReader;

        public Game1() {
            IsMouseVisible = true;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            listTile = new List<String>();
            fieldList = new List<Field>();
            gameObjects = new List<Objects>();
            rectTileList = new List<Rectangle>();
            scoreList = new List<int>();
            life = 4;
            highScore = 0;
            superSheet = new Rectangle(66, 98, 10, 10);
            pacSheet = new Rectangle(18, 1, 14, 14);
            score = 0;
            isStart = true;

            fileReader();

            graphics.PreferredBackBufferHeight = 710;
            graphics.PreferredBackBufferWidth = 570;
            graphics.ApplyChanges();

        }

        protected override void LoadContent() {
            gameOver = false;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteSheet = Content.Load<Texture2D>("SpriteSheet");
            tileSheet = Content.Load<Texture2D>("Tileset");
            texWall = Content.Load<Texture2D>("wall");
            spriteFont = Content.Load<SpriteFont>("spritefont");
            meny = Content.Load<Texture2D>("Pacman_SM");
            txtScore = "Score: "+score;
            txtHighScore = "Your highscore is: " + highScore;

            field = new Field(texWall, textTile);
            fieldList.Add(field);
            rectTileList = field.GetTile();

            objects = new Objects(spriteSheet, textTile);
            gameObjects.Add(objects);

            objectsF = new Objects_Food(spriteSheet, textTile);
            gameObjects.Add(objectsF);

            objectsP = new Objects_Pacman(spriteSheet, textTile, this);
            gameObjects.Add(objectsP);

            objectsG = new Objects_Ghost(spriteSheet, textTile);
            gameObjects.Add(objectsG);
            
        }
        
        protected override void Update(GameTime gameTime) {
            if (isStart) {
                Start();
            }

            if (!gameOver) {
                
                rectPac = objectsP.GetRectPac();
                boomRect = objectsP.Boom();
                score = objectsF.CheckPac(rectPac);
                superPac = objectsF.SuperPac(rectPac, superPac);
                life = objectsG.CheckPac(rectPac);
                superPac = field.DestroyWall(boomRect, superPac);
                
                if (score > highScore) {
                    highScore = score;
                }

                txtScore = "Score: " + score;
                txtHighScore = "Your highscore is: " + highScore;

                objectsF.Update(gameTime);
                objectsG.Update(gameTime);
                objectsP.Update(gameTime);

                if (life <= 0 || score >= 186) {
                    gameOver = true;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && gameOver) {
                life = 4;
                superPac = 0;
                highScore = score;
                Console.WriteLine("Highscore: " + highScore);
                txtHighScore = "Your highscore is: " + highScore;
                scoreList.Add(highScore);
                score = 0;
                rectTileList.Clear();
                gameObjects.Clear();
                LoadContent();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            if (isStart) {
                spriteBatch.Draw(meny, new Vector2(0,0), Color.White);
            }

            if (!gameOver && !isStart) {
                foreach (Field field in fieldList) {
                    field.Draw(spriteBatch, textTile);
                }
                foreach (Objects objects in gameObjects) {
                    objects.Draw(spriteBatch);
                }
                
                spriteBatch.DrawString(spriteFont, txtScore, new Vector2((graphics.PreferredBackBufferWidth / 2 - 5), 10), Color.White);

                for (int i = 0; i < life; i++) {
                    spriteBatch.Draw(spriteSheet, new Rectangle(35 * i + 5, 10, 30, 30), pacSheet, Color.White);
                }
                for (int i= 0; i < superPac; i++) {
                    spriteBatch.Draw(spriteSheet, new Rectangle(35 * i + 400, 10, 30, 30), superSheet, Color.White);
                }
            }
            if (gameOver && !isStart) {
                spriteBatch.DrawString(spriteFont, "Press Enter to restart!", new Vector2(30, 300), Color.White, 0, new Vector2(), 3, SpriteEffects.None, 0);
                spriteBatch.DrawString(spriteFont, txtHighScore, new Vector2(30, 350), Color.White, 0, new Vector2(), 3, SpriteEffects.None, 0);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void fileReader() {
            StreamReader file = new StreamReader("c:\\Tilepos.txt");
            while (!file.EndOfStream) {
                textTile += file.ReadLine();
            }
            file.Close();
            foreach (String textTile in listTile) {
                Console.WriteLine(textTile);
            }
        }
        public void Start() {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter)) {
                isStart = false;
            }
        }
        
    }

}
