using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingSimulator
{
    public class Edge
    {
        Line line;
        Node targetNode;
        Risk risk;
        float edgeWeight;

        public Edge(Node targetNode, float edgeWeight)
        {
            this.targetNode = targetNode;
            this.edgeWeight = edgeWeight;
            this.risk = new Risk(0f); ;
            //this.line = new Line(targetNode.Center);
        }

        public Node TargetNode
        {
            get { return this.targetNode; }
            set { this.targetNode = value; }
        }

        public Risk Risk
        {
            get { return this.risk; }
            set { this.risk = value; }
        }
    }
}
