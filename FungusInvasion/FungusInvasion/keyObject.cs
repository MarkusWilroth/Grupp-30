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
    class keyObject : gameObject
    {
        protected Rectangle keySheet, keyHitBox, playerHitBox;
        protected Vector2 keyPos;
        protected List<Vector2> keyList;
        protected List<Rectangle> keyRectList;
        protected Game1 game;
        protected bool isTaken;

        public keyObject(Texture2D spriteSheet, String[] levelList, Game1 game) : base(spriteSheet, levelList)
        {
            this.game = game;
            isTaken = false;
            keySheet = new Rectangle(18, 384, 44, 77);
            keyList = new List<Vector2>();
            keyRectList = new List<Rectangle>();

            keyList = GetPos('k', game.currentLevel);

            foreach (Vector2 pos in keyList)
            {
                keyPos = pos;
                keyHitBox = new Rectangle((int)pos.X, (int)pos.Y, keySheet.Width, keySheet.Height);
                keyRectList.Add(keyHitBox);
            }

        }
        public override void Update(List<Rectangle> groundRectList, GameTime gameTime)
        {
            playerHitBox = new Rectangle((int)game.playerPos.X, (int)game.playerPos.Y, 40, 80);

            if (playerHitBox.Intersects(keyHitBox))
            {
                isTaken = game.PixelCollision(spriteSheet, keyHitBox, keySheet);
                if (isTaken)
                {
                    game.isEnd = true;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Rectangle keyHitBox in keyRectList)
            {
                if (!isTaken)
                {
                    spriteBatch.Draw(spriteSheet, keyPos, keySheet, Color.White);
                }
            }
        }

        public void Restart()
        {
            keyRectList.Clear();
        }




    }
}
