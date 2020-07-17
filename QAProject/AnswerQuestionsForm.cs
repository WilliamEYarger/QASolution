//-------------------LOCAL VARIABLES--------------------//
//      bool testTypeSet = false;
//      bool questionSequenceSet = false;
//      bool testTypeExam = true;//If the test type is a quiz it will be false
//      bool questionSequenceSeriatem = true;//If is is random it will be false
//      string delimitedQuestionNumbersStr = "";
//      string incorrectQuestionNumbersStr = "";
//      string currentDatetimeStr = "";
//      string currentQuestion = "";
//      string correctAnswer = "";
//      string currentImageURL = "";
//      string currentMp3URL = "";
//      string currentQuestionNumStr="";
//      string incorrectAnswerNumStr = "";

//      int numCorrectAnswers;

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
//      initializeVariables()
//      void answerQuestions(
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
        private bool testTypeSet = false;
        private bool questionSequenceSet = true; // changed in v20200710
        private bool testTypeExam = true;//If the test type is a quiz it will be false
        private bool questionSequenceSeriatem = true;//If is is random it will be false

        /// <summary>
        /// The string delimitedQuestionNumbersStr is a series of number strings 
        /// (ie "1^2^...") delimited with "^". The first number string in the sequesce
        /// will be removed from the string and temporarily saved, converted to an 
        /// integer and used to get the correct qaLine string from the 
        /// </summary>
        private string delimitedQuestionNumbersStr = "";
        private string incorrectQuestionNumbersStr = "";
        private string currentDatetimeStr = "";
        private string currentQuestionNumber = "";
        private string currentQuestion = "";
        private string correctAnswer = "";
        private string currentImageURL = "";
        private string currentMp3URL = "";
        private string currentQuestionNumStr = "";
        private string incorrectAnswerNumStr = "";
        private string keyIntStr = "";
        private int numCorrectAnswers;
        private int keyToQAFileNameScoresDictionary;
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
            // TODO - 202007150657 Update of the load method for the answer question form
            // get the delimitedQuestionNumbersStr
            delimitedQuestionNumbersStr = AnswerQuestionsDataModel.returnDelimitedQuestionsNumbersStr();
            // OLD Code revised 202007150656 created the dictionry and delimited string of keys to the database here
            
            // OLD CODE Commented out
            // get the path to the qaFile
            //string qaFilePath = AnswerQuestionsDataModel.getQAFilePath();
            // Get the int value at the end of the name
            // tempQAFilePathName = qaFilePath.Substring(0, qaFilePath.Length - 4);
            //char[] tempQAFilePathNameArray = tempQAFilePathName.ToCharArray();
            //keyIntStr = "";
            //char lastChar = tempQAFilePathNameArray[tempQAFilePathNameArray.Length-1];
            //while (Char.IsDigit(lastChar))
            //{
            //    keyIntStr = lastChar + keyIntStr;
            //    Array.Resize(ref tempQAFilePathNameArray, tempQAFilePathNameArray.Length - 1);
            //    lastChar = tempQAFilePathNameArray[tempQAFilePathNameArray.Length - 1];
            //}
            // Convert this value to an integer
            //keyToQAFileNameScoresDictionary = Int32.Parse(keyIntStr);
            // create the QandADictionary and the ^ delimited qaList to call the questions
            //AnswerQuestionsDataModel.loadQAFileIntoDictionary(qaFilePath);
            // Call initializeVariables() to initialize local variables
            initializeVariables();

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
            //testTypeExam is already true
            // TODO - 202007150701 Revision of the select exam menu


            //delimitedQuestionNumbersStr = AnswerQuestionsDataModel.getQAList();
            //testTypeSet = true;
            //if (questionSequenceSet && testTypeSet)
            //{
                answerQuestions();
            //}
        }// End examToolStripMenuItem_Click(

        /// <summary>
        /// The Test type = Quiz menu option clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quizToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // TODO - 202007150639 Revision of the Quiz method
            /*
             Inasmuch as the  DelimitedQuestionsNumbersStr has already been defined
             in the AnswerQuestionsDataModel all I need to do here is to set testTypeSet to true,
             download DelimitedQuestionsNumbersStr and the dictionary 
             and to call answerQuestions()
             */             
            testTypeSet = true;
            
            answerQuestions();

            //Old code commented out 202007150644
            //testTypeExam = false;
            //testTypeSet = true;
            //delimitedQuestionNumbersStr = AnswerQuestionsDataModel.getQAList();
            //if (questionSequenceSet && testTypeSet)
            //{
            //    answerQuestions();
            //}
        }// End quizToolStripMenuItem1_Click


        /// <summary>
        /// /The Question sequence Seriatim menu option clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seriatimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // questionSequenceSeriatem is already true
                questionSequenceSet = true;
                delimitedQuestionNumbersStr = AnswerQuestionsDataModel.getQAList();
                if (questionSequenceSet && testTypeSet)
                {
                    answerQuestions();
                }
        }// End seriatimToolStripMenuItem_Click


        /// <summary>
        /// The Question Sequence Random menu option clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            questionSequenceSeriatem = false;
            questionSequenceSet = true;
            if (questionSequenceSet && testTypeSet)
            {
                answerQuestions();
            }
        }// End randomToolStripMenuItem_Click(


        //--------------------OTHER EVENT METHODS--------------------//
        private void seeCorrectAnswerButton_Click(object sender, EventArgs e)
        {
            correctAnswerValue.Text = correctAnswer;
        }


        private void answerCorrectButton_Click(object sender, EventArgs e)
        {
            questionNumberValue.Text = "";
            currentQuestionValue.Text = "";
            currentAnswerValue.Text = "";
            correctAnswerValue.Text = "";
            answerQuestions();
        }// End answerCorrectButton_Click(

        private void wrongButton_Click(object sender, EventArgs e)
        {
            if (!testTypeExam)
            {
                // This is a quiz
                delimitedQuestionNumbersStr = delimitedQuestionNumbersStr + "^" + currentQuestionNumStr;
                questionNumberValue.Text = "";
                currentQuestionValue.Text = "";
                currentAnswerValue.Text = "";
                correctAnswerValue.Text = "";
                answerQuestions();
            }
            else
            {
                //This is an Exam
                incorrectAnswerNumStr = incorrectAnswerNumStr + "," + currentQuestionNumStr;
                numCorrectAnswers--;
                questionNumberValue.Text = "";
                currentQuestionValue.Text = "";
                currentAnswerValue.Text = "";
                correctAnswerValue.Text = "";
                answerQuestions();
            }
        }// End wrongButton_Click(


        



        private void saveAndReturnToDashboardMenuItem_Click(object sender, EventArgs e)
        {
            
            //if (testTypeExam)
            //{
            //    updateExamData();
                
            //    // Update the Cumulative results file

            //    // Return to dashboard
            //    this.Hide();
            //    QADashboard dashboardForm = new QADashboard();
            //    dashboardForm.ShowDialog();
            //}
            //else
            //{
                this.Hide();
                QADashboard dashboardForm = new QADashboard();
                dashboardForm.ShowDialog();
            //}
            

        }//End saveAndReturnToDashboardMenuItem_Click

        //--------------------UTILITY METHODS-------------------//

        /// <summary>
        /// The purpose of this method is to initialize all working variables
        /// when the form loads, or if it is reused without closing.
        /// </summary>
        private void initializeVariables()
        {
            //Get the current date time string for the cumulative results file
            currentDatetimeStr = DateTime.Now.ToString("yyyyMMddhhmm");
            // Set/Reset incorrectAnswerNumStr
            incorrectAnswerNumStr = "";
            // Get the initial count of correct answers
            numCorrectAnswers = AnswerQuestionsDataModel.getNumCorrectAnswers();
        }// End initializeVariables
        
        
        
        
        private void answerQuestions()
        {
            // TODO - 202007150645 Revise the answerQuestions() method
            /*
              As long as delimitedQuestionNumbersStr is not blank, I need to get the current
              questions and answer line from the AnswerQuestionDataModel
             */
            // the delimitedQuestionNumbersStr string is a ^ delimited string of string integer keys to the 
            // qa dictionary
            if (delimitedQuestionNumbersStr.Length == 0)
            {
                if (testTypeExam)
                {
                    updateExamData();
                }
                resetLocalVariables();

                // This is the last question 
                instructionsLabel.Text = "This is the last question Save file and return to Dashboard or Repeat the Exercise!";
                             
                return;
            }

            // TODO - 202007150651 Revise getting the current questions and answer string from  the data model
            // Get the leading integer string from the delimitedQuestionNumbersStr
            string frontNumberStr = StringHelperClass.returnNthItemInDelimitedString(delimitedQuestionNumbersStr, '^', 0);
            // Remove this item from the delimitedQuestionNumbersStr
            delimitedQuestionNumbersStr = StringHelperClass.removeNthItemFromDelimitedString(delimitedQuestionNumbersStr, '^', 0);
            // Convert this to an integer key to the answerQuestionsDictionary dictionary
            int keyToQADict = Int32.Parse(frontNumberStr);
            // Get the appropriate string from the answerQuestionsDictionary
            string currentDelQALine = AnswerQuestionsDataModel.returnDesiredLineFromQADictionary(keyToQADict);
            // Parse this stirng
            string[] currentDelQALineComponents = currentDelQALine.Split('^');
            // assign values to the correct strings
            currentQuestionNumber = currentDelQALineComponents[0];
            // Convert ~ to \n\r
            currentQuestion = currentDelQALineComponents[1];
            currentQuestion =currentQuestion.Replace("~", "\r\n");
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
        }// End answerQuestions()

        /// <summary>
        /// The purpose of this method is to save the results of an exam to
        /// the FileNameScores file and the culutative results file
        /// It is called by:
        ///     1. 
        /// </summary>
        private void updateExamData()
        {
            double originalQuestionsNumInt = AnswerQuestionsDataModel.getNumCorrectAnswers();
            string currentCorrectNumAnswersStr = numCorrectAnswers.ToString();
            string orriginalNumOfQuestions = originalQuestionsNumInt.ToString();
            string outputNumCorrectStr = $"{currentCorrectNumAnswersStr} out of {orriginalNumOfQuestions} were Correct!";
            double originalQuestions = AnswerQuestionsDataModel.getNumCorrectAnswers();
            double percentCorrect = (numCorrectAnswers / originalQuestionsNumInt) * 100;
            string percentCorrectStr = String.Format("{0:00.0}", percentCorrect);
            QAFileNameScoresModel.updateQAFileNameScoresExamResults(keyToQAFileNameScoresDictionary, outputNumCorrectStr);
            // Create cumulativeResultsOutputStr
            string cumulativeResultsOutputStr = currentDatetimeStr + ":" + percentCorrectStr + ":" + incorrectAnswerNumStr + "~";
            QACumulativeResultsModel.updateCumulativeresultsDictionary(keyIntStr+"q", cumulativeResultsOutputStr);


        }// End updateExamData

        private void resetLocalVariables()
        {
            testTypeSet = false;
            questionSequenceSet = false;
            testTypeExam = true;
            questionSequenceSeriatem = true;
            delimitedQuestionNumbersStr = "";
            incorrectQuestionNumbersStr = "";
            currentDatetimeStr = "";
            currentQuestion = "";
            correctAnswer = "";
            currentImageURL = "";
            currentMp3URL = "";
            currentQuestionNumStr = "";
            incorrectAnswerNumStr = "";
            // do not reset this value      keyIntStr = "";
        }// End resetLocalVariable


    }// End  class AnswerQuestionsForm
}// End QAProject
