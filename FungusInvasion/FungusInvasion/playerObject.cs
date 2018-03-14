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
    class playerObject : gameObject {
        protected List<Vector2> playerList;
        protected List<Rectangle> playerRectList;
        protected Vector2 speed, jumpPos;
        protected Rectangle playerSheet, hitBox, player;
        protected bool isWall;
        protected int jump, movement;
        protected double timer;
        protected Game1 game;
        
        public playerObject(Texture2D spriteSheet, String[] levelList, Game1 game) : base(spriteSheet, levelList) {
            this.game = game;
            playerList = new List<Vector2>();
            playerRectList = new List<Rectangle>();
            timer = 0;
            playerSheet = new Rectangle(1, 2, 40, 81);
            inAir = false;

            playerList = GetPos('p', game.currentLevel);

            foreach (Vector2 pos in playerList) {
                player = new Rectangle((int)pos.X, (int)pos.Y, 40, 80);
                jumpPos = new Vector2(pos.X, pos.Y);
                playerRectList.Add(player);
            }
            hitBox = player;

        }
        public override void Update(List<Rectangle> groundRectList, GameTime gameTime) {

            speed.X = 0;

            inAir = Gravity(hitBox, groundRectList);
            isWall = HitWall(hitBox, groundRectList, movement);

            foreach (Rectangle groundRect in groundRectList) {
                if(new Rectangle(hitBox.X, hitBox.Y, 40, 60).Intersects(groundRect)) {
                    speed.Y = 0;
                    inAir = true;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left)) {
                speed.X = -4;
                movement = -4;
            } else if (Keyboard.GetState().IsKeyDown(Keys.Right)) {
                speed.X = 4;
                movement = 4;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !inAir) {
                speed.Y = -10;
                inAir = true;
            }
            if (isWall) {
                speed.X = 0;
            }
            if (inAir) {
                speed.Y += 0.3f;
            } else {
                speed.Y = 0;
            }
            jumpPos += speed;
            hitBox.X = (int)(jumpPos.X >= 0 ? jumpPos.X + 0.5f : jumpPos.X - 0.5f);
            hitBox.Y = (int)(jumpPos.Y >= 0 ? jumpPos.Y + 0.5f : jumpPos.Y - 0.5f);
            
            if(hitBox.Y >= 1000) {
                game.isDead = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            foreach (Rectangle player in playerRectList) {
                spriteBatch.Draw(spriteSheet, hitBox, playerSheet, Color.White);
            }

        }
        public Vector2 GetPos() {
            return jumpPos;
        }

        public Texture2D GetTex() {
            return spriteSheet;
        }
        public Rectangle GetRect() {
            return hitBox;
        }
        public Rectangle GetSheet() {
            return playerSheet;
        }
        public void Restart() {
            playerRectList.Clear();
        }
    }
}


