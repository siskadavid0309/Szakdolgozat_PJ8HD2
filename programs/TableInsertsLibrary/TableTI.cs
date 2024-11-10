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
             List<int> finalMovieId, List<int> finalDataId, List<string> cmds)
        {

            AlgorithmsTI alg = new AlgorithmsTI();
            FillUpsTI fill = new FillUpsTI();
            int mode = (int)Mode.Genre;
            List<string> data = conn.PrepareGenres();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);

            alg.CreateData(id, data, movies, ref finalMovieId, ref finalDataId, mode);
            fill.MoviesGenres(finalMovieId, finalDataId, ref cmds);
            conn.ExecuteInserts(cmds);
            id.Clear();
            finalMovieId.Clear();
            finalDataId.Clear();
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
             List<int> finalMovieId, List<int> finalDataId, List<string> cmds)
        {
            AlgorithmsTI alg = new AlgorithmsTI();
            FillUpsTI fill = new FillUpsTI();
            int mode = (int)Mode.Keyword;
            List<string> data = conn.PrepareKeywords();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);

            alg.CreateData(id, data, movies, ref finalMovieId, ref finalDataId, mode);
            fill.MoviesKeywords(finalMovieId, finalDataId, ref cmds);
            conn.ExecuteInserts(cmds);
            id.Clear();
            finalMovieId.Clear();
            finalDataId.Clear();
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
             List<int> finalMovieId, List<int> finalDataId, List<string> cmds)
        {
            AlgorithmsTI alg = new AlgorithmsTI();
            FillUpsTI fill = new FillUpsTI();
            int mode = (int)Mode.Language;
            List<string> data = conn.PrepareLanguages();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);

            alg.CreateData(id, data, movies, ref finalMovieId, ref finalDataId, mode);
            fill.MoviesLanguages(finalMovieId, finalDataId, ref cmds);
            conn.ExecuteInserts(cmds);
            id.Clear();
            finalMovieId.Clear();
            finalDataId.Clear();
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
             List<int> finalMovieId, List<int> finalDataId, List<string> cmds)
        {
            AlgorithmsTI alg = new AlgorithmsTI();
            FillUpsTI fill = new FillUpsTI();
            int mode = (int)Mode.Director;
            List<string> data = conn.PrepareDirectors();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);

            alg.CreateData(id, data, movies, ref finalMovieId, ref finalDataId, mode);
            fill.MoviesDirectors(finalMovieId, finalDataId, ref cmds);
            conn.ExecuteInserts(cmds);
            id.Clear();
            finalMovieId.Clear();
            finalDataId.Clear();
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
             List<int> finalMovieId, List<int> finalDataId, List<string> cmds)
        {
            AlgorithmsTI alg = new AlgorithmsTI();
            FillUpsTI fill = new FillUpsTI();
            int mode = (int)Mode.Country;
            List<string> data = conn.PrepareCountries();
            data = alg.Matches(data);
            alg.GenerateId(ref id, data);

            alg.CreateData(id, data, movies, ref finalMovieId, ref finalDataId, mode);
            fill.MoviesCountries(finalMovieId, finalDataId, ref cmds);
            conn.ExecuteInserts(cmds);
            id.Clear();
            finalMovieId.Clear();
            finalDataId.Clear();
            cmds.Clear();
        }

        public void InsertAll(SqlConnectorTI conn, List<int> id, List<MovieTI> movies,
     List<int> finalMovieId, List<int> finalDataId, List<string> cmds)
        {
            FillUpsTI fillup = new FillUpsTI();
            conn.ExecuteInserts(fillup.UpdateDB());
            Keyword(conn, id, cmds);
            Keyword_Movie(conn, id, movies, finalMovieId, finalDataId, cmds);
            Language(conn, id, cmds);
            Language_Movie(conn, id, movies, finalMovieId, finalDataId, cmds);
            Director(conn, id, cmds);
            Director_Movie(conn, id, movies, finalMovieId, finalDataId, cmds);
            Country(conn, id, cmds);
            Country_Movie(conn, id, movies, finalMovieId, finalDataId, cmds);
            Genre(conn, id, cmds);
            Genre_Movie(conn, id, movies, finalMovieId, finalDataId, cmds);
        }
    }
}
