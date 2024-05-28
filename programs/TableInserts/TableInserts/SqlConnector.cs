using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableInserts
{
    internal class SqlConnector
    {
        private SQLiteConnection connection;

        public SqlConnector(string databasePath)
        {
            if (System.IO.File.Exists(databasePath))
            {
                connection = new SQLiteConnection($"Data Source={databasePath}");
                try
                {
                    connection.Open();
                }
                catch
                {
                    Console.WriteLine("Az adatbázishoz való kapcsolódás sikertelen");
                }

            }
            else
            {
                Console.WriteLine("Az adatbázis nem található");
                Environment.Exit(1);
            }
        }

        public void getMoviedata(ref List<int> movieID, ref List<string> moviekw, ref List<string> movielanguage,
            ref List<string> moviedirector, ref List<string> moviecountry, ref List<string> moviegenre)
        {
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();
            
            command.CommandText = "SELECT * FROM Movies";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                movieID.Add(Convert.ToInt32(reader["ID"]));
                moviekw.Add(string.Format("{0}", reader["Keywords"]));
                movielanguage.Add(string.Format("{0}", reader["Language"]));
                moviedirector.Add(string.Format("{0}", reader["Director"]));
                moviecountry.Add(string.Format("{0}", reader["Production_countries"]));
                moviegenre.Add(string.Format("{0}", reader["Genre"]));
            }
            reader.Close();
        }

        public void keywordPrepare(ref List<string> keywords)
        {
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Movies";
            reader = command.ExecuteReader();
            string tmp;
            string[] parts;
            while (reader.Read())
            {
                tmp=string.Format("{0}", reader["Keywords"]);
                parts = tmp.Split(',');
                for (int i = 0; i < parts.Length; i++)
                {
                    keywords.Add(parts[i]);
                }
                
            }
            reader.Close();
            removeWhitespace(ref keywords);
        }

        public void languagePrepare(ref List<string> language)
        {
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Movies";
            reader = command.ExecuteReader();
            string tmp;
            string[] parts;
            while (reader.Read())
            {
                tmp = string.Format("{0}", reader["Language"]);
                parts = tmp.Split(',');
                for (int i = 0; i < parts.Length; i++)
                {
                    language.Add(parts[i]);
                }

            }
            reader.Close();
            removeWhitespace(ref language);
        }

        public void directorPrepare(ref List<string> director)
        {
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Movies";
            reader = command.ExecuteReader();
            string tmp;
            string[] parts;
            while (reader.Read())
            {
                tmp = string.Format("{0}", reader["Director"]);
                parts = tmp.Split(',');
                for (int i = 0; i < parts.Length; i++)
                {
                    director.Add(parts[i]);
                }

            }
            reader.Close();
            removeWhitespace(ref director);
        }

        public void countryPrepare(ref List<string> country)
        {
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Movies";
            reader = command.ExecuteReader();
            string tmp;
            string[] parts;
            while (reader.Read())
            {
                tmp = string.Format("{0}", reader["Production_countries"]);
                parts = tmp.Split(',');
                for (int i = 0; i < parts.Length; i++)
                {
                    country.Add(parts[i]);
                }

            }
            reader.Close();
            removeWhitespace(ref country);
        }

        public void genrePrepare(ref List<string> genre)
        {
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Movies";
            reader = command.ExecuteReader();
            string tmp;
            string[] parts;
            while (reader.Read())
            {
                tmp = string.Format("{0}", reader["Genre"]);
                parts = tmp.Split(',');
                for (int i = 0; i < parts.Length; i++)
                {
                    genre.Add(parts[i]);
                }

            }
            reader.Close();
            removeWhitespace(ref genre);
        }

        static void removeWhitespace(ref List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].StartsWith(" "))
                {
                    list[i] = list[i].Substring(1);
                }
            }
        }
        public void DbWrite(List<string> cmds)
        {
            SQLiteCommand command = connection.CreateCommand();
            for (int i = 0; i < cmds.Count; i++)
            {
                command.CommandText = cmds[i];
                command.ExecuteNonQuery();
            }
        }
    }
}
