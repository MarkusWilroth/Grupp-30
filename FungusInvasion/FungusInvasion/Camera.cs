﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FungusInvasion
{
    class Camera
    {

        private Matrix transform;
        private Vector2 position;
        private Viewport view;

        public Camera(Viewport view)
        {
            this.view = view;
        }
        public void SetPosition(Vector2 position)
        {
            this.position = position;
            transform = Matrix.CreateTranslation(-position.X + view.Width / 2, -position.Y + view.Height / 2, 0);
        }
        public Vector2 GetPosition()
        {
            return position;
        }

        public Matrix GetTransform()
        {
            return transform;
        }
    }
}