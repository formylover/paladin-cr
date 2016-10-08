using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Paladin.CRUtilities;
using Paladin.Settings;

namespace Paladin.Settings.Forms
{
    public partial class CleanseForm : Form
    {
        public CleanseForm()
        {
            InitializeComponent();
        }

        Dictionary<int, Tuple<bool, string, string, string>> CleanseDictionary = PaladinCR.CleansesDict;

        private void CleanseForm_Load(object sender, EventArgs e)
        {
            AutoScaleMode = AutoScaleMode.Dpi;

            treeCleanse.CheckBoxes = true;

            foreach (var interrupt in CleanseDictionary)
            {
                switch (interrupt.Value.Item3)
                {
                    case "Cleanse":
                        AddCleanseToTree(treeCleanse, interrupt);
                        continue;
                    default:
                        break;
                }
            }
        }

        private void AddCleanseToTree(TreeView tree, KeyValuePair<int, Tuple<bool, string, string, string>> kvp)
        {
            var RootNodes = tree.Nodes;
            var RootNode = new TreeNode(kvp.Value.Item4);

            bool needToAddRoot = true;
            foreach (TreeNode node in RootNodes)
            {
                if (node.Text == RootNode.Text)
                {
                    RootNode = node;
                    needToAddRoot = false;
                }
            }

            if (needToAddRoot)
            {
                tree.Nodes.Add(RootNode);
                RootNode.HideCheckBox();
            }

            var ChildNode = new TreeNode(kvp.Value.Item2);
            ChildNode.Tag = kvp.Key;
            ChildNode.Checked = kvp.Value.Item1;
            bool needToAddChild = true;
            foreach (TreeNode node in RootNode.Nodes)
            {
                if (node.Text == ChildNode.Text)
                {
                    needToAddChild = false;
                }
            }
            if (needToAddChild)
            {
                RootNode.Nodes.Add(ChildNode);
            }
        }

        #region Check Events
        private void TreeViewCheck(TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    foreach (TreeNode node in e.Node.Nodes)
                    {
                        node.Checked = e.Node.Checked;
                    }
                }
            }
            if (e.Node.Level > 0)
            {
                SettingsUtilities.SetPropertyValue(CleanseSettings.Instance, e.Node.Checked, (int)e.Node.Tag);
                var value = CleanseDictionary[(int)e.Node.Tag];

                var updateValue = new Tuple<bool, string, string, string>(e.Node.Checked, value.Item2, value.Item3,
                    value.Item4);

                CleanseDictionary[(int)e.Node.Tag] = updateValue;
                PaladinCR.CleansesDict[(int)e.Node.Tag] = updateValue;
            }
        }

        private void treeCleanse_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeViewCheck(e);
        }

        private void treeHoS_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeViewCheck(e);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            CleanseSettings.Instance.Save();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
