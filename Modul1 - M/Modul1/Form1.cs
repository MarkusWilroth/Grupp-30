using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modul1 {
    public partial class Form1 : Form {
        int x, y;
        bool isRotating;
        Rotation rotation;
        Thread t1;
        public Form1() {


            InitializeComponent();
            //isRotating = false;
            x = panel1.Bounds.Width / 2 - 50;
            y = panel1.Bounds.Height / 2 - 50;
            
            rotation = new Rotation(panel1);

            t1 = new Thread(new ThreadStart(Start));
            t1.Start();
        }

        public void Start() {
            //while (isRotating) {
                rotation.Update();
                Thread.Sleep(1000);
            //}
            
            //panel1.Invalidate();
            //if (isRotating) {
            //}


        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            //SolidBrush sb = new SolidBrush(Color.Black);
            //g.Clear(Color.White);
            //panel1.BackgroundImage = bmp;
            //g.FillPolygon(sb, points);
            //g.Dispose();

            //Pen p = new Pen(Color.Black);



            //g.DrawRectangle(p, x, y, 100, 100);
            //g.FillRectangle(sb, x, y, 100, 100);


        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void btnRotate_Click(object sender, EventArgs e) {
            if (isRotating) {
                isRotating = false;
            }
            else {
                isRotating = true;
                Start();
            }
            rotation.Update();
            //panel1.Invalidate();
        }
    }
}








