using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem
{
    internal class Gender
    {
        public string MainActor { get; set; }
        public float TmdbScore { get; set; }
        public float Popularity { get; set; }
         [VectorType(17)]
        public int[] Genre {get; set; }
        public int GenderOfProtagonist { get; set; }

    }
}
