using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordInsert
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
                    Console.WriteLine("Az adatbázishoz való kapcsolódás sikertelen");
                }

            }
            else
            {
                Console.WriteLine("Az adatbázis nem található");
                Environment.Exit(1);
            }
        }

        public void DbMethods(ref List<int> kwID, ref List<string> kw, ref List<int> mID, ref List<string> mkw)
        {
            SQLiteDataReader reader = null;
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Keywords";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                kwID.Add(Convert.ToInt32(reader["ID"]));
                kw.Add(string.Format("{0}", reader["Keyword_Name"]));
            }

            reader.Close();
            command.CommandText = "SELECT * FROM Movies";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                mID.Add(Convert.ToInt32(reader["ID"]));
                mkw.Add(string.Format("{0}", reader["Keywords"]));
            }
        }

        public void DbWrite(List<string> cmds)
        {
            SQLiteCommand command = connection.CreateCommand();
            for (int i = 0; i < cmds.Count; i++)
            {
                command.CommandText = cmds[i];
                command.ExecuteNonQuery();
            }
        }
    }
}
