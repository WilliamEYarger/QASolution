//-------------------LOCAL VARIABLES--------------------//seriatimToolStripMenuItem_Click(
//      bool testTypeExam = true;//If the test type is a quiz it will be false
//      string delimitedQuestionNumbersStr = "";
//      string currentDatetimeStr = "";
//      string currentQuestion = "";
//      string correctAnswer = "";
//      string currentImageURL = "";
//      string currentMp3URL = "";
//      string currentQuestionNumStr="";
//      string incorrectAnswerNumStr = "";

//      int numCorrectAnswers;
//      double percentCorrect;


//-------------------EVENT METHODS--------------------//
//      void AnswerQuestionsForm_Load(
//--------------------Menu Options--------------------//
//      examToolStripMenuItem_Click(
//      quizToolStripMenuItem1_Click(
//      seriatimToolStripMenuItem_Click(
//      randomToolStripMenuItem_Click(

//--------------------OTHER EVENT METHODS--------------------//
//      seeCorrectAnswerButton_Click(
//      answerCorrectButton_Click(
//      wrongButton_Click(
//--------------------UTILITY METHODS-------------------//
//      InitializeVariables()
//      AnswerQuestions()
//      resetLocalVariables()
//      
//      
//      


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QADataModelLib;

namespace QAProject
{
    public partial class AnswerQuestionsForm : Form
    {
        //-------------------LOCAL VARIABLES--------------------//
        private bool testTypeExam = true;//If the test type is a quiz it will be false

        /// <summary>
        /// The string delimitedQuestionNumbersStr is a series of number strings 
        /// (ie "1^2^...") delimited with "^". The first number string in the sequesce
        /// will be removed from the string and temporarily saved, converted to an 
        /// integer and used to get the correct qaLine string from the 
        /// </summary>
        private static string delimitedQuestionNumbersStr = "";
        private static string currentDatetimeStr = "";
        private static string currentQuestionNumber = "";
        private static string currentQuestion = "";
        private static string correctAnswer = "";
        private static string currentImageURL = "";
        private static string currentMp3URL = "";
        private static string currentQuestionNumStr = "";
        private static string incorrectAnswerNumStr = "";
        private static string keyIntStr = "";
        private static int numCorrectAnswers;
        private static int keyToQAFileNameScoresDictionary;
        private static Boolean examination;
        private static string currentDictionaryKey;
        private static double percentCorrect;
        private static string percentCorrectStr;

        //-------------------EVENT METHODS--------------------//

        public AnswerQuestionsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This form can be called from the QATreeForm's
        /// takeQAFileTestButton_Click( method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnswerQuestionsForm_Load(object sender, EventArgs e)
        {
            // get the delimitedQuestionNumbersStr
            delimitedQuestionNumbersStr = AnswerQuestionsDataModel.ReturnDelimitedQuestionsNumbersStr();
            examination = AnswerQuestionsDataModel.IsExamination();


            InitializeVariables();

        }// End void AnswerQuestionsForm_Load(

        //--------------------Menu Options--------------------//
        
        /// <summary>
        /// The Test Type = Exam menu option clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void examToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clicked if user wishes to take an exam
           
            //Get the current date time string for the cumulative results file
            currentDatetimeStr = DateTime.Now.ToString("yyyyMMddhhmm");
                AnswerQuestions();
        }// End examToolStripMenuItem_Click(

        /// <summary>
        /// The Test type = Quiz menu option clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quizToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            testTypeExam = false;
                AnswerQuestions();
        }// End quizToolStripMenuItem1_Click


        //--------------------OTHER EVENT METHODS--------------------//
        private void seeCorrectAnswerButton_Click(object sender, EventArgs e)
        {
            correctAnswerValue.Text = correctAnswer;
        }


        private void AnswerCorrectButton_Click(object sender, EventArgs e)
        {
            questionNumberValue.Text = "";
            currentQuestionValue.Text = "";
            currentAnswerValue.Text = "";
            correctAnswerValue.Text = "";
            AnswerQuestions();
        }// End AnswerCorrectButton_Click(

        private void WrongButton_Click(object sender, EventArgs e)
        {
            // get the original question number
            string currentQuestionNumber = questionNumberValue.Text;
            string originalQuestionNumber = StringHelperClass.returnNthItemInDelimitedString(currentQuestionNumber, '-', 1);
            if (!testTypeExam)
            {
                // This is a review 
                // Determine if this review is on a single qaFile (=!examination) or not
                if (!examination)
                {
                    // since this is a quiz on a single qaFile place the originalQuestionNumber at the end of thedelimitedQuestionNumbersStr
                    delimitedQuestionNumbersStr = delimitedQuestionNumbersStr + "^" + originalQuestionNumber;
                }
                else
                {
                    // since this is a quiz on more than 1 qaFile place the currentDictionaryKey at the end of delimitedQuestionNumbersStr
                    delimitedQuestionNumbersStr = delimitedQuestionNumbersStr + "^" + currentDictionaryKey;
                }
                questionNumberValue.Text = "";
                currentQuestionValue.Text = "";
                currentAnswerValue.Text = "";
                correctAnswerValue.Text = "";
                AnswerQuestions();
            }
            else
            {
                //This is an exam so create the incorrectAnswerNumStr 
                // if this exam is on a single qaFile (=!examination) place the originalQuestionNumber at the end of the 
                //     incorrectAnswerNumStr
                if (!examination)
                {
                    incorrectAnswerNumStr = incorrectAnswerNumStr + originalQuestionNumber + ",";
                }
                else
                {
                    incorrectAnswerNumStr = incorrectAnswerNumStr + questionNumberValue.Text + ",";
                }

                numCorrectAnswers--;
                questionNumberValue.Text = "";
                currentQuestionValue.Text = "";
                currentAnswerValue.Text = "";
                correctAnswerValue.Text = "";
                AnswerQuestions();
            }
        }// End wrongButton_Click(

        private void SaveAndReturnToDashboardMenuItem_Click(object sender, EventArgs e)
        {           
                this.Hide();
                QADashboard dashboardForm = new QADashboard();
                dashboardForm.ShowDialog();

        }//End saveAndReturnToDashboardMenuItem_Click

        //--------------------UTILITY METHODS-------------------//

        /// <summary>
        /// The purpose of this method is to initialize all working variables
        /// when the form loads, or if it is reused without closing.
        /// </summary>
        private void InitializeVariables()
        {
            //Get the current date time string for the cumulative results file
            currentDatetimeStr = DateTime.Now.ToString("yyyyMMddhhmm");
            // Set/Reset incorrectAnswerNumStr
            incorrectAnswerNumStr = "";
            // Get the initial count of correct answers
            numCorrectAnswers = AnswerQuestionsDataModel.GetNumOfQuestions();
        }// End initializeVariables
        private void AnswerQuestions()
        {
            /* the delimitedQuestionNumbersStr string is a ^ delimited string of string 
               integer keys to the qa dictionary */
            if (delimitedQuestionNumbersStr.Length == 0)
            {
                if (testTypeExam)
                {
                    UpdateExamData();
                    MessageBox.Show("Your score on this test was " + percentCorrectStr);

                }
                // If this is a test or an examinstion publish the results to the screen
                // else 

                ResetLocalVariables();

                // This is the last question 
                instructionsLabel.Text = "This is the last question Save file and return to Dashboard or Repeat the Exercise!";
                             
                return;
            }
            // Set the currentDictionaryKey to  the leading integer string from the delimitedQuestionNumbersStr
            currentDictionaryKey = StringHelperClass.returnNthItemInDelimitedString(delimitedQuestionNumbersStr, '^', 0);
            // Remove this item from the delimitedQuestionNumbersStr
            delimitedQuestionNumbersStr = StringHelperClass.removeNthItemFromDelimitedString(delimitedQuestionNumbersStr, '^', 0);
            // Convert this to an integer key to the answerQuestionsDictionary dictionary
            int keyToQADict = Int32.Parse(currentDictionaryKey);
            // Get the appropriate string from the answerQuestionsDictionary
            string currentDelQALine = AnswerQuestionsDataModel.ReturnDesiredLineFromQADictionary(keyToQADict);
            // Parse this stirng
            string[] currentDelQALineComponents = currentDelQALine.Split('^');
            // assign values to the correct strings
            currentQuestionNumber = currentDelQALineComponents[0];
            // Convert ~ to \n\r
            currentQuestion = currentDelQALineComponents[1];
            currentQuestion = currentQuestion.Replace("~", "\r\n");
            correctAnswer = currentDelQALineComponents[2];
            correctAnswer = correctAnswer.Replace("~", "\r\n");
            currentImageURL = currentDelQALineComponents[3];
            currentMp3URL = currentDelQALineComponents[4];
            // Make provision here for a question value entry
            int arraySize = currentDelQALineComponents.Length;
            if (arraySize == 6)
            {
                // insert code here to deal with question level
            }
            //questionNumberValue textbox
            questionNumberValue.Text = currentQuestionNumber;
            currentQuestionValue.Text = currentQuestion;
            currentQuestionValue.Focus();

        }// End AnswerQuestions()

        /// <summary>
        /// The purpose of this method is to save the results of an exam to
        /// the FileNameScores file and the culutative results file
        /// It is called by:
        ///     1. 
        /// </summary>
        private void UpdateExamData()
        {
            double originalQuestionsNumInt = AnswerQuestionsDataModel.GetNumOfQuestions();
            string currentCorrectNumAnswersStr = numCorrectAnswers.ToString();
            string orriginalNumOfQuestions = originalQuestionsNumInt.ToString();
            string outputNumCorrectStr = $"{currentCorrectNumAnswersStr} out of {orriginalNumOfQuestions} were Correct!";
            percentCorrect = (numCorrectAnswers / originalQuestionsNumInt) * 100;
            percentCorrectStr = String.Format("{0:00.0}", percentCorrect);
            // If this is not an examination update the QAFileNameScores file
            if (!examination)
            {
                // This is a test on a single qaFile
                // The key to the qaFileNameSocresDictionary isthe qa #
                string selectedNodeName = AnswerQuestionsDataModel.SelectedNodeName;
                // get the position of the last '.'
                int posLastDot = selectedNodeName.LastIndexOf('.');
                // get the node name at the end of the qaFileName
                string nodeNameStr = selectedNodeName.Substring(posLastDot + 1);
                // eliminate the terminal 'q'
                nodeNameStr = nodeNameStr.Substring(0, nodeNameStr.Length - 1);
                //convert this to an int
                keyToQAFileNameScoresDictionary = Int32.Parse(nodeNameStr);
                keyIntStr = nodeNameStr;

                QAFileNameScoresModel.updateQAFileNameScoresExamResults(keyToQAFileNameScoresDictionary, outputNumCorrectStr);
                // Create cumulativeResultsOutputStr
                string cumulativeResultsOutputStr = currentDatetimeStr + ":" + percentCorrectStr + ":" + incorrectAnswerNumStr + "~";
                QACumulativeResultsModel.UpdateCumulativeresultsDictionary(keyIntStr + "q", cumulativeResultsOutputStr);
            }
            else
            {
                // This is an examination on multiple qaFiles belonging to a common ancestor
                /*
                 a string of the results of taking and examination 
                    The format of this string is:
                    SelectedNode.Name^ SelectedNodeText^ParentString^Date~%~#sIncorrect@  where:
                        SelectedNode.Name is the key to the dictionary
                        SelectedNodeText^ParentString are the hedder values, for a dictionary display line
                         Date~%~#sIncorrect@ are the results data
                 */
                //Get Selected node name
                string selectedNodeName = AnswerQuestionsDataModel.SelectedNodeName;
                // Get Selected node text
                string selectedNodeText = AnswerQuestionsDataModel.SelectedNodeText;
                // Get parents
                string parentsString = AnswerQuestionsDataModel.ReturnParentsString();
                // send results to UpdateCumulativeExamResultsDictionary(string resultsOFExam
                string dataStr = selectedNodeName + '^' + selectedNodeText + '^' + parentsString + '^' +
                    currentDatetimeStr + "~" + percentCorrectStr + "~" + incorrectAnswerNumStr + "@";
                QACumulativeResultsModel.UpdateCumulativeExamResultsDictionary(dataStr);
            }
        }// End updateExamData

    private void ResetLocalVariables()
        {
            testTypeExam = true;
            delimitedQuestionNumbersStr = "";
            currentQuestion = "";
            correctAnswer = "";
            currentImageURL = "";
            currentMp3URL = "";
            currentQuestionNumStr = "";
            incorrectAnswerNumStr = "";
        }// End resetLocalVariable


    }// End  class AnswerQuestionsForm
}// End QAProject
