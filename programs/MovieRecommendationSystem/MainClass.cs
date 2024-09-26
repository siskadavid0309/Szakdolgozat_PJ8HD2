using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem
{
    internal class MainClass
    {
        public int Released { get; set; }
        public int Runtime { get; set; }
        public int GenderOfProtagonist { get; set; }
        public string MainActor { get; set; }
        public double TmdbScore { get; set; }
        public bool IsPopular { get; set; }
        public bool Blockbuster { get; set; }

        public double Score { get; set; }

        public int[] Genre { get; set; }
        public int[] Keyword { get; set; }
        public int[] Director { get; set; }
        public int[] Language { get; set; }
        public int[] ProductionCountry { get; set; }
    }
}
