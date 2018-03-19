using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FungusInvasion {
    class enemyObject : gameObject
    {
        protected List<Vector2> enemyList;
        protected List<Vector2> groundRectList;
        protected Rectangle[] hitBox;
        protected Rectangle enemySheet, playerHitBox;
        protected bool[] inAir, movingLeft, isWall, isBattle;
        protected int enemies, i;
        protected int[] movement;
        protected Game1 game;

        public enemyObject(Texture2D spriteSheet, String[] levelList, Game1 game) : base(spriteSheet, levelList)
        {
            this.game = game;
            enemyList = new List<Vector2>();
            enemies = 10;
            isBattle = new bool[enemies];
            movement = new int[enemies];
            inAir = new bool[enemies];
            movingLeft = new bool[enemies];
            isWall = new bool[enemies];
            hitBox = new Rectangle[enemies];


            enemyList = GetPos('s', game.currentLevel);
            enemySheet = new Rectangle(6, 178, 77, 95);
            foreach (Vector2 pos in enemyList)
            {
                i++;
                hitBox[i] = new Rectangle((int)pos.X, (int)pos.Y, enemySheet.Width, enemySheet.Height);
                movement[i] = -2;
                inAir[i] = true;
                movingLeft[i] = true;
                isWall[i] = false;
            }
        }

        public override void Update(List<Rectangle> groundRectList, GameTime gameTime)
        {
            playerHitBox = new Rectangle((int)game.playerPos.X, (int)game.playerPos.Y, 40, 80);

            for (int i = 0; i < enemies; i++)
            {
                inAir[i] = Gravity(hitBox[i], groundRectList);
                isWall[i] = HitWall(hitBox[i], groundRectList, movement[i]);

                if (isWall[i])
                {
                    if (movingLeft[i])
                    {
                        movingLeft[i] = false;
                    }
                    else
                    {
                        movingLeft[i] = true;
                    }
                }
                if (movingLeft[i])
                {
                    movement[i] = +2;
                }
                else
                {
                    movement[i] = -2;
                }
                hitBox[i].X += movement[i];
                if (inAir[i])
                {
                    hitBox[i].Y += 4;
                }
                if (hitBox[i].Y >= 1000)
                {
                    hitBox[i] = new Rectangle(10000, 10000, 40, 80);
                }
                if (playerHitBox.Intersects(hitBox[i]))
                {
                    isBattle[i] = game.PixelCollision(spriteSheet, hitBox[i], enemySheet); //Fel med detta.... Måste fixas
                    if (isBattle[i])
                    {
                        if (game.playerPos.Y < hitBox[i].Y - hitBox[i].Height / 2)
                        {
                            hitBox[i] = new Rectangle(10000, 10000, 40, 80);
                        }
                        else
                        {
                            game.isDead = true;
                        }
                    }
                }

                isBattle[i] = false;
            }

        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < enemies; i++)
            {
                spriteBatch.Draw(spriteSheet, hitBox[i], enemySheet, Color.White);
            }
        }
        public void Restart()
        {
            for (int i = 0; i < enemies; i++)
            {
                hitBox[i] = new Rectangle(10000, 10000, 40, 80);
            }
        }
    }
}
