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
        private ToolStripButton leftPathButton;
        private ToolStripButton rightPathButton;
        private ToolStripButton backUpPathButton;
        private CheckBox fileCheckBox;
        private CheckBox folderCheckBox;
        //路径
        List<string> pathList = new List<string>();
        private string simpleFileName=null;
        public string curPath=null;
        private string temp=null;
        private int pathIndex=-1;
        private int pathSize=0;
        public bool addPath=false;
        private string rootName = "此电脑";
        //图标
        Dictionary<string, int> extIcon = new Dictionary<string, int>();
        int startIndex;
        int fileImgIndex;
        private IntPtr handle;
        private ImageList largeIconImageList;
        private ImageList smallImageList;


        public FromMainBLL(TreeView treeView,ListView listView, IntPtr handle,
            ImageList largeIconImageList, ImageList smallImageList, TextBox curPathText,
            ToolStripButton leftPathButton, ToolStripButton rightPathButton,
            ToolStripButton backUpPathButton,CheckBox fileCheckBox, CheckBox folderCheckBox)
        {   this.listView = listView;
            this.treeView = treeView;
            this.handle=handle;
            this.largeIconImageList = largeIconImageList;
            this.smallImageList = smallImageList;
            this.curPathText = curPathText;
            this.startIndex = largeIconImageList.Images.Count;
            this.leftPathButton= leftPathButton;
            this.rightPathButton= rightPathButton;
            this.backUpPathButton= backUpPathButton;
            this.fileCheckBox=fileCheckBox; 
            this.folderCheckBox=folderCheckBox;
         }

        //窗口初始化
        public void fromMainInit()
        {
            //创建根节点
            TreeNode headNode = new TreeNode(rootName, ImgListIndexs.MyComputer, ImgListIndexs.MyComputer);
            //添加根节点
            treeView.Nodes.Add(headNode);
            //显示ListView
            ListViewShow(headNode);
            //显示TreeView
            TreeViewShow(headNode);
            //TreeView根节点展开
            treeView.Nodes[0].Expand();
        }

        //大图标显示
        public void LargeIconShow()
        {
            listView.View = View.LargeIcon;
        }

        //小图标显示
        public void SmallIconShow()
        {
            listView.View = View.SmallIcon;
        }

        //详细信息列表显示
        public void DetailsShow()
        {
            listView.View = View.Details;
        }

        //文件显示过滤
        public void ShowFilter()
        {
            if (curPath != null)
            {
                listViewShowPath(curPath);
            }
        }

        //列表显示
        public void ListShow()
        {
            listView.View = View.List;
        }

        //回到上一级
        public void backUpPath()
        {
            addPath = false;
            DirectoryInfo directoryInfo = new DirectoryInfo(curPath);
            if (directoryInfo.Parent != null)
            {
                string parentPath = directoryInfo.Parent.FullName.Replace(rootName, "");
                ListViewShow(parentPath);
            }
            else
            {
                listViewShowDrv();
            }
            updatePathButtonState();
        }

        //右回退路径
        public void rightReturnPath()
        {
            addPath = false;
            //上一级目录
            if (pathIndex != pathSize)
            {
                listView.Items.Clear();
                if (pathIndex + 1 < pathSize)
                {
                    pathIndex++;
                    string path = pathList[pathIndex];
                    ListViewShow(path);
                }
                else if (pathIndex == 0)
                {
                    string path = pathList[pathIndex];
                    pathIndex++;
                    ListViewShow(path);
                }
            }
            updatePathButtonState();
        }

        //左回退路径
        public void leftReturnPath()
        {
            addPath = false;
            listView.Items.Clear();
            pathIndex -= 1;
            //上一级目录
            if (pathIndex >= 0)
            {
                string path = pathList[pathIndex];
                ListViewShow(path);
            }
            else
            {
                curPath = null;
                pathIndex = -1;
                foreach (string DrvName in Directory.GetLogicalDrives())//获得硬盘分区名
                {
                    ListViewItem ItemList = new ListViewItem(DrvName, ImgListIndexs.Disk);
                    listView.Items.Add(ItemList);//添加进来
                }
                curPathText.Text = "";
            }
            updatePathButtonState();
        }

        //显示被点击树节点的子节点
        public void TreeViewShow(TreeNode nodeDir)//初始化TreeView控件
        {
            if (nodeDir.Nodes.Count == 0)
            {   
                //如果父节点为空显示硬盘分区
                if (nodeDir.Parent == null)
                {
                    treeViewShowDrv(nodeDir);
                }
                else
                {
                    // 不为空，显示分区下文件夹
                    string nodePath = nodeDir.FullPath.Replace(rootName + "\\", "");
                    curPath = nodePath;
                    curPathText.Text = nodePath;
                    treeViewShowFolderOneTier(nodeDir);
                }
            }
        }

        //树节点显示path下的文件夹
        public void ListViewShow(TreeNode nodeDir)
        {
            listView.BeginUpdate();
            string nodePath = nodeDir.FullPath.Replace(rootName + "\\", "");
            if (nodeDir.Parent == null)// 如果当前TreeView的父结点为空，就把我的电脑下的分区名称添加进来
            {
                listViewShowDrv();
            }
            //如果DirFileName是文件夹
            else if (Directory.Exists(nodePath))
            {

                //try catch 判断是否可访问
                try
                {
                    //判断是否有访问权限，如果发生异常则是无法访问，执行catch块程序
                    Directory.GetDirectories(nodePath);
                }
                catch
                {
                    MessageBox.Show("无法访问路径:" + nodePath);
                    return;
                }
                updatePath(nodePath);
                //更新路径
                pathList.Insert(pathIndex, curPath);
                //显示
                listViewShowPath(nodePath);
            }
            listView.EndUpdate();
        }

        //传入路径名，列表显示文件
        public void ListViewShow(string path)
        {
            //如果path是文件夹
            if (Directory.Exists(path))
            {
                path = pathCompletion(path);
                //try catch 判断是否可访问
                try
                {
                    //判断是否有访问权限，如果发生异常则是无法访问，执行catch块程序
                    Directory.GetDirectories(path);
                }
                catch
                {
                    MessageBox.Show("无法访问路径:" + path);
                    return;
                }
                //更新路径
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                string nodePath = directoryInfo.FullName.Replace(rootName + "\\", "");
                updatePath(nodePath);
                //显示
                listViewShowPath(path);
            }
            //否则如果被打开的是文件
            else if (File.Exists(path))
            {
                //启动该文件
                try
                {
                    System.Diagnostics.Process.Start(path);
                }
                catch
                {
                    MessageBox.Show("无法打开文件："+ path);
                }
            }
        }

        //树节点显示驱动器(磁盘)
        private void treeViewShowDrv(TreeNode NodeDir)
        {
            foreach (string drvName in Directory.GetLogicalDrives())
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(drvName);
                TreeNode itemNode = new TreeNode(directoryInfo.Name, ImgListIndexs.Disk, ImgListIndexs.Disk);
                NodeDir.Nodes.Add(itemNode);
                treeViewShowFolderOneTier(itemNode);
            }
        }

        //显示树节点下的文件夹，tier代表递归次数，用于显示子目录的加号
        private void treeViewShowFolderOneTier(TreeNode NodeDir)
        {
            //当前节点的子节点个数为0
            if (NodeDir.Nodes.Count == 0)
            {
                string nodeName = (string)NodeDir.Tag;
                string nodePath = NodeDir.FullPath.Replace(rootName + "\\", "");
                string[] arrs;

                //try catch 判断是否可访问
                try
                {
                    //判断是否有访问权限，如果无法访问，执行catch块程序，直接return
                    arrs = Directory.GetDirectories(nodePath);
                }
                catch
                {
                    return;
                }
                //遍历
                foreach (string itemName in arrs)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(itemName);
                    TreeNode itemNode = new TreeNode(directoryInfo.Name, ImgListIndexs.Folder, ImgListIndexs.Folder);
                    NodeDir.Nodes.Add(itemNode);
                }
            }
        }

        //加载第二层节点
        public void treeViewShowFolderTwoTier(TreeNode NodeDir)
        {
            //遍历当前节点的子节点
            TreeNode treeNode = NodeDir.Nodes[0];
            while (treeNode != null)
            {
                //加载子节点的子节点
                treeViewShowFolderOneTier(treeNode);
                treeNode = treeNode.NextNode;
            }
        }

        //列表显示路径下的目录和文件
        private void listViewShowPath(string path)
        {
            listView.BeginUpdate();
            listView.Items.Clear();
            //如果显示文件夹为选中状态
            if (folderCheckBox.Checked)
            {
                listViewShowFolderItems(curPath);
            }
            //如果显示文件为选中状态
            if (fileCheckBox.Checked)
            {
                listViewShowFileItems(curPath);
            }
            listView.EndUpdate();
        }

        //列表显示文件夹下的子目录
        private void listViewShowFolderItems(string curPath)
        {
            //编历当前分区或文件夹所有目录
            foreach (string dirName in Directory.GetDirectories(curPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(dirName);
                ListViewItem listItem = new ListViewItem(directoryInfo.Name, ImgListIndexs.Folder);
                listItem.Text = directoryInfo.Name;
                listItem.SubItems.Add(directoryInfo.LastWriteTime.ToString());
                listItem.SubItems.Add("文件夹");
                listView.Items.Add(listItem);
            }
        }

        //列表显示文件夹下的文件
        private void listViewShowFileItems(string curPath)
        {
            //编历当前分区或文件夹所有文件
            foreach (string fileName in Directory.GetFiles(curPath))
            {
                fileImgIndex = getImgIndex(fileName);
                FileInfo fileInfo = new FileInfo(fileName);
                ListViewItem listItem = new ListViewItem(fileInfo.Name, fileImgIndex);
                listItem.Text = fileInfo.Name;
                listItem.SubItems.Add(fileInfo.LastWriteTime.ToString());
                listItem.SubItems.Add(fileInfo.Extension);
                listItem.SubItems.Add(formattingKB(fileInfo.Length));
                listView.Items.Add(listItem);
            }
        }

        //显示驱动器（磁盘）
        private void listViewShowDrv()
        {
            listView.BeginUpdate();
            listView.Items.Clear();
            curPath = null;
            foreach (string drvName in Directory.GetLogicalDrives())//获得硬盘分区名
            {
                ListViewItem listItem = new ListViewItem(drvName, ImgListIndexs.Disk);
                DirectoryInfo directoryInfo = new DirectoryInfo(drvName);
                listItem.Text = drvName;
                listItem.SubItems.Add(directoryInfo.LastWriteTime.ToString());
                listItem.SubItems.Add("文件夹");
                listView.Items.Add(listItem);//添加进来
            }
            listView.EndUpdate();
        }

        //单位转换，传入字节B转为KB...GB...EB
        private string formattingKB(long length)
        {
            //所有单位集合
            string[] units = { " B", " KB", " MB", " GB", " TB", " PB", " EB" };
            //进制
            long kb = 1024;
            //单位等级
            int level = 0;
            long num = length;
            while (num > 1024)
            {
                num = num / 1024;
                level++;
            }
            //取出单位
            string unit = units[level];
            //算出值，Pow得到kb的level次幂
            double value = length / Math.Pow(kb, level);
            //取小数点后两位，四舍五入
            value = Math.Round(value, 2);
            //返回值+单位
            return value + unit;
        }

        //更新路径
        private void updatePath(string newPath)
        {
            curPath = pathCompletion(newPath);
            curPathText.Text = curPath;
            //是否保存路径
            if (addPath)
            {
                pathSize++;
                pathIndex++;
                pathList.Insert(pathIndex, curPath);
            }
            updatePathButtonState();
        }
        
        //为结尾没有“\”的路径补上“\”
        private static string pathCompletion(string newPath)
        {
            //如果结尾没有“\”则补上
            if (!newPath.EndsWith("\\"))
            {
                newPath += "\\";
            }

            return newPath;
        }

        //更新路径按钮状态
        public void updatePathButtonState()

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
                    largeIconImageList.Images.Add(ic);
                    smallImageList.Images.Add(ic);
                    extIcon.Add(typeExt, startIndex++);
                    return 0;
                }
                else if (typeExt == ".exe")
                {
                    string fullPath = f.FullName;
                    Icon ic = getExtractIcon(fullPath, 0);
                    if (ic != null)
                    {
                        largeIconImageList.Images.Add(ic);
                        smallImageList.Images.Add(ic);
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
