using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableInserts
{
    internal class Table
    {
        public static void Genre(SqlConnector conn, List<int> id, List<string> cmds)
        {
            Algorithms alg = new Algorithms();
            FillUps fill = new FillUps();
            List<string> data = conn.PrepareGenres();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);
            fill.Genres(id, data, ref cmds);
            conn.ExecuteInserts(cmds);
            cmds.Clear();
        }

        public static void Genre_Movie(SqlConnector conn, List<int> id, List<Movie> movies,
             List<int> finalMovieId, List<int> finalDataId, List<string> cmds)
        {
            
            Algorithms alg= new Algorithms();
            FillUps fill= new FillUps();
            int mode = (int)Mode.Genre;
            List<string> data = conn.PrepareGenres();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);

            alg.CreateData(id, data, movies, ref finalMovieId, ref finalDataId, mode);
            fill.MoviesGenres(finalMovieId, finalDataId, ref cmds);
            conn.ExecuteInserts(cmds);
            cmds.Clear();
        }

        public static void Keyword(SqlConnector conn, List<int> id, List<string> cmds)
        {
            Algorithms alg = new Algorithms();
            FillUps fill = new FillUps();
            List<string> data =conn.PrepareKeywords();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);
            fill.Keywords(id, data, ref cmds);
            conn.ExecuteInserts(cmds);
            cmds.Clear();
        }

        public static void Keyword_Movie(SqlConnector conn, List<int> id, List<Movie> movies,
             List<int> finalMovieId, List<int> finalDataId, List<string> cmds)
        {
            Algorithms alg = new Algorithms();
            FillUps fill = new FillUps();
            int mode = (int)Mode.Keyword;
            List<string> data =conn.PrepareKeywords();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);

            alg.CreateData(id, data, movies, ref finalMovieId, ref finalDataId, mode);
            fill.MoviesKeywords(finalMovieId, finalDataId, ref cmds);
            conn.ExecuteInserts(cmds);
            cmds.Clear();
        }

        public static void Language(SqlConnector conn, List<int> id, List<string> cmds)
        {
            Algorithms alg = new Algorithms();
            FillUps fill = new FillUps();
            List<string> data = conn.PrepareLanguages();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);
            fill.Languages(id, data, ref cmds);
            conn.ExecuteInserts(cmds);
            cmds.Clear();
        }

        public static void Language_Movie(SqlConnector conn, List<int> id, List<Movie> movies,
             List<int> finalMovieId, List<int> finalDataId, List<string> cmds)
        {
            Algorithms alg = new Algorithms();
            FillUps fill = new FillUps();
            int mode = (int)Mode.Language;
            List<string> data =conn.PrepareLanguages();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);

            alg.CreateData(id, data, movies, ref finalMovieId, ref finalDataId, mode);
            fill.MoviesLanguages(finalMovieId, finalDataId, ref cmds);
            conn.ExecuteInserts(cmds);
            cmds.Clear();
        }

        public static void Director(SqlConnector conn, List<int> id, List<string> cmds)
        {
            Algorithms alg = new Algorithms();
            FillUps fill = new FillUps();
            List<string> data =conn.PrepareDirectors();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);
            fill.Directors(id, data, ref cmds);
            conn.ExecuteInserts(cmds);
            cmds.Clear();
        }

        public static void Director_Movie(SqlConnector conn, List<int> id, List<Movie> movies,
             List<int> finalMovieId, List<int> finalDataId, List<string> cmds)
        {
            Algorithms alg = new Algorithms();
            FillUps fill = new FillUps();
            int mode = (int)Mode.Director;
            List<string> data = conn.PrepareDirectors();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);

            alg.CreateData(id, data, movies, ref finalMovieId, ref finalDataId, mode);
            fill.MoviesDirectors(finalMovieId, finalDataId, ref cmds);
            conn.ExecuteInserts(cmds);
            cmds.Clear();
        }

        public static void Country(SqlConnector conn, List<int> id, List<string> cmds)
        {
            Algorithms alg = new Algorithms();
            FillUps fill = new FillUps();
            List<string> data = conn.PrepareCountries();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);
            fill.Countries(id, data, ref cmds);
            conn.ExecuteInserts(cmds);
            cmds.Clear();
        }

        public static void Country_Movie(SqlConnector conn, List<int> id, List<Movie> movies,
             List<int> finalMovieId, List<int> finalDataId,List<string> cmds)
        {
            Algorithms alg = new Algorithms();
            FillUps fill = new FillUps();
            int mode = (int)Mode.Country;
            List<string> data = conn.PrepareCountries();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);

            alg.CreateData(id, data, movies, ref finalMovieId, ref finalDataId, mode);
            fill.MoviesCountries(finalMovieId, finalDataId, ref cmds);
            conn.ExecuteInserts(cmds);
            cmds.Clear();
        }

        public void Options(SqlConnector conn, List<int> id, List<Movie> movies,
     List<int> finalMovieId, List<int> finalDataId, List<string> cmds)
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
                    Keyword_Movie(conn, id, movies, finalMovieId, finalDataId, cmds);
                    break;
                case 2:
                    Language(conn, id, cmds);
                    break;
                case 3:
                    Language_Movie(conn, id, movies, finalMovieId, finalDataId, cmds);
                    break;
                case 4:
                    Director(conn, id, cmds);
                    break;
                case 5:
                    Director_Movie(conn, id, movies, finalMovieId, finalDataId, cmds);
                    break;
                case 6:
                    Country(conn, id, cmds);
                    break;
                case 7:
                    Country_Movie(conn, id, movies, finalMovieId, finalDataId, cmds);
                    break;
                case 8:
                    Genre(conn, id, cmds);
                    break;
                case 9:
                    Genre_Movie(conn, id, movies, finalMovieId, finalDataId, cmds);
                    break;
            }
        }
    }
}
