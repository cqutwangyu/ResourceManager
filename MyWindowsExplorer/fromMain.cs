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
        string curPath = null;
        string lastPath = null;
        string temp = null;
        string simpleFileName = null;
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
            TreeNode CountNode = new TreeNode("此电脑");
            //添加根节点
            TreeViewFile.Nodes.Add(CountNode);
            //初始化ListView控件
            ListViewShow(CountNode);
            //列表形式显示
            ListViewFile.View = View.List;
        }
        //树节点点击事件
        private void TreeViewFile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //树节点显示
            TreeViewShow(e.Node);
            //列表显示
            ListViewShow(e.Node);
        }
        //列表文件夹双击事件
        private void ListViewFile_DoubleClick(object sender, EventArgs e)
        {
            foreach (int ListIndex in ListViewFile.SelectedIndices)
            {
                ListViewShow(curPath + ListViewFile.Items[ListIndex].Text);
            }
        }
        //显示被点击树节点的子节点
        private void TreeViewShow(TreeNode NodeDir)//初始化TreeView控件
        {
            if (NodeDir.Nodes.Count == 0)
            {
                if (NodeDir.Parent == null)//如果结点为空显示硬盘分区
                {
                    foreach (string DrvName in Directory.GetLogicalDrives())
                    {
                        simpleFileName = getSimpleFileName(curPath, DrvName);
                        TreeNode aNode = new TreeNode(simpleFileName);
                        aNode.Tag = DrvName;
                        NodeDir.Nodes.Add(aNode);
                    }
                }// end 
                else// 不为空，显示分区下文件夹
                {
                    try
                    {
                        //判断是否有访问权限，如果发生异常则是无法访问，执行catch块程序
                        Boolean authority = HasOperationPermission((string)NodeDir.Tag);
                    }
                    catch
                    {
                        MessageBox.Show("无法访问路径:" + (string)NodeDir.Tag);
                        return;
                    }
                    curPath = (string)NodeDir.Tag;
                    foreach (string DirName in Directory.GetDirectories((string)NodeDir.Tag))
                    {
                        simpleFileName = getSimpleFileName(curPath, DirName);
                        TreeNode aNode = new TreeNode(simpleFileName);
                        aNode.Tag = DirName;
                        NodeDir.Nodes.Add(aNode);
                    }
                }
            }
        }
        //显示被点击树节点的文件列表
        private void ListViewShow(TreeNode NodeDir)//初始化ListView控件，把TrreView控件中的数据添加进来
        {
            ListViewFile.Clear();
            if (NodeDir.Parent == null)// 如果当前TreeView的父结点为空，就把我的电脑下的分区名称添加进来
            {
                foreach (string DrvName in Directory.GetLogicalDrives())//获得硬盘分区名
                {
                    ListViewItem ItemList = new ListViewItem(DrvName);
                    ListViewFile.Items.Add(ItemList);//添加进来
                }
            }
            //如果DirFileName是文件夹
            else if (Directory.Exists((string)NodeDir.Tag))//如果当前TreeView的父结点不为空，把点击的结点，做为一个目录文件的总结点
            {
                try
                {
                    //判断是否有访问权限，如果发生异常则是无法访问，执行catch块程序
                    Boolean authority = HasOperationPermission((string)NodeDir.Tag);
                }
                catch
                {
                    MessageBox.Show("无法访问路径:" + (string)NodeDir.Tag);
                    return;
                }
                curPath = (string)NodeDir.Tag;
                foreach (string DirName in Directory.GetDirectories(curPath))//编历当前分区或文件夹所有目录
                {
                    simpleFileName = getSimpleFileName(curPath, DirName);
                    ListViewItem ItemList = new ListViewItem(simpleFileName);
                    ListViewFile.Items.Add(ItemList);
                }
                foreach (string FileName in Directory.GetFiles(curPath))//编历当前分区或文件夹所有目录的文件
                {
                    simpleFileName = getSimpleFileName(curPath, FileName);
                    ListViewItem ItemList = new ListViewItem(simpleFileName);
                    ListViewFile.Items.Add(ItemList);
                }
            }
        }
        //显示被点击的列表文件的子目录
        private void ListViewShow(string DirFileName)//获取当有文件夹内的文件和目录
        {
            try
            {
                //判断是否有访问权限，如果发生异常则是无法访问，执行catch块程序
                Boolean authority = HasOperationPermission(DirFileName);
            }
            catch
            {
                MessageBox.Show("无法访问路径:" + DirFileName);
                return;
            }
            //如果DirFileName是文件夹
            if (Directory.Exists(DirFileName))
            {
                ListViewFile.Clear();
                foreach (string DirName in Directory.GetDirectories(DirFileName))
                {
                    simpleFileName = getSimpleFileName(DirFileName, DirName);
                    ListViewItem ItemList = new ListViewItem(simpleFileName);
                    ListViewFile.Items.Add(ItemList);
                }
                foreach (string FileName in Directory.GetFiles(DirFileName))
                {
                    simpleFileName = getSimpleFileName(DirFileName, FileName);
                    ListViewItem ItemList = new ListViewItem(simpleFileName);
                    ListViewFile.Items.Add(ItemList);
                }
            }
            //否则如果是文件
            else if (File.Exists(DirFileName))
            {
                System.Diagnostics.Process.Start(DirFileName);
            }
        }
        //去除多余的路径名，将最后的文件名保存到FileNameTemp
        private string getSimpleFileName(string parentPath, string fileName)
        {
            //假设curPath="C:\"
            curPath = parentPath;
            //如果父路径不为空
            if (parentPath != null)
            {
                //如果最后一个字符不为\，如G:\Maven
                if (curPath.LastIndexOf("\\") != curPath.Length - 1)
                {
                    //在最后加上\，如G:\Maven\
                    curPath += "\\";
                }
                //去除父路径
                simpleFileName = fileName.Replace(parentPath, "");
            }
            else
            {
                //否则直接赋值
                simpleFileName = fileName;
            }
            //去除:和\并返回
            return simpleFileName.Replace(":", "").Replace("\\", "");
        }
        // 检查当前用户是否拥有此文件夹的操作权限
        public static bool HasOperationPermission(string folder)
        {
            var currentUserIdentity = Path.Combine(Environment.UserDomainName, Environment.UserName);

            //获取访问控制列表，如果无法访问，会在这里抛出异常
            DirectorySecurity fileAcl = Directory.GetAccessControl(folder);
            var userAccessRules = fileAcl.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)).OfType<FileSystemAccessRule>().Where(i => i.IdentityReference.Value == currentUserIdentity).ToList();

            return userAccessRules.Any(i => i.AccessControlType == AccessControlType.Deny);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //上一级目录
            if (curPath != null)
            {
                lastPath = curPath.Substring(0, curPath.LastIndexOf("\\") + 1);
                ListViewShow(lastPath);
            }
        }
    }
}