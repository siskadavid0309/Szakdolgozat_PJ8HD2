
using MovieRecommendationSystem;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRecommendation
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
                    MessageBox.Show("Az adatbázishoz való kapcsolódás sikertelen", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Az adatbázis nem található", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        public List<Movie> collectMovie()
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
                    Title = reader["Title"].ToString(),
                    Released = Convert.ToInt32(reader["Released"]),
                    Runtime = Convert.ToInt32(reader["Runtime"]),
                    GenderOfProtagonist = Convert.ToInt32(reader["Gender_of_the_protagonist"]),
                    MainActor = reader["Main_actor"].ToString(),
                    TmdbScore = Convert.ToDouble(reader["Tmdb_score"]),
                    NumberOfRatings = Convert.ToInt32(reader["Number_of_ratings"]),
                    Popularity = Convert.ToDouble(reader["Popularity"]),
                    Budget = Convert.ToInt64(reader["Budget"]),
                    Revenue = Convert.ToInt64(reader["Revenue"]),

                    /*
                    Keywords = reader["Keywords"].ToString(),
                    Language = reader["Language"].ToString(),
                    Director = reader["Director"].ToString(),
                    Country = reader["Production_countries"].ToString(),
                    Genre = reader["Genre"].ToString()
                    */
                };
                movies.Add(movie);
            }
            reader.Close();

            return movies;
        }

        /// <summary>
        /// A korábbiakban feltöltött Id adattag és a Movies_Genres kapcsolótábla segítségével a Genre adattag feltöltésre kerül, itt még a műfajokat azonosító integerekkel
        /// </summary>
        /// <param name="movies">A movies listában tároljuk el a filmek műfajait</param>
        public void FillupGenre(ref List<Movie> movies)
        
        {

            int index;
            int data;
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();
            
            command.CommandText = "SELECT * FROM Movies_Genres";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                index = Convert.ToInt32(reader["Movie_ID"]);
                data = Convert.ToInt32(reader["Genres_ID"]);
                for (int i = 0; i < movies.Count; i++)
                {
                    if (movies[i].Id == index)
                    {
                        movies[i].Genre.Add(data);
                    }
                }
            }
            reader.Close();
        }

        public void FillupKeywords(ref List<Movie> movies)
        {
            int index;
            int data;
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Movies_Keywords";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                index = Convert.ToInt32(reader["Movie_ID"]);
                data = Convert.ToInt32(reader["Keywords_ID"]);
                for (int i = 0; i < movies.Count; i++)
                {
                    if (movies[i].Id == index)
                    {
                        movies[i].Keyword.Add(data);
                    }
                }
            }
            reader.Close();
        }

        public void FillupDirector(ref List<Movie> movies)
        {
            int index;
            int data;
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Movies_Directors";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                index = Convert.ToInt32(reader["Movie_ID"]);
                data = Convert.ToInt32(reader["Directors_ID"]);
                for (int i = 0; i < movies.Count; i++)
                {
                    if (movies[i].Id == index)
                    {
                        movies[i].Director.Add(data);
                    }
                }
            }
            reader.Close();
        }

        public void FillupLanguage(ref List<Movie> movies)
        {
            int index;
            int data;
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Movies_Languages";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                index = Convert.ToInt32(reader["Movie_ID"]);
                data = Convert.ToInt32(reader["Languages_ID"]);
                for (int i = 0; i < movies.Count; i++)
                {
                    if (movies[i].Id == index)
                    {
                        movies[i].Language.Add(data);
                    }
                }
            }
            reader.Close();
        }
        
        public void FillupCountry(ref List<Movie> movies)
        {
            int index;
            int data;
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Movies_Countries";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                index = Convert.ToInt32(reader["Movie_ID"]);
                data = Convert.ToInt32(reader["Countries_ID"]);
                for (int i = 0; i < movies.Count; i++)
                {
                    if (movies[i].Id == index)
                    {
                        movies[i].ProductionCountry.Add(data);
                    }
                }
            }
            reader.Close();
        }

        /// <summary>
        /// A korábbiakban megkapott integerek felhasználásával hozzárendeljük a műfajok nevét is a filmekhez
        /// </summary>
        /// <param name="movies">A movies lista megfelelő adattagjában fogjuk eltárolni a műfajok tényleges neveit is</param>
        /// <param name="tableID">A műfajok integer azonosítót tároljuk benne</param>
        /// <param name="tableData">A műfajok neveit tároljuk benne</param>
        public void GetGenre(ref List<Movie> movies, List<int> tableID, List<string> tableData, ref PropertiesForDecTree prop)
        {
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Genres";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                tableID.Add(Convert.ToInt32(reader["ID"]));
                tableData.Add(reader["Genre_Name"].ToString());
                prop.GenreAll.Add(reader["Genre_Name"].ToString()); //az összes műfaj eltárolása a prop változó GenreAll adattagjában a becslésekhez használt tömbök feltöltésének előkészítéséhez
            }
            reader.Close();
            Algorithms alg = new Algorithms();
            //int mode = (int)Mode.Genre; //enumot használva beállítjuk a mode változó értékét Genre-re, amit castolással integerré alakítunk
            //alg.tableFiller(ref movies, tableID, tableData, mode); //a tableFiller metódusnak átadjuk a műfajok azonosítóit és a műfajokat is, a mode változó értékébőúl pedig tudni fogja hogy a movies lista melyik adattagját kell feltölteni a kapott adatokkal
            alg.GenreToString(ref movies,tableID,tableData);
        }

        public void GetKeyword(ref List<Movie> movies, List<int> tableID, List<string> tableData, ref PropertiesForDecTree prop)
        {
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Keywords";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                tableID.Add(Convert.ToInt32(reader["ID"]));
                tableData.Add(reader["Keyword_Name"].ToString());
                prop.KeywordAll.Add(reader["Keyword_Name"].ToString());
            }
            reader.Close();
            Algorithms alg = new Algorithms();
            //int mode = (int)Mode.Keyword;
            //alg.tableFiller(ref movies, tableID, tableData, mode);
            alg.KeywordToString(ref movies, tableID, tableData);
            //prop.KeywordAll = tableData;

        }

        public void GetLanguage(ref List<Movie> movies, List<int> tableID, List<string> tableData, ref PropertiesForDecTree prop)
        {
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Languages";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                tableID.Add(Convert.ToInt32(reader["ID"]));
                tableData.Add(reader["Language_Name"].ToString());
                prop.LanguageAll.Add(reader["Language_Name"].ToString());
            }
            reader.Close();
            Algorithms alg = new Algorithms();
            //int mode = (int)Mode.Language;
            //alg.tableFiller(ref movies, tableID, tableData, mode);
            alg.LanguageToString(ref movies, tableID, tableData);
            //prop.LanguageAll = tableData;
        }

        public void GetDirector(ref List<Movie> movies, List<int> tableID, List<string> tableData, ref PropertiesForDecTree prop)
        {
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Directors";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                tableID.Add(Convert.ToInt32(reader["ID"]));
                tableData.Add(reader["Director_Name"].ToString());
                prop.DirectorAll.Add(reader["Director_Name"].ToString());
            }
            reader.Close();
            Algorithms alg = new Algorithms();
            //int mode = (int)Mode.Director;
            //alg.tableFiller(ref movies, tableID, tableData, mode);
            alg.DirectorToString(ref movies, tableID, tableData);
            //prop.DirectorAll = tableData;
        }

        public void GetCountry(ref List<Movie> movies, List<int> tableID, List<string> tableData, ref PropertiesForDecTree prop)
        {
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Countries";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                tableID.Add(Convert.ToInt32(reader["ID"]));
                tableData.Add(reader["Country_Name"].ToString());
                prop.CountryAll.Add(reader["Country_Name"].ToString());
            }
            reader.Close();
            Algorithms alg = new Algorithms();
            //int mode = (int)Mode.Country;
            //alg.tableFiller(ref movies, tableID, tableData, mode);
            alg.CountryToString(ref movies, tableID, tableData);
            // prop.CountryAll = tableData;
        }

        public void UpdateCommand(string cmd)
        {
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = cmd;
            command.ExecuteNonQuery();
        }
    }
}
