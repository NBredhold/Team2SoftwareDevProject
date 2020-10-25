using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongProject
{
    public partial class Form2 : Form
    {
        public int score1 = 0;
        public int score2 = 0;
        public int ballXSpeed = -5;
        public int ballYSpeed = 5;
        public static PictureBox[] Player = new PictureBox[5];  
        public static PictureBox[] Enemy = new PictureBox[5];
        public bool GameRunning = false;
        int game = 0;


        public Form2()
        {
            InitializeComponent();

            this.KeyPreview = true;
        }

        public void score()
        {
            if (pictureBox3.Location.X < 2)
            {
                score2 = int.Parse(label2.Text) + 1;
                label2.Text = score2.ToString();
                pictureBox3.Location = new Point(700, 300);
                ballXSpeed = 5;
            }
            else if (pictureBox3.Location.X > 1400)
            {
                score1 = int.Parse(label1.Text) + 1;
                label1.Text = score1.ToString();
                pictureBox3.Location = new Point(700, 300);
                ballXSpeed = -5;
            }


        }

        public void SpeedUp()
        {
            ballXSpeed = ballXSpeed < 0 ? ballXSpeed -= 1 : ballXSpeed += 1;
        }

        
        private bool IsTouching(PictureBox p1, PictureBox p2)
        {
            if (p1.Location.X + p1.Width < p2.Location.X)
                return false;
            if (p2.Location.X + p2.Width < p1.Location.X)
                return false;
            if (p1.Location.Y + p1.Height < p2.Location.Y)
                return false;
            if (p2.Location.Y + p2.Height < p1.Location.Y)
                return false;
            return true;
        }
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
                    }
                    else if (e.KeyCode == Keys.S)
                    {
                        y += 10; 
                    }

                    pictureBox1.Location = new Point(x, y);
                }
                else if (pictureBox1.Location.Y < (18))
                {
                    y += 10;
                    pictureBox1.Location = new Point(x, y);
                }
                else if (pictureBox1.Location.Y > (468))
                {
                    y -= 10;
                    pictureBox1.Location = new Point(x, y);
                }

                

            }
            catch
            {

            }  
       }
      
        private void Form2_Load(object sender, EventArgs e)
        {
            GameRunning = true;
            label1.Text = score1.ToString(); 
            label2.Text = score2.ToString();
            label4.Text = pictureBox3.Location.X.ToString();
            label5.Text = pictureBox3.Location.Y.ToString();
            timer2.Interval = 20;
            timer2.Tick += timer2_Tick;
            timer2.Start();
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

        private void button1_Click(object sender, EventArgs e)
        {
            GameRunning = false;
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (GameRunning == true)
            {
                int ballx = pictureBox3.Location.X;
                int bally = pictureBox3.Location.Y;
                ballx += ballXSpeed;
                bally += ballYSpeed;
                pictureBox3.Location = new Point(ballx, bally);
                label6.Text = ballx.ToString();
                label7.Text = bally.ToString();

                if (pictureBox3.Location.X > 18 || pictureBox3.Location.Y < 468)
                {
                    ballYSpeed = -ballYSpeed;
                    pictureBox3.Location = new Point(ballx, bally);
                }
                if (pictureBox3.Location.X > 1415)
                {
                    ballXSpeed = -ballXSpeed;
                    score();
                    pictureBox3.Location = new Point(700, 300);
                }
                if (pictureBox3.Location.X < -5)
                {
                    ballXSpeed = -ballXSpeed;
                    score();
                    pictureBox3.Location = new Point(700, 300);
                }
                if (IsTouching(pictureBox1, pictureBox3) == true || IsTouching(pictureBox2, pictureBox3) == true)
                {
                    ballYSpeed = -ballYSpeed;
                    ballXSpeed = -ballXSpeed;
                    pictureBox3.Location = new Point(ballx, bally);
                    SpeedUp();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GameRunning)
            {
                game++;
                TimeSpan time = TimeSpan.FromSeconds(game);
                string str = time.ToString(@"mm\:ss");
                label3.Text = "Time: " + str;
            }
        }       
    }
}
