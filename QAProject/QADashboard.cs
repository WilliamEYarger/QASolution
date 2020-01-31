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
                SubjectNodesListModel.loadSubjectNodesList();
                QADataModelLib.NodeChildrenDictionaryModel.loadNodeChildrenDictionary();
                QADataModelLib.TreeViewDictionaryModel.loadTreeViewDictionary();
                filesLoaded = true;
                QACumulativeResultsModel.importQACumulativeResultsFile();
            }
           
        }

        private void exitApplicationButton_Click(object sender, EventArgs e)
        {
            QADataModelLib.AccessData.saveAllFiles();
            SubjectNodesListModel.saveSubjectNodeList();
            NodeChildrenDictionaryModel.saveNodeChildrenDictionary();
            QAFileNameScoresModel.saveQAFileNameScoresFile();
            TreeViewDictionaryModel.saveTreeViewDictionary();
            QACumulativeResultsModel.exportQACumulativeResutsFile();
            Application.Exit();
            //this.ControlBox = true;
           //System.Windows.Forms.Application.Exit();
        }
    }
}
