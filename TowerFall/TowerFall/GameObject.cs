using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerFall {
    abstract class GameObject {
        protected Texture2D spriteSheet;
        protected Vector2 pos;

        public GameObject(Texture2D spriteSheet) {

        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch SB);
        
    }
}
