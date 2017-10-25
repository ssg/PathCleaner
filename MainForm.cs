using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PathCleaner
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();

        private static IEnumerable<IPathChecker> pathCheckers = new IPathChecker[]
        {
            new DuplicatePathChecker(),
            new MissingPathChecker(),
            new EmptyPathChecker(),
            new NoExecutablesPathChecker(),
        };

        private void MainForm_Load(object sender, EventArgs e) => findProblematicItems();

        private void findProblematicItems()
        {
            UseWaitCursor = true;
            problemList.Items.Clear();
            var path = new PathString();
            var identifier = new ProblemIdentifier(path, pathCheckers);
            var problems = identifier.FindProblems();
            foreach (var item in problems)
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
            foreach (ListViewItem item in problemList.SelectedItems)
            {
                int index = path.Folders.IndexOf(item.Text);
                if (index >= 0)
                {
                    path.Folders.RemoveAt(index);
                }
            }
            path.UpdateEnvironmentVariable();
            findProblematicItems();
        }
    }
}