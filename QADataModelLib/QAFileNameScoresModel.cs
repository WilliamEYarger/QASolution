using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace QADataModelLib
{
    public class QAFileNameScoresModel
    {

        private static string qaNameScoreFilePath = @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\QAFileNameScores.txt";

        /// <summary>
        /// This Int32 value is used (after incrementation) to be both the ID and in the Name
        /// of a QAFile entry. Its initial value is set to 0, but as values are downloaded from the
        /// QAFileNameScores.txt each ID is tested and is replaces, if the current ID is larger.
        /// This allows me to delete an old QAFile ID if the file is moved to a new location in
        /// the TreeView
        /// </summary>
        public static Int32 currentMaxQAFileID { get; set; } = 0;


        private static Dictionary<Int32, string> QANameScoreDictionary = new Dictionary<int, string>();

        public static Dictionary<Int32, string> getQANameScoreDictionary()
        {
            return QANameScoreDictionary;
        }// End getQANameScoreDictionary

        /// <summary>
        /// 
        /// </summary>
        public static void loadQANameScoreDictionary()
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


        public static void saveQAFileNameScoresFile()
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

        public static void updateQANameScoreDictionary(int ID, string nodeName, string nodeText, string parentString)
        {
            string value = nodeText + "^" + parentString + "^" + nodeName + "^No Test Yet";

            QANameScoreDictionary.Add(ID, value);
            string output = ID.ToString() + '~' + value + '\n';

        }// End updateQANameScoreDictionary


        public static void reTextNameScores(string nodeName, string oldNodeText, string newNodeText)
        {
            // Create dummy dictionary to hold changed values
            Dictionary<Int32, string> tempQANAmeScoredictionary = new Dictionary<int, string>();
            // Create a string[] valueArray to hold the component of the value
            string[] valueArray = new string[4];
            // Cycle thru QANameScoreDictionary 
            foreach (KeyValuePair<Int32, string> kvp in QANameScoreDictionary)
            {
                int Key = kvp.Key;
                string value = kvp.Value;
                valueArray = value.Split('^');
                string qaFileText = valueArray[0];
                string parentsString = valueArray[1];
                string qaFileName = valueArray[2];
                string testResults = valueArray[3];
                // Determine if the nodeName is at the beginning of the qaFileName
                if (qaFileName.IndexOf(nodeName) == 0)
                {
                    // First convert Parents into a string []
                    string[] parentsArray = parentsString.Split('<');
                    // Next get the number of parents
                    int numParents = parentsArray.Length;
                    // Next convert the nodeName into a string[]
                    string[] nodeItems = nodeName.Split('.');
                    // Next get the number of nodeItems
                    int numNodeItems = nodeItems.Length;
                    // Get the item number of parentsArray to replace from 
                    int itemToReplace = numParents - numNodeItems;
                    // Repalce the itemToReplace - th  item in parents String with newNodeText
                    if(itemToReplace != -1)
                    {
                        parentsString = StringHelperClass.replaceNthItemInDelimitedString(parentsString, '<', itemToReplace, newNodeText);
                        // Reassemble the value with the updated parentsString
                        value = qaFileText + '^' + parentsString + '^' + qaFileName + '^' + testResults;
                    }
                    else
                    {
                        // This is a QA file 
                        value = newNodeText + '^' + parentsString + '^' + qaFileName + '^' + testResults;
                    }
                    // Insert this new value in the QANameScoreDictionary
                    // TODO - Determine if I need the next line
                   // tempQANAmeScoredictionary[Key] = value;
                }// End if (qaFileText.IndexOf(nodeName) == 0
                // Insert this new value in the QANameScoreDictionary
                tempQANAmeScoredictionary[Key] = value;
            }// End foreach (KeyValuePair<Int32, string> kvp 
            // Delete the old version of QANameScoreDictionary
            QANameScoreDictionary = new Dictionary<int, string>();
            QANameScoreDictionary = tempQANAmeScoredictionary;
        }// End reTextNameScores

    }// End QAFileNameScoresModel
}// End QADataModelLib
