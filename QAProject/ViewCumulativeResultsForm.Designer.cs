namespace QAProject
{
    partial class ViewCumulativeResultsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.informationButton = new System.Windows.Forms.Button();
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.qaFileSelectedButton = new System.Windows.Forms.Button();
            this.quizDataGridView = new System.Windows.Forms.DataGridView();
            this.examinationGridView = new System.Windows.Forms.DataGridView();
            this.qaFilesLabel = new System.Windows.Forms.Label();
            this.subjectFileExamResultsLabel = new System.Windows.Forms.Label();
            this.returnToDashboardButton = new System.Windows.Forms.Button();
            this.examFileSelectedButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.quizDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.examinationGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // informationButton
            // 
            this.informationButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.informationButton.Location = new System.Drawing.Point(74, 43);
            this.informationButton.Margin = new System.Windows.Forms.Padding(2);
            this.informationButton.Name = "informationButton";
            this.informationButton.Size = new System.Drawing.Size(209, 29);
            this.informationButton.TabIndex = 3;
            this.informationButton.Text = "How to use this Form";
            this.informationButton.UseVisualStyleBackColor = true;
            // 
            // formTitleLabel
            // 
            this.formTitleLabel.AutoSize = true;
            this.formTitleLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formTitleLabel.Location = new System.Drawing.Point(214, 6);
            this.formTitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new System.Drawing.Size(511, 23);
            this.formTitleLabel.TabIndex = 2;
            this.formTitleLabel.Text = "Cumulative Results of  QAFile tests and Subject Files Examinations";
            // 
            // qaFileSelectedButton
            // 
            this.qaFileSelectedButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qaFileSelectedButton.Location = new System.Drawing.Point(348, 43);
            this.qaFileSelectedButton.Margin = new System.Windows.Forms.Padding(2);
            this.qaFileSelectedButton.Name = "qaFileSelectedButton";
            this.qaFileSelectedButton.Size = new System.Drawing.Size(297, 29);
            this.qaFileSelectedButton.TabIndex = 4;
            this.qaFileSelectedButton.Text = "Take Test on this QA File Name";
            this.qaFileSelectedButton.UseVisualStyleBackColor = true;
            this.qaFileSelectedButton.Click += new System.EventHandler(this.QAFileSelectedButton_Click);
            // 
            // quizDataGridView
            // 
            this.quizDataGridView.AllowUserToAddRows = false;
            this.quizDataGridView.AllowUserToResizeColumns = false;
            this.quizDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.quizDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.quizDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.quizDataGridView.DefaultCellStyle = dataGridViewCellStyle17;
            this.quizDataGridView.Location = new System.Drawing.Point(14, 116);
            this.quizDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.quizDataGridView.Name = "quizDataGridView";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.quizDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.quizDataGridView.RowHeadersWidth = 51;
            this.quizDataGridView.RowTemplate.Height = 24;
            this.quizDataGridView.Size = new System.Drawing.Size(667, 663);
            this.quizDataGridView.TabIndex = 5;
            // 
            // examinationGridView
            // 
            this.examinationGridView.AllowUserToAddRows = false;
            this.examinationGridView.AllowUserToDeleteRows = false;
            this.examinationGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.examinationGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.examinationGridView.DefaultCellStyle = dataGridViewCellStyle19;
            this.examinationGridView.Location = new System.Drawing.Point(705, 116);
            this.examinationGridView.Margin = new System.Windows.Forms.Padding(2);
            this.examinationGridView.MultiSelect = false;
            this.examinationGridView.Name = "examinationGridView";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.examinationGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.examinationGridView.RowHeadersWidth = 51;
            this.examinationGridView.Size = new System.Drawing.Size(788, 663);
            this.examinationGridView.TabIndex = 6;
            // 
            // qaFilesLabel
            // 
            this.qaFilesLabel.AutoSize = true;
            this.qaFilesLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qaFilesLabel.Location = new System.Drawing.Point(110, 82);
            this.qaFilesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.qaFilesLabel.Name = "qaFilesLabel";
            this.qaFilesLabel.Size = new System.Drawing.Size(219, 23);
            this.qaFilesLabel.TabIndex = 7;
            this.qaFilesLabel.Text = "Results from QA File Quizes";
            // 
            // subjectFileExamResultsLabel
            // 
            this.subjectFileExamResultsLabel.AutoSize = true;
            this.subjectFileExamResultsLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectFileExamResultsLabel.Location = new System.Drawing.Point(919, 82);
            this.subjectFileExamResultsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.subjectFileExamResultsLabel.Name = "subjectFileExamResultsLabel";
            this.subjectFileExamResultsLabel.Size = new System.Drawing.Size(301, 23);
            this.subjectFileExamResultsLabel.TabIndex = 8;
            this.subjectFileExamResultsLabel.Text = "Results from Subject File Examinations";
            // 
            // returnToDashboardButton
            // 
            this.returnToDashboardButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnToDashboardButton.Location = new System.Drawing.Point(1172, 43);
            this.returnToDashboardButton.Margin = new System.Windows.Forms.Padding(2);
            this.returnToDashboardButton.Name = "returnToDashboardButton";
            this.returnToDashboardButton.Size = new System.Drawing.Size(253, 29);
            this.returnToDashboardButton.TabIndex = 9;
            this.returnToDashboardButton.Text = "Return to Dashboard";
            this.returnToDashboardButton.UseVisualStyleBackColor = true;
            this.returnToDashboardButton.Click += new System.EventHandler(this.returnToDashboardButton_Click);
            // 
            // examFileSelectedButton
            // 
            this.examFileSelectedButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.examFileSelectedButton.Location = new System.Drawing.Point(741, 43);
            this.examFileSelectedButton.Margin = new System.Windows.Forms.Padding(2);
            this.examFileSelectedButton.Name = "examFileSelectedButton";
            this.examFileSelectedButton.Size = new System.Drawing.Size(332, 29);
            this.examFileSelectedButton.TabIndex = 10;
            this.examFileSelectedButton.Text = "Take Test on this Examination File Name";
            this.examFileSelectedButton.UseVisualStyleBackColor = true;
            this.examFileSelectedButton.Click += new System.EventHandler(this.NonQAExamFileSelectedButton_Click);
            // 
            // ViewCumulativeResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1507, 795);
            this.ControlBox = false;
            this.Controls.Add(this.examFileSelectedButton);
            this.Controls.Add(this.returnToDashboardButton);
            this.Controls.Add(this.subjectFileExamResultsLabel);
            this.Controls.Add(this.qaFilesLabel);
            this.Controls.Add(this.examinationGridView);
            this.Controls.Add(this.quizDataGridView);
            this.Controls.Add(this.qaFileSelectedButton);
            this.Controls.Add(this.informationButton);
            this.Controls.Add(this.formTitleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(907, 453);
            this.Name = "ViewCumulativeResultsForm";
            this.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "ViewCumulativeResultsForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ViewCumulativeResultsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quizDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.examinationGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button informationButton;
        private System.Windows.Forms.Label formTitleLabel;
        private System.Windows.Forms.Button qaFileSelectedButton;
        private System.Windows.Forms.DataGridView quizDataGridView;
        private System.Windows.Forms.DataGridView examinationGridView;
        private System.Windows.Forms.Label qaFilesLabel;
        private System.Windows.Forms.Label subjectFileExamResultsLabel;
        private System.Windows.Forms.Button returnToDashboardButton;
        private System.Windows.Forms.Button examFileSelectedButton;
    }
}