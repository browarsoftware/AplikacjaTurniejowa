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
    public partial class ManageClubsForm : Form
    {
        DataTable dt = new DataTable();
        DataTable dt_copy = new DataTable();

        public void UpdateDataTable()
        {
            dt.Rows.Clear();
            SQLiteConnection connection = Utils.getConnection();
            String sql = "SELECT Klub.Id MyId, Nazwa, DataZgloszenia, OsobaZglaszajaca, Count(Uczestnik.id) Ilu FROM Klub JOIN Uczestnik On Uczestnik.IdKlub = Klub.Id GROUP BY Klub.Id, Nazwa, DataZgloszenia, OsobaZglaszajaca "
                + "UNION "
                + "SELECT Klub.Id, Nazwa, DataZgloszenia, OsobaZglaszajaca, 0 Ilu FROM Klub WHERE Klub.Id not in (SELECT Klub.Id FROM Klub JOIN Uczestnik On Uczestnik.IdKlub = Klub.Id)";
            SQLiteCommand command2 = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command2.ExecuteReader();
            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                dr[0] = reader["MyId"].ToString();
                dr[1] = reader["Nazwa"].ToString();
                dr[2] = reader["DataZgloszenia"].ToString();
                dr[3] = reader["OsobaZglaszajaca"].ToString();
                String iluH = reader["Ilu"].ToString();
                if (iluH.Length == 1)
                    iluH = "00" + iluH;
                else if (iluH.Length == 2)
                    iluH = "0" + iluH;
                dr[4] = iluH;
                dt.Rows.Add(dr);
            }
            int a = 0;
            a++;
        }

        public ManageClubsForm()
        {
            InitializeComponent();

            //DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nazwa");
            dt.Columns.Add("Data");
            dt.Columns.Add("Osoba zgłaszająca");
            dt.Columns.Add("Ilość uczestników");

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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Text = "Zarządzaj klubami";
            this.StartPosition = FormStartPosition.CenterScreen;
            //dataGridView1.databin
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
            String filter = NameTextBox.Text;
            dt_copy.Rows.Clear();
            try
            {
                for (int a = 0; a < dt.Rows.Count; a++)
                {
                    if (dt.Rows[a][1].ToString().ToLower().Contains(filter.ToLower()))
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
            SelectedClubsCountLabel.Text = "Liczba prezentowanych klubów: " + dt_copy.Rows.Count;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateDataTableWithFilter();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                String id = row.Cells[0].Value.ToString();

                if (row.Cells[4].Value.ToString() != "000")
                {
                    MessageBox.Show("Nie można usunąć klubu, który zgłosił uczestników. Najpierw usuń wszystkich uczestników przypisanych do klubu", "Usuwanie klubu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SQLiteConnection connection = Utils.getConnection();
                String sql = "DELETE FROM Klub WHERE Id = " + id;
                SQLiteCommand command2 = new SQLiteCommand(sql, connection);
                command2.ExecuteNonQuery();
                UpdateDataTable();
                UpdateDataTableWithFilter();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            /*SQLiteConnection connection = Utils.getConnection();
            String sql = "INSERT INTO Klub (Nazwa, DataZgloszenia, OsobaZglaszajaca) VALUES ('Abc','2015-02-27','Akukuku!')";
            SQLiteCommand command2 = new SQLiteCommand(sql, connection);
            command2.ExecuteNonQuery();*/
            AddClubForm acf = new AddClubForm(null, "", "", "");
            acf.ShowDialog();
            if (acf.NewAdded)
            {
                UpdateDataTable();
                UpdateDataTableWithFilter();
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
            }
        }

        private void ManageClubsForm_Load(object sender, EventArgs e)
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

