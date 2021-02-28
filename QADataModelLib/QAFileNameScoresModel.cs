




using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace QADataModelLib
{
    public class QAFileNameScoresModel
    {
        /// <summary>
        /// The path to the text file that holds the FileNameScores data
        /// </summary>
        private static string qaNameScoreFilePath = @"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\QAFileNameScores.txt";

        /// <summary>
        /// This Int32 value is used (after incrementation) to be both the ID and in the Name
        /// of a QAFile entry. Its initial value is set to 0, but as values are downloaded from the
        /// QAFileNameScores.txt each ID is tested and is replaces, if the current ID is larger.
        /// This allows me to delete an old QAFile ID if the file is moved to a new location in
        /// the TreeView
        /// </summary>
        public static Int32 currentMaxQAFileID { get; set; } = 0;

        /// <summary>
        /// This is the reference variable that holds the 
        /// </summary>
        private static Dictionary<Int32, string> QANameScoreDictionary = new Dictionary<int, string>();


        /// <summary>
        /// This is called by the QATreeForms' updateQAFileNameScores( method
        /// </summary>
        /// <returns></returns>
        public static Dictionary<Int32, string> getQANameScoreDictionary()
        {
            return QANameScoreDictionary;
        }// End getQANameScoreDictionary

        /// <summary>
        /// This method is called by the QADashboard_Load Method
        ///      Its Purpose is to load the QAFileNameScores.txt file into the
        /// QANameScoreDictionary.
        ///      It also sets currentMaxQAFileID, 
        /// </summary>
        public static void loadQANameScoreDictionary()
        {
            // Create a List of string to hold the lines in the input file
            List<string> inputList = new List<string>();
            // 
            if (File.Exists(qaNameScoreFilePath))
            {

                //determine if there are data in the file and if so read it into the dictionary
                var fil = new FileInfo(qaNameScoreFilePath);
                long length = fil.Length;
                if (length != 0)
                {
                    string line;
                    int counter = 0;
                    // Read the file and enter it line by line into  inputList 
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
                    }// End for loop parsing lines in inputList into QANameScoreDictionar
                }// End if there are data in the file and if so read it into the dictionary
            }// End if qaNameScoreFilePath FileExixts
        }// End setQANameScoreDictionary


        /// <summary>
        /// This method is called by the Dashboard's exitApplicationButton_Click( method
        /// It converts the QANameScoreDictionary into a text file where the Key and
        /// the value are delimitged by a '~' and the value is broken down into
        /// qaFileName, qaParentChain, and the most recent % correct score of the most 
        /// RECENT result on taking a qaFile Exam are delimited by '^'
        /// </summary>
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

        /*
         *  If the parent's name is omitted from the string the node name value will be changed 
         *  to only reflect its unique int ID number
         */

            // CHANGE- 002 change the nodeName to the cumulativeQANodeNumber string

        /// <summary>
        /// Called by the QTreeForm addNewQAFileButton Click
        /// </summary>
        /// <param name="cumulativeQANumberString"></param>
        /// <param name="ID"></param>
        /// <param name="nodeName"></param>
        /// <param name="nodeText"></param>
        /// <param name="parentString"></param>
        public static void updateQANameScoreDictionaryWithNewEntry(string cumulativeQANumberString, int ID, string nodeName, string nodeText, string parentString)
        {
            
            string value = nodeText + "^" + parentString + "^" + cumulativeQANumberString+'q' + "^No Test Yet";
            QANameScoreDictionary.Add(ID, value);
            string output = ID.ToString() + '~' + value + '\n';

        }// End updateQANameScoreDictionaryWithNewEntry

        /// <summary>
        /// This method receives the int key to a line in the QANameScoreDictionary
        /// it calls that line and replaces the 3rd item with the transmitted
        /// "examResults"></param> 
        /// It is called by: AnswerQuestionsForm.UpdateExamData() Method
        /// </summary>
        /// <param name="qaKeyInt"></param>
        /// <param name="examResults"></param>
        public static void updateQAFileNameScoresExamResults(int qaKeyInt, string examResults)
        {
            string desiredQALine = QANameScoreDictionary[qaKeyInt];
            string correctedLine = StringHelperClass.replaceNthItemInDelimitedString(desiredQALine, '^', 3, examResults);
            QANameScoreDictionary[qaKeyInt] = correctedLine;
        }// End updateQAQNameScoreDictionaryWithExamResults


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
                }// End if (qaFileText.IndexOf(nodeName) == 0
                // Insert this new value in the QANameScoreDictionary
                tempQANAmeScoredictionary[Key] = value;
            }// End foreach (KeyValuePair<Int32, string> kvp 
            // Delete the old version of QANameScoreDictionary
            QANameScoreDictionary = new Dictionary<int, string>();
            QANameScoreDictionary = tempQANAmeScoredictionary;
        }// End reTextNameScores

        public static void reCreateQANameScoreDictionary(Dictionary<Int32, string> newQANameScoreDiction)
        {
            QANameScoreDictionary = new Dictionary<int, string>();
            QANameScoreDictionary = newQANameScoreDiction;
        }// End reCreateQANameScoreDictionary(

    }// End QAFileNameScoresModel
}// End QADataModelLib
