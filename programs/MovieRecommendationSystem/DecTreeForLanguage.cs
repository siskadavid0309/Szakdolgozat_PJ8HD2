using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using MovieRecommendationSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem
{
    internal class DecTreeForLanguage
    {

        public void CompareToHandmadeDecTree(List<Movie> moviesL)
        {
            double efficiency = 0;
            var mlContext = new MLContext();

            // Példa adatok
            var movies = new List<LanguageForCompareToHandmadeDecTree>();

            for (int i = 80; i < moviesL.Count; i++)
            {
                LanguageForCompareToHandmadeDecTree newLanguage = new LanguageForCompareToHandmadeDecTree
                {
                    Budget = moviesL[i].Budget,
                    Popularity = (float)moviesL[i].Popularity,
                    NumberOfRatings = moviesL[i].NumberOfRatings,
                    GenderOfProtagonist = moviesL[i].GenderOfProtagonist,
                    TmdbScore = (float)moviesL[i].TmdbScore,
                    Lang = moviesL[i].LanguageStringWithCommas
                };
                movies.Add(newLanguage);
            }
            // Az adatok betöltése IDataView formátumba
            var data = mlContext.Data.LoadFromEnumerable(movies);
            var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(LanguageForCompareToHandmadeDecTree.Lang))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("GenderOfProtagonistEncoded", nameof(LanguageForCompareToHandmadeDecTree.GenderOfProtagonist)))
                .Append(mlContext.Transforms.Conversion.ConvertType("BudgetFloat", nameof(LanguageForCompareToHandmadeDecTree.Budget), DataKind.Single))
                .Append(mlContext.Transforms.NormalizeMeanVariance("BudgetNormalized", "BudgetFloat"))
                .Append(mlContext.Transforms.NormalizeMeanVariance("PopularityNormalized", nameof(LanguageForCompareToHandmadeDecTree.Popularity)))
                .Append(mlContext.Transforms.Conversion.ConvertType("NumberOfRatingsFloat", nameof(LanguageForCompareToHandmadeDecTree.NumberOfRatings), DataKind.Single))
                .Append(mlContext.Transforms.Concatenate("Features", "GenderOfProtagonistEncoded", "BudgetNormalized", "PopularityNormalized",
                nameof(LanguageForCompareToHandmadeDecTree.TmdbScore), "NumberOfRatingsFloat"))
                .AppendCacheCheckpoint(mlContext);

            var trainer = mlContext.MulticlassClassification.Trainers.OneVersusAll(
            mlContext.BinaryClassification.Trainers.FastTree(
            labelColumnName: "Label",
            featureColumnName: "Features",
            numberOfLeaves: 5,
            numberOfTrees: 30,
            minimumExampleCountPerLeaf: 1
    )
);
            var trainingPipeline = dataProcessPipeline
        .Append(trainer)
        .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            // Modell tanítása
            var model = trainingPipeline.Fit(data);

            // Modell értékelése
            var predictions = model.Transform(data);
            var metrics = mlContext.MulticlassClassification.Evaluate(predictions);

            Console.WriteLine($"Log-loss: {metrics.LogLoss}");
            Console.WriteLine($"MicroAccuracy: {metrics.MicroAccuracy}");
            Console.WriteLine($"MacroAccuracy: {metrics.MacroAccuracy}");

            // Egy példa előrejelzés
            var predictionEngine = mlContext.Model.CreatePredictionEngine<LanguageForCompareToHandmadeDecTree, LanguagePredict>(model);

            for (int i = 59; i < 79; i++)
            {
                var testMovie = new LanguageForCompareToHandmadeDecTree
                {
                    Budget = moviesL[i].Budget,
                    Popularity = (float)moviesL[i].Popularity,
                    NumberOfRatings = moviesL[i].NumberOfRatings,
                    GenderOfProtagonist = moviesL[i].GenderOfProtagonist,
                    TmdbScore = (float)moviesL[i].TmdbScore,
                };
                var prediction = predictionEngine.Predict(testMovie);
                Console.WriteLine($"Title:{moviesL[i].Title} Predicted language: {prediction.PredictedLanguage}");
                if (moviesL[i].LanguageStringWithCommas == prediction.PredictedLanguage)
                {
                    efficiency++;
                }

            }
            efficiency = efficiency / 20;
            Console.WriteLine("Efficiency: " + efficiency);

        }

    }

}

