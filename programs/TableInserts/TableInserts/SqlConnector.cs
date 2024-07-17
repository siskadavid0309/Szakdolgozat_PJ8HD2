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
                    Console.WriteLine("Failed to connect to the database");
                }

            }
            else
            {
                Console.WriteLine("Database not found");
                Environment.Exit(1);
            }
        }

        public List<Movie> CollectMovie()
        {
            List<Movie> movies = new List<Movie>();
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Movies";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Movie movie = new Movie
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Keywords = reader["Keywords"].ToString(),
                    Language = reader["Language"].ToString(),
                    Director = reader["Director"].ToString(),
                    Country = reader["Production_countries"].ToString(),
                    Genre = reader["Genre"].ToString()
                };
                movies.Add(movie);
            }
            reader.Close();

            return movies;
        }

        public List<string> PrepareKeywords()
        {
            List<string> keywords = new List<string>();
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
            RemoveWhitespace(ref keywords);

            return keywords;
        }

        public List<string> PrepareLanguages()
        {
            List<string> language= new List<string>();
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
            RemoveWhitespace(ref language);

            return language;
        }

        public List<string> PrepareDirectors()
        {
            List<string> director= new List<string>();
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
            RemoveWhitespace(ref director);

            return director;
        }

        public List<string> PrepareCountries()
        {
            List<string> country= new List<string>();
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
            RemoveWhitespace(ref country);

            return country;
        }

        public List<string> PrepareGenres()
        {
            List<string> genre = new List<string>();
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
            RemoveWhitespace(ref genre);

            return genre;
        }

        static void RemoveWhitespace(ref List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].StartsWith(" "))
                {
                    list[i] = list[i].Substring(1);
                }
            }
        }
        public void ExecuteInserts(List<string> cmds)
        {
            SQLiteCommand command = connection.CreateCommand();
            try
            {
                for (int i = 0; i < cmds.Count; i++)
                {
                    command.CommandText = cmds[i];
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                Console.WriteLine("An error occurred during table upload");
            }
        }
    }
}
