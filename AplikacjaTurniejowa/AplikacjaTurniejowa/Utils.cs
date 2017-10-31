using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Collections;
using System.IO;
using NPOI.SS.UserModel;
using System.ComponentModel;

namespace AplikacjaTurniejowa
{
    class Utils
    {
        /*
         SELECT Grupa.Id, GrupaWiekowa.Nazwa, GrupaWiekowa.UrodzeniOd, GrupaWiekowa.UrodzeniDo,stod.Nazwa,stdo.nazwa,TypRywalizacji.nazwa,Plec.nazwa, Grupa.CzyDruzynowa  FROM Grupa 
JOIN GrupaWiekowa On GrupaWiekowa.Id = Grupa.IdGrupaWiekowa
JOIN Stopien stod ON stod.Id = Grupa.IdStopienOd
JOIN Stopien stdo ON stdo.Id = Grupa.IdStopienDo
JOIN TypRywalizacji ON TypRywalizacji.Id = Grupa.IdTypRywalizacji
JOIN Plec ON Plec.Id = Grupa.IdPlec
WHERE GrupaWiekowa.Nazwa = 'J'
         */
        public static String connectionString = "Data Source=II_Ogolnopolski_Puchar_Krakowa_2017.db;Version=3;";
        private static SQLiteConnection m_dbConnection = null;
        public static Random r = new Random(0);


        public static ArrayList GetAllAthletesAtLevelAndGroup(int idGrupyRodzica, int poziom)
        {
            ArrayList al = new ArrayList();
            try
            {
                SQLiteConnection connection = getConnection();
                String sql = "SELECT Uczestnik.*, Grupa.Nazwa nazwaGrupy, Klub.Nazwa nazwaKlubu, Stopien.Nazwa nazwaStopinia, UczestnikGrupa.IdGrupa glownaGrupa, UczestnikGrupa.IdPodgrupa podgrupa FROM Uczestnik JOIN UczestnikGrupa ON UczestnikGrupa.IdUczestnik = Uczestnik.Id JOIN Grupa ON Grupa.Id = UczestnikGrupa.IdGrupa JOIN Klub ON Klub.Id = Uczestnik.IdKlub JOIN Stopien ON Stopien.Id = Uczestnik.IdStopien";
                /*String sql = "SELECT Uczestnik.*, Klub.Nazwa nazwaKlubu, Stopien.Nazwa nazwaStopinia FROM GRUPA, uczestnik "
                + "JOIN GrupaWiekowa ON GrupaWiekowa.Id = Grupa.IdGrupaWiekowa "
                + "JOIN Klub On Klub.Id = Uczestnik.IdKlub "
                + "JOIN Stopien On Stopien.Id = Uczestnik.IdStopien "
                + "WHERE GrupaWiekowa.UrodzeniOd <= Uczestnik.RokUrodzenia AND Uczestnik.RokUrodzenia <= GrupaWiekowa.UrodzeniDo "
                + "AND Grupa.IdStopienOd <= Uczestnik.IdStopien  AND Uczestnik.IdStopien <= Grupa.IdStopienDo "
                + "AND ((Grupa.IdTypRywalizacji = 1 AND Uczestnik.Kumite = 1) OR (Grupa.IdTypRywalizacji = 2 AND Uczestnik.Kata = 1) OR (Grupa.IdTypRywalizacji = 3 AND Uczestnik.Kata = 1)) "
                + "AND Uczestnik.CzyChlopiec = Grupa.CzyChlopcy "
                + "AND Grupa.Id = " + idGrupyRodzica + " "
                + "";*/
                if (poziom < 0 && idGrupyRodzica < 0) {}
                else if (poziom < 0)
                    sql += " WHERE UczestnikGrupa.poziom = " + poziom;
                else if (idGrupyRodzica < 0)
                    sql += " WHERE UczestnikGrupa.IdGrupa = " + idGrupyRodzica;
                else
                    sql += " WHERE UczestnikGrupa.IdGrupa = " + idGrupyRodzica + " AND UczestnikGrupa.poziom = " + poziom;
                SQLiteCommand command2 = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    al.Add(new Participant(reader));
                }
            }
            catch (Exception e)
            {
                int a = 0;
                a++;
            }
            return al;
        }

        public static void OpenConnection()
        {
            if (m_dbConnection == null)
            {
                m_dbConnection = new SQLiteConnection(connectionString);
                m_dbConnection.Open();
            }
        }

        public static SQLiteConnection getConnection()
        {
            if (m_dbConnection == null)
                OpenConnection();
            return m_dbConnection;
        }

        public static void CloseConnection()
        {
            if (m_dbConnection != null)
            {
                m_dbConnection.Close();
                m_dbConnection = null;
            }
        }



        public static ArrayList ReturnAllGroupsAtLevel(int parentId, int level)
        {
            ArrayList allGroups = new ArrayList();
            SQLiteConnection connection = getConnection();
            String sql = "";
            try
            {
                if (parentId < 1)
                    //sql = "SELECT Grupa.*, TypRywalizacji.Nazwa as TypKonkurencjiNazwa FROM Grupa JOIN TypRywalizacji ON Grupa.IdTypRywalizacji = TypRywalizacji.Id WHERE rodzic is null and poziom = " + level + " ORDER BY Grupa.nazwa";
                    sql = "SELECT GRUPA.*, Grupa.Nazwa NazwaGrupy, GrupaWiekowa.Nazwa NazwaGrupyWiekowej, GrupaWiekowa.PelnaNazwa PelnaNazwaGrupyWiekowej, stod.Nazwa odstopnia, stdo.Nazwa dostopnia, stod.id odstopniaid, stdo.id dostopniaid, TypRywalizacji.Nazwa nazwatypurywalizacji, GrupaWiekowa.UrodzeniOd, GrupaWiekowa.UrodzeniDo, plec.opis plecnazwa FROM Grupa "
                        + "JOIN GrupaWiekowa ON GrupaWiekowa.Id = Grupa.IdGrupaWiekowa "
                        + "JOIN Stopien stod ON stod.Id = Grupa.IdStopienOd "
                        + "JOIN Stopien stdo ON stdo.Id = Grupa.IdStopienDo "
                        + "JOIN Plec ON plec.Id = Grupa.IdPlec "
                        + "JOIN TypRywalizacji ON TypRywalizacji.Id = Grupa.IdTypRywalizacji "
                        + "WHERE rodzic is null and poziom = " + level + " ORDER BY Grupa.id ";

                else
                    //sql = "SELECT Grupa.*, TypKonkurencji.Nazwa as TypKonkurencjiNazwa FROM Grupa JOIN TypKonkurencji ON Grupa.TypKonkurencji = TypKonkurencji.Id WHERE rodzic = " + parentId + " and poziom = " + level + " ORDER BY Grupa.nazwa";
                    sql = "SELECT GRUPA.*, Grupa.Nazwa NazwaGrupy, GrupaWiekowa.Nazwa NazwaGrupyWiekowej, GrupaWiekowa.PelnaNazwa PelnaNazwaGrupyWiekowej, stod.Nazwa odstopnia, stdo.Nazwa dostopnia, stod.id odstopniaid, stdo.id dostopniaid, TypRywalizacji.Nazwa nazwatypurywalizacji, GrupaWiekowa.UrodzeniOd, GrupaWiekowa.UrodzeniDo, plec.opis plecnazwa FROM Grupa "
                        + "JOIN GrupaWiekowa ON GrupaWiekowa.Id = Grupa.IdGrupaWiekowa "
                        + "JOIN Stopien stod ON stod.Id = Grupa.IdStopienOd "
                        + "JOIN Stopien stdo ON stdo.Id = Grupa.IdStopienDo "
                        + "JOIN Plec ON plec.Id = Grupa.IdPlec "
                        + "JOIN TypRywalizacji ON TypRywalizacji.Id = Grupa.IdTypRywalizacji "
                        + "WHERE rodzic = " + parentId + " and poziom = " + level + " ORDER BY Grupa.id ";
                SQLiteCommand command2 = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    allGroups.Add(new Group(reader));
                }
            }
            catch (Exception e)
            {
                int a = 0;
                a++;
            }
            return allGroups;
        }

        public static ArrayList ReturnAllLevels(int parentId)
        {
            ArrayList allGroups = new ArrayList();
            SQLiteConnection connection = getConnection();
            String sql = "";
            sql = "SELECT DISTINCT poziom FROM Grupa WHERE rodzic = " + parentId;
            SQLiteCommand command2 = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command2.ExecuteReader();
            while (reader.Read())
            {
                allGroups.Add(reader["poziom"].ToString());
            }
            return allGroups;
        }

        public static void InitializeAllAtheletsToGroups()
        {
            String sql = "SELECT Uczestnik.*, Klub.Nazwa nazwaKlubu, Stopien.Nazwa nazwaStopinia, Grupa.Id GrupaDoPodstawienia FROM GRUPA, uczestnik "
                + "JOIN GrupaWiekowa ON GrupaWiekowa.Id = Grupa.IdGrupaWiekowa "
                + "JOIN Klub On Klub.Id = Uczestnik.IdKlub "
                + "JOIN Stopien On Stopien.Id = Uczestnik.IdStopien "
                + "WHERE GrupaWiekowa.UrodzeniOd <= Uczestnik.RokUrodzenia AND Uczestnik.RokUrodzenia <= GrupaWiekowa.UrodzeniDo "
                + "AND Grupa.IdStopienOd <= Uczestnik.IdStopien  AND Uczestnik.IdStopien <= Grupa.IdStopienDo "
                + "AND ((Grupa.IdTypRywalizacji = 1 AND Uczestnik.Kumite = 1) OR (Grupa.IdTypRywalizacji = 2 AND Uczestnik.Kata = 1) OR (Grupa.IdTypRywalizacji = 3 AND Uczestnik.Kata = 1)) "
                + "AND Grupa.CzyDruzynowa = Uczestnik.CzyDruzyna "
                + "AND Uczestnik.IdPlec = Grupa.IdPlec "
                + "";
            try
            {
                OpenConnection();
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String id = (String)reader["id"].ToString();
                    String idGrupa = (String)reader["GrupaDoPodstawienia"].ToString();


                    String sql2 = "INSERT INTO UczestnikGrupa (IdGrupa, IdUczestnik, Poziom) VALUES (" + idGrupa + "," + id + "," + 0 + ")";
                    SQLiteCommand command2 = new SQLiteCommand(sql2, m_dbConnection);
                    command2.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                int ee = 0;
                ee++;
            }
        }

        public static void AddAllAthletesToNextLevel(int level)
        {
            OpenConnection();
            if (level < 1)
                return;
            //String query = "SELECT id FROM Uczestnik";
            String query = "SELECT * FROM UczestnikGrupa WHERE poziom = " + (level - 1);
            SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);
            ArrayList al = new ArrayList();
            try
            {
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String idGrupa = (String)reader["idgrupa"].ToString();
                    String iduczestnik = (String)reader["iduczestnik"].ToString();

                    String sql2 = "INSERT INTO UczestnikGrupa (IdGrupa, IdUczestnik, Poziom) VALUES (" + idGrupa + "," + iduczestnik + "," + level + ")";
                    SQLiteCommand command2 = new SQLiteCommand(sql2, m_dbConnection);
                    command2.ExecuteNonQuery();
                }
                //AddAllAthletesToTheLevel(level, al);
            }
            catch (Exception e)
            {
                int ee = 0;
                ee++;
            }
        }

        public static void AddAllAthletesToTheLevel(int level, ArrayList AthletesId)
        {
            SQLiteConnection connection = getConnection();
            for (int a = 0; a < AthletesId.Count; a++)
            {
                try
                {
                    String id = (String)AthletesId[a];
                    String sql = "INSERT INTO UczestnikGrupa (IdUczestnik, Poziom) VALUES (" + id + "," + level + ")";
                    SQLiteCommand command2 = new SQLiteCommand(sql, connection);
                    command2.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    int ee = 0;
                    ee++;
                }
            }
        }
        /*
        public static void FillInitialGroups()
        {
            OpenConnection();
            String query = "";
            SQLiteConnection connection = getConnection();
            String[] grupyWiekowe = { "Grupa A (5 lat i młodsi) ur. 2011 i później", "Grupa B (6-7 ) ur. 2010 i 2009", "Grupa C (8-9 ) ur. 2008 i 2007", "Grupa D (10-11 ) ur. 2006 i 2005", "Grupa E (12-13 ) ur. 2004 i 2003", "Grupa Junior Młodszy 14-15 lat ur. 2001-2002", "Grupa Junior 16-17 lat ur. 2000-1999" };
            String[] plec = { "CHŁOPCY", "DZIEWCZĘTA" };
            for (int a = 0; a < grupyWiekowe.Length; a++)
            {
                for (int b = 0; b < plec.Length; b++)
                {
                    String sql = "INSERT INTO GRUPA (Opis) VALUES ('" + grupyWiekowe[a] + " " + plec[b] + "')";
                    SQLiteCommand command2 = new SQLiteCommand(sql, connection);
                    command2.ExecuteNonQuery();
                }
            }
            //for (int a = 0; 
        }*/

        public static int ImportToDatabaseFromXLS(String file, bool overrightGroup, ref String nazwaKlubu, BackgroundWorker b)
        {
            IWorkbook workbook = WorkbookFactory.Create(file);
            ISheet sheet = workbook.GetSheetAt(0);
            String dataZgłoszenia = "";
            String osobaZgłaszajaca = "";
            String NazwaKlubu = "";
            String KlubId = null;//bedzie dodane pozniej

            OpenConnection();
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            String query = "";

            ArrayList uczestnicy = new ArrayList();
            for (int row = 0; row <= sheet.LastRowNum; row++)
            {
                if (sheet.GetRow(row) != null) //null is when the row only contains empty cells 
                {
                    if (row == 5)
                    {
                        dataZgłoszenia = sheet.GetRow(row).GetCell(2).ToString().Trim();
                        osobaZgłaszajaca = sheet.GetRow(row).GetCell(5).ToString().Trim();
                    }
                    if (row == 6)
                    {
                        NazwaKlubu = sheet.GetRow(row).GetCell(2).ToString();
                        query = "Select id FROM klub where nazwa like '" + NazwaKlubu + "'";
                        command = new SQLiteCommand(query, m_dbConnection);
                        object klubIdObject = command.ExecuteScalar();
                        if (klubIdObject != null)
                        {
                            if (!overrightGroup)
                            {
                                throw new DataImportException("Klub o nazwie '" + NazwaKlubu + "' znajduje się już w bazie danych.");
                            }
                            else
                            {
                                try
                                {
                                    int klubIdInt = int.Parse(klubIdObject.ToString());
                                    KlubId = klubIdInt.ToString();
                                }
                                catch (Exception e)
                                {
                                    throw new DataImportException(e.Message);
                                }
                            }

                        }
                    }
                    if (row > 7)
                    {
                        ArrayList ud = new ArrayList();
                        //String Lp = sheet.GetRow(row).GetCell(0).NumericCellValue.ToString();
                        String Nazwisko = sheet.GetRow(row).GetCell(1).ToString();
                        if (Nazwisko != null)
                            if (Nazwisko.Trim() != "")
                            {

                                String Imie = sheet.GetRow(row).GetCell(2).ToString().Trim();
                                String RokUrodzenia = sheet.GetRow(row).GetCell(3).ToString().Trim();
                                String Plec = sheet.GetRow(row).GetCell(4).ToString().Trim();
                                String Stopien = sheet.GetRow(row).GetCell(5).ToString().Trim();
                                String Kihon = sheet.GetRow(row).GetCell(6).ToString().Trim();
                                String Kata = sheet.GetRow(row).GetCell(7).ToString().Trim();
                                String Kumite = sheet.GetRow(row).GetCell(8).ToString().Trim();
                                String CzyDruzyna = "0";

                                if (Kihon.ToLower() == "Tak".ToLower())
                                    Kihon = "1";
                                else
                                    Kihon = "0";

                                if (Kata.ToLower() == "Tak".ToLower())
                                    Kata = "1";
                                else
                                    Kata = "0";

                                if (Kumite.ToLower() == "Tak".ToLower())
                                    Kumite = "1";
                                else
                                    Kumite = "0";

                                query = "Select id FROM plec where nazwa like '" + Plec + "'";
                                command = new SQLiteCommand(query, m_dbConnection);
                                object plecIdObj = command.ExecuteScalar();
                                String PlecId = "";
                                try
                                {
                                    int plecIdInt = int.Parse(plecIdObj.ToString());
                                    PlecId = plecIdInt.ToString();
                                }
                                catch (Exception e) 
                                {
                                    throw new DataImportException("Nie wprowadzono płci zawodnika " + Nazwisko);
                                }


                                query = "Select id FROM stopien where nazwa like '" + Stopien + "'";
                                command = new SQLiteCommand(query, m_dbConnection);
                                object stopienIdObj = command.ExecuteScalar();
                                String StopienId = "";
                                try
                                {
                                    int stopienIdInt = int.Parse(stopienIdObj.ToString());
                                    StopienId = stopienIdInt.ToString();
                                }
                                catch (Exception e)
                                {
                                    throw new DataImportException("Nie wprowadzono stopnia zawodnika " + Nazwisko);
                                }

                                ud.Add(Imie);
                                ud.Add(Nazwisko);
                                ud.Add(RokUrodzenia);
                                ud.Add(Kata);
                                ud.Add(Kumite);
                                ud.Add(Kihon);
                                ud.Add(KlubId);
                                ud.Add(StopienId);
                                ud.Add(PlecId);
                                ud.Add(CzyDruzyna);

                                uczestnicy.Add(ud);

                            }
                    }
                    //MessageBox.Show(string.Format("Row {0} = {1}", row, sheet.GetRow(row).GetCell(0).StringCellValue));
                }
            }
            if (KlubId == null)
            {
                //String skrot = "";
                
                //query = "INSERT INTO Klub (Nazwa, DataZgloszenia, OsobaZglaszajaca) VALUES ('" + NazwaKlubu + "', '" + dataZgłoszenia + "','" + osobaZgłaszajaca + "')";
                query = "INSERT INTO Klub (Nazwa, DataZgloszenia, OsobaZglaszajaca) VALUES (@Nazwa, @DataZgloszenia, @OsobaZglaszajaca)";
                


                command = new SQLiteCommand(query, m_dbConnection);
                command.Parameters.AddWithValue("Nazwa", NazwaKlubu);
                command.Parameters.AddWithValue("DataZgloszenia", dataZgłoszenia);
                command.Parameters.AddWithValue("OsobaZglaszajaca", osobaZgłaszajaca);
                try
                {
                    command.ExecuteNonQuery();
                    KlubId = getLastId();
                }
                catch (Exception e)
                {
                    throw new DataImportException(e.Message);
                }

            }
            for (int a = 0; a < uczestnicy.Count; a++)
            {
                //query = "INSERT INTO Uczestnik (Imie, Nazwisko, RokUrodzenia, Kata, Kumite, Kihon, IdKlub, IdStopien, IdPlec, CzyDruzyna) VALUES (";

                query = "INSERT INTO Uczestnik (Imie, Nazwisko, RokUrodzenia, Kata, Kumite, Kihon, IdKlub, IdStopien, IdPlec, CzyDruzyna) VALUES (@Imie, @Nazwisko, @RokUrodzenia, @Kata, @Kumite, @Kihon, @IdKlub, @IdStopien, @IdPlec, @CzyDruzyna)";

                ArrayList ud = (ArrayList)uczestnicy[a];
                command = new SQLiteCommand(query, m_dbConnection);
                command.Parameters.AddWithValue("Imie", ud[0]);
                command.Parameters.AddWithValue("Nazwisko", ud[1]);
                command.Parameters.AddWithValue("RokUrodzenia", ud[2]);
                command.Parameters.AddWithValue("Kata", ud[3]);
                command.Parameters.AddWithValue("Kumite", ud[4]);
                command.Parameters.AddWithValue("Kihon", ud[5]);

                if (KlubId == null)
                    command.Parameters.AddWithValue("IdKlub", ud[6]);
                else
                    command.Parameters.AddWithValue("IdKlub", KlubId);

                command.Parameters.AddWithValue("IdStopien", ud[7]);
                command.Parameters.AddWithValue("IdPlec", ud[8]);
                command.Parameters.AddWithValue("CzyDruzyna", ud[9]);


                /*
                ArrayList ud = (ArrayList)uczestnicy[a];
                query += "'" + ud[0] + "',";//Imie
                query += "'" + ud[1] + "',";//Nazwisko
                query += "" + ud[2] + ",";//RokUrodzenia
                query += "" + ud[3] + ",";//Kata
                query += "" + ud[4] + ",";//Kumite
                query += "" + ud[5] + ",";//Kihon
                if (KlubId == null)
                    query += "" + ud[6] + ",";//IdKlub
                else
                    query += "" + KlubId + ",";//IdKlub
                query += "" + ud[7] + ",";//IdStopien
                query += "" + ud[8] + ",";//IdPlec
                query += "" + ud[9] + "";//IdPlec
                query += ")";*/
                //command = new SQLiteCommand(query, m_dbConnection);
                command.ExecuteNonQuery();
                String lastUserId = getLastId();

                /*
                 SELECT u1.*, Klub.Nazwa nazwaKlubu, Stopien.Nazwa nazwaStopinia, Grupa.Id GrupaDoPodstawienia FROM GRUPA, uczestnik u1
                JOIN GrupaWiekowa ON GrupaWiekowa.Id = Grupa.IdGrupaWiekowa 
                JOIN Klub On Klub.Id = u1.IdKlub 
                JOIN Stopien On Stopien.Id = u1.IdStopien
                WHERE 
                Grupa.IdStopienOd <= u1.IdStopien  AND u1.IdStopien <= Grupa.IdStopienDo
                AND ((Grupa.IdTypRywalizacji = 1 AND u1.Kumite = 1) OR (Grupa.IdTypRywalizacji = 2 AND u1.Kata = 1) OR (Grupa.IdTypRywalizacji = 3 AND u1.Kihon = 1))
                AND Grupa.CzyDruzynowa = u1.CzyDruzyna 
                AND u1.IdPlec = Grupa.IdPlec
                AND GrupaWiekowa.Id IN (SELECT GrupaWiekowa.Id FROM GrupaWiekowa, Uczestnik u2
                    WHERE u2.RokUrodzenia >= GrupaWiekowa.UrodzeniOd AND u2.RokUrodzenia <= GrupaWiekowa.UrodzeniDo AND u2.Id = u1.Id)
                AND u1.id = 300
                 */

                AssignUserToGroups(lastUserId);
                b.ReportProgress((a * 100) / uczestnicy.Count);
            }
            nazwaKlubu = NazwaKlubu;
            b.ReportProgress(0);
            return uczestnicy.Count;
        }


        public static void AssignUserToGroups(String lastUserId)
        {
            String sql = "SELECT u1.*, Klub.Nazwa nazwaKlubu, Stopien.Nazwa nazwaStopinia, Grupa.Id GrupaDoPodstawienia FROM GRUPA, uczestnik u1 "
                    + "JOIN GrupaWiekowa ON GrupaWiekowa.Id = Grupa.IdGrupaWiekowa "
                    + "JOIN Klub On Klub.Id = u1.IdKlub "
                    + "JOIN Stopien On Stopien.Id = u1.IdStopien "
                    + "WHERE "
                    + "Grupa.IdStopienOd <= u1.IdStopien  AND u1.IdStopien <= Grupa.IdStopienDo "
                    + "AND ((Grupa.IdTypRywalizacji = 1 AND u1.Kumite = 1) OR (Grupa.IdTypRywalizacji = 2 AND u1.Kata = 1) OR (Grupa.IdTypRywalizacji = 3 AND u1.Kihon = 1)) "
                    + "AND Grupa.CzyDruzynowa = u1.CzyDruzyna "
                    + "AND u1.IdPlec = Grupa.IdPlec "
                    + "AND GrupaWiekowa.Id IN (SELECT GrupaWiekowa.Id FROM GrupaWiekowa, Uczestnik u2 "
                    + "WHERE u2.RokUrodzenia >= GrupaWiekowa.UrodzeniOd AND u2.RokUrodzenia <= GrupaWiekowa.UrodzeniDo AND u2.Id = u1.Id) AND GRUPA.Poziom = 0 "
                    + "AND u1.id = " + lastUserId;

            try
            {
                OpenConnection();
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    String id = (String)reader["id"].ToString();
                    String idGrupa = (String)reader["GrupaDoPodstawienia"].ToString();


                    String sql2 = "INSERT INTO UczestnikGrupa (IdGrupa, IdUczestnik, Poziom) VALUES (" + idGrupa + "," + id + "," + 0 + ")";
                    SQLiteCommand command2 = new SQLiteCommand(sql2, m_dbConnection);
                    command2.ExecuteNonQuery();

                    sql2 = "INSERT INTO UczestnikGrupa (IdGrupa, IdUczestnik, Poziom) VALUES (" + idGrupa + "," + id + "," + 1 + ")";
                    command2 = new SQLiteCommand(sql2, m_dbConnection);
                    command2.ExecuteNonQuery();
                }
                if (count == 0)
                {
                    String sql2 = "INSERT INTO UczestnikGrupa (IdGrupa, IdUczestnik, Poziom) VALUES (" + 1 + "," + lastUserId + "," + 0 + ")";
                    SQLiteCommand command2 = new SQLiteCommand(sql2, m_dbConnection);
                    command2.ExecuteNonQuery();

                    sql2 = "INSERT INTO UczestnikGrupa (IdGrupa, IdUczestnik, Poziom) VALUES (" + 1 + "," + lastUserId + "," + 1 + ")";
                    command2 = new SQLiteCommand(sql2, m_dbConnection);
                    command2.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                int ee = 0;
                ee++;
            }
        }
        /*
        //jakie są dostępne grupy?
        //Use format UTF-8
        public static void ImportToDatabaseFromCSVOLD(String file, String clubName, bool skipFirstLine)
        {
            OpenConnection();
            String query = "";
            using (var fs = File.OpenRead(file))
            using (var reader = new StreamReader(fs))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                int a = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('\t');
                    if (skipFirstLine && a == 0)
                    {
                    }
                    else
                    {
                        try
                        {
                            String imie = values[0].Trim();
                            String nazwisko = values[1].Trim();
                            String klub = values[2].Trim();
                            String stopien = values[3].Trim();
                            String rok = values[4].Trim();
                            String kata = values[5].Trim();
                            String kumite = values[6].Trim();
                            String grupa = values[7].Trim();

                            query = "Select id FROM klub where nazwa like '" + klub + "'";
                            SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);
                            object clubId = command.ExecuteScalar();
                            query = "Select id FROM stopien where nazwa like '" + stopien + "'";
                            command = new SQLiteCommand(query, m_dbConnection);
                            object stopienId = command.ExecuteScalar();
                            query = "Select id FROM GrupaWiekowa where nazwa like '" + grupa + "'";
                            command = new SQLiteCommand(query, m_dbConnection);
                            object grupaId = command.ExecuteScalar();

                            if (kata == "") kata = "0";
                            else kata = "1";
                            if (kumite == "") kumite = "0";
                            else kumite = "1";
                            if (clubId == null)
                                clubId = clubName;
                            if (rok == "") rok = "-1";

                            if (grupaId == null)
                            {
                                query = "Select id FROM GrupaWiekowa where nazwa like 'Brak danych'";
                                command = new SQLiteCommand(query, m_dbConnection);
                                grupaId = command.ExecuteScalar();
                            }
                            if (clubId == null)
                            {
                                query = "Select id FROM klub where nazwa like 'Brak danych'";
                                command = new SQLiteCommand(query, m_dbConnection);
                                clubId = command.ExecuteScalar();
                            }
                            if (stopienId == null)
                            {
                                query = "Select id FROM stopien where nazwa like 'Brak stopnia'";
                                command = new SQLiteCommand(query, m_dbConnection);
                                stopienId = command.ExecuteScalar();
                            }
                            int plec = 1;
                            if (imie.Length > 0)
                            {
                                if ((imie.ToLower())[imie.Length - 1] == 'a')
                                {
                                    plec = 2;
                                }
                            }
                            int czyDruzyna = 0;

                            //query = "INSERT INTO Uczestnik (Imie, Naziwsko, RokUrodzenia, Kata, Kumite, IdGrupa, IdKlub, Stopien) VALUES (@Imie, @Naziwsko, @RokUrodzenia, @Kata, @Kumite, @IdGrupa, @IdKlub, @Stopien)";
                            query = "INSERT INTO Uczestnik (Imie, Nazwisko, RokUrodzenia, Kata, Kumite, IdGrupaWiekowa, IdKlub, IdStopien, IdPlec, CzyDruzyna) VALUES ("
                            + "'" + imie + "',"
                            + "'" + nazwisko + "',"
                            + "" + rok + ","
                            + "" + kata + ","
                            + "" + kumite + ","
                            + "" + grupaId + ","
                            + "" + clubId + ","
                            + "" + stopienId + ","
                            + "" + plec + ","
                            + "" + czyDruzyna + ""
                            + ")";//@Imie, @Naziwsko, @RokUrodzenia, @Kata, @Kumite, @IdGrupa, @IdKlub, @Stopien)";
                            command = new SQLiteCommand(query, m_dbConnection);
                            command.ExecuteNonQuery();
                            //command.Parameters["Imie"] = new SQLiteParameter(imie;


                            int z = 0;
                            z++;
                        }
                        catch (Exception e)
                        {
                            int ee = 0;
                            ee++;
                        }

                    }
                    a++;
                }

            }
        }
        */

        
        /*
         SELECT DISTINCT Klub.id FROM KLUB JOIN Uczestnik ON Uczestnik.IdKlub = Klub.Id WHERE Uczestnik.IdGrupa = 1;

SELECT Klub.id FROM KLUB JOIN Uczestnik ON Uczestnik.IdKlub = Klub.Id WHERE Uczestnik.IdGrupa = 1;

SELECT Uczestnik.* FROM KLUB JOIN Uczestnik ON Uczestnik.IdKlub = Klub.Id WHERE Uczestnik.IdGrupa = 1;

SELECT DISTINCT Klub.id as ki FROM KLUB JOIN Uczestnik ON Uczestnik.IdKlub = Klub.Id WHERE Uczestnik.IdGrupa = 1;
         
          
          
SELECT Uczestnik.*, Grupa.Nazwa FROM Uczestnik 
JOIN UczestnikGrupa ON Uczestnik.Id = UczestnikGrupa.IdUczestnik 
JOIN Grupa ON Grupa.Id = UczestnikGrupa.IdGrupa



         */

        /*
        
SELECT grupa.id, Uczestnik.id, Uczestnik.Nazwisko, Uczestnik.Imie FROM GRUPA, uczestnik
JOIN GrupaWiekowa ON GrupaWiekowa.Id = Grupa.IdGrupaWiekowa
WHERE GrupaWiekowa.UrodzeniOd <= Uczestnik.RokUrodzenia AND Uczestnik.RokUrodzenia <= GrupaWiekowa.UrodzeniDo
AND Grupa.IdStopienOd <= Uczestnik.IdStopien  AND Uczestnik.IdStopien <= Grupa.IdStopienDo
AND ((Grupa.IdTypRywalizacji = 1 AND Uczestnik.Kumite = 1) OR (Grupa.IdTypRywalizacji = 2 AND Uczestnik.Kata = 1))
AND Uczestnik.CzyChlopiec = Grupa.CzyChlopcy
ORDER BY Uczestnik.Nazwisko;

SELECT GRUPA.*, GrupaWiekowa.Nazwa NazwaGrupyWiekowej, GrupaWiekowa.PelnaNazwa PelnaNazwaGrupyWiekowej, stod.Nazwa odstopnia, stdo.Nazwa dostopnia, TypRywalizacji.Nazwa nazwatypurywalizacji, GrupaWiekowa.UrodzeniOd, GrupaWiekowa.UrodzeniDo FROM Grupa
JOIN GrupaWiekowa ON GrupaWiekowa.Id = Grupa.IdGrupaWiekowa
JOIN Stopien stod ON stod.Id = Grupa.IdStopienoD
JOIN Stopien stdo ON stdo.Id = Grupa.IdStopienDo
JOIN TypRywalizacji ON TypRywalizacji.Id = Grupa.IdTypRywalizacji
WHERE rodzic is null and poziom = 0 ORDER BY Grupa.id;


SELECT Uczestnik.id from Uczestnik WHERE Uczestnik.id not in(
SELECT Uczestnik.id FROM GRUPA, uczestnik
JOIN GrupaWiekowa ON GrupaWiekowa.Id = Grupa.IdGrupaWiekowa
WHERE GrupaWiekowa.UrodzeniOd <= Uczestnik.RokUrodzenia AND Uczestnik.RokUrodzenia <= GrupaWiekowa.UrodzeniDo
AND Grupa.IdStopienOd <= Uczestnik.IdStopien  AND Uczestnik.IdStopien <= Grupa.IdStopienDo
AND ((Grupa.IdTypRywalizacji = 1 AND Uczestnik.Kumite = 1) OR (Grupa.IdTypRywalizacji = 2 AND Uczestnik.Kata = 1) OR (Grupa.IdTypRywalizacji = 3 AND Uczestnik.Kata = 1))
AND Uczestnik.CzyChlopiec = Grupa.CzyChlopcy
ORDER BY Uczestnik.Nazwisko
)*/

        public static String SplitIntoSubGroups(int minInSupgroup, String nazwaGrupy, int poziom, int typKonkurencji, Group parent, BackgroundWorker bw)
        {
            int idGrupa = parent.id;
            OpenConnection();
            //String query = "SELECT DISTINCT Klub.id as ki FROM KLUB JOIN Uczestnik ON Uczestnik.IdKlub = Klub.Id WHERE Uczestnik.IdGrupa = " + idGrupa;
            //String query = "SELECT DISTINCT Klub.id as ki FROM KLUB JOIN Uczestnik ON Uczestnik.IdKlub = Klub.Id WHERE Uczestnik.IdGrupa = " + idGrupa;
            String query = "SELECT DISTINCT Klub.id as ki FROM KLUB JOIN Uczestnik ON Uczestnik.IdKlub = Klub.Id JOIN UczestnikGrupa on Uczestnik.id = UczestnikGrupa.IdUczestnik WHERE UczestnikGrupa.IdPodgrupa IS NULL AND UczestnikGrupa.IdGrupa = " + idGrupa; 
            SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);
            ArrayList allClubs = new ArrayList();
            ArrayList allSubsets = new ArrayList();
            ArrayList subset = new ArrayList();
            int elementsCount = 0;
            try
            {
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String idKlub = (String)reader["ki"].ToString();
                    //String query2 = "SELECT id FROM Uczestnik WHERE Uczestnik.IdKlub = " + idKlub + " and Uczestnik.IdGrupa = " + idGrupa;
                    String query2 = "SELECT Uczestnik.id FROM Uczestnik JOIN UczestnikGrupa ON UczestnikGrupa.IdUczestnik = Uczestnik.Id WHERE Uczestnik.IdKlub = " + idKlub + " AND UczestnikGrupa.IdGrupa = " + idGrupa + " AND UczestnikGrupa.IdPodgrupa IS null AND UczestnikGrupa.Poziom = " + poziom;
                    SQLiteCommand command2 = new SQLiteCommand(query2, m_dbConnection);
                    SQLiteDataReader reader2 = command2.ExecuteReader();
                    ArrayList club = new ArrayList();
                    while (reader2.Read())
                    {
                        club.Add(reader2["id"]);
                        elementsCount++;
                    }
                    allClubs.Add(club);
                }

                //brak uczestników w tej grupie - nie ma czego dzielić :-)
                if (isAllEmpty(allClubs))
                    return null;

                while (!isAllEmpty(allClubs))
                {
                    if (subset.Count >= minInSupgroup)
                    {
                        allSubsets.Add(subset);
                        subset = new ArrayList();
                    }
                    int groupId = r.Next(allClubs.Count);
                    while (((ArrayList)allClubs[groupId]).Count == 0)
                    {
                        groupId = r.Next(allClubs.Count);
                    }
                    ArrayList helperAL = (ArrayList)allClubs[groupId];
                    String idHelper = (String)helperAL[0].ToString();
                    helperAL.RemoveAt(0);
                    subset.Add(idHelper);
                    if (helperAL.Count == 0)
                        allClubs.Remove(helperAL);
                }
                if (subset.Count >= minInSupgroup || allSubsets.Count == 0)
                    allSubsets.Add(subset);
                else
                {
                    int index = 0;
                    for (int a = 0; a < subset.Count; a++)
                    {
                        ArrayList alHelper = (ArrayList)allSubsets[index];
                        String stringHelper = subset[a].ToString();
                        alHelper.Add(stringHelper);
                        index++;
                        if (index >= allSubsets.Count)
                            index = 0;
                    }
                }
                for (int a = 0; a < allSubsets.Count; a++)
                {
                    Group g = parent;

                    String artificialGroupName = "" + (a + 1);
                    if (artificialGroupName.Length < 2)
                        artificialGroupName = "0" + artificialGroupName;

                    query = "INSERT INTO GRUPA (Nazwa, Opis, Rodzic,Poziom,IdGrupaWiekowa,IdStopienOd,IdStopienDo,IdTypRywalizacji,IdPlec,CzyDruzynowa) VALUES "
                                          + "('" + nazwaGrupy + "" + artificialGroupName + "', ''," + g.id + "," + poziom + "," + g.IdGrupaWiekowa + "," + g.IdStopienOd + "," + g.IdStopienDo + "," + g.IdTypRywalizacji + "," + g.IdPlec + "," + g.CzyDruzynowa + ")";

                    //query = "INSERT INTO Grupa(nazwa, rodzic, poziom, typkonkurencji) VALUES ('" + nazwaGrupy + "_" + a + "'," + idGrupa + "," + poziom + "," + typKonkurencji + ")";
                    command = new SQLiteCommand(query, m_dbConnection);
                    command.ExecuteNonQuery();
                    String lastId = getLastId();

                    subset = (ArrayList)allSubsets[a];
                    for (int b = 0; b < subset.Count; b++)
                    {
                        String idUser = (String)subset[b].ToString();

                        /*query = "DELETE FROM UczestnikGrupa WHERE idUczestnik = " + idUser + " AND poziom = " + poziom;
                        command = new SQLiteCommand(query, m_dbConnection);
                        command.ExecuteNonQuery();
                        */
                        query = "UPDATE UczestnikGrupa SET idPodgrupa = " + lastId + " WHERE IdUczestnik = " + idUser + " AND Poziom = " + poziom + " AND IdGrupa = " + g.id;
                        command = new SQLiteCommand(query, m_dbConnection);
                        command.ExecuteNonQuery();
                    }

                    int zz = 0;
                    zz++;

                    bw.ReportProgress((a * 100) / allSubsets.Count);
                }
                int aa = 0;
                aa++;
            }
            catch (Exception ex)
            {
                return "Błąd podziału na podgrupy, wyjątek: " + ex.Message;
            }

            bw.ReportProgress(0);

            return null;
        }


        public static String SplitIntoSubGroups(int maxGroups, int poziom, int typKonkurencji, String groupName, Group parent, BackgroundWorker bw)
        {
            int idGrupa = parent.id;
            OpenConnection();
            //String query = "SELECT DISTINCT Klub.id as ki FROM KLUB JOIN Uczestnik ON Uczestnik.IdKlub = Klub.Id WHERE Uczestnik.IdGrupa = " + idGrupa;
            //String query = "SELECT DISTINCT Klub.id as ki FROM KLUB JOIN Uczestnik ON Uczestnik.IdKlub = Klub.Id WHERE Uczestnik.IdGrupa = " + idGrupa;
            String query = "SELECT DISTINCT Klub.id as ki FROM KLUB JOIN Uczestnik ON Uczestnik.IdKlub = Klub.Id JOIN UczestnikGrupa on Uczestnik.id = UczestnikGrupa.IdUczestnik WHERE UczestnikGrupa.IdPodgrupa IS NULL AND UczestnikGrupa.IdGrupa = " + idGrupa;
            SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);
            ArrayList allClubs = new ArrayList();
            ArrayList allSubsets = new ArrayList();
            ArrayList subset = new ArrayList();
            int elementsCount = 0;
            try
            {
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String idKlub = (String)reader["ki"].ToString();
                    //String query2 = "SELECT id FROM Uczestnik WHERE Uczestnik.IdKlub = " + idKlub + " and Uczestnik.IdGrupa = " + idGrupa;
                    String query2 = "SELECT Uczestnik.id FROM Uczestnik JOIN UczestnikGrupa ON UczestnikGrupa.IdUczestnik = Uczestnik.Id WHERE Uczestnik.IdKlub = " + idKlub + " AND UczestnikGrupa.IdGrupa = " + idGrupa + " AND UczestnikGrupa.IdPodgrupa IS null AND UczestnikGrupa.Poziom = " + poziom;
                    SQLiteCommand command2 = new SQLiteCommand(query2, m_dbConnection);
                    SQLiteDataReader reader2 = command2.ExecuteReader();
                    ArrayList club = new ArrayList();
                    while (reader2.Read())
                    {
                        club.Add(reader2["id"]);
                        elementsCount++;
                    }
                    allClubs.Add(club);
                }

                //brak uczestników w tej grupie - nie ma czego dzielić :-)
                if (isAllEmpty(allClubs))
                    return null;

                for (int a = 0; a < maxGroups; a++)
                {
                    subset = new ArrayList();
                    allSubsets.Add(subset);
                }

                int groupNumber = 0;
                while (!isAllEmpty(allClubs))
                {
                    subset = (ArrayList)allSubsets[groupNumber];
                    /*
                    if (subset.Count <= maxGroups)
                    {
                        allSubsets.Add(subset);
                        subset = new ArrayList();
                    }*/
                    int groupId = r.Next(allClubs.Count);
                    while (((ArrayList)allClubs[groupId]).Count == 0)
                    {
                        groupId = r.Next(allClubs.Count);
                    }
                    ArrayList helperAL = (ArrayList)allClubs[groupId];
                    String idHelper = (String)helperAL[0].ToString();
                    helperAL.RemoveAt(0);
                    subset.Add(idHelper);
                    if (helperAL.Count == 0)
                        allClubs.Remove(helperAL);
                    groupNumber++;
                    if (groupNumber >= maxGroups)
                        groupNumber = 0;
                }
                /*if (subset.Count >= minInSupgroup || allSubsets.Count == 0)
                    allSubsets.Add(subset);
                else
                {
                    int index = 0;
                    for (int a = 0; a < subset.Count; a++)
                    {
                        ArrayList alHelper = (ArrayList)allSubsets[index];
                        String stringHelper = subset[a].ToString();
                        alHelper.Add(stringHelper);
                        index++;
                        if (index >= allSubsets.Count)
                            index = 0;
                    }
                }*/
                for (int a = 0; a < allSubsets.Count; a++)
                {
                    Group g = parent;

                    String artificialGroupName = "" + (a + 1);
                    if (artificialGroupName.Length < 2)
                        artificialGroupName = "0" + artificialGroupName;

                    query = "INSERT INTO GRUPA (Nazwa, Opis, Rodzic,Poziom,IdGrupaWiekowa,IdStopienOd,IdStopienDo,IdTypRywalizacji,IdPlec,CzyDruzynowa) VALUES "
                                          + "('" + groupName + artificialGroupName + "', ''," + g.id + "," + poziom + "," + g.IdGrupaWiekowa + "," + g.IdStopienOd + "," + g.IdStopienDo + "," + g.IdTypRywalizacji + "," + g.IdPlec + "," + g.CzyDruzynowa + ")";

                    //query = "INSERT INTO Grupa(nazwa, rodzic, poziom, typkonkurencji) VALUES ('" + nazwaGrupy + "_" + a + "'," + idGrupa + "," + poziom + "," + typKonkurencji + ")";
                    command = new SQLiteCommand(query, m_dbConnection);
                    command.ExecuteNonQuery();
                    String lastId = getLastId();

                    subset = (ArrayList)allSubsets[a];
                    for (int b = 0; b < subset.Count; b++)
                    {
                        String idUser = (String)subset[b].ToString();

                        /*query = "DELETE FROM UczestnikGrupa WHERE idUczestnik = " + idUser + " AND poziom = " + poziom;
                        command = new SQLiteCommand(query, m_dbConnection);
                        command.ExecuteNonQuery();
                        */
                        query = "UPDATE UczestnikGrupa SET idPodgrupa = " + lastId + " WHERE IdUczestnik = " + idUser + " AND Poziom = " + poziom + " AND IdGrupa = " + g.id;
                        command = new SQLiteCommand(query, m_dbConnection);
                        command.ExecuteNonQuery();
                    }

                    if (bw != null)
                        bw.ReportProgress((a * 100) / allSubsets.Count);
                }
                int aa = 0;
                aa++;
            }
            catch (Exception ex)
            {
                return "Błąd podziału na podgrupy, wyjątek: " + ex.Message;
            }

            if (bw != null)
                bw.ReportProgress(0);

            return null;
        }

        public static void RemoveUserFromGroup(int idPodgrupa, int idUser, int level)
        {
            OpenConnection();
            string sql = "UPDATE UczestnikGrupa SET IdPodgrupa = NULL WHERE IdPodgrupa = " + idPodgrupa + " AND idUczestnik = " + idUser + " AND poziom = " + level;
            //if (idGrupa < 0)
            //  sql = "UPDATE UczestnikGrupa SET IdGrupa = NULL WHERE idGrupa = " + idGrupa + " AND idUczestnik = " + idUser + " AND poziom = " + level;
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            cmd.ExecuteNonQuery();
        }

        public static void AddUserToGroup(int idPodgrupa, int idGrupa, int idUser, int level)
        {
            OpenConnection();
            string sql = "UPDATE UczestnikGrupa SET IdPodgrupa = " + idPodgrupa + " WHERE idUczestnik = " + idUser + " AND poziom = " + level + " AND idGrupa = " + idGrupa;
            //if (idGrupa < 0)
              //  sql = "UPDATE UczestnikGrupa SET IdGrupa = NULL WHERE idGrupa = " + idGrupa + " AND idUczestnik = " + idUser + " AND poziom = " + level;
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            cmd.ExecuteNonQuery();
        }

        public static String getLastId()
        {
            OpenConnection();
            string sql = "SELECT last_insert_rowid()";
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            return (String)cmd.ExecuteScalar().ToString();
        }

        private static bool isAllEmpty(ArrayList allClubs)
        {
            for (int a = 0; a < allClubs.Count; a++)
            {
                if (((ArrayList)allClubs[a]).Count > 0)
                    return false;
            }
            return true;
        }

    }
}
