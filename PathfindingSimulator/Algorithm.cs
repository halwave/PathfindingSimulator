using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingSimulator
{
    public abstract class Algorithm
    {
        protected List<Node> expandedNodes;
        protected int totalOperations = 0;

        public abstract List<Node> RunAlgorithm(Node startNode, Node goalNode);

        public abstract List<Node> RunAlgorithm(Node startNode, Node goalNode, float pVal);

        public abstract Node GetSmallestDist(List<Node> nodes);

        protected static List<Node> ReconstructPath(Node cameFrom, Node currentNode)
        {
            List<Node> totalPath = new List<Node>();
            totalPath.Add(currentNode);
            while (currentNode.CameFrom == cameFrom && currentNode.CameFrom != null)
            {
                currentNode = currentNode.CameFrom;
                cameFrom = currentNode.CameFrom;
                totalPath.Add(currentNode);
            }

            return totalPath;
        }

        public List<Node> ExpandedNodes
        {
            get { return this.expandedNodes; }
        }

        public int TotalOperations
        {
            get { return this.totalOperations; }
        }
    }
}
