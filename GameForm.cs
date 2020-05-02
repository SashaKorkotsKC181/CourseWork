using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class GameForm : Form
    {
        Figure currentFigure;
        Figure nextFigure;
        Point center;
        Point leftUpPointOfMap;       
        int numberOfCobsDownInPictureBox = 4;
        int numberOfCobsDownSide = 6;
        int numberOfCobsLeftSide = 12;
        int score;
        int speed;
        int cobeSide;
        int[,] map;
        int forDestrou;
        bool gameOver;
        bool stop;
        bool moveLeft;
        bool moveRight;
        SortedSet<DeleteCode> destrou;
        int level;
        public GameForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            Load += GameForm_Load;
            timer.Tick += new EventHandler(NewFrame);
            Paint += GameForm_Paint;
            Resize += GameForm_Resize;
            moveDownTimer.Tick += moveDownTimer_Tick;
            KeyUp += GameForm_KeyUp;
            KeyDown += GameForm_KeyDown;
            timerForDestrou.Tick += timerForDestrou_Tick;         
            pauseToolStripMenuItem.Click += pauseToolStripMenuItem_Click;
            restartToolStripMenuItem.Click += restartToolStripMenuItem_Click;
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            timerForMoveLeftRight.Tick += timerForMoveLeftRight_Tick;

        }

        void timerForMoveLeftRight_Tick(object sender, EventArgs e)
        {
            if (moveLeft == true)
            {
                CleanCurrentFigure();
                currentFigure.MoveLeft(map);
                DrawCurrentFigure();
            }
            if (moveRight == true)
            {
                CleanCurrentFigure();
                currentFigure.MoveRight(map);
                DrawCurrentFigure();
            } 

        }

        void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (moveDownTimer.Enabled && forDestrou == 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        moveLeft = false;
                        
                        break;
                    case Keys.Right:
                        moveRight = false;
                        
                        break;
                    case Keys.Up:
                        CleanCurrentFigure();
                        currentFigure.Scroll();
                        DrawCurrentFigure();
                        break;
                    case Keys.R:
                        CleanCurrentFigure();
                        currentFigure.Rotay(map);
                        DrawCurrentFigure();
                        break;
                    case Keys.E:
                        CleanCurrentFigure();
                        currentFigure.Rotate();
                        DrawCurrentFigure();
                        break;
                }
            }
            if (e.KeyCode == Keys.Down)
                moveDownTimer.Interval = speed;

        }

        void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (moveDownTimer.Enabled && forDestrou == 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        moveDownTimer.Interval = speed / 10;
                        break;
                    case Keys.Left:
                        if (!moveLeft)
                        {
                            CleanCurrentFigure();
                            currentFigure.MoveLeft(map);
                            DrawCurrentFigure();
                        }   
                        moveLeft = true;
                        break;
                    case Keys.Right:
                        if (!moveRight)
                        {
                            CleanCurrentFigure();
                            currentFigure.MoveRight(map);
                            DrawCurrentFigure();
                        }
                        moveRight = true;
                        break;

                }
            }

        }

        void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restart();
        }

        void timerForDestrou_Tick(object sender, EventArgs e)
        {
            if (!stop && !gameOver)
            {
                
                if (forDestrou == 2)
                {
                    FindEqualCobesInDestrou();
                    score += destrou.Count();
                    forDestrou++;
                }
                if (destrou.Count() == 0)
                    forDestrou = 8;
                else if (forDestrou == 6)
                {
                    DestrouAndMoveCobes(destrou, ref map);
                    forDestrou = 2;
                }
                else if (forDestrou != 6)
                    forDestrou++;
            }
        }

        void GameForm_Load(object sender, EventArgs e)
        {
            Restart();
        }

        void GameForm_Resize(object sender, EventArgs e)
        {
            LocationOfItems();
        }

        void GameForm_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawCobes(e.Graphics);
            CleanDestrou(e.Graphics);                
        }

        void moveDownTimer_Tick(object sender, EventArgs e)
        {
            if (!stop && !gameOver)
            {
                if (forDestrou == 8)
                {
                    GameOver();
                    if (!gameOver)
                    {
                        currentFigure = nextFigure;
                        nextFigure = CreateFigure(map);
                    }
                    forDestrou = 0;                    
                }
                if (currentFigure.CheckMoveDown(map))
                {
                    CleanCurrentFigure();
                    currentFigure.MoveDown();
                    DrawCurrentFigure();
                }
                else
                {
                    MoveCobes();
                    FindEqualCobesInCorrentFigure();
                    score += destrou.Count();
                    if (destrou.Count() == 0) forDestrou = 8;
                    else forDestrou = 3;
                    moveLeft = false;
                    moveRight = false;
                }
            }
        }

        void NewFrame(object sender, EventArgs e)
        {
            Refresh();
            labelR.Text = currentFigure.ToString();
            scoreLabel.Text = score.ToString();
            levelLabel.Text = level.ToString();
            if (score >= level * 50)
            {
                level++;
                speed -= 50;
                moveDownTimer.Interval = speed;                
                
            }
            if (!stop && !gameOver)
            {
                if (forDestrou == 3)
                {
                    moveDownTimer.Enabled = false;
                    timerForDestrou.Enabled = true;
                }
                else if (forDestrou == 8)
                {

                    moveDownTimer.Enabled = true;
                    timerForDestrou.Enabled = false;
                }
            }
            if (gameOver)
            {
                gameoverLabel.Visible = true;
                pauseToolStripMenuItem.Enabled = false;
            }
            else pauseToolStripMenuItem.Enabled = true;
            if (moveLeft || moveRight) timerForMoveLeftRight.Enabled = true;
            else timerForMoveLeftRight.Enabled = false;
        }

        void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stop = !stop;
            if (stop)
            {
                pauseToolStripMenuItem.Text = "Start";
            }
            else
            {
                pauseToolStripMenuItem.Text = "Pause";
            }
        }

        private void DrawCobes(Graphics graf)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 3; j < map.GetLength(1); j++)
                {
                    if (map[i, j] != 0)
                        currentFigure.Draw(ref graf, i, j, map[i, j]);
                }
            }
        }

        private void DrawGrid(Graphics graf)
        {
            Point k = new Point ( leftUpPointOfMap.X + (numberOfCobsDownSide + 1) * cobeSide, leftUpPointOfMap.Y + 1 * cobeSide);
            graf.FillRectangle(Brushes.White,k.X,k.Y, nextFigure.GetMatrix.GetLength(0) * cobeSide, nextFigure.GetMatrix.GetLength(1) * cobeSide);
            for (int i = 0; i < nextFigure.GetMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < nextFigure.GetMatrix.GetLength(1); j++)
                {
                    //map[numberOfCobsDownSide + i, currentFigure.GetY + j] = currentFigure.GetMatrix[i, j];
                    currentFigure.Draw(ref graf, numberOfCobsDownSide + i + 1, j + 4, nextFigure.GetMatrix[i, j]);
                }
            }



            graf.FillRectangle(Brushes.White, leftUpPointOfMap.X, leftUpPointOfMap.Y, numberOfCobsDownSide * cobeSide, numberOfCobsLeftSide * cobeSide); 
            for (int i = 1; i <= map.GetLength(0); i++)
            {
                graf.DrawLine(Pens.LightGray, new Point(leftUpPointOfMap.X + i * cobeSide, leftUpPointOfMap.Y), new Point(leftUpPointOfMap.X + i * cobeSide, leftUpPointOfMap.Y + numberOfCobsLeftSide * cobeSide));
            }
            for (int i = 1; i <= map.GetLength(1) - 3; i++)
            {
                graf.DrawLine(Pens.LightGray, new Point(leftUpPointOfMap.X, leftUpPointOfMap.Y + i * cobeSide), new Point(leftUpPointOfMap.X + numberOfCobsDownSide * cobeSide, leftUpPointOfMap.Y + i * cobeSide));
            }
             
        }        

        private int WhatCobeSide()
        {
            if (this.DisplayRectangle.Height - MenuOfForm.Height > this.DisplayRectangle.Width)
                return this.DisplayRectangle.Width / (numberOfCobsDownInPictureBox * 2 + numberOfCobsDownSide);
            else
                return (this.DisplayRectangle.Height - MenuOfForm.Height) / numberOfCobsLeftSide;                        
        }

        private void DrawCurrentFigure()
        {
            for (int i = 0; i < currentFigure.GetMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < currentFigure.GetMatrix.GetLength(1); j++)
                {
                    map[currentFigure.GetX + i, currentFigure.GetY + j] = currentFigure.GetMatrix[i, j];
                }

            }
        }

        private void CleanCurrentFigure()
        {
            for (int i = 0; i < currentFigure.GetMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < currentFigure.GetMatrix.GetLength(1); j++)
                {
                    if (currentFigure.GetY + j >= 0)
                        map[currentFigure.GetX + i, currentFigure.GetY + j] = 0;
                }
            }
        }

        private void FindEqualCobesInCorrentFigure()
        {            
            for (int i = 0; i < currentFigure.GetMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < currentFigure.GetMatrix.GetLength(1); j++)
                {
                    FindEqualCobes(currentFigure.GetX + i, currentFigure.GetY + j, ref destrou);
                }
            }            
        }

        private void FindEqualCobesInDestrou()
        {
            List<DeleteCode> list = new List<DeleteCode>();            
            foreach (DeleteCode i in destrou)
                list.Add(i);           
            destrou.Clear();
            foreach(DeleteCode i in list)
                FindEqualCobes(i.GetX, i.GetY, ref destrou);
                      
        }
            
        private bool FindEqualCobes(int x, int y, ref SortedSet<DeleteCode> destrou)
        {
            if (map[x, y] == 0)
                return false;
            SortedSet<DeleteCode> verticalDestrou = new SortedSet<DeleteCode>();
            SortedSet<DeleteCode> horizontalDestrou = new SortedSet<DeleteCode>();
            SortedSet<DeleteCode> lDiagonalDestrou = new SortedSet<DeleteCode>();
            SortedSet<DeleteCode> rDiagonalDestrou = new SortedSet<DeleteCode>();

            bool b = false;
            bool[] v = { true, true };
            bool[] h = { true, true };
            bool[] ld = { true, true };
            bool[] rd = { true, true };

            for (int i = 1; v[0] || v[1] || h[0] || h[1] || ld[0] || ld[1] || rd[0] || rd[1]; i++)
            {
                if (v[0] && x + i < map.GetLength(0) && map[x + i, y] == map[x, y])
                    verticalDestrou.Add(new DeleteCode(x + i, y));
                else v[0] = false;
                if (v[1] && x - i >= 0 && map[x - i, y] == map[x, y])
                    verticalDestrou.Add(new DeleteCode(x - i, y));
                else v[1] = false;
                if (h[0] && y + i < map.GetLength(1) && map[x, y + i] == map[x, y])
                    horizontalDestrou.Add(new DeleteCode(x, y + i));
                else h[0] = false;
                if (h[1] && y - i >= 0 && map[x, y - i] == map[x, y])
                    horizontalDestrou.Add(new DeleteCode(x, y - i));
                else h[1] = false;
                if (ld[0] && x - i >= 0 && y - i >= 0 && map[x - i, y - i] == map[x, y])
                    lDiagonalDestrou.Add(new DeleteCode(x - i, y - i));
                else ld[0] = false;
                if (ld[1] && x + i < map.GetLength(0) && y + i < map.GetLength(1) && map[x + i, y + i] == map[x, y])
                    lDiagonalDestrou.Add(new DeleteCode(x + i, y + i));
                else ld[1] = false;
                if (rd[0] &&  x + i < map.GetLength(0) && y - i >= 0 && map[x + i, y - i] == map[x, y])
                    rDiagonalDestrou.Add(new DeleteCode(x + i, y - i));
                else rd[0] = false;
                if (rd[1] && x - i >= 0 && y + i < map.GetLength(1) && map[x - i, y + i] == map[x, y])
                    rDiagonalDestrou.Add(new DeleteCode(x - i, y + i));
                else rd[1] = false;
            }
            if (verticalDestrou.Count() >= 2)
            {
                DestrouAdd(verticalDestrou);
                b = true;
            }
            if (horizontalDestrou.Count() >= 2)
            {
                DestrouAdd(horizontalDestrou);
                b = true;
            }
            if (lDiagonalDestrou.Count() >= 2)
            {
                DestrouAdd(lDiagonalDestrou);
                b = true;
            }
            if (rDiagonalDestrou.Count() >= 2)
            {
                DestrouAdd(rDiagonalDestrou);
                b = true;
            }
            if (b)
            {
                destrou.Add(new DeleteCode(x, y));
                return true;
            }
            return false;
        }

        private void DestrouAdd(SortedSet<DeleteCode> mas)
        {
            foreach (DeleteCode i in mas)
                destrou.Add(i);
        }

        private void DestrouAndMoveCobes(SortedSet<DeleteCode> destrou, ref int[,] map)
        {
            SortedSet<DeleteCode> set = new SortedSet<DeleteCode>();
            foreach (DeleteCode i in destrou)
            {
                for (int j = i.GetY; j - 1 >= 0; j--)
                {
                    map[i.GetX, j] = map[i.GetX, j - 1];
                    set.Add(new DeleteCode(i.GetX, j));
                }
            }
            DestrouAdd(set);
        }

        private void MoveCobes()
        {
            for (int i = 0; i < currentFigure.GetMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < currentFigure.GetMatrix.GetLength(1); j++)
                {
                    if (currentFigure.GetY + j + 1 < map.GetLength(1) && map[currentFigure.GetX + i, currentFigure.GetY + j + 1] == 0)
                    {
                        int k = 0;
                        for (; currentFigure.GetX + i < map.GetLength(0) && currentFigure.GetY + j + 1 + k < map.GetLength(1) && map[currentFigure.GetX + i, currentFigure.GetY + j + 1 + k] == 0; k++)
                        {

                        }
                        map[currentFigure.GetX + i, currentFigure.GetY + j + k] = map[currentFigure.GetX + i, currentFigure.GetY + j];
                        map[currentFigure.GetX + i, currentFigure.GetY + j] = 0;
                    }
                }
            }
        }

        private void CleanDestrou(Graphics graf)
        {
            if (forDestrou == 4 || forDestrou == 6)
            {
                foreach (DeleteCode item in destrou)
                {
                    currentFigure.HideDrawing(ref graf, item.GetX, item.GetY);
                }
                
            }
        }

        private void GameOver()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                if (map[i, 3] > 0) gameOver = true; 
            }
        }

        private Figure CreateFigure(int[,] map)
        {
            Random r = new Random();
            int number = r.Next(0, 21);
            if (number < 15)
            {
                return new StandardFigure(map, cobeSide, leftUpPointOfMap);
            }
            else if (number > 19)
            {
                return new RotaryFigure(map, cobeSide, leftUpPointOfMap);                
            }
            else
                return new RotateFigure(map, cobeSide, leftUpPointOfMap);
        }

        private void Restart()
        {
            
            timer.Enabled = true;
            moveDownTimer.Enabled = false;
            timerForDestrou.Enabled = false;
            destrou = new SortedSet<DeleteCode>();
            numberOfCobsDownInPictureBox = 4;
            numberOfCobsDownSide = 6;
            numberOfCobsLeftSide = 12;
            map = new int[numberOfCobsDownSide, numberOfCobsLeftSide + 3];
            currentFigure = CreateFigure(map);
            nextFigure = CreateFigure(map);
            LocationOfItems();
            speed = 500;
            moveDownTimer.Interval = speed;
            timerForMoveLeftRight.Interval = speed / 5;
            timerForDestrou.Interval = 500;
            //cobeSide = WhatCobeSide();
            // щоб фігурка плавно появлявся
               
            //center = new Point(this.DisplayRectangle.Width / 2, MenuOfForm.Height + (this.DisplayRectangle.Height - MenuOfForm.Height) / 2);
            //leftUpPointOfMap = new Point(center.X - numberOfCobsDownSide / 2 * cobeSide, (center.Y - numberOfCobsLeftSide / 2 * cobeSide));
            //currentFigure.Resize(cobeSide, leftUpPointOfMap);
            //scoreLabel.Location = new Point(leftUpPointOfMap.X + (numberOfCobsDownSide + 1) * cobeSide, leftUpPointOfMap.Y + 6 * cobeSide);
            //scoreLabel.Font = new Font(scoreLabel.Font.Name, (float)(cobeSide / 1.5), scoreLabel.Font.Style);
            //levelLabel.Location = new Point(scoreLabel.Location.X, scoreLabel.Location.Y + 2 * cobeSide);
            //levelLabel.Font = scoreLabel.Font;
            //gameoverLabel.Location = new Point(leftUpPointOfMap.X, center.Y - cobeSide / 2);
            //gameoverLabel.Size = new Size(cobeSide * numberOfCobsDownSide, cobeSide);
            //gameoverLabel.Font = new Font(scoreLabel.Font.Name, (float)(cobeSide / 1.6), scoreLabel.Font.Style);
            gameoverLabel.Visible = false;
            level = 1;
            moveDownTimer.Enabled = true;
            score = 0;
            forDestrou = 0;
            gameOver = false;
            stop = false;
            pauseToolStripMenuItem.Text = "Pause";
            //nextFigure = CreateFigure(map);
            moveLeft = false;
            moveRight = false;            
        }

        private void LocationOfItems()
        {
            cobeSide = WhatCobeSide();

            center = new Point(this.DisplayRectangle.Width / 2, MenuOfForm.Height + (this.DisplayRectangle.Height - MenuOfForm.Height) / 2);
            leftUpPointOfMap = new Point(center.X - numberOfCobsDownSide / 2 * cobeSide, (center.Y - numberOfCobsLeftSide / 2 * cobeSide));
            currentFigure.Resize(cobeSide, leftUpPointOfMap);
            nextFigure.Resize(cobeSide, leftUpPointOfMap);
            scoreLabel.Location = new Point(leftUpPointOfMap.X + (numberOfCobsDownSide + 1) * cobeSide, leftUpPointOfMap.Y + 6 * cobeSide);
            levelLabel.Location = new Point(scoreLabel.Location.X, scoreLabel.Location.Y + 2 * cobeSide);
            gameoverLabel.Location = new Point(leftUpPointOfMap.X, center.Y - cobeSide / 2);
            labelR.Location = new Point(leftUpPointOfMap.X - numberOfCobsDownInPictureBox * cobeSide - 6, leftUpPointOfMap.Y + 4 * cobeSide);
            labelInstryction.Location = new Point(leftUpPointOfMap.X - numberOfCobsDownInPictureBox * cobeSide - 6, leftUpPointOfMap.Y + cobeSide);
            labelScore.Location = new Point(scoreLabel.Location.X, scoreLabel.Location.Y - cobeSide * 2 / 3);
            labelLevel.Location = new Point(levelLabel.Location.X, levelLabel.Location.Y - cobeSide * 2 / 3);
            gameoverLabel.Size = new Size(cobeSide * numberOfCobsDownSide, cobeSide);
            try
            {
                labelLevel.Font = new Font(scoreLabel.Font.Name, (float)(cobeSide / 2.5), scoreLabel.Font.Style);
                labelScore.Font = new Font(scoreLabel.Font.Name, (float)(cobeSide / 2.5), scoreLabel.Font.Style);
                labelInstryction.Font = new Font(scoreLabel.Font.Name, (float)(cobeSide / 2.5), scoreLabel.Font.Style);
                labelR.Font = new Font(labelR.Font.Name, (float)(cobeSide / 2.5), labelR.Font.Style);
                gameoverLabel.Font = new Font(scoreLabel.Font.Name, (float)(cobeSide / 1.6), scoreLabel.Font.Style);
                scoreLabel.Font = new Font(scoreLabel.Font.Name, (float)(cobeSide / 1.5), scoreLabel.Font.Style);
                levelLabel.Font = scoreLabel.Font;
            }
            catch (Exception) { };

            Refresh();
        }

    }
}
