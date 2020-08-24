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
    public partial class QADashboard : Form
    {
        public QADashboard()
        {
            InitializeComponent();
        }

        
        private static Boolean filesLoaded = false;

        private void openSubjectsTreeButton_Click(object sender, EventArgs e)
        {
           // QATreeForm.loadTree();
            this.Hide();
            QATreeForm treeForm = new QATreeForm();
            treeForm.ShowDialog();
        }

        private void QADashboard_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            if (!filesLoaded)
            {
                QADataModelLib.AccessData.openAllFiles();
                QAFileNameScoresModel.loadQANameScoreDictionary();
                //SubjectNodesListModel.loadSubjectNodesList();
                QADataModelLib.NodeChildrenDictionaryModel.loadNodeChildrenDictionary();
                QADataModelLib.TreeViewDictionaryModel.loadTreeViewDictionary();
                filesLoaded = true;
                QACumulativeResultsModel.ImportQACumulativeResultsFile();
                AnswerQuestionsDataModel.CreateDictionaryOfSortedQAFileText();// +2020082311359
                AnswerQuestionsDataModel.CreateDictionaryOfAllNonQANodesName_Text(); //+202008231401
                AnswerQuestionsDataModel.SetListOfOrderedQAFilesName_Text();// +202008231402
            }// END if (!filesLoaded)
        }// END QADashboard_Load(

        private void exitApplicationButton_Click(object sender, EventArgs e)
        {
            QADataModelLib.AccessData.saveAllFiles();
            //SubjectNodesListModel.saveSubjectNodeList();
            NodeChildrenDictionaryModel.saveNodeChildrenDictionary();
            QAFileNameScoresModel.saveQAFileNameScoresFile();
            TreeViewDictionaryModel.saveTreeViewDictionary();
            QACumulativeResultsModel.ExportQACumulativeResutsFile();
            QACumulativeResultsModel.ExportExaminationResultsFile();//+202008231405
            Application.Exit();
        }

        private void openCeateEditQAFilesFormbutton_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            QuestionAndAnswerForm createQAForm = new QuestionAndAnswerForm();
            createQAForm.ShowDialog();
        }
    }
}
