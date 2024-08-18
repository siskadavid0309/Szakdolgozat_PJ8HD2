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
        [VectorType(946)]
        public int[] Keyword { get; set; }
        [VectorType(17)]
        public int[] Genre { get; set; }
        public double TmdbScore { get; set; }

    }
}
