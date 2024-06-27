using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableInserts
{
    internal class FillUps
    {
        public void G (List<int> ids, List<string> genres_ok, ref List<string> cmds)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Genres\" (\"ID\", \"Genre_Name\") VALUES ({0}, \"" + genres_ok[i] + "\");", ids[i]));
            }
        }

        public void MG (List<int> finalID, List<int> finalgenre, ref List<string> cmds)
        {
            for (int i = 0; i < finalID.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Movies_Genres\" (\"Movie_ID\", \"Genres_ID\") VALUES ({0}, {1});", finalID[i], finalgenre[i]));
            }
        }
        public void MK (List<int> finalID, List<int> finalkw, ref List<string> cmds)
        {
            for (int i = 0; i < finalID.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Movies_Keywords\" (\"Movie_ID\", \"Keywords_ID\") VALUES ({0}, {1});", finalID[i], finalkw[i]));
            }
        }

        public void K (List<int> ids, List<string> keywords_ok, ref List<string> cmds)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Keywords\" (\"ID\", \"Keyword_Name\") VALUES ({0}, \"" + keywords_ok[i] + "\");", ids[i]));
            }
        }

        public void L (List<int> languageid, List<string> language_ok, ref List<string> cmds)
        {
            for (int i = 0; i < languageid.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Languages\" (\"ID\", \"Language_Name\") VALUES ({0}, \"" + language_ok[i] + "\");", languageid[i]));
            }
        }

        public void ML (List<int> finallanguageid, List<int> finallanguage, ref List<string> cmds)
        {
            for (int i = 0; i < finallanguageid.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Movies_Languages\" (\"Movie_ID\", \"Languages_ID\") VALUES ({0}, {1});", finallanguageid[i], finallanguage[i]));
            }
        }

        public void D (List<int> directorid, List<string> director_ok, ref List<string> cmds)
        {
            for (int i = 0; i < directorid.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Directors\" (\"ID\", \"Director_Name\") VALUES ({0}, \"" + director_ok[i] + "\");", directorid[i]));
            }
        }

        public void MD (List<int> finaldirectorid, List<int> finaldirector, ref List<string> cmds)
        {
            for (int i = 0; i < finaldirectorid.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Movies_Directors\" (\"Movie_ID\", \"Directors_ID\") VALUES ({0}, {1});", finaldirectorid[i], finaldirector[i]));
            }
        }

        public void C (List<int> countryid, List<string> country_ok, ref List<string> cmds)
        {
            for (int i = 0; i < countryid.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Countries\" (\"ID\", \"Country_Name\") VALUES ({0}, \"" + country_ok[i] + "\");", countryid[i]));
            }
        }

        public void MC (List<int> finalcountryid, List<int> finalcountry, ref List<string> cmds)
        {
            for (int i = 0; i < finalcountryid.Count; i++)
            {
                cmds.Add(string.Format("INSERT INTO \"Movies_Countries\" (\"Movie_ID\", \"Countries_ID\") VALUES ({0}, {1});", finalcountryid[i], finalcountry[i]));
            }
        }
    }
}
