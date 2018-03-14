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
    class groundObject:gameObject {
        protected Texture2D spriteSheet;
        protected String[] levelList;
        protected Vector2 pos;
        protected List<Vector2> groundList;
        protected List<Rectangle> rectList;
        protected Rectangle groundSheet, groundRect;
        protected KeyboardState ks;
        protected bool timer;

        public groundObject(Texture2D spriteSheet, String[] levelList, Game1 game):base(spriteSheet, levelList) {
            this.spriteSheet = spriteSheet;
            this.levelList = levelList;
            timer = false;
            rectList = new List<Rectangle>();

            groundSheet = new Rectangle(0, 273, 100, 100);

            groundList = GetPos('-', game.currentLevel);
            foreach (Vector2 pos in groundList) {
                groundRect = new Rectangle((int)pos.X, (int)pos.Y, 100, 100);
                rectList.Add(groundRect);
            }

        }
        public override void Update(List<Rectangle> groundRectList, GameTime gameTime) {
            
        }
        public override void Draw(SpriteBatch spriteBatch) {
            foreach (Rectangle groundRect in rectList) {
                spriteBatch.Draw(spriteSheet, groundRect, groundSheet, Color.Gray);
            }
        }

        public List<Rectangle> GetRect() {
            return rectList;
        }

        public void TNT(Vector2 playerPos, GameTime gameTime, Game1 game) {
            if (game.tnt > 0) { 
                ks = Keyboard.GetState();
                foreach (Rectangle groundRect in rectList) {
                    if (ks.IsKeyDown(Keys.Left) && ks.IsKeyDown(Keys.Enter)) {
                        if (new Rectangle((int)playerPos.X - 10, (int)playerPos.Y, 1, 1).Intersects(groundRect)) {
                            game.tnt--;
                            rectList.Remove(groundRect);
                            break;
                        }
                    }
                    if (ks.IsKeyDown(Keys.Right) && ks.IsKeyDown(Keys.Enter)) {
                        if (new Rectangle((int)playerPos.X + 50, (int)playerPos.Y, 1, 1).Intersects(groundRect)) {
                            game.tnt--;
                            rectList.Remove(groundRect);
                            break;
                        }
                    }

                }
            }
        }
    }
}

/* ToDo:
 * Hitbox för marken
 * Skicka hitboxen till andra arvklasser
 */
