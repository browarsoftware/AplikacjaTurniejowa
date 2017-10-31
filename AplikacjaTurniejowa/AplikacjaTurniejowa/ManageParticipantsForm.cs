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
    public partial class ManageParticipantsForm : Form
    {
        DataTable dt = new DataTable();
        DataTable dt_copy = new DataTable();

        public void UpdateDataTable()
        {
            dt.Rows.Clear();
            SQLiteConnection connection = Utils.getConnection();
            String sql = 
                "SELECT uczestnik.id myid, imie, nazwisko, rokurodzenia, kata, kumite, kihon, klub.nazwa nk, Stopien.Nazwa ns, plec.Opis Opis, CzyDruzyna, COUNT(UczestnikGrupa.id) WGrupach "
                + "FROM Uczestnik "
                + "JOIN Klub on Klub.Id = Uczestnik.IdKlub "
                + "JOIN Stopien on Stopien.Id = Uczestnik.IdStopien "
                + "JOIN Plec on Plec.Id = Uczestnik.IdPlec "
                + "JOIN UczestnikGrupa ON UczestnikGrupa.IdUczestnik = uczestnik.id WHERE UczestnikGrupa.Poziom = 1 "
                + "GROUP BY uczestnik.id, imie, nazwisko, rokurodzenia, kata, kumite, kihon, klub.nazwa, Stopien.Nazwa, plec.Opis, CzyDruzyna "
                + "UNION  "
                + "SELECT uczestnik.id myid, imie, nazwisko, rokurodzenia, kata, kumite, kihon, klub.nazwa nk, Stopien.Nazwa ns, plec.Opis Opis, CzyDruzyna, 0 WGrupach  "
                + "FROM Uczestnik  "
                + "JOIN Klub on Klub.Id = Uczestnik.IdKlub  "
                + "JOIN Stopien on Stopien.Id = Uczestnik.IdStopien "
                + "JOIN Plec on Plec.Id = Uczestnik.IdPlec "
                + "AND uczestnik.id NOT IN (SELECT UczestnikGrupa.IdUczestnik FROM UczestnikGrupa WHERE UczestnikGrupa.Poziom = 1) ";
            SQLiteCommand command2 = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command2.ExecuteReader();
            while (reader.Read())
            {
                DataRow dr = dt.NewRow();

                int liczbaKonkurencji = 0;
                

                dr[0] = reader["myid"].ToString();

                if (dr[0].ToString() == "358")
                {
                    int ccc = 0;
                    ccc++;
                }

                dr[1] = reader["imie"].ToString();
                dr[2] = reader["nazwisko"].ToString();
                dr[3] = reader["rokurodzenia"].ToString();
                dr[4] = reader["kata"].ToString();
                if (dr[4].ToString().ToLower() == "1".ToLower())
                    liczbaKonkurencji++;
                dr[5] = reader["kumite"].ToString();
                if (dr[5].ToString().ToLower() == "1".ToLower())
                    liczbaKonkurencji++;
                dr[6] = reader["kihon"].ToString();
                if (dr[6].ToString().ToLower() == "1".ToLower())
                    liczbaKonkurencji++;
                dr[7] = reader["nk"].ToString();
                dr[8] = reader["ns"].ToString();
                try
                {
                    dr[9] = reader["Opis"].ToString();
                }
                catch (Exception ee)
                {
                    int aaa = 0;
                    aaa++;
                }
                dr[10] = reader["CzyDruzyna"].ToString();

                dr[11] = liczbaKonkurencji.ToString();

                dr[12] = reader["WGrupach"].ToString();

                dt.Rows.Add(dr);
            }
            int a = 0;
            a++;
        }

        ArrayList allGroups = new ArrayList();

        public ManageParticipantsForm(ArrayList allGroups)
        {
            InitializeComponent();

            //DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Imię");
            dt.Columns.Add("Nazwisko");
            dt.Columns.Add("Rok urodzenia");
            dt.Columns.Add("Kata");
            dt.Columns.Add("Kumite");
            dt.Columns.Add("Kihon");
            dt.Columns.Add("Klub");
            dt.Columns.Add("Stopień");
            dt.Columns.Add("Pleć");
            dt.Columns.Add("Czy drużyna");
            dt.Columns.Add("Liczba konkurencji");
            dt.Columns.Add("Liczba uczestnictwa w grupach");

            for (int a = 0; a < dt.Columns.Count; a++)
            {
                dt_copy.Columns.Add(dt.Columns[a].ColumnName);
            }
            UpdateDataTable();
            

            

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;

            //dataGridView1.Sort(dataGridView1.Columns[4], ListSortDirection.Descending);
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Text = "Zarządzaj uczestnikami";
            this.StartPosition = FormStartPosition.CenterScreen;
            //dataGridView1.databin

            this.allGroups = allGroups;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 4)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;//pass by the default sorting
            }
        }

        public void UpdateDataTableWithFilter()
        {
            String clubFilter = ClubTextBox.Text;
            String nameFilter = NameTextBox.Text;
            String groupsCountFilter = GroupsCountTextBox.Text;
            String participationsInGroupsCountFilter = ParticipationsInGroupsTextBox.Text;
            dt_copy.Rows.Clear();
            try
            {
                for (int a = 0; a < dt.Rows.Count; a++)
                {
                    if (dt.Rows[a][7].ToString().ToLower().Contains(clubFilter.ToLower()) 
                        && dt.Rows[a][2].ToString().ToLower().Contains(nameFilter.ToLower())
                        && dt.Rows[a][11].ToString().ToLower().Contains(groupsCountFilter.ToLower())
                        && dt.Rows[a][12].ToString().ToLower().Contains(participationsInGroupsCountFilter.ToLower()))
                    {
                        DataRow dr = dt_copy.NewRow();
                        for (int b = 0; b < dt.Rows[a].ItemArray.Length; b++)
                            dr[b] = dt.Rows[a].ItemArray[b];
                        dt_copy.Rows.Add(dr);
                    }
                }
                dataGridView1.DataSource = dt_copy;
            }
            catch (Exception ex)
            {
                int a = 0;
                a++;
            }
            int r = 0;
            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {
                if (r % 2 == 1)
                {
                    dgvr.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
                }
                r++;
            }
            SelectedParticipantsLbael.Text = "Liczba prezentowanych uczestników: " + dt_copy.Rows.Count;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateDataTableWithFilter();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Czy na pewno chcesz usunąć tego uczestnika?", "Usuwanie uczestników", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                    String id = row.Cells[0].Value.ToString();

                    SQLiteConnection connection = Utils.getConnection();

                    try
                    {
                        String sql = "DELETE FROM UczestnikGrupa WHERE IdUczestnik = " + id;
                        SQLiteCommand command2 = new SQLiteCommand(sql, connection);
                        command2.ExecuteNonQuery();

                        sql = "DELETE FROM Uczestnik WHERE Id = " + id;
                        command2 = new SQLiteCommand(sql, connection);
                        command2.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nie można usunąć uczestnika.", "Usuwanie uczestnika", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    UpdateDataTable();
                    UpdateDataTableWithFilter();
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            /*SQLiteConnection connection = Utils.getConnection();
            String sql = "INSERT INTO Klub (Nazwa, DataZgloszenia, OsobaZglaszajaca) VALUES ('Abc','2015-02-27','Akukuku!')";
            SQLiteCommand command2 = new SQLiteCommand(sql, connection);
            command2.ExecuteNonQuery();*/
            /*
            AddClubForm acf = new AddClubForm(null, "", "", "");
            acf.ShowDialog();
            if (acf.NewAdded)
            {
                UpdateDataTable();
                UpdateDataTableWithFilter();
            }*/
            AddParticipantForm apf = new AddParticipantForm("", this.allGroups);
            apf.ShowDialog();
            if (apf.NewAdded)
            {
                UpdateDataTable();
                UpdateDataTableWithFilter();
                String lastId = apf.id;
                apf = new AddParticipantForm(lastId, this.allGroups);
                apf.ShowDialog();
                if (apf.NewAdded)
                {
                    UpdateDataTable();
                    UpdateDataTableWithFilter();
                }
            }
            
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                AddParticipantForm apf = new AddParticipantForm(row.Cells[0].Value.ToString(), this.allGroups);
                apf.ShowDialog();
                if (apf.NewAdded)
                {
                    UpdateDataTable();
                    UpdateDataTableWithFilter();
                }
            }

            /*
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                String id = row.Cells[0].Value.ToString();
                String name = row.Cells[1].Value.ToString();
                String date = row.Cells[2].Value.ToString();
                String person = row.Cells[3].Value.ToString();


                AddClubForm acf = new AddClubForm(id, name, date, person);

                acf.ShowDialog();
                if (acf.NewAdded)
                {
                    UpdateDataTable();
                    UpdateDataTableWithFilter();
                }
            }*/
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            UpdateDataTableWithFilter();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GroupsCountTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateDataTableWithFilter();
        }

        private void ParticipationsInGroupsTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateDataTableWithFilter();
        }

        private void ManageParticipantsForm_Load(object sender, EventArgs e)
        {
            UpdateDataTableWithFilter();
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            int r = 0;
            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {
                if (r % 2 == 1)
                {
                    dgvr.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
                }
                r++;
            }
        }
    }
}

