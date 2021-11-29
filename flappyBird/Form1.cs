using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappyBird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 5;
        int gravity = 5;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            pipeBottom2.Left -= pipeSpeed;
            pipeTop2.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if (pipeBottom.Left < -150 || pipeBottom2.Left < -150 )
            {
                pipeBottom.Left = 800;
                pipeBottom2.Left = 800;
                score++;
            }
            if (pipeTop.Left < -200 || pipeTop.Left < -200)
            {
                pipeTop.Left = 950;
                pipeTop2.Left = 950;
                score++; 
            }
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
               flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
               flappyBird.Bounds.IntersectsWith(pipeBottom2.Bounds) ||
               flappyBird.Bounds.IntersectsWith(pipeTop2.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || 
                   flappyBird.Top < -25)
            {
                endGame();
            }

            if (score > 5)
            {
                pipeSpeed = 10;
            }
            else if (score > 15)
            {
                pipeSpeed = 20;
            }
                
            
        }

        private void gameKeysDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }

        }

        private void gameKeysUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space )
            {
                gravity = 5;
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " | Game Over!";
        }
    }
}
