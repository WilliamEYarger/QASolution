﻿using System;
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

        private void OpenSubjectsTreeButton_Click(object sender, EventArgs e)
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
                QADataModelLib.NodeChildrenDictionaryModel.LoadNodeChildrenDictionary();
                QADataModelLib.TreeViewDictionaryModel.loadTreeViewDictionary();
                filesLoaded = true;
                QACumulativeResultsModel.ImportQACumulativeResultsFile();
                QACumulativeResultsModel.ImportQAExaminationResultsFile();
                AnswerQuestionsDataModel.CreateDictionaryOfSortedQAFileText();
                AnswerQuestionsDataModel.CreateDictionaryOfAllNonQANodesName_Text();
                AnswerQuestionsDataModel.SetListOfOrderedQAFilesName_Text();
            }
           
        }

        private void ExitApplicationButton_Click(object sender, EventArgs e)
        {
            QADataModelLib.AccessData.saveAllFiles();
            //SubjectNodesListModel.saveSubjectNodeList();
            NodeChildrenDictionaryModel.SaveNodeChildrenDictionary();
            QAFileNameScoresModel.saveQAFileNameScoresFile();
            TreeViewDictionaryModel.saveTreeViewDictionary();
            QACumulativeResultsModel.ExportQACumulativeResutsFile();
            QACumulativeResultsModel.ExportExaminationResultsFile();
            Application.Exit();
        }

        private void OpenCumulativeResultsFormButton_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            ViewCumulativeResultsForm cumulativeResultsForm = new ViewCumulativeResultsForm();
            cumulativeResultsForm.ShowDialog();
        }
    }
}
