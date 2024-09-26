using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem
{
    internal class PredictedScore
    {
        [ColumnName("Score")]
        public float PredictedSc { get; set; }
    }
}
