using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Client1712
{
    public class PacmanPlayer
    {
        private int[,] bordGame = { 
                            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            { 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1 },
                            { 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 4, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                            { 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                            { 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 1 },
                            { 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1 },
                            { 1, 0, 0, 4, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1 },
                            { 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 },
                            { 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                            { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1 },
                            { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1 },
                            { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1 },
                            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                          };
       
        public string dir { get; set; }
        private string UserName;
        PictureBox[,] boardImages;
        
        public PictureBox PacMan { get; set; }
        
        public PacmanPlayer(string UserName, string direction)
        {
            this.UserName = UserName;
            this.dir = direction;
            
            boardImages = new PictureBox[bordGame.GetLength(0) , bordGame.GetLength(1) ];

        }
        public void drawBoardGame(Panel addToForm , int xstart , int ystart)
        {
            int xpos = xstart;
            int ypos = ystart;
            for (int i = 0; i < bordGame.GetLength(0); i++)
            {
                for (int j = 0; j < bordGame.GetLength(1); j++)
                {
                    if (bordGame[i, j] == 0)
                    {
                        boardImages[i, j] = new PictureBox();
                        boardImages[i, j].Image = Image.FromFile(@"pic/dot2.png");
                        boardImages[i, j].Location = new Point(xpos +5 , ypos +5);
                        boardImages[i, j].Size = new Size(10, 10);
                        boardImages[i, j].SizeMode = PictureBoxSizeMode.Zoom;


                    }
                    if (bordGame[i, j] == 1)
                    {
                        boardImages[i, j] = new PictureBox();
                        boardImages[i, j].Image = Image.FromFile(@"pic/rec.png");
                        boardImages[i, j].Location = new Point(xpos, ypos);
                        boardImages[i, j].Size = new Size(20, 20);
                        boardImages[i, j].SizeMode = PictureBoxSizeMode.Zoom;

                    }
                    if (bordGame[i, j] == 2)
                    {
                        boardImages[i, j] = new PictureBox();
                        boardImages[i, j].Image = Image.FromFile(@"pic/pacRight.png");
                        boardImages[i, j].Location = new Point(xpos + 5, ypos + 5);
                        boardImages[i, j].Size = new Size(20, 20);
                        boardImages[i, j].SizeMode = PictureBoxSizeMode.Zoom;
                        PacMan = boardImages[i, j];
                    }
                    if(bordGame[i,j]==3)
                    {
                        boardImages[i, j] = new PictureBox();
                        boardImages[i, j].Image = Image.FromFile(@"pic/hole.jpg");
                        boardImages[i, j].Location = new Point(xpos + 2, ypos + 2);
                        boardImages[i, j].Size = new Size(20,20 );
                        boardImages[i, j].SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    
                    addToForm.Controls.Add(boardImages[i, j]);
                    xpos += 20;
                }
                ypos += 20;
                xpos = 0;
            }
            

        }
        public Point CalcEndBoard()
        {
            int x = 0, y = 0;
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < bordGame.GetLength(1); j++)
                {
                    if(bordGame[i,j]== 0)
                    {
                        x += 35;
                    }
                    if(bordGame[i, j] == 1)
                    {
                        x += 40;
                    }
                    if (bordGame[i, j] == 2 )
                    {
                        x += 45;
                    }
                    if (bordGame[i, j] == 3)
                    {
                        x += 42;
                    }
                }
            }
            for (int i = 0; i < bordGame.GetLength(0); i++)
            {
                for (int j = 0; j <1; j++)
                {
                    if (bordGame[i, j] == 0)
                    {
                        y += 35;
                    }
                    if (bordGame[i, j] == 1)
                    {
                        y += 40;
                    }
                    if (bordGame[i, j] == 2 )
                    {
                       y += 45;
                    }
                    if (bordGame[i, j] == 3)
                    {
                        y += 42;
                    }
                }
            }
            return new Point(x, y);
        }

        public int Move(string dir)
        {
            this.dir = dir;
            int i = PacMan.Location.X / 20;
            int j = PacMan.Location.Y / 20;
            int returning = 0;
                if(dir.Equals( "pacRight"))
                {
                    if ((bordGame.GetLength(1) > i + 1 && // check if can move right
                        bordGame[j, i + 1] != 1
                        && bordGame[j, i + 1] != 3))
                    {
                    PacMan.Image = Image.FromFile(@"pic/pacRight.png");
                    if (boardImages[j, i + 1].Visible)
                    {
                        boardImages[j, i + 1].Visible = false;
                        //if (PacMan.Location.X < this.CalcEndBoard().X)
                        
                    }
                    PacMan.Location = new Point(PacMan.Location.X + 20, PacMan.Location.Y);
                }
                    if (bordGame[j, i + 1] == 3)
                        returning=3;
                    if (bordGame[j, i + 1] == 1)
                        returning = 1;
                }
                if(dir.Equals("pacLeft"))
                {
                    if (-1 < i - 1 && // checked if can move left
                    bordGame[j, i - 1] != 1 && bordGame[j, i - 1] != 3)// check if left is not wall
                    {
                        PacMan.Image = Image.FromFile(@"pic/pacLeft.png");
                        if (boardImages[j, i - 1].Visible)
                        {
                            boardImages[j, i - 1].Visible = false;
                          
                        }
                    PacMan.Location = new Point(PacMan.Location.X - 20, PacMan.Location.Y);
                }
                if (bordGame[j, i - 1] == 3)
                    returning = 3;
                if (bordGame[j, i - 1] == 1)
                    returning = 1;
            }
                if (dir.Equals("pacDown"))
                {
                if (j + 1 < bordGame.GetLength(0) && bordGame[j + 1, i] != 1// check if up is not wall
                && bordGame[j + 1, i] != 3)
                {
                    PacMan.Image = Image.FromFile(@"pic/pacDown.png");
                    if (boardImages[j + 1, i].Visible)
                    {
                        boardImages[j + 1, i].Visible = false;

                        
                    }
                    PacMan.Location = new Point(PacMan.Location.X, PacMan.Location.Y + 20);
                }
                if (bordGame[j+1, i ] == 3)
                    returning = 3;
                if (bordGame[j + 1, i] == 1)
                    returning = 1;
            }
            if (dir.Equals("pacUp"))
            {
                if (j - 1 > -1 // check if can move up
                && bordGame[j - 1, i] != 1 && bordGame[j - 1, i] != 3)// check if up is not wall
                {
                    PacMan.Image = Image.FromFile(@"pic/pacUp.png");
                    if (boardImages[j - 1, i].Visible)
                    {
                        boardImages[j - 1, i].Visible = false;

                        //if (PacMan.Location.Y > 0)
                        
                    }
                    PacMan.Location = new Point(PacMan.Location.X, PacMan.Location.Y - 20);
                }
                if (bordGame[j-1,i] == 3)
                    returning = 3;
                if (bordGame[j - 1, i] == 1)
                    returning = 1;
            }
            return returning;
        }
       
        

    }
}
