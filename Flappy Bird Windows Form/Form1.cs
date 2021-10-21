using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 8;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimeEvent(object sender, EventArgs e)
        {
            flappyBird.Top +=   gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " +score;
            this.Size = new Size (580,600);
            this.CenterToScreen();
            creditText.Visible = true;


            if (pipeBottom.Left <-50) 
            {
                pipeBottom.Left = 550;
                score ++;
            }
            if (pipeTop.Left < -80) 
            {
                pipeTop.Left = 590;
                score ++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Top < -25

                ) 
            {
                endGame();
            }

            if (score > 5) 
            {
                pipeSpeed = 15;
            }

            if(score > 20)
            {
                pipeSpeed = 20;
            }

        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
           
        }

        private void endGame() 
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!!!";
           
        }

    }
}
