using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CourseWork
{
    abstract class Figure
    {
        protected int x;
        protected int y;
        protected int[,] matrix;
        abstract public void Scroll();
        abstract public void Rotay(int[,] map_);
        abstract public void Rotate();
        protected Bitmap[] cobeColors = new Bitmap[] { Resource.Blue, Resource.Blue, Resource.Green, Resource.Pink, Resource.Purple, Resource.Red, Resource.Yellow };
        protected Bitmap[] cobeColorsCurrentFigure;
        protected Point leftUpPointOfMap;
        protected int side;
        public void Draw(ref Graphics graf, int i, int j, int color_)
        {
            graf.DrawImage(cobeColors[color_], (leftUpPointOfMap.X + i * side), (leftUpPointOfMap.Y + j * side), side, side);
        }
        public void DrawCurrentFigure(ref Graphics graf, int i, int j, int color_)
        {
            graf.DrawImage(cobeColorsCurrentFigure[color_], (leftUpPointOfMap.X + i * side), (leftUpPointOfMap.Y + j * side), side, side);
        }
        public  void HideDrawing(ref Graphics graf, int i , int j)
        {
            graf.DrawImage(Resource.White, (leftUpPointOfMap.X + i * side), (leftUpPointOfMap.Y + j * side), side, side);
        }
        public void Resize(int side_, Point leftUpPointOfWorkspace_)
        {
            leftUpPointOfMap = new Point(leftUpPointOfWorkspace_.X, leftUpPointOfWorkspace_.Y - 3 * side_);
            side = side_;
        }
        public void MoveRight(int[,] map_)
        {
            if (CheckMoveRight(map_))
                x++;
        }
        public void MoveLeft(int[,] map_)
        {
            if (CheckMoveLeft(map_))
                x--;
        }
        public void MoveDown()
        {
            y++;
        }

        public int[,] GetMatrix
        {
            get { return matrix; }
        }

        public int GetX
        {
            get { return x; }
        }

        public int GetY
        {
            get { return y; }
        }

        public bool CheckMoveRight(int[,] map_)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (x + 1 + i >= map_.GetLength(0) || map_[x + 1 + i, y + j] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckMoveLeft(int[,] map_)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (x - 1 + i < 0 || map_[x - 1 + i, y + j] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool CheckMoveDown(int[,] map_)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (y + matrix.GetLength(1) >= map_.GetLength(1) || map_[x + i, y + matrix.GetLength(1)] != 0)
                {                    
                    return false;
                }

            return true;
        }

    }
}
