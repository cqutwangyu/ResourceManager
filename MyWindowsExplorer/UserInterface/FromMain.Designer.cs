using System.Windows.Forms;

namespace MyWindowsExplorer
{
    partial class FromMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FromMain));
            this.treeView = new System.Windows.Forms.TreeView();
            this.treeImageList = new System.Windows.Forms.ImageList(this.components);
            this.largeIconImageList = new System.Windows.Forms.ImageList(this.components);
            this.head = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.curPathText = new System.Windows.Forms.TextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.leftPathButton = new System.Windows.Forms.ToolStripButton();
            this.rightPathButton = new System.Windows.Forms.ToolStripButton();
            this.backUpPathButton = new System.Windows.Forms.ToolStripButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.viewModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconShowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconShowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsShowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listShowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Body = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listView = new System.Windows.Forms.ListView();
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.foot = new System.Windows.Forms.Panel();
            this.fileCountText = new System.Windows.Forms.Label();
            this.folderCheckBox = new System.Windows.Forms.CheckBox();
            this.fileCheckBox = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.head.SuspendLayout();
            this.panel5.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.panel4.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.foot.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.ContextMenuStrip = this.contextMenuStrip;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.treeImageList;
            this.treeView.ItemHeight = 16;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.MinimumSize = new System.Drawing.Size(200, 200);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(215, 463);
            this.treeView.TabIndex = 2;
            this.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewNodeBeforeExpand);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewNodeAfterSelect);
            // 
            // treeImageList
            // 
            this.treeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImageList.ImageStream")));
            this.treeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImageList.Images.SetKeyName(0, "此电脑.png");
            this.treeImageList.Images.SetKeyName(1, "disk.png");
            this.treeImageList.Images.SetKeyName(2, "folder.png");
            this.treeImageList.Images.SetKeyName(3, "file.jpg");
            // 
            // largeIconImageList
            // 
            this.largeIconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("largeIconImageList.ImageStream")));
            this.largeIconImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.largeIconImageList.Images.SetKeyName(0, "此电脑.png");
            this.largeIconImageList.Images.SetKeyName(1, "disk.png");
            this.largeIconImageList.Images.SetKeyName(2, "folder.png");
            this.largeIconImageList.Images.SetKeyName(3, "file.jpg");
            // 
            // head
            // 
            this.head.Controls.Add(this.panel5);
            this.head.Controls.Add(this.panel4);
            this.head.Dock = System.Windows.Forms.DockStyle.Top;
            this.head.Location = new System.Drawing.Point(0, 0);
            this.head.Name = "head";
            this.head.Size = new System.Drawing.Size(1066, 72);
            this.head.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.curPathText);
            this.panel5.Controls.Add(this.toolStrip);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 37);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1066, 35);
            this.panel5.TabIndex = 1;
            // 
            // curPathText
            // 
            this.curPathText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.curPathText.Location = new System.Drawing.Point(111, 2);
            this.curPathText.Name = "curPathText";
            this.curPathText.Size = new System.Drawing.Size(943, 25);
            this.curPathText.TabIndex = 1;
            this.curPathText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.curPathText_KeyDown);
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftPathButton,
            this.rightPathButton,
            this.backUpPathButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1066, 27);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // leftPathButton
            // 
            this.leftPathButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.leftPathButton.Enabled = false;
            this.leftPathButton.Image = ((System.Drawing.Image)(resources.GetObject("leftPathButton.Image")));
            this.leftPathButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.leftPathButton.Name = "leftPathButton";
            this.leftPathButton.Size = new System.Drawing.Size(24, 24);
            this.leftPathButton.Text = "后退";
            this.leftPathButton.Click += new System.EventHandler(this.leftPath_Click);
            // 
            // rightPathButton
            // 
            this.rightPathButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rightPathButton.Enabled = false;
            this.rightPathButton.Image = ((System.Drawing.Image)(resources.GetObject("rightPathButton.Image")));
            this.rightPathButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rightPathButton.Name = "rightPathButton";
            this.rightPathButton.Size = new System.Drawing.Size(24, 24);
            this.rightPathButton.Text = "前进";
            this.rightPathButton.Click += new System.EventHandler(this.rightPath_Click);
            // 
            // backUpPathButton
            // 
            this.backUpPathButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backUpPathButton.Enabled = false;
            this.backUpPathButton.Image = ((System.Drawing.Image)(resources.GetObject("backUpPathButton.Image")));
            this.backUpPathButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backUpPathButton.Name = "backUpPathButton";
            this.backUpPathButton.Size = new System.Drawing.Size(24, 24);
            this.backUpPathButton.Text = "上一级";
            this.backUpPathButton.Click += new System.EventHandler(this.backUp_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.menuStrip);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1066, 31);
            this.panel4.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewModeMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1066, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // viewModeMenuItem
            // 
            this.viewModeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconShowMenuItem,
            this.smallIconShowMenuItem,
            this.detailsShowMenuItem,
            this.listShowMenuItem});
            this.viewModeMenuItem.Name = "viewModeMenuItem";
            this.viewModeMenuItem.Size = new System.Drawing.Size(51, 24);
            this.viewModeMenuItem.Text = "查看";
            // 
            // largeIconShowMenuItem
            // 
            this.largeIconShowMenuItem.Name = "largeIconShowMenuItem";
            this.largeIconShowMenuItem.Size = new System.Drawing.Size(144, 26);
            this.largeIconShowMenuItem.Text = "大图标";
            this.largeIconShowMenuItem.Click += new System.EventHandler(this.largeIconShowMenuItem_Click);
            // 
            // smallIconShowMenuItem
            // 
            this.smallIconShowMenuItem.Name = "smallIconShowMenuItem";
            this.smallIconShowMenuItem.Size = new System.Drawing.Size(144, 26);
            this.smallIconShowMenuItem.Text = "小图标";
            this.smallIconShowMenuItem.Click += new System.EventHandler(this.smallIconShowMenuItem_Click);
            // 
            // detailsShowMenuItem
            // 
            this.detailsShowMenuItem.Name = "detailsShowMenuItem";
            this.detailsShowMenuItem.Size = new System.Drawing.Size(144, 26);
            this.detailsShowMenuItem.Text = "详细信息";
            this.detailsShowMenuItem.Click += new System.EventHandler(this.detailsShowMenuItem_Click);
            // 
            // listShowMenuItem
            // 
            this.listShowMenuItem.Name = "listShowMenuItem";
            this.listShowMenuItem.Size = new System.Drawing.Size(144, 26);
            this.listShowMenuItem.Text = "列表";
            this.listShowMenuItem.Click += new System.EventHandler(this.listShowMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Body);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1066, 463);
            this.panel2.TabIndex = 3;
            // 
            // Body
            // 
            this.Body.Controls.Add(this.splitContainer);
            this.Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Body.Location = new System.Drawing.Point(0, 0);
            this.Body.Name = "Body";
            this.Body.Size = new System.Drawing.Size(1066, 463);
            this.Body.TabIndex = 2;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.listView);
            this.splitContainer.Size = new System.Drawing.Size(1066, 463);
            this.splitContainer.SplitterDistance = 215;
            this.splitContainer.TabIndex = 2;
            // 
            // listView
            // 
            this.listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.LargeImageList = this.largeIconImageList;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MinimumSize = new System.Drawing.Size(300, 300);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(847, 463);
            this.listView.SmallImageList = this.smallImageList;
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.listViewFileDoubleClick);
            // 
            // smallImageList
            // 
            this.smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImageList.ImageStream")));
            this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.smallImageList.Images.SetKeyName(0, "此电脑.png");
            this.smallImageList.Images.SetKeyName(1, "disk.png");
            this.smallImageList.Images.SetKeyName(2, "folder.png");
            this.smallImageList.Images.SetKeyName(3, "file.jpg");
            // 
            // foot
            // 
            this.foot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foot.Controls.Add(this.fileCountText);
            this.foot.Controls.Add(this.folderCheckBox);
            this.foot.Controls.Add(this.fileCheckBox);
            this.foot.Location = new System.Drawing.Point(0, 508);
            this.foot.Name = "foot";
            this.foot.Size = new System.Drawing.Size(1066, 27);
            this.foot.TabIndex = 4;
            // 
            // fileCountText
            // 
            this.fileCountText.AutoSize = true;
            this.fileCountText.Location = new System.Drawing.Point(13, 9);
            this.fileCountText.Name = "fileCountText";
            this.fileCountText.Size = new System.Drawing.Size(55, 15);
            this.fileCountText.TabIndex = 2;
            this.fileCountText.Text = "label1";
            // 
            // folderCheckBox
            // 
            this.folderCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.folderCheckBox.AutoSize = true;
            this.folderCheckBox.Checked = true;
            this.folderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.folderCheckBox.Location = new System.Drawing.Point(855, 5);
            this.folderCheckBox.Name = "folderCheckBox";
            this.folderCheckBox.Size = new System.Drawing.Size(104, 19);
            this.folderCheckBox.TabIndex = 1;
            this.folderCheckBox.Text = "显示文件夹";
            this.folderCheckBox.UseVisualStyleBackColor = true;
            this.folderCheckBox.CheckedChanged += new System.EventHandler(this.folderCheckBox_CheckedChanged);
            // 
            // fileCheckBox
            // 
            this.fileCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileCheckBox.AutoSize = true;
            this.fileCheckBox.Checked = true;
            this.fileCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fileCheckBox.Location = new System.Drawing.Point(965, 5);
            this.fileCheckBox.Name = "fileCheckBox";
            this.fileCheckBox.Size = new System.Drawing.Size(89, 19);
            this.fileCheckBox.TabIndex = 0;
            this.fileCheckBox.Text = "显示文件";
            this.fileCheckBox.UseVisualStyleBackColor = true;
            this.fileCheckBox.CheckedChanged += new System.EventHandler(this.fileCheckBox_CheckedChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重命名ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.新建ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(124, 100);
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.重命名ToolStripMenuItem.Text = "重命名";
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.复制ToolStripMenuItem.Text = "复制";
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.文件ToolStripMenuItem1});
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.新建ToolStripMenuItem.Text = "新建";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.文件ToolStripMenuItem.Text = "文件夹";
            // 
            // 文件ToolStripMenuItem1
            // 
            this.文件ToolStripMenuItem1.Name = "文件ToolStripMenuItem1";
            this.文件ToolStripMenuItem1.Size = new System.Drawing.Size(216, 26);
            this.文件ToolStripMenuItem1.Text = "文件";
            // 
            // FromMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 535);
            this.Controls.Add(this.foot);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.head);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FromMain";
            this.Text = "资源小管家";
            this.Load += new System.EventHandler(this.fromMain_Load);
            this.head.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.Body.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.foot.ResumeLayout(false);
            this.foot.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Panel head;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel foot;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Panel Body;
        private System.Windows.Forms.ImageList largeIconImageList;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ToolStripButton leftPathButton;
        private System.Windows.Forms.ToolStripButton rightPathButton;
        private System.Windows.Forms.ToolStripButton backUpPathButton;
        private System.Windows.Forms.TextBox curPathText;
        private System.Windows.Forms.ToolStripMenuItem viewModeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeIconShowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallIconShowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsShowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listShowMenuItem;
        private System.Windows.Forms.ImageList treeImageList;
        private ImageList smallImageList;
        private CheckBox folderCheckBox;
        private CheckBox fileCheckBox;
        private Label fileCountText;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem 重命名ToolStripMenuItem;
        private ToolStripMenuItem 复制ToolStripMenuItem;
        private ToolStripMenuItem 粘贴ToolStripMenuItem;
        private ToolStripMenuItem 新建ToolStripMenuItem;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem 文件ToolStripMenuItem1;
    }
}

