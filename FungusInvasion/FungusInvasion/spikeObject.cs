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
    class spikeObject : gameObject {
        protected Game1 game;
        protected bool isTrap;
        protected Rectangle trapSheet, trapRect, playerHitBox;
        protected List<Vector2> trapList;
        protected List<Rectangle> trapRectList;
        protected Vector2 trapPos;

        public spikeObject(Texture2D spriteSheet, String[] levelList, Game1 game) : base(spriteSheet, levelList) {
            this.game = game;
            isTrap = false;
            trapSheet = new Rectangle(0, 466, 100, 100);
            trapList = new List<Vector2>();
            trapRectList = new List<Rectangle>();

            trapList = GetPos('t', game.currentLevel);

            foreach (Vector2 pos in trapList) {
                trapPos = pos;
                trapRect = new Rectangle((int)pos.X, (int)pos.Y, trapSheet.Width, trapSheet.Height);
                trapRectList.Add(trapRect);
            }

        }
        public override void Update(List<Rectangle> groundRectList, GameTime gameTime) {
            playerHitBox = new Rectangle((int)game.playerPos.X, (int)game.playerPos.Y, 40, 80);
            foreach (Rectangle trapRect in trapRectList) {
                if (trapRect.Intersects(playerHitBox)) {
                    isTrap = game.PixelCollision(spriteSheet, trapRect, trapSheet);
                    if (isTrap) {
                              game.isDead = true;
                    }
                }
            }
           
            
        }
        public override void Draw(SpriteBatch spriteBatch) {
            foreach (Rectangle trapRect in trapRectList)
                spriteBatch.Draw(spriteSheet, trapRect, trapSheet, Color.White);
        }
    }
}
