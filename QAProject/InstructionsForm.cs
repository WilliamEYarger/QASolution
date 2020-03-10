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
    public partial class instructionForm : Form
    {
        public instructionForm()
        {
            InitializeComponent();
        }

        

       

        public void instructionForm_Load(object sender, EventArgs e)
        {
            string instructionsText = Instructions.instructions;
            instructionsTextBox.Text = instructionsText;
        }

    }
}
