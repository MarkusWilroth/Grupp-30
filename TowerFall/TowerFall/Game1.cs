using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.IO;
using Spline;
using System.Linq;

namespace TowerFall {

    enum GameState {
        MainMenu, Play, GamePause, End,
    }

    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D spriteSheet, explosion;
        List<GameObject> gameList;
        List<Vector2> posList, grassPosList, roadPosList, towerHUDList;
        List<Rectangle> roadRectList;
        List<Texture2D> textures;
        List<Bullet> bulletList;
        Rectangle roadRect, bulletRect;
        TowerObject towerO;
        RoadObject roadO;
        EnemyObject enemyO;
        GrassObject grassO;
        ParticleEngine particleEngine;
        Bullet bullet;
        TowerManager towerM; //Min manager för att styra torn, fungerar som Game1 använder den för att minska koden i Game1
        WaveManager waveM; //Min manager för att styra fienderna, det är här de skapas med antal beroend på vilken wave det är
        Vector2 pos, fontHPPos, fontCoinsPos;
        SpriteFont spriteFont;
        GameState gameState;
        String[] printLevel;
        String getLine, HPText, coinsText;
        bool movingDown, movingUp, movingLeft, movingRight, killBullet;
        public SimplePath path; //Spline sak, ni kanske kan hitta en bättre algoritm för att rita ut spline men min fungerar... ritar ni kartan som jag gör vet jag inte om man kan
                                //rita ut splinen på ett annat sett men glöm inte att ändra så att det inte ser lika dant ut som mitt... tror inte han kommer bry sig men onödig risk
        int  groundX, groundY, activeSplineX, activeSplineY, bulletDamage, HP; //activeSpline används i min spline algoritm 
        char textLetter;
        public int levels, currentLevel, coins;
        public MouseState mouseState, oldMouseState;



        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
            fontHPPos = new Vector2(20, 20);
            fontCoinsPos = new Vector2(20, 40);
            levels = 1; //Om du ska ha flera banor glöm inte att ändra denna!

            printLevel = new String[levels];
            textures = new List<Texture2D>();
            bulletList = new List<Bullet>();
            gameList = new List<GameObject>();
            grassPosList = new List<Vector2>();
            roadPosList = new List<Vector2>();
            posList = new List<Vector2>();
            towerHUDList = new List<Vector2>();
            roadRectList = new List<Rectangle>();
            
            FileReader();   //Läser av filerna så att banan kan ritas ut
            graphics.PreferredBackBufferWidth = 1150;
            graphics.PreferredBackBufferHeight = 700;
            
        }
    
        
       
        

        protected override void Initialize() {

            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteSheet = Content.Load<Texture2D>("spriteSheet");
            spriteFont = Content.Load<SpriteFont>("spriteFont");
            textures.Add(Content.Load<Texture2D>("explosion")); //har den seperat så att jag kan lägga in den i particleEngine (Ett krav att man skulle ha med en sådan)
            particleEngine = new ParticleEngine(textures, new Vector2(1000000, 1000000)); //Följ tutorian för detta, skrev bara rakt av från den och ändrade några värden på slutet
            towerM = new TowerManager(spriteSheet);
            path = new SimplePath(graphics.GraphicsDevice);
            path.Clean(); //Spline sak, gör så att du inte har en spiral i mitten
            gameState = GameState.MainMenu; //Tänkt att den skulle börja om när man var klar men spline gjorde så att jag inte kunde börja om... men att börja om var inte krav, bara att det skulle avslutas när x antal waves var klara eller hp <= 0
            HPText = "HP: " + HP;
            coinsText = "";
            activeSplineX = 75; //startvärdet, behövs ritas ut av någon anledning, man kan lösa detta med att i Spline ha roadRectList.Count <= 1 istället för roadRectList.Any() men orkade inte bry mig
            activeSplineY = 125;
            coins = 100;
            HP = 100;

            grassPosList = GetPos('-', currentLevel); //Ritar ut gräs på alla rutor som har värdet '-' kolla text filen för att se det
            foreach (Vector2 pos in grassPosList) {
                grassO = new GrassObject(spriteSheet, pos);
                gameList.Add(grassO);
            }

            roadPosList = GetPos('r', currentLevel);
            foreach (Vector2 pos in roadPosList) {
                roadO = new RoadObject(spriteSheet, pos);
                gameList.Add(roadO);
                roadRect = new Rectangle((int)pos.X + 25, (int)pos.Y + 25, 50, 50);
                roadRectList.Add(roadRect); //La in det i en seperat lista för att kunna ha det som en counter samt se till att ingen roadRect missades vid spline ritningen
            }

            towerHUDList = GetPos(' ', currentLevel);
            foreach (Vector2 pos in towerHUDList) {
                towerM.TowerHUD(pos);
            }
            Spline(); //Tar er till min spline algoritm!
            waveM = new WaveManager(spriteSheet, this, towerM);
        }

        protected override void Update(GameTime gameTime) {
            oldMouseState = mouseState;
            mouseState = Mouse.GetState();
            HPText = "HP: " + HP;

            switch (gameState) {
                case (GameState.MainMenu):
                    if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released) {
                        gameState = GameState.Play;
                    }
                    break;
                case (GameState.Play):
                    coinsText = "Coins: " + coins;
                    GetMouseState(); //Borde ha bytt namn på dena metod till typ buildTower eller något.. men men
                    waveM.Update(gameTime);
                    towerM.Update(gameTime, this);
                    particleEngine.Update();

                    foreach (Bullet bullet in bulletList) {
                        bullet.Update();
                        bulletRect = bullet.GetRect();
                        bulletDamage = bullet.GetDamage();
                        waveM.Shoot(bulletDamage, bulletRect, particleEngine);

                        if (killBullet) { 
                            bulletList.Remove(bullet);
                            killBullet = false;
                            break;
                        }
                    }
                    break;
                case (GameState.End): //Funkar inte
                    movingDown = false;
                    movingLeft = false;
                    movingRight = false;
                    movingUp = false;
                    Initialize();
                    break;
            }
            

            base.Update(gameTime);
        }

        public void TakeDamage(int damage) {
            HP -= damage;
            if (HP <= 0) {
                gameState = GameState.End;
            }
        }

        public void CreatBullet(Vector2 shotPos, double direction, int damage) {
            bullet = new Bullet(spriteSheet, shotPos, direction, damage, this);
            bulletList.Add(bullet);
        }
        public void KillBullet() {
            killBullet = true;
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
            if (gameState == GameState.Play) {
                spriteBatch.Begin();

                foreach (GameObject gameO in gameList) {
                    gameO.Draw(spriteBatch);
                }
                foreach (Bullet bullet in bulletList) {
                    bullet.Draw(spriteBatch);
                }
                towerM.Draw(spriteBatch);
                waveM.Draw(spriteBatch);
                spriteBatch.DrawString(spriteFont, HPText, fontHPPos, Color.White);
                spriteBatch.DrawString(spriteFont, coinsText, fontCoinsPos, Color.White);
                particleEngine.Draw(spriteBatch);
                //path.Draw(spriteBatch); avkommentera denna för att se hur splinen ritas ut, kan underlätta att se vad som är fel
                base.Draw(gameTime);

                spriteBatch.End();
            }
            
        }
        public void EndGame() {
            gameState = GameState.End;
        }

        public void FileReader() {
            for (int i = 0; i < 1; i++) {
                StreamReader file = new StreamReader("TF-lvl" + i + ".txt"); //Om ni döper textfilen till något annat glöm inte att ändra namn på denna!
                while (!file.EndOfStream) {
                    getLine += file.ReadLine();
                }
                file.Close();
                printLevel[i] = getLine;
                getLine = "";

            }
        }

        public void GetMouseState () {
            if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released) {
                foreach (Vector2 pos in roadPosList) {
                    for (int i = 0; i < towerM.towers; i++) {
                        towerM.BuildTower(mouseState.X, mouseState.Y, mouseState, i, pos);
                    }
                }
            }

        }

        protected List<Vector2> GetPos(char getLetter, int currentLevel) { //Använder samma algoritm på PlaceHolder-Name-Game 
            posList.Clear();
            for (int i = 0; i < printLevel[currentLevel].Length; i++) {
                textLetter = printLevel[currentLevel][i];

                if (textLetter == getLetter) {
                    pos = new Vector2(groundX, groundY);
                    posList.Add(pos);
                    groundX += 50;
                } else if (textLetter == '|') {
                    groundX = 0;
                    groundY += 50;
                } else if (textLetter == '#') {
                    groundX = 0;
                    groundY = 0;
                } else {
                    groundX += 50;
                }
            }
            return posList;
        }

        public void Spline() { //Borde kunna göras på ett snyggare sett.. mycket kod upprepas men det funkar!
            while (roadRectList.Any()) {
                foreach (Rectangle roadRect in roadRectList) {
                    if (roadRect.Contains(new Vector2(activeSplineX, activeSplineY + 50)) && !movingUp) {
                        movingDown = true;
                        movingRight = false;
                        movingLeft = false;
                        activeSplineY += 50;
                        path.AddPoint(new Vector2(activeSplineX, activeSplineY));
                        roadRectList.Remove(roadRect);
                        break;

                    } else {
                        movingDown = false;
                    }

                    if (roadRect.Contains(new Vector2(activeSplineX + 50, activeSplineY)) && !movingLeft) {
                        movingRight = true;
                        movingUp = false;
                        movingDown = false;
                        activeSplineX += 50;
                        path.AddPoint(new Vector2(activeSplineX, activeSplineY));
                        roadRectList.Remove(roadRect);
                        break;

                    } else {
                        movingLeft = false;
                    }

                    if (roadRect.Contains(new Vector2(activeSplineX, activeSplineY - 50)) && !movingDown) {
                        movingUp = true;
                        movingLeft = false;
                        movingRight = false;
                        activeSplineY -= 50;
                        path.AddPoint(new Vector2(activeSplineX, activeSplineY));
                        roadRectList.Remove(roadRect);
                        break;
                    } else {
                        movingDown = false;
                    }

                    if (roadRect.Contains(new Vector2(activeSplineX - 50, activeSplineY)) && !movingRight) {
                        movingLeft = true;
                        movingUp = false;
                        movingDown = false;
                        activeSplineX -= 50;
                        path.AddPoint(new Vector2(activeSplineX, activeSplineY));
                        roadRectList.Remove(roadRect);
                        break;
                    } else {
                        movingRight = false;
                    }
                }
            }
        }
    }
}
