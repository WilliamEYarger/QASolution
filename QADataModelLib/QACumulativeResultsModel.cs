//--------------------GLOBAL vARIABLES--------------------//
//      DataTable table = new DataTable();
//      string filePath = @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\QACumulativeResults.txt";
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
        static string filePath = @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\QACumulativeResults.txt";

        /// <summary>
        /// The cumulativeResultsDictionary has the nodeName as its Key and the delimited items of the 
        /// cumulative results for taking a Test on a particular "qa_" question and answer file collection.
        /// THE FORMAT OF EACH STIRNG IS:
        ///     0.0.0.1.0.8q^qa_Plato^20191015 0853:95.0:1,15~20191115 1453:80:1,3,9,15~20191230 0950:70:1,3,7,9,25,31
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
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="nodeText"></param>
        public static void addNewQATestFileRow(string nodeName, string nodeText)
        {
            //string nodeName = nodeNameValue.Text;
            string value = nodeName + '^' + nodeText + '^';
            if (!cumulativeResultsDictionary.ContainsKey(nodeName))
            {
                cumulativeResultsDictionary.Add(nodeName, value);
            }
            //string outputString = cumulativeResultsDictionary[nodeName] + '~' + value;

        }// End addNewQATestFileRow(


        /// <summary>
        /// This method will be called when the QACumulativeResultsForm opens and used
        /// to populate the QACumulativeResults DataGridView 
        /// </summary>
        /// <returns></returns>
        public static DataTable getQACumulativeResultsDataTable()
        {
            return table;
        }


    }// End QACumulativeResultsModel
}// End QADataModelLib
