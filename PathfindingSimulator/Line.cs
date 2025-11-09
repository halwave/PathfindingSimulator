using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PathfindingSimulator
{
    public class Line
    {
        private Point p1;
        private Point p2;

        public Line(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public Point Point1
        {
            get { return p1; }
            set { this.p1 = value; }
        }

        public Point Point2
        {
            get { return p2; }
            set { this.p2 = value; }
        }

    }
}
