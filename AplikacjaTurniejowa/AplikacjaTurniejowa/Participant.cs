using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace AplikacjaTurniejowa
{
    public class Participant
    {
        public int id = 0;
        public String name = "";
        public String surname = "";
        public int dateOfBirth = 0;
        public bool kata = false;
        public bool kumite = false;
        public bool kihon = false;
        //public int idgrupa = 0;
        public int idklub = 0;
        public String datausuniecia = "";
        public int stopien = 0;
        public String nazwaGrupy = "";
        public String nazwaKlubu = "";
        public String nazwaStopinia = "";
        public int idGrupa = -1;
        public int idPodgrupa = -1;

        

        public Participant() { }
        public Participant(SQLiteDataReader reader) {
            id = int.Parse(reader["id"].ToString());
            name = reader["imie"].ToString();
            surname = reader["nazwisko"].ToString();
            dateOfBirth = int.Parse(reader["rokurodzenia"].ToString());
            kata = bool.Parse(reader["kata"].ToString().ToString());
            kumite = bool.Parse(reader["kumite"].ToString().ToString());
            kihon = bool.Parse(reader["kihon"].ToString().ToString());
            //idgrupa = int.Parse(reader["idgrupa"].ToString().ToString());
            idklub = int.Parse(reader["idklub"].ToString().ToString());
            datausuniecia = reader["datausuniecia"].ToString().ToString();
            stopien = int.Parse(reader["idstopien"].ToString().ToString());

            //nazwaGrupy = reader["nazwaGrupy"].ToString();
            nazwaKlubu = reader["nazwaKlubu"].ToString();
            nazwaStopinia = reader["nazwaStopinia"].ToString();
            try
            {
                idGrupa = int.Parse(reader["glownaGrupa"].ToString());
            }
            catch (Exception e)
            {
                int zz = 0;
                zz++;
            }
            try
            {
                String aaaa = reader["podgrupa"].ToString();
                idPodgrupa = int.Parse(reader["podgrupa"].ToString());
            }
            catch (Exception e)
            {
                int zz = 0;
                zz++;
            }
        }
        public String GenerateTooltipText()
        {
            String text = "";
            text += "Imie: " + name;
            text += "\r\nNazwisko: " + surname;
            text += "\r\nStopień: " + nazwaStopinia;
            text += "\r\nData urodzenia: " + dateOfBirth;
            text += "\r\nKlub: " + nazwaKlubu;
            text += "\r\nGrupa: " + nazwaGrupy;
            text += "\r\nKata: " + kata;
            text += "\r\nKumite: " + kumite;
            text += "\r\nKihon: " + kihon;
            text += "\r\n**DEBUG**\r\n(id, idGrupa, idPodgrupa): (" + id + ", " + idGrupa + ", " + idPodgrupa + ")";
            return text;

        }
    }
}
