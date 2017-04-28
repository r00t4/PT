using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;     

namespace astr
{
    public partial class frmAsteroids : Form
    {
        PictureBox picSpaceStation = new PictureBox();
        PictureBox[] picAsteroids = new PictureBox[8];
        int[,] AsteroidsCoord = { { -100, 600 }, { -100, -100 }, { 800, 350 }, { 800, -100 }, { 800, 600 } };
        int direction = 1;
        PictureBox picSpaceShip = new PictureBox();
        Random rnd = new Random();
        PictureBox Rocket = new PictureBox();
        int RocketDirection = 1;
        bool fire = false;

        public frmAsteroids()
        {
            InitializeComponent();

            KeyDown += new KeyEventHandler(SpaceShipMove_KeyDown); 

        }


        private void frmAsteroids_Load(object sender, EventArgs e)
        {
            SetUpSpaceStation();
            SetUpAsteoids();
            MoveAsteroids();
            SetUpSpaceShip();

        }
        void SetUpSpaceStation()
        {
            picSpaceStation.Image = imageList1.Images[9];
            picSpaceStation.Size = new Size(50, 50);
            picSpaceStation.SizeMode = PictureBoxSizeMode.StretchImage;
            picSpaceStation.Left = 900;
            picSpaceStation.Top = -50;
            Controls.Add(picSpaceStation);
            tmrSpaceStation.Start();
        }

        private void tmrSpaceStation_Tick(object sender, EventArgs e)
        {
            if (picSpaceStation.Left > -100)
            {
                picSpaceStation.Left -= 5;
                picSpaceStation.Top += 1;
            }
            else
            {
                Controls.Remove(picSpaceStation);
                tmrSpaceStation.Stop();
            }


        }
        void SetUpAsteoids()
        {
            for (int i = 0; i < 5; i++)
            {
                picAsteroids[i] = new PictureBox();
                picAsteroids[i].Image = imageList1.Images[0];
                picAsteroids[i].Size = new Size(50, 50);
                picAsteroids[i].SizeMode = PictureBoxSizeMode.StretchImage;
                picAsteroids[i].Left = AsteroidsCoord[i, 0];
                picAsteroids[i].Top = AsteroidsCoord[i, 1];
                Controls.Add(picAsteroids[i]);
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (picAsteroids[0].Left > ClientSize.Width + 60)
            {
                picAsteroids[0].Left = AsteroidsCoord[0, 0];
                picAsteroids[0].Top = AsteroidsCoord[0, 1];
            }
            else
            {
                picAsteroids[0].Left += 4;
                picAsteroids[0].Top -= 4;
            }
            if (picAsteroids[1].Left > ClientSize.Width + 60)
            {
                picAsteroids[1].Left = AsteroidsCoord[1, 0];
                picAsteroids[1].Top = AsteroidsCoord[1, 1];
            }
            else
            {
                picAsteroids[1].Left += 6;
                picAsteroids[1].Top += 2;
            }
            if (picAsteroids[2].Left < -60)
            {
                picAsteroids[2].Left = AsteroidsCoord[2, 0];
                picAsteroids[2].Top = AsteroidsCoord[2, 1];
            }
            else
            {
                picAsteroids[2].Left -= 4;
                picAsteroids[2].Top -= 1;
            }
            if (picAsteroids[3].Left < -60)
            {
                picAsteroids[3].Left = AsteroidsCoord[3, 0];
                picAsteroids[3].Top = AsteroidsCoord[3, 1];
            }
            else
            {
                picAsteroids[3].Left -= 8;
                picAsteroids[3].Top += 2;
            }
            if (picAsteroids[4].Left < -60)
            {

                picAsteroids[4].Left = AsteroidsCoord[4, 0];
                picAsteroids[4].Top = AsteroidsCoord[4, 1];

            }
            else
            {
                picAsteroids[3].Left -= 2;
                picAsteroids[3].Top += 4;
            }


        }
        void MoveAsteroids()
        {
            tmrAsteroids.Start();
        }
        

        void SpaceShipMove_KeyDown(object sender, KeyEventArgs e)
        {
            this.Focus();

            switch (e.KeyCode)
            {
                case Keys.Right:
                    switch (direction)
                    {
                        case 1:
                            direction = 2;
                            picSpaceShip.Image = imageList1.Images[direction];
                            break;
                        case 2:
                            direction = 3;
                            picSpaceShip.Image = imageList1.Images[direction];
                            break;
                        case 3:
                            direction = 4;
                            picSpaceShip.Image = imageList1.Images[direction];
                            break;
                        case 4:
                            direction = 5;
                            picSpaceShip.Image = imageList1.Images[direction];
                            break;
                        case 5:
                            direction = 6;
                            picSpaceShip.Image = imageList1.Images[direction];
                            break;
                        case 6:
                            direction = 7;
                            picSpaceShip.Image = imageList1.Images[direction];
                            break;
                        case 7:
                            direction = 8;
                            picSpaceShip.Image = imageList1.Images[direction];
                            break;
                        case 8:
                            direction = 1;
                            picSpaceShip.Image = imageList1.Images[direction];
                            break;
                    }
                    break;

                case Keys.Left:
                    switch (direction)
                    {
                        case 1:
                            direction = 8;
                            picSpaceShip.Image = imageList1.Images[direction];
                            break;
                        case 8:
                            direction = 7;
                            picSpaceShip.Image = imageList1.Images[direction];
                            break;
                        case 7:
                            direction = 6;
                            picSpaceShip.Image = imageList1.Images[direction];
                            break;
                        case 6:
                            direction = 5;
                            picSpaceShip.Image = imageList1.Images[direction];
                            break;
                        case 5:
                            direction = 4;
                            picSpaceShip.Image = imageList1.Images[direction];
                            break;
                        case 4:
                            direction = 3;
                            picSpaceShip.Image = imageList1.Images[direction];
                            break;
                        case 3:
                            direction = 2;
                            picSpaceShip.Image = imageList1.Images[direction];
                            break;
                        case 2:
                            direction = 1;
                            picSpaceShip.Image = imageList1.Images[direction];
                            break; 
                    }
                    break;
                case Keys.Up:
                    tmrSpaceShip.Start();
                    break;
                case Keys.Down:
                    tmrSpaceShip.Stop();
                    break;
                case Keys.R:
                    picSpaceShip.Left = rnd.Next(0, ClientSize.Width - picSpaceShip.Right);
                    picSpaceShip.Top = rnd.Next(0, ClientSize.Height - picSpaceShip.Bottom);
                    break;
                case Keys.Space:
                    tmrRocket.Interval = 1;
                    tmrRocket.Start();
                    break;
           

            }
        }

        private void tmrSpaceShip_Tick(object sender, EventArgs e)
        {
            switch (direction)
            {
                case 1:
                    if (picSpaceShip.Bottom >= 0)
                        picSpaceShip.Top -= 9;
                    else
                        picSpaceShip.Top = this.ClientSize.Height + 50;
                    break;
                case 2:
                    if (picSpaceShip.Bottom >= 0 && picSpaceShip.Right <= this.ClientSize.Width)
                    { picSpaceShip.Top -= 6;
                      picSpaceShip.Left += 6;
                    }
                    else
                    {
                        picSpaceShip.Left = -50;
                      picSpaceShip.Top = this.ClientSize.Height + 50;
                    }
                    break;

                case 3:
                    if (picSpaceShip.Right <= this.ClientSize.Width)
                        picSpaceShip.Left += 9;
                    else
                        picSpaceShip.Left = -50;
                    break;
                case 4:
                    if (picSpaceShip.Bottom <= this.ClientSize.Height && picSpaceShip.Right <= this.ClientSize.Width)
                    {
                        picSpaceShip.Top += 6;
                        picSpaceShip.Left += 6;
                    }
                    else
                    {
                        picSpaceShip.Left = -50;
                        picSpaceShip.Top = -50;
                    }
                    break;
                case 5:
                
                    if (picSpaceShip.Top <= this.ClientSize.Height)
                        picSpaceShip.Top += 6;
                    else
                        picSpaceShip.Top = -50;
                    break;
                case 6:
                    if (picSpaceShip.Bottom <= this.ClientSize.Height && picSpaceShip.Left >= 0)
                    
                    {
                        picSpaceShip.Top += 6;
                        picSpaceShip.Left -= 4;
                    }
                    else
                    {
                        picSpaceShip.Left = this.ClientSize.Width + 50;
                        picSpaceShip.Top = -50;
                    }
                    break;
                case 7:
                    if (picSpaceShip.Top >= 0 && picSpaceShip.Left >= 0)
                        picSpaceShip.Left -= 8;
                    else
                        picSpaceShip.Left = this.ClientSize.Width + 1550;
                    break;

                case 8:
                    if (picSpaceShip.Top >= 0 && picSpaceShip.Left >= 0)
                    {
                        picSpaceShip.Top -= 6;
                        picSpaceShip.Left -= 6;
                    }
                    else
                    {
                        picSpaceShip.Left = this.ClientSize.Width + 50;

                        picSpaceShip.Top = this.ClientSize.Height + 50;
                    }
                    break;



            }
        }

        void SetUpSpaceShip()
        {
            picSpaceShip.Image = imageList1.Images[1];
            picSpaceShip.Size = new Size(50, 50);
            picSpaceShip.SizeMode = PictureBoxSizeMode.StretchImage;
            picSpaceShip.Left = 450;
            picSpaceShip.Top = 225;
            Controls.Add(picSpaceShip);
        }

        private void tmrRocket_Tick(object sender, EventArgs e)
        {
            if (!fire)
            {
                Rocket.BackColor = Color.Cyan;
                RocketStartPosition();
                Rocket.Size = new Size(5, 5);
                Controls.Add(Rocket);
                fire = true;
            }
            label1.Text = "Score;" + score.ToString();
            RocketMove();
            Shot();
        }
        private void RocketStartPosition()
        {
            if (!fire)
            {
                RocketDirection = direction;
                switch (RocketDirection)
                {
                    case 1:
                        Rocket.Top = picSpaceShip.Top;

                        Rocket.Left = picSpaceShip.Left + 25;
                        break;
                    case 2:
                        
                        Rocket.Top = picSpaceShip.Top;

                        Rocket.Left = picSpaceShip.Left + 50;
                        break;
                    case 3:
                        
                        Rocket.Top = picSpaceShip.Top + 25;

                        Rocket.Left = picSpaceShip.Left + 50;
                        break;
                    case 4:
                        
                        Rocket.Top = picSpaceShip.Top + 50;

                        Rocket.Left = picSpaceShip.Left + 50;
                        break;
                    case 5:
                        
                        Rocket.Top = picSpaceShip.Top + 50;

                        Rocket.Left = picSpaceShip.Left + 25;
                        break;
                    case 6:
                        
                        Rocket.Top = picSpaceShip.Top + 50;

                        Rocket.Left = picSpaceShip.Left;
                            break;
                    case 7:
                        
                        Rocket.Top = picSpaceShip.Top + 25;

                        Rocket.Left = picSpaceShip.Left ;
                        break;
                    case 8:
 
                        Rocket.Top = picSpaceShip.Top + 50;

                        Rocket.Left = picSpaceShip.Left + 25;
                        break;
                }
            }
        }


                private void RocketMove()
                {
                    switch (RocketDirection)
                    {
                        case 1: 
                            if (Rocket.Bottom >=0)
                                Rocket.Top -= 5;
                            else
                            {
                                fire = false;
                                tmrRocket.Enabled = false;
                                Controls.Remove(Rocket);
                            }
                            break;
                        case 2:
                            if (Rocket.Bottom >=0 && Rocket.Right <= this.ClientSize.Width)
                            {Rocket.Top -=5;
                                Rocket.Left += 5;

                            }else{
                                fire = false;
                                tmrRocket.Enabled = false;
                                Controls.Remove(Rocket);
                            }break;
                        case 3:
                            if (Rocket.Right <= this.ClientSize.Width)
                                Rocket.Left += 5;
                        else{
                            fire = false;
                            tmrRocket.Enabled = false;
                            Controls.Remove(Rocket);
                            
                            }
                            break;

                        case 4:
                            if (Rocket.Bottom <= this.ClientSize.Height && Rocket.Right<=this.ClientSize.Width)
                            {
                                Rocket.Top += 5;
                                Rocket.Left += 5;
                            }
                            else
                            {
                                fire = false;
                                tmrRocket.Enabled = false;
                                Controls.Remove(Rocket);
                            }
                            break;
                        case 5:
                            if (Rocket.Top <= this.ClientSize.Height)
                                Rocket.Top += 5;
                            else{
                                fire = false;
                                tmrRocket.Enabled = false;
                                
                                Controls.Remove(Rocket);
                            }
                            break;
                        case 6:
                            if (Rocket.Bottom <= this.ClientSize.Height && Rocket.Left>=0)
                            {
                                Rocket.Top += 3;
                                Rocket.Left -= 3;
                            }
                            else
                            {
                                fire = false;
                                tmrRocket.Enabled = false;
                                Controls.Remove(Rocket);
                            }
                            break;
                        case 7:
                            if (Rocket.Left >=-50)
                                Rocket.Left -= 5;
                            else
                            {
                                 fire = false;
                                tmrRocket.Enabled = false;
                                Controls.Remove(Rocket);
                                
                            }
                            break;
                        case 8:
                            if (Rocket.Top>=0 &&  Rocket.Left >= 0)
                            {
                                Rocket.Top -= 5;
                                Rocket.Left-= 5;

                            }
                            else
                            {
                                fire = false;
                                tmrRocket.Enabled = false;
                                Controls.Remove(Rocket);
                            }
                            break;
                    }
                }
        int score = 0;
                private void Shot() 
                {
                    if (fire)
                    {
                        for (int i=0; i<5; i++)
                            if (Rocket.Bounds.IntersectsWith(picAsteroids[i].Bounds) && picAsteroids[i].Visible == true)
                            {
                                picAsteroids[i].Visible = false;
                                fire = false;
                                tmrRocket.Enabled = false;
                                Controls.Remove(Rocket);
                            }

                    }

                }

                private void tmrAsterTick_Tick(object sender, EventArgs e)
                {
                    for (int i=0; i<5; i++)
                    {

                        if (picAsteroids[i].Bounds.IntersectsWith(picSpaceShip.Bounds) && picAsteroids[i].Visible == true)
                        {
                            picAsteroids[i].Visible = false;
                            picSpaceShip.Visible = false;
                            MessageBox.Show("GAME OVER!");
                        }
                    }
                }






                            }
                                

                            }

