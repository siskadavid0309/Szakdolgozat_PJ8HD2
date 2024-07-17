using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<int> Genre { get; set; }
        public int Released { get; set; }
        public int Runtime { get; set; }
        public int GenderOfProtagonist { get; set; }
        public string MainActor { get; set; }
        public List<int> Keyword { get; set; }
        public List<int> Director { get; set; }
        public List<int> Language { get; set; }
        public List<int> ProductionCountry { get; set; }
        public double TmdbScore { get; set; }
        public int NumberOfRatings { get; set; }
        public double Popularity { get; set; }
        public long Budget { get; set; }
        public long Revenue { get; set; }

        public List<string> GenreString {get; set;}
        public List<string> KeywordString {get; set;}
        public List<string> LanguageString {get; set;}
        public List<string> DirectorString {get; set;}
        public List<string> CountryString {get; set;}

        public string GenreStringWithCommas => string.Join(", ", GenreString);
        public string KeywordStringWithCommas => string.Join(", ", KeywordString);
        public string LanguageStringWithCommas => string.Join(", ", LanguageString);
        public string DirectorStringWithCommas => string.Join(", ", DirectorString);
        public string CountryStringWithCommas => string.Join(", ", CountryString);
    }
}
