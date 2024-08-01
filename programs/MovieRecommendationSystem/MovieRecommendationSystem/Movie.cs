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
        public int Released { get; set; }
        public int Runtime { get; set; }
        public int GenderOfProtagonist { get; set; }
        public string MainActor { get; set; }
        public double TmdbScore { get; set; }
        public int NumberOfRatings { get; set; }
        public double Popularity { get; set; }
        public long Budget { get; set; }
        public long Revenue { get; set; }

        /// <summary>
        /// A kapcsolótáblák adatait felhasználva ezekbe az adattagokba kerülnek az egyes adatokat, pl. műfajokat azonosító integerek (id-k)
        /// </summary>
        public List<int> Genre { get; set; }
        public List<int> Keyword { get; set; }
        public List<int> Director { get; set; }
        public List<int> Language { get; set; }
        public List<int> ProductionCountry { get; set; }

        /// <summary>
        /// Az azonosító integereket (id)-kat felhasználva ezekbe a string listákba kerülnek a filmekhez kapcsolódó tényleges adatok
        /// </summary>
        public List<string> GenreString {get; set;}
        public List<string> KeywordString {get; set;}
        public List<string> LanguageString {get; set;}
        public List<string> DirectorString {get; set;}
        public List<string> CountryString {get; set;}

        /// <summary>
        /// Az előző listák felhasználásával a listákban szereplő adatok vesszővel történő összefűzése táblázatos megjelenítéshez
        /// </summary>
        public string GenreStringWithCommas => string.Join(", ", GenreString);
        public string KeywordStringWithCommas => string.Join(", ", KeywordString);
        public string LanguageStringWithCommas => string.Join(", ", LanguageString);
        public string DirectorStringWithCommas => string.Join(", ", DirectorString);
        public string CountryStringWithCommas => string.Join(", ", CountryString);
    }
}
