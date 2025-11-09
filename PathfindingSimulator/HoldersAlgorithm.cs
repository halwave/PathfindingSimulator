using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PathfindingSimulator
{
    public class HoldersAlgorithm:Algorithm
    {
        private Node startNode;
        private Node goalNode;
        private float pVal = 0.0f;
        private float tempRisk = 0.0f;

        public HoldersAlgorithm(Node startNode, Node goalNode, float pVal)
        {
            this.startNode = startNode;
            this.goalNode = goalNode;
            this.pVal = pVal;
            this.expandedNodes = new List<Node>();
        }

        public override List<Node> RunAlgorithm(Node startNode, Node goalNode, float pVal)
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

                    if (!openList.Contains(neighbour))
                    {
                        openList.Add(neighbour);
                    }

                    tempRisk = CalcRisk(currentNode);
                    tentativeScore = (currentNode.GScore + currentNode.DistanceFromNode(neighbour)) * (tempRisk * pVal + 1);
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

        private float CalcRisk(Node current)
        {
            Node c = current;
            float r = c.IncomingRisk.RiskVal;
            while (c.CameFrom != null)
            {
                r = r * (1 - c.CameFrom.IncomingRisk.RiskVal);
                c = c.CameFrom;
            }

            if(current.CameFrom == null)
            {
                return current.IncomingRisk.RiskVal;
            }
            else
            {
                return r + CalcRisk(current.CameFrom);
            }
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

        public override List<Node> RunAlgorithm(Node startNode, Node goalNode)
        {
            throw new NotImplementedException();
        }
    }
}
