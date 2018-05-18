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

namespace TowerFall {
    class TowerObject:GameObject {
        Rectangle towerRectPos;
        int damage, range, ID, timer;
        Rectangle baseRect, towerRect, upgradeRect;
        bool isUpgraded, reloading;
        float rotation;
        double angle, sin, cos;
        MouseState mouseState, oldMouseState;
        Vector2 mousePos, turretPos, distance;
        Game1 game;

        public TowerObject(Texture2D spriteSheet, int damage, int range, Rectangle towerRectPos, Rectangle baseRect, Rectangle towerRect, Rectangle upgradeRect, int ID, Game1 game) : base(spriteSheet) {
            this.spriteSheet = spriteSheet;
            this.damage = damage;
            this.range = range;
            this.towerRectPos = towerRectPos;
            this.baseRect = baseRect;
            this.towerRect = towerRect;
            this.upgradeRect = upgradeRect;
            this.game = game;
            this.ID = ID;
            turretPos = new Vector2(towerRectPos.X, towerRectPos.Y);
        }
        public override void Update(GameTime gameTime) {
            mouseState = Mouse.GetState();
            mousePos = new Vector2(mouseState.X, mouseState.Y);
            if (reloading) {
                timer++;
                if (timer >= 30) {
                    reloading = false;
                    timer = 0;
                }
            }
            
            if (towerRectPos.Contains(mousePos) && mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released && game.coins >= 5 && (ID == 0 || ID == 4)) {
                game.coins -= 5;
                range += 100;
                isUpgraded = true;
            }
            oldMouseState = mouseState;

        }
        public void inRange(Vector2 enemyPos) {
            if (!reloading) {
                distance = new Vector2(towerRectPos.X, towerRectPos.Y) - enemyPos;
                distance.Normalize();

                sin = enemyPos.X * towerRectPos.Y - towerRectPos.X * enemyPos.Y;
                cos = enemyPos.X * towerRectPos.X + enemyPos.Y * towerRectPos.Y;

                angle = (float)Math.Atan2(towerRectPos.Y - enemyPos.Y, enemyPos.X - towerRectPos.X);
                if (Vector2.Distance(turretPos, enemyPos) <= range) {
                    rotation = (float)angle;
                    game.CreatBullet(new Vector2(towerRectPos.X, towerRectPos.Y), angle, damage);
                    reloading = true;
                }
            }
            
        }

        public override void Draw(SpriteBatch SB) {
            SB.Draw(spriteSheet, towerRectPos, baseRect, Color.White);
            SB.Draw(spriteSheet, towerRectPos, towerRect, Color.White, rotation, new Vector2(towerRect.Width/2, towerRect.Height/2), SpriteEffects.None, 1);

            if (isUpgraded) {
                SB.Draw(spriteSheet, towerRectPos, upgradeRect, Color.White);
            }
        }
    }
}
