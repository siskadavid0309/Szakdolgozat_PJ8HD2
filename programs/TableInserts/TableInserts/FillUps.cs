using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableInserts
{
    internal class FillUps
    {
        
         public void Genres(List<int> ids, List<string> genres_ok, ref List<string> cmds)
        {
            cmds.AddRange(ids.Select((id, index) => 
            string.Format("INSERT INTO \"Genres\" (\"ID\", \"Genre_Name\") VALUES ({0}, \"{1}\");", id, genres_ok[index])));
        }


        public void MoviesGenres(List<int> finalID, List<int> finalGenre, ref List<string> cmds)
        {
            cmds.AddRange(finalID.Select((id, index) =>
            string.Format("INSERT INTO \"Movies_Genres\" (\"Movie_ID\", \"Genres_ID\") VALUES ({0}, {1});", id, finalGenre[index])));
            
        }
        public void MoviesKeywords (List<int> finalID, List<int> finalKw, ref List<string> cmds)
        {
            cmds.AddRange(finalID.Select((id, index) =>
            string.Format("INSERT INTO \"Movies_Keywords\" (\"Movie_ID\", \"Keywords_ID\") VALUES ({0}, {1});", id, finalKw[index])));
            
        }

        public void Keywords (List<int> ids, List<string> keywords_ok, ref List<string> cmds)
        {
            cmds.AddRange(ids.Select((id, index) =>
            string.Format("INSERT INTO \"Keywords\" (\"ID\", \"Keyword_Name\") VALUES ({0}, {1});", id, keywords_ok[index])));
            
        }

        public void Languages (List<int> languageid, List<string> language_ok, ref List<string> cmds)
        {
            cmds.AddRange(languageid.Select((id, index) =>
            string.Format("INSERT INTO \"Languages\" (\"ID\", \"Language_Name\") VALUES ({0}, {1});",id, language_ok[index])));
            
        }

        public void MoviesLanguages (List<int> finalLanguageId, List<int> finalLanguage, ref List<string> cmds)
        {
            cmds.AddRange(finalLanguageId.Select((id, index) =>
            string.Format("INSERT INTO \"Movies_Languages\" (\"Movie_ID\", \"Languages_ID\") VALUES ({0}, {1});", id, finalLanguage[index])));
            
        }

        public void Directors (List<int> directorId, List<string> director_ok, ref List<string> cmds)
        {
            cmds.AddRange(directorId.Select((id, index) =>
            string.Format("INSERT INTO \"Directors\" (\"ID\", \"Director_Name\") VALUES ({0}, {1});", id, director_ok[index])));
            
        }

        public void MoviesDirectors (List<int> finalDirectorId, List<int> finalDirector, ref List<string> cmds)
        {
            cmds.AddRange(finalDirectorId.Select((id, index) =>
            string.Format("INSERT INTO \"Movies_Directors\" (\"Movie_ID\", \"Directors_ID\") VALUES ({0}, {1});", id, finalDirector[index])));
            
        }

        public void Countries (List<int> countryId, List<string> country_ok, ref List<string> cmds)
        {
            cmds.AddRange(countryId.Select((id, index) =>
            string.Format("INSERT INTO \"Countries\" (\"ID\", \"Country_Name\") VALUES ({0},{1});", id, country_ok[index])));
            
        }

        public void MoviesCountries (List<int> finalCountryId, List<int> finalCountry, ref List<string> cmds)
        {
            cmds.AddRange(finalCountryId.Select((id, index) =>
            string.Format("INSERT INTO \"Movies_Countries\" (\"Movie_ID\", \"Countries_ID\") VALUES ({0}, {1});", id, finalCountry[index])));
            
        }
    }
}
