namespace QAProject
{
    partial class AnswerQuestionsForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAndReturnToDashboardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formInstructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testTypeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.examToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quizToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.formPurposeLabel = new System.Windows.Forms.Label();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.questionNumberLabel = new System.Windows.Forms.Label();
            this.questionNumberValue = new System.Windows.Forms.TextBox();
            this.currentQuestionValue = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.enterAnswerLabel = new System.Windows.Forms.Label();
            this.currentAnswerValue = new System.Windows.Forms.TextBox();
            this.seeCorrectAnswerButton = new System.Windows.Forms.Button();
            this.correctAnswerValue = new System.Windows.Forms.TextBox();
            this.answerCorrectButton = new System.Windows.Forms.Button();
            this.wrongButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testTypeToolStripMenuItem,
            this.formInstructionsToolStripMenuItem,
            this.testTypeToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1482, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testTypeToolStripMenuItem
            // 
            this.testTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAndReturnToDashboardMenuItem});
            this.testTypeToolStripMenuItem.Name = "testTypeToolStripMenuItem";
            this.testTypeToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.testTypeToolStripMenuItem.Text = "File";
            // 
            // saveAndReturnToDashboardMenuItem
            // 
            this.saveAndReturnToDashboardMenuItem.Name = "saveAndReturnToDashboardMenuItem";
            this.saveAndReturnToDashboardMenuItem.Size = new System.Drawing.Size(290, 26);
            this.saveAndReturnToDashboardMenuItem.Text = "Save and return to Dashboard";
            this.saveAndReturnToDashboardMenuItem.Click += new System.EventHandler(this.SaveAndReturnToDashboardMenuItem_Click);
            // 
            // formInstructionsToolStripMenuItem
            // 
            this.formInstructionsToolStripMenuItem.Name = "formInstructionsToolStripMenuItem";
            this.formInstructionsToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.formInstructionsToolStripMenuItem.Text = "Form Instructions";
            // 
            // testTypeToolStripMenuItem1
            // 
            this.testTypeToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.examToolStripMenuItem,
            this.quizToolStripMenuItem1});
            this.testTypeToolStripMenuItem1.Name = "testTypeToolStripMenuItem1";
            this.testTypeToolStripMenuItem1.Size = new System.Drawing.Size(84, 24);
            this.testTypeToolStripMenuItem1.Text = "Test Type";
            // 
            // examToolStripMenuItem
            // 
            this.examToolStripMenuItem.Name = "examToolStripMenuItem";
            this.examToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.examToolStripMenuItem.Text = "Exam";
            this.examToolStripMenuItem.Click += new System.EventHandler(this.ExamToolStripMenuItem_Click);
            // 
            // quizToolStripMenuItem1
            // 
            this.quizToolStripMenuItem1.Name = "quizToolStripMenuItem1";
            this.quizToolStripMenuItem1.Size = new System.Drawing.Size(128, 26);
            this.quizToolStripMenuItem1.Text = "Quiz";
            this.quizToolStripMenuItem1.Click += new System.EventHandler(this.QuizToolStripMenuItem1_Click);
            // 
            // formPurposeLabel
            // 
            this.formPurposeLabel.AutoSize = true;
            this.formPurposeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formPurposeLabel.Location = new System.Drawing.Point(462, 39);
            this.formPurposeLabel.Name = "formPurposeLabel";
            this.formPurposeLabel.Size = new System.Drawing.Size(641, 39);
            this.formPurposeLabel.TabIndex = 1;
            this.formPurposeLabel.Text = "Answer Questions and Evaluate Answers";
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionsLabel.Location = new System.Drawing.Point(25, 78);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(526, 29);
            this.instructionsLabel.TabIndex = 2;
            this.instructionsLabel.Text = "First Choose Test type and Question Sequence ";
            // 
            // questionNumberLabel
            // 
            this.questionNumberLabel.AutoSize = true;
            this.questionNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionNumberLabel.Location = new System.Drawing.Point(25, 107);
            this.questionNumberLabel.Name = "questionNumberLabel";
            this.questionNumberLabel.Size = new System.Drawing.Size(107, 25);
            this.questionNumberLabel.TabIndex = 3;
            this.questionNumberLabel.Text = "Question #";
            // 
            // questionNumberValue
            // 
            this.questionNumberValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionNumberValue.Location = new System.Drawing.Point(138, 104);
            this.questionNumberValue.Name = "questionNumberValue";
            this.questionNumberValue.ReadOnly = true;
            this.questionNumberValue.Size = new System.Drawing.Size(71, 30);
            this.questionNumberValue.TabIndex = 4;
            // 
            // currentQuestionValue
            // 
            this.currentQuestionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentQuestionValue.Location = new System.Drawing.Point(30, 140);
            this.currentQuestionValue.Multiline = true;
            this.currentQuestionValue.Name = "currentQuestionValue";
            this.currentQuestionValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.currentQuestionValue.Size = new System.Drawing.Size(1253, 200);
            this.currentQuestionValue.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1340, 174);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(391, 497);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // enterAnswerLabel
            // 
            this.enterAnswerLabel.AutoSize = true;
            this.enterAnswerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterAnswerLabel.Location = new System.Drawing.Point(25, 365);
            this.enterAnswerLabel.Name = "enterAnswerLabel";
            this.enterAnswerLabel.Size = new System.Drawing.Size(175, 25);
            this.enterAnswerLabel.TabIndex = 7;
            this.enterAnswerLabel.Text = "Enter Your Answer";
            // 
            // currentAnswerValue
            // 
            this.currentAnswerValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentAnswerValue.Location = new System.Drawing.Point(30, 405);
            this.currentAnswerValue.Multiline = true;
            this.currentAnswerValue.Name = "currentAnswerValue";
            this.currentAnswerValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.currentAnswerValue.Size = new System.Drawing.Size(1253, 200);
            this.currentAnswerValue.TabIndex = 8;
            // 
            // seeCorrectAnswerButton
            // 
            this.seeCorrectAnswerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seeCorrectAnswerButton.Location = new System.Drawing.Point(30, 637);
            this.seeCorrectAnswerButton.Name = "seeCorrectAnswerButton";
            this.seeCorrectAnswerButton.Size = new System.Drawing.Size(209, 34);
            this.seeCorrectAnswerButton.TabIndex = 9;
            this.seeCorrectAnswerButton.Text = "See Correct Answer";
            this.seeCorrectAnswerButton.UseVisualStyleBackColor = true;
            this.seeCorrectAnswerButton.Click += new System.EventHandler(this.SeeCorrectAnswerButton_Click);
            // 
            // correctAnswerValue
            // 
            this.correctAnswerValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correctAnswerValue.Location = new System.Drawing.Point(30, 702);
            this.correctAnswerValue.Multiline = true;
            this.correctAnswerValue.Name = "correctAnswerValue";
            this.correctAnswerValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.correctAnswerValue.Size = new System.Drawing.Size(1253, 200);
            this.correctAnswerValue.TabIndex = 10;
            // 
            // answerCorrectButton
            // 
            this.answerCorrectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerCorrectButton.Location = new System.Drawing.Point(1383, 783);
            this.answerCorrectButton.Name = "answerCorrectButton";
            this.answerCorrectButton.Size = new System.Drawing.Size(112, 35);
            this.answerCorrectButton.TabIndex = 11;
            this.answerCorrectButton.Text = "Correct";
            this.answerCorrectButton.UseVisualStyleBackColor = true;
            this.answerCorrectButton.Click += new System.EventHandler(this.AnswerCorrectButton_Click);
            // 
            // wrongButton
            // 
            this.wrongButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wrongButton.Location = new System.Drawing.Point(1578, 783);
            this.wrongButton.Name = "wrongButton";
            this.wrongButton.Size = new System.Drawing.Size(112, 35);
            this.wrongButton.TabIndex = 12;
            this.wrongButton.Text = "Wrong";
            this.wrongButton.UseVisualStyleBackColor = true;
            this.wrongButton.Click += new System.EventHandler(this.WrongButton_Click);
            // 
            // AnswerQuestionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1482, 853);
            this.Controls.Add(this.wrongButton);
            this.Controls.Add(this.answerCorrectButton);
            this.Controls.Add(this.correctAnswerValue);
            this.Controls.Add(this.seeCorrectAnswerButton);
            this.Controls.Add(this.currentAnswerValue);
            this.Controls.Add(this.enterAnswerLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.currentQuestionValue);
            this.Controls.Add(this.questionNumberValue);
            this.Controls.Add(this.questionNumberLabel);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.formPurposeLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnswerQuestionsForm";
            this.Text = "AnswerQuestionsForm";
            this.Load += new System.EventHandler(this.AnswerQuestionsForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAndReturnToDashboardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formInstructionsToolStripMenuItem;
        private System.Windows.Forms.Label formPurposeLabel;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Label questionNumberLabel;
        private System.Windows.Forms.TextBox questionNumberValue;
        private System.Windows.Forms.TextBox currentQuestionValue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label enterAnswerLabel;
        private System.Windows.Forms.TextBox currentAnswerValue;
        private System.Windows.Forms.Button seeCorrectAnswerButton;
        private System.Windows.Forms.TextBox correctAnswerValue;
        private System.Windows.Forms.Button answerCorrectButton;
        private System.Windows.Forms.Button wrongButton;
        private System.Windows.Forms.ToolStripMenuItem testTypeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem examToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quizToolStripMenuItem1;
    }
}