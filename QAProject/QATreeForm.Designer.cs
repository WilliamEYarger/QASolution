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
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // informationButton
            // 
            this.informationButton.Location = new System.Drawing.Point(435, 25);
            this.informationButton.Name = "informationButton";
            this.informationButton.Size = new System.Drawing.Size(757, 47);
            this.informationButton.TabIndex = 3;
            this.informationButton.Text = "Click here for information as to how to use this Form";
            this.informationButton.UseVisualStyleBackColor = true;
            // 
            // formTitleLabel
            // 
            this.formTitleLabel.AutoSize = true;
            this.formTitleLabel.Location = new System.Drawing.Point(6, 30);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new System.Drawing.Size(282, 38);
            this.formTitleLabel.TabIndex = 2;
            this.formTitleLabel.Text = "QA Subject Tree View";
            // 
            // QATreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 553);
            this.Controls.Add(this.informationButton);
            this.Controls.Add(this.formTitleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "QATreeForm";
            this.Text = "QA Subject Tree";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button informationButton;
        private System.Windows.Forms.Label formTitleLabel;
    }
}