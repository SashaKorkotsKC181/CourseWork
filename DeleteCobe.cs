using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class DeleteCode : IComparable<DeleteCode>
    {
        int x;
        int y;
        public DeleteCode(int x_, int y_)
        {
            x = x_;
            y = y_;
        }
        public int CompareTo(DeleteCode that)
        {
            if (y != that.y)
                return y.CompareTo(that.y);
            else return x.CompareTo(that.x);
        }
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
    }
}
