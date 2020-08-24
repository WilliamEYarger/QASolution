using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace QADataModelLib
{
    public class TreeViewDictionaryModel
    {


        public static string treeViewDictionaryPath = @"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\TreeViewDictionary.txt";


        private static Dictionary<string, string> TreeViewDictionary = new Dictionary<string, string>();
        private static Dictionary<string, string> HyperlinkDictionary = new Dictionary<string, string>();

        public static string getHyperlink(string nodeName)
        {
            string hyperlink = "";
            loadHyperlinkDictionary();
            try 
            {
                hyperlink = HyperlinkDictionary[nodeName];
            }
            catch (Exception)
            {
                hyperlink = "";
            }
            return hyperlink;
        }// End getHyperlink




        /// <summary>
        /// This method is called by ChangeNodeTextvalue and returns the TreeViewDictionary
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> getTreeViewDictionary()
        {
            return TreeViewDictionary;
        }

        /// <summary>
        /// This procedure Receives an updated version of the TreeViewDictionary 
        /// and exchanges it for the old version of the TreeViewdictionary
        /// </summary>
        /// <param name="newValue"></param>
        public static void updateTreeViewDictionary(Dictionary<string, string> newValue)
        {
            TreeViewDictionary = new Dictionary<string, string>();
            TreeViewDictionary = newValue;
        }

        /// <summary>
        /// This method is called getTreeViewDictionary 
        /// It opens reads the lines in the  TreeViewDictionary.txt into a ArrayList
        /// and extracts the '^' keys and values 
        /// and creates the TreeViewDictionary<string,string> from them
        /// </summary>
        public static void loadTreeViewDictionary()
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
            }// End if(File.Exists
        }// loadTreeViewDictionary

        private static void loadHyperlinkDictionary()
        {
            // Check to see if the HyperlinkDictionary has already been created and if so clear it
            if (HyperlinkDictionary.Count != 0)
            {
                HyperlinkDictionary = new Dictionary<string, string>();
            }
            var hyperlinkDictionaryList = new List<string>();
            string hyperlinkDictionaryPath = @"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\NameHyperlinks.txt";

            if (File.Exists(hyperlinkDictionaryPath))
            {
                //determine if there are data in the file and if so read it into the dictionary
                var fil = new FileInfo(hyperlinkDictionaryPath);
                long length = fil.Length;
                if (length != 0)
                {
                    // Read in the file and parse  it into the dictionary
                    var logFile = File.ReadAllLines(hyperlinkDictionaryPath);
                    hyperlinkDictionaryList = new List<string>(logFile);
                    //logFile.toList<string>;
                    foreach (string line in hyperlinkDictionaryList)
                    {
                        string[] keyAndValue = line.Split('^');
                        HyperlinkDictionary.Add(keyAndValue[0], keyAndValue[1]);
                    }
                }
            }// End if(File.Exists
        }// loadTreeViewDictionary

        public static void saveTreeViewDictionary()
        {
            int count = TreeViewDictionary.Count;
            string[] treeViewDictionaryArray = new string[count];
            int counter = 0;
            string output = "";
            foreach (KeyValuePair<string, string> kvp in TreeViewDictionary)
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


        /// <summary>
        /// This method receives the 'name' of the parent of a new QA node and retruns the chain of parents
        /// </summary>
        /// <param name="name" is the delimited name of the parent of a new QA node></param>
        /// <returns></returns>
        public static string returnParentChain(string name)
        {
            // Get a copy of the TreeView Dictionary
            Dictionary<string, string> copyTreeViewDictionary = TreeViewDictionaryModel.getTreeViewDictionary();
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
        /// If there is no node whose name value to nodeName then adds a new entry to
        ///  treeViewDictionary with key= nodeName and value = nodeText and saves the new Dictionary 
        ///  to TreeViewDictionary.txt
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="nodeText"></param>
        public static Boolean AddNode(string nodeName, string nodeText)
        {
            // Get a copy of the TreeView Dictionary
            //Dictionary<string, string> copyTreeViewDictionary = TreeViewDictionaryModel.getTreeViewDictionary();

            if (!TreeViewDictionary.ContainsKey(nodeName))
            {
                TreeViewDictionaryModel.addNodeToTreeViewDictionary(nodeName, nodeText);
                return true;
            }
            else
            {
                return false;
            }
        }// End AddNode
        public static void addNodeToTreeViewDictionary(string nodeName, string nodeText)
        {
            TreeViewDictionary.Add(nodeName, nodeText);
        }


        public static void reTextNode(string nodeName, string newNodeText)
        {
            TreeViewDictionary[nodeName] = newNodeText;

        }// End reTextNode

       

    }// End TreeViewDictionaryModel
}// End QADataModelLib
