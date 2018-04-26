using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1 {
    class Rotation {
        int x, y, radius, center, angle;
        bool isRotating;
        Graphics g;
        Matrix myMatrix;
        Point myPoint, pointResult;
        
        
        public Rotation(int x, int y, Graphics g) {

            center = x/2;
            radius = 50;
            angle = 0;
            //myMatrix = new Matrix(5, 10, 15, 20, 25, 30);
            //myPoint = new Point(15, 15);
            //pointResult = Transform(myPoint);

        }
        public void Rotating() {
            if (isRotating) {
                isRotating = false;
            }
            else {
                isRotating = true;
            }

        }
        public Point Transform (Point point) {
            return point;
        }

        public Point[] Update() {
            //rotate 
            Point point1 = new Point(LineCoored(angle, radius, center)[0], LineCoored(angle, radius, center)[1]);
            Point point2 = new Point(LineCoored(angle + 90, radius, center)[0], LineCoored(angle + 90, radius, center)[1]);
            Point point3 = new Point(LineCoored(angle + 180, radius, center)[0], LineCoored(angle + 180, radius, center)[1]);
            Point point4 = new Point(LineCoored(angle + 270, radius, center)[0], LineCoored(angle + 270, radius, center)[1]);
            Point[] points = { point1, point2, point3, point4 };

            if (angle == 360) {
                angle = 0;
            } else {
                angle++;
            }



            return points;
        }
        private int[] LineCoored(int angleIn, int radius, int center) {
            int[] coored = new int[2];
            angleIn %= 360;
            angleIn *= 1;

            if (angleIn >= 0 && angleIn <= 180) {
                coored[0] = center + (int)(radius * Math.Sin(Math.PI * angleIn / 180));
                coored[1] = center - (int)(radius * Math.Cos(Math.PI * angleIn / 180));
            } else {
                coored[0] = center - (int)(radius * -Math.Sin(Math.PI * angleIn / 180));
                coored[1] = center - (int)(radius * Math.Cos(Math.PI * angleIn / 180));
            }
            return coored;
        }
    }
}
