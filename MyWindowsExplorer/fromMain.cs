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
            //初始化TreeView控件添加总结点
            TreeNode CountNode = new TreeNode("我的电脑");
            TreeViewFile.Nodes.Add(CountNode);
            //初始化ListView控件
            ListViewShow(CountNode);
        }

        //初始化ListView控件，把TrreView控件中的数据添加进来
        private void ListViewShow(TreeNode NodeDir)
        {
            // 如果当前TreeView的父结点为空，就把我的电脑下的分区名称添加进来
            if (NodeDir.Parent == null)
            {
                //获得硬盘分区名
                foreach (string DrvName in Directory.GetLogicalDrives())
                {
                    ListViewItem ItemList = new ListViewItem(DrvName);
                }
            }
            else//如果当前TreeView的父结点不为空，把点击的结点，做为一个目录文件的总结点
            {
                //编历当前分区或文件夹所有目录
                foreach (string DirName in Directory.GetDirectories((string)NodeDir.Tag))
                {
                    ListViewItem ItemList = new ListViewItem(DirName);
                }
                //编历当前分区或文件夹所有目录的文件
                foreach (string FileName in Directory.GetFiles((string)NodeDir.Tag))
                {
                    ListViewItem ItemList = new ListViewItem(FileName);
                }
            }
        }
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
        private void TreeViewFile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ListViewShow(e.Node);
        }
    }
}