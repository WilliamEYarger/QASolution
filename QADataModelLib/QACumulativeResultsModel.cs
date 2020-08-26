//-------------------- GLOBAL VARIABLES --------------------//
//      DataTable table = new DataTable();
//      Dictionary<string, string> cumulativeResultsDictionary
//      Dictionary<string, string> examinationResultsDictionary
//      bool ExaminationResultsdictionaryContaineKey(
//      Dictionary<string, string> ExaminationResultsDictionary
//--------------------------------PRIVATE VARIABLES----------------------------//
//      Dictionary<string, string> sortedDictionaryOfNonQAFiles 
//      string filePath = @"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\QACumulativeResults.txt";
//--------------------------------PRIVATE METHODS------------------------------//
//      void CreateQADataTable()
//      void CreateQACumulativeResultsDictionary(
//      void CreateDataTableFromDictionary(
//-------------------------PUBLIC METHODS------------------------------------------//
//      void ImportQAExaminationResultsFile()
//      void ExportExaminationResultsFile()
//      void ImportQACumulativeResultsFile()
//      void UpdateCumulativeExamResultsDictionary
//      void ExportQACumulativeResutsFile()
//      void AddNewQATestFileRow(
//      void ReTextQANode(
//      void UpdateCumulativeresultsDictionary(
//      void AddNewEntryToExaminationResultsdictionary(
//      void CreateSortedDictionaryOfNonQAFiles(



using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;

namespace QADataModelLib
{
    /// <summary>
    /// This public static class handles input, output and altering the QACuulativeResultsFile
    /// </summary>
    public static class QACumulativeResultsModel
        // TODO - 20200808 The cumulative results on exams are not updating
    {
        //-------------------- GOBAL VARIABLES --------------------//

        /// <summary>
        /// The DataTable table is the vehicle for passing data to and from the QACumulativeResultsForm
        /// </summary>
        static readonly DataTable table = new DataTable();

        /// <summary>
        /// The cumulativeResultsDictionary has the nodeName as its Key and the delimited items of the 
        /// cumulative results for taking a Test on a particular "qa_" question and answer file collection.
        /// THE FORMAT OF EACH STIRNG IS:
        ///     8q^qa_Plato^201910150853:95.0:1,15~201911151453:80:1,3,9,15~20191230 0950:70:1,3,7,9,25,31
        ///     nodeName^nodeText^individual test data [date, % corrct and , questions incorrectly answered] '~' individual test data'~' etc.
        /// Whenever a new qa_TestFile is created a "nodeName^nodeText^" stub will be appended to the dictionary
        /// Each time a test is taken on a qa_TestFile,  its dateTime yyyymmdd hhmm; the % of questions answered
        /// correctln and a comma delimited list of incorrectly answered questions  wil be '~' appended to the line
        /// whose qa_TestFile name(equivalent to the nodeName of its postion in the QASubjectsTree) is both the Key 
        /// and the first element of the value of a line in the dictionary
        /// </summary>
        static Dictionary<string, string> cumulativeResultsDictionary = new Dictionary<string, string>();

        /// <summary>
        /// The ExaminationResultsDictionary holds the cumulative results of taking an examination
        ///     (a collection of questions from more that 1 qaFile)
        /// The key is the nodeName of the node selected in the TreeView
        /// The value is a triple delimited string
        ///     SelectedNodeText^ParentString^Date~%~#sIncorrect@ Date~%~#sIncorrect@ Date~%~#sIncorrect@... Date~%~#sIncorrect@
        ///     Where SelectedNodeText^ParentString serve as a hedder value for all of the cumulative
        ///     results of taking an examination on that node
        ///     and the Date~%~#sIncorrect@ Date~%~#sIncorrect@ Date~%~#sIncorrect@... Date~% portion
        ///     is multiple lines of exam results:
        ///         date, percentCorrect and a list of questions incorrectly answered
        /// </summary>
        private static Dictionary<string, string> examinationResultsDictionary = new Dictionary<string, string>();


        /// <summary>
        /// This Method is called by the QATreeViewForm's TakeQAFileTestButton Click procedure
        /// If the examinationResultsDictionary contains the key then it returns true, else
        /// it returns false
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool ExaminationResultsdictionaryContaineKey(string key)
        {
            if (examinationResultsDictionary.ContainsKey(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }// END ExaminationResultsdictionaryContaineKey

        /// <summary>
        /// This property gets and sets the value of ExaminationResultsDictionary
        /// </summary>
        public static Dictionary<string, string> ExaminationResultsDictionary
        {
            get
            {
                return examinationResultsDictionary;
            }
            set
            {
                examinationResultsDictionary = value;
            }
        }

        public static Dictionary<string,string> SortedDictionaryOfNonQAFiles 
        {
            get
            {
                return sortedDictionaryOfNonQAFiles;
            }
           
        }
        //--------------------------------PRIVATE VARIABLES----------------------------//

        /// <summary>
        /// This dictionary holds the results of taking an examination on a nonQA file (ie composed of
        /// more that 1 qaFile belonging to a particulary parent node)
        /// </summary>
        private static readonly Dictionary<string, string> sortedDictionaryOfNonQAFiles = new Dictionary<string, string>();


        /// <summary>
        /// filePath is the path to the storage file for cumulative test results
        /// </summary>
        private static readonly string filePath = @"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\QACumulativeResults.txt";

        //--------------------------------PRIVATE METHODS------------------------------//
        private static void CreateQADataTable()
        {
            table.Columns.Add("File Name", typeof(string));
            table.Columns.Add("File Text", typeof(string));
            table.Columns.Add("Date Taken", typeof(string));
            table.Columns.Add("% Correct", typeof(string));
            table.Columns.Add("Incorrect Answers", typeof(string));
        }

        /// <summary>
        /// This method is called by importQACumulativeResultsFile( to load the QACumulativeResults file
        /// into the cumulativeResultsDictionary
        /// </summary>
        /// <param name="lines"></param>
        private static void CreateQACumulativeResultsDictionary(string[] lines)
        {
            // If the QACumulative results file exists, load it into the cumulativeResultsDictionary
            if (File.Exists(filePath))
            {
                string[] values;
                for (int i = 0; i < lines.Length; i++)
                {
                    //Get the major divisions
                    values = lines[i].ToString().Split('^');
                    //string[] row = new string[lines.Length];
                    string fileName = values[0];
                    if (!cumulativeResultsDictionary.ContainsKey(fileName))
                    {
                        cumulativeResultsDictionary.Add(fileName, lines[i]);
                    }
                }// End for (int i = 0; i < lines.Length; i++)
            }
            return;
        }// End createCumulativeResultsDictionary

        /// <summary>
        /// Called by ImportQACumulativeResultsFile()
        /// </summary>
        /// <param name="cumulativeResultsDictionary"></param>
        private static void CreateDataTableFromDictionary(Dictionary<string, string> cumulativeResultsDictionary)
        {
            CreateQADataTable();
            string[] lines = new string[cumulativeResultsDictionary.Count];
            int counter = 0;
            foreach (KeyValuePair<string, string> kvp in cumulativeResultsDictionary)
            {
                string key = kvp.Key;
                string value = kvp.Value;
                int lastTilda = value.LastIndexOf('~');
                if (lastTilda == value.Length - 1)
                {
                    value = value.Substring(0, value.Length - 1);
                }
                lines[counter] = value;
                counter++;
            }
            string[] values;
            for (int i = 0; i < lines.Length; i++)
            {
                //Get the major divisions
                values = lines[i].ToString().Split('^');
                string fileName = values[0];
                string fileText = values[1];
                string data = values[2];
                string[] allResults = data.Split('~');
                if (allResults[0] != "")
                {
                    foreach (string result in allResults)
                    {
                        string[] individualResult = result.Split(':');
                        table.Rows.Add(fileName.Trim(), fileText.Trim(), individualResult[0].Trim(), individualResult[1].Trim(), individualResult[2].Trim());
                    }// End create a row
                }
                else
                {
                    table.Rows.Add(fileName.Trim(), fileText.Trim());
                }
            }// End create all rows
            return;
        }// END CreateDataTableFromDictionary 


        //-------------------------PUBLIC METHODS------------------------------------------//

        /// <summary>
        /// This method is called by the QADashboard load procedure
        /// It reads the QAExaminationResults.txt into the
        /// examinationResultsDictionary where the Key is the the nodeName propert
        /// of a non-QA node and the value is a '^' delimited string of
        ///     the nodeText value
        ///     the node's parent string
        ///     a composit '@' delimited string composed of
        ///         The datatime when the examinstion was taken
        ///         The xx.x% score achieved
        ///         and a ',' delimited list of the incorrectly answered questions where
        ///         each entry is composed of the qaNode;s number (ie For the Greece node it
        ///         is 4 and the number of the question in the appropriate qaFile) thus if 
        ///         question 1 in qaFile 4 was answered incorrectly then the entry would be "4-1,"
        ///         
        /// </summary>
        public static void ImportQAExaminationResultsFile()
        {
            string examFilePath = @"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\QAExaminationResults.txt";
            string[] qumulativeExamResultsLines = File.ReadAllLines(examFilePath);
            foreach(string line in qumulativeExamResultsLines)
            {
                string key = StringHelperClass.returnNthItemInDelimitedString(line, '^', 0);
                string value = StringHelperClass.removeNthItemFromDelimitedString(line, '^', 0);
                examinationResultsDictionary.Add(key, value);
            }
        }// END ImportQAExaminationResultsFile



        /// <summary>
        /// This procedure is called when the QADashboard ExitApplicationButton is clicked
        /// 
        /// It converts the ExaminationResultsDictionary to a text file
        /// </summary>
        public static void ExportExaminationResultsFile()
        {
            string qaCumulatingFilePath = @"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\QAExaminationResults.txt";
            string outputStr;
            List<string> examDictionaryLines = new List<string>(); ;
            foreach(KeyValuePair<string,string> kvp in ExaminationResultsDictionary)
            {
                string nodeName = kvp.Key;
                string value = kvp.Value;
                outputStr = nodeName + '^'+ value;
                examDictionaryLines.Add(outputStr);
            }
            string[] cumulativeExamResultsArray = examDictionaryLines.ToArray();
            File.WriteAllLines(qaCumulatingFilePath, cumulativeExamResultsArray);
        }// END ExportExaminationResultsFile


        /// <summary>
        /// This method is called by the  QADashboard_Load( procedure whenever the project is opened
        /// </summary>
        public static void ImportQACumulativeResultsFile()
        {
            if (File.Exists(filePath))
            {
                // create an array of strings to hold all the lines in the file
                string[] lines = File.ReadAllLines(filePath);
                CreateQACumulativeResultsDictionary(lines);
                CreateDataTableFromDictionary(cumulativeResultsDictionary);
            }
            return;
        }// End  importQACumulativeResultsFile(

        
        /// <summary>
        /// This method receives a string of the results of taking and examination 
        /// The format of this string is:
        /// SelectedNode.Name^ SelectedNodeText^ParentString^Date~%~#sIncorrect@  where:
        ///     SelectedNode.Name is the key to the dictionary
        ///     SelectedNodeText^ParentString are the hedder values, for a dictionary display line
        ///     Date~%~#sIncorrect@ are the results data
        /// </summary>
        /// <param name="resultsOFExam"></param>
        public static void UpdateCumulativeExamResultsDictionary(string resultsOFExam)
        {
            // get the component parts of resultsOFExam
            string[] results = resultsOFExam.Split('^');
            string key = results[0];
            // If the CreateDataTableFromDictionary exists get the desired key value pair
            if (examinationResultsDictionary.Count > 0)
            {
                // the dictionary already exists so update it
                //get the correct item from the dictionary
                string desiredDictionaryItem = examinationResultsDictionary[key];
                desiredDictionaryItem += results[3];
                examinationResultsDictionary[results[0]] = desiredDictionaryItem;
            }
            else
            {
                // the dictionary doesn't exist so create it
                key = results[0];
                string nodeText = results[1];
                string parentsStr = results[2];
                string examResults = results[3];
                examinationResultsDictionary.Add(key, nodeText + '^' + parentsStr + '^' + examResults+'@');
            }

        }


        /// <summary>
        /// This method is called by the QADashboard's exitApplicationButton_Click( method
        /// when the user is ready to close the application
        /// </summary>
        public static void ExportQACumulativeResutsFile()
        {
            // Create a List<string> from the cumulativeResultsdictionary
            List<string> outputList = new List<string>();
            foreach (KeyValuePair<string, string> kvp in cumulativeResultsDictionary)
            {
                string value = kvp.Value;
                outputList.Add(value);
            }
            File.WriteAllLines(filePath, outputList);
        }// End xportQACumulativeResutsFile(


        /// <summary>
        /// This public method is called whenever a new 'qa_' test node is added to the SubjectTreeView
        /// in the QATreeForm's addNewQAFileNodeButton_Click( method
        /// 
        /// The nodeName transferred is composed of the Parent's name+ the new unique int
        /// identifying this QA file + a terminal 'q'
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="nodeText"></param>
        /// 
        public static void AddNewQATestFileRow(string nextQAFileNumberString, string nodeText)
        {
            /* newQAFileName will be used as the key to the dictionary it is created from
               the integer representing the next available integer to create a new qaFile
               converted to a string with a 'q' appended
            */
            string newQAFileName = nextQAFileNumberString + 'q';

            string value = newQAFileName + '^' + nodeText + '^';
            if (!cumulativeResultsDictionary.ContainsKey(newQAFileName))
            {
                cumulativeResultsDictionary.Add(newQAFileName, value);
            }

        }// End addNewQATestFileRow(


        /// <summary>
        /// This method is called when the SubjectTreeForm renames a qaNode
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="newNodeText"></param>
        public static void ReTextQANode(string nodeName, string newNodeText)
        {
            // Create  a temporary holding dictionary
            Dictionary<string, string> tempCumulativeResultsDictionary = cumulativeResultsDictionary;
            
                string delimitedResults = cumulativeResultsDictionary[nodeName];
                string newDelimitedResults = StringHelperClass.replaceNthItemInDelimitedString(delimitedResults, '^', 1, newNodeText);
                tempCumulativeResultsDictionary[nodeName] = newDelimitedResults;
                cumulativeResultsDictionary = new Dictionary<string, string>();
                cumulativeResultsDictionary = tempCumulativeResultsDictionary;
        }// End reTextQANode


        public static void UpdateCumulativeresultsDictionary(string keyStr, string examResultsStr)
        {
            /* the Key string is a value something like "5q" and the
             * examResultsStr contains a ':' delimited string like "201910150853:95.0:1,1"
             * where the first value is the datetime the exam was taken
             * the second value is the percent of correct answers,
             * and the third is is list of incorrectly answered questions
             * The examResultsStr will be appended to the existing value of the
             * cumulativeResultsDictionary with a '~' internal delimiter added
             */
            string currentDictionaryLineStr = cumulativeResultsDictionary[keyStr];
            currentDictionaryLineStr += examResultsStr;
            cumulativeResultsDictionary[keyStr] = currentDictionaryLineStr;

        }// End updateCumulativeresultsDictionary

        /// <summary>
        /// This method is called by QATReeForm's when it TakeQATestFileButton is clicked
        /// AND there is no entry in the examinationResultsDictionary with a key = nodeName
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="selectedNodeText"></param>
        /// <param name="parentString"></param>
        public static void AddNewEntryToExaminationResultsdictionary(string nodeName, string selectedNodeText, string parentString)
        {
            string newValue = selectedNodeText+'^'+ parentString+'^';
            examinationResultsDictionary.Add(nodeName, newValue);

        }

        /// <summary>
        /// This procedure is called by QATreeForm.CreateQADictionary()
        /// It receives a List<string> of all nonQAFiles as they appear in the TreeView
        /// Its Purpose is to Create a Dictionary<string,string> sortedDictionaryOfNonQAFiles
        /// where the key is the 
        /// nonQAFile nodeName and he value in the nonQAFile text offset by 2xNode Level spaces
        /// </summary>
        /// <param name="nonQAFileList"></param>
        public static void CreateSortedDictionaryOfNonQAFiles(List<string> nonQAFileList)
        {
            string key;
            string value;
            int nodeLevel;
            string offset;
            // Cycle thru each line in nonQAFileList
            foreach (string line in nonQAFileList)
            {
                offset = "";
                key = StringHelperClass.returnNthItemInDelimitedString(line, '^', 0);
                value = StringHelperClass.returnNthItemInDelimitedString(line, '^', 1);
                // Determins the node level of the item
                nodeLevel = StringHelperClass.returnNumOfCharValuesInString(key, '.');
                // string.Concat(Enumerable.Repeat("ab", 2));
                for(int i=0; i< nodeLevel; i++)
                {
                    offset += "  ";
                }
                value = offset + value+"^";
                sortedDictionaryOfNonQAFiles.Add(key, value);
            }// END Cycle thru each line in nonQAFileList
            foreach(KeyValuePair<string,string> kvp in examinationResultsDictionary)
            {
                // Get the key and the value string from the next entry in the examinationResultsDictionary
                string currentKey = kvp.Key;
                string currentValue = kvp.Value;
                // Get the exam result value from currentValue
                string examinationResults = StringHelperClass.returnNthItemInDelimitedString(currentValue, '^', 2);
                // Get the value string of the sortedDictionaryOfNonQAFiles for the key = currentKey;
                string oldValue = sortedDictionaryOfNonQAFiles[currentKey];

                // add the results from the examinationResultsDictionary to its value
                oldValue += examinationResults;
                // return the ammended value
                sortedDictionaryOfNonQAFiles[currentKey] = oldValue;
            }
            // Create a List of the keys and values in the sortedDictionaryOfNonQAFiles and publish it
            List<string> listOfNonQAFiles = new List<string>();
            foreach(KeyValuePair<string,string> kvp in sortedDictionaryOfNonQAFiles)
            {
                string nonQAKey = kvp.Key;
                string nonQAValue = kvp.Value;
                string output = nonQAKey + '^'+ nonQAValue;
                listOfNonQAFiles.Add(output);
            }
            // 20200809 0742 string nonQAFilePath = @"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\NonQAFileNames.txt";
            string nonQAFilePath = @"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\SortedListOfAllQANodesName_Text.txt";
            File.WriteAllLines(nonQAFilePath, listOfNonQAFiles);

        }// END CreateSortedDictionaryOfNonQAFiles

        public static Dictionary<string,string> getQACumulativeResultsDictionary()
        {
            return cumulativeResultsDictionary;
        }



    }// End QACumulativeResultsModel
}// End QADataModelLib
