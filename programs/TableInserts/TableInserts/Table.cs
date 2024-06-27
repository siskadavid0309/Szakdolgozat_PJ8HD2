using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableInserts
{
    internal class Table
    {
        public static void genre(SqlConnector conn, List<int> id, List<string> data, FillUps fill, Algorithms alg, List<string> cmds)
        {
            data = conn.prepareGenres();
            data = alg.Matches(data);
            alg.idGenerate(ref id, data);
            fill.G(id, data, ref cmds);
            conn.executeInserts(cmds);
            cmds.Clear();
        }

        public static void genre_movie(SqlConnector conn, List<int> id, List<string> data, List<Movie> movies,
             List<int> finalMovieID, List<int> finalDataID, FillUps fill, Algorithms alg, List<string> cmds, int mode)
        {
            mode = 0;
            data=data = conn.prepareGenres();
            data = alg.Matches(data);
            alg.idGenerate(ref id, data);

            alg.createData(id, data, movies, ref finalMovieID, ref finalDataID, mode);
            fill.MG(finalMovieID, finalDataID, ref cmds);
            conn.executeInserts(cmds);
            cmds.Clear();
        }

        public static void keyword(SqlConnector conn, List<int> id, List<string> data, FillUps fill, Algorithms alg, List<string> cmds)
        {
            data=conn.prepareKeywords();
            data = alg.Matches(data);
            alg.idGenerate(ref id, data);
            fill.K(id, data, ref cmds);
            conn.executeInserts(cmds);
            cmds.Clear();
        }

        public static void keyword_movie(SqlConnector conn, List<int> id, List<string> data, List<Movie> movies,
             List<int> finalMovieID, List<int> finalDataID, FillUps fill, Algorithms alg, List<string> cmds, int mode)
        {
            mode = 1;
            data=conn.prepareKeywords();
            data = alg.Matches(data);
            alg.idGenerate(ref id, data);

            alg.createData(id, data, movies, ref finalMovieID, ref finalDataID, mode);
            fill.MK(finalMovieID, finalDataID, ref cmds);
            conn.executeInserts(cmds);
            cmds.Clear();
        }

        public static void language(SqlConnector conn, List<int> id, List<string> data, FillUps fill, Algorithms alg, List<string> cmds)
        {
            data = conn.prepareLanguages();
            data = alg.Matches(data);
            alg.idGenerate(ref id, data);
            fill.L(id, data, ref cmds);
            conn.executeInserts(cmds);
            cmds.Clear();
        }

        public static void language_movie(SqlConnector conn, List<int> id, List<string> data, List<Movie> movies,
             List<int> finalMovieID, List<int> finalDataID, FillUps fill, Algorithms alg, List<string> cmds, int mode)
        {
            mode = 2;
            data=conn.prepareLanguages();
            data = alg.Matches(data);
            alg.idGenerate(ref id, data);

            alg.createData(id, data, movies, ref finalMovieID, ref finalDataID, mode);
            fill.ML(finalMovieID, finalDataID, ref cmds);
            conn.executeInserts(cmds);
            cmds.Clear();
        }

        public static void director(SqlConnector conn, List<int> id, List<string> data, FillUps fill, Algorithms alg, List<string> cmds)
        {
            data=conn.prepareDirectors();
            data = alg.Matches(data);
            alg.idGenerate(ref id, data);
            fill.D(id, data, ref cmds);
            conn.executeInserts(cmds);
            cmds.Clear();
        }

        public static void director_movie(SqlConnector conn, List<int> id, List<string> data, List<Movie> movies,
             List<int> finalMovieID, List<int> finalDataID, FillUps fill, Algorithms alg, List<string> cmds, int mode)
        {
            mode = 3;
            data = conn.prepareDirectors();
            data = alg.Matches(data);
            alg.idGenerate(ref id, data);

            alg.createData(id, data, movies, ref finalMovieID, ref finalDataID, mode);
            fill.MD(finalMovieID, finalDataID, ref cmds);
            conn.executeInserts(cmds);
            cmds.Clear();
        }

        public static void country(SqlConnector conn, List<int> id, List<string> data, FillUps fill, Algorithms alg, List<string> cmds)
        {
            data = conn.prepareCountries();
            data = alg.Matches(data);
            alg.idGenerate(ref id, data);
            fill.C(id, data, ref cmds);
            conn.executeInserts(cmds);
            cmds.Clear();
        }

        public static void country_movie(SqlConnector conn, List<int> id, List<string> data, List<Movie> movies,
             List<int> finalMovieID, List<int> finalDataID, FillUps fill, Algorithms alg, List<string> cmds, int mode)
        {
            mode = 4;
            data = conn.prepareCountries();
            data = alg.Matches(data);
            alg.idGenerate(ref id, data);

            alg.createData(id, data, movies, ref finalMovieID, ref finalDataID, mode);
            fill.MC(finalMovieID, finalDataID, ref cmds);
            conn.executeInserts(cmds);
            cmds.Clear();
        }

        public void Options(SqlConnector conn, List<int> id, List<string> data, List<Movie> movies,
     List<int> finalMovieID, List<int> finalDataID, FillUps fill, Algorithms alg, List<string> cmds, int mode)
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
                    keyword(conn, id, data, fill, alg, cmds);
                    break;
                case 1:
                    keyword_movie(conn, id, data, movies, finalMovieID, finalDataID, fill, alg, cmds, mode);
                    break;
                case 2:
                    language(conn, id, data, fill, alg, cmds);
                    break;
                case 3:
                    language_movie(conn, id, data, movies, finalMovieID, finalDataID, fill, alg, cmds, mode);
                    break;
                case 4:
                    director(conn, id, data, fill, alg, cmds);
                    break;
                case 5:
                    director_movie(conn, id, data, movies, finalMovieID, finalDataID, fill, alg, cmds, mode);
                    break;
                case 6:
                    country(conn, id, data, fill, alg, cmds);
                    break;
                case 7:
                    country_movie(conn, id, data, movies, finalMovieID, finalDataID, fill, alg, cmds, mode);
                    break;
                case 8:
                    genre(conn, id, data, fill, alg, cmds);
                    break;
                case 9:
                    genre_movie(conn, id, data, movies, finalMovieID, finalDataID, fill, alg, cmds, mode);
                    break;
            }
        }
    }
}
