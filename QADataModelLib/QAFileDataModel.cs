//-----------------------CONSTANTS----------------------//
//      string qaFilePathFolder
//-----------------------VARIABLES----------------------//
//      string qaFileName
//      Dictionary<int, string> qaDictionary

//----------------------PROPERTIES AND GETTER/SETTERS---------------------//
//      string qaFilePath = "";
//      string getQAFilePath()
//      setQAFilePath(
//      string QAFilePath {
//      Dictionary<int, string> QandADictionary{
//      setQAFileNameStr(
//      string getQAFileNameStr()
//--------------------------PUBLIC METHODS-----------------------//
//      void loadQAFileIntoDictionary(string qaFilePath)
//      void saveQAFile(
//      
//      
//      

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace QADataModelLib
{
    public static class QAFileDataModel
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


        //----------------------PROPERTIES AND GETTER/SETTERS---------------------//
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
        ///     1.  If the file was chosen by the tree view's Create/Edit button, the
        ///         qaFileNameStr consists of only the file name  and the folder and 
        ///         extension are added
        ///     2.  If the file was chosen by QuestionAndAnswerform's open qa file
        ///         menu option then qaFileNameStr is the complete path to the file        /// 
        /// </summary>
        /// <param name="qaFileNameStr"></param>
        public static void setQAFilePath(string qaFileNameStr)
        {
            if(qaFileNameStr.IndexOf(".txt") == -1){
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


        //--------------------------PUBLIC METHODS-----------------------//

        /// <summary>
        /// 1.  Read all the lines in the designated file into qaLineArray
        /// 2.  Convert the qaLineArray into qaDictionary
        /// 3.  Convert the qaDictionary into QandADictionary
        /// </summary>
        /// <param name="qaFilePath"></param>
        public static void loadQAFileIntoDictionary(string qaFilePath)
        {
            string[] qaLineArray = File.ReadAllLines(qaFilePath);
            foreach(string qaLine in qaLineArray)
            {
                string qaNumStr = StringHelperClass.returnNthItemInDelimitedString(qaLine, '^', 0);
                int qaNumInt = Int32.Parse(qaNumStr);
                string newQALine = qaLine;
                newQALine = StringHelperClass.removeNthItemFromDelimitedString(qaLine, '^', 0);
                qaDictionary.Add(qaNumInt, newQALine);
            }
            QandADictionary = qaDictionary;

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
            List<string> qaLineList = new List<string>();
            foreach(KeyValuePair<int,string> kvp in qaDictionary)
            {
                int qaNumInt = kvp.Key;
                string qaNumStr = qaNumInt.ToString();
                string qaLine = kvp.Value;
                qaLineList.Add(qaNumStr + '^' + qaLine);
            }
            string qaFilePath = QAFileDataModel.getQAFilePath();
            File.WriteAllLines(qaFilePath, qaLineList);
        }// EndsaveQAFile

        //=================================END OF CLASS====================================//


        //==============================END OF MODEL==========================================//
    }// End QAFileDataModel
}// End QADataModelLib
