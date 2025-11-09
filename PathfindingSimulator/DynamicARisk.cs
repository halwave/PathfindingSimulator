using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PathfindingSimulator
{
    public class DynamicARisk:Algorithm
    {
        private Node startNode;
        private Node goalNode;
        private float pVal = 0.0f;
        private float t = 0.0f;
        private float tempRisk = 0.0f;
        private float neighbourRisk = 0.0f;

        public DynamicARisk(Node startNode, Node goalNode, float pVal)
        {
            this.startNode = startNode;
            this.goalNode = goalNode;
            this.pVal = pVal;
            this.t = 0.0f;
            this.expandedNodes = new List<Node>();
        }

        public override List<Node> RunAlgorithm(Node startNode, Node goalNode, float pVal)
        {
            List<Node> closedList = new List<Node>();
            List<Node> openList = new List<Node>();
            List<Node> exploringNodes = new List<Node>();
            Node currentNode;
            float tentativeScore = 0f;

            startNode.GScore = 0;
            startNode.FScore = GetHeuristic(startNode, goalNode);       //fscore := actual distance[n] + w(h,v)
            startNode.SetRisks(0.0f);

            openList.Add(startNode);

            while (openList.Count != 0)
            {
                currentNode = GetSmallestF(openList);
                if (currentNode == goalNode)
                {
                    this.expandedNodes = closedList;
                    return ReconstructPath(currentNode.CameFrom, currentNode);
                }

                //Expand
                openList.Remove(currentNode);
                closedList.Add(currentNode);

                foreach (Node neighbour in currentNode.GetAdjacentNodes())
                {

                    if (closedList.Contains(neighbour))
                    {
                        continue;
                    }

                    if (!openList.Contains(neighbour))
                    {
                        openList.Add(neighbour);
                    }

                    tempRisk = CalcRisk(currentNode);
                    tentativeScore = ((pVal * currentNode.GScore) + ((1 - pVal) * tempRisk)) + currentNode.DistanceFromNode(neighbour) ; // + estimated risk?
                    neighbourRisk = CalcRisk(neighbour);
                    if (tentativeScore >= ((pVal * neighbour.GScore) + (1 - pVal) * neighbourRisk))
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

        private float CalcRisk(Node current)
        {
            Node c = current;
            float r = c.IncomingRisk.RiskAtTime(current.GScore);
            while (c.CameFrom != null)
            {
                r = r * (1 - c.CameFrom.IncomingRisk.RiskAtTime(c.CameFrom.GScore));
                c = c.CameFrom;
            }

            if (current.CameFrom == null)
            {
                return current.IncomingRisk.RiskAtTime(current.GScore);
            }
            else
            {
                return r + CalcRisk(current.CameFrom);
            }
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

        public override List<Node> RunAlgorithm(Node startNode, Node goalNode)
        {
            throw new NotImplementedException();
        }

        public override Node GetSmallestDist(List<Node> nodes)
        {
            throw new NotImplementedException();
        }
    }
}
