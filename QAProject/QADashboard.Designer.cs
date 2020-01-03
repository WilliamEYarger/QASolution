namespace QAProject
{
    partial class QADashboard
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
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.informationButton = new System.Windows.Forms.Button();
            this.openSubjectsTreeButton = new System.Windows.Forms.Button();
            this.exitApplicationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // formTitleLabel
            // 
            this.formTitleLabel.AutoSize = true;
            this.formTitleLabel.Location = new System.Drawing.Point(24, 30);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new System.Drawing.Size(299, 38);
            this.formTitleLabel.TabIndex = 0;
            this.formTitleLabel.Text = "QA Project Dash Board";
            // 
            // informationButton
            // 
            this.informationButton.Location = new System.Drawing.Point(352, 21);
            this.informationButton.Name = "informationButton";
            this.informationButton.Size = new System.Drawing.Size(757, 47);
            this.informationButton.TabIndex = 1;
            this.informationButton.Text = "Click here for information as to how to use this Dashboard";
            this.informationButton.UseVisualStyleBackColor = true;
            // 
            // openSubjectsTreeButton
            // 
            this.openSubjectsTreeButton.Location = new System.Drawing.Point(31, 103);
            this.openSubjectsTreeButton.Name = "openSubjectsTreeButton";
            this.openSubjectsTreeButton.Size = new System.Drawing.Size(232, 89);
            this.openSubjectsTreeButton.TabIndex = 2;
            this.openSubjectsTreeButton.Text = "Open the Subjects Tree ";
            this.openSubjectsTreeButton.UseVisualStyleBackColor = true;
            this.openSubjectsTreeButton.Click += new System.EventHandler(this.openSubjectsTreeButton_Click);
            // 
            // exitApplicationButton
            // 
            this.exitApplicationButton.Location = new System.Drawing.Point(367, 103);
            this.exitApplicationButton.Name = "exitApplicationButton";
            this.exitApplicationButton.Size = new System.Drawing.Size(232, 89);
            this.exitApplicationButton.TabIndex = 3;
            this.exitApplicationButton.Text = "Save Files Before Exiting";
            this.exitApplicationButton.UseVisualStyleBackColor = true;
            this.exitApplicationButton.Click += new System.EventHandler(this.exitApplicationButton_Click);
            // 
            // QADashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1151, 627);
            this.Controls.Add(this.exitApplicationButton);
            this.Controls.Add(this.openSubjectsTreeButton);
            this.Controls.Add(this.informationButton);
            this.Controls.Add(this.formTitleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "QADashboard";
            this.Text = "QA Dashboard";
            this.Load += new System.EventHandler(this.QADashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label formTitleLabel;
        private System.Windows.Forms.Button informationButton;
        private System.Windows.Forms.Button openSubjectsTreeButton;
        private System.Windows.Forms.Button exitApplicationButton;
    }
}

