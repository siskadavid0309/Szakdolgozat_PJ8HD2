using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem
{
    internal class FeaturesForCheckbox
    {
        //public int GenderOfProtagonist { get; set; }
        public List<string> MainActor { get; set; }
        //public bool IsPopular { get; set; }
        //public bool Blockbuster { get; set; }

        public List<string> Genre { get; set; }
        public List<string> Keyword { get; set; }
        public List<string> Language { get; set; }
        public List<string> Director { get; set; }
        public List<string> Country { get; set; }
    }
}
