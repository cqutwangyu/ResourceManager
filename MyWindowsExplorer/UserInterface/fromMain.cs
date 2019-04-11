using MyWindowsExplorer.BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace MyWindowsExplorer
{
    public partial class FromMain : Form
    {
        FromMainBLL bll;
         //主窗口构造方法
         public FromMain()
        {
            //主窗控件初始化
            InitializeComponent();
        }

        //窗口加载事件
        private void fromMain_Load(object sender, EventArgs e)
        {
            bll = new FromMainBLL(treeView,listView, this.Handle, largeIconImageList,smallImageList,curPathText,  leftPathButton,  rightPathButton,  backUpPathButton);
            bll.fromMainInit();
        }
        //树节点点击事件
        private void TreeViewFile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bll.addPath = true;
            //树节点显示
            bll.TreeViewShow(e.Node);
            //列表显示
            bll.ListViewShow(e.Node);
            bll.updatePathButtonState();
        }

        //树节点展开事件
        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //树节点显示
            bll.treeViewShowFolderTwoTier(e.Node);
        }
        //列表文件夹双击事件
        private void ListViewFile_DoubleClick(object sender, EventArgs e)
        {
            bll.addPath = true;
            foreach (int ListIndex in listView.SelectedIndices)
            {
                bll.ListViewShow(bll.curPath+listView.Items[ListIndex].Text);
            }
        }
        
        //left目录
        private void leftPath_Click(object sender, EventArgs e)
        {
            bll.leftReturnPath();
        }
        //rigth目录
        private void rightPath_Click(object sender, EventArgs e)
        {
            bll.rightReturnPath();
        }
        //回到上一级目录
        private void backUp_Click(object sender, EventArgs e)
        {
            bll.backUpPath();
        }

        private void curPathText_KeyDown(object sender, KeyEventArgs e)
        {
            //判断回车键
            if (e.KeyCode == Keys.Enter)
            {
                bll.ListViewShow(curPathText.Text);
            }
        }

        private void 大图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bll.LargeIconShow();
        }

        private void 小图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bll.SmallIconShow();
        }

        private void 详细信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bll.DetailsShow();
        }

        private void 列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bll.ListShow();
        }
    }
}