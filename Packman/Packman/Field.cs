using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;


namespace Packman {
    class Field {
        public Rectangle rectTile;
        public List<Rectangle> rectTileList;
        public String textTile;
        public Texture2D texWall;
        public int fieldY, fieldX;
        public char getLetter;


        public Field (Texture2D texWall, String textTile) {
            this.texWall = texWall;
            this.textTile = textTile;
            fieldY = 50;
            fieldX = 0;
            rectTileList = new List<Rectangle>();
            rectTile = new Rectangle();

            for (int i = 0; i < textTile.Length; i++) { 
                getLetter = textTile[i];
                if (getLetter.Equals('w')) {
                    rectTile = new Rectangle(fieldX, fieldY, 30, 30);
                    rectTileList.Add(rectTile);
                    
                    fieldX += 30;
                } else {
                    fieldX += 30;
                }
                if (getLetter.Equals('|')) {
                    fieldX = 0;
                    fieldY += 30;
                }
                if (getLetter.Equals('#')) {
                    fieldX = 0;
                    fieldY = 50;
                }

            }
        }
        public void Draw(SpriteBatch spriteBatch, String textTile) {
            foreach (Rectangle rectTile in rectTileList) {
                spriteBatch.Draw(texWall, rectTile, Color.Blue);
            }
        }

        public List<Rectangle> GetTile() {
            return rectTileList;
        }

        public int DestroyWall(Rectangle boomRect, int superPac) {
            foreach (Rectangle rectTile in rectTileList) {
                if (boomRect.Intersects(rectTile) && superPac > 0 && Keyboard.GetState().IsKeyDown(Keys.Enter)) {
                    rectTileList.Remove(rectTile);
                    superPac--;
                    return (superPac);
                }
            }
            return (superPac);
        }
         

    }
}


