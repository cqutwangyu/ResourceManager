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
            bll = new FromMainBLL(treeView,listView, this.Handle, largeIconImageList,
                smallImageList,curPathText,  leftPathButton,  
                rightPathButton,  backUpPathButton,fileCheckBox,folderCheckBox,fileCountText);
            bll.fromMainInit();
        }
        //树节点点击事件
        private void treeViewNodeAfterSelect(object sender, TreeViewEventArgs e)
        {
            bll.addPath = true;
            //树节点显示
            bll.treeViewShow(e.Node);
            //列表显示
            bll.listViewShow(e.Node);
            bll.updatePathButtonState();
        }

        //树节点展开事件
        private void treeViewNodeBeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //树节点显示
            bll.treeViewShowFolderTwoTier(e.Node);
        }
        //列表文件夹双击事件
        private void listViewFileDoubleClick(object sender, EventArgs e)
        {
            bll.addPath = true;
            foreach (int ListIndex in listView.SelectedIndices)
            {
                bll.listViewShow(bll.curPath+listView.Items[ListIndex].Text);
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
                bll.listViewShow(curPathText.Text);
            }
        }

        private void largeIconShowMenuItem_Click(object sender, EventArgs e)
        {
            bll.largeIconShow();
        }

        private void smallIconShowMenuItem_Click(object sender, EventArgs e)
        {
            bll.smallIconShow();
        }

        private void detailsShowMenuItem_Click(object sender, EventArgs e)
        {
            bll.detailsShow();
        }

        private void listShowMenuItem_Click(object sender, EventArgs e)
        {
            bll.listShow();
        }

        private void folderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bll.showFilter();
        }

        private void fileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bll.showFilter();
        }
    }
}