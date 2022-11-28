﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirHockeyProject
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(150, 210, 50, 50);
        Rectangle player2 = new Rectangle(600, 210, 50, 50);
        Rectangle puck = new Rectangle(390, 225, 20, 20);
        Rectangle p1Net = new Rectangle(1, 130, 20, 200);
        Rectangle p2Net = new Rectangle(762, 130, 20, 200);
        Rectangle topBorder = new Rectangle(1, 1, 780, 1);
        Rectangle bottomBorder = new Rectangle(1, 458, 780, 1);
        Rectangle rightBorder = new Rectangle(781, 1, 1, 457);
        Rectangle leftBorder = new Rectangle(1, 1, 1, 457);

        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 8;
        int puckXSpeed = -5;
        int puckYSpeed = 5;

        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        SolidBrush p1Brush = new SolidBrush(Color.Lime);
        SolidBrush p2Brush = new SolidBrush(Color.DeepPink);
        SolidBrush puckBrush = new SolidBrush(Color.White);
        Pen outlinePen = new Pen(Color.LightSlateGray, 3);
        Pen p1Pen = new Pen(Color.Lime, 3);
        Pen p2Pen = new Pen(Color.DeepPink, 3);

        int puckX;
        int puckY;

        int player1X;
        int player1Y;

        int player2X;
        int player2Y;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(p1Pen, p1Net);
            e.Graphics.DrawRectangle(p2Pen, p2Net);
            e.Graphics.DrawLine(outlinePen, 400, 0, 400, 500);
            e.Graphics.DrawArc(p1Pen, -127, 105, 250, 250, 270, 180);
            e.Graphics.DrawArc(p2Pen, 670, 105, 250, 250, -270, 180);
            e.Graphics.DrawRectangle(outlinePen, topBorder);
            e.Graphics.DrawRectangle(outlinePen, bottomBorder);
            e.Graphics.DrawRectangle(outlinePen, rightBorder);
            e.Graphics.DrawRectangle(outlinePen, leftBorder);
            e.Graphics.DrawEllipse(outlinePen, 355, 190, 90, 90);
            e.Graphics.FillEllipse(p1Brush, player1);
            e.Graphics.FillEllipse(p2Brush, player2);
            e.Graphics.FillEllipse(puckBrush, puck);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            puckX = puck.X;
            puckY = puck.Y;

            player1X = player1.X;
            player1Y = player1.Y;

            player2X = player2.X;
            player2Y = player2.Y;

            //player one collision borders
            Rectangle paddle1Top = new Rectangle(player1.X, player1.Y, player1.Width, 1);
            Rectangle paddle1Bottom = new Rectangle(player1.X, player1.Y + player1.Height, player1.Width, 1);
            Rectangle paddle1Right = new Rectangle(player1.X + player1.Width, player1.Y, 1, player1.Height);
            Rectangle paddle1Left = new Rectangle(player1.X, player1.Y, 1, player1.Height);

            //player 2 collision borders
            Rectangle paddle2Top = new Rectangle(player2.X, player2.Y, player2.Width, 1);
            Rectangle paddle2Bottom = new Rectangle(player2.X, player2.Y + player2.Height, player2.Width, 1);
            Rectangle paddle2Right = new Rectangle(player2.X + player2.Width, player1.Y, 1, player2.Height);
            Rectangle paddle2Left = new Rectangle(player2.X, player2.Y, 1, player2.Height);

            //move puck 
            puck.X += puckXSpeed;
            puck.Y += puckYSpeed;

            //move player 1 
            if (wDown == true && paddle1Top.Y > topBorder.Y + 3)
            {
                player1.Y -= playerSpeed;
            }

            if (aDown == true && paddle1Left.X > leftBorder.X + 3)
            {
                player1.X -= playerSpeed;
            }

            if (sDown == true && paddle1Bottom.Y + paddle1Bottom.Height < bottomBorder.Y - 3)
            {
                player1.Y += playerSpeed;
            }

            if (dDown == true && paddle1Right.X < 397)
            {
                player1.X += playerSpeed;
            }

            //move player 2 
            if (upArrowDown == true && paddle2Top.Y > topBorder.Y + 3)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && paddle2Bottom.Y + paddle2Bottom.Height < bottomBorder.Y - 3)
            {
                player2.Y += playerSpeed;
            }

            if (leftArrowDown == true && paddle2Left.X > 403)
            {
                player2.X -= playerSpeed;
            }

            if (rightArrowDown == true && paddle2Right.X < rightBorder.X - 3)
            {
                player2.X += playerSpeed;
            }
            
            //check if puck hits top/bottom wall
            if (puck.IntersectsWith(topBorder) || puck.IntersectsWith(bottomBorder))
            {
                puckYSpeed *= -1;
            }

            //check if puck hits right/left wall
            if (puck.IntersectsWith(rightBorder) || puck.IntersectsWith(leftBorder))
            {
                puckXSpeed *= -1;
            }

            //check if puck  hits player 1
            if (puck.IntersectsWith(paddle1Top) || puck.IntersectsWith(paddle1Bottom))
            {
                puckYSpeed *= -1;

                puck.X = puckX;
                puck.Y = puckY;

                player1.X = player1X;
                player1.Y = player1Y;
            }
            else if (puck.IntersectsWith(paddle1Right) || puck.IntersectsWith(paddle1Left))
            {
                puckXSpeed *= -1;

                puck.X = puckX;
                puck.Y = puckY;

                player1.X = player1X;
                player1.Y = player1Y;
            }

            //check if puck hits player 2
            if (puck.IntersectsWith(paddle2Top) || puck.IntersectsWith(paddle2Bottom))
            {
                puckYSpeed += -1;

                puck.X = puckX;
                puck.Y = puckY;

                player2.X = player2X;
                player2.Y = player2Y;
            }
            else if (puck.IntersectsWith(paddle2Right) || puck.IntersectsWith(paddle2Left))
            {
                puckXSpeed *= -1;

                puck.X = puckX;
                puck.Y = puckY;

                player2.X = player2X;
                player2.Y = player2Y;
            }

            //check if puck hits a net.If so, add one point to opposing player's score
            if (puck.IntersectsWith(p1Net))
            {
                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";

                puck.X = 390;
                puck.Y = 225;

                player1.X = 150;
                player1.Y = 210;
                player2.X = 600;
                player2.Y = 210;

                if (player1Score == 5)
                {
                    gameTimer.Enabled = false;
                    winLabel.Visible = true;
                    winLabel.Text = "PLAYER 1 WINS!!";
                }
                else if (player2Score == 5)
                {
                    gameTimer.Enabled = false;
                    winLabel.Visible = true;
                    winLabel.Text = "PLAYER 2 WINS!!";
                }
            }
            else if (puck.IntersectsWith(p2Net))
            {
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";

                puck.X = 390;
                puck.Y = 225;

                player1.X = 150;
                player1.Y = 210;
                player2.X = 600;
                player2.Y = 210;

                if (player1Score == 5)
                {
                    gameTimer.Enabled = false;
                    winLabel.Visible = true;
                    winLabel.Text = "PLAYER 1 WINS!!";
                }
                else if (player2Score == 5)
                {
                    gameTimer.Enabled = false;
                    winLabel.Visible = true;
                    winLabel.Text = "PLAYER 2 WINS!!";
                }
            }

            Refresh();
        }
    }
}
