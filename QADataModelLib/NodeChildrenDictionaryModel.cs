using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace QADataModelLib
{
    public static class NodeChildrenDictionaryModel
    {
        private static readonly string nodeChildDictionaryPath = @"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\NodeChildDictionary.txt";

        /// <summary>
        /// Holds all Subject and Division nodes and each line holds a string node name
        ///   and a integer  indication how many childres that node has
        /// </summary>
        private static readonly Dictionary<string, int> nodeChildrenDictionary = new Dictionary<string, int>();


        public static void LoadNodeChildrenDictionary()
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
        public static void SaveNodeChildrenDictionary()
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
        /// The nodes contained in nodeChildrendictionary only contain Subject and Division nodes, 
        /// not QA nodes so if thisNodesName appears in nodeChildrendictionary it is a node that 
        /// already has nonQA node children
        /// </summary>
        /// <param name="thisNodesName"></param>
        /// <returns></returns>
        public static Boolean DoesNodeHaveChildren(string thisNodesName)
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

    }// EndNodeChildrenDictionaryModel
}// End QADataModelLib
