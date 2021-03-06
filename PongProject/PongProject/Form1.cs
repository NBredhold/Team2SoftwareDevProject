﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongProject
{
    public partial class Form1 : Form
    {
        public static bool easy = false;
        public static bool medium = false;
        public static bool hard = false;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Easy");
            comboBox1.Items.Add("Intermediate");
            comboBox1.Items.Add("Hard");
            comboBox1.Text = "Select Difficulty: ";
        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Easy")
            {
                easy = true;
                medium = false;
                hard = false;
            }else if (comboBox1.Text == "Intermediate")
            {
                easy = false;
                medium = true;
                hard = false;
            }
            else if (comboBox1.Text == "Hard")
            {
                easy = false;
                medium = false;
                hard = true;
            }
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
