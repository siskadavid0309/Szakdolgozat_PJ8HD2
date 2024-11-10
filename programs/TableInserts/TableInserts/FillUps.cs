using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableInserts
{
    internal class FillUps
    {
        
         public void Genres(List<int> ids, List<string> filteredGenres, ref List<string> cmds)
        {
            cmds.AddRange(ids.Select((id, index) => 
            string.Format("INSERT INTO \"Genres\" (\"ID\", \"Genre_Name\") VALUES ({0}, \"{1}\");", id, filteredGenres[index])));
        }


        public void MoviesGenres(List<int> finalId, List<int> finalGenre, ref List<string> cmds)
        {
            cmds.AddRange(finalId.Select((id, index) =>
            string.Format("INSERT INTO \"Movies_Genres\" (\"Movie_ID\", \"Genres_ID\") VALUES ({0}, {1});", id, finalGenre[index])));
            
        }
        public void MoviesKeywords (List<int> finalId, List<int> finalKeyword, ref List<string> cmds)
        {
            cmds.AddRange(finalId.Select((id, index) =>
            string.Format("INSERT INTO \"Movies_Keywords\" (\"Movie_ID\", \"Keywords_ID\") VALUES ({0}, {1});", id, finalKeyword[index])));
            
        }

        public void Keywords (List<int> ids, List<string> filteredKeywords, ref List<string> cmds)
        {
            cmds.AddRange(ids.Select((id, index) =>
            string.Format("INSERT INTO \"Keywords\" (\"ID\", \"Keyword_Name\") VALUES ({0}, \"{1}\");", id, filteredKeywords[index])));
            
        }

        public void Languages (List<int> ids, List<string> filteredLanguages, ref List<string> cmds)
        {
            cmds.AddRange(ids.Select((id, index) =>
            string.Format("INSERT INTO \"Languages\" (\"ID\", \"Language_Name\") VALUES ({0}, \"{1}\");", id, filteredLanguages[index])));
            
        }

        public void MoviesLanguages (List<int> finalId, List<int> finalLanguage, ref List<string> cmds)
        {
            cmds.AddRange(finalId.Select((id, index) =>
            string.Format("INSERT INTO \"Movies_Languages\" (\"Movie_ID\", \"Languages_ID\") VALUES ({0}, {1});", id, finalLanguage[index])));
            
        }

        public void Directors (List<int> ids, List<string> filteredDirectors, ref List<string> cmds)
        {
            cmds.AddRange(ids.Select((id, index) =>
            string.Format("INSERT INTO \"Directors\" (\"ID\", \"Director_Name\") VALUES ({0}, \"{1}\");", id, filteredDirectors[index])));
            
        }

        public void MoviesDirectors (List<int> finalId, List<int> finalDirector, ref List<string> cmds)
        {
            cmds.AddRange(finalId.Select((id, index) =>
            string.Format("INSERT INTO \"Movies_Directors\" (\"Movie_ID\", \"Directors_ID\") VALUES ({0}, {1});", id, finalDirector[index])));
            
        }

        public void Countries (List<int> ids, List<string> filteredCountries, ref List<string> cmds)
        {
            cmds.AddRange(ids.Select((id, index) =>
            string.Format("INSERT INTO \"Countries\" (\"ID\", \"Country_Name\") VALUES ({0},\"{1}\");", id, filteredCountries[index])));
            
        }

        public void MoviesCountries (List<int> finalId, List<int> finalCountry, ref List<string> cmds)
        {
            cmds.AddRange(finalId.Select((id, index) =>
            string.Format("INSERT INTO \"Movies_Countries\" (\"Movie_ID\", \"Countries_ID\") VALUES ({0}, {1});", id, finalCountry[index])));
            
        }
    }
}
