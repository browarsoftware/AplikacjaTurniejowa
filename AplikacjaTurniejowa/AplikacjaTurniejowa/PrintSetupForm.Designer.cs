namespace AplikacjaTurniejowa
{
    partial class PrintSetupForm
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
            this.SaveAllRadioButton = new System.Windows.Forms.RadioButton();
            this.SaveSelectedRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SelectGroupComboBox = new System.Windows.Forms.ComboBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveAllRadioButton
            // 
            this.SaveAllRadioButton.AutoSize = true;
            this.SaveAllRadioButton.Checked = true;
            this.SaveAllRadioButton.Location = new System.Drawing.Point(6, 19);
            this.SaveAllRadioButton.Name = "SaveAllRadioButton";
            this.SaveAllRadioButton.Size = new System.Drawing.Size(133, 17);
            this.SaveAllRadioButton.TabIndex = 0;
            this.SaveAllRadioButton.TabStop = true;
            this.SaveAllRadioButton.Text = "Zapisz wszystkie grupy";
            this.SaveAllRadioButton.UseVisualStyleBackColor = true;
            this.SaveAllRadioButton.CheckedChanged += new System.EventHandler(this.SaveAllRadioButton_CheckedChanged);
            // 
            // SaveSelectedRadioButton
            // 
            this.SaveSelectedRadioButton.AutoSize = true;
            this.SaveSelectedRadioButton.Location = new System.Drawing.Point(6, 42);
            this.SaveSelectedRadioButton.Name = "SaveSelectedRadioButton";
            this.SaveSelectedRadioButton.Size = new System.Drawing.Size(129, 17);
            this.SaveSelectedRadioButton.TabIndex = 1;
            this.SaveSelectedRadioButton.Text = "Zapisz wybraną grupę";
            this.SaveSelectedRadioButton.UseVisualStyleBackColor = true;
            this.SaveSelectedRadioButton.CheckedChanged += new System.EventHandler(this.SaveSelectedRadioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CancelButton);
            this.groupBox1.Controls.Add(this.SaveButton);
            this.groupBox1.Controls.Add(this.SelectGroupComboBox);
            this.groupBox1.Controls.Add(this.SaveAllRadioButton);
            this.groupBox1.Controls.Add(this.SaveSelectedRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 122);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // SelectGroupComboBox
            // 
            this.SelectGroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectGroupComboBox.Enabled = false;
            this.SelectGroupComboBox.FormattingEnabled = true;
            this.SelectGroupComboBox.Location = new System.Drawing.Point(6, 65);
            this.SelectGroupComboBox.Name = "SelectGroupComboBox";
            this.SelectGroupComboBox.Size = new System.Drawing.Size(583, 21);
            this.SelectGroupComboBox.TabIndex = 2;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SaveButton.Location = new System.Drawing.Point(6, 92);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Zapisz";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(514, 92);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // PrintSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 146);
            this.Controls.Add(this.groupBox1);
            this.Name = "PrintSetupForm";
            this.Text = "PrintSetupForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton SaveAllRadioButton;
        private System.Windows.Forms.RadioButton SaveSelectedRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox SelectGroupComboBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
    }
}