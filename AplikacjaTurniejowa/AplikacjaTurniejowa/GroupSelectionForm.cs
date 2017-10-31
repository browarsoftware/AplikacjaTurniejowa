using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SQLite;

namespace AplikacjaTurniejowa
{
    public partial class GroupSelectionForm : Form
    {
        ArrayList allGroups = new ArrayList();
        public bool changesMade = false;
        String id = "";
        String groupId = "";
        public GroupSelectionForm(ArrayList allGroups, String id, String groupId)
        {
            this.id = id;
            this.groupId = groupId;
            InitializeComponent();
            this.allGroups = allGroups;
            int selected = 0;
            for (int a = 0; a < allGroups.Count; a++)
            {
                Group g = (Group)allGroups[a];
                GroupsComboBox.Items.Add(g.name);
                if (g.id.ToString() == groupId)
                    selected = a;
            }
            if (allGroups.Count > 0)
            {
                if (selected > 0)
                    GroupsComboBox.SelectedIndex = selected;
                else
                    GroupsComboBox.SelectedIndex = 0;
            }

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Text = "Edytuj grupę";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void moveToAnotherGroup()
        {
            Group g = (Group)allGroups[GroupsComboBox.SelectedIndex];

            if (MessageBox.Show("Czy na pewno chcesz przenieść uczestnika do tej grupy?", "Przenoszenie uczestnika", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            try
            {
                Utils.OpenConnection();
                SQLiteConnection con = Utils.getConnection();

                String sql = "SELECT UczestnikGrupa.ID FROM UczestnikGrupa WHERE Poziom = 1 AND IdGrupa = " + g.id + " AND IdUczestnik = " + id;
                SQLiteCommand command2 = new SQLiteCommand(sql, con);
                SQLiteDataReader reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    MessageBox.Show("Ta osoba jest już przypisana do wybranej grupy", "Przenoszenie uczestnika", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }

                String groupIdHelp = "-1";
                if (groupId != "")
                    groupIdHelp = groupId;
                String sql2 = "DELETE FROM UczestnikGrupa WHERE Poziom = 1 AND IdGrupa = " + groupIdHelp + " AND IdUczestnik = " + id;
                SQLiteCommand command = new SQLiteCommand(sql2, con);
                command.ExecuteNonQuery();


                sql2 = "INSERT INTO UczestnikGrupa (IdGrupa, IdUczestnik, Poziom) VALUES (" + g.id + "," + id + ",1)";
                command2 = new SQLiteCommand(sql2, con);
                command2.ExecuteNonQuery();
                changesMade = true;
                this.Close();

            }
            catch (Exception ex)
            {
                int a = 0;
                a++;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            moveToAnotherGroup();
            changesMade = true;
            this.Close();
        }
    }
}
