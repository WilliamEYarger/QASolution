namespace QAProject
{
    partial class QATreeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.informationButton = new System.Windows.Forms.Button();
            this.subjectTreeView = new System.Windows.Forms.TreeView();
            this.subjectTextLabel = new System.Windows.Forms.Label();
            this.subjectTextValue = new System.Windows.Forms.TextBox();
            this.addNewSubjectButton = new System.Windows.Forms.Button();
            this.addNewSubjectChapterButton = new System.Windows.Forms.Button();
            this.addNewQAFileNodeButton = new System.Windows.Forms.Button();
            this.editQAFileButton = new System.Windows.Forms.Button();
            this.takeQAFileTestButton = new System.Windows.Forms.Button();
            this.vewCumulativeResultsForSelectedQAFileButton = new System.Windows.Forms.Button();
            this.viewCumResAllFilesButton = new System.Windows.Forms.Button();
            this.moveNodeToNewParentGroupBox = new System.Windows.Forms.GroupBox();
            this.selectNewParentbutton = new System.Windows.Forms.Button();
            this.selectNodetoMoveButton = new System.Windows.Forms.Button();
            this.returnToDashboardButton = new System.Windows.Forms.Button();
            this.renameNodeButton = new System.Windows.Forms.Button();
            this.deleteNode = new System.Windows.Forms.Button();
            this.addHyperlinkButton = new System.Windows.Forms.Button();
            this.openHyperlinkButton = new System.Windows.Forms.Button();
            this.moveNodeToNewParentGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // informationButton
            // 
            this.informationButton.Location = new System.Drawing.Point(995, 12);
            this.informationButton.Name = "informationButton";
            this.informationButton.Size = new System.Drawing.Size(208, 47);
            this.informationButton.TabIndex = 3;
            this.informationButton.Text = "Get Usage Info";
            this.informationButton.UseVisualStyleBackColor = true;
            // 
            // subjectTreeView
            // 
            this.subjectTreeView.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectTreeView.Location = new System.Drawing.Point(12, 12);
            this.subjectTreeView.Name = "subjectTreeView";
            this.subjectTreeView.Size = new System.Drawing.Size(765, 743);
            this.subjectTreeView.TabIndex = 4;
            // 
            // subjectTextLabel
            // 
            this.subjectTextLabel.AutoSize = true;
            this.subjectTextLabel.Location = new System.Drawing.Point(809, 71);
            this.subjectTextLabel.Name = "subjectTextLabel";
            this.subjectTextLabel.Size = new System.Drawing.Size(201, 38);
            this.subjectTextLabel.TabIndex = 5;
            this.subjectTextLabel.Text = "Enter Name ->";
            // 
            // subjectTextValue
            // 
            this.subjectTextValue.Location = new System.Drawing.Point(1074, 71);
            this.subjectTextValue.Name = "subjectTextValue";
            this.subjectTextValue.Size = new System.Drawing.Size(315, 43);
            this.subjectTextValue.TabIndex = 6;
            this.subjectTextValue.Leave += new System.EventHandler(this.subjectTextValue_Leave);
            // 
            // addNewSubjectButton
            // 
            this.addNewSubjectButton.Location = new System.Drawing.Point(795, 126);
            this.addNewSubjectButton.Name = "addNewSubjectButton";
            this.addNewSubjectButton.Size = new System.Drawing.Size(194, 47);
            this.addNewSubjectButton.TabIndex = 7;
            this.addNewSubjectButton.Text = "Add Subject";
            this.addNewSubjectButton.UseVisualStyleBackColor = true;
            this.addNewSubjectButton.Click += new System.EventHandler(this.addNewSubjectButton_Click);
            // 
            // addNewSubjectChapterButton
            // 
            this.addNewSubjectChapterButton.Location = new System.Drawing.Point(995, 126);
            this.addNewSubjectChapterButton.Name = "addNewSubjectChapterButton";
            this.addNewSubjectChapterButton.Size = new System.Drawing.Size(194, 47);
            this.addNewSubjectChapterButton.TabIndex = 8;
            this.addNewSubjectChapterButton.Text = "Add Division";
            this.addNewSubjectChapterButton.UseVisualStyleBackColor = true;
            this.addNewSubjectChapterButton.Click += new System.EventHandler(this.addNewSubjectDivisionButton_Click);
            // 
            // addNewQAFileNodeButton
            // 
            this.addNewQAFileNodeButton.Location = new System.Drawing.Point(1195, 126);
            this.addNewQAFileNodeButton.Name = "addNewQAFileNodeButton";
            this.addNewQAFileNodeButton.Size = new System.Drawing.Size(194, 47);
            this.addNewQAFileNodeButton.TabIndex = 9;
            this.addNewQAFileNodeButton.Text = "Add QA File";
            this.addNewQAFileNodeButton.UseVisualStyleBackColor = true;
            this.addNewQAFileNodeButton.Click += new System.EventHandler(this.addNewQAFileNodeButton_Click);
            // 
            // editQAFileButton
            // 
            this.editQAFileButton.Location = new System.Drawing.Point(795, 374);
            this.editQAFileButton.Name = "editQAFileButton";
            this.editQAFileButton.Size = new System.Drawing.Size(321, 54);
            this.editQAFileButton.TabIndex = 10;
            this.editQAFileButton.Text = "Edit/Create this QA File";
            this.editQAFileButton.UseVisualStyleBackColor = true;
            this.editQAFileButton.Click += new System.EventHandler(this.editQAFileButton_Click);
            // 
            // takeQAFileTestButton
            // 
            this.takeQAFileTestButton.Location = new System.Drawing.Point(1153, 374);
            this.takeQAFileTestButton.Name = "takeQAFileTestButton";
            this.takeQAFileTestButton.Size = new System.Drawing.Size(267, 54);
            this.takeQAFileTestButton.TabIndex = 11;
            this.takeQAFileTestButton.Text = "Take Test on this File";
            this.takeQAFileTestButton.UseVisualStyleBackColor = true;
            // 
            // vewCumulativeResultsForSelectedQAFileButton
            // 
            this.vewCumulativeResultsForSelectedQAFileButton.Location = new System.Drawing.Point(797, 455);
            this.vewCumulativeResultsForSelectedQAFileButton.Name = "vewCumulativeResultsForSelectedQAFileButton";
            this.vewCumulativeResultsForSelectedQAFileButton.Size = new System.Drawing.Size(319, 124);
            this.vewCumulativeResultsForSelectedQAFileButton.TabIndex = 13;
            this.vewCumulativeResultsForSelectedQAFileButton.Text = "View cumulative results for this QAFile";
            this.vewCumulativeResultsForSelectedQAFileButton.UseVisualStyleBackColor = true;
            // 
            // viewCumResAllFilesButton
            // 
            this.viewCumResAllFilesButton.Location = new System.Drawing.Point(1153, 455);
            this.viewCumResAllFilesButton.Name = "viewCumResAllFilesButton";
            this.viewCumResAllFilesButton.Size = new System.Drawing.Size(267, 124);
            this.viewCumResAllFilesButton.TabIndex = 14;
            this.viewCumResAllFilesButton.Text = "View cumulative results for all QAFiles";
            this.viewCumResAllFilesButton.UseVisualStyleBackColor = true;
            // 
            // moveNodeToNewParentGroupBox
            // 
            this.moveNodeToNewParentGroupBox.Controls.Add(this.selectNewParentbutton);
            this.moveNodeToNewParentGroupBox.Controls.Add(this.selectNodetoMoveButton);
            this.moveNodeToNewParentGroupBox.Location = new System.Drawing.Point(797, 585);
            this.moveNodeToNewParentGroupBox.Name = "moveNodeToNewParentGroupBox";
            this.moveNodeToNewParentGroupBox.Size = new System.Drawing.Size(605, 148);
            this.moveNodeToNewParentGroupBox.TabIndex = 15;
            this.moveNodeToNewParentGroupBox.TabStop = false;
            this.moveNodeToNewParentGroupBox.Text = "Move Node";
            // 
            // selectNewParentbutton
            // 
            this.selectNewParentbutton.Location = new System.Drawing.Point(356, 39);
            this.selectNewParentbutton.Name = "selectNewParentbutton";
            this.selectNewParentbutton.Size = new System.Drawing.Size(267, 87);
            this.selectNewParentbutton.TabIndex = 1;
            this.selectNewParentbutton.Text = "Select New Parent";
            this.selectNewParentbutton.UseVisualStyleBackColor = true;
            this.selectNewParentbutton.Click += new System.EventHandler(this.selectNewParentbutton_Click);
            // 
            // selectNodetoMoveButton
            // 
            this.selectNodetoMoveButton.Location = new System.Drawing.Point(6, 39);
            this.selectNodetoMoveButton.Name = "selectNodetoMoveButton";
            this.selectNodetoMoveButton.Size = new System.Drawing.Size(313, 87);
            this.selectNodetoMoveButton.TabIndex = 0;
            this.selectNodetoMoveButton.Text = "Select Node To Move";
            this.selectNodetoMoveButton.UseVisualStyleBackColor = true;
            this.selectNodetoMoveButton.Click += new System.EventHandler(this.selectNodetoMoveButton_Click);
            // 
            // returnToDashboardButton
            // 
            this.returnToDashboardButton.Location = new System.Drawing.Point(959, 758);
            this.returnToDashboardButton.Name = "returnToDashboardButton";
            this.returnToDashboardButton.Size = new System.Drawing.Size(307, 47);
            this.returnToDashboardButton.TabIndex = 16;
            this.returnToDashboardButton.Text = "Return to Dashboard";
            this.returnToDashboardButton.UseVisualStyleBackColor = true;
            this.returnToDashboardButton.Click += new System.EventHandler(this.returnToDashboardButton_Click);
            // 
            // renameNodeButton
            // 
            this.renameNodeButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renameNodeButton.Location = new System.Drawing.Point(795, 192);
            this.renameNodeButton.Name = "renameNodeButton";
            this.renameNodeButton.Size = new System.Drawing.Size(251, 47);
            this.renameNodeButton.TabIndex = 19;
            this.renameNodeButton.Text = "Rename Node";
            this.renameNodeButton.UseVisualStyleBackColor = true;
            this.renameNodeButton.Click += new System.EventHandler(this.renameNodeButton_Click);
            // 
            // deleteNode
            // 
            this.deleteNode.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteNode.Location = new System.Drawing.Point(1153, 192);
            this.deleteNode.Name = "deleteNode";
            this.deleteNode.Size = new System.Drawing.Size(267, 47);
            this.deleteNode.TabIndex = 20;
            this.deleteNode.Text = "Delete Node";
            this.deleteNode.UseVisualStyleBackColor = true;
            this.deleteNode.Click += new System.EventHandler(this.deleteNode_Click);
            // 
            // addHyperlinkButton
            // 
            this.addHyperlinkButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addHyperlinkButton.Location = new System.Drawing.Point(795, 286);
            this.addHyperlinkButton.Name = "addHyperlinkButton";
            this.addHyperlinkButton.Size = new System.Drawing.Size(251, 44);
            this.addHyperlinkButton.TabIndex = 21;
            this.addHyperlinkButton.Text = "Add Link";
            this.addHyperlinkButton.UseVisualStyleBackColor = true;
            this.addHyperlinkButton.Click += new System.EventHandler(this.addHyperlinkButton_Click);
            // 
            // openHyperlinkButton
            // 
            this.openHyperlinkButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openHyperlinkButton.Location = new System.Drawing.Point(1153, 286);
            this.openHyperlinkButton.Name = "openHyperlinkButton";
            this.openHyperlinkButton.Size = new System.Drawing.Size(267, 44);
            this.openHyperlinkButton.TabIndex = 22;
            this.openHyperlinkButton.Text = "Open Link";
            this.openHyperlinkButton.UseVisualStyleBackColor = true;
            this.openHyperlinkButton.Click += new System.EventHandler(this.openHyperlinkButton_Click);
            // 
            // QATreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 853);
            this.Controls.Add(this.openHyperlinkButton);
            this.Controls.Add(this.addHyperlinkButton);
            this.Controls.Add(this.deleteNode);
            this.Controls.Add(this.renameNodeButton);
            this.Controls.Add(this.returnToDashboardButton);
            this.Controls.Add(this.moveNodeToNewParentGroupBox);
            this.Controls.Add(this.viewCumResAllFilesButton);
            this.Controls.Add(this.vewCumulativeResultsForSelectedQAFileButton);
            this.Controls.Add(this.takeQAFileTestButton);
            this.Controls.Add(this.editQAFileButton);
            this.Controls.Add(this.addNewQAFileNodeButton);
            this.Controls.Add(this.addNewSubjectChapterButton);
            this.Controls.Add(this.addNewSubjectButton);
            this.Controls.Add(this.subjectTextValue);
            this.Controls.Add(this.subjectTextLabel);
            this.Controls.Add(this.subjectTreeView);
            this.Controls.Add(this.informationButton);
            this.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "QATreeForm";
            this.Text = "QA Subject Tree";
            this.Load += new System.EventHandler(this.QATreeForm_Load);
            this.moveNodeToNewParentGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button informationButton;
        private System.Windows.Forms.TreeView subjectTreeView;
        private System.Windows.Forms.Label subjectTextLabel;
        private System.Windows.Forms.TextBox subjectTextValue;
        private System.Windows.Forms.Button addNewSubjectButton;
        private System.Windows.Forms.Button addNewSubjectChapterButton;
        private System.Windows.Forms.Button addNewQAFileNodeButton;
        private System.Windows.Forms.Button editQAFileButton;
        private System.Windows.Forms.Button takeQAFileTestButton;
        private System.Windows.Forms.Button vewCumulativeResultsForSelectedQAFileButton;
        private System.Windows.Forms.Button viewCumResAllFilesButton;
        private System.Windows.Forms.GroupBox moveNodeToNewParentGroupBox;
        private System.Windows.Forms.Button selectNodetoMoveButton;
        private System.Windows.Forms.Button returnToDashboardButton;
        private System.Windows.Forms.Button renameNodeButton;
        private System.Windows.Forms.Button deleteNode;
        private System.Windows.Forms.Button selectNewParentbutton;
        private System.Windows.Forms.Button addHyperlinkButton;
        private System.Windows.Forms.Button openHyperlinkButton;
    }
}