using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modul1 {
    class Rotation {
        Bitmap bmp = new Bitmap(400, 400);
        int radius, center, angle;
        bool isRotating;
        Graphics g;
        Panel panel1;


        public Rotation(Panel panel1) {
            this.panel1 = panel1;
            
            center = 400 / 2;
            radius = 350 / 2;
            angle = 180;
            //g = Graphics.FromImage(bmp);
        }

        public void Rotating() {
            if (isRotating) {
                isRotating = false;
            }
            else {
                isRotating = true;
            }

        }
        private void panel1_Paint(object sender, PaintEventArgs e) {
            
        }
        public void Update() {
            //rotate
            //while (isRotating) {
                g = Graphics.FromImage(bmp);
                g.Clear(Color.White);
                SolidBrush sb = new SolidBrush(Color.Red);
                Point point1 = new Point(LineCoored(angle, radius, center)[0], LineCoored(angle, radius, center)[1]);
                Point point2 = new Point(LineCoored(angle + 90, radius, center)[0], LineCoored(angle + 90, radius, center)[1]);
                Point point3 = new Point(LineCoored(angle + 180, radius, center)[0], LineCoored(angle + 180, radius, center)[1]);
                Point point4 = new Point(LineCoored(angle + 270, radius, center)[0], LineCoored(angle + 270, radius, center)[1]);
                Point[] points = { point1, point2, point3, point4 };

                panel1.BackgroundImage = bmp;
                g.FillPolygon(sb, points);
                g.Dispose();

                if (angle == 360) {
                    angle = 0;
                } else {
                    angle++;
                }
                //Thread.Sleep(1000);
            //}
            
        }
        private int[] LineCoored(int angleIn, int radius, int center) {
            int[] coored = new int[2];
            angleIn %= 360;
            angleIn *= 1;

            if (angleIn >= 0 && angleIn <= 180) {
                coored[0] = center + (int)(radius * Math.Sin(Math.PI * angleIn / 180));
                coored[1] = center - (int)(radius * Math.Cos(Math.PI * angleIn / 180));
            }
            else {
                coored[0] = center - (int)(radius * -Math.Sin(Math.PI * angleIn / 180));
                coored[1] = center - (int)(radius * Math.Cos(Math.PI * angleIn / 180));
            }
            return coored;
        }
    }
}
