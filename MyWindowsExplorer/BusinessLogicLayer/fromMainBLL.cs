using Microsoft.Win32;
using MyWindowsExplorer.view;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace MyWindowsExplorer.BusinessLogicLayer
{
    class FromMainBLL
    {
        //显示控件
        private TreeView treeView;
        private ListView listView;
        private TextBox curPathText;
        //路径
        List<string> pathList = new List<string>();
        private string simpleFileName;
        private string curPath;
        private int pathIndex;
        private int pathSize;
        private bool addPath=true;
        //图标
        Dictionary<string, int> extIcon = new Dictionary<string, int>();
        int startIndex;
        int fileImgIndex;
        private IntPtr handle;
        private ImageList imageList;

        public string CurPath { get => curPath; set => curPath = value; }

        public FromMainBLL(TreeView treeView,ListView listView, IntPtr handle,ImageList imageList, TextBox curPathText)
        {            this.listView = listView;
            this.treeView = treeView;
            this.handle=handle;
            this.imageList = imageList;
            this.curPathText = curPathText;
            this.startIndex = imageList.Images.Count;
        }

        //窗口初始化
        public void fromMainInit()
        {
            //创建根节点
            TreeNode headNode = new TreeNode("我的电脑", ImgListIndexs.MyComputer, ImgListIndexs.MyComputer);
            //添加根节点
            treeView.Nodes.Add(headNode);
            //显示ListView
            ListViewShow(headNode);
            //显示TreeView
            TreeViewShow(headNode);
            //TreeView根节点展开
            treeView.Nodes[0].Expand();
            //列表形式显示
            listView.View = View.List;
        }

        //回到上一级
        internal void backUpPath()
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
                listView.Clear();
                //回退路径时不添加路径
                addPath = false;
                curPath = null;
                pathIndex = -1;
                foreach (string DrvName in Directory.GetLogicalDrives())//获得硬盘分区名
                {
                    ListViewItem ItemList = new ListViewItem(DrvName, ImgListIndexs.Disk);
                    listView.Items.Add(ItemList);//添加进来
                }
                curPathText.Text = "";
                //updatePathButtonState();
            }
        }

        //右回退路径
        internal void rightReturnPath()
        {
            //上一级目录
            if (pathIndex != pathSize)
            {
                if (pathIndex + 1 < pathSize)
                {
                    //回退路径时不添加路径
                    addPath = false;
                    listView.Clear();
                    pathIndex++;
                    string path = pathList[pathIndex];
                    ListViewShow(path);
                }
                else if (pathIndex == 0)
                {
                    addPath = false;
                    listView.Clear();
                    string path = pathList[pathIndex];
                    pathIndex++;
                    ListViewShow(path);
                }
            }
        }

        //左回退路径
        internal void leftReturnPath()
        {
            listView.Clear();
            pathIndex -= 1;
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
                pathIndex = -1;
                foreach (string DrvName in Directory.GetLogicalDrives())//获得硬盘分区名
                {
                    ListViewItem ItemList = new ListViewItem(DrvName, ImgListIndexs.Disk);
                    listView.Items.Add(ItemList);//添加进来
                }
                curPathText.Text = "";
                //updatePathButtonState();
            }
        }

        //显示被点击树节点的子节点
        public void TreeViewShow(TreeNode NodeDir)//初始化TreeView控件
        {
            if (NodeDir.Nodes.Count == 0)
            {
                if (NodeDir.Parent == null)//如果结点为空显示硬盘分区
                {
                    foreach (string DrvName in Directory.GetLogicalDrives())
                    {
                        simpleFileName = getSimpleFileName(curPath, DrvName);
                        TreeNode aNode = new TreeNode(simpleFileName, ImgListIndexs.Disk, ImgListIndexs.Disk);
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
                    //curPathText.Text = curPath;
                    foreach (string DirName in Directory.GetDirectories((string)NodeDir.Tag))
                    {
                        simpleFileName = getSimpleFileName(curPath, DirName);
                        TreeNode aNode = new TreeNode(simpleFileName, ImgListIndexs.Folder, ImgListIndexs.Folder);
                        aNode.Tag = DirName;
                        NodeDir.Nodes.Add(aNode);
                    }
                }
            }
        }

        //传入被点击的树节点，列表显示文件
        public void ListViewShow(TreeNode NodeDir)
        {
            listView.Clear();
            if (NodeDir.Parent == null)// 如果当前TreeView的父结点为空，就把我的电脑下的分区名称添加进来
            {
                foreach (string DrvName in Directory.GetLogicalDrives())//获得硬盘分区名
                {
                    ListViewItem ItemList = new ListViewItem(DrvName, ImgListIndexs.Disk);
                    listView.Items.Add(ItemList);//添加进来
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
                //curPathText.Text = curPath;
                pathSize++;
                pathIndex++;
                pathList.Insert(pathIndex, curPath);
                foreach (string DirName in Directory.GetDirectories(curPath))//编历当前分区或文件夹所有目录
                {
                    simpleFileName = getSimpleFileName(curPath, DirName);
                    ListViewItem ItemList = new ListViewItem(simpleFileName, ImgListIndexs.Folder);
                    listView.Items.Add(ItemList);
                }
                foreach (string FileName in Directory.GetFiles(curPath))//编历当前分区或文件夹所有目录的文件
                {
                    fileImgIndex = getImgIndex(FileName);
                    simpleFileName = getSimpleFileName(curPath, FileName);
                    ListViewItem ItemList = new ListViewItem(simpleFileName, fileImgIndex);
                    listView.Items.Add(ItemList);
                }
            }
        }

        //传入路径名，列表显示文件
        public void ListViewShow(string DirFileName)
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
                listView.Clear();
                foreach (string DirName in Directory.GetDirectories(DirFileName))
                {
                    simpleFileName = getSimpleFileName(DirFileName, DirName);
                    ListViewItem ItemList = new ListViewItem(simpleFileName, ImgListIndexs.Folder);
                    listView.Items.Add(ItemList);
                }
                foreach (string FileName in Directory.GetFiles(DirFileName))
                {
                    fileImgIndex = getImgIndex(FileName);
                    simpleFileName = getSimpleFileName(DirFileName, FileName);
                    ListViewItem ItemList = new ListViewItem(simpleFileName, fileImgIndex);
                    listView.Items.Add(ItemList);
                }
            }
            //否则如果被打开的是文件
            else if (File.Exists(DirFileName))
            {
                //启动该文件
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

        //更新路径按钮状态
        public void updatePathButtonState(ToolStripButton leftPathButton, ToolStripButton rightPathButton,ToolStripButton backUpPathButton)

        {
            //左箭头按钮
            if (pathIndex >= 0)
            {
                leftPathButton.Enabled = true;
            }
            else
            {
                leftPathButton.Enabled = false;
            }
            //右箭头按钮
            if (pathIndex + 1 < pathSize)
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
                if (curPath.Length - temp.Length > 0)
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
                    extIcon.Add(typeExt, startIndex++);
                    return 0;
                }
                else if (typeExt == ".exe")
                {
                    string fullPath = f.FullName;
                    Icon ic = getExtractIcon(fullPath, 0);
                    if (ic != null)
                    {
                        imageList.Images.Add(ic);
                        extIcon.Add(typeExt, startIndex++);
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
                IntPtr hIcon = (IntPtr)ExtractIcon(handle, fileName, iIndex);
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
                    index = ImgListIndexs.File;
                }
            }
            else
            {
                //如果后缀名为空，则取默认的文件图标下标
                index = ImgListIndexs.File;
            }
            return index;
        }
    }
}
