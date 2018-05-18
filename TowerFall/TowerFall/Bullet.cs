using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerFall {
    class Bullet {
        Texture2D spriteSheet;
        Rectangle shootRect, sourceRect;
        Vector2 pos, direction;
        Game1 game;
        bool isDead;
        int damage, timer;
        double angle;

        public Bullet(Texture2D spriteSheet, Vector2 pos, double angle, int damage, Game1 game) {
            this.spriteSheet = spriteSheet;
            this.pos = pos;
            this.angle = angle;
            this.damage = damage;
            this.game = game;
            sourceRect = new Rectangle(2864, 1456, 30, 30);
            direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)); //Onödig och borde kunnas ta bort men orkar inte hålla på o rensa kod
            shootRect = new Rectangle((int)pos.X, (int)pos.Y, 10, 10);
        }

        public void Update() {
            timer++;
            if (isDead) {
                game.KillBullet();
            }
            pos.X += (float)Math.Cos(angle); //angle är vinkeln som bestämmer hur den ska åka
            pos.Y += -(float)Math.Sin(angle);
            shootRect.X = (int)pos.X; //Updaterar rektanglen, anledningen till att jag använder pos är för att det är så små värden från angle att det avrundas till 0 om det är en int
            shootRect.Y = (int)pos.Y;

            if (timer >= 120) { //timer som avgör hur långt skottet kommer
                isDead = true;
            }


        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(spriteSheet, shootRect, sourceRect, Color.White);
        }

        public Rectangle GetRect() {
            return shootRect;
        }

        public int GetDamage() {
            return damage;
        }
    }
}
