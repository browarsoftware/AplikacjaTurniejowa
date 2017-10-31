namespace AplikacjaTurniejowa
{
    partial class GroupDetailsForm
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
            this.ChangeNameButton = new System.Windows.Forms.Button();
            this.GroupNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ChangeNameButton
            // 
            this.ChangeNameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ChangeNameButton.Location = new System.Drawing.Point(233, 12);
            this.ChangeNameButton.Name = "ChangeNameButton";
            this.ChangeNameButton.Size = new System.Drawing.Size(111, 23);
            this.ChangeNameButton.TabIndex = 0;
            this.ChangeNameButton.Text = "Zmień nazwę";
            this.ChangeNameButton.UseVisualStyleBackColor = false;
            this.ChangeNameButton.Click += new System.EventHandler(this.ChangeNameButton_Click);
            // 
            // GroupNameTextBox
            // 
            this.GroupNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GroupNameTextBox.Location = new System.Drawing.Point(12, 12);
            this.GroupNameTextBox.Name = "GroupNameTextBox";
            this.GroupNameTextBox.Size = new System.Drawing.Size(215, 20);
            this.GroupNameTextBox.TabIndex = 1;
            // 
            // GroupDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 47);
            this.Controls.Add(this.GroupNameTextBox);
            this.Controls.Add(this.ChangeNameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GroupDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Szczegóły grupy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChangeNameButton;
        private System.Windows.Forms.TextBox GroupNameTextBox;
    }
}