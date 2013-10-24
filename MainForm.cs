using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace PathCleaner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            findProblematicItems();
        }

        private void findProblematicItems()
        {
            UseWaitCursor = true;
            problemList.Items.Clear();
            var path = new PathString();
            foreach(var item in path.Problems)
            {
                var listItem = new ListViewItem(item.Path);
                listItem.SubItems.Add(new ListViewItem.ListViewSubItem(listItem, item.Reason));
                problemList.Items.Add(listItem);
            }
            UseWaitCursor = false;
        }

        private void cleanupButton_Click(object sender, EventArgs e)
        {
            var path = new PathString();
            foreach(ListViewItem item in problemList.SelectedItems)
            {
                int index = path.Folders.IndexOf(item.Text);
                if (index >= 0)
                {
                    path.Folders.RemoveAt(index);
                }
            }
            path.Update();
            findProblematicItems();
        }

    }
}
