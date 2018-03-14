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
    class Objects_Pacman:Objects {
        public char getLetter;
        public Rectangle rectPac;
        public Vector2 pacPos, direction, destination;
        public int fieldX, fieldY, time, speedX, speedY, frame, sheet, X, Y;
        public double frameInterval, frameTimer;
        public Rectangle sheetPac;
        public Texture2D spriteSheet;
        public float rotation, speed;
        public Game1 game;
        public SpriteEffects pacFx;
        public bool isMoving, hitWall;

        public Objects_Pacman(Texture2D spriteSheet, String textTile, Game1 game) : base(spriteSheet, textTile) {
            this.spriteSheet = spriteSheet;
            this.game = game;
            time = 0;
            sheetPac = new Rectangle(1, 1, 14, 14);
            frameInterval = 100;
            frameTimer = 100;
            sheet = 1;
            speed = 50.0f;
            isMoving = false;
            hitWall = false;

            pacFx = SpriteEffects.None;
            speedX = 0;
            speedY = 0;

            for (int i = 0; i < textTile.Length; i++) {
                getLetter = textTile[i];

                switch (getLetter) {
                    case 'p':
                        rectPac = new Rectangle(fieldX, fieldY, 15, 15);
                        pacPos = new Vector2(fieldX, fieldY);
                        System.Diagnostics.Debug.WriteLine("StartPac: " + pacPos);
                        fieldX += 30;
                        break;

                    case 'g':
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
            if (frameTimer <= 0) {
                frameTimer = frameInterval;
                frame += sheet;
                sheetPac.X = (frame%3)*15;
            }

            if (pacPos.X < 0) {
                pacPos.X = 565;
            }

            if (pacPos.X > 565) {
                pacPos.X = 0;
            }

            if (!isMoving) {
                sheetPac.X = 1;
                if (Keyboard.GetState().IsKeyDown(Keys.Left)) {
                    ChangeDirection(new Vector2(-1, 0));
                    rotation = MathHelper.ToRadians(180);

                } else if (Keyboard.GetState().IsKeyDown(Keys.Up)) {
                    ChangeDirection(new Vector2(0, -1));
                    rotation = MathHelper.ToRadians(-90);

                } else if (Keyboard.GetState().IsKeyDown(Keys.Right)) {
                    ChangeDirection(new Vector2(1, 0));
                    rotation = MathHelper.ToRadians(0);

                } else if (Keyboard.GetState().IsKeyDown(Keys.Down)) {
                    ChangeDirection(new Vector2(0, 1));
                    rotation = MathHelper.ToRadians(90);

                }
                
            } 
            else {
                frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
                pacPos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (Vector2.Distance(pacPos, destination) < 1) {
                    pacPos = destination;
                    rectPac = new Rectangle((int)pacPos.X, (int)pacPos.Y, 15, 15);
                    isMoving = false;
                }
            }



        }
        public override void Draw(SpriteBatch spriteBatch) {
            
            spriteBatch.Draw(spriteSheet, new Vector2(pacPos.X + 15, pacPos.Y + 7), sheetPac, Color.White, rotation, new Vector2(7,7), 1, pacFx, 1);
        }

        public Rectangle GetRectPac () {
            return rectPac;
        }
        public Rectangle Boom () {
            return new Rectangle(X, Y, 15, 15);
        }

        private void ChangeDirection (Vector2 dir) {
            direction = dir;
            Vector2 newDestination = pacPos + (direction * 30.0f);

            if (newDestination.X < 0) {
                newDestination.X = 540;
            }
            if (newDestination.X > 565) {
                newDestination.X = 0;
            }

            X = (int)newDestination.X;
            Y = (int)newDestination.Y;

            

            foreach (Rectangle rectTile in game.rectTileList) {
                if (rectTile.Intersects(new Rectangle(X, Y, 15, 15))) {
                    hitWall = true;
                    break;
                } else {
                    hitWall = false;
                }
            }
            if (!hitWall) {
                destination = newDestination;
                isMoving = true;
            }
            if  (hitWall) {
                isMoving = false;
            }
            
        }

        
    }
}
    
/* 
 * ToDo:
 * Fixa animering snyggar... behöver nog hjälp med det
 */

            