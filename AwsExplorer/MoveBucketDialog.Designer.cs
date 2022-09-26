namespace AwsExplorer
{
    partial class MoveBucketDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveBucketDialog));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddBucket = new System.Windows.Forms.Button();
            this.btnRefreshBuckets = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRemoteBucket = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOkay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDestinationPrefix = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbCopy = new System.Windows.Forms.RadioButton();
            this.rbMove = new System.Windows.Forms.RadioButton();
            this.cbSourcePrefix = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Controls.Add(this.btnAddBucket, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnRefreshBuckets, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbRemoteBucket, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDestinationPrefix, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbSourcePrefix, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(395, 195);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnAddBucket
            // 
            this.btnAddBucket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddBucket.Image = ((System.Drawing.Image)(resources.GetObject("btnAddBucket.Image")));
            this.btnAddBucket.Location = new System.Drawing.Point(358, 38);
            this.btnAddBucket.Name = "btnAddBucket";
            this.btnAddBucket.Size = new System.Drawing.Size(34, 29);
            this.btnAddBucket.TabIndex = 23;
            this.btnAddBucket.UseVisualStyleBackColor = true;
            this.btnAddBucket.Click += new System.EventHandler(this.BtnAddBucket_Click);
            // 
            // btnRefreshBuckets
            // 
            this.btnRefreshBuckets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefreshBuckets.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshBuckets.Image")));
            this.btnRefreshBuckets.Location = new System.Drawing.Point(318, 38);
            this.btnRefreshBuckets.Name = "btnRefreshBuckets";
            this.btnRefreshBuckets.Size = new System.Drawing.Size(34, 29);
            this.btnRefreshBuckets.TabIndex = 22;
            this.btnRefreshBuckets.UseVisualStyleBackColor = true;
            this.btnRefreshBuckets.Click += new System.EventHandler(this.LoadBuckets);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Destination Bucket";
            // 
            // cbRemoteBucket
            // 
            this.cbRemoteBucket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRemoteBucket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRemoteBucket.FormattingEnabled = true;
            this.cbRemoteBucket.Location = new System.Drawing.Point(123, 41);
            this.cbRemoteBucket.Name = "cbRemoteBucket";
            this.cbRemoteBucket.Size = new System.Drawing.Size(189, 23);
            this.cbRemoteBucket.Sorted = true;
            this.cbRemoteBucket.TabIndex = 17;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 4);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnOkay, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 143);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(389, 49);
            this.tableLayoutPanel2.TabIndex = 24;
            // 
            // btnOkay
            // 
            this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkay.Image = ((System.Drawing.Image)(resources.GetObject("btnOkay.Image")));
            this.btnOkay.Location = new System.Drawing.Point(214, 6);
            this.btnOkay.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(155, 37);
            this.btnOkay.TabIndex = 2;
            this.btnOkay.Text = "Okay";
            this.btnOkay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOkay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.BtnOkay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(20, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(154, 37);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Source Prefix";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "Destination Prefix";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "Copy or Move?";
            // 
            // txtDestinationPrefix
            // 
            this.txtDestinationPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtDestinationPrefix, 3);
            this.txtDestinationPrefix.Location = new System.Drawing.Point(123, 76);
            this.txtDestinationPrefix.Name = "txtDestinationPrefix";
            this.txtDestinationPrefix.Size = new System.Drawing.Size(269, 23);
            this.txtDestinationPrefix.TabIndex = 29;
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 3);
            this.flowLayoutPanel1.Controls.Add(this.rbCopy);
            this.flowLayoutPanel1.Controls.Add(this.rbMove);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(123, 108);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(269, 29);
            this.flowLayoutPanel1.TabIndex = 30;
            // 
            // rbCopy
            // 
            this.rbCopy.AutoSize = true;
            this.rbCopy.Checked = true;
            this.rbCopy.Location = new System.Drawing.Point(3, 3);
            this.rbCopy.Name = "rbCopy";
            this.rbCopy.Size = new System.Drawing.Size(79, 19);
            this.rbCopy.TabIndex = 0;
            this.rbCopy.TabStop = true;
            this.rbCopy.Text = "Copy Files";
            this.rbCopy.UseVisualStyleBackColor = true;
            // 
            // rbMove
            // 
            this.rbMove.AutoSize = true;
            this.rbMove.Location = new System.Drawing.Point(88, 3);
            this.rbMove.Name = "rbMove";
            this.rbMove.Size = new System.Drawing.Size(81, 19);
            this.rbMove.TabIndex = 1;
            this.rbMove.Text = "Move Files";
            this.rbMove.UseVisualStyleBackColor = true;
            // 
            // cbSourcePrefix
            // 
            this.cbSourcePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cbSourcePrefix, 3);
            this.cbSourcePrefix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourcePrefix.FormattingEnabled = true;
            this.cbSourcePrefix.Location = new System.Drawing.Point(123, 6);
            this.cbSourcePrefix.Name = "cbSourcePrefix";
            this.cbSourcePrefix.Size = new System.Drawing.Size(269, 23);
            this.cbSourcePrefix.TabIndex = 31;
            this.cbSourcePrefix.SelectedIndexChanged += new System.EventHandler(this.CbSourcePrefix_SelectedIndexChanged);
            // 
            // MoveBucketDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 195);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MoveBucketDialog";
            this.Text = "Copying Files to Another Bucket";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private ComboBox cbRemoteBucket;
        private Button btnRefreshBuckets;
        private Button btnAddBucket;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnCancel;
        private Button btnOkay;
        private Label label1;
        private Label label2;
        private Label label4;
        private TextBox txtDestinationPrefix;
        private FlowLayoutPanel flowLayoutPanel1;
        private RadioButton rbCopy;
        private RadioButton rbMove;
        private ComboBox cbSourcePrefix;
    }
}