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
    public partial class AddClubForm : Form
    {
        public bool NewAdded = false;
        public String id = null;
        public String name = "";
        public String date = "";
        public String person = "";

        public AddClubForm(String id, String name, String date, String person)
        {
            this.id = id;
            this.name = name;
            this.date = date;
            this.person = person;

            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            if (this.id != null)
                this.AddButton.Text = "Zmień";

            NameTextBox.Text = name;
            PersonTextBox.Text = person;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection connection = Utils.getConnection();
                String name = NameTextBox.Text;
                String date = dateTimePicker1.Text;
                String person = PersonTextBox.Text;

                String sql = "";
                if (this.id == null)
                    sql = "INSERT INTO Klub (Nazwa, DataZgloszenia, OsobaZglaszajaca) VALUES (@name, @date, @person)";
                else
                    sql = "UPDATE Klub SET Nazwa = @name, DataZgloszenia = @date, OsobaZglaszajaca = @person WHERE id = " + id;
                
                SQLiteCommand command2 = new SQLiteCommand(sql, connection);
                command2.Parameters.AddWithValue("name", name);
                command2.Parameters.AddWithValue("date", date);
                command2.Parameters.AddWithValue("person", person);
                command2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return;
            }
            NewAdded = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            NewAdded = false;
            this.Close();
        }
    }
}
