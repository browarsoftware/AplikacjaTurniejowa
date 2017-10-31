using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AplikacjaTurniejowa
{
    public partial class GroupDetailsForm : Form
    {
        Group g = null;
        public bool changesMade = false;
        public GroupDetailsForm(Group g)
        {
            this.g = g;
            InitializeComponent();
            this.GroupNameTextBox.Text = g.name;
        }

        private void ChangeNameButton_Click(object sender, EventArgs e)
        {
            Utils.OpenConnection();
            SQLiteConnection con = Utils.getConnection();
            String newName = this.GroupNameTextBox.Text.Replace("'", "");
            String query = "UPDATE Grupa SET nazwa = '" + this.GroupNameTextBox.Text + "' WHERE Id = " + g.id;
            try
            {
                SQLiteCommand command = new SQLiteCommand(query, con);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            changesMade = true;
            this.Close();
        }
    }
}
