using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CourseWork
{
    class RotaryFigure: Figure
    {
        bool horizontal;
        public RotaryFigure(int[,] map_, int side_, Point leftUpPointOfWorkspace_)
        {
            Random rand = new Random();
            x = rand.Next(0, map_.GetLength(0) - 1);
            y = 0;
            matrix = new int[1, 3]
            {
                {rand.Next(1, 6), rand.Next(1, 6), rand.Next(1, 6)},
            };            
            leftUpPointOfMap = new Point(leftUpPointOfWorkspace_.X, leftUpPointOfWorkspace_.Y - 3 * side_);
            side = side_;
            cobeColorsCurrentFigure = new Bitmap[] { Resource.BlueRotary, Resource.BlueRotary, Resource.GreenRotary, Resource.PinkRotary, Resource.PurpleRotary, Resource.RedRotary, Resource.YellowRotary };
        }
        public RotaryFigure(RotaryFigure that)
        {
            x = this.x;
            y = this.y;
            matrix = that.matrix;
        }

        public override void Scroll()
        {
            if (horizontal)
            {
                matrix = new int[3, 1] 
                {
                    {matrix[2, 0]}, 
                    {matrix[0, 0]}, 
                    {matrix[1, 0]}
                };
                horizontal = true;
            }
            else
            {
                matrix = new int[1, 3] 
                {
                    {matrix[0, 2], matrix[0, 0], matrix[0, 1]}
                };
                horizontal = false;
            }
        }

        public override void Rotay(int[,] map_)
        {
            if (!horizontal && CheckMoveLeft(map_) && CheckMoveRight(map_) && CheckMoveDown(map_))
            {
                matrix = new int[3, 1] 
            {
                {matrix[0, 0]}, 
                {matrix[0, 1]}, 
                {matrix[0, 2]}
            };
                horizontal = true;                    
                x--;
                y++;
            }
            else if (horizontal)
            {
                matrix = new int[1, 3] 
            {
                {matrix[0, 0], matrix[1, 0], matrix[2, 0]}
            };
                horizontal = false;
                x++;
                y--;
            }
        }
        public override void Rotate()
        {

        }
        public override string ToString()
        {
            return "\"R\" make\nhorizontal\ncurrent figure";
        }
    }
}
