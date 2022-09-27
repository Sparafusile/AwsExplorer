namespace Explorer
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbSettings = new System.Windows.Forms.ToolStripButton();
            this.tbAddFolder = new System.Windows.Forms.ToolStripButton();
            this.tbSync = new System.Windows.Forms.ToolStripButton();
            this.tbDownload = new System.Windows.Forms.ToolStripButton();
            this.tbUpload = new System.Windows.Forms.ToolStripButton();
            this.tbMoveFiles = new System.Windows.Forms.ToolStripDropDownButton();
            this.sameAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differentAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbCollapseAll = new System.Windows.Forms.ToolStripButton();
            this.tbViewLogs = new System.Windows.Forms.ToolStripButton();
            this.tbFontIncrease = new System.Windows.Forms.ToolStripButton();
            this.tbFontDecrease = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.cbFolder = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblModified = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHistory = new System.Windows.Forms.TextBox();
            this.btnSaveComments = new System.Windows.Forms.Button();
            this.treeViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.treeViewNodeDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewNodeShare = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewNodeRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.treeViewNodeDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.treeViewContextMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSettings,
            this.tbAddFolder,
            this.tbSync,
            this.tbDownload,
            this.tbUpload,
            this.tbMoveFiles,
            this.tbCollapseAll,
            this.tbViewLogs,
            this.tbFontIncrease,
            this.tbFontDecrease});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 40);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbSettings
            // 
            this.tbSettings.AutoSize = false;
            this.tbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSettings.Image = ((System.Drawing.Image)(resources.GetObject("tbSettings.Image")));
            this.tbSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSettings.Name = "tbSettings";
            this.tbSettings.Size = new System.Drawing.Size(36, 37);
            this.tbSettings.Text = "Settings";
            this.tbSettings.Click += new System.EventHandler(this.TbSettings_Click);
            // 
            // tbAddFolder
            // 
            this.tbAddFolder.AutoSize = false;
            this.tbAddFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAddFolder.Image = ((System.Drawing.Image)(resources.GetObject("tbAddFolder.Image")));
            this.tbAddFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAddFolder.Name = "tbAddFolder";
            this.tbAddFolder.Size = new System.Drawing.Size(37, 37);
            this.tbAddFolder.Text = "Add Folder";
            this.tbAddFolder.Click += new System.EventHandler(this.TbAddFolder_Click);
            // 
            // tbSync
            // 
            this.tbSync.AutoSize = false;
            this.tbSync.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSync.Enabled = false;
            this.tbSync.Image = ((System.Drawing.Image)(resources.GetObject("tbSync.Image")));
            this.tbSync.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbSync.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSync.Name = "tbSync";
            this.tbSync.Size = new System.Drawing.Size(37, 37);
            this.tbSync.Text = "Refresh Files";
            this.tbSync.Click += new System.EventHandler(this.TbSync_Click);
            // 
            // tbDownload
            // 
            this.tbDownload.AutoSize = false;
            this.tbDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDownload.Enabled = false;
            this.tbDownload.Image = ((System.Drawing.Image)(resources.GetObject("tbDownload.Image")));
            this.tbDownload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDownload.Name = "tbDownload";
            this.tbDownload.Size = new System.Drawing.Size(37, 37);
            this.tbDownload.Text = "Sync Files to Computer";
            this.tbDownload.Click += new System.EventHandler(this.TbDownload_Click);
            // 
            // tbUpload
            // 
            this.tbUpload.AutoSize = false;
            this.tbUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbUpload.Enabled = false;
            this.tbUpload.Image = ((System.Drawing.Image)(resources.GetObject("tbUpload.Image")));
            this.tbUpload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUpload.Name = "tbUpload";
            this.tbUpload.Size = new System.Drawing.Size(37, 37);
            this.tbUpload.Text = "Sync Files to Cloud";
            this.tbUpload.Click += new System.EventHandler(this.TbUpload_Click);
            // 
            // tbMoveFiles
            // 
            this.tbMoveFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbMoveFiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sameAccountToolStripMenuItem,
            this.differentAccountToolStripMenuItem});
            this.tbMoveFiles.Enabled = false;
            this.tbMoveFiles.Image = ((System.Drawing.Image)(resources.GetObject("tbMoveFiles.Image")));
            this.tbMoveFiles.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbMoveFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbMoveFiles.Name = "tbMoveFiles";
            this.tbMoveFiles.Size = new System.Drawing.Size(37, 37);
            this.tbMoveFiles.Text = "Move Files to Another Bucket";
            // 
            // sameAccountToolStripMenuItem
            // 
            this.sameAccountToolStripMenuItem.Name = "sameAccountToolStripMenuItem";
            this.sameAccountToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sameAccountToolStripMenuItem.Text = "Same Account";
            this.sameAccountToolStripMenuItem.Click += new System.EventHandler(this.TbMoveBucket_Click);
            // 
            // differentAccountToolStripMenuItem
            // 
            this.differentAccountToolStripMenuItem.Name = "differentAccountToolStripMenuItem";
            this.differentAccountToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.differentAccountToolStripMenuItem.Text = "Different Account";
            this.differentAccountToolStripMenuItem.Click += new System.EventHandler(this.TbMoveAccount_Click);
            // 
            // tbCollapseAll
            // 
            this.tbCollapseAll.AutoSize = false;
            this.tbCollapseAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCollapseAll.Enabled = false;
            this.tbCollapseAll.Image = ((System.Drawing.Image)(resources.GetObject("tbCollapseAll.Image")));
            this.tbCollapseAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbCollapseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCollapseAll.Name = "tbCollapseAll";
            this.tbCollapseAll.Size = new System.Drawing.Size(37, 37);
            this.tbCollapseAll.Text = "Collapse All";
            this.tbCollapseAll.Click += new System.EventHandler(this.TbCollapseAll_Click);
            // 
            // tbViewLogs
            // 
            this.tbViewLogs.AutoSize = false;
            this.tbViewLogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbViewLogs.Image = ((System.Drawing.Image)(resources.GetObject("tbViewLogs.Image")));
            this.tbViewLogs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbViewLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbViewLogs.Name = "tbViewLogs";
            this.tbViewLogs.Size = new System.Drawing.Size(37, 37);
            this.tbViewLogs.Text = "View Log";
            this.tbViewLogs.Click += new System.EventHandler(this.TbViewLogs_Click);
            // 
            // tbFontIncrease
            // 
            this.tbFontIncrease.AutoSize = false;
            this.tbFontIncrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbFontIncrease.Image = ((System.Drawing.Image)(resources.GetObject("tbFontIncrease.Image")));
            this.tbFontIncrease.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbFontIncrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbFontIncrease.Name = "tbFontIncrease";
            this.tbFontIncrease.Size = new System.Drawing.Size(37, 37);
            this.tbFontIncrease.Text = "Increase Font Size";
            this.tbFontIncrease.Visible = false;
            this.tbFontIncrease.Click += new System.EventHandler(this.TbFontIncrease_Click);
            // 
            // tbFontDecrease
            // 
            this.tbFontDecrease.AutoSize = false;
            this.tbFontDecrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbFontDecrease.Image = ((System.Drawing.Image)(resources.GetObject("tbFontDecrease.Image")));
            this.tbFontDecrease.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbFontDecrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbFontDecrease.Name = "tbFontDecrease";
            this.tbFontDecrease.Size = new System.Drawing.Size(37, 37);
            this.tbFontDecrease.Text = "Decrease Font Size";
            this.tbFontDecrease.Visible = false;
            this.tbFontDecrease.Click += new System.EventHandler(this.TbFontDecrease_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer.Size = new System.Drawing.Size(800, 393);
            this.splitContainer.SplitterDistance = 389;
            this.splitContainer.TabIndex = 1;
            this.splitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer_SplitterMoved);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.treeView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbFolder, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(389, 393);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.HideSelection = false;
            this.treeView.Location = new System.Drawing.Point(3, 33);
            this.treeView.Name = "treeView";
            this.treeView.PathSeparator = "/";
            this.treeView.Size = new System.Drawing.Size(383, 357);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            this.treeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.TreeView_DragDrop);
            this.treeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.TreeView_DragEnter);
            this.treeView.DragOver += new System.Windows.Forms.DragEventHandler(this.TreeView_DragOver);
            this.treeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TreeView_MouseUp);
            // 
            // cbFolder
            // 
            this.cbFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFolder.FormattingEnabled = true;
            this.cbFolder.Location = new System.Drawing.Point(3, 4);
            this.cbFolder.Name = "cbFolder";
            this.cbFolder.Size = new System.Drawing.Size(383, 23);
            this.cbFolder.TabIndex = 1;
            this.cbFolder.SelectedIndexChanged += new System.EventHandler(this.CbFolder_SelectedIndexChanged);
            this.cbFolder.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CbFolder_KeyUp);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblModified, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblSize, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblKey, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtComments, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.txtHistory, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.btnSaveComments, 0, 8);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(407, 393);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblModified
            // 
            this.lblModified.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModified.AutoSize = true;
            this.lblModified.Location = new System.Drawing.Point(153, 55);
            this.lblModified.Name = "lblModified";
            this.lblModified.Size = new System.Drawing.Size(251, 15);
            this.lblModified.TabIndex = 5;
            // 
            // lblSize
            // 
            this.lblSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(153, 30);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(251, 15);
            this.lblSize.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Size";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Modified";
            // 
            // lblKey
            // 
            this.lblKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(153, 5);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(251, 15);
            this.lblKey.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Comments";
            // 
            // txtComments
            // 
            this.txtComments.AcceptsReturn = true;
            this.tableLayoutPanel2.SetColumnSpan(this.txtComments, 2);
            this.txtComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComments.Location = new System.Drawing.Point(3, 113);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComments.Size = new System.Drawing.Size(401, 100);
            this.txtComments.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "History";
            // 
            // txtHistory
            // 
            this.txtHistory.AcceptsReturn = true;
            this.tableLayoutPanel2.SetColumnSpan(this.txtHistory, 2);
            this.txtHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHistory.Location = new System.Drawing.Point(3, 239);
            this.txtHistory.Multiline = true;
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ReadOnly = true;
            this.txtHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHistory.Size = new System.Drawing.Size(401, 100);
            this.txtHistory.TabIndex = 9;
            this.txtHistory.WordWrap = false;
            this.txtHistory.Click += new System.EventHandler(this.TxtHistory_Click);
            // 
            // btnSaveComments
            // 
            this.btnSaveComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.btnSaveComments, 2);
            this.btnSaveComments.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveComments.Image")));
            this.btnSaveComments.Location = new System.Drawing.Point(3, 350);
            this.btnSaveComments.Name = "btnSaveComments";
            this.btnSaveComments.Size = new System.Drawing.Size(401, 35);
            this.btnSaveComments.TabIndex = 10;
            this.btnSaveComments.Text = "Save Changes";
            this.btnSaveComments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveComments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveComments.UseVisualStyleBackColor = true;
            this.btnSaveComments.Click += new System.EventHandler(this.BtnSaveComments_Click);
            // 
            // treeViewContextMenu
            // 
            this.treeViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.treeViewNodeDownload,
            this.treeViewNodeShare,
            this.treeViewNodeRename,
            this.toolStripMenuItem1,
            this.treeViewNodeDelete});
            this.treeViewContextMenu.Name = "treeViewContextMenu";
            this.treeViewContextMenu.Size = new System.Drawing.Size(138, 98);
            // 
            // treeViewNodeDownload
            // 
            this.treeViewNodeDownload.Name = "treeViewNodeDownload";
            this.treeViewNodeDownload.Size = new System.Drawing.Size(137, 22);
            this.treeViewNodeDownload.Text = "Download...";
            this.treeViewNodeDownload.Click += new System.EventHandler(this.TreeViewNodeDownload_Click);
            // 
            // treeViewNodeShare
            // 
            this.treeViewNodeShare.Name = "treeViewNodeShare";
            this.treeViewNodeShare.Size = new System.Drawing.Size(137, 22);
            this.treeViewNodeShare.Text = "Share...";
            this.treeViewNodeShare.Click += new System.EventHandler(this.TreeViewNodeShare_Click);
            // 
            // treeViewNodeRename
            // 
            this.treeViewNodeRename.Name = "treeViewNodeRename";
            this.treeViewNodeRename.Size = new System.Drawing.Size(137, 22);
            this.treeViewNodeRename.Text = "Rename...";
            this.treeViewNodeRename.Click += new System.EventHandler(this.TreeViewNodeRename_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 6);
            // 
            // treeViewNodeDelete
            // 
            this.treeViewNodeDelete.Name = "treeViewNodeDelete";
            this.treeViewNodeDelete.Size = new System.Drawing.Size(137, 22);
            this.treeViewNodeDelete.Text = "Delete";
            this.treeViewNodeDelete.Click += new System.EventHandler(this.TreeViewNodeDelete_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.pbProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 433);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(563, 17);
            this.lblStatus.Spring = true;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbProgress
            // 
            this.pbProgress.Margin = new System.Windows.Forms.Padding(1, 3, 11, 3);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(200, 16);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 393);
            this.panel1.TabIndex = 3;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "AWS File Explorer";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 455);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "AWS File Explorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResizeEnd += new System.EventHandler(this.Main_ResizeEnd);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.treeViewContextMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private SplitContainer splitContainer;
        private TableLayoutPanel tableLayoutPanel1;
        private TreeView treeView;
        private ComboBox cbFolder;
        private ToolStripButton tbFontDecrease;
        private ToolStripButton tbSettings;
        private ToolStripButton tbAddFolder;
        private ToolStripButton tbDownload;
        private ToolStripButton tbViewLogs;
        private ToolStripButton tbFontIncrease;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblModified;
        private Label lblSize;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblKey;
        private Label label4;
        private TextBox txtComments;
        private Label label5;
        private TextBox txtHistory;
        private ContextMenuStrip treeViewContextMenu;
        private ToolStripMenuItem treeViewNodeDownload;
        private ToolStripMenuItem treeViewNodeRename;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem treeViewNodeDelete;
        private Button btnSaveComments;
        private ToolStripMenuItem treeViewNodeShare;
        private StatusStrip statusStrip1;
        private Panel panel1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripProgressBar pbProgress;
        private ToolStripButton tbSync;
        private ToolStripButton tbUpload;
        private ToolStripButton tbCollapseAll;
        private NotifyIcon notifyIcon;
        private ToolStripDropDownButton tbMoveFiles;
        private ToolStripMenuItem sameAccountToolStripMenuItem;
        private ToolStripMenuItem differentAccountToolStripMenuItem;
    }
}