using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections;

namespace AplikacjaTurniejowa
{
    public partial class AddParticipantForm : Form
    {
        ArrayList degreesId = new ArrayList();
        ArrayList sexId = new ArrayList();
        ArrayList clubId = new ArrayList();
        public bool NewAdded = false;
        public String id = "";
        ArrayList allGroups = new ArrayList();
        ArrayList assignedToGroup = new ArrayList();

        public AddParticipantForm(String id, ArrayList allGroups)
        {
            InitializeComponent();

            this.allGroups = allGroups;
            this.id = id;
            SQLiteConnection connection = Utils.getConnection();
            String sql = "SELECT * FROM Stopien";
            SQLiteCommand command2 = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command2.ExecuteReader();
            while (reader.Read())
            {
                DegreeComboBox.Items.Add(reader["Nazwa"]);
                degreesId.Add(reader["Id"]);
            }
            DegreeComboBox.SelectedIndex = 0;

            sql = "SELECT * FROM Plec";
            command2 = new SQLiteCommand(sql, connection);
            reader = command2.ExecuteReader();
            while (reader.Read())
            {
                SexComboBox.Items.Add(reader["Opis"]);
                sexId.Add(reader["Id"]);
            }
            SexComboBox.SelectedIndex = 0;

            sql = "SELECT * FROM Klub";
            command2 = new SQLiteCommand(sql, connection);
            reader = command2.ExecuteReader();
            while (reader.Read())
            {
                ClubComboBox.Items.Add(reader["Nazwa"]);
                clubId.Add(reader["Id"]);
            }
            ClubComboBox.SelectedIndex = 0;

            GroupsListBox.Enabled = false;
            AssignButton.Enabled = false;
            EditButton.Enabled = false;
            RemoveButton.Enabled = false;

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Text = "Dodaj uczestnika";
            this.StartPosition = FormStartPosition.CenterScreen;
            

            if (id != "")
            {
                this.Text = "Edytuj uczestnika";
                this.AddButton.Text = "Zmień";

                GroupsListBox.Enabled = true;
                AssignButton.Enabled = true;
                EditButton.Enabled = true;
                RemoveButton.Enabled = true;


                sql = "SELECT * FROM Uczestnik WHERE id = " + id;
                command2 = new SQLiteCommand(sql, connection);
                reader = command2.ExecuteReader();
                reader.Read();

                this.NameTextBox.Text = reader["imie"].ToString();
                this.SurnameTextBox.Text = reader["nazwisko"].ToString();
                this.YearTextBox.Text = reader["RokUrodzenia"].ToString();
                if (reader["kata"].ToString().ToLower() == "True".ToLower())
                    this.KataCheckBox.Checked = true;
                else
                    this.KataCheckBox.Checked = false;
                if (reader["kumite"].ToString().ToLower() == "True".ToLower())
                    this.KumitCheckBox.Checked = true;
                else
                    this.KumitCheckBox.Checked = false;
                if (reader["kihon"].ToString().ToLower() == "True".ToLower())
                    this.KihonCheckBox.Checked = true;
                else
                    this.KihonCheckBox.Checked = false;
                
                int a = 0;

                String aaaaa = reader["idklub"].ToString().ToLower();

                while (reader["idklub"].ToString().ToLower() != (String)clubId[a].ToString())
                {
                    a++;
                }
                ClubComboBox.SelectedIndex = a;

                a = 0;
                while (reader["idstopien"].ToString().ToLower() != (String)degreesId[a].ToString())
                {
                    a++;
                }
                DegreeComboBox.SelectedIndex = a;

                a = 0;
                while (reader["idplec"].ToString().ToLower() != (String)sexId[a].ToString())
                {
                    a++;
                }
                SexComboBox.SelectedIndex = a;

                if (reader["czydruzyna"].ToString().ToLower() == "True".ToLower().ToString())
                    this.TeamCheckBox.Checked = true;
                else
                    this.TeamCheckBox.Checked = false;
                
            }

            updateGroupsAssignment();
        }

        private void updateGroupsAssignment()
        {
            GroupsListBox.Items.Clear();
            if (id != "")
            {
                SQLiteConnection connection = Utils.getConnection();
                String sql = "SELECT UczestnikGrupa.IdGrupa FROM UczestnikGrupa WHERE Poziom = 1 AND IdUczestnik = " + id;
                SQLiteCommand command2 = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    String idGrupa = reader["IdGrupa"].ToString();

                    for (int a = 0; a < allGroups.Count; a++)
                    {
                        Group g = (Group)allGroups[a];
                        if (g.id.ToString() == idGrupa)
                        {
                            GroupsListBox.Items.Add(g.name);
                            assignedToGroup.Add(g.id.ToString());
                        }
                    }

                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            SQLiteConnection connection = Utils.getConnection();

            //if (id == "")
            {

                String sql = "INSERT INTO UCZESTNIK (Imie,Nazwisko,RokUrodzenia,Kata,Kumite,Kihon,IdKlub,IdStopien,IdPlec,CzyDruzyna) VALUES(@Imie,@Nazwisko,@RokUrodzenia,@Kata,@Kumite,@Kihon,@IdKlub,@IdStopien,@IdPlec,@CzyDruzyna)";
                if (id != "")
                    sql = "UPDATE UCZESTNIK SET Imie = @Imie, Nazwisko = @Nazwisko, RokUrodzenia = @RokUrodzenia, Kata = @Kata, Kumite = @Kumite, Kihon = @Kihon, IdKlub = @IdKlub, IdStopien = @IdStopien, IdPlec = @IdPlec, CzyDruzyna = @CzyDruzyna WHERE id = " + id;

                SQLiteCommand command2 = new SQLiteCommand(sql, connection);
                command2.Parameters.AddWithValue("Imie", NameTextBox.Text);
                command2.Parameters.AddWithValue("Nazwisko", SurnameTextBox.Text);

                String year = null;
                try
                {
                    year = int.Parse(YearTextBox.Text).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błędnie wpisano datę urodzenia - spróbuj ponownie.", "Dodaj uczestnika", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                command2.Parameters.AddWithValue("RokUrodzenia", year);

                String kata = "0";
                if (KataCheckBox.Checked)
                    kata = "1";
                String kumite = "0";
                if (KumitCheckBox.Checked)
                    kumite = "1";
                String kihon = "0";
                if (KihonCheckBox.Checked)
                    kihon = "1";
                String team = "0";
                if (TeamCheckBox.Checked)
                    team = "1";

                String idClub = (String)clubId[ClubComboBox.SelectedIndex].ToString();
                String idStopien = (String)degreesId[DegreeComboBox.SelectedIndex].ToString();
                String idPlec = (String)sexId[SexComboBox.SelectedIndex].ToString();
                //ArrayList degreesId = new ArrayList();
                //ArrayList sexId = new ArrayList();
                //ArrayList clubId = new ArrayList();

                command2.Parameters.AddWithValue("Kata", kata);
                command2.Parameters.AddWithValue("Kumite", kumite);
                command2.Parameters.AddWithValue("Kihon", kihon);
                command2.Parameters.AddWithValue("IdKlub", idClub);
                command2.Parameters.AddWithValue("IdStopien", idStopien);
                command2.Parameters.AddWithValue("IdPlec", idPlec);
                command2.Parameters.AddWithValue("CzyDruzyna", team);

                command2.ExecuteNonQuery();

                String lastUserId = Utils.getLastId();
                if (id == "")
                {
                    id = Utils.getLastId();
                    Utils.AssignUserToGroups(lastUserId);
                }

                NewAdded = true;
            }
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //NewAdded = false;
            this.Close();
        }

        private void AssignButton_Click(object sender, EventArgs e)
        {
            GroupSelectionForm gsf = new GroupSelectionForm(this.allGroups, id, "");
            gsf.ShowDialog();
            if (gsf.changesMade)
            {
                updateGroupsAssignment();
                NewAdded = true;
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (GroupsListBox.SelectedIndex >= 0 && id != "")
            {
                String groupId = (String)assignedToGroup[GroupsListBox.SelectedIndex];
                GroupSelectionForm gsf = new GroupSelectionForm(this.allGroups, id, groupId);
                gsf.ShowDialog();
                if (gsf.changesMade)
                {
                    updateGroupsAssignment();
                    NewAdded = true;
                }
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (GroupsListBox.SelectedIndex >= 0 && id != "")
            {
                String groupId = (String)assignedToGroup[GroupsListBox.SelectedIndex];
                String sql2 = "DELETE FROM UczestnikGrupa WHERE Poziom = 1 AND IdGrupa = " + groupId + " AND IdUczestnik = " + id;
                SQLiteConnection connection = Utils.getConnection();
                SQLiteCommand command = new SQLiteCommand(sql2, connection);
                command.ExecuteNonQuery();
                updateGroupsAssignment();
                NewAdded = true;
            }
        }
    }
}
