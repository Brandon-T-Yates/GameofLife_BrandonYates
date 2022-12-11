namespace GameofLife_BrandonYates
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hUDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToggle = new System.Windows.Forms.ToolStripMenuItem();
            this.neighborCountToggle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.finiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toroidalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.randomSeed = new System.Windows.Forms.ToolStripMenuItem();
            this.randomTime = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridAndTimeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.colorTool = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColorButton = new System.Windows.Forms.ToolStripMenuItem();
            this.cellColorButton = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorTool = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.resetButton = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadButton = new System.Windows.Forms.ToolStripMenuItem();
            this.previousButton = new System.Windows.Forms.ToolStrip();
            this.NewGrid = new System.Windows.Forms.ToolStripButton();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.playButton = new System.Windows.Forms.ToolStripButton();
            this.pauseButton = new System.Windows.Forms.ToolStripButton();
            this.previousButton1 = new System.Windows.Forms.ToolStripButton();
            this.nextButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelGenerations = new System.Windows.Forms.ToolStripStatusLabel();
            this.cellsAlive = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuRand = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rightClickRandom = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClickColor = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClickGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClickCell = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClickBG = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicsPanel1 = new GameofLife_BrandonYates.GraphicsPanel();
            this.menuStrip1.SuspendLayout();
            this.previousButton.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuRand.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(580, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileNew,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // fileNew
            // 
            this.fileNew.Image = ((System.Drawing.Image)(resources.GetObject("fileNew.Image")));
            this.fileNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileNew.Name = "fileNew";
            this.fileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.fileNew.Size = new System.Drawing.Size(146, 22);
            this.fileNew.Text = "&New";
            this.fileNew.Click += new System.EventHandler(this.fileNew_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hUDToolStripMenuItem,
            this.gridToggle,
            this.neighborCountToggle,
            this.toolStripSeparator4,
            this.finiteToolStripMenuItem,
            this.toroidalToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&View";
            // 
            // hUDToolStripMenuItem
            // 
            this.hUDToolStripMenuItem.CheckOnClick = true;
            this.hUDToolStripMenuItem.Name = "hUDToolStripMenuItem";
            this.hUDToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hUDToolStripMenuItem.Text = "HUD";
            this.hUDToolStripMenuItem.Click += new System.EventHandler(this.hUDToolStripMenuItem_Click);
            // 
            // gridToggle
            // 
            this.gridToggle.CheckOnClick = true;
            this.gridToggle.Name = "gridToggle";
            this.gridToggle.Size = new System.Drawing.Size(180, 22);
            this.gridToggle.Text = "Grid";
            this.gridToggle.Click += new System.EventHandler(this.gridToggle_Click);
            // 
            // neighborCountToggle
            // 
            this.neighborCountToggle.CheckOnClick = true;
            this.neighborCountToggle.Name = "neighborCountToggle";
            this.neighborCountToggle.Size = new System.Drawing.Size(180, 22);
            this.neighborCountToggle.Text = "Neighbor Count";
            this.neighborCountToggle.CheckedChanged += new System.EventHandler(this.neighborCountToggle_Click);
            this.neighborCountToggle.CheckStateChanged += new System.EventHandler(this.neighborCountToggle_Click);
            this.neighborCountToggle.Click += new System.EventHandler(this.neighborCountToggle_Click);
            this.neighborCountToggle.OwnerChanged += new System.EventHandler(this.neighborCountToggle_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // finiteToolStripMenuItem
            // 
            this.finiteToolStripMenuItem.Name = "finiteToolStripMenuItem";
            this.finiteToolStripMenuItem.ShowShortcutKeys = false;
            this.finiteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.finiteToolStripMenuItem.Text = "Finite";
            this.finiteToolStripMenuItem.Click += new System.EventHandler(this.finiteToolStripMenuItem_Click);
            // 
            // toroidalToolStripMenuItem
            // 
            this.toroidalToolStripMenuItem.Name = "toroidalToolStripMenuItem";
            this.toroidalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toroidalToolStripMenuItem.Text = "Toroidal";
            this.toroidalToolStripMenuItem.Click += new System.EventHandler(this.toroidalToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.randomSeed,
            this.randomTime});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.helpToolStripMenuItem.Text = "&Randomize";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(128, 6);
            // 
            // randomSeed
            // 
            this.randomSeed.Name = "randomSeed";
            this.randomSeed.Size = new System.Drawing.Size(131, 22);
            this.randomSeed.Text = "From Seed";
            this.randomSeed.Click += new System.EventHandler(this.randomSeed_Click);
            // 
            // randomTime
            // 
            this.randomTime.Name = "randomTime";
            this.randomTime.Size = new System.Drawing.Size(131, 22);
            this.randomTime.Text = "From Time";
            this.randomTime.Click += new System.EventHandler(this.randomTime_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridAndTimeButton,
            this.colorTool,
            this.toolStripSeparator3,
            this.resetButton,
            this.reloadButton});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // gridAndTimeButton
            // 
            this.gridAndTimeButton.Name = "gridAndTimeButton";
            this.gridAndTimeButton.Size = new System.Drawing.Size(161, 22);
            this.gridAndTimeButton.Text = "Grid Size && Time";
            this.gridAndTimeButton.Click += new System.EventHandler(this.gridAndTimeButton_Click);
            // 
            // colorTool
            // 
            this.colorTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridColorButton,
            this.cellColorButton,
            this.backgroundColorTool});
            this.colorTool.Name = "colorTool";
            this.colorTool.Size = new System.Drawing.Size(161, 22);
            this.colorTool.Text = "&Color";
            // 
            // gridColorButton
            // 
            this.gridColorButton.Name = "gridColorButton";
            this.gridColorButton.Size = new System.Drawing.Size(170, 22);
            this.gridColorButton.Text = "&Grid Color";
            this.gridColorButton.Click += new System.EventHandler(this.gridColorButton_Click);
            // 
            // cellColorButton
            // 
            this.cellColorButton.Name = "cellColorButton";
            this.cellColorButton.Size = new System.Drawing.Size(170, 22);
            this.cellColorButton.Text = "&Cell Color";
            this.cellColorButton.Click += new System.EventHandler(this.cellColorButton_Click);
            // 
            // backgroundColorTool
            // 
            this.backgroundColorTool.Name = "backgroundColorTool";
            this.backgroundColorTool.Size = new System.Drawing.Size(170, 22);
            this.backgroundColorTool.Text = "&Background Color";
            this.backgroundColorTool.Click += new System.EventHandler(this.backgroundColorTool_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(158, 6);
            // 
            // resetButton
            // 
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(161, 22);
            this.resetButton.Text = "&Reset";
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // reloadButton
            // 
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(161, 22);
            this.reloadButton.Text = "&Reload";
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.AccessibleName = "previousButton";
            this.previousButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGrid,
            this.openButton,
            this.saveButton,
            this.toolStripSeparator6,
            this.playButton,
            this.pauseButton,
            this.previousButton1,
            this.nextButton,
            this.toolStripSeparator7});
            this.previousButton.Location = new System.Drawing.Point(0, 24);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(580, 25);
            this.previousButton.TabIndex = 1;
            this.previousButton.Text = "previousButton";
            // 
            // NewGrid
            // 
            this.NewGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewGrid.Image = ((System.Drawing.Image)(resources.GetObject("NewGrid.Image")));
            this.NewGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewGrid.Name = "NewGrid";
            this.NewGrid.Size = new System.Drawing.Size(23, 22);
            this.NewGrid.Text = "&New";
            this.NewGrid.Click += new System.EventHandler(this.NewGrid_Click);
            // 
            // openButton
            // 
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(23, 22);
            this.openButton.Text = "&Open";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(23, 22);
            this.saveButton.Text = "&Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // playButton
            // 
            this.playButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.playButton.Image = global::GameofLife_BrandonYates.Properties.Resources.Play;
            this.playButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(23, 22);
            this.playButton.Text = "Play";
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pauseButton.Image = global::GameofLife_BrandonYates.Properties.Resources.Pause;
            this.pauseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(23, 22);
            this.pauseButton.Text = "Pause";
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // previousButton1
            // 
            this.previousButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.previousButton1.Image = global::GameofLife_BrandonYates.Properties.Resources.Previous;
            this.previousButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.previousButton1.Name = "previousButton1";
            this.previousButton1.Size = new System.Drawing.Size(23, 22);
            this.previousButton1.Text = "Previous Generation";
            // 
            // nextButton
            // 
            this.nextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextButton.Image = global::GameofLife_BrandonYates.Properties.Resources.Next;
            this.nextButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(23, 22);
            this.nextButton.Text = "Next Generation";
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelGenerations,
            this.cellsAlive});
            this.statusStrip1.Location = new System.Drawing.Point(0, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(580, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelGenerations
            // 
            this.toolStripStatusLabelGenerations.Name = "toolStripStatusLabelGenerations";
            this.toolStripStatusLabelGenerations.Size = new System.Drawing.Size(90, 17);
            this.toolStripStatusLabelGenerations.Text = "Generations = 0";
            // 
            // cellsAlive
            // 
            this.cellsAlive.Name = "cellsAlive";
            this.cellsAlive.Size = new System.Drawing.Size(81, 17);
            this.cellsAlive.Text = "Cells Alive = 0";
            this.cellsAlive.Click += new System.EventHandler(this.cellsAlive_Click);
            // 
            // contextMenuRand
            // 
            this.contextMenuRand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rightClickRandom,
            this.rightClickColor});
            this.contextMenuRand.Name = "contextMenuRand";
            this.contextMenuRand.Size = new System.Drawing.Size(134, 48);
            this.contextMenuRand.Text = "Randomize";
            // 
            // rightClickRandom
            // 
            this.rightClickRandom.Name = "rightClickRandom";
            this.rightClickRandom.Size = new System.Drawing.Size(133, 22);
            this.rightClickRandom.Text = "Randomize";
            this.rightClickRandom.Click += new System.EventHandler(this.rightClickRandom_Click);
            // 
            // rightClickColor
            // 
            this.rightClickColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rightClickGrid,
            this.rightClickCell,
            this.rightClickBG});
            this.rightClickColor.Name = "rightClickColor";
            this.rightClickColor.Size = new System.Drawing.Size(133, 22);
            this.rightClickColor.Text = "Color";
            // 
            // rightClickGrid
            // 
            this.rightClickGrid.Name = "rightClickGrid";
            this.rightClickGrid.Size = new System.Drawing.Size(170, 22);
            this.rightClickGrid.Text = "Grid Color";
            this.rightClickGrid.Click += new System.EventHandler(this.rightClickGrid_Click);
            // 
            // rightClickCell
            // 
            this.rightClickCell.Name = "rightClickCell";
            this.rightClickCell.Size = new System.Drawing.Size(170, 22);
            this.rightClickCell.Text = "Cell Color";
            this.rightClickCell.Click += new System.EventHandler(this.rightClickCell_Click);
            // 
            // rightClickBG
            // 
            this.rightClickBG.Name = "rightClickBG";
            this.rightClickBG.Size = new System.Drawing.Size(170, 22);
            this.rightClickBG.Text = "Background Color";
            this.rightClickBG.Click += new System.EventHandler(this.rightClickBG_Click);
            // 
            // graphicsPanel1
            // 
            this.graphicsPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.graphicsPanel1.ContextMenuStrip = this.contextMenuRand;
            this.graphicsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsPanel1.Location = new System.Drawing.Point(0, 49);
            this.graphicsPanel1.Name = "graphicsPanel1";
            this.graphicsPanel1.Size = new System.Drawing.Size(580, 401);
            this.graphicsPanel1.TabIndex = 3;
            this.graphicsPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicsPanel1_Paint);
            this.graphicsPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphicsPanel1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(580, 472);
            this.Controls.Add(this.graphicsPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Game of Life";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.previousButton.ResumeLayout(false);
            this.previousButton.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuRand.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip previousButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private GraphicsPanel graphicsPanel1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileNew;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton NewGrid;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelGenerations;
        private System.Windows.Forms.ToolStripButton playButton;
        private System.Windows.Forms.ToolStripButton pauseButton;
        private System.Windows.Forms.ToolStripButton nextButton;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton previousButton1;
        private System.Windows.Forms.ToolStripStatusLabel cellsAlive;
        private System.Windows.Forms.ToolStripMenuItem randomSeed;
        private System.Windows.Forms.ToolStripMenuItem randomTime;
        private System.Windows.Forms.ToolStripMenuItem colorTool;
        private System.Windows.Forms.ToolStripMenuItem gridColorButton;
        private System.Windows.Forms.ToolStripMenuItem cellColorButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem resetButton;
        private System.Windows.Forms.ToolStripMenuItem reloadButton;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorTool;
        private System.Windows.Forms.ContextMenuStrip contextMenuRand;
        private System.Windows.Forms.ToolStripMenuItem rightClickRandom;
        private System.Windows.Forms.ToolStripMenuItem rightClickColor;
        private System.Windows.Forms.ToolStripMenuItem rightClickGrid;
        private System.Windows.Forms.ToolStripMenuItem rightClickCell;
        private System.Windows.Forms.ToolStripMenuItem rightClickBG;
        private System.Windows.Forms.ToolStripMenuItem gridAndTimeButton;
        private System.Windows.Forms.ToolStripMenuItem hUDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neighborCountToggle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem finiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toroidalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToggle;
    }
}

