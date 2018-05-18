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
    class TowerManager {
        public int towers, HUDTower, j;
        bool noBuilding, killBullet;
        bool[] isBuilding;

        Rectangle[] towerBase, towerTurret, towerUpgrade;
        Rectangle towerRectPos, mouseRect, buildingRectPos, roadRect;
        Vector2 HUDpos;
        Texture2D spriteSheet;
        MouseState mouseState, oldMouseState;
        TowerObject towerO;
        Bullet bullet;
        List<Vector2> towerHUDList;
        List<Bullet> bulletList;
        List<TowerObject> towerList;

        public TowerManager(Texture2D spriteSheet) {
            this.spriteSheet = spriteSheet;
            towers = 5; 
            isBuilding = new bool[towers];
            towerList = new List<TowerObject>();
            bulletList = new List<Bullet>();
            towerBase = new Rectangle[towers];
            towerTurret = new Rectangle[towers];
            towerUpgrade = new Rectangle[towers];

            for (int i = 0; i < towers; i++) {
                if (i < 1) {
                    towerBase[i] = new Rectangle(1933, 1420, 110, 110);
                    towerTurret[i] = new Rectangle(1930, 1550, 110, 110);
                    towerUpgrade[i] = new Rectangle(1964, 1317, 110, 110);


                } else {
                    towerBase[i] = new Rectangle(10000, 10000, 0, 0);
                    towerTurret[i] = new Rectangle(1960 + (124 * i), 1300, 110, 110);
                    towerUpgrade[i] = new Rectangle(1964, 1317, 110, 110);
                }
            }
        }
        public void enemyPos(Vector2 enemyPos) { //får positionen från en fiende
            foreach (TowerObject towerO in towerList) {
                towerO.inRange(enemyPos);
            }
        } //Tvungen att dra nu vill du att jag ska kommentera fler saker så är det bara att säga till så fixar jag

        public void Update(GameTime gameTime, Game1 game) {
            mouseState = Mouse.GetState();
            buildingRectPos = new Rectangle(mouseState.X, mouseState.Y, 50, 50);
            for (int i = 0; i < towers; i++) {
                if (isBuilding[i] && mouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released && game.coins >= 10) {
                    isBuilding[i] = false;
                    towerO = new TowerObject(spriteSheet, 3, 100, buildingRectPos, towerBase[i], towerTurret[i], towerUpgrade[i], i, game);
                    towerList.Add(towerO);
                    game.coins -= 10;
                }
            }
            foreach (TowerObject towerO in towerList) { 
                towerO.Update(gameTime);
            }
            oldMouseState = mouseState;
        }
        public void TowerHUD(Vector2 pos) {
            HUDpos = pos;
        }
        

        public void BuildTower(int X, int Y, MouseState mouseState, int i, Vector2 roadPos) {
            noBuilding = false;
            for (int j = 0; j < towers; j++) {
                if (isBuilding[j] == true) {
                    noBuilding = true;
                    break;
                }

            }

            mouseRect = new Rectangle(X, Y, 10, 10);
            towerRectPos = new Rectangle((int)HUDpos.X + (50 * i), (int)HUDpos.Y, 40, 40);

            //roadRect = new Rectangle((int)roadPos.X, (int)roadPos.Y, 50, 50);
            //if (roadRect.Intersects(towerRectPos)) {
            //    noBuilding = true;
            //}

            if (!noBuilding) {
                if (towerRectPos.Contains(mouseRect)) {
                    isBuilding[i] = true;
                }
            }

        }

        public void Draw(SpriteBatch SB) {
            for (int i = 0; i < towers; i++) {
                towerRectPos = new Rectangle((int)HUDpos.X + (50 * i) + 5, (int)HUDpos.Y + 5, 40, 40);
                SB.Draw(spriteSheet, towerRectPos, towerBase[i], Color.White);
                SB.Draw(spriteSheet, towerRectPos, towerTurret[i], Color.White);


                if (isBuilding[i]) {
                    SB.Draw(spriteSheet, buildingRectPos, new Rectangle(0, 0, 40, 40), Color.Red);
                    SB.Draw(spriteSheet, buildingRectPos, towerBase[i], Color.Gray);
                    SB.Draw(spriteSheet, buildingRectPos, towerTurret[i], Color.White);
                }

            }
            foreach (TowerObject towerO in towerList) {
                towerO.Draw(SB);
            }
        }
    }
}
