using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FungusInvasion {
    class tntObject : gameObject {
        protected Game1 game;
        protected bool isTNT;
        protected Rectangle tntSheet, tntRect, playerRect;
        protected List<Vector2> tntList;
        protected List<Rectangle> tntRectList;
        protected Vector2 tntPos;

        public tntObject(Texture2D spriteSheet, String[] levelList, Game1 game) : base(spriteSheet, levelList) {
            this.game = game;
            isTNT = false;
            tntSheet = new Rectangle(102, 396, 47, 62);
            tntList = new List<Vector2>();
            tntRectList = new List<Rectangle>();

            tntList = GetPos('d', game.currentLevel);

            foreach (Vector2 pos in tntList) {
                tntRect = new Rectangle((int)pos.X, (int)pos.Y, tntSheet.Width, tntSheet.Height);
                tntRectList.Add(tntRect);
            }

        }
        public override void Update(List<Rectangle> groundRectList, GameTime gameTime) {
            playerRect = new Rectangle((int)game.playerPos.X, (int)game.playerPos.Y, 40, 80);
            
                foreach (Rectangle tntRect in tntRectList) {
                if (playerRect.Intersects(tntRect)) {
                    isTNT = game.PixelCollision(spriteSheet, tntRect, tntSheet);
                    if (isTNT) {
                        game.tnt++;
                        tntRectList.Remove(tntRect);
                        break;
                    }
                }
            }
            

        }
        public override void Draw(SpriteBatch spriteBatch) {
            foreach (Rectangle tntRect in tntRectList) {
                spriteBatch.Draw(spriteSheet, tntRect, tntSheet, Color.White);
            }
                
        }
        public void Restart() {
            foreach (Rectangle tntRect in tntRectList) {
                tntRectList.Clear();
                break;
            }
        }
    }
}
