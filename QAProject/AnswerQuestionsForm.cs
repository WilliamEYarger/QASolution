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
//      answerQuestions()
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
            // get the path to the qaFile
            string qaFilePath = AnswerQuestionsDataModel.getQAFilePath();
            // Get the int value at the end of the name
            string tempQAFilePathName = qaFilePath.Substring(0, qaFilePath.Length - 4);
            char[] tempQAFilePathNameArray = tempQAFilePathName.ToCharArray();
            keyIntStr = "";
            char lastChar = tempQAFilePathNameArray[tempQAFilePathNameArray.Length-1];
            while (Char.IsDigit(lastChar))
            {
                keyIntStr = lastChar + keyIntStr;
                Array.Resize(ref tempQAFilePathNameArray, tempQAFilePathNameArray.Length - 1);
                lastChar = tempQAFilePathNameArray[tempQAFilePathNameArray.Length - 1];
            }
            // Convert this value to an integer
            keyToQAFileNameScoresDictionary = Int32.Parse(keyIntStr);
            // create the QandADictionary and the ^ delimited qaList to call the questions
            AnswerQuestionsDataModel.loadQAFileIntoDictionary(qaFilePath);
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
            delimitedQuestionNumbersStr = AnswerQuestionsDataModel.getQAList();
            testTypeSet = true;
            if (questionSequenceSet && testTypeSet)
            {
                answerQuestions();
            }
        }// End examToolStripMenuItem_Click(

        /// <summary>
        /// The Test type = Quiz menu option clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quizToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            testTypeExam = false;
            testTypeSet = true;
            delimitedQuestionNumbersStr = AnswerQuestionsDataModel.getQAList();
            if (questionSequenceSet && testTypeSet)
            {
                answerQuestions();
            }
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
            // create a tuple that returns the front value of the delimitedQuestionNumbersStr as an int and the remainder of the 
            // string as a ^ delimited string
            Tuple<string, string>  currentValueTuple = AnswerQuestionsDataModel.returnDelimitedValue(delimitedQuestionNumbersStr);
            // convert the int value of the question to a string
            string currentQuestionNumStr = currentValueTuple.Item1;
            this.currentQuestionNumStr = currentQuestionNumStr.ToString();
            // *** convert the currentQuestionNumStr into a string and display it in the 
            //questionNumberValue textbox
            questionNumberValue.Text = this.currentQuestionNumStr;
            // convert the delimitedQuestionNumbersStr to the revised ^ delimited string returned in the tuple
            delimitedQuestionNumbersStr = currentValueTuple.Item2;
            // TODO - Start Here
            // get currentQALine
            string qaLine = AnswerQuestionsDataModel.currentQALine(currentQuestionNumStr);
            // example 0^When did Aristotle live?^384-322 BCE^^
            // Get the components of the current qaLine, the question, the answer, the currentImageURL and the
            //currentMp3URL
            string[] qaComponentsArray = qaLine.Split('^');
            currentQuestion = qaComponentsArray[0];
            // adjust and line breakes int the current question and answers, represented as ~ with a new line character
            string newLine = Environment.NewLine;
            currentQuestion = currentQuestion.Replace("~", newLine);
            correctAnswer = qaComponentsArray[1];
            correctAnswer = correctAnswer.Replace("~", newLine);
            currentImageURL = qaComponentsArray[2];
            currentMp3URL = qaComponentsArray[3];
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
