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

    }// End QAFileNameScoresModel
}// End QADataModelLib
