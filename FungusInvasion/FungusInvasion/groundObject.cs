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

namespace FungusInvasion
{
    class groundObject : gameObject
    {
        protected List<Vector2> groundList;
        protected List<Rectangle> rectList;
        protected Rectangle groundSheet, groundRect;
        protected bool timer;

        public groundObject(Texture2D spriteSheet, String[] levelList, Game1 game) : base(spriteSheet, levelList)
        {
            this.spriteSheet = spriteSheet;
            this.levelList = levelList;
            timer = false;
            rectList = new List<Rectangle>();

            groundSheet = new Rectangle(0, 273, 100, 100);

            groundList = GetPos('-', game.currentLevel);
            foreach (Vector2 pos in groundList)
            {
                groundRect = new Rectangle((int)pos.X, (int)pos.Y, 100, 100);
                rectList.Add(groundRect);
            }

        }
        public override void Update(List<Rectangle> groundRectList, GameTime gameTime)
        {

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Rectangle groundRect in rectList)
            {
                spriteBatch.Draw(spriteSheet, groundRect, groundSheet, Color.Pink);
            }
        }

        public List<Rectangle> GetRect()
        {
            return rectList;
        }
    }
}

/* ToDo:
 * Hitbox för marken
 * Skicka hitboxen till andra arvklasser
 */
