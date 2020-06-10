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
//     initializeVariables()
//      answerQuestions()
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
        private bool questionSequenceSet = false;
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
            //testTypeExam is already true
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
            // TODO - create method in AnswerQuestionsDataModel to save files
            if (testTypeExam)
            {
                updateExamData();
                
                // Update the Cumulative results file

                // Return to dashboard
                this.Hide();
                QADashboard dashboardForm = new QADashboard();
                dashboardForm.ShowDialog();
            }
            else
            {
                this.Hide();
                QADashboard dashboardForm = new QADashboard();
                dashboardForm.ShowDialog();
            }
            

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
            if(delimitedQuestionNumbersStr.Length == 0)
            {
                // This is the last question 
                instructionsLabel.Text = "This is the last question Save file and return to Dashboard or Repeat the Exercise!";
                return;
            }

            Tuple<int, string>  currentValueTuple = AnswerQuestionsDataModel.returnDelimitedValue(delimitedQuestionNumbersStr);
            int currentQuestionNumInt = currentValueTuple.Item1;
            currentQuestionNumStr = currentQuestionNumInt.ToString();            
            questionNumberValue.Text = currentQuestionNumStr;
            delimitedQuestionNumbersStr = currentValueTuple.Item2;

            // get currentQALine
            string qaLine = AnswerQuestionsDataModel.currentQALine(currentQuestionNumInt);
            // example 0^When did Aristotle live?^384-322 BCE^^
            string[] qaComponentsArray = qaLine.Split('^');
            currentQuestion = qaComponentsArray[0];
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

            //string cumulativeUpdateStr =
            /*  delimitedQuestionNumbersStr does not = list of incorrect answers
             *  1q^qa_Reeves- Roman Pagan Life and Worship-1^201910150853:95.0:1,15~
             *  keyIntStr
             *  
             *  updateCumulativeresultsDictionary
             *  String.Format("{0:00.0}", 23.4567);       // "23.5"
             */
        }

    }// End  class AnswerQuestionsForm
}// End QAProject
