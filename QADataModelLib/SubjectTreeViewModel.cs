
//------------------------------VARIABLE DEFINITIONS----------------------------------------//
//------------------------------FILE PATHS--------------------------------------------------//
//      string accessoryFilesPath = @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\";
//      string subjectNodesListPath = accessoryFilesPath + "SubjectNodesList.txt";
//      string treeViewDictionaryPath = accessoryFilesPath + "TreeViewDictionary.txt";
//      string nodeChildDictionaryPath = accessoryFilesPath + "NodeChildDictionary.txt";
//      string qASubjectTreeViewPath = accessoryFilesPath + "QASubjectTreeView.bin";
//      string qaNameScoreFilePath = accessoryFilesPath + "QAFileNameScores.txt"
//------------------------------DATA STORAGE OBJECTS----------------------------------------//
//      Dictionary<string, string> TreeViewDictionary
//      Dictionary<string, int> nodeChildrenDictionary
//      Dictionary<Int32, string> QANameScoreDictionary
//------------------------------PROPERTIES--------------------------------------------------// 
//      Int32 currentMaxQAFileID {
//      bool filesChanged {
//------------------------------GETTERS AND SETTERS-----------------------------------------//
//      Dictionary<Int32, string> getQANameScoreDictionary(
//      setQANameScoreDictionary(
//      List<string> getSubjectNodesList(
//      setSubjectNodesList(
//      Dictionary<string, string> getTreeViewDictionary(
//      setTreeViewDictionary(
//------------------------------METHODS CALLED BY THE QATreeForm----------------------------//
//      string returnParentChain(
//      string returnSubjectNodeName(
//      string returnDivisionNodeName(
//      void updateNodeChildrenDictionary(
//      Boolean AddNode(
//      void saveNodeChildrenDictionary(
//      Int32 returnQAFileName(
//      addQANodeToQANamesDictionary(
//      void  loadNodeChildrenDictionary(
//      Boolean doesNodeHaveChildren(
//      void renameNode(
//------------------------------METHODS CALLED BY ChangeNodeTextValue----------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using QADataModelLib;


namespace QADataModelLib
{
    public static class SubjectTreeViewModel


    {
        //------------------------------VARIABLE DEFINITIONS----------------------------------------//
        //------------------------------FILE PATHS--------------------------------------------------//
        //private static string accessoryFilesPath = @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\";
        //public static string subjectNodesListPath = accessoryFilesPath + "SubjectNodesList.txt";
        //public static string treeViewDictionaryPath = accessoryFilesPath + "TreeViewDictionary.txt";
        //public static string nodeChildDictionaryPath = accessoryFilesPath + "NodeChildDictionary.txt";
        //public static string qASubjectTreeViewPath = accessoryFilesPath + "QASubjectTreeView.bin";
        //public static string qaNameScoreFilePath = accessoryFilesPath + "QAFileNameScores.txt";



        //------------------------------DATA STORAGE OBJECTS----------------------------------------//        

        //private static Dictionary<string, string> TreeViewDictionary = new Dictionary<string, string>();
        /// <summary>
        /// Holds all Subject and Division nodes and each line holds a string node name
        ///   and a integer  indication how many childres that node has
        /// </summary>
        //private static Dictionary<string, int> nodeChildrenDictionary = new Dictionary<string, int>();

        /// <summary>
        /// SubjectNodesList is a variable of type List<string> of the primary subject nodes. Its count is used
        ///   to determine the subjectNodeName. These data are stored in a file called
        ///   SubjectNodesList.txt, who path is accessed by invoking getSubjectNodesListPath()
        /// </summary>
       // private static List<string> SubjectNodesList = new List<string>();


        //private static Dictionary<Int32, string> QANameScoreDictionary = new Dictionary<int, string>();

        // a TODO - currentMaxQAFileID is not obtained from QAFileNameScores.txt unless file is changed, find out how QAFileNameScores is updated

        ////------------------------------PROPERTIES--------------------------------------------------// 
        ///// <summary>
        ///// This Int32 value is used (after incrementation) to be both the ID and in the Name
        ///// of a QAFile entry. Its initial value is set to 0, but as values are downloaded from the
        ///// QAFileNameScores.txt each ID is tested and is replaces, if the current ID is larger.
        ///// This allows me to delete an old QAFile ID if the file is moved to a new location in
        ///// the TreeView
        ///// </summary>
        //public static Int32 currentMaxQAFileID { get; set; } = 0;


        /// <summary>
        /// It true if the TreeView and its associated accessory files were changed
        /// </summary>
        public static bool filesChanged { get; set; } = false;


        //------------------------------GETTERS AND SETTERS-----------------------------------------//


        //public static Dictionary<Int32, string> getQANameScoreDictionary()
        //{
        //    setQANameScoreDictionary();
        //    return QANameScoreDictionary;
        //}

        ///// <summary>
        ///// This method is not called yet because the file is added to by appending, but I will
        ///// need it for the change node text procedure
        ///// </summary>
        //public static void setQANameScoreDictionary()
        //{
        //    //QANameScoreDictionary = new Dictionary<int, string>();
        //    List<string> inputList = new List<string>();
        //    if (File.Exists(qaNameScoreFilePath))
        //    {
        //        //---------------------------------------------------
        //        //If length of the file is not 
        //        //determine if there are data in the file and if so read it into the dictionary
        //        var fil = new FileInfo(qaNameScoreFilePath);
        //        long length = fil.Length;
        //        if (length != 0)
        //        {
        //            string line;
        //            int counter = 0;
        //            // Read the file and display it line by line.  
        //            System.IO.StreamReader file =
        //                new System.IO.StreamReader(qaNameScoreFilePath);
        //            while ((line = file.ReadLine()) != null)
        //            {
        //                inputList.Add(line);
        //                counter++;
        //            }
        //            file.Close();
        //            // For each line in inputList parse it into the dictionary
        //            var qaNameScoreDictionaryList = new List<string>(inputList);
        //            //string line = "";
        //            for(int i =0; i<counter; i++)
        //            {
        //                line = inputList[i];
        //                string[] keyAndValue = line.Split('~');
        //                string keyString = keyAndValue[0];
        //                int key = Int32.Parse(keyString);
        //                if (key > currentMaxQAFileID)
        //                {
        //                    currentMaxQAFileID = key;
        //                }
        //                string value = keyAndValue[1];
        //                QANameScoreDictionary.Add(key, value);
        //            }
        //        }
        //    }
        //}// End setQANameScoreDictionary

        //public static  void resetQANameScoreDictionary(Dictionary<Int32, string> newQANameScoreDictionary)
        //{
        //    QANameScoreDictionary = null;
        //    QANameScoreDictionary = newQANameScoreDictionary;

        //}


        /// <summary>
        /// This method is  called by the ChangeNodeTextValue class when the node that needs
        /// to have its text value changed is a SubjectNode
        /// this method loads the text file containing the entries in the subjectNodeList
        /// each line contains subjectNodeName + "^" + nodeTextValue
        /// </summary>
        public static List<string> getSubjectNodesList()
        {
            //List<string> subjectNodesList = new List<string>();
            // Test to make sure the file exists
            AccessData.getSubjectNodesList();
            // Get a copy of SubjectNodesList
            List<string> copySubjectNodesList = AccessData.getSubjectNodesList();
            return copySubjectNodesList;
        }// End loadSubjectNodesList

        //public static void setSubjectNodesList()
        //{
        //    if (File.Exists(subjectNodesListPath))
        //    {
        //        // If the file length is not 0 open the file and read it into subjectNodesList
        //        var fil = new FileInfo(subjectNodesListPath);
        //        long length = fil.Length;
        //        if (length != 0)
        //        {

        //            string[] lines = File.ReadAllLines(subjectNodesListPath);
        //            SubjectNodesList = new List<string>(lines);
        //        }
        //    }
        //}// End setSubjectNodesList

        ///// <summary>
        ///// This method is called by ChangeNodeTextvalue and returns the TreeViewDictionary
        ///// </summary>
        ///// <returns></returns>
        //public static Dictionary<string, string> getTreeViewDictionary()
        //{
        //    setTreeViewDictionary();
        //    return TreeViewDictionary;
        //}


        ///// <summary>
        ///// This method is called getTreeViewDictionary 
        ///// It opens reads the lines in the  TreeViewDictionary.txt into a ArrayList
        ///// and extracts the '^' keys and values 
        ///// and creates the TreeViewDictionary<string,string> from them
        ///// </summary>
        //public static void setTreeViewDictionary()
        //{
        //    var treeViewdictionaryList = new List<string>();
        //    if (File.Exists(treeViewDictionaryPath))
        //    {
        //        //determine if there are data in the file and if so read it into the dictionary
        //        var fil = new FileInfo(treeViewDictionaryPath);
        //        long length = fil.Length;
        //        if (length != 0)
        //        {
        //            // Read in the file and parse  it into the dictionary
        //            var logFile = File.ReadAllLines(treeViewDictionaryPath);
        //            treeViewdictionaryList = new List<string>(logFile);
        //            //logFile.toList<string>;
        //            foreach (string line in treeViewdictionaryList)
        //            {
        //                string[] keyAndValue = line.Split('^');
        //                TreeViewDictionary.Add(keyAndValue[0], keyAndValue[1]);
        //            }
        //        }
        //    }
        //}// setTreeView




        //------------------------------METHODS CALLED BY THE QATreeForm----------------------------//

        /// <summary>
        /// This method receives the 'name' of the parent of a new QA node and retruns the chain of parents
        /// </summary>
        /// <param name="name" is the delimited name of the parent of a new QA node></param>
        /// <returns></returns>
        public static string returnParentChain(string name)
        {
            // Get a copy of the TreeView Dictionary
            Dictionary<string, string> copyTreeViewDictionary = AccessData.getTreeViewDictionary();
            string parentsChain = "";
            string parentChain = "";
            while (name.Length != 0)
            {
                string nextParentName;
                //Dictionary<string, string> thisTreeViewDictionary = AccessData.getTreeViewDictionary();
                bool success = copyTreeViewDictionary.TryGetValue(name, out nextParentName);
                parentChain = parentChain + nextParentName + "<";
                name = QADataModelLib.DelimitedStringMethods.removeLastValue(name, '.');
                if (name.IndexOf('.') == -1)
                {
                    success = copyTreeViewDictionary.TryGetValue(name, out nextParentName);
                    parentChain = parentChain + nextParentName;
                    return parentChain;

                }
            }

            return parentsChain;
        }

        /// <summary>
        /// Converts the count of subject nodes to a string to return as the subject
        ///   node name and saves the new List entry to SubjectNodesList.txt. 
        /// </summary>
        /// <param name="nodeTextValue"></param>
        /// <returns></returns>
        public static string returnSubjectNodeName(string nodeTextValue)
        {
            // Get a copy of SubjectNodesList
            List<string> copySubjectNodesList = AccessData.getSubjectNodesList();
            int subjectNodeIndexInt = copySubjectNodesList.Count;
            string subjectNodeName = subjectNodeIndexInt.ToString();
            AccessData.updateSubjectNodesList(subjectNodeName, nodeTextValue);

            return subjectNodeName;
        }// End returnSubjectNodeName

        /// <summary>
        /// This method determines the number of children in the parent node,
        ///     converts that integer to a string and returns it as the  node name
        /// </summary>
        /// <param name="parentNodeName"></param>
        /// <returns></returns>
        public static string returnDivisionNodeName(string parentNodeName)
        {

            // Get a copy of the nodeChildrenDictionary Dictionary
            Dictionary<string, int> copyNodeChildrenDictionary = AccessData.getNodeChildrenDictionary();
            if (copyNodeChildrenDictionary.ContainsKey(parentNodeName))
            {
                int numChildren = copyNodeChildrenDictionary[parentNodeName];
                string divisionNodeName = numChildren.ToString();
                filesChanged = true;
                return divisionNodeName;
            }
            else
            {
                return "0";
            }
        }// End returnDivisionNodeName

        ///// <summary>
        ///// This method receives the parent node's name
        ///// and uses it as the key to the nodeChildrenDictionary to get the
        /////   current number of child nodes
        /////  Increments the number of child nodes and stores it in the
        /////     dictionary
        ///// </summary>
        ///// <param name="parentNodeName"></param>
        //public static void updateNodeChildrenDictionary(string parentNodeName)
        //{
        //    if (nodeChildrenDictionary.ContainsKey(parentNodeName))
        //    {
        //        int currentCount = nodeChildrenDictionary[parentNodeName];
        //        currentCount++;
        //        nodeChildrenDictionary[parentNodeName] = currentCount;
        //        filesChanged = true;
        //    }
        //    else
        //    {
        //        nodeChildrenDictionary.Add(parentNodeName, 1);
        //    }
        //}// End updateNodeChildrenDictionary

        /// <summary>
        /// If there is no node whose name value to nodeName then adds a new entry to
        ///  treeViewDictionary with key= nodeName and value = nodeText and saves the new Dictionary 
        ///  to TreeViewDictionary.txt
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="nodeText"></param>
        public static Boolean AddNode(string nodeName, string nodeText)
        {
            // Get a copy of the TreeView Dictionary
            Dictionary<string, string> copyTreeViewDictionary = AccessData.getTreeViewDictionary();

            if (!copyTreeViewDictionary.ContainsKey(nodeName))
            {
                AccessData.addNodeToTreeViewDictionary(nodeName, nodeText);
                return true;
            }
            else
            {
                return false;
            }
        }// End AddNode







        ///// <summary>
        ///// This method is called when the user exit the QATreeForm
        ///// </summary>
        //public static void saveNodeChildrenDictionary()
        //{
        //    string output = "";
        //    foreach (KeyValuePair<string, int> kvp in nodeChildrenDictionary)
        //    {

        //        string key = kvp.Key;
        //        int value = kvp.Value;
        //        string valueString = value.ToString();
        //        output = output + key + "^" + valueString + '\n';
        //    }
        //    File.WriteAllText(nodeChildDictionaryPath, output);
        //}// End saveNodeChildrenDictionary





        /// <summary>
        /// This method determines gets the current largest value of an ID in the QAFileDataTable
        /// which is uploaded from the QAFileNameScores.txt  in the AccessoryFiles folder
        /// </summary>
        /// <returns> the new maximum value for a QAFile ID integer</returns>
        public static Int32 returnQAFileName()
        {
            Int32 newQAFileIDNumber = AccessData.currentMaxQAFileID;
            newQAFileIDNumber++;
            AccessData.currentMaxQAFileID = newQAFileIDNumber;
            return newQAFileIDNumber;
        }// End returnQAFileName



        //public static void addQANodeToQANamesDictionary(int ID, string nodeName, string nodeText, string parentString)
        //{
        //    // The value paramater of this dictionary = nodeName^node's Parents^node Text^latest scort = " ";
        //    string value = nodeText + "^" + parentString + "^" + nodeName + "^No Test Yet";

        //    QANameScoreDictionary.Add(ID, value);
        //    string output = ID.ToString() + '~' + value + '\n';
        //    //File.AppendAllText(qaNameScoreFilePath, output);

        //}// End addQANodeToQANamesDictionary



        //public static void  loadNodeChildrenDictionary()
        //{
        //   // Dictionary<string, int> nodeChildrenDictionary = new Dictionary<string, int>();
        //    if (File.Exists(nodeChildDictionaryPath))
        //    {
        //        //If length of the file is not 
        //        //determine if there are data in the file and if so read it into the dictionary
        //        var fil = new FileInfo(nodeChildDictionaryPath);
        //        long length = fil.Length;
        //        if (length != 0) 
        //        {
        //            // Read in the file and parse  it into the dictionary
        //            var logFile = File.ReadAllLines(nodeChildDictionaryPath);
        //            var nodeChildrenDictionaryList = new List<string>(logFile);
        //            foreach (string line in nodeChildrenDictionaryList)
        //            {
        //                string[] keyAndValue = line.Split('^');
        //                int result = Int32.Parse(keyAndValue[1]);
        //                nodeChildrenDictionary.Add(keyAndValue[0], result);
        //            }
        //        }
        //    }
        //}// End loadNodeChildrenDictionary

        /// <summary>
        /// The nodes contained in nodeChildrendictionary only contain Subject and Division nodes, 
        /// not QA nodes so if thisNodesName appears in nodeChildrendictionary it is a node that 
        /// already has nonQA node children
        /// </summary>
        /// <param name="thisNodesName"></param>
        /// <returns></returns>
        public static Boolean doesNodeHaveChildren(string thisNodesName)
        {
            // Get a copy of the nodeChildrenDictionary Dictionary
            Dictionary<string, int> copyNodeChildrenDictionary = AccessData.getNodeChildrenDictionary();
            if (copyNodeChildrenDictionary.ContainsKey(thisNodesName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }// End doesNodeHaveChildren


        public static void renameNode(string nodeName, string oldNodeText, string newNodeText, int nodeLevel)
        {
            ChangeNodeTextValue.nodeName = nodeName;
            ChangeNodeTextValue.oldNodeText = oldNodeText;
            ChangeNodeTextValue.newNodeText = newNodeText;
            ChangeNodeTextValue.newNodeText = newNodeText;
            ChangeNodeTextValue.changeNodeTextValue();
        }

        //----------------------METHODS that will be transferrec to ChangeNodeGTextValue.cs------------------//

        //public static void saveQAFileNameScoresFile()
        //{
        //    if (QANameScoreDictionary.Count != 0)
        //    {
        //        string output = "";
        //        foreach (KeyValuePair<int, string> kvp in QANameScoreDictionary)
        //        {
        //            int key = kvp.Key;
        //            string keyString = key.ToString();
        //            string value = kvp.Value;
        //            output = output + keyString + "~" + value + '\n';
        //        }
        //        File.AppendAllText(qaNameScoreFilePath, output);

        //        return;
        //    }

       // End saveQAFileNameScoresFile

    //public static List<string> returnSubjectTreeViewNodesList (string filePath)
    //{
    //    List<string> subjectNodeList = new List<string>();  
    //    string[] nodesArray = File.ReadAllLines(filePath);
    //    //  Each line contains a delimited string like '0.0.1q^qa_Plato' where the front value 
    //    //  is the  name of a node and the last is its text value
    //    foreach (string line in nodesArray)
    //    {
    //        //  Get the node's name and text value
    //        string[] nameText = StringHelperClass.getLastDelimitedValue(line, '^');
    //        string nodesName = nameText[0];
    //        string nodesText = nameText[1];
    //        // Get the node's parent name
    //        string[] values = StringHelperClass.getLastDelimitedValue(nodesName, '.');
    //        string parentsName = values[0];
    //        string parentNameTextString = parentsName + '^' + nodesName + '^' + nodesText;
    //        subjectNodeList.Add(parentNameTextString);

    //    }
    //        return subjectNodeList;
    //}





        //------------------------------METHODS CALLED BY ChangeNodeTextValue----------------------//


    }// End SubjectTreeViewModel



}// End QADataModelLib
