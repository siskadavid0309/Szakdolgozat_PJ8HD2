using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem
{
    internal class Tmdb
    {
        public int[] Keyword { get; set; }
        public int[] Genre { get; set; }
        public double TmdbScore { get; set; }

    }
}
