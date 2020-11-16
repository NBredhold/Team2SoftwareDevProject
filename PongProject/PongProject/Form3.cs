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
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            try
            {
                Form2.scores.Sort();
                Form2.scores.Reverse();
                int highScore = Form2.scores.Max();
                label2.Text = highScore.ToString();
                /*foreach (int item in Form2.scores)
                {
                    label2.Text = item.ToString();
                }*/
            }
            catch
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
