using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackAMole
{
    class Mole
    {
        Texture2D moleTexture;
        Vector2 molepos;
        int stop;    // en stop position
        int starpos; // start positiom

        Vector2 moleVelocity;
        Rectangle boundingBox;  
       public bool isVisible = false;
        public bool alive;
        public Rectangle moleRect;
        MouseState mouseState, previousMouseState;

        public Mole(Texture2D moleTexture,int moleposX, int moleposY, Vector2 moleVelocity, Rectangle boundingBox)
        {
            this.moleTexture = moleTexture;   //ksriver in texturen
            this.molepos = new Vector2(moleposX, moleposY);    //skriver in positionerna
            starpos = moleposY;

            this.moleVelocity = moleVelocity; // skriver in hastighten
            this.boundingBox = boundingBox;
            stop = (int)molepos.Y - (int)moleTexture.Height/2;  // hur högt skall varje molvad gå och sedan stann. /2 innebär att de kan int gå över skärmen

            alive = true;

        }

        public void Update(MouseState mouseState, MouseState previousMouseState, ref int score, ref float gameOverTimer)
        {
            this.mouseState = mouseState;
            this.previousMouseState = previousMouseState;
            //molepos = molepos + moleVelocity;
           if(isVisible == true)
            {

                if (isClicked(mouseState.X, mouseState.Y))
                { 
                    
                        score += 10;
                       
                 }

              
                molepos = molepos + moleVelocity;
                if (molepos.Y >= (stop)) // om den är större än stop så skall den gå upp till -1
                {
                    moleVelocity.Y = moleVelocity.Y * (-1); // * -1. den kan bara gå upp till -1

                }

                if (molepos.Y <= starpos)
                {
                    moleVelocity.Y = moleVelocity.Y * (-1);
                }

                if(molepos.Y >= starpos)
                {
                    alive = true;
                }
            }        
            // if ( molepos.Y >= (stop))
            //{
            //    moleVelocity.Y = moleVelocity.Y * (-1);

            //}

            // if (molepos.Y <= starpos)
            //{
            //    moleVelocity.Y = moleVelocity.Y * (-1);
            //}

            

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //ritar ut vad, var och vilken färg

            if (isVisible)
            {
                spriteBatch.Draw(moleTexture, molepos, Color.White);
            }
            
        }

        public bool isClicked(int x, int y)
        {
            bool isClicked = false;

            moleRect = new Rectangle((int)molepos.X, (int) molepos.Y, moleTexture.Width, moleTexture.Height);
            if (moleRect.Contains (x, y) && mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released && alive == true)
            {

                isClicked = true;
                alive = false;
                
            }
            return isClicked;
        }
       

        
    }

    
}
