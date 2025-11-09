using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PathfindingSimulator
{
    public class AStarSearch:Algorithm
    {
        private Node startNode;
        private Node goalNode;

        public AStarSearch(Node startNode, Node goalNode)
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

            startNode.GScore = 0;
            startNode.FScore = GetHeuristic(startNode, goalNode);

            openList.Add(startNode);

            while (openList.Count != 0)
            {
                currentNode = GetSmallestF(openList);
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
                    if (tentativeScore >= neighbour.GScore)
                    {
                        continue;
                    }

                    neighbour.CameFrom = currentNode;
                    neighbour.GScore = tentativeScore;
                    neighbour.FScore = neighbour.GScore + GetHeuristic(neighbour, goalNode);
                    totalOperations++;
                }
            }
            return null;

        }

        public static float GetHeuristic(Node currentNode, Node goalNode)
        {
            Point p1 = goalNode.Center;
            Point p2 = currentNode.Center;

            return Convert.ToSingle(Math.Sqrt(Convert.ToDouble(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2))));
        }

        public static Node GetSmallestF(List<Node> nodes)
        {
            Node tempNode = nodes[0];

            foreach (Node n in nodes)
            {
                if (n.FScore < tempNode.FScore)
                {
                    tempNode = n;
                }
            }

            return tempNode;
        }

        public static float GetF(Node goalNode, Node n)
        {
            return n.GScore + GetHeuristic(n, goalNode);
        }

        public override Node GetSmallestDist(List<Node> nodes)
        {
            throw new NotImplementedException();
        }

        public override List<Node> RunAlgorithm(Node startNode, Node goalNode, float pVal)
        {
            throw new NotImplementedException();
        }
    }
}
