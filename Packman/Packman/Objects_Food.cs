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
    class Objects_Food:Objects {
        public List<Rectangle> foodRectList, superFoodList;
        public Rectangle foodRect, sheetRect, superSheet;
        public char getLetter;
        public int fieldX, fieldY, score, superPac;

        public Objects_Food(Texture2D texture, String textTile) : base(texture, textTile) {
            this.texture = texture;
            fieldY = 50;
            fieldX = 0;
            foodRectList = new List<Rectangle>();
            superFoodList = new List<Rectangle>();
            sheetRect = new Rectangle(56, 1, 10, 10);
            superSheet = new Rectangle(66, 98, 10, 10);
            superPac = 0;

            for (int i = 0; i < textTile.Length; i++) { //ta bort isEaten från alla klasser!
                getLetter = textTile[i];

                switch (getLetter) {
                    case '-':
                        foodRect = new Rectangle(fieldX+12, fieldY+12, 10, 10);
                        foodRectList.Add(foodRect);
                        fieldX += 30;
                        break;

                    case 'g':
                        foodRect = new Rectangle(fieldX + 12, fieldY + 12, 10, 10);
                        superFoodList.Add(foodRect);
                        fieldX += 30;
                        break;
                    case 'w':
                    case 'p':
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

        }

        public override void Draw(SpriteBatch spriteBatch) {
            foreach (Rectangle foodRect in foodRectList) {
                spriteBatch.Draw(texture, foodRect, sheetRect, Color.White);
            }
            foreach (Rectangle foodRect in superFoodList) {
                spriteBatch.Draw(texture, foodRect, superSheet, Color.White);
            }
        }
        public int CheckPac(Rectangle rectPac) {
            foreach (Rectangle foodRect in foodRectList) {
                if (rectPac.Intersects(foodRect)) {
                    foodRectList.Remove(foodRect);
                    score++;
                    return (score);
                }
            }
            
            return (score);
        }
        public int SuperPac(Rectangle rectPac, int superPac) {
            foreach (Rectangle foodRect in superFoodList) {
                if (foodRect.Intersects(rectPac)) {
                    superFoodList.Remove(foodRect);
                    superPac++;
                    return (superPac);
                }
            }
            return (superPac);
        }



    }
}
