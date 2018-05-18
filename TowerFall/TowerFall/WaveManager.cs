using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;
using Spline;

namespace TowerFall {
    class WaveManager {
        int waveCounter, enemyCounter, bossCounter, timer;
        bool ongoingWave, enemyDown, killBullet;
        KeyboardState keyboardState, oldKeyboardState;
        EnemyObject enemyO;
        Texture2D spriteSheet;
        List<EnemyObject> enemyList;
        Queue<WaveManager> waves = new Queue<WaveManager>();
        Game1 game;
        TowerManager towerM;
        Vector2 pos, endPos;
        SimplePath path;

        public WaveManager(Texture2D spriteSheet, Game1 game, TowerManager towerM) {
            this.spriteSheet = spriteSheet;
            this.game = game;
            this.towerM = towerM;
            waveCounter = 0;
            enemyCounter = 0;
            bossCounter = 0;
            ongoingWave = false;
            enemyList = new List<EnemyObject>();
            pos = game.path.GetPos(game.path.beginT);
            endPos = game.path.GetPos(game.path.endT);
        }

        public void Update(GameTime gameTime) {
            keyboardState = Keyboard.GetState();
            if (!(enemyList.Any()) && keyboardState.IsKeyDown(Keys.Enter) && oldKeyboardState.IsKeyUp(Keys.Enter)) {
                startWave();
            }
            if (ongoingWave) {
                if (enemyCounter > 0) {
                    timer++;
                    if (timer >= 60) { //Ser till att alla fiender inte spawnar på ett o samma ställe, kan lösas med queue<> men orkade inte gå in på det
                        SpawnEnemies();
                        timer = 0;
                    } 
                } else {
                    ongoingWave = false;
                }
            }

            foreach (EnemyObject  enemyO in enemyList) {
                enemyO.Update(gameTime, game.path.GetPos(enemyO.posSpeed), game, this, towerM); //game.path.GetPos(enemyO.posSpeed) är viktigt och inget du borde ändra om det inte är för att ändra namn
                if (enemyDown) {
                    enemyList.Remove(enemyO);
                    break;
                }
            }
            enemyDown = false;
            oldKeyboardState = keyboardState;
        }
        public void KillEnemy() {
            enemyDown = true;
        }

        public void Shoot(int damage, Rectangle shootRect, ParticleEngine particleEngine) {
            foreach (EnemyObject enemyO in enemyList) {
                killBullet = enemyO.GetHit(damage, shootRect, game, particleEngine); //Får in bulletRect från Bullet och kollar varje enemyO ifall den träffar någon, har den här för det är här enemyList är
                if (killBullet) {
                    break;
                }
            }
        }

        public void SpawnEnemies() {
            bossCounter++;
            if (bossCounter >= 5) { //var femte fiende är en boss med bättre stats
                enemyO = new EnemyObject(spriteSheet, 10, 20, 0, pos, endPos); //damage avgör hur mycket skada den gör när den kommer fram
                bossCounter = 0;
            } else {
                enemyO = new EnemyObject(spriteSheet, 5, 10, 1, pos, endPos);
            }
            enemyList.Add(enemyO);
            enemyCounter--;
        }

        public void startWave() {
            enemyCounter = 5 + 3 * waveCounter; //5 och 3 bestämmer hur många fiender det kommer vara på waven, har så att det börjar med 5 men ökar med 3 för varje wave
            ongoingWave = true;
            waveCounter++;
            Console.WriteLine("Wave: " + waveCounter);
            if (waveCounter >= 10) { //10 är hur många waves det är innan spelet är slut, KRAV
                game.EndGame();
            }
        }

        public void Draw(SpriteBatch SB) {
            foreach (EnemyObject enemyO in enemyList) {
                enemyO.Draw(SB);
            }
        }

    }
}
