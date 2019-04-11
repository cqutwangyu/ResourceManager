﻿namespace MyWindowsExplorer
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
            this.TreeView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.head = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.panel4 = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.其他ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Body = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.ListView = new System.Windows.Forms.ListView();
            this.foot = new System.Windows.Forms.Panel();
            this.leftPathButton = new System.Windows.Forms.ToolStripButton();
            this.rightPathButton = new System.Windows.Forms.ToolStripButton();
            this.backUpPathButton = new System.Windows.Forms.ToolStripButton();
            this.curPathText = new System.Windows.Forms.TextBox();
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
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView.ImageIndex = 0;
            this.TreeView.ImageList = this.imageList;
            this.TreeView.Location = new System.Drawing.Point(0, 0);
            this.TreeView.MinimumSize = new System.Drawing.Size(200, 200);
            this.TreeView.Name = "TreeView";
            this.TreeView.SelectedImageIndex = 0;
            this.TreeView.Size = new System.Drawing.Size(200, 378);
            this.TreeView.TabIndex = 2;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewFile_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "此电脑.png");
            this.imageList.Images.SetKeyName(1, "disk.png");
            this.imageList.Images.SetKeyName(2, "folder.png");
            this.imageList.Images.SetKeyName(3, "file.jpg");
            // 
            // head
            // 
            this.head.Controls.Add(this.panel5);
            this.head.Controls.Add(this.panel4);
            this.head.Dock = System.Windows.Forms.DockStyle.Top;
            this.head.Location = new System.Drawing.Point(0, 0);
            this.head.Name = "head";
            this.head.Size = new System.Drawing.Size(800, 72);
            this.head.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.curPathText);
            this.panel5.Controls.Add(this.toolStrip);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 37);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(800, 35);
            this.panel5.TabIndex = 1;
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
            this.toolStrip.Size = new System.Drawing.Size(800, 27);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.menuStrip);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 31);
            this.panel4.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.其他ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 其他ToolStripMenuItem
            // 
            this.其他ToolStripMenuItem.Name = "其他ToolStripMenuItem";
            this.其他ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.其他ToolStripMenuItem.Text = "其他";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Body);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 378);
            this.panel2.TabIndex = 3;
            // 
            // Body
            // 
            this.Body.Controls.Add(this.splitContainer);
            this.Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Body.Location = new System.Drawing.Point(0, 0);
            this.Body.Name = "Body";
            this.Body.Size = new System.Drawing.Size(800, 378);
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
            this.splitContainer.Panel1.Controls.Add(this.TreeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.ListView);
            this.splitContainer.Size = new System.Drawing.Size(800, 378);
            this.splitContainer.SplitterDistance = 162;
            this.splitContainer.TabIndex = 2;
            // 
            // ListView
            // 
            this.ListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView.LargeImageList = this.imageList;
            this.ListView.Location = new System.Drawing.Point(0, 0);
            this.ListView.MinimumSize = new System.Drawing.Size(300, 300);
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(634, 378);
            this.ListView.SmallImageList = this.imageList;
            this.ListView.StateImageList = this.imageList;
            this.ListView.TabIndex = 0;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.DoubleClick += new System.EventHandler(this.ListViewFile_DoubleClick);
            // 
            // foot
            // 
            this.foot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.foot.Location = new System.Drawing.Point(0, 423);
            this.foot.Name = "foot";
            this.foot.Size = new System.Drawing.Size(800, 27);
            this.foot.TabIndex = 4;
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
            // curPathText
            // 
            this.curPathText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.curPathText.Location = new System.Drawing.Point(111, 2);
            this.curPathText.Name = "curPathText";
            this.curPathText.Size = new System.Drawing.Size(677, 25);
            this.curPathText.TabIndex = 1;
            this.curPathText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.curPathText_KeyDown);
            // 
            // FromMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.foot);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.head);
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.Panel head;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel foot;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 其他ToolStripMenuItem;
        private System.Windows.Forms.Panel Body;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListView ListView;
        private System.Windows.Forms.ToolStripButton leftPathButton;
        private System.Windows.Forms.ToolStripButton rightPathButton;
        private System.Windows.Forms.ToolStripButton backUpPathButton;
        private System.Windows.Forms.TextBox curPathText;
    }
}
