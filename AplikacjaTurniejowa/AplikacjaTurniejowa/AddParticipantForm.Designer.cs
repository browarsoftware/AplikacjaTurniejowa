namespace AplikacjaTurniejowa
{
    partial class AddParticipantForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.DegreeComboBox = new System.Windows.Forms.ComboBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.KataCheckBox = new System.Windows.Forms.CheckBox();
            this.SurnameTextBox = new System.Windows.Forms.TextBox();
            this.KumitCheckBox = new System.Windows.Forms.CheckBox();
            this.KihonCheckBox = new System.Windows.Forms.CheckBox();
            this.ClubComboBox = new System.Windows.Forms.ComboBox();
            this.SexComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.YearTextBox = new System.Windows.Forms.TextBox();
            this.TeamCheckBox = new System.Windows.Forms.CheckBox();
            this.GroupsListBox = new System.Windows.Forms.ListBox();
            this.AssignButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Imię";
            // 
            // DegreeComboBox
            // 
            this.DegreeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DegreeComboBox.FormattingEnabled = true;
            this.DegreeComboBox.Location = new System.Drawing.Point(408, 13);
            this.DegreeComboBox.Name = "DegreeComboBox";
            this.DegreeComboBox.Size = new System.Drawing.Size(147, 21);
            this.DegreeComboBox.TabIndex = 4;
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AddButton.Location = new System.Drawing.Point(11, 299);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 11;
            this.AddButton.Text = "Dodaj";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.NameTextBox.Location = new System.Drawing.Point(112, 13);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(212, 20);
            this.NameTextBox.TabIndex = 1;
            // 
            // KataCheckBox
            // 
            this.KataCheckBox.AutoSize = true;
            this.KataCheckBox.Location = new System.Drawing.Point(11, 99);
            this.KataCheckBox.Name = "KataCheckBox";
            this.KataCheckBox.Size = new System.Drawing.Size(48, 17);
            this.KataCheckBox.TabIndex = 7;
            this.KataCheckBox.Text = "Kata";
            this.KataCheckBox.UseVisualStyleBackColor = true;
            // 
            // SurnameTextBox
            // 
            this.SurnameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SurnameTextBox.Location = new System.Drawing.Point(112, 38);
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.Size = new System.Drawing.Size(212, 20);
            this.SurnameTextBox.TabIndex = 2;
            // 
            // KumitCheckBox
            // 
            this.KumitCheckBox.AutoSize = true;
            this.KumitCheckBox.Location = new System.Drawing.Point(11, 122);
            this.KumitCheckBox.Name = "KumitCheckBox";
            this.KumitCheckBox.Size = new System.Drawing.Size(58, 17);
            this.KumitCheckBox.TabIndex = 8;
            this.KumitCheckBox.Text = "Kumite";
            this.KumitCheckBox.UseVisualStyleBackColor = true;
            // 
            // KihonCheckBox
            // 
            this.KihonCheckBox.AutoSize = true;
            this.KihonCheckBox.Location = new System.Drawing.Point(11, 145);
            this.KihonCheckBox.Name = "KihonCheckBox";
            this.KihonCheckBox.Size = new System.Drawing.Size(53, 17);
            this.KihonCheckBox.TabIndex = 9;
            this.KihonCheckBox.Text = "Kihon";
            this.KihonCheckBox.UseVisualStyleBackColor = true;
            // 
            // ClubComboBox
            // 
            this.ClubComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClubComboBox.FormattingEnabled = true;
            this.ClubComboBox.Location = new System.Drawing.Point(408, 67);
            this.ClubComboBox.Name = "ClubComboBox";
            this.ClubComboBox.Size = new System.Drawing.Size(147, 21);
            this.ClubComboBox.TabIndex = 6;
            // 
            // SexComboBox
            // 
            this.SexComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SexComboBox.FormattingEnabled = true;
            this.SexComboBox.Location = new System.Drawing.Point(408, 38);
            this.SexComboBox.Name = "SexComboBox";
            this.SexComboBox.Size = new System.Drawing.Size(147, 21);
            this.SexComboBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nazwisko";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Rok urodzenia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Stopień";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(343, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Płeć";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(343, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Klub";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(480, 299);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 12;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // YearTextBox
            // 
            this.YearTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.YearTextBox.Location = new System.Drawing.Point(112, 64);
            this.YearTextBox.Name = "YearTextBox";
            this.YearTextBox.Size = new System.Drawing.Size(212, 20);
            this.YearTextBox.TabIndex = 3;
            // 
            // TeamCheckBox
            // 
            this.TeamCheckBox.AutoSize = true;
            this.TeamCheckBox.Enabled = false;
            this.TeamCheckBox.Location = new System.Drawing.Point(138, 99);
            this.TeamCheckBox.Name = "TeamCheckBox";
            this.TeamCheckBox.Size = new System.Drawing.Size(83, 17);
            this.TeamCheckBox.TabIndex = 10;
            this.TeamCheckBox.Text = "Czy drużyna";
            this.TeamCheckBox.UseVisualStyleBackColor = true;
            // 
            // GroupsListBox
            // 
            this.GroupsListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GroupsListBox.FormattingEnabled = true;
            this.GroupsListBox.Location = new System.Drawing.Point(11, 197);
            this.GroupsListBox.Name = "GroupsListBox";
            this.GroupsListBox.Size = new System.Drawing.Size(481, 82);
            this.GroupsListBox.TabIndex = 16;
            // 
            // AssignButton
            // 
            this.AssignButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AssignButton.Location = new System.Drawing.Point(498, 197);
            this.AssignButton.Name = "AssignButton";
            this.AssignButton.Size = new System.Drawing.Size(57, 23);
            this.AssignButton.TabIndex = 13;
            this.AssignButton.Text = "Przypisz";
            this.AssignButton.UseVisualStyleBackColor = false;
            this.AssignButton.Click += new System.EventHandler(this.AssignButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.EditButton.Location = new System.Drawing.Point(498, 226);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(57, 23);
            this.EditButton.TabIndex = 14;
            this.EditButton.Text = "Edytuj";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.RemoveButton.Location = new System.Drawing.Point(498, 256);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(57, 23);
            this.RemoveButton.TabIndex = 15;
            this.RemoveButton.Text = "Usuń";
            this.RemoveButton.UseVisualStyleBackColor = false;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Przypisanie do grup";
            // 
            // AddParticipantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 325);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AssignButton);
            this.Controls.Add(this.GroupsListBox);
            this.Controls.Add(this.TeamCheckBox);
            this.Controls.Add(this.YearTextBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SexComboBox);
            this.Controls.Add(this.ClubComboBox);
            this.Controls.Add(this.KihonCheckBox);
            this.Controls.Add(this.KumitCheckBox);
            this.Controls.Add(this.SurnameTextBox);
            this.Controls.Add(this.KataCheckBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DegreeComboBox);
            this.Controls.Add(this.label1);
            this.Name = "AddParticipantForm";
            this.Text = "Dodaj zawodnika";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DegreeComboBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.CheckBox KataCheckBox;
        private System.Windows.Forms.TextBox SurnameTextBox;
        private System.Windows.Forms.CheckBox KumitCheckBox;
        private System.Windows.Forms.CheckBox KihonCheckBox;
        private System.Windows.Forms.ComboBox ClubComboBox;
        private System.Windows.Forms.ComboBox SexComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox YearTextBox;
        private System.Windows.Forms.CheckBox TeamCheckBox;
        private System.Windows.Forms.ListBox GroupsListBox;
        private System.Windows.Forms.Button AssignButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Label label7;
    }
}