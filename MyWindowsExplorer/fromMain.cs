using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Security.AccessControl;

namespace MyWindowsExplorer
{
    public partial class fromMain : Form
    {
        //主窗口构造方法
        public fromMain()
        {
            //主窗控件初始化
            InitializeComponent();
        }

        //窗口加载事件
        private void fromMain_Load(object sender, EventArgs e)
        {
            //创建根节点
            TreeNode CountNode = new TreeNode("我的电脑");
            //添加根节点
            TreeViewFile.Nodes.Add(CountNode);
        }
        //显示被点击节点的子目录
        private void TreeViewShow(TreeNode NodeDir)//初始化TreeView控件
        {
            if (NodeDir.Nodes.Count == 0)
            {
                if (NodeDir.Parent == null)//如果结点为空显示硬盘分区
                {
                    foreach (string DrvName in Directory.GetLogicalDrives())
                    {
                        TreeNode aNode = new TreeNode(DrvName);
                        aNode.Tag = DrvName;
                        NodeDir.Nodes.Add(aNode);
                    }
                }// end 
                else// 不为空，显示分区下文件夹
                {
                    foreach (string DirName in Directory.GetDirectories((string)NodeDir.Tag))
                    {
                        TreeNode aNode = new TreeNode(DirName);
                        aNode.Tag = DirName;
                        NodeDir.Nodes.Add(aNode);
                    }
                }
            }
        }
        //树节点点击事件
        private void TreeViewFile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeViewShow(e.Node);
        }
    }
}