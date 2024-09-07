using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TableInsertsLibrary
{
    public class FillUpsTI
    {
        public void Genres(List<int> ids, List<string> genres_ok, ref List<string> cmds)
        {
            cmds.Add("BEGIN");
            cmds.AddRange(ids.Select((id, index) =>
            string.Format("INSERT INTO \"Genres\" (\"ID\", \"Genre_Name\") VALUES ({0}, \"{1}\");", id, genres_ok[index])));
            cmds.Add("COMMIT");
        }


        public void MoviesGenres(List<int> finalID, List<int> finalGenre, ref List<string> cmds)
        {
            cmds.Add("BEGIN");
            cmds.AddRange(finalID.Select((id, index) =>
            string.Format("INSERT INTO \"Movies_Genres\" (\"Movie_ID\", \"Genres_ID\") VALUES ({0}, {1});", id, finalGenre[index])));
            cmds.Add("COMMIT");

        }
        public void MoviesKeywords(List<int> finalID, List<int> finalKw, ref List<string> cmds)
        {
            cmds.Add("BEGIN");
            cmds.AddRange(finalID.Select((id, index) =>
            string.Format("INSERT INTO \"Movies_Keywords\" (\"Movie_ID\", \"Keywords_ID\") VALUES ({0}, {1});", id, finalKw[index])));
            cmds.Add("COMMIT");

        }

        public void Keywords(List<int> ids, List<string> keywords_ok, ref List<string> cmds)
        {
            cmds.Add("BEGIN");
            cmds.AddRange(ids.Select((id, index) =>
            string.Format("INSERT INTO \"Keywords\" (\"ID\", \"Keyword_Name\") VALUES ({0}, \"{1}\");", id, keywords_ok[index])));
            cmds.Add("COMMIT");
        }

        public void Languages(List<int> languageid, List<string> language_ok, ref List<string> cmds)
        {
            cmds.Add("BEGIN");
            cmds.AddRange(languageid.Select((id, index) =>
            string.Format("INSERT INTO \"Languages\" (\"ID\", \"Language_Name\") VALUES ({0}, \"{1}\");", id, language_ok[index])));
            cmds.Add("COMMIT");

        }

        public void MoviesLanguages(List<int> finalLanguageId, List<int> finalLanguage, ref List<string> cmds)
        {
            cmds.Add("BEGIN");
            cmds.AddRange(finalLanguageId.Select((id, index) =>
            string.Format("INSERT INTO \"Movies_Languages\" (\"Movie_ID\", \"Languages_ID\") VALUES ({0}, {1});", id, finalLanguage[index])));
            cmds.Add("COMMIT");

        }

        public void Directors(List<int> directorId, List<string> director_ok, ref List<string> cmds)
        {
            cmds.Add("BEGIN");
            cmds.AddRange(directorId.Select((id, index) =>
            string.Format("INSERT INTO \"Directors\" (\"ID\", \"Director_Name\") VALUES ({0}, \"{1}\");", id, director_ok[index])));
            cmds.Add("COMMIT");

        }
         
        public void MoviesDirectors(List<int> finalDirectorId, List<int> finalDirector, ref List<string> cmds)
        {
            cmds.Add("BEGIN");
            cmds.AddRange(finalDirectorId.Select((id, index) =>
            string.Format("INSERT INTO \"Movies_Directors\" (\"Movie_ID\", \"Directors_ID\") VALUES ({0}, {1});", id, finalDirector[index])));
            cmds.Add("COMMIT");

        }

        public void Countries(List<int> countryId, List<string> country_ok, ref List<string> cmds)
        {
            cmds.Add("BEGIN");
            cmds.AddRange(countryId.Select((id, index) =>
            string.Format("INSERT INTO \"Countries\" (\"ID\", \"Country_Name\") VALUES ({0},\"{1}\");", id, country_ok[index])));
            cmds.Add("COMMIT");

        }

        public void MoviesCountries(List<int> finalCountryId, List<int> finalCountry, ref List<string> cmds)
        {
            cmds.Add("BEGIN");
            cmds.AddRange(finalCountryId.Select((id, index) =>
            string.Format("INSERT INTO \"Movies_Countries\" (\"Movie_ID\", \"Countries_ID\") VALUES ({0}, {1});", id, finalCountry[index])));
            cmds.Add("COMMIT");

        }

        public List<string> UpdateDB()
        {
            List<string> command=new List<string>();
            string temp;

            temp = "DROP TABLE IF EXISTS Movies_Countries;";
            command.Add(temp);
            temp = "DROP TABLE IF EXISTS Movies_Directors;";
            command.Add(temp);
            temp = "DROP TABLE IF EXISTS Movies_Genres;";
            command.Add(temp);
            temp = "DROP TABLE IF EXISTS Movies_Keywords;";
            command.Add(temp);
            temp = "DROP TABLE IF EXISTS Movies_Languages;";
            command.Add(temp);
            temp = "DROP TABLE IF EXISTS Countries;";
            command.Add(temp);
            temp = "DROP TABLE IF EXISTS Directors;";
            command.Add(temp);
            temp = "DROP TABLE IF EXISTS Genres;";
            command.Add(temp);
            temp = "DROP TABLE IF EXISTS Keywords;";
            command.Add(temp);
            temp = "DROP TABLE IF EXISTS Languages;";
            command.Add(temp);


            temp = "CREATE TABLE \"Countries\" (\r\n\t\"ID\"\tINTEGER,\r\n\t\"Country_Name\"\tTEXT,\r\n\tPRIMARY KEY(\"ID\")\r\n);";
            command.Add(temp);
            temp = "CREATE TABLE \"Directors\" (\r\n\t\"ID\"\tINTEGER,\r\n\t\"Director_Name\"\tTEXT,\r\n\tPRIMARY KEY(\"ID\")\r\n);";
            command.Add(temp);
            temp = "CREATE TABLE \"Genres\" (\r\n\t\"ID\"\tINTEGER,\r\n\t\"Genre_Name\"\tTEXT,\r\n\tPRIMARY KEY(\"ID\")\r\n);";
            command.Add(temp);
            temp = "CREATE TABLE \"Keywords\" (\r\n\t\"ID\"\tINTEGER,\r\n\t\"Keyword_Name\"\tTEXT,\r\n\tPRIMARY KEY(\"ID\")\r\n);";
            command.Add(temp);
            temp = "CREATE TABLE \"Languages\" (\r\n\t\"ID\"\tINTEGER,\r\n\t\"Language_Name\"\tTEXT,\r\n\tPRIMARY KEY(\"ID\")\r\n);";
            command.Add(temp);
            temp = "CREATE TABLE \"Movies_Countries\" (\r\n\t\"Movie_ID\"\tINTEGER,\r\n\t\"Countries_ID\"\tINTEGER,\r\n\tPRIMARY KEY(\"Movie_ID\",\"Countries_ID\"),\r\n\tFOREIGN KEY(\"Countries_ID\") REFERENCES \"Countries\"(\"ID\"),\r\n\tFOREIGN KEY(\"Movie_ID\") REFERENCES \"Movies\"(\"ID\")\r\n);";
            command.Add(temp);
            temp = "CREATE TABLE \"Movies_Directors\" (\r\n\t\"Movie_ID\"\tINTEGER,\r\n\t\"Directors_ID\"\tINTEGER,\r\n\tFOREIGN KEY(\"Directors_ID\") REFERENCES \"Directors\"(\"ID\"),\r\n\tFOREIGN KEY(\"Movie_ID\") REFERENCES \"Movies\"(\"ID\"),\r\n\tPRIMARY KEY(\"Movie_ID\",\"Directors_ID\")\r\n);";
            command.Add(temp);
            temp = "CREATE TABLE \"Movies_Genres\" (\r\n\t\"Movie_ID\"\tINTEGER,\r\n\t\"Genres_ID\"\tINTEGER,\r\n\tFOREIGN KEY(\"Genres_ID\") REFERENCES \"Genres\"(\"ID\"),\r\n\tFOREIGN KEY(\"Movie_ID\") REFERENCES \"Movies\"(\"ID\"),\r\n\tPRIMARY KEY(\"Movie_ID\",\"Genres_ID\")\r\n);";
            command.Add(temp);
            temp = "CREATE TABLE \"Movies_Keywords\" (\r\n\t\"Movie_ID\"\tINTEGER,\r\n\t\"Keywords_ID\"\tINTEGER,\r\n\tFOREIGN KEY(\"Movie_ID\") REFERENCES \"Movies\"(\"ID\"),\r\n\tFOREIGN KEY(\"Keywords_ID\") REFERENCES \"Keywords\"(\"ID\"),\r\n\tPRIMARY KEY(\"Movie_ID\",\"Keywords_ID\")\r\n);";
            command.Add(temp);
            temp = "CREATE TABLE \"Movies_Languages\" (\r\n\t\"Movie_ID\"\tINTEGER,\r\n\t\"Languages_ID\"\tINTEGER,\r\n\tFOREIGN KEY(\"Languages_ID\") REFERENCES \"Languages\"(\"ID\"),\r\n\tFOREIGN KEY(\"Movie_ID\") REFERENCES \"Movies\"(\"ID\"),\r\n\tPRIMARY KEY(\"Movie_ID\",\"Languages_ID\")\r\n);";
            command.Add(temp);

            return command;
        }

       
    }
}
