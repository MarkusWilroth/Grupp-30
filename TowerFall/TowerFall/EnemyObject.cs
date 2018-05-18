using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spline;

namespace TowerFall {
    class EnemyObject {
        Texture2D spriteSheet;
        Rectangle baseRect, towerRect, enemyRectPos;
        Vector2 pos, endPos;
        SimplePath path;
        ParticleEngine particleEngine;
        int range, damage, hp, ID;
        float speed;
        public float posSpeed;

        public EnemyObject(Texture2D spriteSheet, int damage, int hp, int ID, Vector2 pos, Vector2 endPos) {
            this.spriteSheet = spriteSheet;
            this.damage = damage;
            this.pos = pos;
            this.endPos = endPos;
            this.hp = hp;
            this.ID = ID;
            posSpeed = 1;
            enemyRectPos = new Rectangle((int)pos.X - 10, (int)pos.Y - 20, 50, 50);
            baseRect = new Rectangle(2061, 1436, 110, 110);

            if (ID == 0) { //Range är onödigt hade tänkt att bossar kan skjuta spelarens torn o på så sett göra det svårare men orkade, range för tornen krånglade sjukt mycket
                towerRect = new Rectangle(2070, 1580, 110, 100);
                range = 100;
                speed = 3;
            } else {
                towerRect = new Rectangle(10000, 10000, 0, 0);
                range = 0;
                speed = 2;
            }
        }

        public void Update(GameTime gameTime, Vector2 newPos, Game1 game, WaveManager waveM, TowerManager towerM) {
            pos = newPos;
            posSpeed += speed; //Magi som gör så att den rör sig via spline...
            enemyRectPos.X = (int)pos.X - 25;
            enemyRectPos.Y = (int)pos.Y -20;

            towerM.enemyPos(pos); //skrickar pos till towerM som sen skickar den till towerO för att se om de är i range

            if (enemyRectPos.Contains(endPos)) {
                game.TakeDamage(damage);
                waveM.KillEnemy();
            }
            if (hp <= 0) {
                game.coins += 10 - 5*ID; //Får pengar när man dödar en fiende
                waveM.KillEnemy();
            }
        }

        public bool GetHit(int damage, Rectangle bulletRect, Game1 game, ParticleEngine particleEngine) {
            if (bulletRect.Intersects(enemyRectPos)) {
                particleEngine.EmitterLocation = new Vector2(enemyRectPos.X, enemyRectPos.Y); //Ritar ut super duber Matrix effekter när en fiende blir träffad av ett skott, har det för att det är Krav
                hp -= damage;
                game.KillBullet();
                Console.WriteLine("HP: " + hp);
                return true;
            }
            return false;
        }

        public void Draw(SpriteBatch SB) {
            SB.Draw(spriteSheet, enemyRectPos, baseRect, Color.White);
            SB.Draw(spriteSheet, enemyRectPos, towerRect, Color.White);
        }
    }
}
