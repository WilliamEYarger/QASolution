//------------------------------VARIABLES--------------------------------------//
//      Dictionary<string, string> quizCumulativeResultsDictionary
//      Dictionary<string, string> examCumulativeResultsdictionary
//      DataTable examResultsTable 
//      DataTable quizTable 
//------------------------------PUBLIC METHODS--------------------------------//
//      void QAFileSelectedButton_Click(
//      void ViewCumulativeResultsForm_Load(
//      void CreateQuizDGV()
//      void CreateExamDGV()
//      void ImportSortedDictionaryOfNonQAFiles()
//      

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QADataModelLib;

namespace QAProject
{
    public partial class ViewCumulativeResultsForm : Form
    {

        //------------------------------VARIABLES--------------------------------------//
        Dictionary<string, string> quizCumulativeResultsDictionary = new Dictionary<string, string>();
        Dictionary<string,string>  examCumulativeResultsdictionary = new Dictionary<string, string>();
        DataTable examResultsTable = new DataTable();
        DataTable quizTable = new DataTable();
        DataTable examTable = new DataTable();
        //string filePath = @"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\QACumulativeResults.txt";


        //------------------------------PUBLIC METHODS--------------------------------//
        public ViewCumulativeResultsForm()
        {
            InitializeComponent();
        }


        //------------------------------PRIVATE METHODS--------------------------------//

        private void QAFileSelectedButton_Click(object sender, EventArgs e)
        {
            // Get the nodeText and use it to get the nodeName & send it to AnswerQuestinsDataModel
            string nodeText = Convert.ToString(quizDataGridView.CurrentCell.Value);
            string nodeName = AnswerQuestionsDataModel.returnFileNameOfSortedQAFile(nodeText);
            AnswerQuestionsDataModel.SelectedNodeText = nodeText;
            AnswerQuestionsDataModel.SelectedNodeName = nodeName;

            // Get this qaFile's parent's string & Send it to AnswerQuestionsDataModel
            int numParents = StringHelperClass.returnNumOfCharValuesInString(nodeName, '.');
            // Remove the qaFileName at the end
            string parentsNodeNamesStr = StringHelperClass.removeNthItemFromDelimitedString(nodeName, '.', numParents);
            string parentString = TreeViewDictionaryModel.returnParentChain(parentsNodeNamesStr);
            AnswerQuestionsDataModel.SetParentsString(parentString);

            // create a List<string> qaFileNames to hold the list of qaFiles and their file number
            // each entry is a ^ deliited string of qaFile nodeNames and nodeText values
            List<string> listOfQAFiles = AnswerQuestionsDataModel.ReturnListOfSelectedQAFiles(nodeName);

            AnswerQuestionsDataModel.CreateQuestionAndAnswerDictionary(listOfQAFiles);
            AnswerQuestionsDataModel.SetQAFilePath(nodeText);
            this.Hide();
            AnswerQuestionsForm answerQuestionsForm = new AnswerQuestionsForm();
            answerQuestionsForm.ShowDialog();


        }// End 

        /// <summary>
        /// This method is called when the user clicks in the FileName column of the examinationGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NonQAExamFileSelectedButton_Click(object sender, EventArgs e)
        {

            string nodeName = Convert.ToString(examinationGridView.CurrentCell.Value);
            string nodeText = AnswerQuestionsDataModel.ReturnNonQANodeText(nodeName);
            AnswerQuestionsDataModel.SelectedNodeText = nodeText;
            AnswerQuestionsDataModel.SelectedNodeName = nodeName;
            // Get this qaFile's parent's string & Send it to AnswerQuestionsDataModel
            int numParents = StringHelperClass.returnNumOfCharValuesInString(nodeName, '.');
            // Remove the qaFileName at the end
            string parentsNodeNamesStr = StringHelperClass.removeNthItemFromDelimitedString(nodeName, '.', numParents);
            string parentString = TreeViewDictionaryModel.returnParentChain(parentsNodeNamesStr);
            AnswerQuestionsDataModel.SetParentsString(parentString);// create a List<string> qaFileNames to hold the list of qaFiles and their file number
            // In listOfQAFiles each entry is a ^ deliited string of qaFile nodeNames and nodeText values
            List<string> listOfQAFiles = AnswerQuestionsDataModel.ReturnListOfSelectedQAFiles(nodeName);

            AnswerQuestionsDataModel.CreateQuestionAndAnswerDictionary(listOfQAFiles);
            AnswerQuestionsDataModel.SetQAFilePath(nodeText);
            this.Hide();
            AnswerQuestionsForm answerQuestionsForm = new AnswerQuestionsForm();
            answerQuestionsForm.ShowDialog();
        }
        private void ViewCumulativeResultsForm_Load(object sender, EventArgs e)
        {
            CreateQuizDGV();
            CreateExamDGV();
            quizDataGridView.ClearSelection();
            examinationGridView.ClearSelection();
        }// End ViewCumulativeResultsForm_Load

        private void CreateQuizDGV()
        {

            // Enable the wrap function to allow multiple lines of data in a given cell
            this.quizDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.quizDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //quizTable.Columns.Add("ID", typeof(string));
            quizTable.Columns.Add("File Name", typeof(string));
            quizTable.Columns.Add("Date of Test", typeof(string));
            quizTable.Columns.Add("% Correct", typeof(string));
            quizTable.Columns.Add("Missed Questions", typeof(string));

            // Get cumulative results dictionary 
            Dictionary<string, string> qaCummulativeResultsDictionary = QACumulativeResultsModel.getQACumulativeResultsDictionary();

            string[] lines = new string[qaCummulativeResultsDictionary.Count];
            int counter = 0;
            foreach (KeyValuePair<string, string> kvp in qaCummulativeResultsDictionary)
            {
                string key = kvp.Key;
                string value = kvp.Value;
                lines[counter] = value;
                counter++;
            }
            string[] values;
            // Process each value in lines[] from qaCumulateveResults dictionary
            for (int i = 0; i < lines.Length; i++)
            {
                //Get the major divisions
                values = lines[i].ToString().Split('^');
                //string[] row = new string[lines.Length];
                string fileName = values[0];
                string fileText = values[1];
                string data = values[2];

                int numberOfResults = data.Count(f => f == '~');
                // split data into its ~ delimited components
                string[] dataComponents = data.Split('~');
                // cycle thru dataComponents
                string dateStr = "";
                string percentStr = "";
                string wrongAnswersStr = "";
                for (int j = 0; j < dataComponents.Length - 1; j++)
                {
                    string[] individualData = dataComponents[j].Split(':');
                    if (j == 0)
                    {
                        dateStr = individualData[0];
                        percentStr = individualData[1];
                        wrongAnswersStr = individualData[2];
                    }
                    else
                    {
                        dateStr = dateStr + "\r\n" + individualData[0];
                        percentStr = percentStr + "\r\n" + individualData[1];
                        wrongAnswersStr = wrongAnswersStr + "\r\n" + individualData[2];
                    }

                }// End cycle thru dataComponents
                quizTable.Rows.Add(fileText.Trim(), dateStr.Trim(), percentStr.Trim(), wrongAnswersStr.Trim());

            }// End Process each value in lines[] from qaCumulateveResults dictionary
            quizDataGridView.DataSource = quizTable;
        }// End CreateQuizDGV()

        private void CreateExamDGV()
        {
            // examinationGridView

            // Enable the wrap function to allow multiple lines of data in a given cell
            examinationGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            examinationGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            examinationGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //examTable.Columns.Add("ID", typeof(string));
            examTable.Columns.Add("File Name", typeof(string));
            examTable.Columns.Add("Subject", typeof(string));
            examTable.Columns.Add("Date of Test", typeof(string));
            examTable.Columns.Add("% Correct", typeof(string));
            examTable.Columns.Add("Missed Questions", typeof(string));
            // get the SortedListOfAllNonQANodesName_Text which contains nodeName^nodeText
            string[] nonQAFileResultsArray = File.ReadAllLines(@"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\SortedListOfAllNonQANodesName_Text.txt");
            // convert this array into a dictionary
            Dictionary<string, string> nonQAFileResultDictionary = new Dictionary<string, string>();
            foreach(string line in nonQAFileResultsArray)
            {
                string[] lineParts = line.Split('^');
                string key = lineParts[0];
                string value = lineParts[1]+'^';
                nonQAFileResultDictionary.Add(key, value);
            }
            // Get QAExaminationResults and add the results to nonQAFileResultsArray
            string[] nonQAExamResults = File.ReadAllLines(@"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\QAExaminationResults.txt");
            foreach(string examResultsLine in nonQAExamResults)
            {
                string[] examResultsLineParts = examResultsLine.Split('^');
                string nodeName = examResultsLineParts[0];
                string examResults = examResultsLineParts[3];
                string neededNonQAFileResultsArrayLine = nonQAFileResultDictionary[nodeName];
                neededNonQAFileResultsArrayLine = neededNonQAFileResultsArrayLine  + examResults;
                nonQAFileResultDictionary[nodeName] = neededNonQAFileResultsArrayLine;
            }
            // turn nonQAFileResultDictionary back into nonQAFileResultsArray
            // Clear nonQAFileResultsArray
            int lengthOfNonQAFileResultsArray = nonQAFileResultsArray.Length;
            nonQAFileResultsArray = null;
           // Array.Clear(nonQAFileResultsArray, 0, lengthOfNonQAFileResultsArray);
            // Create a List<string> listOfNonQAFileResult to hold the updated results
            List<string> listOfNonQAFileResult = new List<string>();
            foreach (KeyValuePair<string,string> kvp in nonQAFileResultDictionary)
            {
                string key = kvp.Key;
                string value = kvp.Value;
                string newLine = key + '^' + value;
                listOfNonQAFileResult.Add(newLine);
            }
            // Turn this list  back into nonQAFileResultsArray
            nonQAFileResultsArray = listOfNonQAFileResult.ToArray();
            // Process each line of nonQAFileResultsArray and add it to examTable
            foreach (string line in nonQAFileResultsArray)
            {
                // Split the line into its '^' delimited components
                string[] arrayOfParts = line.Split('^');
                string fileName = arrayOfParts[0];
                string subject = arrayOfParts[1];
                string data = arrayOfParts[2];
                int numberOfResults = data.Count(f => f == '~');

                // split data into its ~ delimited components
                string[] dataComponents = data.Split('@');
                // cycle thru dataComponents
                string dateStr = "";
                string percentStr = "";
                string wrongAnswersStr = "";
                for (int j = 0; j < dataComponents.Length - 1; j++)
                {
                    string[] individualData = dataComponents[j].Split('~');
                    if (j == 0)
                    {
                        dateStr = individualData[0];
                        percentStr = individualData[1];
                        wrongAnswersStr = individualData[2];
                    }
                    else
                    {
                        dateStr = dateStr + "\r\n" + individualData[0];
                        percentStr = percentStr + "\r\n" + individualData[1];
                        wrongAnswersStr = wrongAnswersStr + "\r\n" + individualData[2];
                    }
                }// End cycle thru dataComponents
                 // Add this line to the table
                examTable.Rows.Add(fileName.Trim(), subject, dateStr, percentStr, wrongAnswersStr);

            }// End Process each line of nonQAFileResultsArray and add it to examTable
            examinationGridView.DataSource = examTable;
        }// End CreateExamDGV

        private void ImportSortedDictionaryOfNonQAFiles()
        {
            string[] arrayOfNonQASortedFiles = File.ReadAllLines(@"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\NonQAFileNames.txt");

        }// End ImportSortedDictionaryOfNonQAFiles()


        private void CreateCumulativeResultsDictionary(string[] lines)
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
                if (!quizCumulativeResultsDictionary.ContainsKey(fileName))
                {
                    quizCumulativeResultsDictionary.Add(fileName, lines[i]);
                }
            }// End for (int i = 0; i < lines.Length; i++)
            return;
        }// End CreateCumulativeResultsDictionary

        private void LoadDictionaryIntoViewGrid(Dictionary<string, string> cumulativeResultsDictionary)
        {
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
                //string[] row = new string[lines.Length];
                string fileName = values[0];
                string fileText = values[1];
                string data = values[2];
                /*
                 At this point determine how many different results are in the data
                 which is equal to the number of ~
                 */
                int numberOfResults = data.Count(f => f == '~');
                // split data into its ~ delimited components
                string[] dataComponents = data.Split('~');
                // cycle thru dataComponents
                string dateStr = "";
                string percentStr = "";
                string wrongAnswersStr = "";
                for (int j = 0; j < dataComponents.Length - 1; j++)
                {
                    string[] individualData = dataComponents[j].Split(':');
                    if (j == 0)
                    {
                        dateStr = individualData[0];
                        percentStr = individualData[1];
                        wrongAnswersStr = individualData[2];
                    }
                    else
                    {
                        dateStr = dateStr + "\r\n" + individualData[0];
                        percentStr = percentStr + "\r\n" + individualData[1];
                        wrongAnswersStr = wrongAnswersStr + "\r\n" + individualData[2];
                    }
                }// End cycle thru dataComponents




                examResultsTable.Rows.Add(fileName.Trim(), fileText.Trim(), dateStr.Trim(), percentStr.Trim(), wrongAnswersStr.Trim());


                int numberOfRows = examResultsTable.Rows.Count;

            }// End create all rows
            int numRows = examinationGridView.Rows.Count;
            if (numRows < 2)
            {
                examinationGridView.DataSource = examResultsTable;
            }
            return;
        }// End LoadDictionaryIntoGridView

        private void returnToDashboardButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            QADashboard dashboardForm = new QADashboard();
            dashboardForm.ShowDialog();
        }
    }// End class ViewCumulativeResultsForm
}// End QAProject namespace
