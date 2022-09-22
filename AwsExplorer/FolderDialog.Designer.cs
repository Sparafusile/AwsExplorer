namespace Explorer
{
    partial class FolderDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderDialog));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtAwsAccessKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAwsSecretKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbOptions = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFilePrefix = new System.Windows.Forms.TextBox();
            this.btnRefreshBuckets = new System.Windows.Forms.Button();
            this.btnAddBucket = new System.Windows.Forms.Button();
            this.cbRemoteBucket = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRegion = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Controls.Add(this.txtAwsAccessKey, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtAwsSecretKey, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbOptions, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtFilePrefix, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnRefreshBuckets, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAddBucket, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbRemoteBucket, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbRegion, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(414, 272);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtAwsAccessKey
            // 
            this.txtAwsAccessKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtAwsAccessKey, 3);
            this.txtAwsAccessKey.Location = new System.Drawing.Point(129, 12);
            this.txtAwsAccessKey.Name = "txtAwsAccessKey";
            this.txtAwsAccessKey.Size = new System.Drawing.Size(276, 23);
            this.txtAwsAccessKey.TabIndex = 6;
            this.toolTip.SetToolTip(this.txtAwsAccessKey, "The AWS access key used to access the bucket.");
            this.txtAwsAccessKey.Leave += new System.EventHandler(this.loadBuckets);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "AWS Access Key";
            this.toolTip.SetToolTip(this.label1, "The AWS access key used to access the bucket.");
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "AWS Secret Key";
            this.toolTip.SetToolTip(this.label2, "The AWS secret key used to access the bucket.");
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Remote Bucket";
            this.toolTip.SetToolTip(this.label3, "The name of the bucket to be used to transfer files.");
            // 
            // txtAwsSecretKey
            // 
            this.txtAwsSecretKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtAwsSecretKey, 3);
            this.txtAwsSecretKey.Location = new System.Drawing.Point(129, 47);
            this.txtAwsSecretKey.Name = "txtAwsSecretKey";
            this.txtAwsSecretKey.Size = new System.Drawing.Size(276, 23);
            this.txtAwsSecretKey.TabIndex = 7;
            this.toolTip.SetToolTip(this.txtAwsSecretKey, "The AWS secret key used to access the bucket.");
            this.txtAwsSecretKey.UseSystemPasswordChar = true;
            this.txtAwsSecretKey.Leave += new System.EventHandler(this.loadBuckets);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Options";
            this.toolTip.SetToolTip(this.label5, "If this option is selected, a .dat file will be created next to each file in the " +
        "bucket. This file will contain meta data about the file including comments and h" +
        "istory.");
            // 
            // cbOptions
            // 
            this.cbOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOptions.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.cbOptions, 3);
            this.cbOptions.Location = new System.Drawing.Point(129, 189);
            this.cbOptions.Name = "cbOptions";
            this.cbOptions.Size = new System.Drawing.Size(276, 19);
            this.cbOptions.TabIndex = 9;
            this.cbOptions.Text = "Track file comments and history";
            this.toolTip.SetToolTip(this.cbOptions, "If this option is selected, a .dat file will be created next to each file in the " +
        "bucket. This file will contain meta data about the file including comments and h" +
        "istory.");
            this.cbOptions.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 4);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnOkay, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(9, 219);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(396, 44);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(20, 3);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(158, 37);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOkay
            // 
            this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkay.Image = ((System.Drawing.Image)(resources.GetObject("btnOkay.Image")));
            this.btnOkay.Location = new System.Drawing.Point(218, 3);
            this.btnOkay.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(158, 37);
            this.btnOkay.TabIndex = 1;
            this.btnOkay.Text = "Okay";
            this.btnOkay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOkay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "File Prefix";
            this.toolTip.SetToolTip(this.label6, "(Optional) A prefix to prepend all files with.");
            // 
            // txtFilePrefix
            // 
            this.txtFilePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtFilePrefix, 3);
            this.txtFilePrefix.Location = new System.Drawing.Point(129, 152);
            this.txtFilePrefix.Name = "txtFilePrefix";
            this.txtFilePrefix.Size = new System.Drawing.Size(276, 23);
            this.txtFilePrefix.TabIndex = 13;
            this.toolTip.SetToolTip(this.txtFilePrefix, "(Optional) A prefix to prepend all files with.");
            // 
            // btnRefreshBuckets
            // 
            this.btnRefreshBuckets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefreshBuckets.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshBuckets.Image")));
            this.btnRefreshBuckets.Location = new System.Drawing.Point(331, 114);
            this.btnRefreshBuckets.Name = "btnRefreshBuckets";
            this.btnRefreshBuckets.Size = new System.Drawing.Size(34, 29);
            this.btnRefreshBuckets.TabIndex = 14;
            this.toolTip.SetToolTip(this.btnRefreshBuckets, "Refresh the bucket list");
            this.btnRefreshBuckets.UseVisualStyleBackColor = true;
            this.btnRefreshBuckets.Click += new System.EventHandler(this.loadBuckets);
            // 
            // btnAddBucket
            // 
            this.btnAddBucket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddBucket.Image = ((System.Drawing.Image)(resources.GetObject("btnAddBucket.Image")));
            this.btnAddBucket.Location = new System.Drawing.Point(371, 114);
            this.btnAddBucket.Name = "btnAddBucket";
            this.btnAddBucket.Size = new System.Drawing.Size(34, 29);
            this.btnAddBucket.TabIndex = 15;
            this.toolTip.SetToolTip(this.btnAddBucket, "Create a new bucket");
            this.btnAddBucket.UseVisualStyleBackColor = true;
            this.btnAddBucket.Click += new System.EventHandler(this.btnAddBucket_Click);
            // 
            // cbRemoteBucket
            // 
            this.cbRemoteBucket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRemoteBucket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRemoteBucket.FormattingEnabled = true;
            this.cbRemoteBucket.Location = new System.Drawing.Point(129, 117);
            this.cbRemoteBucket.Name = "cbRemoteBucket";
            this.cbRemoteBucket.Size = new System.Drawing.Size(196, 23);
            this.cbRemoteBucket.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "AWS Region";
            // 
            // cbRegion
            // 
            this.cbRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cbRegion, 3);
            this.cbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegion.FormattingEnabled = true;
            this.cbRegion.Location = new System.Drawing.Point(129, 82);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(276, 23);
            this.cbRegion.TabIndex = 18;
            this.cbRegion.SelectedIndexChanged += new System.EventHandler(this.loadBuckets);
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // FolderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 272);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FolderDialog";
            this.Text = "Bucket Settings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox txtAwsAccessKey;
        private Label label2;
        private Label label3;
        private TextBox txtAwsSecretKey;
        private Label label5;
        private CheckBox cbOptions;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnCancel;
        private Button btnOkay;
        private Label label6;
        private TextBox txtFilePrefix;
        private ToolTip toolTip;
        private Button btnRefreshBuckets;
        private Button btnAddBucket;
        private ComboBox cbRemoteBucket;
        private Label label4;
        private ComboBox cbRegion;
    }
}