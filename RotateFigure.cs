using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CourseWork
{
    class RotateFigure : Figure
    {
        bool horizontal;
        public RotateFigure(int[,] map_, int side_, Point leftUpPointOfWorkspace_)
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
        }
        public RotateFigure(RotateFigure that)
        {
            x = this.x;
            y = this.y;
            matrix = that.matrix;
        }

        public override void Scroll()
        {
            matrix = new int[1, 3] 
            {
                {matrix[0, 1], matrix[0, 2], matrix[0, 0]}
            };
        }
        public override void Rotay(int[,] map_)
        {

        }
        public override void Rotate()
        {
            matrix = new int[1, 3] 
            {
                {matrix[0, 2], matrix[0, 1], matrix[0, 0]}
            };
        }
        public override string ToString()
        {
            return "\"E\" can rotate\ncurrent figure";
        }
    }
}
