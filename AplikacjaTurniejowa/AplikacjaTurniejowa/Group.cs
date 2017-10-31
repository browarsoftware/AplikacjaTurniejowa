using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace AplikacjaTurniejowa
{
    public class Group
    {
        /*
         SELECT GRUPA.*, GrupaWiekowa.Nazwa NazwaGrupyWiekowej, GrupaWiekowa.PelnaNazwa PelnaNazwaGrupyWiekowej, stod.Nazwa odstopnia, stdo.Nazwa dostopnia, TypRywalizacji.Nazwa nazwatypurywalizacji, GrupaWiekowa.UrodzeniOd, GrupaWiekowa.UrodzeniDo FROM Grupa
JOIN GrupaWiekowa ON GrupaWiekowa.Id = Grupa.IdGrupaWiekowa
JOIN Stopien stod ON stod.Id = Grupa.IdStopienDo
JOIN Stopien stdo ON stdo.Id = Grupa.IdStopienDo
JOIN TypRywalizacji ON TypRywalizacji.Id = Grupa.IdTypRywalizacji
WHERE rodzic is null and poziom = 0 ORDER BY Grupa.id
         */
        public String name = "";
        public int id = 0;
        public String description = "";
        public int parent = -1;
        public int level = 0;
        public String typeName = "";
        public int type = 0;
        public int plec = 1;
        public String plecNazwa = "";
        public String nazwaGrupyWiekowej = "";

        public int IdGrupaWiekowa = 0;
        public int IdStopienOd = 0;
        public int IdStopienDo = 0;
        public int IdTypRywalizacji = 0;
        public int IdPlec = 0;
        public int CzyDruzynowa = 0;

        public Group()
        { }


        public Group(SQLiteDataReader reader)
        {
            
            name = reader["PelnaNazwaGrupyWiekowej"].ToString() + " ur. " + reader["UrodzeniOd"].ToString() + " - " + reader["UrodzeniDo"].ToString() + " - ";
            nazwaGrupyWiekowej = reader["NazwaGrupyWiekowej"].ToString();
            typeName = reader["nazwatypurywalizacji"].ToString();
            if (reader["odstopnia"].ToString() == reader["dostopnia"].ToString())
                name += reader["odstopnia"].ToString() + " ";
            else
                name += reader["odstopnia"].ToString() + " - " + reader["dostopnia"].ToString() + " ";
            


            String odId = reader["odstopniaid"].ToString();
            String doId = reader["dostopniaid"].ToString();
            String sql = "SELECT DISTINCT kolor FROM Stopien WHERE ID >= " + odId + " AND ID <= " + doId;

            SQLiteConnection connection = Utils.getConnection();
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader2 = command.ExecuteReader();
            String kolor = "";
            int a = 0;
            while (reader2.Read())
            {
                if (a > 0)
                    kolor += ", ";
                a++;
                kolor += reader2["kolor"];
            }
            name += "(pas: " + kolor + ") ";

            name += typeName + " ";

            plec = int.Parse(reader["idplec"].ToString());

            plecNazwa = reader["plecnazwa"].ToString();
            name += plecNazwa;

            id = int.Parse(reader["id"].ToString());
            object rr = reader["rodzic"];
            if (rr != null)
                try
                {
                    parent = int.Parse(reader["rodzic"].ToString());
                }
                catch { }

            String nazwaHelp = reader["nazwa"].ToString();
            if (nazwaHelp != "")
            {
                this.name = nazwaHelp;
            }
            /*
             * 

        
            CREATE TABLE Grupa (
    Id               INTEGER PRIMARY KEY AUTOINCREMENT,
    Nazwa            TEXT,
    Opis             TEXT,
    Rodzic           INTEGER REFERENCES Grupa (Id),
    Poziom           INTEGER,
    IdGrupaWiekowa   INTEGER REFERENCES GrupaWiekowa (Id),
    IdStopienOd      INTEGER REFERENCES Stopien (Id),
    IdStopienDo      INTEGER REFERENCES Stopien (Id),
    IdTypRywalizacji INTEGER REFERENCES TypRywalizacji (Id),
    IdPlec           INTEGER REFERENCES Plec (Id),
    CzyDruzynowa     BOOLEAN
);
             */
            level = int.Parse(reader["poziom"].ToString());
            IdGrupaWiekowa = int.Parse(reader["IdGrupaWiekowa"].ToString());
            IdStopienOd = int.Parse(reader["IdStopienOd"].ToString());
            IdStopienDo = int.Parse(reader["IdStopienDo"].ToString());
            IdTypRywalizacji = int.Parse(reader["IdTypRywalizacji"].ToString());
            IdPlec = int.Parse(reader["IdPlec"].ToString());
            if (reader["CzyDruzynowa"].ToString().ToLower() == "true")
                CzyDruzynowa = 1;
            else
                CzyDruzynowa = 0;

            int zzz = 0;
            zzz++;
            /*
            name = reader["nazwa"].ToString();
            id = int.Parse(reader["id"].ToString());
            description = reader["opis"].ToString();
            object rr = reader["rodzic"];
            if (rr != null)
                try
                {
                    parent = int.Parse(reader["rodzic"].ToString());
                }
                catch { }
            level = int.Parse(reader["poziom"].ToString());
            typeName = reader["TypKonkurencjiNazwa"].ToString();
            type = int.Parse(reader["TypRywalizacji"].ToString());*/
        }
        public String GenerateTooltipText()
        {
            String text = "";
            text += "Nazwa: " + name;
            text += "\nOpis: " + description;
            text += "\nPoziom: " + level;
            text += "\nTyp: " + type;
            return text;
        }
    }
}
