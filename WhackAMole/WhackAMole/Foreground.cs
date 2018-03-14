using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackAMole
{
    class Foreground
    {
        Texture2D foregroundTex;
        Vector2 foregroundPos;

        public Foreground(Texture2D foregroundTex, int foregroundPosX, int foregroundPosY)
        {
            this.foregroundTex = foregroundTex;
            this.foregroundPos = new Vector2(foregroundPosX, foregroundPosY);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(foregroundTex, foregroundPos, Color.White);
        }

    }
}
