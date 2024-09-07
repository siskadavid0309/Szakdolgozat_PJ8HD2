using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem
{
    internal class PropertiesForDecTree
    {
        public List<string> GenreAll { get; set; }
        public List<string> KeywordAll { get; set; }
        public List<string> LanguageAll { get; set; }
        public List<string> DirectorAll { get; set; }
        public List<string> CountryAll { get; set; }

        public int[][] GenreContains { get; set; }
        public int[][] KeywordContains { get; set; }
        public int[][] LanguageContains { get; set; }
        public int[][] DirectorContains { get; set; }
        public int[][] CountryContains { get; set; }
    }
}
