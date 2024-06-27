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
            FillUps fill = new FillUps();
            Algorithms alg = new Algorithms();
            Table table = new Table();
            int mode = 0;
            
            List<int> id = new List<int>();
            List<string> data = new List<string>();
            List<int> finalMovieID = new List<int>();
            List<int> finalDataID=new List<int>();

            movies=conn.collectMoviedata();
  
            table.Options(conn, id, data, movies, finalMovieID, finalDataID, fill, alg, cmds, mode);
            Console.ReadKey();
        }
    }
}

