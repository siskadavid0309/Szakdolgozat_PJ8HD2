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
        public void Build(List<Movie> moviesL)
        {
            var mlContext = new MLContext();

            // Példa adatok
            var movies = new List<Language>
            {
                new Language { GenderOfProtagonist = 2, MainActor = "Audrey Hepburn", TmdbScore = 8.2f, Lang = "English" }, // Sabrina
new Language { GenderOfProtagonist = 2, MainActor = "Marlon Brando", TmdbScore = 8.2f, Lang = "Hungarian" }, // A keresztapa
new Language { GenderOfProtagonist = 1, MainActor = "Akira Kurosawa", TmdbScore = 3.7f, Lang = "Japanese" }, // A hét szamuráj
                /*new Language { GenderOfProtagonist = moviesL[0].GenderOfProtagonist, MainActor = moviesL[0].MainActor, TmdbScore = 1.0f, Lang = GetLanguage(moviesL[0].LanguageString) },
                new Language { GenderOfProtagonist = moviesL[1].GenderOfProtagonist, MainActor = moviesL[1].MainActor, TmdbScore = 1.8f, Lang = GetLanguage(moviesL[1].LanguageString) },
               // new Language { GenderOfProtagonist = moviesL[2].GenderOfProtagonist, MainActor = moviesL[2].MainActor, TmdbScore = 1.9f, Lang = GetLanguage(moviesL[2].LanguageString) }
                new Language { GenderOfProtagonist = moviesL[2].GenderOfProtagonist, MainActor = moviesL[2].MainActor, TmdbScore = 0.7f, Lang = "Német" }*/
            };

            // Az adatok betöltése IDataView formátumba
            var data = mlContext.Data.LoadFromEnumerable(movies);

            // Az adatok előkészítése: kategóriák és numerikus jellemzők transzformációja
            var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(Language.Lang))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("GenderOfProtagonistEncoded", nameof(Language.GenderOfProtagonist)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("MainActorEncoded", nameof(Language.MainActor)))
                .Append(mlContext.Transforms.Concatenate("Features", "GenderOfProtagonistEncoded", "MainActorEncoded", nameof(Language.TmdbScore)))
                .AppendCacheCheckpoint(mlContext);

            // Többosztályos osztályozó modell létrehozása
            var trainer = mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features");
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
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Language, LanguagePredict>(model);
            var testMovie = new Language { GenderOfProtagonist = 2, MainActor = "Marlon Brando", TmdbScore = 8.0f };
            var prediction = predictionEngine.Predict(testMovie);

            Console.WriteLine($"Predicted language: {prediction.PredictedLanguage}");
        }
        
        public void Build2(List<Movie> moviesL)
        {
    var mlContext = new MLContext();

            // Példa adatok
            var movies = new List<Language>();

            for(int i = 20; i < moviesL.Count; i++)
            {
                Language newLanguage = new Language { GenderOfProtagonist = moviesL[i].GenderOfProtagonist, MainActor = moviesL[i].MainActor, Lang = moviesL[i].LanguageStringWithCommas };
                movies.Add(newLanguage);
            }
    // Az adatok betöltése IDataView formátumba
    var data = mlContext.Data.LoadFromEnumerable(movies);

    // Az adatok előkészítése: kategóriák és numerikus jellemzők transzformációja
    var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(Language.Lang))
        .Append(mlContext.Transforms.Categorical.OneHotEncoding("GenderOfProtagonistEncoded", nameof(Language.GenderOfProtagonist)))
        .Append(mlContext.Transforms.Categorical.OneHotEncoding("MainActorEncoded", nameof(Language.MainActor)))
        .Append(mlContext.Transforms.Concatenate("Features", "GenderOfProtagonistEncoded", "MainActorEncoded", nameof(Language.TmdbScore)))
        .AppendCacheCheckpoint(mlContext);

          
            var trainer = mlContext.MulticlassClassification.Trainers.OneVersusAll(
    mlContext.BinaryClassification.Trainers.FastTree(
        labelColumnName: "Label",
        featureColumnName: "Features",
        numberOfLeaves: 5,
        numberOfTrees: 30,
        minimumExampleCountPerLeaf: 1
        //learningRate: 0.1
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
    var predictionEngine = mlContext.Model.CreatePredictionEngine<Language, LanguagePredict>(model);
            int film = 91;
    var testMovie = new Language { GenderOfProtagonist = moviesL[film].GenderOfProtagonist, MainActor = moviesL[film].MainActor, TmdbScore = (float)moviesL[film].TmdbScore };
    var prediction = predictionEngine.Predict(testMovie);

    Console.WriteLine($"Predicted language: {prediction.PredictedLanguage}");
           

        }
        

      
    
}
}
