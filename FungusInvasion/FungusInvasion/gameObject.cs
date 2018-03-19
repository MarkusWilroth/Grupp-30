using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace FungusInvasion
{
    abstract class gameObject
    {
        protected Texture2D spriteSheet;
        protected Vector2 pos;
        protected List<Vector2> posList;
        protected char textLetter;
        protected String[] levelList;
        protected int groundX, groundY;
        protected bool inAir;

        public gameObject(Texture2D spriteSheet, String[] levelList)
        {
            this.spriteSheet = spriteSheet;
            this.levelList = levelList;
            groundX = 0;
            groundY = 50;
            posList = new List<Vector2>();
        }
        public abstract void Update(List<Rectangle> groundRectList, GameTime gameTime);


        public abstract void Draw(SpriteBatch spriteBatch);

        protected List<Vector2> GetPos(char getLetter, int level)
        {
            posList.Clear();
            for (int i = 0; i < levelList[level].Length; i++)
            {
                textLetter = levelList[level][i];

                if (textLetter == getLetter)
                {
                    pos = new Vector2(groundX, groundY);
                    posList.Add(pos);
                    groundX += 100;
                }
                else if (textLetter == '|')
                {
                    groundX = 0;
                    groundY += 100;
                }
                else if (textLetter == '#')
                {
                    groundX = 0;
                    groundY = 50;
                }
                else
                {
                    groundX += 100;
                }
            }
            return posList;
        }

        protected bool Gravity(Rectangle hitBox, List<Rectangle> groundRectList)
        {
            foreach (Rectangle groundRect in groundRectList)
            {
                if ((groundRect.Intersects(hitBox)))
                {
                    inAir = false;
                    break;
                }
                else
                    inAir = true;
            }
            return inAir;

        }

        public bool HitWall(Rectangle hitBox, List<Rectangle> groundRectList, int movement)
        {
            foreach (Rectangle groundRect in groundRectList)
            {
                if (groundRect.Intersects(new Rectangle(hitBox.X + movement, hitBox.Y - 10, hitBox.Width, hitBox.Height - 10)))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
/*
 * Saker som ska finnas här:
 * Kamera
 * Spelare
 * Svampar
 * PoverUps
 * Banan
 * Slutet
 */
