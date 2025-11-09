using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PathfindingSimulator
{
    public class Node
    {
        private string name;
        private Color color;
        private Graphics g;
        private Rectangle r;
        private Point center;
        private SolidBrush brush;
        private List<Edge> edges = new List<Edge>();
        private bool isWall;
        private bool isStart;
        private bool isGoal;
        private float gScore;
        private float fScore;
        private Node cameFrom;
        private Color defaultColor;
        private Risk incomingRisk;

        public Node(string name, float h, Rectangle r)
        {
            this.r = r;
            this.center = new Point(r.Left + r.Width / 2, r.Top + r.Height / 2);
            this.brush = new SolidBrush(Color.White);
            this.name = name;
            this.isWall = false;
            this.isStart = false;
            this.isGoal = false;
            this.gScore = 9999f;
            this.fScore = 0f;
            this.incomingRisk = new Risk(0f);
        }

        public List<Node> GetAdjacentNodes()
        {
            List<Node> nodes = new List<Node>();
            foreach(Edge e in edges)
            {
                nodes.Add(e.TargetNode);
            }

            return nodes;
        }

        public float DistanceFromNode(Node n)
        {
            double xDelta = this.Center.X - n.Center.X;
            double yDelta = this.Center.Y - n.Center.Y;

            return Convert.ToSingle(Math.Sqrt(Math.Pow(xDelta, 2) + Math.Pow(yDelta, 2)));
        }

        /// <summary>
        /// Check if user clicks within the bounds of the rectangle
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsInBounds(Point p)
        {
            if ((p.X >= center.X - ((r.Width - 1)/2) && p.X <= center.X + ((r.Width - 1) / 2)) && p.Y >= center.Y - ((r.Height - 1) / 2) && p.Y <= center.Y + ((r.Height - 1) / 2))
            {
                return true;
            }

            return false;
        }

        public int NameInt
        {
            get { return this.name[0]; }
        }

        /// <summary>
        /// Gets or sets the name of the node
        /// </summary>
        public int NameVal
        {
            get
            {
                if (this.name.Length > 2)
                {
                    return Int32.Parse(this.name.Substring(this.name.Length - 2));
                }
                else
                {
                    return Int32.Parse(this.name[1].ToString());
                }
            }
        }

        public Node CameFrom
        {
            get { return this.cameFrom; }
            set { this.cameFrom = value; }
        }

        public Color Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public SolidBrush Brush
        {
            get
            {
                this.brush = new SolidBrush(Color);
                return this.brush;
            }
        }

        public Rectangle Rectangle
        {
            get { return this.r; }
            set { this.r = value; }
        }

        public Point Center
        {
            get { return this.center; }
            set { this.center = value; }
        }

        public List<Edge> Edges
        {
            get { return edges; }
            set { this.edges = value; }
        }

        public bool IsWall
        {
            get { return isWall; }
            set { this.isWall = value; }
        }

        public bool IsStart
        {
            get { return isStart; }
            set { this.isStart = value; }
        }

        public bool IsGoal
        {
            get { return isGoal; }
            set { this.isGoal = value; }
        }

        public float GScore
        {
            get { return gScore; }
            set { this.gScore = value; }
        }

        public float FScore
        {
            get { return fScore; }
            set { this.fScore = value; }
        }

        public Color DefaultColor
        {
            get
            {
                if(this.defaultColor == null)
                {
                    return default(Color);
                }
                else
                {
                    return this.defaultColor;
                }
            }
            set { this.defaultColor = value; }
        }

        public void SetRisks(float risk)
        {
            foreach(Edge e in Edges)
            {
                e.Risk.RiskVal = risk;
            }
        }

        public Risk IncomingRisk
        {
            get { return this.incomingRisk; }
            set { this.incomingRisk = value;  }
        }

    }
}
