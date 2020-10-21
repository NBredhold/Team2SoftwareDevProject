using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongProject
{
    public partial class Form2 : Form
    {
        public int score1 = 0;
        public int score2 = 0;
        public int ballXSpeed = -1;
        public int ballYSpeed = 1;

      
        public Form2()
        {
            InitializeComponent();
            label1.Text = pictureBox1.Location.X.ToString();
            label2.Text = pictureBox2.Location.X.ToString();
            label3.Text = pictureBox3.Location.X.ToString();
        }

        public void SpeedUp()
        {
            ballXSpeed = ballXSpeed < 0 ? ballXSpeed -= 1 : ballXSpeed += 1;
        }
        /*public void BallMovement(Timer ti)
        {
            int ballx = pictureBox3.Location.X;
            int bally = pictureBox3.Location.Y;
            ballx += ballXSpeed;
            bally += ballYSpeed;

            if (bally > 18 || bally < 468)
            {
                ballYSpeed = -ballYSpeed;
            }
            if (ballx > 1481 || ballx < 1)
            {
                ballXSpeed = -ballXSpeed;
            }
            if (pictureBox3.InterscectsWith(pictureBox1) || pictureBox3.InterscectsWith(pictureBox2))
            {

            }
        }*/

        /*public Boolean CollisionPlayer(PictureBox tar)
        {
            if (tar.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                PictureBox temp1 = new PictureBox();
                temp1.Bounds = pictureBox1.Bounds;
                temp1.SetBounds(temp1.Location.X + temp1.Width, temp1.Location.Y, 1, 10);
                if (tar.Bounds.IntersectsWith(temp1.Bounds))
                {
                    BallForce = 3;
                    return true;
                }
                temp1.SetBounds(temp1.Location.X, temp1.Location.Y + 5, 1, 10);
                if (tar.Bounds.IntersectsWith(temp1.Bounds))
                {
                    BallForce = 2;
                    return true;
                }
                temp1.SetBounds(temp1.Location.X, temp1.Location.Y + 10, 1, 10);
                if (tar.Bounds.IntersectsWith(temp1.Bounds))
                {
                    BallForce = 1;
                    return true;
                }
            }
        }*/
                private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;

            try
            {
                if (pictureBox1.Location.Y > (18) && pictureBox1.Location.Y < 468)
                {
                    if (e.KeyCode == Keys.W)
                    {
                        y -= 10;
                        label1.Text = pictureBox1.Location.Y.ToString();
                    }
                    else if (e.KeyCode == Keys.S)
                    {
                        y += 10;
                        label1.Text = pictureBox1.Location.Y.ToString();
                    }

                    pictureBox1.Location = new Point(x, y);
                }
                else if (pictureBox1.Location.Y < (18))
                {
                    y += 10;
                    label1.Text = pictureBox1.Location.Y.ToString();
                    pictureBox1.Location = new Point(x, y);
                }
                else if (pictureBox1.Location.Y > (468))
                {
                    y -= 10;
                    label1.Text = pictureBox1.Location.Y.ToString();
                    pictureBox1.Location = new Point(x, y);
                }

            }
            catch
            {

            }  
        }

        public Boolean Left_Wall(PictureBox pictureBox)
        {
            if(pictureBox3.Location.X <= panel1.Location.X)
            {
                return true;
            }
            return false;
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
