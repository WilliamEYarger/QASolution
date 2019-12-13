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
            this.reviewQAFileButton = new System.Windows.Forms.Button();
            this.takeQAFileTestButton = new System.Windows.Forms.Button();
            this.vewCumulativeResultsForSelectedQAFileButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.moveNodeToNewParentGroupBox = new System.Windows.Forms.GroupBox();
            this.moveNodeButton = new System.Windows.Forms.Button();
            this.selectParentbutton = new System.Windows.Forms.Button();
            this.getMoveInfoButton = new System.Windows.Forms.Button();
            this.returnToDashboardButton = new System.Windows.Forms.Button();
            this.loadTreeButton = new System.Windows.Forms.Button();
            this.renameNodeButton = new System.Windows.Forms.Button();
            this.deleteNode = new System.Windows.Forms.Button();
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
            this.subjectTreeView.Location = new System.Drawing.Point(12, 12);
            this.subjectTreeView.Name = "subjectTreeView";
            this.subjectTreeView.Size = new System.Drawing.Size(765, 717);
            this.subjectTreeView.TabIndex = 4;
            // 
            // subjectTextLabel
            // 
            this.subjectTextLabel.AutoSize = true;
            this.subjectTextLabel.Location = new System.Drawing.Point(809, 136);
            this.subjectTextLabel.Name = "subjectTextLabel";
            this.subjectTextLabel.Size = new System.Drawing.Size(201, 38);
            this.subjectTextLabel.TabIndex = 5;
            this.subjectTextLabel.Text = "Enter Name ->";
            // 
            // subjectTextValue
            // 
            this.subjectTextValue.Location = new System.Drawing.Point(1074, 136);
            this.subjectTextValue.Name = "subjectTextValue";
            this.subjectTextValue.Size = new System.Drawing.Size(315, 43);
            this.subjectTextValue.TabIndex = 6;
            // 
            // addNewSubjectButton
            // 
            this.addNewSubjectButton.Location = new System.Drawing.Point(795, 191);
            this.addNewSubjectButton.Name = "addNewSubjectButton";
            this.addNewSubjectButton.Size = new System.Drawing.Size(194, 47);
            this.addNewSubjectButton.TabIndex = 7;
            this.addNewSubjectButton.Text = "Add Subject";
            this.addNewSubjectButton.UseVisualStyleBackColor = true;
            this.addNewSubjectButton.Click += new System.EventHandler(this.addNewSubjectButton_Click);
            // 
            // addNewSubjectChapterButton
            // 
            this.addNewSubjectChapterButton.Location = new System.Drawing.Point(995, 191);
            this.addNewSubjectChapterButton.Name = "addNewSubjectChapterButton";
            this.addNewSubjectChapterButton.Size = new System.Drawing.Size(194, 47);
            this.addNewSubjectChapterButton.TabIndex = 8;
            this.addNewSubjectChapterButton.Text = "Add Division";
            this.addNewSubjectChapterButton.UseVisualStyleBackColor = true;
            this.addNewSubjectChapterButton.Click += new System.EventHandler(this.addNewSubjectDivisionButton_Click);
            // 
            // addNewQAFileNodeButton
            // 
            this.addNewQAFileNodeButton.Location = new System.Drawing.Point(1195, 191);
            this.addNewQAFileNodeButton.Name = "addNewQAFileNodeButton";
            this.addNewQAFileNodeButton.Size = new System.Drawing.Size(194, 47);
            this.addNewQAFileNodeButton.TabIndex = 9;
            this.addNewQAFileNodeButton.Text = "Add QA File";
            this.addNewQAFileNodeButton.UseVisualStyleBackColor = true;
            this.addNewQAFileNodeButton.Click += new System.EventHandler(this.addNewQAFileNodeButton_Click);
            // 
            // reviewQAFileButton
            // 
            this.reviewQAFileButton.Location = new System.Drawing.Point(795, 328);
            this.reviewQAFileButton.Name = "reviewQAFileButton";
            this.reviewQAFileButton.Size = new System.Drawing.Size(267, 54);
            this.reviewQAFileButton.TabIndex = 10;
            this.reviewQAFileButton.Text = "Review this QA File";
            this.reviewQAFileButton.UseVisualStyleBackColor = true;
            // 
            // takeQAFileTestButton
            // 
            this.takeQAFileTestButton.Location = new System.Drawing.Point(1110, 328);
            this.takeQAFileTestButton.Name = "takeQAFileTestButton";
            this.takeQAFileTestButton.Size = new System.Drawing.Size(279, 54);
            this.takeQAFileTestButton.TabIndex = 11;
            this.takeQAFileTestButton.Text = "Take Test on this File";
            this.takeQAFileTestButton.UseVisualStyleBackColor = true;
            // 
            // vewCumulativeResultsForSelectedQAFileButton
            // 
            this.vewCumulativeResultsForSelectedQAFileButton.Location = new System.Drawing.Point(797, 415);
            this.vewCumulativeResultsForSelectedQAFileButton.Name = "vewCumulativeResultsForSelectedQAFileButton";
            this.vewCumulativeResultsForSelectedQAFileButton.Size = new System.Drawing.Size(280, 124);
            this.vewCumulativeResultsForSelectedQAFileButton.TabIndex = 13;
            this.vewCumulativeResultsForSelectedQAFileButton.Text = "View cumulative results for this QAFile";
            this.vewCumulativeResultsForSelectedQAFileButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1122, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(280, 124);
            this.button1.TabIndex = 14;
            this.button1.Text = "View cumulative results for all QAFiles";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // moveNodeToNewParentGroupBox
            // 
            this.moveNodeToNewParentGroupBox.Controls.Add(this.moveNodeButton);
            this.moveNodeToNewParentGroupBox.Controls.Add(this.selectParentbutton);
            this.moveNodeToNewParentGroupBox.Controls.Add(this.getMoveInfoButton);
            this.moveNodeToNewParentGroupBox.Location = new System.Drawing.Point(797, 544);
            this.moveNodeToNewParentGroupBox.Name = "moveNodeToNewParentGroupBox";
            this.moveNodeToNewParentGroupBox.Size = new System.Drawing.Size(605, 132);
            this.moveNodeToNewParentGroupBox.TabIndex = 15;
            this.moveNodeToNewParentGroupBox.TabStop = false;
            this.moveNodeToNewParentGroupBox.Text = "Move Node";
            // 
            // moveNodeButton
            // 
            this.moveNodeButton.Location = new System.Drawing.Point(441, 51);
            this.moveNodeButton.Name = "moveNodeButton";
            this.moveNodeButton.Size = new System.Drawing.Size(135, 43);
            this.moveNodeButton.TabIndex = 2;
            this.moveNodeButton.Text = "Move";
            this.moveNodeButton.UseVisualStyleBackColor = true;
            // 
            // selectParentbutton
            // 
            this.selectParentbutton.Location = new System.Drawing.Point(162, 51);
            this.selectParentbutton.Name = "selectParentbutton";
            this.selectParentbutton.Size = new System.Drawing.Size(263, 43);
            this.selectParentbutton.TabIndex = 1;
            this.selectParentbutton.Text = "Select New Parent";
            this.selectParentbutton.UseVisualStyleBackColor = true;
            // 
            // getMoveInfoButton
            // 
            this.getMoveInfoButton.Location = new System.Drawing.Point(6, 51);
            this.getMoveInfoButton.Name = "getMoveInfoButton";
            this.getMoveInfoButton.Size = new System.Drawing.Size(135, 43);
            this.getMoveInfoButton.TabIndex = 0;
            this.getMoveInfoButton.Text = "Get Info";
            this.getMoveInfoButton.UseVisualStyleBackColor = true;
            // 
            // returnToDashboardButton
            // 
            this.returnToDashboardButton.Location = new System.Drawing.Point(934, 682);
            this.returnToDashboardButton.Name = "returnToDashboardButton";
            this.returnToDashboardButton.Size = new System.Drawing.Size(307, 47);
            this.returnToDashboardButton.TabIndex = 16;
            this.returnToDashboardButton.Text = "Return to Dashboard";
            this.returnToDashboardButton.UseVisualStyleBackColor = true;
            this.returnToDashboardButton.Click += new System.EventHandler(this.returnToDashboardButton_Click);
            // 
            // loadTreeButton
            // 
            this.loadTreeButton.Location = new System.Drawing.Point(803, 65);
            this.loadTreeButton.Name = "loadTreeButton";
            this.loadTreeButton.Size = new System.Drawing.Size(222, 47);
            this.loadTreeButton.TabIndex = 17;
            this.loadTreeButton.Text = "Load Tree";
            this.loadTreeButton.UseVisualStyleBackColor = true;
            this.loadTreeButton.Click += new System.EventHandler(this.loadTreeButton_Click);
            // 
            // renameNodeButton
            // 
            this.renameNodeButton.Location = new System.Drawing.Point(795, 257);
            this.renameNodeButton.Name = "renameNodeButton";
            this.renameNodeButton.Size = new System.Drawing.Size(267, 47);
            this.renameNodeButton.TabIndex = 19;
            this.renameNodeButton.Text = "Rename Node";
            this.renameNodeButton.UseVisualStyleBackColor = true;
            // 
            // deleteNode
            // 
            this.deleteNode.Location = new System.Drawing.Point(1122, 257);
            this.deleteNode.Name = "deleteNode";
            this.deleteNode.Size = new System.Drawing.Size(267, 47);
            this.deleteNode.TabIndex = 20;
            this.deleteNode.Text = "Delete Node";
            this.deleteNode.UseVisualStyleBackColor = true;
            // 
            // QATreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 753);
            this.Controls.Add(this.deleteNode);
            this.Controls.Add(this.renameNodeButton);
            this.Controls.Add(this.loadTreeButton);
            this.Controls.Add(this.returnToDashboardButton);
            this.Controls.Add(this.moveNodeToNewParentGroupBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vewCumulativeResultsForSelectedQAFileButton);
            this.Controls.Add(this.takeQAFileTestButton);
            this.Controls.Add(this.reviewQAFileButton);
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
        private System.Windows.Forms.Button reviewQAFileButton;
        private System.Windows.Forms.Button takeQAFileTestButton;
        private System.Windows.Forms.Button vewCumulativeResultsForSelectedQAFileButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox moveNodeToNewParentGroupBox;
        private System.Windows.Forms.Button moveNodeButton;
        private System.Windows.Forms.Button selectParentbutton;
        private System.Windows.Forms.Button getMoveInfoButton;
        private System.Windows.Forms.Button returnToDashboardButton;
        private System.Windows.Forms.Button loadTreeButton;
        private System.Windows.Forms.Button renameNodeButton;
        private System.Windows.Forms.Button deleteNode;
    }
}