//-----------------------CONSTANTS----------------------//
//      string qaFilePathFolder
//-----------------------VARIABLES----------------------//
//      Dictionary<int, string> qaDictionary
//      string seriatimQuestionNumberDelStr
//----------------------PROPERTIES AND GETTER/SETTERS---------------------//
//      string qaFilePath = "";
//      string getQAFilePath()
//      setQAFilePath(
//      Dictionary<int, string> QandADictionar
//      Dictionary<int, string> answerQuestionsDictionary
//      string qaFileNameStr
//      string QAFilePath {
//      Dictionary<int, string> QandADictionary{
//      setQAFileNameStr(
//      string getQAFileNameStr()
//      List<string> orderedListOfQAFiles
//      int getNumCorrectAnswers(
//      string delimitedQuestionNumbersStr
//      string ReturnDelimitedQuestionsNumbersStr(
//      Boolean examination
//      Boolean IsExamination(
//      string parentsString
//      void SetParentsString(
//      string ReturnParentsString(
//      public string SelectedNodeName { get; set; }
//      public string SelectedNodeText { get; set; }

//--------------------------PUBLIC METHODS-----------------------//
//      void loadQAFileIntoDictionary(string qaFilePath)
//      void saveQAFile(
//      string ReturnDesiredLineFromQADictionary(
//      void SetListOfOrderedQAFiles(
//      List<string> ReturnListOfSelectedQAFiles(\
//      void CreateQuestionAndAnswerDictionary(

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace QADataModelLib
{
    public static class AnswerQuestionsDataModel
    {
        //-----------------------CONSTANTS----------------------//
        /// <summary>
        /// qaFilePathFolder is the QAFiles folder in the Learning\_CSharpQAFiles directory
        /// </summary>
        private static readonly string qaFilePathFolder = @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\QAFiles\";
        //-----------------------VARIABLES----------------------//

        /// <summary>
        /// qaDictionary is a  Dictionary<string, string> whose key is the integerStr question and
        /// answer number and whose value is the'^' delimited string of Question text; 
        /// Answer text; any image URL, and any mp3 url. For example
        /// 0^Q0.1.1^A0.1.1^^ where the key is 0, the question in Q0.1.1, the answer is A0.1.1
        /// and both the image and mpe urls are blank
        /// </summary>
        
        private static Dictionary<string, string> qaDictionary = new Dictionary<string, string>();

        private static string seriatimQuestionNumberDelStr = "";
        //----------------------PROPERTIES AND GETTER/SETTERS---------------------//

        /// <summary>
        /// qaFilePath is the private internal path to the desired qaFile
        /// </summary>
        private static string qaFilePath = "";

        /// <summary>
        /// Returns qaFilePath which was created fromthe file name if the user selects the file
        /// </summary>
        /// <returns></returns>
        public static string GetQAFilePath()
        {
            return qaFilePath;
        }

        /// <summary>
        /// This method sets the path to the desired qa file. 
        ///     1.  If the file was chosen by the tree view's takeQAFileTestButton_Click, the
        ///         qaFileNameStr consists of only the file name  and the folder and 
        ///         extension are added
        ///     2.  If the file was chosen by QuestionAndAnswerform's open qa file
        ///         menu option then qaFileNameStr is the complete path to the file        /// 
        /// </summary>
        /// <param name="qaFileNameStr"></param>
        public static void SetQAFilePath(string qaFileNameStr)
        {
            if (qaFileNameStr.IndexOf(".txt") == -1) {
                qaFilePath = qaFilePathFolder + qaFileNameStr + ".txt";
            }
            else
            {
                qaFilePath = qaFileNameStr;
            }
        }// End setQAFilePath

        /// <summary>
        /// This Property, QandADictionary, gets and sets qaDictionary
        /// The Getter method returns the existing qaDictionary
        /// The Setter method creats a new qaDictionary from the
        /// transmitted value
        /// </summary>
        public static Dictionary<string, string> QandADictionary
        {
            get => QandADictionary = qaDictionary;
            set
            {
                qaDictionary = value;
            }
        }// End property of Dictionary<int, string> QandADictionar

        private static readonly Dictionary<int, string> answerQuestionsDictionary = new Dictionary<int, string>();
        private static string qaFileNameStr = "";


        /// <summary>
        /// This method receives the name of the file to edit
        /// from QATreeForm's Creat/Edit button and sends it 
        /// to the local setQAFilePath method to convert it into
        /// a complete path to the desired file
        /// </summary>
        /// <param name="fileNameString"></param>
        public static void SetQAFileNameStr(string fileNameString)
        {
            qaFileNameStr = fileNameString;
            SetQAFilePath(qaFileNameStr);
            //QAFilePath(qaFileNameStr);

        }

        /// <summary>
        /// Returns qaFileNameStr when the QAForm loads
        /// If the QA form was called from the QA tree form it contains only the file name
        /// if the QA form was loaded from the dashboard and the QA forms' open QA file menu
        /// option was selected then the value is balnk
        /// </summary>
        /// <returns></returns>
        public static string GetQAFileNameStr()
        {
            return qaFileNameStr;
        }// End getQAFileNameStr

        /// <summary>
        /// This is a list of all qa files ordered by their appearance in the subjectTreeView
        /// </summary>
        private static List<string> orderedListOfQAFiles;

        public static List<string> GetOrderedListOfQAFiles()
        {
            return orderedListOfQAFiles;
        }

        public static int GetNumOfQuestions()
        {
            return answerQuestionsDictionary.Count;
        }//End getNumCorrectAnswers(

        private static string delimitedQuestionNumbersStr = "";

        public static string ReturnDelimitedQuestionsNumbersStr()
        {
            return delimitedQuestionNumbersStr;
        }

        /* the the number of qaFiles submitted for testing is >1 then 
         * examinstion is true and any testing report will be reported
         * to only the 
         * C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\CumulativeExamResults.txt
         * file
         */
        private static Boolean examination;
        public static Boolean IsExamination()
        {
            if (examination)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string parentsString;

        public static void SetParentsString(string value)
        {
            parentsString = value;
        }

        public static string ReturnParentsString()
        {
            return parentsString;
        }

        private static string selectedNodeName;
        public static string SelectedNodeName
        {
            get { return selectedNodeName; }
            set { selectedNodeName = value; }
        }

        private static string selectedNodeText;
        public static string SelectedNodeText 
        {
            get { return selectedNodeText; }
            set { selectedNodeText = value; }
        }
        //--------------------------PUBLIC METHODS-----------------------//

        /// <summary>
        /// 1.  Read all the lines in the designated file into qaLineArray
        /// 2.  Convert the qaLineArray into qaDictionary
        /// 3.  Convert the qaDictionary into QandADictionary
        /// 4.  Using the count of the dictionary create a '^' delimited string
        ///     of sequential numStrings
        /// </summary>
        /// <param name="qaFilePath"></param>
        public static void LoadQAFileIntoDictionary(string qaFilePath)
        {
            //  Determine if the file is empty
            if (new FileInfo(qaFilePath).Length > 0)
            {
                //File is not empty
                // Read all lines from the file into qaLineArray
                string[] qaLineArray = File.ReadAllLines(qaFilePath);
                // Parse each line in the qaLineArray creating a new entry in qaDictionary
                foreach (string qaLine in qaLineArray)
                {
                    // Get the question number for this qaFile which is in the 0th entry of the ^ delimited qaLine                     
                    string qaNumStr = StringHelperClass.returnNthItemInDelimitedString(qaLine, '^', 0);

                    string newQALine;
                    // add the revised qaLine to the dictionary using the question number int as the key
                    newQALine = StringHelperClass.removeNthItemFromDelimitedString(qaLine, '^', 0);
                    // add the 
                    qaDictionary.Add(qaNumStr, newQALine);
                }
                // Set QandADictionary to qaDictionary
                QandADictionary = qaDictionary;
                // Create seriatimQuestionNumberDelStr, a delimited string of seriatim question numbers, seriatimQuestionNumberDelStr
                seriatimQuestionNumberDelStr = "";
                for (int i = 0; i < QandADictionary.Count; i++)
                {
                    string q = i.ToString();
                    seriatimQuestionNumberDelStr = seriatimQuestionNumberDelStr + q + '^';
                }
                // Remove last '^'
                seriatimQuestionNumberDelStr = seriatimQuestionNumberDelStr.Substring(0, seriatimQuestionNumberDelStr.Length - 1);
              
            }
            else
            {
                //File is Empty
                // Create an empty QandADictionary
                QandADictionary = qaDictionary;
                // Create seriatimQuestionNumberDelStr
                seriatimQuestionNumberDelStr = "";
            }

        }// End loadQAFileIntoDictionary


        /// <summary>
        /// Called by the QA form's saveFileAndReturnToDashboardToolStripMenuItem_Click
        /// method
        /// It converts the key and value string(Question,Answer,ImageURL,mp3Url) 
        /// into a '^' string for temp storage in List<string> qaLineList
        /// Once all values in the dictionary have been added the qaLineList
        /// is saved to the file designated by qaFilePath
        /// </summary>
        public static void SaveQAFile()
        {
            List<string> qaLineList = new List<string>();
            foreach (KeyValuePair<string, string> kvp in qaDictionary)
            {
                string qaNumStr = kvp.Key;
                string qaLine = kvp.Value;
                qaLineList.Add(qaNumStr + '^' + qaLine);
            }
            string qaFilePath = AnswerQuestionsDataModel.GetQAFilePath();
            File.WriteAllLines(qaFilePath, qaLineList);
        }// EndsaveQAFile


        /// <summary>
        /// This procedure is called by the QnasweQuestionsForm.answerQuestions() Method
        /// it receives the int key to the desired dictionary line and returns that line
        /// </summary>
        /// <param name="keyToQADict"></param>
        /// <returns></returns>
        public static string ReturnDesiredLineFromQADictionary(int keyToQADict)
        {
            string desiredLine;
            desiredLine = answerQuestionsDictionary[keyToQADict];
            return desiredLine;
        }

       

        /// <summary>
        /// orderedListOfQAFiles is a '^' list of all qaFile data where the
        /// 1st entry is the qaFile nodeName and the
        /// 2nd endry is the qaFile nodeText
        /// </summary>
        /// <param name="qaFileList"></param>
        public static void SetListOfOrderedQAFiles(List<string> qaFileList)
        {
            orderedListOfQAFiles = qaFileList;
        }

        /// <summary>
        /// This procedure receives a string with a subjectTreeView node nodeName
        /// it then iterates thru the lines of  of qaFileList name^text values
        /// and if the line begins with the subjectTreeView node nodeName
        /// then it is added to selectedQAFilesList
        /// </summary>
        /// <param name="nodeNameString"></param>
        /// <returns></returns>
        public static List<string> ReturnListOfSelectedQAFiles(string nodeNameString)
        {
            List<string> selectedQAFilesList = new List<string>();
            foreach(string qaFileString in orderedListOfQAFiles)
            {
                if(qaFileString.IndexOf(nodeNameString) == 0)
                {
                    selectedQAFilesList.Add(qaFileString);
                }
            }
            return selectedQAFilesList;
        }// End returnListOfSelectedQAFiles


        /// <summary>
        /// This Method receives a ^ delimited list of qaFile nodeNames and nodeText values
        /// the QATreeForm take QAFile button click method 
        /// It creates the the qaDictionary <int,string> where:
        /// the Key = and integer created from the current number of entries in the dictionary
        /// the Value is a ^ delimited string: 1)	 qaFileNunber + "-" + the question number;
        /// 2)  The question; 3) The answer; 4) Any image URL; 5) Any mpe3 URL; 6) an optional integer 
        /// </summary>
        /// <param name="listOfQAFiles"></param>
        public static void CreateQuestionAndAnswerDictionary(List<string> listOfQAFiles)
        {
            // Determine if the listOfQAFiles has more than one entry and if so set examinations true
            List<string> thisListOfQAFiles = listOfQAFiles;
            if(thisListOfQAFiles.Count > 1)
            {
                examination = true;
            }
            else
            {
                examination = false;
            }

            // Store path to the qaFiles
            string qaFileFolderPath = @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\QAFiles\";
            // Iterate thru listOfQAFiles getting each qaFile and uploading its questions
            foreach(string item in listOfQAFiles)
            {
                // Get the nodeTextValue
                string qaFileName = StringHelperClass.returnNthItemInDelimitedString(item, '^', 1);
                int posLastDash = qaFileName.LastIndexOf('-');
                string qaFileNumber = qaFileName.Substring(posLastDash + 1);
                string qaFilePath = qaFileFolderPath + qaFileName + ".txt";
                // get all of the question/answers from this file
                if (new FileInfo(qaFilePath).Length > 0)
                {
                    //File is not empty
                    // Read all lines from the file into qaLineArray
                    string[] qaLineArray = File.ReadAllLines(qaFilePath);
                    foreach (string localItem in qaLineArray)
                    {
                        // Convert localItem into a string[]
                        string[] localItemArray = localItem.Split('^');
                        // get the question number at position 0
                        string questionNumber = localItemArray[0];
                        // append the qaFile# to the front of the question#
                        questionNumber = qaFileNumber + '-' + questionNumber;
                        // replace the [0] element with this revised string
                        localItemArray[0] = questionNumber;
                        //reconstitute questionAnswerInputLine
                        string questionAnswerInputLine = "";
                        foreach(string part in localItemArray)
                        {
                            questionAnswerInputLine = questionAnswerInputLine + part + '^';
                        }
                        //remove the terminal delimiter
                        questionAnswerInputLine = questionAnswerInputLine.Substring(0, questionAnswerInputLine.Length - 1);
                        // create an integer key to the answerQuestionsDictionary
                        int dictKey = answerQuestionsDictionary.Count;
                        answerQuestionsDictionary.Add(dictKey, questionAnswerInputLine);
                    }
                }// End get all of the question/answers from this file
            }// End Iterate thru listOfQAFiles getting each qaFile and uploading its questions

            // create delimitedQuestionNumbersStr
            for (int i = 0; i < answerQuestionsDictionary.Count; i++)
            {
                string keyStr = i.ToString();
                delimitedQuestionNumbersStr = delimitedQuestionNumbersStr + keyStr + '^';
            }
            delimitedQuestionNumbersStr = delimitedQuestionNumbersStr.Substring(0, delimitedQuestionNumbersStr.Length - 1);
           
        }// End createQuestionAndAnswerDictionary

        //=================================END OF CLASS====================================//


        //==============================END OF MODEL==========================================//
    }// End QAFileDataModel
}// End QADataModelLib
