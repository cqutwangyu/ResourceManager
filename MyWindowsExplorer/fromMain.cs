using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace MyWindowsExplorer
{
    public partial class fromMain : Form
    {
        string curPath = null;
        string lastPath = null;
        string temp = null;
        string simpleFileName = null;
        List<string> pathList=new List<string>();
        Boolean addPath = true;
        int pathSize = 0;
        int pathIndex = -1;
        int fileImgIndex;
        //存储图标的键值对<文件后缀名，图标的下标>
        Dictionary<string, int> extIcon = new Dictionary<string, int>();
        //动态生成图标的下标从4开始，因为集合中0到3下标
        int i ;
        //头节点
        TreeNode headNode;
        private class IconIndexes{
            public const int MyComputer = 0; //我的电脑
            public const int Disk = 1;     //磁盘
            public const int Folder = 2;   //文件夹关闭
            public const int File = 3;   //文件夹关闭
        }
         //主窗口构造方法
         public fromMain()
        {
            //主窗控件初始化
            InitializeComponent();
        }

        //窗口加载事件
        private void fromMain_Load(object sender, EventArgs e)
        {
            i = imageList.Images.Count;
            //创建根节点
            headNode = new TreeNode("我的电脑", IconIndexes.MyComputer, IconIndexes.MyComputer);
            //添加根节点
            TreeView.Nodes.Add(headNode);
            //显示ListView
            ListViewShow(headNode);
            //显示TreeView
            TreeViewShow(headNode);
            //TreeView根节点展开
            TreeView.Nodes[0].Expand();
            //列表形式显示
            ListView.View = View.List;
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
            foreach (int ListIndex in ListView.SelectedIndices)
            {
                ListViewShow(curPath + ListView.Items[ListIndex].Text);
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
                        TreeNode aNode = new TreeNode(simpleFileName, IconIndexes.Disk, IconIndexes.Disk);
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
                    curPathText.Text = curPath;
                    foreach (string DirName in Directory.GetDirectories((string)NodeDir.Tag))
                    {
                        simpleFileName = getSimpleFileName(curPath, DirName);
                        TreeNode aNode = new TreeNode(simpleFileName, IconIndexes.Folder, IconIndexes.Folder);
                        aNode.Tag = DirName;
                        NodeDir.Nodes.Add(aNode);
                    }
                }
            }
            updatePathButtonState();
        }
        //显示被点击树节点的文件列表
        private void ListViewShow(TreeNode NodeDir)//初始化ListView控件，把TrreView控件中的数据添加进来
        {
            ListView.Clear();
            if (NodeDir.Parent == null)// 如果当前TreeView的父结点为空，就把我的电脑下的分区名称添加进来
            {
                foreach (string DrvName in Directory.GetLogicalDrives())//获得硬盘分区名
                {
                    ListViewItem ItemList = new ListViewItem(DrvName, IconIndexes.Disk);
                    ListView.Items.Add(ItemList);//添加进来
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
                curPathText.Text = curPath;
                pathSize++;
                pathIndex++;
                pathList.Insert(pathIndex, curPath);
                foreach (string DirName in Directory.GetDirectories(curPath))//编历当前分区或文件夹所有目录
                {
                    simpleFileName = getSimpleFileName(curPath, DirName);
                    ListViewItem ItemList = new ListViewItem(simpleFileName, IconIndexes.Folder);
                    ListView.Items.Add(ItemList);
                }
                foreach (string FileName in Directory.GetFiles(curPath))//编历当前分区或文件夹所有目录的文件
                {
                    fileImgIndex = getImgIndex(FileName);
                    simpleFileName = getSimpleFileName(curPath, FileName);
                    ListViewItem ItemList = new ListViewItem(simpleFileName, fileImgIndex);
                    ListView.Items.Add(ItemList);
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
            curPath = DirFileName;
            curPathText.Text = curPath;
            if (addPath)
            {
                pathSize++;
                pathIndex++;
                pathList.Insert(pathIndex, curPath);
            }
            else
            {
                addPath = true;
            }
            //如果DirFileName是文件夹
            if (Directory.Exists(DirFileName))
            {
                ListView.Clear();
                foreach (string DirName in Directory.GetDirectories(DirFileName))
                {
                    simpleFileName = getSimpleFileName(DirFileName, DirName);
                    ListViewItem ItemList = new ListViewItem(simpleFileName, IconIndexes.Folder);
                    ListView.Items.Add(ItemList);
                }
                foreach (string FileName in Directory.GetFiles(DirFileName))
                {
                    fileImgIndex = getImgIndex(FileName);
                    simpleFileName = getSimpleFileName(DirFileName, FileName);
                    ListViewItem ItemList = new ListViewItem(simpleFileName, fileImgIndex);
                    ListView.Items.Add(ItemList);
                }
            }
            //否则如果被打开的是文件
            else if (File.Exists(DirFileName))
            {
                //启动该文件
                System.Diagnostics.Process.Start(DirFileName);
            }
            //更新路径按钮状态
            updatePathButtonState();
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
        //left目录
        private void leftPath_Click(object sender, EventArgs e)
        {
            ListView.Clear();
            pathIndex-=1;
            //上一级目录
            if (pathIndex >= 0)
            {
                string path = pathList[pathIndex];
                //回退路径时不添加路径
                addPath = false;
                ListViewShow(path);
            }
            else
            {
                //回退路径时不添加路径
                addPath = false;
                curPath = null;
                pathIndex=-1;
                foreach (string DrvName in Directory.GetLogicalDrives())//获得硬盘分区名
                {
                    ListViewItem ItemList = new ListViewItem(DrvName, IconIndexes.Disk);
                    ListView.Items.Add(ItemList);//添加进来
                }
                curPathText.Text = "";
                updatePathButtonState();
            }
        }
        //rigth目录
        private void rightPath_Click(object sender, EventArgs e)
        {
            //上一级目录
            if (pathIndex != pathSize)
            {
                if (pathIndex + 1 < pathSize)
                {
                    //回退路径时不添加路径
                    addPath = false;
                    ListView.Clear();
                    pathIndex++;
                    string path = pathList[pathIndex];
                    ListViewShow(path);
                }
                else if (pathIndex==0)
                {
                    addPath = false;
                    ListView.Clear();
                    string path = pathList[pathIndex];
                    pathIndex++;
                    ListViewShow(path);
                }
            }
        }
        //回到上一级目录
        private void backUp_Click(object sender, EventArgs e)
        {
            //去除\
            string temp = curPath.Replace("\\", "");
            if (curPath.Length - temp.Length > 1)
            {
                addPath = false;
                string path = curPath.Substring(0, curPath.LastIndexOf("\\"));
                ListViewShow(path.Substring(0, path.LastIndexOf("\\") + 1));
            }
            else
            {
                ListView.Clear();
                //回退路径时不添加路径
                addPath = false;
                curPath = null;
                pathIndex = -1;
                foreach (string DrvName in Directory.GetLogicalDrives())//获得硬盘分区名
                {
                    ListViewItem ItemList = new ListViewItem(DrvName, IconIndexes.Disk);
                    ListView.Items.Add(ItemList);//添加进来
                }
                curPathText.Text = "";
                updatePathButtonState();
            }
        }
        //更新路径按钮状态
        private void updatePathButtonState()
        {
            //左箭头按钮
            if ( pathIndex >= 0)
            {
                leftPathButton.Enabled = true;
            }
            else
            {
                leftPathButton.Enabled = false;
            }
            //右箭头按钮
            if (pathIndex+1 < pathSize)
            {
                rightPathButton.Enabled = true;
            }
            else
            {
                rightPathButton.Enabled = false;
            }
            //上箭头按钮
            if (curPath != null)
            {
                string temp = curPath.Replace("\\", "");
                if (curPath.Length-temp.Length > 0)
                {
                    backUpPathButton.Enabled = true;
                }
                else
                {
                    backUpPathButton.Enabled = false;
                }
            }
            else
            {
                backUpPathButton.Enabled = false;
            }
        }
        //根据扩展名获取图标 
        public int fileExtIcon(string typeExt, FileInfo f)
        {
            try
            {
                if (!extIcon.ContainsKey(typeExt) && typeExt != ".exe")
                {
                    RegistryKey regRead = Registry.ClassesRoot.OpenSubKey(typeExt);
                    if (regRead == null) { return 0; }
                    string subKey = regRead.GetValue("").ToString();
                    RegistryKey regRead1 = Registry.ClassesRoot.OpenSubKey(subKey);
                    if (regRead1 == null) { return 0; }
                    RegistryKey subKey1 = regRead1.OpenSubKey("DefaultIcon");
                    string defaultIcon = subKey1.GetValue("").ToString();
                    string[] defIcon = defaultIcon.Split(',');
                    Icon ic = getExtractIcon(defIcon[0], int.Parse(defIcon[1]));
                    imageList.Images.Add(ic);
                    extIcon.Add(typeExt, i++);
                    return 0;
                }
                else if (typeExt == ".exe")
                {
                    string fullPath = f.FullName;
                    Icon ic = getExtractIcon(fullPath, 0);
                    if (ic != null)
                    {
                        imageList.Images.Add(ic);
                        extIcon.Add(typeExt, i++);
                    }
                }

            }
            catch
            {
                //MessageBox.Show(typeExt + "处理异常");
            }
            return 0;
        }
        //获取系统图标 
        [DllImport("shell32.dll")]
        public static extern int ExtractIcon(IntPtr h, string strx, int ii);
        //获取从系统文件"shell32.dll"中获取图标
        public Icon getExtractIcon(string fileName, int iIndex)
        {
            try
            {
                IntPtr hIcon = (IntPtr)ExtractIcon(this.Handle, fileName, iIndex);
                if (hIcon != IntPtr.Zero)
                {
                    Icon icon = Icon.FromHandle(hIcon);
                    return icon;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误提示", 0, MessageBoxIcon.Error);
            }
            return null;
        }
        //获取图标的下标
        private int getImgIndex(string FileName)
        {
            int index = 0;
            FileInfo fileInfo = new FileInfo(FileName);
            //扩展名不为空
            if (!fileInfo.Extension.Equals(""))
            {
                //根据扩展名获取图标
                fileExtIcon(fileInfo.Extension, fileInfo);
                if (extIcon.ContainsKey(fileInfo.Extension))
                {
                    //如果extIcon集合中存在相应扩展名图标的下标，则取得该下标
                    index = extIcon[fileInfo.Extension];
                }
                else
                {
                    //如果不存在，则取默认的文件图标下标
                    index = IconIndexes.File;
                }
            }
            else
            {
                //如果后缀名为空，则取默认的文件图标下标
                index = IconIndexes.File;
            }
            return index;
        }

    }
}