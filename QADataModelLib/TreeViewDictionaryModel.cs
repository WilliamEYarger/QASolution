//--------------------Variables--------------------
//      string treeViewDictionaryPath = @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\TreeViewDictionary.txt";
//      Dictionary<string, string> TreeViewDictionary = new Dictionary<string, string>();
//      Dictionary<string, string> HyperlinkDictionary = new Dictionary<string, string>();
//--------------------Public Methods--------------------
//      public static string getHyperlink(
//      public static Dictionary<string, string> getTreeViewDictionary(
//      public static void updateTreeViewDictionary(
//      public static void loadTreeViewDictionary(
//--------------------Private Methods--------------------
//      private static void loadHyperlinkDictionary(

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace QADataModelLib
{
    public class TreeViewDictionaryModel
    {

        //--------------------Variables--------------------
        public static string treeViewDictionaryPath = @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\TreeViewDictionary.txt";
        private static Dictionary<string, string> TreeViewDictionary = new Dictionary<string, string>();
        private static Dictionary<string, string> HyperlinkDictionary = new Dictionary<string, string>();

        //--------------------Public Methods--------------------
        /// <summary>
        /// This procedure returns a string containing a hyperlink to a MSWord document containing
        /// information related to the subject of the tree node selected
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public static string getHyperlink(string nodeName)
        {
            loadHyperlinkDictionary();
            string hyperlink;
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
            _ = new List<string>();
            if (File.Exists(treeViewDictionaryPath))
            {
                //determine if there are data in the file and if so read it into the dictionary
                var fil = new FileInfo(treeViewDictionaryPath);
                long length = fil.Length;
                if (length != 0)
                {
                    // Read in the file and parse  it into the dictionary
                    var logFile = File.ReadAllLines(treeViewDictionaryPath);
                    List<string> treeViewdictionaryList = new List<string>(logFile);
                    //logFile.toList<string>;
                    foreach (string line in treeViewdictionaryList)
                    {
                        string[] keyAndValue = line.Split('^');
                        TreeViewDictionary.Add(keyAndValue[0], keyAndValue[1]);
                    }
                }
            }// End if(File.Exists
        }// loadTreeViewDictionary

       

        //--------------------Private Methods--------------------
        private static void loadHyperlinkDictionary()
        {
            // Check to see if the HyperlinkDictionary has already been created and if so clear it
            if (HyperlinkDictionary.Count != 0)
            {
                HyperlinkDictionary = new Dictionary<string, string>();
            }

            string hyperlinkDictionaryPath = @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\NameHyperlinks.txt";

            if (File.Exists(hyperlinkDictionaryPath))
            {
                //determine if there are data in the file and if so read it into the dictionary
                var fil = new FileInfo(hyperlinkDictionaryPath);
                long length = fil.Length;
                if (length != 0)
                {
                    // Read in the file and parse  it into the dictionary
                    var logFile = File.ReadAllLines(hyperlinkDictionaryPath);
                    List<string> hyperlinkDictionaryList = new List<string>(logFile);
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
            foreach (KeyValuePair<string, string> kvp in TreeViewDictionary)
            {
                string key = kvp.Key;
                string value = kvp.Value;
                string output = key + '^' + value;
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
                _ = copyTreeViewDictionary.TryGetValue(name, out string nextParentName);
                parentChain = parentChain + nextParentName + "<";
                name = QADataModelLib.DelimitedStringMethods.removeLastValue(name, '.');
                if (name.IndexOf('.') == -1)
                {
                    parentChain += nextParentName;
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
