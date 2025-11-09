namespace PathfindingSimulator
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenMap = new System.Windows.Forms.Button();
            this.dlgOpenMap = new System.Windows.Forms.OpenFileDialog();
            this.rdoSetStart = new System.Windows.Forms.RadioButton();
            this.rdoSetGoal = new System.Windows.Forms.RadioButton();
            this.rdoAddObstacle = new System.Windows.Forms.RadioButton();
            this.cboDimensionSelect = new System.Windows.Forms.ComboBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.txtPrevTotalOperations = new System.Windows.Forms.TextBox();
            this.txtPrevNodesExpanded = new System.Windows.Forms.TextBox();
            this.txtPrevAlgorithm = new System.Windows.Forms.TextBox();
            this.lblPrevAlgorithm = new System.Windows.Forms.Label();
            this.lblPrevTotalOperations = new System.Windows.Forms.Label();
            this.lblPrevNodesExpanded = new System.Windows.Forms.Label();
            this.txtAlgorithmName = new System.Windows.Forms.TextBox();
            this.txtTotalOperations = new System.Windows.Forms.TextBox();
            this.lblTotalOperations = new System.Windows.Forms.Label();
            this.txtNodesExpanded = new System.Windows.Forms.TextBox();
            this.lblNodesExpanded = new System.Windows.Forms.Label();
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.cboAlgorithmSelect = new System.Windows.Forms.ComboBox();
            this.btnRestart = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoSetRisk = new System.Windows.Forms.RadioButton();
            this.txtRiskVal = new System.Windows.Forms.TextBox();
            this.txtPref = new System.Windows.Forms.TextBox();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkDiagonal = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.chkShowEdges = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtNode = new System.Windows.Forms.TextBox();
            this.panel1 = new PathfindingSimulator.MyPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Map Size";
            // 
            // btnOpenMap
            // 
            this.btnOpenMap.Location = new System.Drawing.Point(16, 3);
            this.btnOpenMap.Name = "btnOpenMap";
            this.btnOpenMap.Size = new System.Drawing.Size(123, 26);
            this.btnOpenMap.TabIndex = 3;
            this.btnOpenMap.Text = "Open Map...";
            this.btnOpenMap.UseVisualStyleBackColor = true;
            this.btnOpenMap.Click += new System.EventHandler(this.btnOpenMap_Click);
            // 
            // rdoSetStart
            // 
            this.rdoSetStart.AutoSize = true;
            this.rdoSetStart.Location = new System.Drawing.Point(16, 153);
            this.rdoSetStart.Name = "rdoSetStart";
            this.rdoSetStart.Size = new System.Drawing.Size(66, 17);
            this.rdoSetStart.TabIndex = 5;
            this.rdoSetStart.TabStop = true;
            this.rdoSetStart.Text = "Set Start";
            this.rdoSetStart.UseVisualStyleBackColor = true;
            this.rdoSetStart.CheckedChanged += new System.EventHandler(this.rdoSetStart_CheckedChanged);
            // 
            // rdoSetGoal
            // 
            this.rdoSetGoal.AutoSize = true;
            this.rdoSetGoal.Location = new System.Drawing.Point(16, 177);
            this.rdoSetGoal.Name = "rdoSetGoal";
            this.rdoSetGoal.Size = new System.Drawing.Size(66, 17);
            this.rdoSetGoal.TabIndex = 6;
            this.rdoSetGoal.TabStop = true;
            this.rdoSetGoal.Text = "Set Goal";
            this.rdoSetGoal.UseVisualStyleBackColor = true;
            this.rdoSetGoal.CheckedChanged += new System.EventHandler(this.rdoSetGoal_CheckedChanged);
            // 
            // rdoAddObstacle
            // 
            this.rdoAddObstacle.AutoSize = true;
            this.rdoAddObstacle.Location = new System.Drawing.Point(16, 130);
            this.rdoAddObstacle.Name = "rdoAddObstacle";
            this.rdoAddObstacle.Size = new System.Drawing.Size(72, 17);
            this.rdoAddObstacle.TabIndex = 7;
            this.rdoAddObstacle.TabStop = true;
            this.rdoAddObstacle.Text = "Add Obst.";
            this.rdoAddObstacle.UseVisualStyleBackColor = true;
            this.rdoAddObstacle.CheckedChanged += new System.EventHandler(this.rdoAddObstacle_CheckedChanged);
            // 
            // cboDimensionSelect
            // 
            this.cboDimensionSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDimensionSelect.FormattingEnabled = true;
            this.cboDimensionSelect.Items.AddRange(new object[] {
            "49x49",
            "56x56",
            "100x100",
            "120x120",
            "261x261"});
            this.cboDimensionSelect.Location = new System.Drawing.Point(18, 54);
            this.cboDimensionSelect.Name = "cboDimensionSelect";
            this.cboDimensionSelect.Size = new System.Drawing.Size(121, 21);
            this.cboDimensionSelect.TabIndex = 8;
            this.cboDimensionSelect.SelectedIndexChanged += new System.EventHandler(this.cboDimensionSelect_SelectedIndexChanged);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(18, 224);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 9;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbltitle);
            this.panel2.Controls.Add(this.txtPrevTotalOperations);
            this.panel2.Controls.Add(this.txtPrevNodesExpanded);
            this.panel2.Controls.Add(this.txtPrevAlgorithm);
            this.panel2.Controls.Add(this.lblPrevAlgorithm);
            this.panel2.Controls.Add(this.lblPrevTotalOperations);
            this.panel2.Controls.Add(this.lblPrevNodesExpanded);
            this.panel2.Controls.Add(this.txtAlgorithmName);
            this.panel2.Controls.Add(this.txtTotalOperations);
            this.panel2.Controls.Add(this.lblTotalOperations);
            this.panel2.Controls.Add(this.txtNodesExpanded);
            this.panel2.Controls.Add(this.lblNodesExpanded);
            this.panel2.Controls.Add(this.lblAlgorithm);
            this.panel2.Location = new System.Drawing.Point(1065, 327);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(156, 159);
            this.panel2.TabIndex = 10;
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.Location = new System.Drawing.Point(0, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(42, 13);
            this.lbltitle.TabIndex = 12;
            this.lbltitle.Text = "Results";
            // 
            // txtPrevTotalOperations
            // 
            this.txtPrevTotalOperations.Location = new System.Drawing.Point(85, 128);
            this.txtPrevTotalOperations.Name = "txtPrevTotalOperations";
            this.txtPrevTotalOperations.ReadOnly = true;
            this.txtPrevTotalOperations.Size = new System.Drawing.Size(60, 20);
            this.txtPrevTotalOperations.TabIndex = 11;
            // 
            // txtPrevNodesExpanded
            // 
            this.txtPrevNodesExpanded.Location = new System.Drawing.Point(85, 82);
            this.txtPrevNodesExpanded.Name = "txtPrevNodesExpanded";
            this.txtPrevNodesExpanded.ReadOnly = true;
            this.txtPrevNodesExpanded.Size = new System.Drawing.Size(60, 20);
            this.txtPrevNodesExpanded.TabIndex = 10;
            // 
            // txtPrevAlgorithm
            // 
            this.txtPrevAlgorithm.Location = new System.Drawing.Point(85, 36);
            this.txtPrevAlgorithm.Name = "txtPrevAlgorithm";
            this.txtPrevAlgorithm.ReadOnly = true;
            this.txtPrevAlgorithm.Size = new System.Drawing.Size(60, 20);
            this.txtPrevAlgorithm.TabIndex = 9;
            // 
            // lblPrevAlgorithm
            // 
            this.lblPrevAlgorithm.AutoSize = true;
            this.lblPrevAlgorithm.Location = new System.Drawing.Point(82, 20);
            this.lblPrevAlgorithm.Name = "lblPrevAlgorithm";
            this.lblPrevAlgorithm.Size = new System.Drawing.Size(54, 13);
            this.lblPrevAlgorithm.TabIndex = 8;
            this.lblPrevAlgorithm.Text = "Previous: ";
            // 
            // lblPrevTotalOperations
            // 
            this.lblPrevTotalOperations.AutoSize = true;
            this.lblPrevTotalOperations.Location = new System.Drawing.Point(82, 112);
            this.lblPrevTotalOperations.Name = "lblPrevTotalOperations";
            this.lblPrevTotalOperations.Size = new System.Drawing.Size(51, 13);
            this.lblPrevTotalOperations.TabIndex = 7;
            this.lblPrevTotalOperations.Text = "Previous:";
            // 
            // lblPrevNodesExpanded
            // 
            this.lblPrevNodesExpanded.AutoSize = true;
            this.lblPrevNodesExpanded.Location = new System.Drawing.Point(82, 66);
            this.lblPrevNodesExpanded.Name = "lblPrevNodesExpanded";
            this.lblPrevNodesExpanded.Size = new System.Drawing.Size(51, 13);
            this.lblPrevNodesExpanded.TabIndex = 6;
            this.lblPrevNodesExpanded.Text = "Previous:";
            // 
            // txtAlgorithmName
            // 
            this.txtAlgorithmName.Location = new System.Drawing.Point(7, 36);
            this.txtAlgorithmName.Name = "txtAlgorithmName";
            this.txtAlgorithmName.ReadOnly = true;
            this.txtAlgorithmName.Size = new System.Drawing.Size(59, 20);
            this.txtAlgorithmName.TabIndex = 2;
            // 
            // txtTotalOperations
            // 
            this.txtTotalOperations.Location = new System.Drawing.Point(7, 128);
            this.txtTotalOperations.Name = "txtTotalOperations";
            this.txtTotalOperations.ReadOnly = true;
            this.txtTotalOperations.Size = new System.Drawing.Size(59, 20);
            this.txtTotalOperations.TabIndex = 5;
            // 
            // lblTotalOperations
            // 
            this.lblTotalOperations.AutoSize = true;
            this.lblTotalOperations.Location = new System.Drawing.Point(4, 112);
            this.lblTotalOperations.Name = "lblTotalOperations";
            this.lblTotalOperations.Size = new System.Drawing.Size(56, 13);
            this.lblTotalOperations.TabIndex = 4;
            this.lblTotalOperations.Text = "Total Ops:";
            // 
            // txtNodesExpanded
            // 
            this.txtNodesExpanded.Location = new System.Drawing.Point(7, 82);
            this.txtNodesExpanded.Name = "txtNodesExpanded";
            this.txtNodesExpanded.ReadOnly = true;
            this.txtNodesExpanded.Size = new System.Drawing.Size(59, 20);
            this.txtNodesExpanded.TabIndex = 3;
            // 
            // lblNodesExpanded
            // 
            this.lblNodesExpanded.AutoSize = true;
            this.lblNodesExpanded.Location = new System.Drawing.Point(4, 66);
            this.lblNodesExpanded.Name = "lblNodesExpanded";
            this.lblNodesExpanded.Size = new System.Drawing.Size(62, 13);
            this.lblNodesExpanded.TabIndex = 1;
            this.lblNodesExpanded.Text = "Nodes Exp:";
            // 
            // lblAlgorithm
            // 
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Location = new System.Drawing.Point(4, 20);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(49, 13);
            this.lblAlgorithm.TabIndex = 0;
            this.lblAlgorithm.Text = "Method: ";
            // 
            // cboAlgorithmSelect
            // 
            this.cboAlgorithmSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlgorithmSelect.FormattingEnabled = true;
            this.cboAlgorithmSelect.Items.AddRange(new object[] {
            "Dijkstra",
            "A* Search",
            "Holder",
            "A(t)*"});
            this.cboAlgorithmSelect.Location = new System.Drawing.Point(16, 103);
            this.cboAlgorithmSelect.Name = "cboAlgorithmSelect";
            this.cboAlgorithmSelect.Size = new System.Drawing.Size(121, 21);
            this.cboAlgorithmSelect.TabIndex = 11;
            this.cboAlgorithmSelect.SelectedIndexChanged += new System.EventHandler(this.cboAlgorithmSelect_SelectedIndexChanged);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(18, 279);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 12;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtDesc);
            this.panel3.Location = new System.Drawing.Point(1065, 580);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(156, 226);
            this.panel3.TabIndex = 13;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(-1, -1);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.Size = new System.Drawing.Size(156, 226);
            this.txtDesc.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Algorithm";
            // 
            // rdoSetRisk
            // 
            this.rdoSetRisk.AutoSize = true;
            this.rdoSetRisk.Location = new System.Drawing.Point(16, 200);
            this.rdoSetRisk.Name = "rdoSetRisk";
            this.rdoSetRisk.Size = new System.Drawing.Size(65, 17);
            this.rdoSetRisk.TabIndex = 17;
            this.rdoSetRisk.TabStop = true;
            this.rdoSetRisk.Text = "Set Risk";
            this.rdoSetRisk.UseVisualStyleBackColor = true;
            // 
            // txtRiskVal
            // 
            this.txtRiskVal.Location = new System.Drawing.Point(99, 200);
            this.txtRiskVal.MaxLength = 5;
            this.txtRiskVal.Name = "txtRiskVal";
            this.txtRiskVal.Size = new System.Drawing.Size(42, 20);
            this.txtRiskVal.TabIndex = 18;
            this.txtRiskVal.Text = "0.4";
            this.txtRiskVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPref
            // 
            this.txtPref.Location = new System.Drawing.Point(121, 253);
            this.txtPref.MaxLength = 4;
            this.txtPref.Name = "txtPref";
            this.txtPref.Size = new System.Drawing.Size(20, 20);
            this.txtPref.TabIndex = 19;
            this.txtPref.Text = "0";
            this.txtPref.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Location = new System.Drawing.Point(100, 229);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(48, 17);
            this.chkAuto.TabIndex = 20;
            this.chkAuto.Text = "Auto";
            this.chkAuto.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "p:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(18, 250);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "Clear Map";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnReset_Click_1);
            // 
            // chkDiagonal
            // 
            this.chkDiagonal.AutoSize = true;
            this.chkDiagonal.Location = new System.Drawing.Point(99, 178);
            this.chkDiagonal.Name = "chkDiagonal";
            this.chkDiagonal.Size = new System.Drawing.Size(51, 17);
            this.chkDiagonal.TabIndex = 23;
            this.chkDiagonal.Text = "Diag.";
            this.chkDiagonal.UseVisualStyleBackColor = true;
            this.chkDiagonal.CheckedChanged += new System.EventHandler(this.chkDiagonal_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.radioButton1);
            this.panel4.Controls.Add(this.btnStop);
            this.panel4.Controls.Add(this.chkShowEdges);
            this.panel4.Controls.Add(this.chkDiagonal);
            this.panel4.Controls.Add(this.btnOpenMap);
            this.panel4.Controls.Add(this.btnClear);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.rdoSetStart);
            this.panel4.Controls.Add(this.chkAuto);
            this.panel4.Controls.Add(this.rdoSetGoal);
            this.panel4.Controls.Add(this.txtPref);
            this.panel4.Controls.Add(this.rdoAddObstacle);
            this.panel4.Controls.Add(this.txtRiskVal);
            this.panel4.Controls.Add(this.cboDimensionSelect);
            this.panel4.Controls.Add(this.rdoSetRisk);
            this.panel4.Controls.Add(this.btnExecute);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.cboAlgorithmSelect);
            this.panel4.Controls.Add(this.btnRestart);
            this.panel4.Location = new System.Drawing.Point(1065, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(156, 309);
            this.panel4.TabIndex = 0;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(99, 279);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(49, 23);
            this.btnStop.TabIndex = 25;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chkShowEdges
            // 
            this.chkShowEdges.AutoSize = true;
            this.chkShowEdges.Location = new System.Drawing.Point(99, 154);
            this.chkShowEdges.Name = "chkShowEdges";
            this.chkShowEdges.Size = new System.Drawing.Size(56, 17);
            this.chkShowEdges.TabIndex = 24;
            this.chkShowEdges.Text = "Edges";
            this.chkShowEdges.UseVisualStyleBackColor = true;
            this.chkShowEdges.CheckedChanged += new System.EventHandler(this.chkShowEdges_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.txtNode);
            this.panel5.Location = new System.Drawing.Point(1065, 492);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(156, 82);
            this.panel5.TabIndex = 14;
            // 
            // txtNode
            // 
            this.txtNode.Location = new System.Drawing.Point(-1, -1);
            this.txtNode.Multiline = true;
            this.txtNode.Name = "txtNode";
            this.txtNode.Size = new System.Drawing.Size(156, 82);
            this.txtNode.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(1800, 1200);
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1047, 794);
            this.panel1.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(99, 131);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(55, 17);
            this.radioButton1.TabIndex = 26;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Select";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 818);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.Text = "Pathfinding Simulator";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyPanel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenMap;
        private System.Windows.Forms.OpenFileDialog dlgOpenMap;
        private System.Windows.Forms.RadioButton rdoSetStart;
        private System.Windows.Forms.RadioButton rdoSetGoal;
        private System.Windows.Forms.RadioButton rdoAddObstacle;
        private System.Windows.Forms.ComboBox cboDimensionSelect;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNodesExpanded;
        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.ComboBox cboAlgorithmSelect;
        private System.Windows.Forms.TextBox txtNodesExpanded;
        private System.Windows.Forms.TextBox txtAlgorithmName;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalOperations;
        private System.Windows.Forms.Label lblTotalOperations;
        private System.Windows.Forms.RadioButton rdoSetRisk;
        private System.Windows.Forms.TextBox txtRiskVal;
        private System.Windows.Forms.TextBox txtPref;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkDiagonal;
        private System.Windows.Forms.TextBox txtPrevTotalOperations;
        private System.Windows.Forms.TextBox txtPrevNodesExpanded;
        private System.Windows.Forms.TextBox txtPrevAlgorithm;
        private System.Windows.Forms.Label lblPrevAlgorithm;
        private System.Windows.Forms.Label lblPrevTotalOperations;
        private System.Windows.Forms.Label lblPrevNodesExpanded;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chkShowEdges;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtNode;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

