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
            bll = new FromMainBLL(TreeView,ListView, this.Handle, imageList,curPathText);
            bll.fromMainInit();
        }
        //树节点点击事件
        private void TreeViewFile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //树节点显示
            bll.TreeViewShow(e.Node);
            //列表显示
            bll.ListViewShow(e.Node);
        }
        //列表文件夹双击事件
        private void ListViewFile_DoubleClick(object sender, EventArgs e)
        {
            foreach (int ListIndex in ListView.SelectedIndices)
            {
                bll.ListViewShow(bll.CurPath + ListView.Items[ListIndex].Text);
            }
        }
        
        //left目录
        private void leftPath_Click(object sender, EventArgs e)
        {
            bll.leftReturnPath();
            bll.updatePathButtonState(leftPathButton, rightPathButton, backUpPathButton);
        }
        //rigth目录
        private void rightPath_Click(object sender, EventArgs e)
        {
            bll.rightReturnPath();
            bll.updatePathButtonState(leftPathButton, rightPathButton, backUpPathButton);
        }
        //回到上一级目录
        private void backUp_Click(object sender, EventArgs e)
        {
            bll.backUpPath();
            bll.updatePathButtonState(leftPathButton, rightPathButton, backUpPathButton);
        }
    }
}