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
            Table table = new Table();

            
            List<int> id = new List<int>();
            List<int> finalMovieID = new List<int>();
            List<int> finalDataID=new List<int>();

            movies=conn.CollectMovie();
  
            table.Options(conn, id, movies, finalMovieID, finalDataID, cmds);
            Console.ReadKey();
        }
    }
}

