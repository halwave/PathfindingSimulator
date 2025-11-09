using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PathfindingSimulator
{
    public class DijkstraAlgorithm:Algorithm
    {
        private Node startNode;
        private Node goalNode;

        public DijkstraAlgorithm(Node startNode, Node goalNode)
        {
            this.startNode = startNode;
            this.goalNode = goalNode;
            this.expandedNodes = new List<Node>();
        }

        public override List<Node> RunAlgorithm(Node startNode, Node goalNode)
        {
            List<Node> closedList = new List<Node>();
            List<Node> openList = new List<Node>();
            List<Node> exploringNodes = new List<Node>();
            Node currentNode;
            float tentativeScore = 0f;

            openList.Add(startNode);

            startNode.GScore = 0;

            while (openList.Count != 0)
            {
                currentNode = GetSmallestDist(openList);
                if (currentNode == goalNode)
                {
                    this.expandedNodes = closedList;
                    return ReconstructPath(currentNode.CameFrom, currentNode);
                }

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                foreach (Node neighbour in currentNode.GetAdjacentNodes())
                {

                    if (closedList.Contains(neighbour))
                    {
                        continue;
                    }

                    if(!openList.Contains(neighbour))
                    {
                        openList.Add(neighbour);
                    }

                    tentativeScore = currentNode.GScore + currentNode.DistanceFromNode(neighbour);
                    if (tentativeScore < neighbour.GScore)
                    {
                        neighbour.GScore = tentativeScore;
                        neighbour.CameFrom = currentNode;
                    }
                    totalOperations++;
                }
            }
            return null;

        }

        public override Node GetSmallestDist(List<Node> nodes)
        {
            Node tempNode = nodes[0];

            foreach (Node n in nodes)
            {
                if (n.GScore < tempNode.GScore)
                {
                    tempNode = n;
                }
            }

            return tempNode;
        }

        public override List<Node> RunAlgorithm(Node startNode, Node goalNode, float pVal)
        {
            throw new NotImplementedException();
        }
    }
}
