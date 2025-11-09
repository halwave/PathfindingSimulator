using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace PathfindingSimulator
{
    public partial class frmMain : Form
    {
        private const string ALG_DIJKSTRA = "Dijkstra";
        private const string ALG_ASTAR = "A* Search";
        private const string ALG_HOLDER = "Holder";
        private const string ALG_ATSTAR = "A(t)*";

        private Node[,] nodes;
        private Pen borderPen = new Pen(Color.Black);
        private Node lastNode;          //for setting manual obstacles
        private Node startNode;
        private Node goalNode;

        private List<Node> pathList = new List<Node>();
        private List<Node> expandedNodes = new List<Node>();

        private const int DEFAULT_DIMENSION = 49;

        private string rawMapData = string.Empty;
        private string selectedAlgorithm = string.Empty;
        private bool showEdges = false;
        private float prefVal = 0.0f;
        private float minRisk = 1f;
        bool cancelProcessing = false;

        public frmMain()
        {
            InitializeComponent();
            LoadNodes(DEFAULT_DIMENSION, DEFAULT_DIMENSION);
            SetAdjacentNodes();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel1.MouseClick += new MouseEventHandler(panel1_OnClick);
            panel1.MouseMove += new MouseEventHandler(panel1_OnMove);
        }

        private void panel1_OnMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ColorPanel(e);   
            }
        }

        private void LoadNodes(int firDimension, int secDimension)
        {
            int tempInt = 0;
            int tempVal = 1;
            string tempName = "";

            int nodeSize = 8;

            if(firDimension >= 8 && firDimension <= 15)
            {
                nodeSize = 32;
            }
            else if(firDimension >= 16 && firDimension <= 23)
            {
                nodeSize = 28;
            }
            else if (firDimension >= 24 && firDimension <= 31)
            {
                nodeSize = 24;
            }
            else if (firDimension >= 32 && firDimension <= 39)
            {
                nodeSize = 20;
            }
            else if (firDimension >= 40 && firDimension <= 45)
            {
                nodeSize = 16;
            }
            else if (firDimension >= 46 && firDimension <= 49)
            {
                nodeSize = 12;
            }
            else if (firDimension >= 50 && firDimension <= 128)
            {
                nodeSize = 8;
            }
            else
            {
                nodeSize = 4;
            }

            nodes = new Node[firDimension, secDimension];

            for (int i = 0; i < firDimension; i++)
            {
                for (int j = 0; j < secDimension; j++)
                {
                    tempName = tempInt.ToString() + tempVal.ToString();
                    nodes[i, j] = (new Node(tempName, 1, new Rectangle(j * nodeSize, i * nodeSize, nodeSize, nodeSize)));
                    tempVal++;
                }
                tempInt++;
                tempVal = 1;
            }
        }

        private void SetAdjacentNodes(bool diagonal = false)
        {
            for (int i = 0; i < nodes.GetLength(0); i++)
            {
                for (int j = 0; j < nodes.GetLength(1); j++)
                {
                    nodes[i, j].Edges.Clear();

                    //Left
                    if (i - 1 >= 0 && !nodes[i - 1, j].IsWall)
                    {
                        nodes[i, j].Edges.Add(new Edge(nodes[i - 1, j], 1));
                    }

                    //Right
                    if (i + 1 < nodes.GetLength(0) && !nodes[i + 1, j].IsWall)
                    {
                        nodes[i, j].Edges.Add(new Edge(nodes[i + 1, j], 1));
                    }

                    //Top
                    if (j - 1 >= 0 && !nodes[i, j - 1].IsWall)
                    {
                        nodes[i, j].Edges.Add(new Edge(nodes[i, j - 1], 1));
                    }

                    //Bottom
                    if (j + 1 < nodes.GetLength(1) && !nodes[i, j + 1].IsWall)
                    {
                        nodes[i, j].Edges.Add(new Edge(nodes[i, j + 1], 1));
                    }

                    if (!diagonal)
                        continue;

                    //Top Left
                    if (i - 1 >= 0 && j - 1 >= 0 && !nodes[i - 1, j].IsWall && !nodes[i, j - 1].IsWall)
                    {
                        nodes[i, j].Edges.Add(new Edge(nodes[i - 1, j - 1], 1));
                    }

                    //Top Right
                    if (i + 1 < nodes.GetLength(0) && j - 1 >= 0 && !nodes[i + 1, j].IsWall && !nodes[i, j - 1].IsWall)
                    {
                        nodes[i, j].Edges.Add(new Edge(nodes[i + 1, j - 1], 1));
                    }

                    //Bottom Left
                    if (i - 1 >= 0 && j + 1 < nodes.GetLength(1) && !nodes[i - 1, j].IsWall && !nodes[i, j + 1].IsWall )
                    {
                        nodes[i, j].Edges.Add(new Edge(nodes[i - 1, j + 1], 1));
                    }


                    //Bottom Right
                    if (i + 1 < nodes.GetLength(0) && j + 1 < nodes.GetLength(1) && !nodes[i + 1, j].IsWall && !nodes[i, j + 1].IsWall)
                    {
                        nodes[i, j].Edges.Add(new Edge(nodes[i + 1, j + 1], 1));
                    }

                }
            }
        }

        private Node SelectedNode(Point p)
        {
            foreach (Node n in nodes)
            {
                if (n.IsInBounds(p))
                {
                    return n;
                }
            }

            return null;
        }

        private void panel1_OnClick(object sender, MouseEventArgs e)
        {
            ColorPanel(e);
        }

        private void ColorPanel(MouseEventArgs e)
        {
            Point pClick = new Point(e.Location.X, e.Location.Y);
            Node n = SelectedNode(pClick);
            if (n != null)
            {
                //Obstacle
                if (rdoAddObstacle.Checked)
                {
                    if (n.IsStart)
                    {
                        n.IsStart = false;
                        startNode = null;
                    }
                    else if (n.IsGoal)
                    {
                        n.IsGoal = false;
                        goalNode = null;
                    }
                    if(n.IncomingRisk.RiskVal > 0)
                    {
                        n.IncomingRisk.RiskVal = 0.0f;
                    }
                    n.IsWall = true;
                    n.Color = Color.Black;
                    n.Edges.Clear();
                    panel1.Invalidate(n.Rectangle);
                }
                else if (rdoSetStart.Checked && !n.IsWall)
                {
                    foreach (Node x in nodes)
                    {
                        if (x.IsStart)
                        {
                            x.IsStart = false;
                            x.Color = default(Color);
                            panel1.Invalidate(x.Rectangle);
                        }
                    }
                    startNode = n;
                    n.IsStart = true;
                    n.Color = Color.Green;
                    panel1.Invalidate(n.Rectangle);
                }
                else if (rdoSetGoal.Checked && !n.IsWall)
                {
                    foreach (Node x in nodes)
                    {
                        if (x.IsGoal)
                        {
                            x.IsGoal = false;
                            x.Color = default(Color);
                            panel1.Invalidate(x.Rectangle);
                        }
                    }
                    goalNode = n;
                    n.IsGoal = true;
                    n.Color = Color.Gold;
                    panel1.Invalidate(n.Rectangle);
                }
                else if (rdoSetRisk.Checked && !n.IsWall)
                {
                    float a;
                    if (!float.TryParse(txtRiskVal.Text, out a))
                    {
                        MessageBox.Show("Risk must be numeric.");
                        return;
                    }

                    float tempRisk = Convert.ToSingle(txtRiskVal.Text);
                    foreach(Node m in n.GetAdjacentNodes())
                    {
                        foreach (Edge r in m.Edges)
                        {
                            if(r.TargetNode == n)
                                r.Risk.RiskVal = tempRisk;
                        }
                    }
                    n.IncomingRisk.RiskVal = tempRisk;

                    if (tempRisk > 0)
                    {
                        float percentage = 255 * Convert.ToSingle(txtRiskVal.Text);
                        n.Color = Color.FromArgb(Convert.ToInt32(percentage), 0, 0);
                        panel1.Invalidate(n.Rectangle);
                        SetMinRisk(tempRisk);
                    }
                }

                string incomingRisk = "";
                string outgoingRisk = "";

                foreach (Node m in n.GetAdjacentNodes())
                {
                    foreach (Edge r in m.Edges)
                    {
                        if (r.TargetNode == n)
                            incomingRisk += r.Risk.RiskVal.ToString() + ", ";
                    }
                }

                foreach(Edge r in n.Edges)
                {
                    outgoingRisk += r.Risk.RiskVal.ToString() + ", ";
                }

                txtNode.Text = "Name: " + n.NameVal + "x" + n.NameInt + "\r\n" +
                                "Gscore: " + n.GScore + "\r\n" +
                                "Edges: " + n.Edges.Count + "\r\n" +
                                "Inc. Risk: " + incomingRisk + "\r\n" +
                                "Outg. Risk: " + outgoingRisk;
            }
        }

        private void SetMinRisk(float risk)
        {
            if(risk < minRisk)
            {
                minRisk = risk;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;

            //e.Graphics.TranslateTransform(panel1.AutoScrollPosition.X, panel1.AutoScrollPosition.Y);

            g.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.Black)), p.DisplayRectangle);

            Font font1 = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);

            // Call the OnPaint method of the base class.
            base.OnPaint(e);
            StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);

            // Call methods of the System.Drawing.Graphics object.
            foreach (Node n in nodes)
            {
                e.Graphics.FillRectangle(n.Brush, n.Rectangle);
                e.Graphics.DrawRectangle(borderPen, n.Rectangle);
                if(this.showEdges)
                {
                    foreach (Edge edge in n.Edges)
                    {
                        e.Graphics.DrawLine(borderPen, n.Center, edge.TargetNode.Center);
                    }
                }
                format1.Alignment = StringAlignment.Near;
                //e.Graphics.DrawString(n.Name, font1, Brushes.Blue, n.Rectangle, format1);
                format1.Alignment = StringAlignment.Far;
                //e.Graphics.DrawString(n.Weight.ToString(), font1, Brushes.Black, n.Rectangle, format1);
            }

            //g.FillPolygon(brush, points);
        }

        private void btnOpenMap_Click(object sender, EventArgs e)
        {
            dlgOpenMap.Filter = "Map Files (*.map)|*.map";
            DialogResult result = dlgOpenMap.ShowDialog(); // Show the dialog.
            
            if (result == DialogResult.OK) // Test result.
            {
                string ext = Path.GetExtension(dlgOpenMap.FileName);
                if(ext != ".map" && ext != ".MAP")
                {
                    MessageBox.Show("Invalid file.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string file = dlgOpenMap.FileName;
                try
                {
                    rawMapData = File.ReadAllText(file);
                    rawMapData = rawMapData.Replace("\n", String.Empty);          //remove new lines
                    ReloadMap();
                }
                catch (IOException)
                {
                }
            }
        }

        private void ReloadMap()
        {
            if(rawMapData == string.Empty)
            {
                LoadNodes(DEFAULT_DIMENSION, DEFAULT_DIMENSION);
                SetAdjacentNodes(chkDiagonal.Checked);
                return;
            }

            string firDimension = string.Empty;
            string secDimension = string.Empty;

            bool firDimensionFound = false;
            bool secDimensionFound = false;

            foreach (char a in rawMapData)
            {
                if (Char.IsNumber(a) && !firDimensionFound)
                {
                    firDimension += a.ToString();
                }
                else if (Char.IsNumber(a) && !secDimensionFound)
                {
                    secDimension += a.ToString();
                }

                if (a == 'w') //first dimension: width
                {
                    firDimensionFound = true;
                }
                else if (a == 'm') //second dimension: map
                {
                    secDimensionFound = true;
                }
            }
            string mapData = rawMapData.Substring(rawMapData.LastIndexOf('p') + 1); //map data after the last 'p' character

            int fDim = int.Parse(firDimension);
            int sDim = int.Parse(secDimension);

            LoadNodes(fDim, sDim);

            RunMapData(mapData, fDim, sDim);

            SetAdjacentNodes(chkDiagonal.Checked);
        }

        private void RunMapData(string mapData, int firDimension, int secDimension)
        {
            int i = 0, j = 0, c = 0;
            int[,] result = new int[firDimension, secDimension];
            for(i = 0; i < firDimension; i++)
            {
               for(j = 0; j < secDimension; j++)
                {
                    result[i, j] = mapData[c];
                    if (result[i, j] == 'T')
                    {
                        nodes[i, j].IsWall = true;
                        nodes[i, j].Color = Color.Black;
                    }
                    else if(result[i, j] == '@')
                    {
                        nodes[i, j].Color = Color.Gray;
                        nodes[i, j].DefaultColor = Color.Gray;
                    }
                    else if(result[i, j] == '.')
                    {
                        nodes[i, j].Color = Color.White;
                        nodes[i, j].DefaultColor = Color.White;
                    }

                    c++;
                }
            }
            panel1.Invalidate();
        }

        private void rdoSetStart_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoSetGoal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoAddObstacle_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboDimensionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Array.Clear(nodes,0,nodes.Length);
            int val1 = 0;
            int val2 = 0;

            string val = cboDimensionSelect.SelectedItem.ToString();

            val1 = int.Parse(val.Substring(0, val.IndexOf("x", StringComparison.Ordinal)));
            val2 = int.Parse(val.Substring(val.LastIndexOf('x') + 1));
            LoadNodes(val1, val2);
            SetAdjacentNodes(chkDiagonal.Checked);
            panel1.Invalidate();
        }

        private void RunAlgorithm(string algorithm)
        {
            Algorithm alg;

            if(algorithm == ALG_DIJKSTRA)
            {
                alg = new DijkstraAlgorithm(startNode, goalNode);
                pathList = alg.RunAlgorithm(startNode, goalNode);
            }
            else if(algorithm == ALG_ASTAR)
            {
                alg = new AStarSearch(startNode, goalNode);
                pathList = alg.RunAlgorithm(startNode, goalNode);
            }
            else if (algorithm == ALG_HOLDER)
            {
                alg = new HoldersAlgorithm(startNode, goalNode, prefVal);
                pathList = alg.RunAlgorithm(startNode, goalNode, prefVal);
            }
            else
            {
                alg = new DynamicARisk(startNode, goalNode, prefVal);
                pathList = alg.RunAlgorithm(startNode, goalNode, prefVal);
            }

            expandedNodes = alg.ExpandedNodes;

            if (pathList == null)
            {
                MessageBox.Show("Could not draw path from start to goal.");
            }
            else
            {
                foreach (Node n in expandedNodes)
                {
                    if(cancelProcessing)
                    {
                        break;
                    }

                    this.txtDesc.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        txtDesc.AppendText("N" + n.NameVal + n.NameInt + ". G=" + n.GScore + ", F=" + n.FScore + "\n");
                    });
                    if (!n.IsStart && !n.IsGoal && !n.IsWall && n.IncomingRisk.RiskVal == 0)
                    {
                        n.Color = Color.LightBlue;
                        if (!chkAuto.Checked)
                            panel1.Invalidate(n.Rectangle);
                    }
                    foreach (Node m in n.GetAdjacentNodes())
                    {
                        if (m.Color != Color.LightBlue && !m.IsStart && !m.IsGoal && !m.IsWall && m.IncomingRisk.RiskVal == 0)
                        {
                            m.Color = Color.LightGreen;
                            if (!chkAuto.Checked)
                                panel1.Invalidate(m.Rectangle);
                        }
                    }
                    if (!chkAuto.Checked)
                        Thread.Sleep(50);
                }
                foreach (Node n in pathList)
                {
                    if(cancelProcessing)
                    {
                        break;
                    }
                    n.Color = Color.Blue;
                    panel1.Invalidate(n.Rectangle);
                    Thread.Sleep(25);
                }

                this.txtDesc.Invoke((MethodInvoker)delegate {
                    // Running on the UI thread

                    //Previous tests
                    txtPrevAlgorithm.Text = txtAlgorithmName.Text;
                    txtPrevNodesExpanded.Text = txtNodesExpanded.Text;
                    txtPrevTotalOperations.Text = txtTotalOperations.Text;

                    if (cancelProcessing)
                    {
                        txtAlgorithmName.Text = "Cancelled";
                        cancelProcessing = false;
                        btnStop.Enabled = false;
                    }
                    else
                    {
                        //Current tests
                        txtAlgorithmName.Text = selectedAlgorithm;
                    }
                    txtNodesExpanded.Text = expandedNodes.Count.ToString();
                    txtTotalOperations.Text = alg.TotalOperations.ToString();
                    chkAuto.Enabled = true;
                    btnClear.Enabled = true;
                    btnRestart.Enabled = true;
                });
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if(startNode == null || goalNode == null)
            {
                MessageBox.Show("No start or goal selected!");
                return;
            }

            if(selectedAlgorithm == string.Empty)
            {
                MessageBox.Show("Select an algorithm first!");
                return;
            }

            Reset();

            prefVal = Convert.ToSingle(txtPref.Text);

            pathList = new List<Node>();
            expandedNodes = new List<Node>();

            chkAuto.Enabled = false;
            txtDesc.Text = string.Empty;
            btnClear.Enabled = false;
            btnRestart.Enabled = false;
            btnStop.Enabled = true;

            if (selectedAlgorithm == ALG_DIJKSTRA)
            {
                Thread newThread = new Thread(() => RunAlgorithm(ALG_DIJKSTRA));
                newThread.Start();
            }
            else if (selectedAlgorithm == ALG_ASTAR)
            {
                Thread newThread = new Thread(() => RunAlgorithm(ALG_ASTAR));
                newThread.Start();
            }
            else if (selectedAlgorithm == ALG_HOLDER)
            {
                Thread newThread = new Thread(() => RunAlgorithm(ALG_HOLDER));
                newThread.Start();
            }
            else if (selectedAlgorithm == ALG_ATSTAR)
            {
                Thread newThread = new Thread(() => RunAlgorithm(ALG_ATSTAR));
                newThread.Start();
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ReloadMap();
            panel1.Invalidate();
            txtDesc.Text = string.Empty;
            txtAlgorithmName.Text = string.Empty;
            txtNodesExpanded.Text = string.Empty;
            txtTotalOperations.Text = string.Empty;
            cboAlgorithmSelect.Text = string.Empty;
        }

        private void chkAutoPath_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAdvance_Click(object sender, EventArgs e)
        {

        }

        private void cboAlgorithmSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDesc.Text = string.Empty;
            selectedAlgorithm = cboAlgorithmSelect.Text;
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            foreach (Node n in nodes)
            {
                n.GScore = 9999f;
                n.FScore = 0f;
                if (n.IncomingRisk.RiskVal == 0 && !n.IsWall)
                {
                    n.Color = n.DefaultColor;
                    panel1.Invalidate(n.Rectangle);
                }
                else if (n.IncomingRisk.RiskVal > 0)
                {
                    float percentage = 255 * Convert.ToSingle(n.IncomingRisk.RiskVal); ;
                    n.Color = Color.FromArgb(Convert.ToInt32(percentage), 0, 0);
                    panel1.Invalidate(n.Rectangle);
                    SetMinRisk(n.IncomingRisk.RiskVal);
                }

                if (n.IsStart)
                {
                    n.Color = Color.Green;
                    panel1.Invalidate(n.Rectangle);
                }
                else if (n.IsGoal)
                {
                    n.Color = Color.Gold;
                    panel1.Invalidate(n.Rectangle);
                }
            }
        }

        private void chkDiagonal_CheckedChanged(object sender, EventArgs e)
        {
            ReloadMap();
            SetAdjacentNodes(chkDiagonal.Checked);
            panel1.Invalidate();
        }

        private void chkShowEdges_CheckedChanged(object sender, EventArgs e)
        {
            this.showEdges = chkShowEdges.Checked;
            panel1.Invalidate();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            cancelProcessing = true;
        }
    }
}
