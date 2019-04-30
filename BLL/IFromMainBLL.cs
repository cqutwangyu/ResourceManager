using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BLL
{
    interface IFromMainBLL
    {

        FromMainBLL setTreeView(TreeView treeView);

        FromMainBLL setListView(ListView listView);

        FromMainBLL setCurPathText(TextBox curPathText);

        FromMainBLL setLeftPathButton(ToolStripButton leftPathButton);

        FromMainBLL setRightPathButton(ToolStripButton rightPathButton);

        FromMainBLL setBackUpPathButton(ToolStripButton backUpPathButton);

        FromMainBLL setFileCheckBox(CheckBox fileCheckBox);

        FromMainBLL setFolderCheckBox(CheckBox folderCheckBox);

        FromMainBLL setHandle(IntPtr handle);

        FromMainBLL setLargeIconImageList(ImageList largeIconImageList);

        FromMainBLL setSmallImageList(ImageList smallImageList);

        FromMainBLL setFileCountText(Label fileCountText);

        FromMainBLL setContextMenuStrip(ContextMenuStrip contextMenuStrip);

        //窗口初始化
        void fromMainInit();

        //大图标显示
        void largeIconShow();

        //打开文件或文件夹
        void open(string path);

        //小图标显示
        void smallIconShow();

        //详细信息列表显示
        void detailsShow();

        //复制（保存被复制文件的路径）
        void copy(string path);

        //粘贴（传入的是生成复制文件的路径）
        void paste(string targetPath);

        //粘贴文件夹(目标路径，被复制路径)
        void pasteFolder(string targetPath, string parentPath);

        //移动文件夹或文件
        void moveTo(string path);

        //重命名文件
        void rename(string oldPath, string newFileName);

        //新建文件
        void createFile(string newFileName);

        //新建文件夹
        void createFolder(string newFolderName);

        //批量删除
        void deleteBatches(System.Collections.IList list);

        //删除文件或文件夹
        void delete(string path);

        //删除文件夹
        void deleteFolder(DirectoryInfo parentDirectoryInfo);

        //输入路径，获得文件名
        string getFileName(string path);

        //文件显示过滤
        void showFilter();

        //列表显示
        void listShow();

        //回到上一级
        void backUpPath();

        //右回退路径
        void rightReturnPath();

        //左回退路径
        void leftReturnPath();

        //显示被点击树节点的子节点
        void treeViewShow(TreeNode nodeDir);

        //树节点显示path下的文件夹
        void listViewShow(TreeNode nodeDir);

        //传入路径名，列表显示文件
        void listViewShow(string path);

        //加载第二层节点
        void treeViewShowFolderTwoTier(TreeNode NodeDir);

        //刷新目录
        void refreshList();
        
        //更新路径按钮状态
        void updatePathButtonState();

        //更新右键菜单栏状态
        void updateContextMenuStrip(string fileName);

        //获取从系统文件"shell32.dll"中获取图标
        Icon getExtractIcon(string fileName, int iIndex);
    }
}
