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
   
            string databasePath = "D:\\sqlite\\movies.db";
            SqlConnector conn = new SqlConnector(databasePath);
            List<string> cmds = new List<string>();

            List<int> keywordsid = new List<int>();
            List<string> keywords = new List<string>();
            List<string> keywords_ok = new List<string>();
            List<int> keywordfinalid = new List<int>();
            List<int> keywordfinal = new List<int>();
            List<string> moviekw = new List<string>();


            List<int> languageid=new List<int>();
            List<string> language=new List<string>();
            List<string> language_ok=new List<string>();
            List<int> languagefinalid = new List<int>();
            List<int> languagefinal = new List<int>();
            List<string> movielanguage = new List<string>();

            List<int> directorid = new List<int>();
            List<string> director = new List<string>();
            List<string> director_ok = new List<string>();
            List<int> directorfinalid = new List<int>();
            List<int> directorfinal = new List<int>();
            List<string> moviedirector = new List<string>();

            List<int> countryid = new List<int>();
            List<string> country = new List<string>();
            List<string> country_ok = new List<string>();
            List<int> countryfinalid = new List<int>();
            List<int> countryfinal = new List<int>();
            List<string> moviecountry = new List<string>();

            List<int> movieID = new List<int>();



            conn.getMoviedata(ref movieID, ref moviekw, ref movielanguage, ref moviedirector, ref moviecountry);
            int decide = Options();
            switch (decide)
            {
                case 0:
                    conn.keywordPrepare(ref keywords);
                    Matches(keywords, ref keywords_ok);
                    idGenerate(ref keywordsid, keywords_ok);
                    FillUp_K(keywordsid, keywords_ok, ref cmds);
                    conn.DbWrite(cmds);
                    cmds.Clear();
                    break;
                case 1:
                    conn.keywordPrepare(ref keywords);
                    Matches(keywords, ref keywords_ok);
                    idGenerate(ref keywordsid, keywords_ok);

                    createData(keywordsid, keywords_ok, movieID, moviekw, ref keywordfinalid, ref keywordfinal);
                    FillUp_MK(keywordfinalid, keywordfinal, ref cmds);
                    conn.DbWrite(cmds);
                    cmds.Clear();
                    break;
                case 2:
                    conn.languagePrepare(ref language);
                    Matches(language, ref language_ok);
                    idGenerate(ref languageid, language_ok);
                    FillUp_L(languageid, language_ok, ref cmds);
                    conn.DbWrite(cmds);
                    cmds.Clear();
                    break;
                case 3:
                    conn.languagePrepare(ref language);
                    Matches(language, ref language_ok);
                    idGenerate(ref languageid, language_ok);

                    createData(languageid, language_ok, movieID, movielanguage, ref languagefinalid, ref languagefinal);
                    FillUp_ML(languagefinalid, languagefinal, ref cmds);
                    conn.DbWrite(cmds);
                    cmds.Clear();
                    break;
                case 4:
                    conn.directorPrepare(ref director);
                    Matches(director, ref director_ok);
                    idGenerate(ref directorid, director_ok);
                    FillUp_D(directorid, director_ok, ref cmds);
                    conn.DbWrite(cmds);
                    cmds.Clear();
                    break;
                case 5:

                    conn.directorPrepare(ref director);
                    Matches(director, ref director_ok);
                    idGenerate(ref directorid, director_ok);

                    createData(directorid, director_ok, movieID, moviedirector, ref directorfinalid, ref directorfinal);
                    FillUp_MD(directorfinalid, directorfinal, ref cmds);
                    conn.DbWrite(cmds);
                    cmds.Clear();
                    break;

                case 6:
                    conn.countryPrepare(ref country);
                    Matches(country, ref country_ok);
                    idGenerate(ref  countryid, country_ok);
                    FillUp_C(countryid, country_ok, ref cmds);
                    conn.DbWrite(cmds);
                    cmds.Clear();
                    break;

                case 7:
                    conn.countryPrepare(ref country);
                    Matches(country, ref country_ok);
                    idGenerate(ref countryid, country_ok);

                    createData(countryid, country_ok, movieID, moviecountry, ref countryfinalid, ref countryfinal);
                    FillUp_MC(countryfinalid, countryfinal, ref cmds);
                    conn.DbWrite(cmds);
                    cmds.Clear();
                    break;
            }



        }

        static void createData(List<int> id, List<string> list_ok, List<int> movieID, List<string> movieData, ref List<int> finalID, ref List<int> finalData)
        {
            for (int i = 0; i < movieID.Count; i++)
            {
                for(int j = 0; j<id.Count; j++)
                {
                    //if (mkw[i].Contains(" "+kw[j]+","))
                    if (movieData[i].Equals(list_ok[j]) || movieData[i].StartsWith(list_ok[j] + ",") || movieData[i].Contains(", " + list_ok[j] + ",") || movieData[i].EndsWith(" " + list_ok[j]))
                    {
                        finalID.Add(Convert.ToInt32(movieID[i]));
                        finalData.Add(Convert.ToInt32(id[j]));
                    }
                }
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
        static void Matches(List<string> list, ref List<string> list_ok)
        {
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
        }

        static void idGenerate(ref List<int> id, List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                id.Add(i + 1);
            }
        }

        static int Options()
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

            while(beolvasas!=true)
            {
                beolvasas=int.TryParse(Console.ReadLine(), out szam);
                if (szam < 0 || szam > 7)
                {
                    beolvasas = false;
                }
            }
            return szam;
        }

    }
}

