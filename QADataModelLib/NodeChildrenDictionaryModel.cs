using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace QADataModelLib
{
    public static class NodeChildrenDictionaryModel
    {
        private static string nodeChildDictionaryPath = @"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\NodeChildDictionary.txt";

        /// <summary>
        /// Holds all Subject and Division nodes and each line holds a string node name
        ///   and a integer  indication how many childres that node has
        /// </summary>
        private static Dictionary<string, int> nodeChildrenDictionary = new Dictionary<string, int>();

        public static Dictionary<string, int> getNodeChildrenDictionary()
        {
            return nodeChildrenDictionary;
        }// End getNodeChildrenDictionary(


        public static void loadNodeChildrenDictionary()
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
            File.WriteAllText(nodeChildDictionaryPath, output);
        }// End saveNodeChildrenDictionary

        /// <summary>
        /// This method determines the number of children in the parent node,
        ///     converts that integer to a string and returns it as the  node name
        /// </summary>
        /// <param name="parentNodeName"></param>
        /// <returns></returns>
        public static string returnDivisionNodeName(string parentNodeName)
        {

            // Get a copy of the nodeChildrenDictionary Dictionary
            //Dictionary<string, int> copyNodeChildrenDictionary = AccessData.getNodeChildrenDictionary();
            if (nodeChildrenDictionary.ContainsKey(parentNodeName))
            {
                int numChildren = nodeChildrenDictionary[parentNodeName];
                string divisionNodeName = numChildren.ToString();
                SubjectTreeViewModel.filesChanged = true;
                return divisionNodeName;
            }
            else
            {
                return "0";
            }
        }// End returnDivisionNodeName

        /// <summary>
        /// The nodes contained in nodeChildrendictionary only contain Subject and Division nodes, 
        /// not QA nodes so if thisNodesName appears in nodeChildrendictionary it is a node that 
        /// already has nonQA node children
        /// </summary>
        /// <param name="thisNodesName"></param>
        /// <returns></returns>
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
        }// End doesNodeHaveChildren

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


    }// EndNodeChildrenDictionaryModel
}// End QADataModelLib
