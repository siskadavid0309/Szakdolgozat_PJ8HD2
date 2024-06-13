using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace TableInserts
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string databaseFileName = "movies.db";
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string databasePath = Path.Combine(currentDirectory, databaseFileName);
            SqlConnector conn = new SqlConnector(databasePath);
            List<string> cmds = new List<string>();

            List<Movie> movies = new List<Movie>();
            int mode = 0;
            
            List<int> id = new List<int>();
            List<string> data = new List<string>();
            List<int> finalMovieID = new List<int>();
            List<int> finalDataID=new List<int>();

            conn.getMoviedata(ref movies);
  
            Options(conn, id, data, movies, finalMovieID, finalDataID, cmds, mode);
          
        }

        
        static void genre(SqlConnector conn, List<int> id, List<string> data, List<string> cmds)
        {
            conn.genrePrepare(ref data);
            data=Matches(data);
            idGenerate(ref id, data);
            FillUp_G(id, data, ref cmds);
            conn.DbWrite(cmds);
            cmds.Clear();
        }

        static void genre_movie(SqlConnector conn, List<int> id, List<string> data, List<Movie> movies,
             List<int> finalMovieID, List<int> finalDataID, List<string> cmds, int mode)
        {
            mode = 0;
            conn.genrePrepare(ref data);
            data = Matches(data);
            idGenerate(ref id, data);

            createData(id, data, movies, ref finalMovieID, ref finalDataID, mode);
            FillUp_MG(finalMovieID,finalDataID, ref cmds);
            conn.DbWrite(cmds);
            cmds.Clear();
        }

        static void keyword(SqlConnector conn, List<int> id, List<string> data, List<string> cmds)
        {
            conn.keywordPrepare(ref data);
            data = Matches(data);
            idGenerate(ref id, data);
            FillUp_K(id, data, ref cmds);
            conn.DbWrite(cmds);
            cmds.Clear();
        }

        static void keyword_movie(SqlConnector conn, List<int> id, List<string> data, List<Movie> movies,
             List<int> finalMovieID, List<int> finalDataID, List<string> cmds, int mode)
        {
            mode = 1;
            conn.keywordPrepare(ref data);
            data = Matches(data);
            idGenerate(ref id, data);

            createData(id, data, movies, ref finalMovieID, ref finalDataID, mode);
            FillUp_MK(finalMovieID, finalDataID, ref cmds);
            conn.DbWrite(cmds);
            cmds.Clear();
        }
        
        static void language(SqlConnector conn, List<int> id, List<string> data, List<string> cmds)
        {
            conn.languagePrepare(ref data);
            data = Matches(data);
            idGenerate(ref id, data);
            FillUp_L(id, data, ref cmds);
            conn.DbWrite(cmds);
            cmds.Clear();
        }
        
        static void language_movie(SqlConnector conn, List<int> id, List<string> data, List<Movie> movies,
             List<int> finalMovieID, List<int> finalDataID, List<string> cmds, int mode)
        {
            mode = 2;
            conn.languagePrepare(ref data);
            data = Matches(data);
            idGenerate(ref id, data);

            createData(id, data, movies, ref finalMovieID, ref finalDataID, mode);
            FillUp_ML(finalMovieID, finalDataID, ref cmds);
            conn.DbWrite(cmds);
            cmds.Clear();
        }

        static void director(SqlConnector conn, List<int> id, List<string> data, List<string> cmds)
        {
            conn.directorPrepare(ref data);
            data = Matches(data);
            idGenerate(ref id, data);
            FillUp_D(id, data, ref cmds);
            conn.DbWrite(cmds);
            cmds.Clear();
        }

        static void director_movie(SqlConnector conn, List<int> id, List<string> data, List<Movie> movies,
             List<int> finalMovieID, List<int> finalDataID, List<string> cmds, int mode)
        {
            mode = 3;
            conn.directorPrepare(ref data);
            data = Matches(data);
            idGenerate(ref id, data);

            createData(id, data, movies, ref finalMovieID, ref finalDataID, mode);
            FillUp_MD(finalMovieID, finalDataID, ref cmds);
            conn.DbWrite(cmds);
            cmds.Clear();
        }

        static void country(SqlConnector conn, List<int> id, List<string> data, List<string> cmds)
        {
            conn.countryPrepare(ref data);
            data = Matches(data);
            idGenerate(ref id, data);
            FillUp_C(id, data, ref cmds);
            conn.DbWrite(cmds);
            cmds.Clear();
        }
        
        static void country_movie(SqlConnector conn, List<int> id, List<string> data, List<Movie> movies,
             List<int> finalMovieID, List<int> finalDataID, List<string> cmds, int mode)
        {
            mode = 4;
            conn.countryPrepare(ref data);
            data = Matches(data);
            idGenerate(ref id, data);

            createData(id, data, movies, ref finalMovieID, ref finalDataID, mode);
            FillUp_MC(finalMovieID, finalDataID, ref cmds);
            conn.DbWrite(cmds);
            cmds.Clear();
        }
        
        static void createData(List<int> id, List<string> list_ok, List<Movie> movies, ref List<int> finalID, ref List<int> finalData, int mode)
        {
            List<string> tempData=new List<string>();
            copy(movies, ref tempData, mode);
            for (int i = 0; i < tempData.Count; i++)
            {
                for(int j = 0; j<id.Count; j++)
                {
                        
                    if (tempData[i].Equals(list_ok[j]) || tempData[i].StartsWith(list_ok[j] + ",") || tempData[i].Contains(", " + list_ok[j] + ",") || tempData[i].EndsWith(" " + list_ok[j]))
                    {
                        finalID.Add(Convert.ToInt32(movies[i].Id));
                        finalData.Add(Convert.ToInt32(id[j]));
                    }
                }
            }
        }

        static void FillUp_G(List<int> ids, List<string> genres_ok, ref List<string> cmds)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Genres\" (\"ID\", \"Genres_Name\") VALUES ({0}, \"" + genres_ok[i] + "\");", ids[i]));
            }
        }

        static void FillUp_MG(List<int> finalID, List<int> finalgenre, ref List<string> cmds)
        {
            for (int i = 0; i < finalID.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Movies_Genres\" (\"Movie_ID\", \"Genres_ID\") VALUES ({0}, {1});", finalID[i], finalgenre[i]));
            }
        }
        static void FillUp_MK(List<int> finalID, List<int> finalkw, ref List<string> cmds)
        {
            for (int i = 0; i < finalID.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Movies_Keywords\" (\"Movie_ID\", \"Keywords_ID\") VALUES ({0}, {1});", finalID[i], finalkw[i]));
            }
        }

        static void FillUp_K(List<int> ids, List<string> keywords_ok, ref List<string> cmds)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Keywords\" (\"ID\", \"Keyword_Name\") VALUES ({0}, \"" + keywords_ok[i]+"\");", ids[i]));
            }
        }

        static void FillUp_L(List<int> languageid, List<string> language_ok, ref List<string> cmds)
        {
            for (int i = 0; i < languageid.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Languages\" (\"ID\", \"Language_Name\") VALUES ({0}, \"" + language_ok[i] + "\");", languageid[i]));
            }
        }

        static void FillUp_ML(List<int> finallanguageid, List<int> finallanguage, ref List<string> cmds)
        {
            for (int i = 0; i < finallanguageid.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Movies_Languages\" (\"Movie_ID\", \"Languages_ID\") VALUES ({0}, {1});", finallanguageid[i], finallanguage[i]));
            }
        }

        static void FillUp_D(List<int> directorid, List<string> director_ok, ref List<string> cmds)
        {
            for (int i = 0; i < directorid.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Directors\" (\"ID\", \"Director_Name\") VALUES ({0}, \"" + director_ok[i] + "\");", directorid[i]));
            }
        }

        static void FillUp_MD(List<int> finaldirectorid, List<int> finaldirector, ref List<string> cmds)
        {
            for (int i = 0; i < finaldirectorid.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Movies_Directors\" (\"Movie_ID\", \"Directors_ID\") VALUES ({0}, {1});", finaldirectorid[i], finaldirector[i]));
            }
        }

        static void FillUp_C(List<int> countryid, List<string> country_ok, ref List<string> cmds)
        {
            for (int i = 0; i < countryid.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Countries\" (\"ID\", \"Country_Name\") VALUES ({0}, \"" + country_ok[i] + "\");", countryid[i]));
            }
        }

        static void FillUp_MC(List<int> finalcountryid, List<int> finalcountry, ref List<string> cmds)
        {
            for (int i = 0; i < finalcountryid.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Movies_Countries\" (\"Movie_ID\", \"Countries_ID\") VALUES ({0}, {1});", finalcountryid[i], finalcountry[i]));
            }
        }
        static List<string> Matches(List<string> list)
        {
            List<string> list_ok=new List<string>();
            bool match = false;
            for (int i = 0; i < list.Count; i++)
            {
                match = false;
                for (int j = 0; j < list_ok.Count; j++)
                {
                    if (list[i] == list_ok[j])
                    {
                        match = true;
                    }
                }
                if (match == false)
                {
                    list_ok.Add(list[i]);
                }

            }
            return list_ok;
        }

        static void idGenerate(ref List<int> id, List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                id.Add(i + 1);
            }
        }

        static void Options(SqlConnector conn, List<int> id, List<string> data, List<Movie> movies,
             List<int> finalMovieID, List<int> finalDataID, List<string> cmds, int mode)
        {
            bool beolvasas = false;
            int szam=0;
            Console.WriteLine("0 Keywords tábla feltöltése");
            Console.WriteLine("1 Movie_Keywords tábla feltöltése");
            Console.WriteLine("2 Languages tábla feltöltése");
            Console.WriteLine("3 Movie_Languages tábla feltöltése");
            Console.WriteLine("4 Directors tábla feltöltése");
            Console.WriteLine("5 Movies_Directors tábla feltöltése");
            Console.WriteLine("6 Countries tábla feltöltése");
            Console.WriteLine("7 Movies_Countries tábla feltöltése");
            Console.WriteLine("8 Genres tábla feltöltése");
            Console.WriteLine("9 Movies_Genres tábla feltöltése");

            while(beolvasas!=true)
            {
                beolvasas=int.TryParse(Console.ReadLine(), out szam);
                if (szam < 0 || szam > 9)
                {
                    beolvasas = false;
                }
            }
            //return szam;
            int decide = szam;
            switch (decide)
            {
                case 0:
                    keyword(conn, id, data, cmds);
                    break;
                case 1:
                    keyword_movie(conn, id, data, movies, finalMovieID, finalDataID, cmds, mode);
                    break;
                case 2:
                    language(conn, id, data, cmds);
                    break;
                case 3:
                    language_movie(conn, id, data, movies, finalMovieID, finalDataID, cmds, mode);
                    break;
                case 4:
                    director(conn, id, data, cmds);
                    break;
                case 5:
                    director_movie(conn, id, data, movies, finalMovieID, finalDataID, cmds, mode);
                    break;
                case 6:
                    country(conn, id, data, cmds);
                    break;
                case 7:
                    country_movie(conn, id, data, movies, finalMovieID, finalDataID, cmds, mode);
                    break;
                case 8:
                    genre(conn, id, data, cmds);
                    break;
                case 9:
                    genre_movie(conn, id, data, movies, finalMovieID, finalDataID, cmds, mode);
                    break;
            }
        }

        static void copy(List<Movie> movies, ref List<string> tempData, int mode)
        {

                switch (mode)
                {
                    case 0:
                    for (int i = 0; i < movies.Count; i++)
                    {
                        tempData.Add(movies[i].Genre);
                    }
                        break;
                    case 1:
                    for (int i = 0; i < movies.Count; i++)
                    {
                        tempData.Add(movies[i].Keywords);
                    }
                    break;
                    case 2:
                    for (int i = 0; i < movies.Count; i++)
                    {
                        tempData.Add(movies[i].Language);
                    }
                    break;
                    case 3:
                    for (int i = 0; i < movies.Count; i++)
                    {
                        tempData.Add(movies[i].Director);
                    }
                    break;
                    case 4:
                    for (int i = 0; i < movies.Count; i++)
                    {
                        tempData.Add(movies[i].Country);
                    }
                    break;

                }
            
        }

    }
}

