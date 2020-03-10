namespace QAProject
{
    partial class QuestionAndAnswerForm
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
            this.components = new System.ComponentModel.Container();
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openQAFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileAndReturnToDashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beginANewFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectedQAPairsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editAllSeriatemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.questionNumberValue = new System.Windows.Forms.TextBox();
            this.questionNumberLabel = new System.Windows.Forms.Label();
            this.questionImagePictureBox = new System.Windows.Forms.PictureBox();
            this.questionValue = new System.Windows.Forms.TextBox();
            this.questionLabel = new System.Windows.Forms.Label();
            this.answerLable = new System.Windows.Forms.Label();
            this.answerValue = new System.Windows.Forms.TextBox();
            this.editTypeLabel = new System.Windows.Forms.Label();
            this.selectEditTypeLable = new System.Windows.Forms.Label();
            this.getNextQAPairButton = new System.Windows.Forms.Button();
            this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // formTitleLabel
            // 
            this.formTitleLabel.AutoSize = true;
            this.formTitleLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formTitleLabel.Location = new System.Drawing.Point(565, 20);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new System.Drawing.Size(377, 54);
            this.formTitleLabel.TabIndex = 2;
            this.formTitleLabel.Text = "Create/Edit QA Files";
            this.formTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.editTypeToolStripMenuItem,
            this.mediaToolStripMenuItem,
            this.instructionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1488, 36);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveFileAndReturnToDashboardToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(64, 32);
            this.filesToolStripMenuItem.Text = "&Files";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openQAFileToolStripMenuItem});
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(399, 32);
            this.openFileToolStripMenuItem.Text = "&Open File";
            // 
            // openQAFileToolStripMenuItem
            // 
            this.openQAFileToolStripMenuItem.Name = "openQAFileToolStripMenuItem";
            this.openQAFileToolStripMenuItem.Size = new System.Drawing.Size(210, 32);
            this.openQAFileToolStripMenuItem.Text = "Open &QA file";
            this.openQAFileToolStripMenuItem.Click += new System.EventHandler(this.openQAFileToolStripMenuItem_Click);
            // 
            // saveFileAndReturnToDashboardToolStripMenuItem
            // 
            this.saveFileAndReturnToDashboardToolStripMenuItem.Name = "saveFileAndReturnToDashboardToolStripMenuItem";
            this.saveFileAndReturnToDashboardToolStripMenuItem.Size = new System.Drawing.Size(399, 32);
            this.saveFileAndReturnToDashboardToolStripMenuItem.Text = "Save File and Return to Dashboard";
            this.saveFileAndReturnToDashboardToolStripMenuItem.Click += new System.EventHandler(this.saveFileAndReturnToDashboardToolStripMenuItem_Click);
            // 
            // editTypeToolStripMenuItem
            // 
            this.editTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beginANewFileToolStripMenuItem,
            this.appendToolStripMenuItem,
            this.editSelectedQAPairsToolStripMenuItem,
            this.editAllSeriatemToolStripMenuItem});
            this.editTypeToolStripMenuItem.Name = "editTypeToolStripMenuItem";
            this.editTypeToolStripMenuItem.Size = new System.Drawing.Size(106, 32);
            this.editTypeToolStripMenuItem.Text = "Edit Type";
            // 
            // beginANewFileToolStripMenuItem
            // 
            this.beginANewFileToolStripMenuItem.Name = "beginANewFileToolStripMenuItem";
            this.beginANewFileToolStripMenuItem.Size = new System.Drawing.Size(289, 32);
            this.beginANewFileToolStripMenuItem.Text = "Begin a New File";
            this.beginANewFileToolStripMenuItem.Click += new System.EventHandler(this.beginANewFileToolStripMenuItem_Click);
            // 
            // appendToolStripMenuItem
            // 
            this.appendToolStripMenuItem.Name = "appendToolStripMenuItem";
            this.appendToolStripMenuItem.Size = new System.Drawing.Size(289, 32);
            this.appendToolStripMenuItem.Text = "Append";
            this.appendToolStripMenuItem.Click += new System.EventHandler(this.appendToolStripMenuItem_Click);
            // 
            // editSelectedQAPairsToolStripMenuItem
            // 
            this.editSelectedQAPairsToolStripMenuItem.Name = "editSelectedQAPairsToolStripMenuItem";
            this.editSelectedQAPairsToolStripMenuItem.Size = new System.Drawing.Size(289, 32);
            this.editSelectedQAPairsToolStripMenuItem.Text = "Edit Selected QA Pairs";
            this.editSelectedQAPairsToolStripMenuItem.Click += new System.EventHandler(this.editSelectedQAPairsToolStripMenuItem_Click);
            // 
            // editAllSeriatemToolStripMenuItem
            // 
            this.editAllSeriatemToolStripMenuItem.Name = "editAllSeriatemToolStripMenuItem";
            this.editAllSeriatemToolStripMenuItem.Size = new System.Drawing.Size(289, 32);
            this.editAllSeriatemToolStripMenuItem.Text = "Edit All Seriatem";
            this.editAllSeriatemToolStripMenuItem.Click += new System.EventHandler(this.editAllSeriatemToolStripMenuItem_Click);
            // 
            // mediaToolStripMenuItem
            // 
            this.mediaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagesToolStripMenuItem,
            this.soundsToolStripMenuItem});
            this.mediaToolStripMenuItem.Name = "mediaToolStripMenuItem";
            this.mediaToolStripMenuItem.Size = new System.Drawing.Size(81, 32);
            this.mediaToolStripMenuItem.Text = "Media";
            // 
            // imagesToolStripMenuItem
            // 
            this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
            this.imagesToolStripMenuItem.Size = new System.Drawing.Size(163, 32);
            this.imagesToolStripMenuItem.Text = "Images";
            this.imagesToolStripMenuItem.Click += new System.EventHandler(this.imagesToolStripMenuItem_Click);
            // 
            // soundsToolStripMenuItem
            // 
            this.soundsToolStripMenuItem.Name = "soundsToolStripMenuItem";
            this.soundsToolStripMenuItem.Size = new System.Drawing.Size(163, 32);
            this.soundsToolStripMenuItem.Text = "Sounds";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // questionNumberValue
            // 
            this.questionNumberValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionNumberValue.Location = new System.Drawing.Point(313, 66);
            this.questionNumberValue.Name = "questionNumberValue";
            this.questionNumberValue.ReadOnly = true;
            this.questionNumberValue.Size = new System.Drawing.Size(100, 39);
            this.questionNumberValue.TabIndex = 0;
            this.questionNumberValue.TabStop = false;
            this.questionNumberValue.Leave += new System.EventHandler(this.questionNumberValue_Leave);
            // 
            // questionNumberLabel
            // 
            this.questionNumberLabel.AutoSize = true;
            this.questionNumberLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionNumberLabel.Location = new System.Drawing.Point(13, 69);
            this.questionNumberLabel.Name = "questionNumberLabel";
            this.questionNumberLabel.Size = new System.Drawing.Size(294, 32);
            this.questionNumberLabel.TabIndex = 6;
            this.questionNumberLabel.Text = "Current Question Number";
            // 
            // questionImagePictureBox
            // 
            this.questionImagePictureBox.Location = new System.Drawing.Point(1067, 166);
            this.questionImagePictureBox.Name = "questionImagePictureBox";
            this.questionImagePictureBox.Size = new System.Drawing.Size(397, 500);
            this.questionImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.questionImagePictureBox.TabIndex = 7;
            this.questionImagePictureBox.TabStop = false;
            // 
            // questionValue
            // 
            this.questionValue.Location = new System.Drawing.Point(19, 166);
            this.questionValue.Multiline = true;
            this.questionValue.Name = "questionValue";
            this.questionValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.questionValue.Size = new System.Drawing.Size(1000, 203);
            this.questionValue.TabIndex = 0;
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionLabel.Location = new System.Drawing.Point(13, 118);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(174, 32);
            this.questionLabel.TabIndex = 9;
            this.questionLabel.Text = "Enter Question";
            // 
            // answerLable
            // 
            this.answerLable.AutoSize = true;
            this.answerLable.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerLable.Location = new System.Drawing.Point(13, 401);
            this.answerLable.Name = "answerLable";
            this.answerLable.Size = new System.Drawing.Size(147, 32);
            this.answerLable.TabIndex = 10;
            this.answerLable.Text = "EnterAnswer";
            // 
            // answerValue
            // 
            this.answerValue.Location = new System.Drawing.Point(19, 463);
            this.answerValue.Multiline = true;
            this.answerValue.Name = "answerValue";
            this.answerValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.answerValue.Size = new System.Drawing.Size(1000, 203);
            this.answerValue.TabIndex = 1;
            // 
            // editTypeLabel
            // 
            this.editTypeLabel.AutoSize = true;
            this.editTypeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTypeLabel.Location = new System.Drawing.Point(981, 122);
            this.editTypeLabel.Name = "editTypeLabel";
            this.editTypeLabel.Size = new System.Drawing.Size(110, 28);
            this.editTypeLabel.TabIndex = 15;
            this.editTypeLabel.Text = "Appending";
            // 
            // selectEditTypeLable
            // 
            this.selectEditTypeLable.AutoSize = true;
            this.selectEditTypeLable.ForeColor = System.Drawing.Color.Red;
            this.selectEditTypeLable.Location = new System.Drawing.Point(436, 64);
            this.selectEditTypeLable.Name = "selectEditTypeLable";
            this.selectEditTypeLable.Size = new System.Drawing.Size(211, 38);
            this.selectEditTypeLable.TabIndex = 16;
            this.selectEditTypeLable.Text = "Select Edit Type";
            this.selectEditTypeLable.Visible = false;
            // 
            // getNextQAPairButton
            // 
            this.getNextQAPairButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getNextQAPairButton.Location = new System.Drawing.Point(85, 692);
            this.getNextQAPairButton.Name = "getNextQAPairButton";
            this.getNextQAPairButton.Size = new System.Drawing.Size(250, 49);
            this.getNextQAPairButton.TabIndex = 17;
            this.getNextQAPairButton.Text = "Get Next QA Pair";
            this.getNextQAPairButton.UseVisualStyleBackColor = true;
            this.getNextQAPairButton.Click += new System.EventHandler(this.getNextQAPairButton_Click);
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(127, 32);
            this.instructionsToolStripMenuItem.Text = "Instructions";
            this.instructionsToolStripMenuItem.Click += new System.EventHandler(this.instructionsToolStripMenuItem_Click);
            // 
            // QuestionAndAnswerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 753);
            this.Controls.Add(this.getNextQAPairButton);
            this.Controls.Add(this.selectEditTypeLable);
            this.Controls.Add(this.editTypeLabel);
            this.Controls.Add(this.answerValue);
            this.Controls.Add(this.answerLable);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.questionValue);
            this.Controls.Add(this.questionImagePictureBox);
            this.Controls.Add(this.questionNumberLabel);
            this.Controls.Add(this.questionNumberValue);
            this.Controls.Add(this.formTitleLabel);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "QuestionAndAnswerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "QuestionAndAnswerForm";
            this.Load += new System.EventHandler(this.QuestionAndAnswerForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label formTitleLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openQAFileToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox answerValue;
        private System.Windows.Forms.Label answerLable;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.TextBox questionValue;
        private System.Windows.Forms.PictureBox questionImagePictureBox;
        private System.Windows.Forms.Label questionNumberLabel;
        private System.Windows.Forms.TextBox questionNumberValue;
        private System.Windows.Forms.ToolStripMenuItem editTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSelectedQAPairsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editAllSeriatemToolStripMenuItem;
        private System.Windows.Forms.Label editTypeLabel;
        private System.Windows.Forms.Label selectEditTypeLable;
        private System.Windows.Forms.ToolStripMenuItem saveFileAndReturnToDashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beginANewFileToolStripMenuItem;
        private System.Windows.Forms.Button getNextQAPairButton;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;
    }
}