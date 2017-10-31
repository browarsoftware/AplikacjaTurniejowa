using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Collections;

namespace AplikacjaTurniejowa
{
    class HTMLPrinter
    {
        public static int AdditionalPepopleInGroup = 5;

        public static void SaveToFile(String path, int groupId)
        {
            SQLiteConnection connection = Utils.getConnection();
            String sql = "";
            if (groupId > 0)
                sql = "SELECT Q1.GI, COUNT(PI) FROM (SELECT DISTINCT  Grupa.Id GI, ifnull(UczestnikGrupa.IdPodgrupa, 0) PI FROM Grupa JOIN UczestnikGrupa ON UczestnikGrupa.IdGrupa = Grupa.Id WHERE UczestnikGrupa.Poziom = 1 AND UczestnikGrupa.IdPodgrupa IS NOT NULL) Q1 WHERE Q1.GI = " + groupId + " GROUP BY Q1.GI;";
            else
                sql = "SELECT Q1.GI, COUNT(PI) FROM (SELECT DISTINCT  Grupa.Id GI, ifnull(UczestnikGrupa.IdPodgrupa, 0) PI FROM Grupa JOIN UczestnikGrupa ON UczestnikGrupa.IdGrupa = Grupa.Id WHERE UczestnikGrupa.Poziom = 1 AND UczestnikGrupa.IdPodgrupa IS NOT NULL) Q1 GROUP BY Q1.GI;";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            String html = "";
            html = "<html>"
            + "<head>"
            + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />"
            + "<title>Ogólnopolski Puchar Krakowa w Karate Tradycyjnym</title>"
            + "<link href=\"styl.css\" rel=\"stylesheet\" type=\"text/css\" />"
            + "</head>"
            + "<body><center>";

            while (reader.Read())
            {
                String id = reader["GI"].ToString();
                html += DodajGrupeIPodgrupy(id);
            }

            html += "</center>"
            + "</body>";
            //String path = "e:\\Projects\\Karate\\print\\test.html";
            File.WriteAllText(path, html);
        }

        private static String DodajGrupeIPodgrupy(String id)
        {
            String html = "";
            String sql = "SELECT GRUPA.*, GrupaWiekowa.Nazwa NazwaGrupyWiekowej, GrupaWiekowa.PelnaNazwa PelnaNazwaGrupyWiekowej, stod.Nazwa odstopnia, stod.Id odstopniaid, stdo.Nazwa dostopnia, stdo.id dostopniaid, TypRywalizacji.Nazwa nazwatypurywalizacji, GrupaWiekowa.UrodzeniOd, GrupaWiekowa.UrodzeniDo, plec.opis plecnazwa FROM Grupa "
                        + "JOIN GrupaWiekowa ON GrupaWiekowa.Id = Grupa.IdGrupaWiekowa "
                        + "JOIN Stopien stod ON stod.Id = Grupa.IdStopienOd "
                        + "JOIN Stopien stdo ON stdo.Id = Grupa.IdStopienDo "
                        + "JOIN Plec ON plec.Id = Grupa.IdPlec "
                        + "JOIN TypRywalizacji ON TypRywalizacji.Id = Grupa.IdTypRywalizacji "
                        + "WHERE Grupa.id = " + id;
            SQLiteConnection connection = Utils.getConnection();
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            Group g = new Group(reader);

            sql = "SELECT Q1.GI, COUNT(PI) pc FROM "
            + "(SELECT DISTINCT  Grupa.Id GI, ifnull(UczestnikGrupa.IdPodgrupa, 0) PI FROM Grupa "
            + "JOIN UczestnikGrupa ON UczestnikGrupa.IdGrupa = Grupa.Id "
            + "WHERE UczestnikGrupa.Poziom = 1 AND UczestnikGrupa.IdPodgrupa IS NOT NULL) Q1 "
            + "WHERE GI = " + id + " "
            + "GROUP BY Q1.GI";
            command = new SQLiteCommand(sql, connection);
            reader = command.ExecuteReader();
            int count = int.Parse(reader["pc"].ToString());

            html += "<h2>Lista zawodników</h2>"
            + "<h1>GR. " + g.name + "</h1><br>"
            + "Ilość podgrup w grupie: <b>" + count + "</b>"
            + "<table class=\"t1\" summary=\"" + g.name +"\">"
            + "<caption>" + g.name + "</caption>"
            + "<thead>"
            + "<tr><th>Lp.</th><th>Nazwisko i imię</th><th>Wynik</th><th>Klub</th><th>Podgrupa</th></tr>"
            + "</thead>"
            + "<tfoot>"
            + "<tr><th colspan=\"5\"></th></tr>"
            + "</tfoot>"
            + "<tbody>";

            sql = "SELECT Imie, Nazwisko, Klub.Nazwa klubnazwa, Grupa.Nazwa podgrupa, UczestnikGrupa.IdPodgrupa podgrupaid FROM Uczestnik "
            + "JOIN UczestnikGrupa ON Uczestnik.Id = UczestnikGrupa.IdUczestnik "
            + "JOIN Klub ON Klub.Id = Uczestnik.IdKlub "
            + "JOIN Grupa ON Grupa.Id = UczestnikGrupa.IdPodgrupa "
            + "WHERE UczestnikGrupa.Poziom = 1 AND UczestnikGrupa.IdGrupa = " + id + " "
            + "ORDER BY klubnazwa, Nazwisko, Imie";

            command = new SQLiteCommand(sql, connection);
            reader = command.ExecuteReader();
            int a = 1;
            while (reader.Read())
            {
                html += "<tr><th>" + a + "</th><td>" + reader["imie"].ToString() + " " + reader["nazwisko"].ToString() + "</td><td></td><td>" + reader["klubnazwa"].ToString() + "</td><td>" + reader["podgrupa"].ToString() + "</td></tr>";
                a++;
            }

            for (int b = 0; b < AdditionalPepopleInGroup; b++)
            {
                html += "<tr><th>" + a + "</th><td>" + "" + " " + "" + "</td><td></td><td>" + "" + "</td><td>" + "" + "</td></tr>";
                a++;
            }

            html += "</tbody>"
            + "</table>"
            + "<br>"
            + "<table class=\"t1\">"
            + "<thead>"
            + "<tr><th>Czas</th><th></th></tr>"
            + "</thead>"
            + "<tfoot>"
            + "<tr><th colspan=\"4\"></th></tr>"
            + "</tfoot>"
            + "<tbody>"
            + "<tr><th>GODZINA ROZPOCZĘCIA STARCIA W GRUPIE:</th><td>_____:_____</td></tr>"
            + "<tr><th>GODZINA ZAKOŃCZENIA STARCIA W GRUPIE:</th><td>_____:_____</td></tr>"
            + "</tbody>"
            + "</table>";

            html += "<h5></h5>";

            html += DodajPodgrupy(id, g.name);

            return html;
        }

        private static String DodajPodgrupy(String id, String glownaGrupaNazwa)
        {
            String html = "";
            SQLiteConnection connection = Utils.getConnection();
            String sql = "SELECT DISTINCT UczestnikGrupa.IdPodgrupa, Grupa.Nazwa FROM UczestnikGrupa "
            + "JOIN Grupa ON Grupa.Id = UczestnikGrupa.IdPodgrupa "
            + "WHERE UczestnikGrupa.Poziom = 1 AND UczestnikGrupa.IdGrupa = " + id + " "
            + "ORDER BY Grupa.Nazwa";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();






            int a = 0;
            while (reader.Read())
            {
                String idPodgrupa = reader["idPodgrupa"].ToString();
                String nazwa = reader["Nazwa"].ToString();


                String sql3 = "SELECT count(UczestnikGrupa.Id) FROM UczestnikGrupa WHERE UczestnikGrupa.Poziom = 1 AND UczestnikGrupa.IdPodgrupa = " + idPodgrupa;
                SQLiteCommand command3 = new SQLiteCommand(sql3, connection);
                int count = int.Parse(command3.ExecuteScalar().ToString());
                //1 dodatkowe pole na zapas
                count++;


                html += "<h2>Podział na podgrupy w grupie</h2> "
                + "<h1>Podgrupa " + nazwa + "</h1><br> "
                + "<table class=\"t1\" summary=\"" + nazwa + "\">"
                + "<caption>" + glownaGrupaNazwa + "</caption> "
                + "<thead>"
                + "<tr><th>Lp.</th><th>Pojedynek</th><th>Wynik (chorągiewki)</th></tr>"
                + "</thead>"
                + "<tfoot>"
                + "<tr><th colspan=\"4\"></th></tr>"
                + "</tfoot>"
                + "<tbody>";
                int cc = 1;

                ArrayList pairsAl = new ArrayList();
                ArrayList pairsAlGoodOrder = new ArrayList();
                
                for (int i = 1; i <= count; i++)
                    for (int j = i + 1; j <= count; j++)
                    {
                        int[] ap = new int[2];
                        ap[0] = i;
                        ap[1] = j;
                        pairsAl.Add(ap);
                    }

                int[] lastSelected = (int[])pairsAl[0];
                pairsAl.RemoveAt(0);
                //pairsAlGoodOrder.Add(lastSelected);

                int selectMe = -1;
                do
                {
                    pairsAl.Remove(lastSelected);
                    html += "<tr><th>" + cc + " </th><th>" + lastSelected[0] + " - <font color=\"red\">" + lastSelected[1] + "</font></th><td>( _______  - _______ )</td></tr>";
                    if (pairsAl.Count > 0)
                    {
                        cc++;
                        
                        int iterationsCount = -1;
                        int[] actualSelected = null;
                        do
                        {
                            iterationsCount++;
                            selectMe++;
                            if (selectMe >= pairsAl.Count)
                                selectMe = 0;
                            if (selectMe < pairsAl.Count)
                                actualSelected = (int[])pairsAl[selectMe];
                        }
                        //while ((lastSelected[0] == actualSelected[0] || lastSelected[1] == actualSelected[1] || lastSelected[1] == actualSelected[0] || lastSelected[0] == actualSelected[1]) && selectMe < pairsAl.Count);
                        while ((lastSelected[0] == actualSelected[0] || lastSelected[1] == actualSelected[1] || lastSelected[1] == actualSelected[0] || lastSelected[0] == actualSelected[1]) && iterationsCount < pairsAl.Count);
                        lastSelected = actualSelected;
                    }
                }
                while (pairsAl.Count > 0);

                /*
                for (int i = 1; i <= count; i++)
                    for (int j = i + 1; j <= count; j++)
                    {
                        html += "<tr><th>" + cc + " </th><th><font color=\"red\">" + i + "</font> - " + j + "</th><td>( _______  - _______ )</td></tr>";
                        cc++;
                    }*/
                html += "</tr>"
                + "</tbody>"
                + "</table>";


                html += "<br>"
                + "<table class=\"t1\">"
                + "<caption>" + glownaGrupaNazwa + "</caption>"
                + "<thead>"
                + "<tr><th>Lp.</th><th>Nazwisko i imię</th><th>Wynik w rozgrywkach</th><th>Wynik z chorągiewek</th></tr>"
                + "</thead>"
                + "<tfoot>"
                + "<tr><th colspan=\"4\"></th></tr>"
                + "</tfoot>"
                + "<tbody>";


                String sql2 = "SELECT Imie, Nazwisko, Klub.Nazwa, Grupa.Nazwa FROM Uczestnik "
                + "JOIN UczestnikGrupa ON Uczestnik.Id = UczestnikGrupa.IdUczestnik "
                + "JOIN Klub ON Klub.Id = Uczestnik.IdKlub "
                + "JOIN Grupa ON Grupa.Id = UczestnikGrupa.IdPodgrupa "
                + "WHERE UczestnikGrupa.Poziom = 1 AND UczestnikGrupa.IdPodgrupa = " + idPodgrupa;

                SQLiteCommand command2 = new SQLiteCommand(sql2, connection);
                SQLiteDataReader reader2 = command2.ExecuteReader();

                cc = 1;
                while (reader2.Read())
                {
                    html += "<tr><th>" + cc + "</th><td>" + reader2["imie"].ToString() + " " + reader2["nazwisko"].ToString() + " </td><td>[__] [__] [__] [__] [__]</td><td></td></tr>";
                    cc++;
                }

                html += "<tr><th>" + cc + "</th><td>" + "" + " " + "" + " </td><td>[__] [__] [__] [__] [__]</td><td></td></tr>";
                cc++;

                html += "</tbody>"
                + "</table>"
                + "<br>"
                + "<table class=\"t1\">"
                + "<caption>Awans do fazy pucharowej</caption>"
                + "<thead>"
                + " <tr><th>Pozycja</th><th>Nazwisko i imię</th></tr>"
                + "</thead>"
                + "<tfoot>"
                + "<tr><th colspan=\"4\"></th></tr>"
                + "</tfoot>"
                + "<tbody>"
                + "<tr><th>I</th><td>________________________________</td></tr>"
                + "<tr><th>II</th><td>________________________________</td></tr>"
                + "</tbody>"
                + "</table>"
                + "<h5></h5>";
            }
            return html;
        }

        
            /*
             
SELECT Grupa.Id, COUNT(UczestnikGrupa.Id) iluUczestnikow FROM Grupa
JOIN UczestnikGrupa ON UczestnikGrupa.IdGrupa = Grupa.Id
WHERE UczestnikGrupa.Poziom = 1 AND UczestnikGrupa.IdPodgrupa IS NOT NULL
GROUP BY Grupa.Id;

SELECT Q1.GI, COUNT(PI) FROM 
(SELECT DISTINCT  Grupa.Id GI, ifnull(UczestnikGrupa.IdPodgrupa, 0) PI FROM Grupa
JOIN UczestnikGrupa ON UczestnikGrupa.IdGrupa = Grupa.Id
WHERE UczestnikGrupa.Poziom = 1 AND UczestnikGrupa.IdPodgrupa IS NOT NULL) Q1
GROUP BY Q1.GI;


SELECT Imie, Nazwisko, Klub.Nazwa, Grupa.Nazwa, UczestnikGrupa.IdPodgrupa FROM Uczestnik
JOIN UczestnikGrupa ON Uczestnik.Id = UczestnikGrupa.IdUczestnik 
JOIN Klub ON Klub.Id = Uczestnik.IdKlub
JOIN Grupa ON Grupa.Id = UczestnikGrupa.IdPodgrupa
WHERE UczestnikGrupa.Poziom = 1 AND UczestnikGrupa.IdGrupa = 53;



SELECT Imie, Nazwisko, Klub.Nazwa, Grupa.Nazwa FROM Uczestnik
JOIN UczestnikGrupa ON Uczestnik.Id = UczestnikGrupa.IdUczestnik 
JOIN Klub ON Klub.Id = Uczestnik.IdKlub
JOIN Grupa ON Grupa.Id = UczestnikGrupa.IdPodgrupa
WHERE UczestnikGrupa.Poziom = 1 AND UczestnikGrupa.IdPodgrupa = 142;
              
             */

    }
}
