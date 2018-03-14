using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.IO;

namespace FungusInvasion {
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        
        SpriteBatch spriteBatch;
        Texture2D spriteSheet, background, playerTex, texStart, texEnd;
        Rectangle playerBox, playerSheet;
        Camera camera;
        public Vector2 cameraPos, playerPos, cameraStart;
        gameObject gameO;
        groundObject groundO;
        playerObject playerO;
        enemyObject enemyO;
        keyObject keyO;
        spikeObject spikeO;
        tntObject tntO;
        List<gameObject> gameList;
        List<Rectangle> groundRectList;
        String[] levelList;
        String textTile;
        public int levels, lives, currentLevel, tnt;
        public bool isStart, isEnd, nextLevel, isDead;

        public Game1() {
            IsMouseVisible = true;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            levels = 3;
            lives = 5;
            levelList = new String[levels];
            gameList = new List<gameObject>();
            groundRectList = new List<Rectangle>();
            currentLevel = 0;
            isStart = true;
            isEnd = false;
            nextLevel = false;

            graphics.PreferredBackBufferHeight = 1000;
            graphics.PreferredBackBufferWidth = 1800;

            FileReader();
        }

        protected override void LoadContent() {
            tnt = 0;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteSheet = Content.Load<Texture2D>("spriteSheet");
            background = Content.Load<Texture2D>("background");
            texStart = Content.Load<Texture2D>("FI_Start");
            texEnd = Content.Load<Texture2D>("FI_End");

            cameraStart = new Vector2(900, 500);
            cameraPos = cameraStart;

            
            spikeO = new spikeObject(spriteSheet, levelList, this);
            gameList.Add(spikeO);

            groundO = new groundObject(spriteSheet, levelList, this);
            gameList.Add(groundO);

            playerO = new playerObject(spriteSheet, levelList, this);
            gameList.Add(playerO);

            enemyO = new enemyObject(spriteSheet, levelList, this);
            gameList.Add(enemyO);

            keyO = new keyObject(spriteSheet, levelList, this);
            gameList.Add(keyO);

            tntO = new tntObject(spriteSheet, levelList, this);
            gameList.Add(tntO);

            Viewport view = GraphicsDevice.Viewport;
            camera = new Camera(view);
        }

        protected override void Update(GameTime gameTime) {
            Start();
            if (!isStart && !isEnd) {
                groundRectList = groundO.GetRect();
                playerPos = playerO.GetPos();
                spikeO.Update(groundRectList, gameTime);
                tntO.Update(groundRectList, gameTime);
                groundO.Update(groundRectList, gameTime);
                playerO.Update(groundRectList, gameTime);
                enemyO.Update(groundRectList, gameTime);
                keyO.Update(groundRectList, gameTime);
                groundO.TNT(playerPos, gameTime, this);

                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && playerPos.X > cameraPos.X + 400) {
                cameraPos.X += 4;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && playerPos.X < cameraPos.X - 400) {
                cameraPos.X -= 4;
            }
            Dead();
            NextLevel();
            camera.SetPosition(cameraPos);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetTransform());
            

            if (!isStart && !isEnd) {
                spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                foreach (gameObject gameO in gameList) {
                    gameO.Draw(spriteBatch);
                }
                for (int i = 0; i < lives; i++) {
                    spriteBatch.Draw(spriteSheet, new Vector2(50 * i + cameraPos.X - 900, 0), new Rectangle(1, 2, 40, 81), Color.White);
                }
                for (int i =0; i < tnt; i++) {
                    spriteBatch.Draw(spriteSheet, new Vector2(50 * i + cameraPos.X -600, 0), new Rectangle(102, 395, 50, 100), Color.White);
                }
            }
            if(isStart) {
                spriteBatch.Draw(texStart, new Vector2(0, 0), Color.White);
            }
            if(isEnd) {
                spriteBatch.Draw(texEnd, new Vector2(0, 0), Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void FileReader() {
            for (int i = 0; i < levels; i++) {
                StreamReader file = new StreamReader("c:\\lvl"+i+".txt");
                while (!file.EndOfStream) {
                    textTile += file.ReadLine();
                }
                file.Close();
                levelList[i] = textTile;
                textTile = "";
                
            }
        }
        public bool PixelCollision(Texture2D tex, Rectangle inputBox, Rectangle inputSheet) {
            playerTex = playerO.GetTex();
            playerBox = playerO.GetRect();
            playerSheet = playerO.GetSheet();

            Color[] dataA = new Color[tex.Width * tex.Height];
            tex.GetData(dataA);
            Color[] dataB = new Color[playerTex.Width * playerTex.Height];
            playerTex.GetData(dataB);

            int top = Math.Max(inputBox.Top, playerBox.Top);
            int bottom = Math.Max(inputBox.Bottom, playerBox.Bottom);
            int left = Math.Max(inputBox.Left, playerBox.Left);
            int right = Math.Max(inputBox.Right, playerBox.Right);

            for (int y = top; y < bottom; y++) {
                for (int x = left; x < right; x++) {
                    Color colorA = dataA[(x - inputBox.Left + inputSheet.X) + (y - inputBox.Top + inputSheet.Y) * tex.Width];
                    Color colorB = dataB[(x - playerBox.Left + playerSheet.X) + (y - playerBox.Top + playerSheet.Y) * playerTex.Width];

                    if (colorA.A != 0 && colorB.A != 0) {
                        return true;
                    }
                }
            }
            return false;
        }
        public void NextLevel () { 
            if (nextLevel) {
                currentLevel++; 
                nextLevel = false;
                if (currentLevel >= levels) {
                    isEnd = true;
                    cameraPos = cameraStart;
                }
                else {
                    groundRectList.Clear();
                    enemyO.Restart();
                    keyO.Restart();
                    playerO.Restart();
                    LoadContent();
                }  
            }
        }

        public void Start() {
            if (isStart) {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter)) {
                    isStart = false;
                }
            }
        }

        public void Dead() {
            if (isDead) {
                lives--;
                if (lives <= 0) {
                    isEnd = true;
                }
                else {
                    keyO.Restart();
                    groundRectList.Clear();
                    playerO.Restart();
                    enemyO.Restart();
                    tntO.Restart();
                    isDead = false;
                    LoadContent();
                }
            }
        }
    }
}
