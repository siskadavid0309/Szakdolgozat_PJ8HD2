using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// A movies lista GenreString, Keywordstring, stb. adattagjainak feltöltése a korábban már eltárolt azonosító integerek (id-k) segítségevel, melyeket a switch case-ben használunk
        /// </summary>
        /// <param name="movies"></param>
        /// <param name="tableID">Az aktuális adat id-jait tartalmazó lista</param>
        /// <param name="tableData">Az aktuális adatokat ténylegesen tartalmazó lista, amelyek majd a megfelelő adattagba kerülnek </param>
        /// <param name="mode">Meghatározza hogy melyik adattagot kell feltölteni</param>
        public void tableFiller(ref List<Movie> movies, List<int> tableID, List<string> tableData, int mode)
        {
            switch(mode)
            {
                case (int)Mode.Genre:
                    GenreToString(ref movies, tableID, tableData);
                    break;
                case (int)Mode.Keyword:
                    KeywordToString(ref movies, tableID, tableData);
                    break;
                case (int)Mode.Language:
                    LanguageToString(ref movies, tableID, tableData);
                    break;
                case (int)Mode.Director:
                    DirectorToString(ref movies, tableID, tableData);
                    break;
                case (int)Mode.Country:
                    CountryToString(ref movies, tableID, tableData);
                    break;
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

    }
}
