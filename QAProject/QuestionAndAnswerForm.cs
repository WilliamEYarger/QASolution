
//----------------------------VARIABLES------------------------------------//
//      Dictionary<int, string> qaDictionary = new Dictionary<int, string>();
//--------------------------Booleans---------------------------------------//
//      bool appendToFile
//      bool editSelectedQAPairs
//      bool editAllSeriatem
//--------------------------String---------------------------------------//
//      string currentQALine = "";
//      string imageURL = "";
//      string mp3URL = "";
//      string qaFilePath = "";
//--------------------------EVENT METHODS----------------------------------//
//      QuestionAndAnswerForm_Load(
//      openQAFileToolStripMenuItem_Click(
//      void saveFileAndReturnToDashboardToolStripMenuItem_Click(
//      void appendToolStripMenuItem_Click(
//      void editSelectedQAPairsToolStripMenuItem_Click(
//      void questionNumberValue_Leave(
//      void editAllSeriatemToolStripMenuItem_Click(
//      imagesToolStripMenuItem_Click(
//      beginANewFileToolStripMenuItem_Click(
//      getNextQAPairButton_Click(
//--------------------------HELPER METHODS-----------------------------//
//      void setQandA() 
//      void saveThisQAPair(
//      
//      

// TODO - Add an instrution form to the solution

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QADataModelLib;

namespace QAProject
{

    // TODO - Creat method for loading an image into a qu
    public partial class QuestionAndAnswerForm : Form
    {
        public QuestionAndAnswerForm()
        {
            InitializeComponent();
        }

        //----------------------------VARIABLES------------------------------------//
        private Dictionary<int, string> qaDictionary = new Dictionary<int, string>();
        //--------------------------Booleans---------------------------------------//
        // Edit mode is append to a new or existing file
        private bool appendToFile = false;
        // Edit mode is edit selected qa Pairs
        private bool editSelectedQAPairs = false;
        // Edit mode is edit All files Seriatem
        private bool editAllSeriatem = false;
        //--------------------------String---------------------------------------//


        private string imageURL = "";
        private string mp3URL = "";
        private string qaFilePath = "";
        private int currentQAPairInt = -1;

        //--------------------------EVENT METHODS----------------------------------//

        /// <summary>
        /// This Method: 1) Opens a local copy of the qaDictionary
        ///     1.  If it is called as a result of using the QA Tree form's Create/Edit button
        ///         then the qaFileNameString is the file name.
        ///         a.  If the retrieved qaFilePath is blank and new dictionary is called else
        ///         b.  The dictionary associated with an extant qaFile is loadee
        ///     2.  If it is called by Openeing the form from the dashboard then the qaFileNameString
        ///         is blank and the method is skipped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuestionAndAnswerForm_Load(object sender, EventArgs e)
        {
            string qaFileNameString = AnswerQuestionsDataModel.GetQAFileNameStr();
            if (qaFileNameString != "")
            {
                string qaFilePath = AnswerQuestionsDataModel.GetQAFilePath();
                if (qaFilePath == "")
                {
                    // Get a blank dictionary
                    qaDictionary = AnswerQuestionsDataModel.QandADictionary;
                    questionNumberValue.Text = qaDictionary.Count.ToString();
                    questionValue.Select();
                    return;
                }
                AnswerQuestionsDataModel.LoadQAFileIntoDictionary(AnswerQuestionsDataModel.GetQAFilePath());
                qaDictionary = AnswerQuestionsDataModel.QandADictionary;
                selectEditTypeLable.Visible = true;
            }//End if (qaFileNameString != "")
        }// End QuestionAndAnswerForm_Load


        /// <summary>
        /// This method is called if the QA form's open QA file menu option is clicked
        /// It uses an open file dialog to get the file path to the desired qa file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openQAFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\QAFiles";
            // Open qa File if it has data and create the qaDictionary
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                qaFilePath = ofd.FileName;
                AnswerQuestionsDataModel.SetQAFilePath(qaFilePath);
                // Determine if the file exists
                if (File.Exists(qaFilePath))
                {
                    // Determine if there are data in the file and if so read it into the dictionary
                    var fil = new FileInfo(qaFilePath);
                    long length = fil.Length;
                    if (length != 0)
                    {
                        // Load File into dictionary
                        AnswerQuestionsDataModel.LoadQAFileIntoDictionary(qaFilePath);
                        // Get dictionary
                        qaDictionary = AnswerQuestionsDataModel.QandADictionary;
                    }
                    else
                    {
                        // If the file exists, but is blank
                        // Get a blank dictionary
                        qaDictionary = AnswerQuestionsDataModel.QandADictionary;
                        questionNumberValue.Text = qaDictionary.Count.ToString();
                        questionValue.Select();
                    }
                }// EndOpen qa File if it has data and create the qaDictionary
            }// End Open file dialogue
        }// End openQAFileToolStripMenuItem_Click




        /// <summary>
        /// Called when the File-> Save file and Return to dashboard menu option is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileAndReturnToDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // send the current local value of the qaDictionary to QAFileDataModel's QandADictionary
            AnswerQuestionsDataModel.QandADictionary = qaDictionary;
            AnswerQuestionsDataModel.saveQAFile();
            this.Hide();
            this.Close();
            QADashboard dashboardForm = new QADashboard();
            dashboardForm.ShowDialog();
        }// End saveFileAndReturnToDashboardToolStripMenuItem_Click

        /// <summary>
        /// This method is called when the user wants to append new question 
        /// and answer pairs to a qa file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void appendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set booleans
            appendToFile = true;
            editSelectedQAPairs = false;
            editAllSeriatem = false;
            // Make edityTypelable visible
            selectEditTypeLable.Visible = true;
            selectEditTypeLable.Text = "When finished with a response move by using Tab or if finished call File-> Save and return";
            // Set the initial value of currentQAPairInt to the number of entries in the dictionary
            currentQAPairInt = qaDictionary.Count;
            // Place this value in the questionNumberValue textbox
            string currentNumQAPairsStr = currentQAPairInt.ToString();
            questionNumberValue.Text = currentNumQAPairsStr;
            questionValue.Select();
        }// End appendToolStripMenuItem_Click

        /// <summary>
        /// this method is called when the user wants to edit selected question and
        /// answer pairs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editSelectedQAPairsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editTypeLabel.Text = "Edit Selected Question";
            selectEditTypeLable.Visible = false;
            // Set booleans
            editSelectedQAPairs = true;
            appendToFile = false;
            editAllSeriatem = false;
            // enable entry into the questionNumberValue text box
            questionNumberValue.ReadOnly = false;
            // set focus in questionNumberValue text box
            questionNumberValue.Select();
        }// End editSelectedQAPairsToolStripMenuItem_Click


        /// <summary>
        /// This method is can only be executed when editSelectedQAPairs is true because
        /// the questionNumberValue text box is read only otherwise
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void questionNumberValue_Leave(object sender, EventArgs e)
        {
            // If edit editSelectedQAPairs is false return without further processing
            if (!editSelectedQAPairs)
            {
                return;
            }

            /*Convert the string numeric the user entered in the questionNumberValue 
             into an integer and use it to call the appropriate values from the
             qaDictionary. 
             */
            currentQAPairInt = Int32.Parse(questionNumberValue.Text);
            setQandA();
            //string currentQAString = qaDictionary[currentQAPairInt];
            //string[] currentQAValsArray = currentQAString.Split('^');
            //questionValue.Text = currentQAValsArray[0];
            //answerValue.Text = currentQAValsArray[1];
            //imageURL = currentQAValsArray[2];
            //mp3URL = currentQAValsArray[3];
            // Move to the question value text box
            questionValue.Select();
        }// End questionNumberValue_Leave

        /// <summary>
        /// This method is called when the user wants to edit all question and
        /// answer parir seriatem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editAllSeriatemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set instructions
            editTypeLabel.Text = "Edit all Questions Seriatem. Use Tab or the Mouse to move and save responses.";
            selectEditTypeLable.Visible = false;
            // Set edit booleans
            editAllSeriatem = true;
            appendToFile = false;
            editSelectedQAPairs = false;
            // Set the currentQAPairInt to 0
            currentQAPairInt = 0;
            // Set 0th question number string
            questionNumberValue.Text = "0";
            setQandA();
            questionValue.Select();
        }// End editAllSeriatemToolStripMenuItem_Click


       
        /// <summary>
        /// This method is called when the user clicks the load Image menu otion
        ///     1. It then copies the image from its original location into the 
        /// _CSharpQAFiles\Images folder creating a numeric name from the number
        /// of image files currently in that folder. 
        ///     2.  It then sends the new file name
        /// and the original file name to the ImageFilesOriginalNames.txt file so
        /// that the user could look at that file to identify the file by its
        /// original name.
        ///     3. It then opens the image in the questionImagePictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Use open file dialog to get an image
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string oldPathAndName = ofd.FileName;
                int fileCount = Directory.GetFiles(@"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\Images").Length;
                string newFileName = fileCount.ToString()+".jpg";
                string newPathAndName = @"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\Images\" + newFileName;
                System.IO.File.Copy(oldPathAndName, newPathAndName);
                imageURL = newPathAndName;
                string oldFileName = Path.GetFileName(oldPathAndName);
                string fileNameConversionStr = newFileName + " = " + oldFileName;
                // write this string to the   folder
                File.AppendAllText(@"C:\Users\Owner\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\ImageFilesOriginalNames.txt", fileNameConversionStr);

                //add the image from the _CSharpQAFiles\Images\ folder to the questionImagePictureBox
                questionImagePictureBox.ImageLocation = newPathAndName;
            }// End open file dialog
        }// End imagesToolStripMenuItem_Click


        private void beginANewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (qaDictionary.Count != 0)
            {
                MessageBox.Show("This file already exists. Select another Edit Mode!");
                return;
            }
            
            currentQAPairInt = 0;
            questionNumberValue.Text = "0";
            questionValue.Text = "";
            answerValue.Text = "";
            imageURL = "";
            mp3URL = "";
            appendToFile = true;
            editAllSeriatem = false;
            editSelectedQAPairs = false;
            questionValue.Select();

        }// End beginANewFileToolStripMenuItem_Click


        private void getNextQAPairButton_Click(object sender, EventArgs e)
        {
            // Set the value of currentQAPairsInt
            saveThisQAPair();
            if (appendToFile)
            {
                
                questionNumberValue.Text = currentQAPairInt.ToString();
            }
            return;
        }// End getNextQAPairButton_Click

        //--------------------------HELPER METHODS-----------------------------//

        /// <summary>
        /// This private method uses the global variable currentQAPairInt to
        /// get the appropriate values for the questiona and answer text and any
        /// urls and loads them onto the form
        /// </summary>
        private void setQandA() 
        {
            string [] thisQALineArray = qaDictionary[currentQAPairInt].Split('^');
            string question = thisQALineArray[0];
            string answer = thisQALineArray[1];
            questionValue.Text = question.Replace("~", "\r\n");
            answerValue.Text = answer.Replace("~", "\r\n");
            imageURL = thisQALineArray[2];
            if(imageURL != "")
            {
                questionImagePictureBox.ImageLocation = imageURL;
            }
            mp3URL = thisQALineArray[3];
            return;
        }// End setQandA

        /// <summary>
        /// This procedure creates a line for the qaDictionary from the text in the question
        /// and answet text boxes, and the strings in the url fields
        /// It assumes !!! the currentQAPairInt IS KNOWN !!!
        /// It does NOTHING about setting the next  questions and answers
        /// </summary>
        private void saveThisQAPair()
        {
            string question = questionValue.Text.Replace("\r\n", "~");
            string answer = answerValue.Text.Replace("\r\n", "~");
            string qaLine = question + '^' + answer + '^' + imageURL + '^' + mp3URL;
            // Save the current values
            // If Edit seriatem or edit selected return the new value to the dictionary
            if((editSelectedQAPairs) || (editAllSeriatem))
            {
                qaDictionary[currentQAPairInt] = qaLine;
            }
            else
            { 
                qaDictionary.Add(currentQAPairInt, qaLine);
            }
            if (appendToFile)
            {
                currentQAPairInt++;
                questionValue.Text = "";
                answerValue.Text = "";
                questionImagePictureBox.Image = null;
                return;
            }
            if (editAllSeriatem)
            {
                currentQAPairInt++;
                if (currentQAPairInt >= qaDictionary.Count)
                {
                    selectEditTypeLable.Visible = true;
                    selectEditTypeLable.Text = "That was the last QA Pair Click Save and Return Menu Item!";
                    return;
                }
                if(imageURL != "")
                {
                    questionImagePictureBox.Image = null;
                }

                setQandA();
                questionNumberValue.Text = currentQAPairInt.ToString();
                return;
            }
            if (editSelectedQAPairs)
            {
                questionNumberValue.Text = "";
                questionValue.Text = "";
                answerValue.Text = "";
                questionNumberValue.Select();
            }
        }// End saveThisQAPair

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string instructions = "This is a list of instutions for the use of this form."
                + '\n' + "This is line 2 of the insturctions.";
            instructionForm iForm = new instructionForm();
            Instructions.instructions = instructions;
            iForm.Show();
           
        }

        




        //=======================END QuestionAndAnswerForm==================//
    }// End QuestionAndAnswerForm
}// End amespace QAProject
