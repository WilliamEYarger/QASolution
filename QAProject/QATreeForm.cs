
// PROPERTIES AND VARIABLES
// private static string output = ""
// updateNodeChildrenDictionary
// METHODS

//----------------------PUBLIC METHODS------------------------------//
//      void QATreeForm_Load(

//----------------------BUTTON CLICK METHODS------------------------------//
//      void returnToDashboardButton_Click
//      void addNewSubjectButton_Click(
//      void addNewSubjectDivisionButton_Click(
//      void addNewQAFileNodeButton_Click(
//      void renameNodeButton_Click(
//      void selectNodetoMoveButton_Click(
//      void selectNewParentbutton_Click(

//----------------------UTILITY METHODS------------------------------//
//      bool nodeIsTerminal(
//      void removeRemainingChildButton_Click
//      void createTreeViewFromDictionary(
//      void moveQANode


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

        //--------------------------------VARIALBES-----------------------------------------------//
        private string movedNodeName ="";
        private int movedNodeChildValue;
        private int movedNodeIndexValue = -1;
        private int movedNodeLevel = -1;
        private TreeNode movedNodesParent = null;
        private TreeNode oldParentNode = null;
        private TreeNode newParentNode = null;
        private TreeNode nodeToMove = null;
        private string oldParentName = "";
        private string oldParentText = "";
        private int oldParentsNumChildren = 0;
        private string newParentName = "";
        private string newParentText = "";
        private int numberOfNewParentsChildren;
        private List<string> alteredQAFileNodeTextValuesList = new List<string>();
        private bool movedNodeIsQA = false;
        private string newParentsChildrenNumberStr = "";
        private Dictionary<string, string> treeViewDictionary = new Dictionary<string, string>();


        //----------------------PUBLIC METHODS------------------------------//

        public void QATreeForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            createTreeViewFromDictionary();
        }// EndQATreeFormLoad

        //-----------------------BUTTON CLICK METHODS------------------------//

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

            if (nodeIsTerminal(selectedNode))
            {

                MessageBox.Show("You cannot Add a node to a Terminal Division Node !! Choose a new Parent!");
                return;
            }

            // Get the NameExtension for this 'Division' node, create a node and add it to the selectedNode in the tree
            //string thisNodeNameExtension = QADataModelLib.NodeChildrenDictionaryModel.returnDivisionNodeName(selectedNode.Name);
            string thisNodeNameExtension = (selectedNode.Nodes.Count).ToString();

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
            //NodeChildrenDictionaryModel.updateNodeChildrenDictionary(selectedNode.Name);

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
            // Create a parent node from the selected node

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
            // Create a string from the int returned above
            string nextQAFileNumberString = qaFileNumber.ToString();
            // Create a new qaNode whose text value is the text in the subjectTextValue 
            // with prefix qa_ to identify it as a QA File
            TreeNode qaNode = new TreeNode("qa_" + subjectTextValue.Text);
            // Add a new stud to the QACumulativerResultsDictionary

           
            //Create the name for this node and append 'q'
            qaNode.Name = selectedNode.Name + "." + nextQAFileNumberString + "q";


            QACumulativeResultsModel.addNewQATestFileRow(nextQAFileNumberString, qaNode.Name, qaNode.Text);
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
            QAFileNameScoresModel.updateQANameScoreDictionary(nextQAFileNumberString, qaFileNumber, qaNode.Name, qaNode.Text, parentChain);
           
            if (!File.Exists(@"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\QAFiles\" + qaNode.Name + ".txt"))
            {
                File.Create(@"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\QAFiles\" + qaNode.Name + ".txt");
            }
        }// End addNewQAFileNodeButton_Click


       

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
        }// End renameNodeButton_Click



       
        /// <summary>
        /// This method is called when the user wants to move a node. When a node in the
        /// tree has been selected and this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectNodetoMoveButton_Click(object sender, EventArgs e)
        {
            // Get needed values about the node to be moved
            nodeToMove = subjectTreeView.SelectedNode;
            oldParentNode = nodeToMove.Parent; 
            movedNodesParent = subjectTreeView.SelectedNode.Parent;
            oldParentName = movedNodesParent.Name;
            oldParentText = movedNodesParent.Text;

            movedNodeName = nodeToMove.Name;
            movedNodeIndexValue = nodeToMove.Index;
            movedNodeLevel = nodeToMove.Level;
            string movedNodeChildValueStr = StringHelperClass.returnNthItemInDelimitedString(movedNodeName, '.', movedNodeIndexValue);
            movedNodeChildValue = Int32.Parse(movedNodeChildValueStr);
            // Determins if this is a QA node and if so add it to alteredQAFileNodeTextValuesList
            if (movedNodeName.IndexOf('q') != -1)
            {
                // This is a QA Node
                alteredQAFileNodeTextValuesList.Add(nodeToMove.Text);
                movedNodeIsQA = true;
                //subjectTreeView.Nodes.Remove(subjectTreeView.SelectedNode);

            }
            
            subjectTreeView.SelectedNode = movedNodesParent;
            oldParentsNumChildren = subjectTreeView.SelectedNode.GetNodeCount(false);

        }// End selectNodetoMoveButton_Click



        /// <summary>
        ///   !!!   The selectNewParentbutton_Click method moves a designated node to a new parent
        ///  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectNewParentbutton_Click(object sender, EventArgs e)
        {
            // Delete the node to be moved
            subjectTreeView.Nodes.Remove(nodeToMove);
            // 1. Get data on new Parent
            newParentName = subjectTreeView.SelectedNode.Name;
            newParentText = subjectTreeView.SelectedNode.Text;
            numberOfNewParentsChildren = subjectTreeView.SelectedNode.Nodes.Count;
            newParentsChildrenNumberStr = numberOfNewParentsChildren.ToString();
            // 1.1 If node to be moved is a QA file call moveQANaod

            if (movedNodeIsQA)
            {
                moveQANode();
                return;
            }

            //2. Create temporary '^' delimited List<string> to hold unchanged, moved and remianing child data
            List<string> unchangesNodesList = new List<string>();
            List<string> movedNodesList = new List<string>();
            List<string> renamedChildNodesList = new List<string>();


            // 3. Create a local copy of treeViewDictionary
            Dictionary<string, string> treeViewDictionary = TreeViewDictionaryModel.getTreeViewDictionary();

            // 4. Cycle thru treeViewDictionary alloting the lines to the appropriate list
            foreach (KeyValuePair<string, string> kvp in treeViewDictionary)
            {
                // 4.a. get the nodeName and text values
                string nodeName = kvp.Key;
                string nodeText = kvp.Value;

                // 4.b. Move the nodes to the proper list
                // 4.b.1. is it an unchanged node?
                if ((nodeName.IndexOf(movedNodeName) != 0) && (nodeName.IndexOf(oldParentName + '.') != 0))
                {
                    unchangesNodesList.Add(nodeName + '^' + nodeText);
                }
                // 4.b.2 is it the node to be moved?
                else if (nodeName == movedNodeName)
                {
                    //this is the node to be moved
                    movedNodesList.Add(nodeName + '^' + nodeText);
                    //movedNodefound = true;
                }
                // 4.b.3. Is it a child of the node to be moved
                else if (nodeName.IndexOf(movedNodeName) == 0)
                {
                    // this is a child of the node to be moved 
                    movedNodesList.Add(nodeName + '^' + nodeText);
                }
                // 4.b.4 is  
                //  4.b.4.a it a remaining child of the old parent
                //  4.b.4.b Or is it an unchanged node
                else //if (nodeName.IndexOf(oldParentName + '.') == 0)
                {
                    //this is a potential child of the old parent
                    // get the movedNodeLevel strig
                    string testNodeLevelStr = StringHelperClass.returnNthItemInDelimitedString(nodeName, '.', movedNodeLevel);
                    int testNodeLevel = Int32.Parse(testNodeLevelStr);
                    if (testNodeLevel > movedNodeLevel)
                    {
                        // this is a remaining child of the oldParent
                        renamedChildNodesList.Add(nodeName + '^' + nodeText);
                    }
                    else
                    {
                        //this is an earlier child of the parent
                        unchangesNodesList.Add(nodeName + '^' + nodeText);
                    }
                }
            } // End Cycle thru treeViewDictionary alloting the lines to the appropriate list



            // 5.  Rename the nodes in the  movedNodesList by
            // 5.1. remove the monedNodeName.Length number of characters from the front of the nodeName
            // 5.2. create a new front string from
            //      5.2.a. the new newParentName + '.'
            //      5.2.b. + newParentsChildrenNumberStr
            // 5.3. Create the new node name from the newFrontString + remiander of the old node name
            // 5.4 Add the renamed node and its text to the list of unchanged Nodes
            // 5.5 Determine if this is a QAFile and ifso add to alteredQAFileNodeTextValuesList

            // Cycle thru movedNodesList changing name and adding to unchangedNodesList
            foreach (string line in movedNodesList)
            {
                string nodeName = StringHelperClass.returnNthItemInDelimitedString(line, '^', 0);
                string nodeText = StringHelperClass.returnNthItemInDelimitedString(line, '^', 1);
                // 5.1
                string nodeNameRemainder = nodeName.Substring(movedNodeName.Length);
                // 5.2
                string newFront = newParentName + '.' + newParentsChildrenNumberStr;
                // 5.3
                nodeName = newFront + nodeNameRemainder;
                string newNodeToAddToUnchangesNodesList = StringHelperClass.replaceNthItemInDelimitedString(line, '^', 0, nodeName);
                // 5.4
                unchangesNodesList.Add(newNodeToAddToUnchangesNodesList);
                // 5.5 
                if (nodeName.IndexOf('q') != -1)
                {
                    alteredQAFileNodeTextValuesList.Add(nodeText);
                }

            }// End Cycle thru movedNodesList changing name and adding to unchangedNodesList

            // 6. Change the renamedChileNodesList 
            // 6.1 get the nodeName and nodeText values 
            // 6.2 Get the string number at the position of the moved node's index value
            // 6.3 convert it to an int, decrement it, string it
            // 6.4 insert the decremented string number into it original position
            // 6.5 add the revised node name and its text to the unchangesNodesList
            // 6.6 Determine if this is a QAFile and ifso add to alteredQAFileNodeTextValuesList

            // 6. cycle thru renamedChileNodesList changing name and adding it to unchangesNodesList
            foreach (string line in renamedChildNodesList)
            {
                // 6.1
                string nodeName = StringHelperClass.returnNthItemInDelimitedString(line, '^', 0);
                string nodeText = StringHelperClass.returnNthItemInDelimitedString(line, '^', 1);
                // 6.2
                string valueToDecrementStr = StringHelperClass.returnNthItemInDelimitedString(nodeName, '.', movedNodeLevel);
                // 6.3
                int valueToDecrementInt = Int32.Parse(valueToDecrementStr);
                valueToDecrementInt--;
                valueToDecrementStr = valueToDecrementInt.ToString();
                // 6.4
                nodeName = StringHelperClass.replaceNthItemInDelimitedString(nodeName, '.', movedNodeLevel, valueToDecrementStr);
                // 6.5
                unchangesNodesList.Add(nodeName + '^' + nodeText);
                // 6.6
                if (nodeName.IndexOf('q') != -1)
                {
                    alteredQAFileNodeTextValuesList.Add(nodeText);
                }
            }

            // 7. Convert tempTreeViewList back into treeViewDictionary
            // 7.1 Clear old treeViewDictionary by creating a new dictionary
            treeViewDictionary = new Dictionary<string, string>();

            // 7.2 Cycle thru tempTreeViewList using nodeName as Key and nodeText as value in the dictionary
            foreach (string line in unchangesNodesList)
            {
                string nodeName = StringHelperClass.returnNthItemInDelimitedString(line, '^', 0);
                string nodeText = StringHelperClass.returnNthItemInDelimitedString(line, '^', 1);
                treeViewDictionary.Add(nodeName, nodeText);
            }// End Cycle thru tempTreeViewList

            // 8. Return revised treeViewDictionary to TreeViewDictionaryModel
            TreeViewDictionaryModel.updateTreeViewDictionary(treeViewDictionary);
            // 9. Clear all the nodes in subjectTreeView and then reconstitute by calling createTreeViewFromDictionary();
            subjectTreeView.Nodes.Clear();
            createTreeViewFromDictionary();
            updateQAFileNameScores();
        }// selectNewParentbuttonClicked




        //----------------------UTILITY METHODS------------------------------//


        /// <summary>
        /// If the node selected is a terminal node, ie. it either has no children or
        /// its first child has qa_ in the Text value
        /// </summary>
        /// <param name="selectedNode"></param>
        /// <returns></returns>
        private bool nodeIsTerminal(TreeNode selectedNode)
        {
            bool returnValue = false;


            //TreeNode firstChild = selectedNode.NextNode;
            TreeNode firstChild = selectedNode.FirstNode;

            //if ( (firstChild == null) || ((firstChild != null && firstChild.Text.StartsWith("qa_"))))

            //
            if (firstChild != null && firstChild.Text.StartsWith("qa_"))
            {
                returnValue = true;
            }
            return returnValue;
        }// End nodeIsTerminal


        private void createTreeViewFromDictionary()
        {
            Dictionary<string, string> treeViewDictionary = new Dictionary<string, string>();
            treeViewDictionary = TreeViewDictionaryModel.getTreeViewDictionary();

            //Cycle thru treeViewDictionary
            foreach (KeyValuePair<string, string> kvp in treeViewDictionary)
            {
                string nodeName = kvp.Key;
                string nodeText = kvp.Value;
                if (subjectTreeView.Nodes.ContainsKey(nodeText))
                    subjectTreeView.Nodes[nodeText].Remove();
            }

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

        /// <summary>
        /// This method is called by selectNewParent_Click method if
        /// the node to be moved is a QA nodde
        /// </summary>
        private void moveQANode()
        {

            // 1.0 Make a copy of treeViewDictionary
            treeViewDictionary = TreeViewDictionaryModel.getTreeViewDictionary();
            // 2. Get the name of the new parent node
            newParentNode = subjectTreeView.SelectedNode;
            // 3. Replace the old parent's name with the new parent's name
            string newMovedNodeName = movedNodeName.Replace(oldParentName, newParentName);
            // 4. Get the moved node's text value
            string movedNodeText = treeViewDictionary[movedNodeName];
            // 5. Remove the old moved node item
            treeViewDictionary.Remove(movedNodeName);
            // 6. add the newMovedNodeName and its text to the dictionaey
            treeViewDictionary.Add(newMovedNodeName, movedNodeText);
            //7. Update the permanent TreeViewDictionary that will be used to reconstruct the tree view
            TreeViewDictionaryModel.updateTreeViewDictionary(treeViewDictionary);
            // 8. Create a new node with the movedNodeText and its updated newMovedNodeName 
            TreeNode newNode = new TreeNode();
            newNode.Text = movedNodeText;
            newNode.Name = newMovedNodeName;
            // 9. Add it to the tree as a child of the new parent, SelectedNode
            subjectTreeView.SelectedNode.Nodes.Add(movedNodeText);
            // 10. update the QAFileNameScoresDictionary
            updateQAFileNameScores();

        }// End  moveQANode()

        private void updateQAFileNameScores()
        {
            
            // 3. Create a local copy of treeViewDictionary
            treeViewDictionary = TreeViewDictionaryModel.getTreeViewDictionary();
            // 10.0 Get a copy of QAFileNameScores
            Dictionary<Int32, string> qaFileNameSocresDictionary = QAFileNameScoresModel.getQANameScoreDictionary();
            // 10.1 Create an inverted treeViewDictionary
            Dictionary<string, string> invertedTreeViewDictionary = new Dictionary<string, string>();
            //10.1 cycle thru treeViewDictionary creating invertedTreeViewDictionary
            foreach (KeyValuePair<string, string> kvp in treeViewDictionary)
            {
                string key = kvp.Key;
                string value = kvp.Value;
                invertedTreeViewDictionary.Add(value, key);
            }
            // 10.1 Get all dictionary lines identifyed by the number portion of all altered QA files
            // 10.2  Cycle thru alteredQAFileNodeTextValuesList
            foreach (string line in alteredQAFileNodeTextValuesList)
            {
                string alteredNodeText = line;
                string keyStrings = "";
                bool numericFound = false;
                // 10.2.a remove leading "qa_"
                alteredNodeText = alteredNodeText.Substring(3);
                // 10.2.b remove all leading non-numeric character values
                for (int i = 0; i < alteredNodeText.Length; i++)
                {
                    char testChar = alteredNodeText[i];
                    if (testChar >= '0' && testChar <= '9')
                    {
                        keyStrings = keyStrings + testChar;
                        numericFound = true;
                    }
                    else if (numericFound)
                    {
                        keyStrings = "";
                        numericFound = false;
                    }
                }// End 10.2.b

                // 10.3 Get the value associated with keyStrings
                string lineToBeRevised = qaFileNameSocresDictionary[Int32.Parse(keyStrings)];
                // TEST if keyStrings =2 lineToBeRevised = qa_Q2^D02<S0^2q^No Test Yet
                // Get the qaFileName
                // get the nodeName associated with valueToBeRevised
                string nodeText = StringHelperClass.returnNthItemInDelimitedString(lineToBeRevised, '^', 0);
                string nodeName = invertedTreeViewDictionary[nodeText];
                int posLastDot = nodeName.LastIndexOf('.');
                string parentNodeName = nodeName.Substring(0, posLastDot);
                string newParentsString = TreeViewDictionaryModel.returnParentChain(parentNodeName);
                string revisedLine = StringHelperClass.replaceNthItemInDelimitedString(lineToBeRevised, '^', 1, newParentsString);
                int keyInt = Int32.Parse(keyStrings);
                qaFileNameSocresDictionary[keyInt] = revisedLine;

                // Return revised qaFileNameSocresDictionary to QAFileNameScoresModel
                QAFileNameScoresModel.reCreateQANameScoreDictionary(qaFileNameSocresDictionary);

            }
        }// End updateQAFileNameScores()


    }// End QATreeForm





}//End QAProject

