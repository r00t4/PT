using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintSimple
{
    public partial class Form1 : Form
    {
        enum Shape
        {
            LINE,
            RECTANGLE,
            ELLIPSE,
            FREE,
            FILL,
            PIPE, 
            TRIANGLE,
            SPRAY
        };
        Queue<Point> q = new Queue<Point>();
        Shape shape = Shape.LINE;
        MyPaint paint = new MyPaint();
        Graphics g;
        bool mouseClicked = false;
        Point prevPoint = new Point(0, 0);
        Graphics gPic;
        Bitmap bmp;
        Color Cur;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            gPic = pictureBox1.CreateGraphics();
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseClicked = true;
            prevPoint = e.Location;
            if (shape == Shape.PIPE)
            {
                paint.penColor = bmp.GetPixel(e.Location.X, e.Location.Y);
            }
            else if (shape == Shape.SPRAY)
            {
                Random _rnd = new Random();
                radius = 15;
                for (int i = 0; i < 100; ++i)
                {
                    double theta = _rnd.NextDouble() * (Math.PI * 2);
                    double r = _rnd.NextDouble() * radius;
                    double x = e.X + Math.Cos(theta) * r;
                    double y = e.Y + Math.Sin(theta) * r;
                    g.DrawEllipse(paint.pen, new Rectangle((int)x - 1, (int)y - 1, 1, 1));
                }
            }
        }
        void step (int x, int y)
        {
            if (x >= bmp.Width)
                return;
            if (x <= 0)
                return;
            if (y >= bmp.Height)
                return;
            if (y <= 0)
                return;
            if (bmp.GetPixel(x, y) != Cur)
                return;
            if (Cur == paint.pen.Color)
                return;
            q.Enqueue(new Point(x, y));
            bmp.SetPixel(x, y, paint.pen.Color);
        }
        Point[] tri;
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseClicked = false;
            //MessageBox.Show(paint.pen.Color.ToString());
            int w = Math.Abs(prevPoint.X - e.Location.X);
            int h = Math.Abs(prevPoint.Y - e.Location.Y);
            int minX = Math.Min(prevPoint.X, e.Location.X);
            int minY = Math.Min(prevPoint.Y, e.Location.Y);
            Point[] Tri = {
                new Point(minX+w/2, minY),
                new Point(minX,minY+h),
                new Point(minX+w, minY+h)
            };
            tri = Tri;
            if (shape == Shape.RECTANGLE)
                g.DrawRectangle(paint.pen, minX, minY, w, h);
            else if (shape == Shape.ELLIPSE)
                g.DrawEllipse(paint.pen, minX, minY, w, h);
            else if (shape == Shape.TRIANGLE)
                g.DrawPolygon(paint.pen , tri);
            else if (shape == Shape.FILL)
            {
                q.Enqueue(e.Location);
                Cur = bmp.GetPixel(e.Location.X, e.Location.Y);
                while (q.Count() >= 1)
                {
                    int x = q.First().X;
                    int y = q.First().Y;
                    q.Dequeue();
                    step(x + 1, y);
                    step(x, y + 1);
                    step(x - 1, y);
                    step(x, y - 1);
                }
            }
            else if (shape == Shape.PIPE)
            {
                paint.penColor = bmp.GetPixel(e.Location.X, e.Location.Y);

            }
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseClicked)
            {
                if (shape == Shape.LINE)
                {
                    g.DrawLine(paint.pen, prevPoint.X, prevPoint.Y, e.Location.X, e.Location.Y);
                    prevPoint = e.Location;
                }
                else if (shape == Shape.SPRAY)
                {
                    Random _rnd = new Random();
                    radius = 15;
                    for (int i = 0; i < 100; ++i)
                    {
                        double theta = _rnd.NextDouble() * (Math.PI * 2);
                        double r = _rnd.NextDouble() * radius;
                        double x = e.X + Math.Cos(theta) * r;
                        double y = e.Y + Math.Sin(theta) * r;
                        g.DrawEllipse(paint.pen, new Rectangle((int)x - 1, (int)y - 1, 1, 1));
                    }
                }
                else if (shape == Shape.RECTANGLE)
                {
                    int w = Math.Abs(prevPoint.X - e.Location.X);
                    int h = Math.Abs(prevPoint.Y - e.Location.Y);
                    int minX = Math.Min(prevPoint.X, e.Location.X);
                    int minY = Math.Min(prevPoint.Y, e.Location.Y);

                    gPic.DrawRectangle(paint.pen, minX, minY, w, h);
                }
                else if (shape == Shape.ELLIPSE)
                {
                    int w = Math.Abs(prevPoint.X - e.Location.X);
                    int h = Math.Abs(prevPoint.Y - e.Location.Y);
                    int minX = Math.Min(prevPoint.X, e.Location.X);
                    int minY = Math.Min(prevPoint.Y, e.Location.Y);
                    gPic.DrawEllipse(paint.pen, minX, minY, w, h);
                }
                else if (shape == Shape.TRIANGLE)
                {
                    int w = Math.Abs(prevPoint.X - e.Location.X);
                    int h = Math.Abs(prevPoint.Y - e.Location.Y);
                    int minX = Math.Min(prevPoint.X, e.Location.X);
                    int minY = Math.Min(prevPoint.Y, e.Location.Y);
                    Point[] tre =
                    {
                        new Point (minX+w/2,minY),
                        new Point (minX, minY+h),
                        new Point (minX + w, minY+h)
                    };
                    tri = tre;
                    gPic.DrawPolygon(paint.pen, tri);
                }
                pictureBox1.Refresh();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            paint.pen.Width = trackBar1.Value;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            shape = Shape.LINE;
            paint.pen.Color = paint.penColor;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            shape = Shape.RECTANGLE;
            paint.pen.Color = paint.penColor;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                paint.pen.Color = c.Color;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            shape = Shape.ELLIPSE;
            paint.pen.Color = paint.penColor;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            shape = Shape.LINE;
            paint.pen.Color = Color.White;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            shape = Shape.FILL;
            paint.pen.Color = paint.penColor;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string a = openFileDialog1.FileName.Replace(@"\", @"\\");
                //MessageBox.Show(a);
                pictureBox1.Image = Image.FromFile(a);
                bmp = new Bitmap(a);
                g = Graphics.FromImage(bmp);
                gPic = pictureBox1.CreateGraphics();
                pictureBox1.Image = bmp;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmpSave = bmp;
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)

                bmpSave.Save(sfd.FileName);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            shape = Shape.PIPE;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            shape = Shape.TRIANGLE;
        }
        int radius;
        private void button11_Click(object sender, EventArgs e)
        {
            //radius = 15;
            shape = Shape.SPRAY;
        }
    }
}
