using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Packman {
    class Objects_Ghost:Objects {
        protected char getLetter;
        protected Rectangle ghostSheet;
        protected Rectangle[] ghostRect;
        protected List<Rectangle> ghostList;
        protected List<Vector2> posList;
        protected int fieldX, fieldY, movement, ghost, life, timer;
        protected Texture2D spriteSheet;
        protected Vector2[] pos;
        protected bool isHit, moveLeft;

        public Objects_Ghost(Texture2D spriteSheet, String textTile) : base(spriteSheet, textTile) {
            this.spriteSheet = spriteSheet;
            ghostSheet = new Rectangle(32, 82, 15, 15);
            ghostList = new List<Rectangle>();
            ghostRect = new Rectangle[4];
            posList = new List<Vector2>();
            pos = new Vector2[4];
            isHit = false;
            ghost = 0;
            life = 4;
            fieldY = 50;
            movement = 2;
            moveLeft = true;

            for (int i = 0; i < textTile.Length; i++) {
                getLetter = textTile[i];

                    switch (getLetter) {
                    case 'g':
                        ghostRect[ghost] = new Rectangle(fieldX + 5, fieldY + 5, 20, 20);
                        pos[ghost] = new Vector2(fieldX + 5, fieldY + 5);
                        ghostList.Add(ghostRect[ghost]);
                        posList.Add(pos[ghost]);
                        fieldX += 30;
                        ghost++;
                        break;

                    case 'p':
                    case 'w':
                    case '-':
                        fieldX += 30;
                        break;

                    case '|':
                        fieldX = 0;
                        fieldY += 30;
                        break;

                    case '#':
                        fieldX = 0;
                        fieldY = 50;
                        break;

                        
                }
                
            }
        }
        public override void Update(GameTime gameTime) {
            if (isHit) {
                timer++;
                if(timer >= 240) {
                    isHit = false;
                }
            }
            GhostMovementOne();
            GhostMovementTwo();
            GhostMovementThree();
            
            
        }

        public override void Draw(SpriteBatch spriteBatch) {
            foreach (Rectangle ghostRect in ghostList) {
                for (int i = 0; i < ghost; i++) {
                    spriteBatch.Draw(spriteSheet, pos[i], ghostSheet, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 1);
                }
                
            }
            
        }
        public int CheckPac(Rectangle rectPac) {
            if(!isHit) {
                for (int i = 0; i < ghost; i++) { 
                    int X = (int)pos[i].X;
                    int Y = (int)pos[i].Y;
                    if (rectPac.Intersects(new Rectangle(X, Y, 20, 20))) {
                        life--;
                        isHit = true;
                        timer = 0;
                        return life;
                    }
                }
            }
            
            return life;
        }

        public void GhostMovementOne() {
            if (pos[0].X >= 0 && pos[0].Y <= 85 && pos[0].X <= 245) {
                pos[0].X += movement;
                ghostRect[0].X += movement;
            }
            else if (pos[0].X >= 245 && pos[0].Y <= 180) {
                pos[0].Y += movement;
                ghostRect[0].Y += movement;
            }
            else if (pos[0].X >= 35) {
                pos[0].X -= movement;
                ghostRect[0].X -= movement;
            }
            else {
                pos[0].Y -= movement;
                ghostRect[0].Y -= movement;
            }
        }

        public void GhostMovementTwo() {
            if (pos[1].X >= 170 && pos[1].Y <= 295 && pos[1].X <= 365) {
                pos[1].X += movement;
                pos[2].X -= movement;
            } else if (pos[1].X >= 365 && pos[1].Y <= 420) {
                pos[1].Y += movement;
                pos[2].Y -= movement;
            } else if (pos[1].X > 185) {
                pos[1].X -= movement;
                pos[2].X += movement;
            } else {
                pos[1].Y -= movement;
                pos[2].Y += movement;
            }
        }

        public void GhostMovementThree() {
            if (pos[3].X >= 520) {
                moveLeft = true;
            }
            if (pos[3].X <= 35) {
                moveLeft = false;
            }
            if (moveLeft) {
                pos[3].X -= movement;
            } else {
                pos[3].X += movement;
            }
        }
    }
}

