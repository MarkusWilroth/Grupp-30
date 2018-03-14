using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackAMole
{
    class Hole
    {
        Texture2D holeTex;

        Vector2 holepos;

        public Hole(Texture2D holeTex, int holeposX, int holeposY)
        {
            this.holeTex = holeTex;
            this.holepos = new Vector2(holeposX, holeposY);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(holeTex, holepos, Color.White);
        }

    }
}
