using Flappy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy
{
    public partial class Form1 : Form
    {
        Graphics k, g;
        Bitmap bird = new Bitmap("bird.png");
        Bitmap upper = new Bitmap("upper.png");
        Bitmap lower = new Bitmap("lower.png");
        Rectangle dUp,DLo,bL;
        bool GOver = false;
        int Score = 0;
        bool Wpassed = false;
        bool plus = false;

        public Form1()
        {
            InitializeComponent();
            k = this.CreateGraphics();
            g = this.CreateGraphics();
            dUp = new Rectangle(550, -120, upper.Width+20, upper.Height+20);
            DLo = new Rectangle(550, upper.Height+30, upper.Width+20, upper.Height+20);
            bL = new Rectangle(50, 130, bird.Width/3, bird.Height/3);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GOver == false)
            {
                bL.Y += 10;
                if (bL.IntersectsWith(dUp) || bL.IntersectsWith(DLo))
                {
                    GOver = true;
                    if (GOver == true)
                    {
                        MessageBox.Show("Sooorrry" + " Your Score: " + Score);
                    }
                }
                Refresh();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (GOver == false)
            {
                if (e.KeyCode == Keys.Space)
                {
                    bL.Y -= 50;
                    Refresh();
                }
            }
            else
            {
                MessageBox.Show("SooRRRy");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (GOver == false)
            {
                dUp.X -= 20;
                DLo.X -= 20;
                if (Wpassed == false && dUp.X < bL.X)
                {
                    Score += 1;
                    label1.Text = Score.ToString();
                    Wpassed = true;
                }
                if (dUp.X < -50)
                {
                    Random r = new Random();
                    int rand;
                    rand = r.Next(0, 50);
                    if (plus == false)
                    {
                        dUp.Y += rand;
                        DLo.Y += rand;
                        plus = true;
                    }
                    else
                    {
                        dUp.Y -= rand;
                        DLo.Y -= rand;
                        plus = false;
                    }
                    dUp.X += 500;
                    DLo.X += 500;
                    Wpassed = false;
                }
                Refresh();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawImage(bird, bL);
            k.DrawImage(upper, dUp);
            k.DrawImage(lower, DLo);
        }
    }
}
