using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableInsertsLibrary
{
    public class TableTI
    {
        public static void Genre(SqlConnectorTI conn, List<int> id, List<string> cmds)
        {
            AlgorithmsTI alg = new AlgorithmsTI();
            FillUpsTI fill = new FillUpsTI();
            List<string> data = conn.PrepareGenres();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);
            fill.Genres(id, data, ref cmds);
            conn.ExecuteInserts(cmds);
            id.Clear();
            cmds.Clear();
        }

        public static void Genre_Movie(SqlConnectorTI conn, List<int> id, List<MovieTI> movies,
             List<int> finalMovieID, List<int> finalDataID, List<string> cmds)
        {

            AlgorithmsTI alg = new AlgorithmsTI();
            FillUpsTI fill = new FillUpsTI();
            int mode = (int)Mode.Genre;
            List<string> data = conn.PrepareGenres();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);

            alg.CreateData(id, data, movies, ref finalMovieID, ref finalDataID, mode);
            fill.MoviesGenres(finalMovieID, finalDataID, ref cmds);
            conn.ExecuteInserts(cmds);
            id.Clear();
            finalMovieID.Clear();
            finalDataID.Clear();
            cmds.Clear();
        }

        public static void Keyword(SqlConnectorTI conn, List<int> id, List<string> cmds)
        {
            AlgorithmsTI alg = new AlgorithmsTI();
            FillUpsTI fill = new FillUpsTI();
            List<string> data = conn.PrepareKeywords();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);
            fill.Keywords(id, data, ref cmds);
            conn.ExecuteInserts(cmds);
            id.Clear();
            cmds.Clear();
        }

        public static void Keyword_Movie(SqlConnectorTI conn, List<int> id, List<MovieTI> movies,
             List<int> finalMovieID, List<int> finalDataID, List<string> cmds)
        {
            AlgorithmsTI alg = new AlgorithmsTI();
            FillUpsTI fill = new FillUpsTI();
            int mode = (int)Mode.Keyword;
            List<string> data = conn.PrepareKeywords();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);

            alg.CreateData(id, data, movies, ref finalMovieID, ref finalDataID, mode);
            fill.MoviesKeywords(finalMovieID, finalDataID, ref cmds);
            conn.ExecuteInserts(cmds);
            id.Clear();
            finalMovieID.Clear();
            finalDataID.Clear();
            cmds.Clear();
        }

        public static void Language(SqlConnectorTI conn, List<int> id, List<string> cmds)
        {
            AlgorithmsTI alg = new AlgorithmsTI();
            FillUpsTI fill = new FillUpsTI();
            List<string> data = conn.PrepareLanguages();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);
            fill.Languages(id, data, ref cmds);
            conn.ExecuteInserts(cmds);
            id.Clear();
            cmds.Clear();
        }

        public static void Language_Movie(SqlConnectorTI conn, List<int> id, List<MovieTI> movies,
             List<int> finalMovieID, List<int> finalDataID, List<string> cmds)
        {
            AlgorithmsTI alg = new AlgorithmsTI();
            FillUpsTI fill = new FillUpsTI();
            int mode = (int)Mode.Language;
            List<string> data = conn.PrepareLanguages();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);

            alg.CreateData(id, data, movies, ref finalMovieID, ref finalDataID, mode);
            fill.MoviesLanguages(finalMovieID, finalDataID, ref cmds);
            conn.ExecuteInserts(cmds);
            id.Clear();
            finalMovieID.Clear();
            finalDataID.Clear();
            cmds.Clear();
        }

        public static void Director(SqlConnectorTI conn, List<int> id, List<string> cmds)
        {
            AlgorithmsTI alg = new AlgorithmsTI();
            FillUpsTI fill = new FillUpsTI();
            List<string> data = conn.PrepareDirectors();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);
            fill.Directors(id, data, ref cmds);
            conn.ExecuteInserts(cmds);
            id.Clear();
            cmds.Clear();
        }

        public static void Director_Movie(SqlConnectorTI conn, List<int> id, List<MovieTI> movies,
             List<int> finalMovieID, List<int> finalDataID, List<string> cmds)
        {
            AlgorithmsTI alg = new AlgorithmsTI();
            FillUpsTI fill = new FillUpsTI();
            int mode = (int)Mode.Director;
            List<string> data = conn.PrepareDirectors();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);

            alg.CreateData(id, data, movies, ref finalMovieID, ref finalDataID, mode);
            fill.MoviesDirectors(finalMovieID, finalDataID, ref cmds);
            conn.ExecuteInserts(cmds);
            id.Clear();
            finalMovieID.Clear();
            finalDataID.Clear();
            cmds.Clear();
        }

        public static void Country(SqlConnectorTI conn, List<int> id, List<string> cmds)
        {
            AlgorithmsTI alg = new AlgorithmsTI();
            FillUpsTI fill = new FillUpsTI();
            List<string> data = conn.PrepareCountries();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);
            fill.Countries(id, data, ref cmds);
            conn.ExecuteInserts(cmds);
            id.Clear();
            cmds.Clear();
        }

        public static void Country_Movie(SqlConnectorTI conn, List<int> id, List<MovieTI> movies,
             List<int> finalMovieID, List<int> finalDataID, List<string> cmds)
        {
            AlgorithmsTI alg = new AlgorithmsTI();
            FillUpsTI fill = new FillUpsTI();
            int mode = (int)Mode.Country;
            List<string> data = conn.PrepareCountries();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);

            alg.CreateData(id, data, movies, ref finalMovieID, ref finalDataID, mode);
            fill.MoviesCountries(finalMovieID, finalDataID, ref cmds);
            conn.ExecuteInserts(cmds);
            id.Clear();
            finalMovieID.Clear();
            finalDataID.Clear();
            cmds.Clear();
        }

        public void InsertAll(SqlConnectorTI conn, List<int> id, List<MovieTI> movies,
     List<int> finalMovieID, List<int> finalDataID, List<string> cmds)
        {
            FillUpsTI fillup= new FillUpsTI();
            conn.ExecuteInserts(fillup.UpdateDB());
            Keyword(conn, id, cmds);
            Keyword_Movie(conn, id, movies, finalMovieID, finalDataID, cmds);
            Language(conn, id, cmds);
            Language_Movie(conn, id, movies, finalMovieID, finalDataID, cmds);
            Director(conn, id, cmds);
            Director_Movie(conn, id, movies, finalMovieID, finalDataID, cmds);
            Country(conn, id, cmds);
            Country_Movie(conn, id, movies, finalMovieID, finalDataID, cmds);
            Genre(conn, id, cmds);
            Genre_Movie(conn, id, movies, finalMovieID, finalDataID, cmds);
        }
        
        public void Options(SqlConnectorTI conn, List<int> id, List<MovieTI> movies,
     List<int> finalMovieID, List<int> finalDataID, List<string> cmds)
        {
            bool beolvasas = false;
            int szam = 0;
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
            
            while (beolvasas != true)
            {
                beolvasas = int.TryParse(Console.ReadLine(), out szam);
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
                    Keyword(conn, id, cmds);
                    break;
                case 1:
                    Keyword_Movie(conn, id, movies, finalMovieID, finalDataID, cmds);
                    break;
                case 2:
                    Language(conn, id, cmds);
                    break;
                case 3:
                    Language_Movie(conn, id, movies, finalMovieID, finalDataID, cmds);
                    break;
                case 4:
                    Director(conn, id, cmds);
                    break;
                case 5:
                    Director_Movie(conn, id, movies, finalMovieID, finalDataID, cmds);
                    break;
                case 6:
                    Country(conn, id, cmds);
                    break;
                case 7:
                    Country_Movie(conn, id, movies, finalMovieID, finalDataID, cmds);
                    break;
                case 8:
                    Genre(conn, id, cmds);
                    break;
                case 9:
                    Genre_Movie(conn, id, movies, finalMovieID, finalDataID, cmds);
                    break;
            }
        }
    }
}
