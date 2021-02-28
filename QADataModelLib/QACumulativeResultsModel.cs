//--------------------GLOBAL vARIABLES--------------------//
//      DataTable table = new DataTable();
//      string filePath = @"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\QACumulativeResults.txt";
//      Dictionary<string, string> cumulativeResultsDictionary 
//-------IMPORT EXPORT QACUMULATIVERESULTS FILE-----------//
//      importQACumulativeResultsFile(
//      createCumulativeResultsDictionary(
//      CreateDataTableFromDictionary(
//      exportQACumulativeResutsFile(
//---------------------OTHER METHODS---------------------//
//      addNewQATestFileRow(
//      


using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;

namespace QADataModelLib
{
    /// <summary>
    /// This public staticclass handles input, output and altering the QACuulativeResultsFile
    /// </summary>
    public static class QACumulativeResultsModel
    {
        //--------------------GLOBAL vARIABLES--------------------//

        /// <summary>
        /// The DataTable table is the vehicle for passing data to and from the QACumulativeResultsForm
        /// </summary>
        static DataTable table = new DataTable();

        private static void createDataTable()
        {
            table.Columns.Add("File Name", typeof(string));
            table.Columns.Add("File Text", typeof(string));
            table.Columns.Add("Date Taken", typeof(string));
            table.Columns.Add("% Correct", typeof(string));
            table.Columns.Add("Incorrect Answers", typeof(string));

           // dataGridView.DataSource = table;
        }


        /// <summary>
        /// filePath is the path to the storage file for cumulative test results
        /// </summary>
        static string filePath = @"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\QACumulativeResults.txt";

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

        //-------IMPORT EXPORT QACUMULATIVERESULTS FILE-----------//

        /// <summary>
        /// This method is called by the  QADashboard_Load( procedure whenever the project is opened
        /// </summary>
        public static void importQACumulativeResultsFile()
        {
            if (File.Exists(filePath))
            {
                // create an array of strings to hold all the lines in the file
                string[] lines = File.ReadAllLines(filePath);
                createCumulativeResultsDictionary(lines);
                CreateDataTableFromDictionary(cumulativeResultsDictionary);

            }
            //// create an array of strings to hold all the lines in the file
            //string[] lines = File.ReadAllLines(filePath);
            //createCumulativeResultsDictionary(lines);
            //CreateDataTableFromDictionary(cumulativeResultsDictionary);
            return;
        }// End  importQACumulativeResultsFile(

        /// <summary>
        /// This method is callde by importQACumulativeResultsFile( to load the QACumulativeResults file
        /// into the cumulativeResultsDictionary
        /// </summary>
        /// <param name="lines"></param>
        private static void createCumulativeResultsDictionary(string[] lines)
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
                    string fileText = values[1];
                    string data = values[2];
                    if (!cumulativeResultsDictionary.ContainsKey(fileName))
                    {
                        cumulativeResultsDictionary.Add(fileName, lines[i]);
                    }
                }// End for (int i = 0; i < lines.Length; i++)
            }
            return;
        }// End createCumulativeResultsDictionary


        private static void CreateDataTableFromDictionary(Dictionary<string, string> cumulativeResultsDictionary)
        {
            createDataTable();
            string[] lines = new string[cumulativeResultsDictionary.Count];
            int counter = 0;
            foreach (KeyValuePair<string, string> kvp in cumulativeResultsDictionary)
            {
                string key = kvp.Key;
                string value = kvp.Value;
                int lastTilda = value.LastIndexOf('~');
                if(lastTilda == value.Length-1)
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
                        string row = "";
                        table.Rows.Add(fileName.Trim(), fileText.Trim(), individualResult[0].Trim(), individualResult[1].Trim(), individualResult[2].Trim());
                    }// End create a row
                }
                else
                {
                    table.Rows.Add(fileName.Trim(), fileText.Trim());
                }
                
                int numberOfRows = table.Rows.Count;

            }// End create all rows
            return;
        }// End loadDictionaryIntoViewGrid(

        /// <summary>
        /// This method is called by the QADashboard's exitApplicationButton_Click( method
        /// when the user is ready to close the application
        /// </summary>
        public static void exportQACumulativeResutsFile()
        {
            // Create a List<string> from the cumulativeResultsdictionary
            List<string> outputList = new List<string>();
            foreach (KeyValuePair<string, string> kvp in cumulativeResultsDictionary)
            {
                string key = kvp.Key;
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

        //CHANGE- 001 add nextQAFileNumberString to the parameters
        public static void addNewQATestFileRow(string nextQAFileNumberString, string nodeName, string nodeText)
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


        // Added 06022020
        public static Boolean cumulativeResultsDictionaryContainsValue(string thisValue)
        {
            bool returnValue = false;
            if (cumulativeResultsDictionary.ContainsValue(thisValue))
            {
                return returnValue;
            }          
            else
            {
                return false;
            }           
                
           
        }

        /// <summary>
        /// This method will be called when the QACumulativeResultsForm opens and used
        /// to populate the QACumulativeResults DataGridView 
        /// </summary>
        /// <returns></returns>
        public static DataTable getQACumulativeResultsDataTable()
        {
            return table;
        }

        /// <summary>
        /// This method is called when the SubjectTreeForm renames a qaNode
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="newNodeText"></param>
        public static void reTextQANode(string nodeName, string newNodeText)
        {
            // Create  a temporary holding dictionary
            Dictionary<string, string> tempCumulativeResultsDictionary = cumulativeResultsDictionary;
            
                string delimitedResults = cumulativeResultsDictionary[nodeName];
                string newDelimitedResults = StringHelperClass.replaceNthItemInDelimitedString(delimitedResults, '^', 1, newNodeText);
                tempCumulativeResultsDictionary[nodeName] = newDelimitedResults;
                cumulativeResultsDictionary = new Dictionary<string, string>();
                cumulativeResultsDictionary = tempCumulativeResultsDictionary;
            
           
        }// End reTextQANode


        public static void updateCumulativeresultsDictionary(string keyStr, string examResultsStr)
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
            currentDictionaryLineStr = currentDictionaryLineStr + examResultsStr;
            cumulativeResultsDictionary[keyStr] = currentDictionaryLineStr;


        }// End updateCumulativeresultsDictionary


    }// End QACumulativeResultsModel
}// End QADataModelLib
