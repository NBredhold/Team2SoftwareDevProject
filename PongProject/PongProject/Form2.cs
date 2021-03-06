﻿using System;
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
        public int ballYSpeed = -5;
        public static List<int> scores = new List<int>();
        public bool GameRunning = false;
        int game = 0;
        private readonly Random _random = new Random();


        public Form2()
        {
            InitializeComponent();

            this.KeyPreview = true;
            label6.Visible = false;
            label7.Visible = false;
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

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
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
            int score = int.Parse(label1.Text);
            scores.Add(score);
            GameRunning = false;
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int xx = pictureBox2.Location.X;
            int yy = pictureBox2.Location.Y;
            if (GameRunning == true)
            {
                int ballx = pictureBox3.Location.X;
                int bally = pictureBox3.Location.Y;
                ballx += ballXSpeed;
                bally += ballYSpeed;
                pictureBox3.Location = new Point(ballx, bally);
                label6.Text = ballx.ToString();
                label7.Text = bally.ToString();
                label4.Text = ballYSpeed.ToString();

                if (pictureBox3.Location.Y > 620)
                {
                    ballYSpeed = -ballYSpeed;
                    pictureBox3.Location = new Point(ballx, bally);
                }else if (pictureBox3.Location.Y < 15)
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
                    ballYSpeed = RandomNumber(-5 , 5);
                    ballXSpeed = -ballXSpeed;
                    pictureBox3.Location = new Point(ballx, bally);
                    SpeedUp();
                }
            }
            if (Form1.easy == true)
            {
                if (pictureBox2.Location.Y > (18) && pictureBox2.Location.Y < 468)
                {
                    if (ballYSpeed > 0)
                    {
                        yy += 5;
                        pictureBox2.Location = new Point(xx, yy);
                    }
                    else if (ballYSpeed < 0)
                    {
                        yy -= 5;
                        pictureBox2.Location = new Point(xx, yy);
                    }
                }
                else if (pictureBox2.Location.Y < (22))
                {
                    yy += 10;
                    pictureBox2.Location = new Point(xx, yy);
                }
                else if (pictureBox2.Location.Y > (460))
                {
                    yy -= 10;
                    pictureBox2.Location = new Point(xx, yy);
                }
            }
            if (Form1.medium == true)
            {
                if (pictureBox2.Location.Y > (18) && pictureBox2.Location.Y < 468)
                {
                    if (ballYSpeed > 0)
                    {
                        yy += 2;
                        pictureBox2.Location = new Point(xx, yy);
                    }
                    else if (ballYSpeed < 0)
                    {
                        yy -= 2;
                        pictureBox2.Location = new Point(xx, yy);
                    }
                }
                else if (pictureBox2.Location.Y < (22))
                {
                    yy += 10;
                    pictureBox2.Location = new Point(xx, yy);
                }
                else if (pictureBox2.Location.Y > (460))
                {
                    yy -= 10;
                    pictureBox2.Location = new Point(xx, yy);
                }
            }
            if (Form1.hard == true)
            {
                if (pictureBox2.Location.Y > (18) && pictureBox2.Location.Y < 468)
                {
                    if (ballYSpeed > 0)
                    {
                        yy += ballYSpeed;
                        pictureBox2.Location = new Point(xx, yy);
                    }
                    else if (ballYSpeed < 0)
                    {
                        yy -= -ballYSpeed;
                        pictureBox2.Location = new Point(xx, yy);
                    }
                }
                else if (pictureBox2.Location.Y < (22))
                {
                    yy += 10;
                    pictureBox2.Location = new Point(xx, yy);
                }
                else if (pictureBox2.Location.Y > (460))
                {
                    yy -= 10;
                    pictureBox2.Location = new Point(xx, yy);
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
