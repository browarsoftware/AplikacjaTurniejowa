using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace AplikacjaTurniejowa
{
    public partial class PrintSetupForm : Form
    {
        ArrayList allGroups = null;

        public int groupId = -1;
        public bool save = false;
        public PrintSetupForm(ArrayList allGroups, int GroupId)
        {
            InitializeComponent();
            this.allGroups = new ArrayList(); ;

            int IdToSelect = 0;
            for (int a = 0; a < allGroups.Count; a++)
            {
                Group g = (Group)allGroups[a];
                if (g.id > 1)
                {
                    SelectGroupComboBox.Items.Add(g.name);
                    this.allGroups.Add(g);
                }
            }

            if (allGroups.Count > 0)
            {
                for (int a = 0; a < this.allGroups.Count; a++)
                {
                    Group g = (Group)this.allGroups[a];
                    if (g.id == GroupId)
                        IdToSelect = a;
                }
                SelectGroupComboBox.SelectedIndex = IdToSelect;
            }

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Text = "Zapisz jako HTML";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveSelectedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
                SelectGroupComboBox.Enabled = SaveSelectedRadioButton.Checked;
        }

        private void SaveAllRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SelectGroupComboBox.Enabled = !SaveAllRadioButton.Checked;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            save = true;
            if (SaveSelectedRadioButton.Checked)
            {
                int selectedId = SelectGroupComboBox.SelectedIndex;
                Group g = (Group)allGroups[selectedId];
                groupId = g.id;
            }
            this.Close();
        }
    }
}
