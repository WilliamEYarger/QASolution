// PROPERTIES AND VARIABLES
// 
// METHODS
//  void saveAllFiles()
// void returnToDashboardButton_Click()
// void addNewSubjectButton_ClicK()
// void addNewSubjectDivisionButton_Click()
// void addNewQAFileNodeButton_Click
// void loadTreeButton_Click
// saveTreeButton_Click
//  QATreeForm_Load()
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

        // the following is a test area
        private void PrintRecursive(TreeNode treeNode)
        {
            // Print the node.  
            //System.Diagnostics.Debug.WriteLine(treeNode.Text);
            // MessageBox.Show(treeNode.Text);
            output = output + treeNode.Name + '^' + treeNode.Text + '\n';
            // Print each node recursively.  
            foreach (TreeNode tn in treeNode.Nodes)
            {
                PrintRecursive(tn);
            }
        }

        // Call the procedure using the TreeView.  
        private string CallRecursive(System.Windows.Forms.TreeView subjectTreeView)
        {
            // Print each node recursively.  
            TreeNodeCollection nodes = subjectTreeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                PrintRecursive(n);
            }
            return output;
        }

        /// <summary>
        /// This method saves the TreeView as a double delimited text file, aswellas  the nodeChildrenDictionary 
        /// and the QANameScoresdictionary as .txt files
        /// </summary>
        public void saveAllFiles()
        {


            string qaTreePath = SubjectTreeViewModel.getQASubjectTreeViewPath();

            if (SubjectTreeViewModel.filesChanged)
            {
                if (File.Exists(qaTreePath))
                {
                    File.Delete(qaTreePath);
                }
                // Create new array

                ArrayList al = new ArrayList();
                foreach (TreeNode tn in subjectTreeView.Nodes)
                {
                    // back up every RootNode in the TreeView ...
                    al.Add(tn);
                }

                // create file
                Stream file = File.Open(qaTreePath, FileMode.Create);
                // Binary formatting init.
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    // Serializing the array
                    bf.Serialize(file, al);
                }
                catch (System.Runtime.Serialization.SerializationException eeex2)
                {
                    MessageBox.Show("Serialization failed : {0}", eeex2.Message);
                }

                // Close file
                file.Close();


                ////  1. CallRecursive() to convert the TreeView into a \n and ^ delimited string 
                ////      of nameID/subjecgtText pairs
                //string treeViewOutput = CallRecursive(subjectTreeView);
                ////  2.  Write the output delimited string to a text file
                //File.WriteAllText(SubjectTreeViewModel.getQASubjectTreeViewPath(), treeViewOutput);


                // 2. Save saveNodeChildrenDictionary
                SubjectTreeViewModel.saveNodeChildrenDictionary();

                // 3. Save the QAFileNameScores.txt  file
                //SubjectTreeViewModel.saveQAFileNameScoresFile();

                // 4. The TreeViewDictionary is Only appended to so no save procedure is necessary

                // 5. The SubjectNodesList is Only appended to so no save procedure is necessary

                // Now that all files have been saved filesChanges is false
                SubjectTreeViewModel.filesChanged = false;
                loadTreeButton.Enabled = false;
            }
        }// End saveAllFiles



        /// <summary>
        /// This method cals saveAllFiles() to save any changes to the tree
        /// and then hides the qaTreeForm and opens the dashboardForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void returnToDashboardButton_Click(object sender, EventArgs e)
        {
            saveAllFiles();
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
            TreeNode subjectTreeNode = new TreeNode(subjectTextValue.Text);
            // Get the node's name property
            subjectTreeNode.Name = SubjectTreeViewModel.returnSubjectNodeName(subjectTextValue.Text);
            // If this node name has not already beed used add this node
            if (!SubjectTreeViewModel.AddNode(subjectTreeNode.Name, subjectTreeNode.Text))
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
            // Get the NameExtension for this 'Division' node, create a node and add it to the selectedNode in the tree
            string thisNodeNameExtension = SubjectTreeViewModel.returnDivisionNodeName(selectedNode.Name);
            // Create a new DivisionNode with text value = subjectTextValue
            TreeNode DivisionNode = new TreeNode(subjectTextValue.Text);
            // Create the name by appending thisNodeNameExtension to the parentNode's name
            DivisionNode.Name = selectedNode.Name + "." + thisNodeNameExtension;
            // If a node with this name is not already present add node to  the treeViewDictionary
            if (!SubjectTreeViewModel.AddNode(DivisionNode.Name, DivisionNode.Text))
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
            SubjectTreeViewModel.updateNodeChildrenDictionary(selectedNode.Name);

        }// End add Subject Division button clicked

        /// <summary>
        ///  This method 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNewQAFileNodeButton_Click(object sender, EventArgs e)
        {
            // TODO - new QA files are not being added when 1 already exists

            TreeNode selectedNode = subjectTreeView.SelectedNode;
            // Determine if this node has children, is so it cannot hold a QAFile
            Boolean nodeHasChildren = SubjectTreeViewModel.doesNodeHaveChildren(selectedNode.Name);
            if (nodeHasChildren)
            {
                MessageBox.Show("You Cannot add a QAFile Node to a Node that has Division Node Children");
                return;
            }
            //  Get the Chain of parents of the new node to be added
            string parentChain = SubjectTreeViewModel.retrunParentChain(selectedNode.Name);


            // The following returns the current value of the current value of currentMaxQAFileID
            int qaFileNumber = SubjectTreeViewModel.returnQAFileName();
            string nextQAFileNumberString = qaFileNumber.ToString();
            // Create a new qaNode whose text value is the text in the subjectTextValue 
            // with prefix qa_ to identify it as a QA File
            TreeNode qaNode = new TreeNode("qa_" + subjectTextValue.Text);
            //Create the name for this node and append 'q'
            qaNode.Name = selectedNode.Name + "." + nextQAFileNumberString + "q";
            // Test to make sure no node with with name already exists in treeViewDictionary
            if (!SubjectTreeViewModel.AddNode(qaNode.Name, qaNode.Text))
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
            SubjectTreeViewModel.addQANodeToQANamesDictionary(qaFileNumber, qaNode.Name, qaNode.Text, parentChain);
            // Create a file in  @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\QAFiles"
            //      whose name is qaNode.Name value

            if (!File.Exists(@"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\QAFiles\" + qaNode.Name + ".txt"))
            {
                File.Create(@"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\QAFiles\" + qaNode.Name + ".txt");
            }
        }// End addNewQAFileNodeButton_Click





        private void loadTreeButton_Click(object sender, EventArgs e)
        {
            string filePath = SubjectTreeViewModel.getQASubjectTreeViewPath();


            if (File.Exists(filePath))
            {
                if (File.Exists(filePath))
                {
                    // open file
                    Stream file = File.Open(filePath, FileMode.Open);
                    // Binary formatting init.
                    BinaryFormatter bf = new BinaryFormatter();
                    // Object var. init.
                    object obj = null;
                    try
                    {
                        // Deserialize data from the file
                        obj = bf.Deserialize(file);
                    }
                    catch (System.Runtime.Serialization.SerializationException ex1)
                    {
                        MessageBox.Show("De-Serialization failed ");
                    }
                    // Close File
                    file.Close();

                    // Create a new array
                    ArrayList nodeList = obj as ArrayList;

                    // load Root-Nodes
                    foreach (TreeNode node in nodeList)
                    {
                        subjectTreeView.Nodes.Add(node);
                    }
                }

                ////  1.  Send path to SubjectTreeViewModel.returnSubjectTreeView
                //List<string>  nodeList = SubjectTreeViewModel.returnSubjectTreeViewNodesList(filePath);
                //foreach(string line in nodeList)
                //{
                //    string[] values = line.Split('^');
                //    string parentsName = values[0];
                //    string nodesName = values[1];
                //    string nodesText = values[2];
                //    TreeNode thisNode = new TreeNode(nodesText);
                //    thisNode.Name = nodesName;
                //    if (parentsName == "")
                //    {
                //        // This is a main subject note
                //        subjectTreeView.Nodes.Add(thisNode);
                //    }
                //    else
                //    {
                //        // This is a Division node or a qa node
                //        TreeNode selectedNode = new TreeNode();
                //        selectedNode.Name = parentsName;
                //        subjectTreeView.SelectedNode = selectedNode;
                //        subjectTreeView.SelectedNode.Nodes.Add(thisNode);
                //    }
                //}




            }// End loadTree button clicked




            /// <summary>
            /// This method loads the tree and all the files from the disk 
            /// into the TreeView and the various Lists and Dictionaries
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            //public void QATreeForm_Load(object sender, EventArgs e)
            //{
            //    this.ControlBox = false;
            //    loadTreeButton.PerformClick();
            //    //subjectTreeView.BeginUpdate();
            //    SubjectTreeViewModel.loadSubjectNodesList();
            //    SubjectTreeViewModel.loadTreeViewDictionary();
            //    SubjectTreeViewModel.loadNodeChildrenDictionary();
            //    SubjectTreeViewModel.loadQANameScoreDictionary();
            //}// End QATreeForm_Load


        }// End (File.Exists(filePath))

        private void QATreeForm_Load(object sender, EventArgs e)
        {
            loadTreeButton.PerformClick();
        }
    }// End QATreeForm
}//End QAProject


