// Properties and Varialbes
// string  accessoryFilesPath
// string  subjectNodesListPath
// string  treeViewDictionaryPath
// string  nodeChildDictionaryPath
// string  qASubjectTreeViewPath
// bool filesChanged { get; set; } = false;
// List<string> subjectNodesList
// Dictionary<string, string> treeViewDictionary
// Dictionary<Int32, string> qaNamesScoreDictionary
// Dictionary<string, int> nodeChildrenDictionary

// METHODS
// string getSubjectNodesListPath()
// string getTreeViewDictionaryPath()
// string getNodeChildDictionaryPath()
// string getQASubjectTreeViewPath()
// string returnSubjectNodeName(string nodeTextValue)
// Boolean AddNode(string nodeName, string nodeText)
// string returnDivisionNodeName(string parentNodeName)
// void updateNodeChildrenDictionary(string parentNodeName)
// void saveNodeChildrenDictionary()
// string GetLine(Dictionary<string, int> data)
// static int returnQAFileName()
// void addQANodeToQANamesDictionary(Int32 id, string nodeText)
// void loadSubjectNodesList()
// void  loadTreeViewDictionary()
// void  loadNodeChildrenDictionary()
// 
// 

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using QADataModelLib;


namespace QADataModelLib
{
    public static class SubjectTreeViewModel


    {

        /// <summary>
        /// This Int32 value is used (aftger incrementation) to be both the ID and in the Name
        /// of a QAFile entry. Its initial value is set to 0, but as values are downloaded from the
        /// QAFileNameScores.txt each ID is testes and is replaces, if the current ID is larger.
        /// This allows me to delete an old QAFile ID if the file is moved to a new location in
        /// the TreeView
        /// </summary>
        public static Int32 currentMaxQAFileID { get; set; } = 0;

        // Create path strings for all files and add getter methods
        private static string accessoryFilesPath = @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\";

        private static string subjectNodesListPath = accessoryFilesPath + "SubjectNodesList.txt";
        public static string getSubjectNodesListPath()
        {
            return subjectNodesListPath;
        }

        private static string treeViewDictionaryPath = accessoryFilesPath + "TreeViewDictionary.txt";
        public static string getTreeViewDictionaryPath()
        {
            return treeViewDictionaryPath;
        }

        private static string nodeChildDictionaryPath = accessoryFilesPath + "NodeChildDictionary.txt";
        public static string getNodeChildDictionaryPath()
        {
            return nodeChildDictionaryPath;
        }

        private static string qASubjectTreeViewPath = accessoryFilesPath + "QASubjectTreeView.bin";

        public static string getQASubjectTreeViewPath()
        {
            return qASubjectTreeViewPath;
        }

        private static string qaNameScoreFilePath = accessoryFilesPath + "QAFileNameScores.txt";
        public static string getQANameScoreFilePath()
        {
            return qaNameScoreFilePath;
        }

        /// <summary>
        /// It true if the TreeView and its associated accessory files were changed
        /// </summary>
        public static bool filesChanged { get; set; } = false;

        /// <summary>
        /// subjectNodesList is a list of the primary subject nodes. Its count is used
        ///   to determine the subjectNodeName. These data are stored in a file called
        ///   SubjectNodesList.txt, who path is accessed by invoking getSubjectNodesListPath()
        /// </summary>
        private static List<string> subjectNodesList = new List<string>();

        /// <summary>
        /// the treeViewDictionary is used to make sure that there are no existing node that has
        ///     the same name as a proposed addition. These data are stored in a file called
        ///     TreeViewDictionary.txt and it path is accessed by calling getTreeViewDictionaryPath()
        ///     each line holds (nodeName, nodeText); and all subject, division and qa nodes are included
        /// </summary>
        private static Dictionary<string, string> treeViewDictionary = new Dictionary<string, string>();


        /// <summary>
        /// The qaNamesScoreDictionary contains all of the QA Files, irrespective of parents. Its int Key 
        ///     is used to determine its qa File name and its value property is a delimited string containin
        ///     the node's text value property; a '<' delimited string on ancestory from nearest to futerist, 
        ///     its file name (which is composed of its ancestor's names+its ID(to String)+'q', and a
        ///     blank row which will hold the latest result of testing percet correct, coverted to a string ie:
        ///     6|New Testament Cannons|Pre-Nicaean 0-300 CE<Christianity<History|1.0.0.6q|45
        /// </summary>
        private static Dictionary<Int32, string> qaNamesScoreDictionary = new Dictionary<int, string>();

        /// <summary>
        /// Holds all Subject and Division nodes and each line holds a string node name
        ///   and a integer  indication how many childres that node has
        /// </summary>
        private static Dictionary<string, int> nodeChildrenDictionary = new Dictionary<string, int>();

        private static Dictionary<int, string> qaNameScoreDictionary = new Dictionary<int, string>();

        /// <summary>
        /// This method receives the parent of a new QA node and retruns the chain of parents
        /// </summary>
        /// <param name="name" is the delimited name of the parent of a new QA node></param>
        /// <returns></returns>
        public static string retrunParentChain(string name)
        {
            string parentsChain = "";
            string parentChain = "";
            while(name.Length != 0)
            {

                string nextParentName = "";
                bool success = treeViewDictionary.TryGetValue(name, out nextParentName);
                parentChain = parentChain + nextParentName + "<";
                name = QADataModelLib.DelimitedStringMethods.removeLastValue(name, '.');
                if(name.IndexOf('.') == -1)
                {
                    success = treeViewDictionary.TryGetValue(name, out nextParentName);
                    parentChain = parentChain + nextParentName ;
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
            int subjectNodeIndexInt = subjectNodesList.Count;
            string subjectNodeName = subjectNodeIndexInt.ToString();
            subjectNodesList.Add(subjectNodeName + "^" + nodeTextValue);
            File.AppendAllText(accessoryFilesPath + "SubjectNodesList.txt", subjectNodeName + "^" + nodeTextValue + '\n');
            
            return subjectNodeName;
        }// End returnSubjectNodeName

        /// <summary>
        /// If there is no node whose name value to nodeName then adds a new entry to
        ///  treeViewDictionary with key= nodeName and value = nodeText and saves the new Dictionary 
        ///  to TreeViewDictionary.txt
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="nodeText"></param>
        public static Boolean AddNode(string nodeName, string nodeText)
        {

            if (!treeViewDictionary.ContainsKey(nodeName))
            {
                treeViewDictionary.Add(nodeName, nodeText);
                File.AppendAllText(accessoryFilesPath + "TreeViewDictionary.txt", nodeName + "^" + nodeText + '\n');
                filesChanged = true;
                return true;
            }
            else
            {
                return false;
            }
        }// End AddNode


        /// <summary>
        /// This method determines the number of children in the parent node,
        ///     converts that integer to a string and returns it as the  node name
        /// </summary>
        /// <param name="parentNodeName"></param>
        /// <returns></returns>
        public static string returnDivisionNodeName(string parentNodeName)
        {
            if (nodeChildrenDictionary.ContainsKey(parentNodeName))
            {
                int numChildren = nodeChildrenDictionary[parentNodeName];
                string divisionNodeName = numChildren.ToString();
                filesChanged = true;
                return divisionNodeName;
            }
            else
            {
                return "0";
            }
        }// End returnDivisionNodeName

        /// <summary>
        /// This method receives the parent node's name
        /// and uses it as the key to the nodeChildrenDictionary to get the
        ///   current number of child nodes
        ///  Increments the number of child nodes and stores it in the
        ///     dictionary
        /// </summary>
        /// <param name="parentNodeName"></param>
        public static void updateNodeChildrenDictionary(string parentNodeName)
        {
            if (nodeChildrenDictionary.ContainsKey(parentNodeName))
            {
                int currentCount = nodeChildrenDictionary[parentNodeName];
                currentCount++;
                nodeChildrenDictionary[parentNodeName] = currentCount;
                filesChanged = true;
            }
            else
            {
                nodeChildrenDictionary.Add(parentNodeName, 1);
            }
        }// End updateNodeChildrenDictionary


        /// <summary>
        /// This method is called when the user exit the QATreeForm
        /// </summary>
        public static void saveNodeChildrenDictionary()
        {
            string output = "";
            foreach (KeyValuePair<string, int> kvp in nodeChildrenDictionary)
            {
              
                string key = kvp.Key;
                int value = kvp.Value;
                string valueString = value.ToString();
                output = output + key + "^" + valueString + '\n';
            }
            File.WriteAllText(getNodeChildDictionaryPath(), output);
        }// End saveNodeChildrenDictionary



        private static string GetLine(Dictionary<string, int> data)
        {
            // Build up the string data.
            StringBuilder builder = new StringBuilder();
            foreach (var pair in data)
            {
                builder.Append(pair.Key).Append("^").Append(pair.Value).Append('\n');
            }
            string result = builder.ToString();
            // Remove the end comma.
            result = result.TrimEnd('\n');
            return result;
        }// End GetLine(Dictionary<string, string> 

        public static void loadQANameScoreDictionary()
        {

            // Dictionary<string, int> nodeChildrenDictionary = new Dictionary<string, int>();
            if (File.Exists(getQANameScoreFilePath()))
            {
                //If length of the file is not 
                //determine if there are data in the file and if so read it into the dictionary
                var fil = new FileInfo(getQANameScoreFilePath());
                long length = fil.Length;
                if (length != 0)
                {

                    // Read in the file and parse  it into the dictionary
                    var logFile = File.ReadAllLines(getQANameScoreFilePath());
                    var qaNameScoreDictionaryList  = new List<string>(logFile);
                    foreach (string line in qaNameScoreDictionaryList)
                    {
                        string[] keyAndValue = line.Split('~');
                        string keyString = keyAndValue[0];
                        int key = Int32.Parse(keyString);
                        if (key> currentMaxQAFileID)
                        {
                            currentMaxQAFileID = key;
                        }
                        string value = keyAndValue[1];
                        qaNameScoreDictionary.Add(key, value);

                    }
                }
            }

        }


        /// <summary>
        /// This method determines gets the current largest value of an ID in the QAFileDataTable
        /// which is uploaded from the QAFileNameScores.txt  in the AccessoryFiles folder
        /// </summary>
        /// <returns> the new maximum value for a QAFile ID integer</returns>
        public static Int32 returnQAFileName()
        {
            Int32 newQAFileIDNumber = currentMaxQAFileID + 1;
            currentMaxQAFileID = newQAFileIDNumber;
            return newQAFileIDNumber;
        }// End returnQAFileName



        public static void addQANodeToQANamesDictionary(int ID, string nodeName, string nodeText, string parentString)
        {
            // The value paramater of this dictionary = nodeName^node's Parents^node Text^latest scort = " ";
            string value = nodeText + "^" + parentString + "^" + nodeName + "^No Test Yet";

            qaNamesScoreDictionary.Add(ID, value);
            string output = ID.ToString() + '~' + value + '\n';
            File.AppendAllText(getQANameScoreFilePath(), output);


        }// End addQANodeToQANamesDictionary


        /// <summary>
        /// this method loads the text file containing the entries in the subjectNodeList
        /// each line contains subjectNodeName + "^" + nodeTextValue
        /// </summary>
        public static void loadSubjectNodesList()
        {
            // Test to make sure the file exists
            if (File.Exists(getSubjectNodesListPath()))
            {
                // If the file length is not 0 open the file and read it into subjectNodesList
                var fil = new FileInfo(getSubjectNodesListPath());
                long length = fil.Length;
                if (length != 0)
                {

                    string[] lines = File.ReadAllLines(getSubjectNodesListPath());
                    subjectNodesList = new List<string>(lines);
                }
            }
        }// End loadSubjectNodesList

        /// <summary>
        /// This method determines if TreeViewDictionary.txt exists and if it is not empty loads i
        /// into Dictionary<string, string> treeViewDictionary
        /// </summary>
        public static void  loadTreeViewDictionary()
        {
            if (File.Exists(getTreeViewDictionaryPath()))
            {
                //determine if there are data in the file and if so read it into the dictionary
                var fil = new FileInfo(getTreeViewDictionaryPath());
                long length = fil.Length;
                if (length != 0)
                {
                    // Read in the file and parse  it into the dictionary
                    var logFile = File.ReadAllLines(getTreeViewDictionaryPath());
                    var treeViewdictionaryList = new List<string>(logFile);
                    foreach(string line in treeViewdictionaryList)
                    {
                        string[] keyAndValue = line.Split('^');
                        treeViewDictionary.Add(keyAndValue[0], keyAndValue[1]);
                    }

                }
            }

        }// End loadTreeViewDictionary


        public static void  loadNodeChildrenDictionary()
        {
           // Dictionary<string, int> nodeChildrenDictionary = new Dictionary<string, int>();
            if (File.Exists(getNodeChildDictionaryPath()))
            {
                //If length of the file is not 
                //determine if there are data in the file and if so read it into the dictionary
                var fil = new FileInfo(getNodeChildDictionaryPath());
                long length = fil.Length;
                if (length != 0) 
                {
                    // Read in the file and parse  it into the dictionary
                    var logFile = File.ReadAllLines(getNodeChildDictionaryPath());
                    var nodeChildrenDictionaryList = new List<string>(logFile);
                    foreach (string line in nodeChildrenDictionaryList)
                    {
                        string[] keyAndValue = line.Split('^');
                        int result = Int32.Parse(keyAndValue[1]);
                        nodeChildrenDictionary.Add(keyAndValue[0], result);
                    }
                }
            }
        }// End loadNodeChildrenDictionary


        public static Boolean doesNodeHaveChildren(string thisNodesName)
        {
            if (nodeChildrenDictionary.ContainsKey(thisNodesName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void saveQAFileNameScoresFile()
        {
           if(qaNamesScoreDictionary.Count != 0)
            {
                string output = "";
                foreach (KeyValuePair<int, string> kvp in qaNamesScoreDictionary)
                {
                    int key = kvp.Key;
                    string keyString = key.ToString();
                    string value = kvp.Value;
                    output = output + keyString + "~" + value + '\n';
                }
                File.AppendAllText(getQANameScoreFilePath(), output);
            }

        }// End saveQAFileNameScoresFile

        public static List<string> returnSubjectTreeViewNodesList (string filePath)
        {
            List<string> subjectNodeList = new List<string>();  
            string[] nodesArray = File.ReadAllLines(filePath);
            //  Each line contains a delimited string like '0.0.1q^qa_Plato' where the front value 
            //  is the  name of a node and the last is its text value
            foreach (string line in nodesArray)
            {
                //  Get the node's name and text value
                string[] nameText = StringHelperClass.getLastDelimitedValue(line, '^');
                string nodesName = nameText[0];
                string nodesText = nameText[1];
                // Get the node's parent name
                string[] values = StringHelperClass.getLastDelimitedValue(nodesName, '.');
                string parentsName = values[0];
                string parentNameTextString = parentsName + '^' + nodesName + '^' + nodesText;
                subjectNodeList.Add(parentNameTextString);

            }
                return subjectNodeList;
        }



    }// End SubjectTreeViewModel
}// End QADataModelLib
