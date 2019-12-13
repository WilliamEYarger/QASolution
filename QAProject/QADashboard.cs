using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QAProject
{
    public partial class QADashboard : Form
    {
        public QADashboard()
        {
            InitializeComponent();
        }

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


        }

        private void exitApplicationButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
