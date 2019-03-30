namespace MyWindowsExplorer
{
    partial class fromMain
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.TreeViewFile = new System.Windows.Forms.TreeView();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.TreeViewFile);
            this.panelLeft.Location = new System.Drawing.Point(12, 80);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(373, 358);
            this.panelLeft.TabIndex = 0;
            // 
            // TreeViewFile
            // 
            this.TreeViewFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewFile.Location = new System.Drawing.Point(0, 0);
            this.TreeViewFile.Name = "TreeViewFile";
            this.TreeViewFile.Size = new System.Drawing.Size(373, 358);
            this.TreeViewFile.TabIndex = 2;
            this.TreeViewFile.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewFile_AfterSelect);
            // 
            // fromMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelLeft);
            this.Name = "fromMain";
            this.Text = "资源小管家";
            this.Load += new System.EventHandler(this.fromMain_Load);
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.TreeView TreeViewFile;
    }
}

