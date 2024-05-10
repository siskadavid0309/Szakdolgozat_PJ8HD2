using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace KeywordInsert
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> keywords = new List<string>();
            List<string> keywords_ok = new List<string>();
            LoadData("keywords.txt", ref keywords);
            Matches(keywords, ref keywords_ok);
            int[] ids = new int[keywords_ok.Count];
            idGenerate(ref ids, keywords_ok);
            List<string> cmds_k = new List<string>();

            string databasePath = "D:\\sqlite\\movies.db";
            List<int> kwID = new List<int>();
            List<string> kw = new List<string>();
            List<int> mID = new List<int>();
            List<string> mkw = new List<string>();
            List<int> kID = new List<int>();
            List<int> kkw = new List<int>();
            List<string> cmds = new List<string>();
            SqlConnector conn = new SqlConnector(databasePath);
            conn.DbMethods(ref kwID, ref kw, ref mID, ref mkw);
            /*
            for (int i = 0;i<mID.Count;i++)
            {
                Console.WriteLine(mID[i]+" " + mkw[i]);
            }
            */
            Match(kwID, kw, mID, mkw, ref kID, ref kkw);
            /*
            for(int i = 0;i<kID.Count;i++)
            {
                Console.WriteLine(kID[i]+" " + kkw[i]);
            }
            */
            FillUp_MK(kID, kkw, ref cmds);
            FillUp_K(ids, keywords_ok, ref cmds_k);
            for(int i = 0;i<cmds_k.Count;i++)
            {
                //Console.WriteLine(cmds[i]);
                Console.WriteLine(cmds_k[i]);
            }
            Console.ReadKey();
            conn.DbWrite(cmds);
            //conn.DbWrite(cmds_k);
        }

        static void Match(List<int> kwID, List<string> kw, List<int> mID, List<string> mkw, ref List<int> kID, ref List<int> kkw)
        {
            for (int i = 0; i < mID.Count; i++)
            {
                for(int j = 0; j<kwID.Count; j++)
                {
                    //if (mkw[i].Contains(" "+kw[j]+","))
                    if (mkw[i].Contains(" " + kw[j] + ",") || mkw[i].EndsWith(" " + kw[j]))
                    {
                        kID.Add(Convert.ToInt32(mID[i]));
                        kkw.Add(Convert.ToInt32(kwID[j]));
                    }
                }
            }
        }

        static void FillUp_MK(List<int> kID, List<int> kkw, ref List<string> cmds)
        {
            for (int i = 0; i < kID.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Movies_Keywords\" (\"Movie_ID\", \"Keywords_ID\") VALUES ({0}, {1});", kID[i], kkw[i]));
            }
        }

        static void FillUp_K(int[] ids, List<string> keywords_ok, ref List<string> cmds_k)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                cmds_k.Add(string.Format("INSERT INTO \"Keywords\" (\"ID\", \"Keyword_Name\") VALUES ({0}, \"" + keywords_ok[i]+"\");", ids[i]));
            }
        }

        static void LoadData(string file, ref List<string> keywords)
        {
            string[] lines = File.ReadAllLines(file);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                for (int j = 0; j < parts.Length; j++)
                {
                    keywords.Add(parts[j]);
                }
            }


        }

        static void Matches(List<string> keywords, ref List<string> keywords_ok)
        {
            bool match = false;
            for (int i = 0; i < keywords.Count; i++)
            {
                match = false;
                for (int j = 0; j < keywords_ok.Count; j++)
                {
                    if (keywords[i] == keywords_ok[j])
                    {
                        match = true;
                    }
                }
                if (match == false)
                {
                    keywords_ok.Add(keywords[i]);
                }

            }
        }

        static void idGenerate(ref int[] ids, List<string> keywords_ok)
        {
            for (int i = 0; i < keywords_ok.Count; i++)
            {
                ids[i] = i + 1;
            }
        }
    }
}

