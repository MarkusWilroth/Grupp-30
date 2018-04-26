using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modul1 {
    public partial class Form1 : Form {
        int x, y;
        bool isRotating;
        Rotation rotation;
        Graphics g;
        Point[] points;
        Bitmap bmp;

        public Form1() {
            InitializeComponent();
            isRotating = false;
            x = panel1.Bounds.Width / 2 - 50;
            y = panel1.Bounds.Height / 2 - 50;

            bmp = new Bitmap(x, y);
            
            rotation = new Rotation(x, y, g);
        }

        public void Start() {
            points = rotation.Update();
            panel1.Invalidate();

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            SolidBrush sb = new SolidBrush(Color.Black);
            g = Graphics.FromImage(bmp);

            if (isRotating) {
                g.Clear(Color.White);
                panel1.BackgroundImage = bmp;
                g.FillPolygon(sb, points);
                g.Dispose();
            }
            

            

            //Pen p = new Pen(Color.Black);
            
            
            
            //g.DrawRectangle(p, x, y, 100, 100);
            //g.FillRectangle(sb, x, y, 100, 100);


        }

        private void btnRotate_Click(object sender, EventArgs e) {
            isRotating = true;
            rotation.Rotating(isRotating);
            panel1.Invalidate();
        }
    }
}








