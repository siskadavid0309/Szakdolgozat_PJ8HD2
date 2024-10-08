﻿using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem
{
    internal class Language
    {
        public int GenderOfProtagonist { get; set; }
        public string MainActor { get; set; }
        public float TmdbScore { get; set; }
        public string Lang { get; set; }
    }

    internal class LanguageForCompareToHandmadeDecTree
    {
        public int GenderOfProtagonist { get; set; }
        public float TmdbScore { get; set; }
        public float Popularity { get; set; }
        public long Budget { get; set; }
        public int NumberOfRatings { get; set; }
        public string Lang { get; set; }
    }
}
