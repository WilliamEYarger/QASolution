//-----------------------CONSTANTS----------------------//
//      string qaFilePathFolder
//-----------------------VARIABLES----------------------//
//      string qaFileName
//      Dictionary<int, string> qaDictionary
//      string seriatimQuestionNumberDelStr
//----------------------PROPERTIES AND GETTER/SETTERS---------------------//
//      string qaFilePath = "";
//      string getQAFilePath()
//      setQAFilePath(
//      Dictionary<int, string> QandADictionar
//      string qaFileNameStr
//      string QAFilePath {
//      Dictionary<int, string> QandADictionary{
//      setQAFileNameStr(
//      string getQAFileNameStr()
//--------------------------PUBLIC METHODS-----------------------//
//      void loadQAFileIntoDictionary(string qaFilePath)
//      void saveQAFile(
//      Tuple<int, string> returnDelimitedValue( 
//      string currentQALine(
//      

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace QADataModelLib
{
    public static class AnswerQuestionsDataModel
    {
        //-----------------------CONSTANTS----------------------//
        /// <summary>
        /// qaFilePathFolder is the QAFiles folder in the Learning\_CSharpQAFiles directory
        /// </summary>
        private static string qaFilePathFolder = @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\QAFiles\";
        //-----------------------VARIABLES----------------------//
        private static string qaFileName = "";

        /// <summary>
        /// qaDictionary is a  Dictionary<int, string> whose key is the integer question and
        /// answer number and whose value is the'^' delimited string of Question text; 
        /// Answer text; any image URL, and any mp3 url. For example
        /// 0^Q0.1.1^A0.1.1^^ where the key is 0, the question in Q0.1.1, the answer is A0.1.1
        /// and both the image and mpe urls are blank
        /// </summary>
        private static Dictionary<int, string> qaDictionary = new Dictionary<int, string>();

        private static string seriatimQuestionNumberDelStr = "";
        //----------------------PROPERTIES AND GETTER/SETTERS---------------------//


        /// <summary>
        /// This property is a '^' string containing sequential numberStrings
        /// from "0" to QandADictionary.Count -1
        /// </summary>
        private static string qaList = "";
        public static void setQAList(string listOfQuestionsAndAnswers)
        {
            qaList = listOfQuestionsAndAnswers;
        }
        public static string getQAList()
        {
            return qaList;
        }


        private static string RandomQAList = "";


        public static string returnRandomizedQAList()
        {
            string QAList = qaList;
            //Randomize QAList
            return QAList;
        }

        /// <summary>
        /// qaFilePath is the private internal path to the desired qaFile
        /// </summary>
        private static string qaFilePath = "";

        /// <summary>
        /// Returns qaFilePath which was created fromthe file name if the user selects the file
        /// </summary>
        /// <returns></returns>
        public static string getQAFilePath()
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
        public static void setQAFilePath(string qaFileNameStr)
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
        public static Dictionary<int, string> QandADictionary
        {
            get => QandADictionary = qaDictionary;
            set
            {
                qaDictionary = value;
            }
        }// End property of Dictionary<int, string> QandADictionar

        private static string qaFileNameStr = "";


        /// <summary>
        /// This method receives the name of the file to edit
        /// from QATreeForm's Creat/Edit button and sends it 
        /// to the local setQAFilePath method to convert it into
        /// a complete path to the desired file
        /// </summary>
        /// <param name="fileNameString"></param>
        public static void setQAFileNameStr(string fileNameString)
        {
            qaFileNameStr = fileNameString;
            setQAFilePath(qaFileNameStr);
            //QAFilePath(qaFileNameStr);

        }

        /// <summary>
        /// Returns qaFileNameStr when the QAForm loads
        /// If the QA form was called from the QA tree form it contains only the file name
        /// if the QA form was loaded from the dashboard and the QA forms' open QA file menu
        /// option was selected then the value is balnk
        /// </summary>
        /// <returns></returns>
        public static string getQAFileNameStr()
        {
            return qaFileNameStr;
        }// End getQAFileNameStr

        /// <summary>
        /// This starts as the count of lines in qaDictionary and
        /// in the AnswerQuestionsForm it is decremented each time
        /// a question is answered incorrectly
        /// </summary>
        private static int numCorrectAnswers;

        public static int getNumCorrectAnswers()
        {
            return qaDictionary.Count;
        }//End getNumCorrectAnswers(


        //--------------------------PUBLIC METHODS-----------------------//

        /// <summary>
        /// 1.  Read all the lines in the designated file into qaLineArray
        /// 2.  Convert the qaLineArray into qaDictionary
        /// 3.  Convert the qaDictionary into QandADictionary
        /// 4.  Using the count of the dictionary create a '^' delimited string
        ///     of sequential numStrings
        /// </summary>
        /// <param name="qaFilePath"></param>
        public static void loadQAFileIntoDictionary(string qaFilePath)
        {
            // 20200401 Determine if the file is empty
            if (new FileInfo(qaFilePath).Length > 0)
            {
                //File is not empty
                // Read all lines from the file into qaLineArray
                string[] qaLineArray = File.ReadAllLines(qaFilePath);
                // Parse each line in the qaLineArray creating a new entry in qaDictionary
                foreach (string qaLine in qaLineArray)
                {
                    string qaNumStr = StringHelperClass.returnNthItemInDelimitedString(qaLine, '^', 0);
                    int qaNumInt = Int32.Parse(qaNumStr);
                    string newQALine = qaLine;
                    newQALine = StringHelperClass.removeNthItemFromDelimitedString(qaLine, '^', 0);
                    qaDictionary.Add(qaNumInt, newQALine);
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
            // Create qaList from seriatimQuestionNumberDelStr
            qaList = seriatimQuestionNumberDelStr;

        }// End loadQAFileIntoDictionary


        /// <summary>
        /// Called by the QA form's saveFileAndReturnToDashboardToolStripMenuItem_Click
        /// method
        /// It converts the key and value string(Question,Answer,ImageURL,mp3Url) 
        /// into a '^' string for temp storage in List<string> qaLineList
        /// Once all values in the dictionary have been added the qaLineList
        /// is saved to the file designated by qaFilePath
        /// </summary>
        public static void saveQAFile()
        {
            // TODO - find out and fix whoever is using a newly creates qaFile

            List<string> qaLineList = new List<string>();
            foreach (KeyValuePair<int, string> kvp in qaDictionary)
            {
                int qaNumInt = kvp.Key;
                string qaNumStr = qaNumInt.ToString();
                string qaLine = kvp.Value;
                qaLineList.Add(qaNumStr + '^' + qaLine);
            }
            string qaFilePath = AnswerQuestionsDataModel.getQAFilePath();
            File.AppendAllLines(qaFilePath, qaLineList);
            //File.WriteAllLines(qaFilePath, qaLineList);
        }// EndsaveQAFile


        public static Tuple<int, string> returnDelimitedValue(string delimitedNumbers)
        {
            int pos1stCarot = delimitedNumbers.IndexOf('^');
            if (pos1stCarot == -1)
            {
                return new Tuple<int, string>(Int32.Parse(delimitedNumbers), "");
            }
            
            string[] numberStrValueArray = delimitedNumbers.Split('^');
            string headNumStr = numberStrValueArray[0];
            string newDelimitedNumbers = "";
            for (int i = 1; i < numberStrValueArray.Length-1; i++)
            {
                newDelimitedNumbers = newDelimitedNumbers + numberStrValueArray[i] + "^";
            }
            string lastValue = numberStrValueArray[numberStrValueArray.Length-1];
            newDelimitedNumbers = newDelimitedNumbers + lastValue;
            int headInt = Int32.Parse(headNumStr);
            return new Tuple<int, string>(headInt, newDelimitedNumbers);
        }// End Tuple<int, string> returnDelimitedValue(

        /// <summary>
        /// This method returns the line of the QandADictionary corresponding
        /// to the "currentNumInt"></param>
        /// It is called by the AnswerQuestionsForm's answerQuestions() method
        /// </summary>
        /// <param name="currentNumInt"></param>
        /// <returns></returns>
        public static string currentQALine(int currentNumInt)
        {
            string qaLine = QandADictionary[currentNumInt];
            return qaLine;
        }

        
        //=================================END OF CLASS====================================//


        //==============================END OF MODEL==========================================//
    }// End QAFileDataModel
}// End QADataModelLib
