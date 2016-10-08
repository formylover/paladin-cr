using System;
using System.Collections.Generic;
using Paladin.CRUtilities;
using System.Windows.Forms;

namespace Paladin.Settings.Forms
{
    public partial class InterruptForm : Form
    {
        public InterruptForm()
        {
            InitializeComponent();
        }

        Dictionary<int, Tuple<bool, string, string, string>> InterruptDictionary = PaladinCR.InterruptDict;

        private void InterruptForm_Load(object sender, EventArgs e)
        {
            foreach (var interrupt in InterruptDictionary)
            {
                switch (interrupt.Value.Item3)
                {
                    case "PVP":
                        AddInterruptToTree(treePVP, interrupt);
                        continue;
                    default:
                        break;
                }
            }
        }

        private void AddInterruptToTree(TreeView tree, KeyValuePair<int, Tuple<bool, string, string, string>> kvp)
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

        private void button1_Click(object sender, EventArgs e)
        {
            InterruptSettings.Instance.Save();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

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
                SettingsUtilities.SetPropertyValue(InterruptSettings.Instance, e.Node.Checked, (int)e.Node.Tag);
                var value = InterruptDictionary[(int)e.Node.Tag];

                var updateValue = new Tuple<bool, string, string, string>(e.Node.Checked, value.Item2, value.Item3,
                    value.Item4);

                InterruptDictionary[(int)e.Node.Tag] = updateValue;
                PaladinCR.InterruptDict[(int)e.Node.Tag] = updateValue;
            }
        }

        private void treePVP_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeViewCheck(e);
        }
    }
}
