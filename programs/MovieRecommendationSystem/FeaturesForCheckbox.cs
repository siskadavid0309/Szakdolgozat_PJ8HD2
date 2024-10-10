using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem
{
    /// <summary>
    /// Adattagok, amelyekben filmekben a válaszlehetőségként szolgáló adatai tárolódnak
    /// </summary>
    internal class FeaturesForCheckbox
    {
        public List<string> MainActor { get; set; }
        public List<string> Genre { get; set; }
        public List<string> Keyword { get; set; }
        public List<string> Language { get; set; }
        public List<string> Director { get; set; }
        public List<string> Country { get; set; }
    }
}
