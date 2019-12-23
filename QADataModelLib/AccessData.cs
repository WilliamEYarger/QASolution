//------------------------------PROPERTIES--------------------------------------------------// 
//      Int32 currentMaxQAFileID {
//------------------------------FILE PATHS--------------------------------------------------//
//       string accessoryFilesPath
//       string subjectNodesListPath 
//       string treeViewDictionaryPath
//       string nodeChildDictionaryPath
//       string qASubjectTreeViewPath
//       string qaNameScoreFilePath
//       string qaCumulativeResultsPath
//------------------------------DATA STRUCTURES---------------------------------------------//
//       Dictionary<string, int> nodeChildrenDictionary
//       Dictionary<Int32, string> QANameScoreDictionary
//       List<string> SubjectNodesList
//       Dictionary<string, string> TreeViewDictionary
//       DataTable qaCumulativeResultsTable 
//------------------------------GETTERS AND SETTERS---------------------------------------//
//       Dictionary<string, int> getNodeChildrenDictionary(
//       Dictionary<Int32, string> getQANameScoreDictionary(
//       string getQASubjectTreePath(
//       static List<string> getSubjectNodesList(
//       Dictionary<string, string> getTreeViewDictionary(
//------------------------------FILE LOADER METHODS---------------------------------------//
//       public static void openAllFiles(
//       private static void loadNodeChildrenDictionary(
//       private static void loadQANameScoreDictionary(
//       private static void loadSubjectNodesList(
//       private static void loadTreeViewDictionary(
//       private static void loadQACumulativeResultFile(
//------------------------------FILE SAVER METHODS----------------------------------------//
//       public static void  saveAllFiles(
//       private static void saveNodeChildrenDictionary(
//       private static void saveQAFileNameScoresFile(
//       private static void saveSubjectNodeList(
//       private static void saveTreeViewDictionary(
//       private static void saveQACumulativeResultsFile(
//------------------------------OTHER METHODS---------------------------------------------//
//       void updateQANameScoreDictionary(
//       void addNodeToTreeViewDictionary(
//       void updateNodeChildrenDictionary(
//       
//       
//       




using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Linq;

namespace QADataModelLib
{

    /// <summary>
    /// This class creates and saves add data structures used by the project
    /// All data structures will be created with the project opens 
    /// and saved when the project closes
    /// The class also manages the construction and deconstruction of all
    /// data structures into appropriate text file format
    /// It uses classic Variables with getters and setters rather than properties
    /// </summary>
    public static class AccessData
    // TODO - Load QACumulativeResults


    {

        //------------------------------PROPERTIES--------------------------------------------------// 
        /// <summary>
        /// This Int32 value is used (after incrementation) to be both the ID and in the Name
        /// of a QAFile entry. Its initial value is set to 0, but as values are downloaded from the
        /// QAFileNameScores.txt each ID is tested and is replaces, if the current ID is larger.
        /// This allows me to delete an old QAFile ID if the file is moved to a new location in
        /// the TreeView
        /// </summary>
        public static Int32 currentMaxQAFileID { get; set; } = 0;


        //------------------------------FILE PATHS--------------------------------------------------//
        private static string accessoryFilesPath = @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\";
        public static string subjectNodesListPath = accessoryFilesPath + "SubjectNodesList.txt";
        public static string treeViewDictionaryPath = accessoryFilesPath + "TreeViewDictionary.txt";
        public static string nodeChildDictionaryPath = accessoryFilesPath + "NodeChildDictionary.txt";
        public static string qASubjectTreeViewPath = accessoryFilesPath + "QASubjectTreeView.bin";
        public static string qaNameScoreFilePath = accessoryFilesPath + "QAFileNameScores.txt";
        public static string qaCumulativeResultsPath = accessoryFilesPath + "QACumulativeResults.txt";

        //------------------------------DATA STRUCTURES---------------------------------------------//

        /// <summary>
        /// Holds all Subject and Division nodes and each line holds a string node name
        ///   and a integer  indication how many childres that node has
        /// </summary>
        private static Dictionary<string, int> nodeChildrenDictionary = new Dictionary<string, int>();
        private static Dictionary<Int32, string> QANameScoreDictionary = new Dictionary<int, string>();
        /// <summary>
        /// SubjectNodesList is a variable of type List<string> of the primary subject nodes. Its count is used
        ///   to determine the subjectNodeName. These data are stored in a file called
        ///   SubjectNodesList.txt, who path is accessed by invoking getSubjectNodesListPath()
        /// </summary>
        private static List<string> SubjectNodesList = new List<string>();
        private static Dictionary<string, string> TreeViewDictionary = new Dictionary<string, string>();

        private static DataTable qaCumulativeResultsTable = new DataTable();

        //------------------------------GETTERS AND SETTERS---------------------------------------//

        public static Dictionary<string, int> getNodeChildrenDictionary()
        {
            return nodeChildrenDictionary;
        }// End getNodeChildrenDictionary(

        public static Dictionary<Int32, string> getQANameScoreDictionary()
        {
            return QANameScoreDictionary;
        }// End getQANameScoreDictionary

        public static string getQASubjectTreePath()
        {
            return qASubjectTreeViewPath;
        }

        public static List<string> getSubjectNodesList()
        {
            return SubjectNodesList;
        }

        /// <summary>
        /// This method is called by ChangeNodeTextvalue and returns the TreeViewDictionary
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> getTreeViewDictionary()
        {
            return TreeViewDictionary;
        }
        //------------------------------FILE LOADER METHODS---------------------------------------//

            public static void openAllFiles()
        {
            loadNodeChildrenDictionary();
            loadQANameScoreDictionary();
            loadSubjectNodesList();
            loadTreeViewDictionary();
            loadQACumulativeResultFile();
        }
        private static void loadNodeChildrenDictionary()
        {
            // Dictionary<string, int> nodeChildrenDictionary = new Dictionary<string, int>();
            if (File.Exists(nodeChildDictionaryPath))
            {
                //If length of the file is not 
                //determine if there are data in the file and if so read it into the dictionary
                var fil = new FileInfo(nodeChildDictionaryPath);
                long length = fil.Length;
                if (length != 0)
                {
                    // Read in the file and parse  it into the dictionary
                    var logFile = File.ReadAllLines(nodeChildDictionaryPath);
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

        /// <summary>
        /// 
        /// </summary>
        private static void loadQANameScoreDictionary()
        {
            //QANameScoreDictionary = new Dictionary<int, string>();
            List<string> inputList = new List<string>();
            if (File.Exists(qaNameScoreFilePath))
            {
                
                //determine if there are data in the file and if so read it into the dictionary
                var fil = new FileInfo(qaNameScoreFilePath);
                long length = fil.Length;
                if (length != 0)
                {
                    string line;
                    int counter = 0;
                    // Read the file and display it line by line.  
                    System.IO.StreamReader file =
                        new System.IO.StreamReader(qaNameScoreFilePath);
                    while ((line = file.ReadLine()) != null)
                    {
                        inputList.Add(line);
                        counter++;
                    }
                    file.Close();
                    // For each line in inputList parse it into the dictionary
                    var qaNameScoreDictionaryList = new List<string>(inputList);
                    //string line = "";
                    for (int i = 0; i < counter; i++)
                    {
                        line = inputList[i];
                        string[] keyAndValue = line.Split('~');
                        string keyString = keyAndValue[0];
                        int key = Int32.Parse(keyString);
                        if (key > currentMaxQAFileID)
                        {
                            currentMaxQAFileID = key;
                        }
                        string value = keyAndValue[1];
                        QANameScoreDictionary.Add(key, value);
                    }
                }
            }
        }// End setQANameScoreDictionary

        private static void loadSubjectNodesList()
        {
            if (File.Exists(subjectNodesListPath))
            {
                // If the file length is not 0 open the file and read it into subjectNodesList
                var fil = new FileInfo(subjectNodesListPath);
                long length = fil.Length;
                if (length != 0)
                {

                    string[] lines = File.ReadAllLines(subjectNodesListPath);
                    SubjectNodesList = new List<string>(lines);
                }
            }
        }// End setSubjectNodesList

        /// <summary>
        /// This method is called getTreeViewDictionary 
        /// It opens reads the lines in the  TreeViewDictionary.txt into a ArrayList
        /// and extracts the '^' keys and values 
        /// and creates the TreeViewDictionary<string,string> from them
        /// </summary>
        private static void loadTreeViewDictionary()
        {
            var treeViewdictionaryList = new List<string>();
            if (File.Exists(treeViewDictionaryPath))
            {
                //determine if there are data in the file and if so read it into the dictionary
                var fil = new FileInfo(treeViewDictionaryPath);
                long length = fil.Length;
                if (length != 0)
                {
                    // Read in the file and parse  it into the dictionary
                    var logFile = File.ReadAllLines(treeViewDictionaryPath);
                    treeViewdictionaryList = new List<string>(logFile);
                    //logFile.toList<string>;
                    foreach (string line in treeViewdictionaryList)
                    {
                        string[] keyAndValue = line.Split('^');
                        TreeViewDictionary.Add(keyAndValue[0], keyAndValue[1]);
                    }
                }
            }
        }// setTreeViewDictionary

        // TODO - This has not yet been completely verified
        private static void loadQACumulativeResultFile()
        {
            if (File.Exists(qaCumulativeResultsPath))
            {

                qaCumulativeResultsTable.Columns.Add("File Name", typeof(string));
                qaCumulativeResultsTable.Columns.Add("File Text", typeof(string));
                qaCumulativeResultsTable.Columns.Add("Date Taken", typeof(string));
                qaCumulativeResultsTable.Columns.Add("% Correct", typeof(string));
                qaCumulativeResultsTable.Columns.Add("Incorrect Answers", typeof(string));
                string[] lines = File.ReadAllLines(qaCumulativeResultsPath);
                string[] values;
                for (int i = 0; i < lines.Length; i++)
                {
                    values = lines[i].ToString().Split('^');
                    string[] row = new string[values.Length];

                    for (int j = 0; j < values.Length; j++)
                    {
                        row[j] = values[j].Trim();
                    }
                    qaCumulativeResultsTable.Rows.Add(row);
                }

            }
        }


        //------------------------------FILE SAVER METHODS----------------------------------------//

        public static void  saveAllFiles()
        {
            saveNodeChildrenDictionary();
            saveQAFileNameScoresFile();
            saveSubjectNodeList();
            saveTreeViewDictionary();
            saveQACumulativeResultsFile();

        }// End saveAllFiles
        /// <summary>
        /// This method is called when the user exit the QATreeForm
        /// </summary>
        private static void saveNodeChildrenDictionary()
        {
            string output = "";
            foreach (KeyValuePair<string, int> kvp in nodeChildrenDictionary)
            {

                string key = kvp.Key;
                int value = kvp.Value;
                string valueString = value.ToString();
                output = output + key + "^" + valueString + '\n';
            }
            File.WriteAllText(nodeChildDictionaryPath, output);
        }// End saveNodeChildrenDictionary


        private static void saveQAFileNameScoresFile()
        {
            // If file exists delete it
            if (File.Exists(qaNameScoreFilePath))
            {
                File.Delete(qaNameScoreFilePath);
            }
            if (QANameScoreDictionary.Count != 0)
            {
                string output = "";
                foreach (KeyValuePair<int, string> kvp in QANameScoreDictionary)
                {
                    int key = kvp.Key;
                    string keyString = key.ToString();
                    string value = kvp.Value;
                    output = output + keyString + "~" + value + '\n';
                }
                File.WriteAllText(qaNameScoreFilePath, output);

                return;
            }
        }// End saveQAFileNameScoresFile(


        private static void saveSubjectNodeList()
        {
            if (File.Exists(subjectNodesListPath))
            {
                File.Delete(subjectNodesListPath);
            }
            File.WriteAllLines(subjectNodesListPath,SubjectNodesList);
            
        }

        private static void saveTreeViewDictionary()
        {
            int count = TreeViewDictionary.Count;
            string[] treeViewDictionaryArray = new string[count];
            int counter = 0;
            string output = "";
            foreach(KeyValuePair<string, string> kvp in TreeViewDictionary)
            {
                string key = kvp.Key;
                string value = kvp.Value;
                output = key + '^' + value;
                treeViewDictionaryArray[counter] = output;
                counter++;
            }

            if (File.Exists(treeViewDictionaryPath))
            {
                File.Delete(treeViewDictionaryPath);
            }
            File.WriteAllLines(treeViewDictionaryPath, treeViewDictionaryArray);

        }// End saveTreeViewDictionary


        private static void saveQACumulativeResultsFile()
        {
            if (File.Exists(qaCumulativeResultsPath))
            {
                File.Delete(qaCumulativeResultsPath);
            }
            StringBuilder sb = new StringBuilder();

            foreach (DataRow row in qaCumulativeResultsTable.Rows)
            {
                string[] fields = row.ItemArray.Select(field => field.ToString()).
                                            ToArray();
                sb.AppendLine(string.Join("^", fields));
            }

            File.WriteAllText(qaCumulativeResultsPath, sb.ToString());
        }

        //------------------------------OTHER METHODS---------------------------------------------//
        public static void updateQANameScoreDictionary(int ID, string nodeName, string nodeText, string parentString)
        {
            string value = nodeText + "^" + parentString + "^" + nodeName + "^No Test Yet";

            QANameScoreDictionary.Add(ID, value);
            string output = ID.ToString() + '~' + value + '\n';

        }// End updateQANameScoreDictionary


        public static void addNodeToTreeViewDictionary(string nodeName, string nodeText)
        {
            TreeViewDictionary.Add(nodeName, nodeText);
        }

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
            }
            else
            {
                nodeChildrenDictionary.Add(parentNodeName, 1);
            }
        }// End updateNodeChildrenDictionary

        public static void updateSubjectNodesList(string subjectNodeName, string nodeTextValue)
        {
            SubjectNodesList.Add(subjectNodeName + "^" + nodeTextValue);
        }
    }// End AccessData class

}// End QADataModelLib
