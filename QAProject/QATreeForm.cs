
// PROPERTIES AND VARIABLES
// private static string output = ""
// updateNodeChildrenDictionary
// METHODS
//      private void PrintRecursive(TreeNode treeNode
//      private string CallRecursive(
//      void saveTreeView()
//      void returnToDashboardButton_Click()
//      void addNewSubjectButton_ClicK()
//      void addNewSubjectDivisionButton_Click()
//      private void addNewQAFileNodeButton_Click(
//      private void loadTreeButton_Click(
//      private void QATreeForm_Load(
//      private void renameNodeButton_Click(
//      saveTreeButton_Click
//      QATreeForm_Load()
// 



using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QADataModelLib;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace QAProject
{
    public partial class QATreeForm : Form

    {

        public QATreeForm()
        {
            InitializeComponent();
        }

        private static string output = "";

        private static string SubjectTreePath = @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\QASubjectTreeView.bin";



        /// <summary>
        /// This method cals saveTreeView() to save any changes to the tree
        /// and then hides the qaTreeForm and opens the dashboardForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void returnToDashboardButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            QADashboard dashboardForm = new QADashboard();
            dashboardForm.ShowDialog();
        }// End return to dashboard button clicked

        /// <summary>
        /// This method:
        /// 1) creates a new primary 'Subject' node 
        /// 2) Gets and sets the node's name property
        /// 3) If there in not a node with the same naem property it then
        ///    adds the node to the  treeViewDictionary
        /// SubjectTreeViewModel which
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNewSubjectButton_Click(object sender, EventArgs e)
        {
            // Get the node's text property
            string subjectNodeTextValue = subjectTextValue.Text;
            // Create a new root, or Subject node with this text value
            TreeNode subjectTreeNode = new TreeNode(subjectTextValue.Text);
            // Get the node's name property from the count of current number of Subject Nodes
            subjectTreeNode.Name = SubjectNodesListModel.returnSubjectNodeName(subjectNodeTextValue);
                
            // SubjectTreeViewModel.returnSubjectNodeName(subjectTextValue.Text);
            // If this node name has not already beed used add this node
            if (!TreeViewDictionaryModel.AddNode(subjectTreeNode.Name, subjectTreeNode.Text))
            {
                MessageBox.Show($"The node name {subjectTreeNode.Name} has already been used");
            }
            else
            {
                // Add this primary node to the TreeView
                subjectTreeView.Nodes.Add(subjectTreeNode);
                // Set filesChanged to true
                SubjectTreeViewModel.filesChanged = true;
                // Clear the subjectTextValue TextBox
                subjectTextValue.Text = "";
            }

        }// End add new subject button clicked


        /// <summary>
        /// This method:
        /// 1) Insures that this 'Division' node is not being added to a QANameNode
        /// adds a new 'Division' child node to the selected parent node
        /// and supplies a name for that node based on its child number
        /// appended as a comma delimited string to its parent node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNewSubjectDivisionButton_Click(object sender, EventArgs e)
        {
            
            // Insure that this 'Division' node is not being added to a 'qaFileNode'
            TreeNode selectedNode = subjectTreeView.SelectedNode;
            int ln = selectedNode.Name.Length - 1;
            char lastChar = selectedNode.Name[ln];
            bool lastIsNum = lastChar == 'q';
            if (lastIsNum)
            {
                MessageBox.Show("You cannot Add a node to a QAFile !! Choose a new Parent!");
                return;
            }
            // Insure that the node is not being added to a terminal Division
            TreeNode firstChild = selectedNode.NextNode;
            if (firstChild != null && firstChild.Text.StartsWith("qa_"))
            {

                MessageBox.Show("You cannot Add a node to a Terminal Division Node !! Choose a new Parent!");
                return;
            }

            // Get the NameExtension for this 'Division' node, create a node and add it to the selectedNode in the tree
            string thisNodeNameExtension = QADataModelLib.NodeChildrenDictionaryModel.returnDivisionNodeName(selectedNode.Name);
            // Create a new DivisionNode with text value = subjectTextValue
            TreeNode DivisionNode = new TreeNode(subjectTextValue.Text);
            // Create the name by appending thisNodeNameExtension to the parentNode's name
            DivisionNode.Name = selectedNode.Name + "." + thisNodeNameExtension;
            // If a node with this name is not already present add node to  the treeViewDictionary
            if (!TreeViewDictionaryModel.AddNode(DivisionNode.Name, DivisionNode.Text))
            {
                MessageBox.Show($"The node name {DivisionNode.Name} has already been used");
            }
            else
            {
                // Add this DivisionNode to its TreeView parent
                subjectTreeView.SelectedNode.Nodes.Add(DivisionNode);
                // Set filesChanged to true
                SubjectTreeViewModel.filesChanged = true;
                subjectTextValue.Text = "";
            }
            // Update the count of children for the parent in the nodeChildrenDictionary
            NodeChildrenDictionaryModel.updateNodeChildrenDictionary(selectedNode.Name);

        }// End add Subject Division button clicked

        /// <summary>
        ///  This method 1st insures that you are not trying to add a QA node to a Divsion or 
        ///  Subject node with other Division node children. 2nd it gets the chain of Parent nodes,
        ///  3rd it gets the new maximum node ID value by incrementing the last and uses it to
        ///  4th create the name for the new QA node with that name and a text value from qa_ +
        ///  the text of the nodeTextValue input box. After examining TreeViewDictionary to
        ///  insure that the new QA node name has not been used it creats and adds the new QA node
        ///  Finally it creates an empty QAFile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNewQAFileNodeButton_Click(object sender, EventArgs e)
        {
            // a TODO - when in QAFileNameScores.txt updated

            TreeNode selectedNode = subjectTreeView.SelectedNode;
            // Determine if this node has children, is so it cannot hold a QAFile
            Boolean nodeHasChildren = NodeChildrenDictionaryModel.doesNodeHaveChildren(selectedNode.Name);
            if (nodeHasChildren)
            {
                MessageBox.Show("You Cannot add a QAFile Node to a Node that has Division Node Children");
                return;
            }
            //  Get the Chain of parents of the new node to be added
            string parentChain = TreeViewDictionaryModel.returnParentChain(selectedNode.Name);


            // The following returns the current value of the current value of currentMaxQAFileID
            int qaFileNumber = SubjectTreeViewModel.returnQAFileName();
            string nextQAFileNumberString = qaFileNumber.ToString();
            // Create a new qaNode whose text value is the text in the subjectTextValue 
            // with prefix qa_ to identify it as a QA File
            TreeNode qaNode = new TreeNode("qa_" + subjectTextValue.Text);
            // Add a new stud to the QACumulativerResultsDictionary
            //Create the name for this node and append 'q'
            qaNode.Name = selectedNode.Name + "." + nextQAFileNumberString + "q";
            QACumulativeResultsModel.addNewQATestFileRow(qaNode.Name, qaNode.Text);
            // Test to make sure no node with with name already exists in treeViewDictionary
            if (!TreeViewDictionaryModel.AddNode(qaNode.Name, qaNode.Text))
            {
                MessageBox.Show($"The node name {qaNode.Name} has already been used");
            }
            else
            {
                // Add this QANode to its Division parent
                subjectTreeView.SelectedNode.Nodes.Add(qaNode);
                // Set treeChanged to true
                SubjectTreeViewModel.filesChanged = true;
                subjectTextValue.Text = "";
            }
            // Add this qa file node's  name and text value to the qaNamesDictionary
            QAFileNameScoresModel.updateQANameScoreDictionary(qaFileNumber, qaNode.Name, qaNode.Text, parentChain);
            // Create a file in  @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\QAFiles"
            //      whose name is qaNode.Name value

            if (!File.Exists(@"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\QAFiles\" + qaNode.Name + ".txt"))
            {
                File.Create(@"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\QAFiles\" + qaNode.Name + ".txt");
            }
        }// End addNewQAFileNodeButton_Click

        //----------------START UPDATE---------------//
        private void createTreeViewFromDictionary()
        {
            Dictionary<string, string> treeViewDictionary = new Dictionary<string, string>();
            treeViewDictionary = TreeViewDictionaryModel.getTreeViewDictionary();
            subjectTreeView.BeginUpdate();

            // Process each line of treeViewDictionary into a node on the treeView
            foreach (KeyValuePair<string, string> kvp in treeViewDictionary)
            {
                string nodeName = kvp.Key;// the key is the '.' delimited nodeName
                string nodeText = kvp.Value;// the value is the nodeText 
                                            // Determine the node level from the number of periods in the nodeName
                string[] nodeNameComponents = nodeName.Split('.');
                int nodeLevel = nodeNameComponents.Length;
                //Create a new treeNode thisNode
                TreeNode thisNode = new TreeNode();
                switch (nodeLevel)
                {
                    case 1:
                        // Level 1 is a root node so create a root node from the nodeText value
                        subjectTreeView.Nodes.Add(nodeText);
                        // Determine the index of this node by convertine the nodeNameComponents[0] string value to an integer
                        int thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
                        // Add this node to the tree
                        thisNode = subjectTreeView.Nodes[thisNodesNumber0];
                        // Assign the nodeName value to this node's name property
                        thisNode.Name = nodeName;
                        break;
                    case 2:
                        // This and all subsequent levels are either Division nodes or QA nodes
                        // Get the immediate parent of this new node from the nodeNameComponents[0]th component
                        int node0 = Int32.Parse(nodeNameComponents[0]);
                        // Add a child to the immediate parent using the nodeText value
                        subjectTreeView.Nodes[node0].Nodes.Add(nodeText);
                        // Create the value of thisNodesNumber0 from nodeNameComponents[0],
                        // This int was defined in the previous case statement it represents the index of the immediate parent
                        thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
                        // Determine if the node to be added is a Division node (nodeNameComponents does not contain 'q'
                        int thisNodesNumber1 = -1;
                        if (nodeNameComponents[1].IndexOf('q') != -1)
                        {
                            // This is a QA node
                            // Get the selectedNode from the the immediate parent index
                            TreeNode selectedNode = subjectTreeView.Nodes[thisNodesNumber0];
                            // Get the index of this node from the number of children of the immediate parent
                            // It will be used to create the nodeName property for the new Node
                            thisNodesNumber1 = selectedNode.GetNodeCount(true);

                        }
                        else
                        {
                            // This is a Divisiion node so its index is derived from nodeNameComponents[1]
                            thisNodesNumber1 = Int32.Parse(nodeNameComponents[1]);
                        }
                        // assign the new node (based on the index of its parent and itself to thisNode
                        thisNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1];
                        // Assign the nodeName property to this new child node
                        thisNode.Name = nodeName;
                        break;
                    case 3:
                        thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
                        thisNodesNumber1 = Int32.Parse(nodeNameComponents[1]);
                        int thisNodesNumber2 = -1;
                        if (nodeNameComponents[2].IndexOf('q') != -1)
                        {
                            TreeNode selectedNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1];
                            thisNodesNumber2 = selectedNode.GetNodeCount(true);
                        }
                        else
                        {
                            thisNodesNumber2 = Int32.Parse(nodeNameComponents[2]);
                        }
                        subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes.Add(nodeText);
                        thisNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2];
                        thisNode.Name = nodeName;
                        break;
                    case 4:
                        thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
                        thisNodesNumber1 = Int32.Parse(nodeNameComponents[1]);
                        thisNodesNumber2 = Int32.Parse(nodeNameComponents[2]);
                        int thisNodesNumber3 = -1;
                        if (nodeNameComponents[3].IndexOf('q') != -1)
                        {
                            TreeNode selectedNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2];
                            thisNodesNumber3 = selectedNode.GetNodeCount(true);
                        }
                        else
                        {
                            thisNodesNumber3 = Int32.Parse(nodeNameComponents[3]);
                        }
                        subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes.Add(nodeText);
                        thisNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3];
                        thisNode.Name = nodeName;
                        break;
                    case 5:
                        thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
                        thisNodesNumber1 = Int32.Parse(nodeNameComponents[1]);
                        thisNodesNumber2 = Int32.Parse(nodeNameComponents[2]);
                        thisNodesNumber3 = Int32.Parse(nodeNameComponents[3]);
                        int thisNodesNumber4 = -1;
                        if (nodeNameComponents[4].IndexOf('q') != -1)
                        {
                            TreeNode selectedNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3];
                            thisNodesNumber4 = selectedNode.GetNodeCount(true);
                        }
                        else
                        {
                            thisNodesNumber4 = Int32.Parse(nodeNameComponents[4]);
                        }
                        subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes.Add(nodeText);
                        thisNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3];
                        thisNode.Name = nodeName;
                        break;
                    case 6:
                        thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
                        thisNodesNumber1 = Int32.Parse(nodeNameComponents[1]);
                        thisNodesNumber2 = Int32.Parse(nodeNameComponents[2]);
                        thisNodesNumber3 = Int32.Parse(nodeNameComponents[3]);
                        thisNodesNumber4 = Int32.Parse(nodeNameComponents[4]);
                        int thisNodesNumber5 = -1;
                        if (nodeNameComponents[5].IndexOf('q') != -1)
                        {
                            TreeNode selectedNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4];
                            thisNodesNumber5 = selectedNode.GetNodeCount(true);
                        }
                        else
                        {
                            thisNodesNumber5 = Int32.Parse(nodeNameComponents[5]);
                        }
                        subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes.Add(nodeText);
                        thisNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes[thisNodesNumber5];
                        thisNode.Name = nodeName;
                        break;
                    case 7:
                        thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
                        thisNodesNumber1 = Int32.Parse(nodeNameComponents[1]);
                        thisNodesNumber2 = Int32.Parse(nodeNameComponents[2]);
                        thisNodesNumber3 = Int32.Parse(nodeNameComponents[3]);
                        thisNodesNumber4 = Int32.Parse(nodeNameComponents[4]);
                        thisNodesNumber5 = Int32.Parse(nodeNameComponents[5]);
                        int thisNodesNumber6 = -1;
                        if (nodeNameComponents[6].IndexOf('q') != -1)
                        {
                            // This is a QA node
                            // Get the selectedNode from the the immediate parent index
                            TreeNode selectedNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes[thisNodesNumber5];
                            // Get the index of this node from the number of children of the immediate parent
                            // It will be used to create the nodeName property for the new Node
                            thisNodesNumber6 = selectedNode.GetNodeCount(true);

                        }
                        else
                        {
                            // This is a Divisiion node so its index is derived from nodeNameComponents[6]
                            thisNodesNumber6 = Int32.Parse(nodeNameComponents[6]);
                        }

                        subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes[thisNodesNumber5].Nodes.Add(nodeText);
                        thisNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes[thisNodesNumber5].Nodes[thisNodesNumber6];
                        thisNode.Name = nodeName;
                        break;
                    case 8:
                        thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
                        thisNodesNumber1 = Int32.Parse(nodeNameComponents[1]);
                        thisNodesNumber2 = Int32.Parse(nodeNameComponents[2]);
                        thisNodesNumber3 = Int32.Parse(nodeNameComponents[3]);
                        thisNodesNumber4 = Int32.Parse(nodeNameComponents[4]);
                        thisNodesNumber5 = Int32.Parse(nodeNameComponents[5]);
                        thisNodesNumber6 = Int32.Parse(nodeNameComponents[6]);
                        int thisNodesNumber7 = -1;
                        if (nodeNameComponents[7].IndexOf('q') != -1)
                        {
                            TreeNode selectedNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes[thisNodesNumber5].Nodes[thisNodesNumber6];
                            thisNodesNumber7 = selectedNode.GetNodeCount(true);
                        }
                        else
                        {
                            thisNodesNumber7 = Int32.Parse(nodeNameComponents[7]);
                        }
                        subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes[thisNodesNumber5].Nodes[thisNodesNumber5].Nodes[thisNodesNumber6].Nodes.Add(nodeText);
                        thisNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes[thisNodesNumber5].Nodes[thisNodesNumber6].Nodes[thisNodesNumber7];
                        thisNode.Name = nodeName;
                        break;
                    case 9:
                        thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
                        thisNodesNumber1 = Int32.Parse(nodeNameComponents[1]);
                        thisNodesNumber2 = Int32.Parse(nodeNameComponents[2]);
                        thisNodesNumber3 = Int32.Parse(nodeNameComponents[3]);
                        thisNodesNumber4 = Int32.Parse(nodeNameComponents[4]);
                        thisNodesNumber5 = Int32.Parse(nodeNameComponents[5]);
                        thisNodesNumber6 = Int32.Parse(nodeNameComponents[6]);
                        thisNodesNumber7 = Int32.Parse(nodeNameComponents[7]);
                        int thisNodesNumber8 = -1;
                        if (nodeNameComponents[8].IndexOf('q') != -1)
                        {
                            TreeNode selectedNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes[thisNodesNumber5].Nodes[thisNodesNumber6].Nodes[thisNodesNumber7];
                            thisNodesNumber8 = selectedNode.GetNodeCount(true);
                        }
                        else
                        {
                            thisNodesNumber8 = Int32.Parse(nodeNameComponents[8]);
                        }
                        subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes[thisNodesNumber5].Nodes[thisNodesNumber5].Nodes[thisNodesNumber6].Nodes[thisNodesNumber7].Nodes.Add(nodeText);
                        thisNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes[thisNodesNumber5].Nodes[thisNodesNumber6].Nodes[thisNodesNumber7].Nodes[thisNodesNumber8];
                        thisNode.Name = nodeName;
                        break;
                    case 10:
                        thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
                        thisNodesNumber1 = Int32.Parse(nodeNameComponents[1]);
                        thisNodesNumber2 = Int32.Parse(nodeNameComponents[2]);
                        thisNodesNumber3 = Int32.Parse(nodeNameComponents[3]);
                        thisNodesNumber4 = Int32.Parse(nodeNameComponents[4]);
                        thisNodesNumber5 = Int32.Parse(nodeNameComponents[5]);
                        thisNodesNumber6 = Int32.Parse(nodeNameComponents[6]);
                        thisNodesNumber7 = Int32.Parse(nodeNameComponents[7]);
                        thisNodesNumber8 = Int32.Parse(nodeNameComponents[8]);
                        int thisNodesNumber9 = -1;
                        if (nodeNameComponents[9].IndexOf('q') != -1)
                        {
                            TreeNode selectedNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes[thisNodesNumber5].Nodes[thisNodesNumber6].Nodes[thisNodesNumber7].Nodes[thisNodesNumber8];
                            thisNodesNumber9 = selectedNode.GetNodeCount(true);
                        }
                        else
                        {
                            thisNodesNumber9 = Int32.Parse(nodeNameComponents[9]);
                        }
                        subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes[thisNodesNumber5].Nodes[thisNodesNumber5].Nodes[thisNodesNumber6].Nodes[thisNodesNumber7].Nodes[thisNodesNumber8].Nodes.Add(nodeText);
                        thisNode = subjectTreeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes[thisNodesNumber5].Nodes[thisNodesNumber6].Nodes[thisNodesNumber7].Nodes[thisNodesNumber8].Nodes[thisNodesNumber9];
                        thisNode.Name = nodeName;
                        break;
                    case 11:
                        MessageBox.Show("The program currently is unable to handel nodes at this level! Change the program");
                        break;
                }// End switch(nodeLevel)
            }
            subjectTreeView.EndUpdate();
        }// End CreateTreeViewFromDictionary

        //----------------END UPDATE-----------------//

        public void QATreeForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            createTreeViewFromDictionary();

            ////-----------------------------------------------------//
            //string filePath = SubjectTreePath;


            //if (File.Exists(filePath))
            //{
            //    if (File.Exists(filePath))
            //    {
            //        // open file
            //        Stream file = File.Open(filePath, FileMode.Open);
            //        // Binary formatting init.
            //        BinaryFormatter bf = new BinaryFormatter();
            //        // Object var. init.
            //        object obj = null;
            //        try
            //        {
            //            // Deserialize data from the file
            //            obj = bf.Deserialize(file);
            //        }
            //        catch (System.Runtime.Serialization.SerializationException ex1)
            //        {
            //            MessageBox.Show($"De-Serialization failed {ex1.Message} ");
            //        }
            //        // Close File
            //        file.Close();

            //        // Create a new array
            //        ArrayList nodeList = obj as ArrayList;

            //        // load Root-Nodes
            //        foreach (TreeNode node in nodeList)
            //        {
            //            subjectTreeView.Nodes.Add(node);
            //        }
            //    }// End if (File.Exists(filePath))
            //    CallRecursive(subjectTreeView);

            //}
        }// EndQATreeFormLoad

        private void renameNodeButton_Click(object sender, EventArgs e)
        {
            // Get the text to apply to the node's TextValue
            string newNodeText = "";
            if (subjectTreeView.SelectedNode.Text.IndexOf("qa_") == 0)
            {
                // The node to be changed is a QA Node
                newNodeText = "qa_" + subjectTextValue.Text;
            }
            else
            {
                newNodeText = subjectTextValue.Text;
            }
            //Get the old text of the node to be changed
            string oldNodeText = subjectTreeView.SelectedNode.Text;
            // Change the text property of the node selected to the new name
            subjectTreeView.SelectedNode.Text = newNodeText;
            // Get the selected node's name and current(oldNodeText) text value
            string nodeName = subjectTreeView.SelectedNode.Name;
            int nodeLevel = subjectTreeView.SelectedNode.Level;

            SubjectTreeViewModel.renameNode(nodeName, oldNodeText, newNodeText, nodeLevel);
            //subjectTreeView.SelectedNode.Text = newNodeText;
            SubjectTreeViewModel.filesChanged = true;
        }
    }// End QATreeForm


    // a TODO - Create a class to respond to the Rename node button


}//End QAProject


