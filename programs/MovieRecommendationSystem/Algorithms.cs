using MovieRecommendation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableInsertsLibrary;


namespace MovieRecommendationSystem
{
    public enum Mode
    {
        Genre,
        Keyword,
        Language,
        Director,
        Country
    }
    internal class Algorithms
    {
        /// <summary>
        /// A prop változó lista adattagjainak inicializálása
        /// </summary>
        /// <param name="prop">PropertiesForDecTree típusú változó, a későbbiekben a becsléshez használatos listák, tömbök az adattagjai</param>

        public void LoadTableInserts(ref List<MovieTI> moviesTI, string databasePath)
        {
            SqlConnectorTI conn = new SqlConnectorTI(databasePath);
            List<string> cmds = new List<string>();
            TableTI table = new TableTI();
            List<int> id = new List<int>();
            List<int> finalMovieID = new List<int>();
            List<int> finalDataID = new List<int>();

            moviesTI = conn.CollectMovie();

            table.InsertAll(conn, id, moviesTI, finalMovieID, finalDataID, cmds);
        }
        public void InitListsForFillContains(ref PropertiesForDecTree prop)
        {
            prop.GenreAll = new List<string>();
            prop.KeywordAll = new List<string>();
            prop.LanguageAll = new List<string>();
            prop.DirectorAll = new List<string>();
            prop.CountryAll = new List<string>();

        }

        /// <summary>
        /// A prop változó kétdimenziós tömbjeinek inicializálása
        /// </summary>
        /// <param name="prop">A prop változó adattagjai az inicializálandó tömbök</param>
        /// <param name="movies">Minden egyes film esetén meg kell határozni az adott jellemző összes lehetséges adatára, hogy rendelkezik-e vele az adott film, vagy sem</param>
        public void InitArraysForFillContains(ref PropertiesForDecTree prop, List<Movie> movies)
        {
            prop.GenreContains = new int[movies.Count][];
            for (int i = 0; i < movies.Count; i++)
            {
                prop.GenreContains[i] = new int[prop.GenreAll.Count];
            }

            prop.KeywordContains = new int[movies.Count][];
            for (int i = 0; i < movies.Count; i++)
            {
                prop.KeywordContains[i] = new int[prop.KeywordAll.Count];
            }

            prop.LanguageContains = new int[movies.Count][];
            for (int i = 0; i < movies.Count; i++)
            {
                prop.LanguageContains[i] = new int[prop.LanguageAll.Count];
            }

            prop.DirectorContains = new int[movies.Count][];
            for (int i = 0; i < movies.Count; i++)
            {
                prop.DirectorContains[i] = new int[prop.DirectorAll.Count];
            }

            prop.CountryContains = new int[movies.Count][];
            for (int i = 0; i < movies.Count; i++)
            {
                prop.CountryContains[i] = new int[prop.CountryAll.Count];
            }

        }

        /// <summary>
        /// A tömbök feltöltése minden egyes filmnél, azon belül minden egyes előforduló adat esetén 0 vagy 1 értékkel
        /// </summary>
        /// <param name="prop">A PropertiesForDecTree osztály példányosításának adattagjait töltjük fel</param>
        /// <param name="movies">A filmeken megyünk végig, illetve azok adatait vizsgálva döntünk a 0 vagy 1 értékről</param>
        public void FillContains(ref PropertiesForDecTree prop, List<Movie> movies)
        {

            for (int i = 0; i < movies.Count; i++)
            {
                for (int j = 0; j < prop.GenreAll.Count; j++)
                {
                    for (int k = 0; k < movies[i].GenreString.Count; k++)
                    {

                        if (movies[i].GenreString[k].Contains(prop.GenreAll[j]))
                        {
                            prop.GenreContains[i][j] = 1;
                            break;
                        }
                        else
                        {
                            prop.GenreContains[i][j] = 0;
                        }
                    }
                }
            }

            for (int i = 0; i < movies.Count; i++)
            {
                for (int j = 0; j < prop.KeywordAll.Count; j++)
                {
                    for (int k = 0; k < movies[i].KeywordString.Count; k++)
                    {

                        if (movies[i].KeywordString[k].Contains(prop.KeywordAll[j]))
                        {
                            prop.KeywordContains[i][j] = 1;
                            break;
                        }
                        else
                        {
                            prop.KeywordContains[i][j] = 0;
                        }
                    }
                }
            }

            for (int i = 0; i < movies.Count; i++)
            {
                for (int j = 0; j < prop.LanguageAll.Count; j++)
                {
                    for (int k = 0; k < movies[i].LanguageString.Count; k++)
                    {

                        if (movies[i].LanguageString[k].Contains(prop.LanguageAll[j]))
                        {
                            prop.LanguageContains[i][j] = 1;
                            break;
                        }
                        else
                        {
                            prop.LanguageContains[i][j] = 0;
                        }
                    }
                }
            }

            for (int i = 0; i < movies.Count; i++)
            {
                for (int j = 0; j < prop.DirectorAll.Count; j++)
                {
                    for (int k = 0; k < movies[i].DirectorString.Count; k++)
                    {

                        if (movies[i].DirectorString[k].Contains(prop.DirectorAll[j]))
                        {
                            prop.DirectorContains[i][j] = 1;
                            break;
                        }
                        else
                        {
                            prop.DirectorContains[i][j] = 0;
                        }
                    }
                }
            }

            for (int i = 0; i < movies.Count; i++)
            {
                for (int j = 0; j < prop.CountryAll.Count; j++)
                {
                    for (int k = 0; k < movies[i].CountryString.Count; k++)
                    {

                        if (movies[i].CountryString[k].Contains(prop.CountryAll[j]))
                        {
                            prop.CountryContains[i][j] = 1;
                            break;
                        }
                        else
                        {
                            prop.CountryContains[i][j] = 0;
                        }
                    }
                }
            }

        }

        public void InitLists(ref List<Movie> movies)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                movies[i].Genre = new List<int>();
                movies[i].Keyword = new List<int>();
                movies[i].Director = new List<int>();
                movies[i].Language = new List<int>();
                movies[i].ProductionCountry = new List<int>();

                movies[i].GenreString = new List<string>();
                movies[i].KeywordString = new List<string>();
                movies[i].DirectorString = new List<string>();
                movies[i].LanguageString = new List<string>();
                movies[i].CountryString = new List<string>();
            }
        }

        /// <summary>
        /// A GenreString adattag tényleges feltöltése az egyes filmek esetén
        /// </summary>
        /// <param name="movies">A movie lista GenreString adattagjába kerülnek az adatok</param>
        /// <param name="tableID">A Genres táblából származó műfaj azonosítók (id-k)</param>
        /// <param name="tableData">A Genres táblából származó műfajok tényleges nevei</param>
        public void GenreToString(ref List<Movie> movies, List<int> tableID, List<string> tableData)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                for (int j = 0; j < movies[i].Genre.Count; j++)
                {
                    for (int k = 0; k < tableID.Count; k++)
                    {
                        if (movies[i].Genre[j] == tableID[k])
                        {
                            movies[i].GenreString.Add(tableData[k]);
                        }
                    }

                }
            }
            tableID.Clear();
            tableData.Clear();
        }
        public void KeywordToString(ref List<Movie> movies, List<int> tableID, List<string> tableData)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                for (int j = 0; j < movies[i].Keyword.Count; j++)
                {
                    for (int k = 0; k < tableID.Count; k++)
                    {
                        if (movies[i].Keyword[j] == tableID[k])
                        {
                            movies[i].KeywordString.Add(tableData[k]);
                        }
                    }

                }
            }
            tableID.Clear();
            tableData.Clear();
        }

        public void DirectorToString(ref List<Movie> movies, List<int> tableID, List<string> tableData)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                for (int j = 0; j < movies[i].Director.Count; j++)
                {
                    for (int k = 0; k < tableID.Count; k++)
                    {
                        if (movies[i].Director[j] == tableID[k])
                        {
                            movies[i].DirectorString.Add(tableData[k]);
                        }
                    }

                }
            }
            tableID.Clear();
            tableData.Clear();
        }

        public void LanguageToString(ref List<Movie> movies, List<int> tableID, List<string> tableData)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                for (int j = 0; j < movies[i].Language.Count; j++)
                {
                    for (int k = 0; k < tableID.Count; k++)
                    {
                        if (movies[i].Language[j] == tableID[k])
                        {
                            movies[i].LanguageString.Add(tableData[k]);
                        }
                    }

                }
            }
            tableID.Clear();
            tableData.Clear();
        }
        public void CountryToString(ref List<Movie> movies, List<int> tableID, List<string> tableData)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                for (int j = 0; j < movies[i].ProductionCountry.Count; j++)
                {
                    for (int k = 0; k < tableID.Count; k++)
                    {
                        if (movies[i].ProductionCountry[j] == tableID[k])
                        {
                            movies[i].CountryString.Add(tableData[k]);
                        }
                    }

                }
            }
            tableID.Clear();
            tableData.Clear();
        }

        public void IsBlockbuster(ref List<Movie> movies)
        {
            long difference = 0;
            for (int i = 0; i < movies.Count; i++)
            {
                difference = movies[i].Revenue - movies[i].Budget;
                if (difference > 0)
                {
                    movies[i].IsBlockbuster = true;
                }
                else
                {
                    movies[i].IsBlockbuster = false;
                }
            }
        }

        public void IsPopular(ref List<Movie> movies)
        {
            double avg = 0;
            for (int i = 0; i < movies.Count; i++)
            {
                avg += movies[i].Popularity;
            }
            avg = avg / movies.Count;
            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].Popularity > avg)
                {
                    movies[i].IsPopular = true;
                }
                else
                {
                    movies[i].IsPopular = false;
                }
            }
        }
    }
}
