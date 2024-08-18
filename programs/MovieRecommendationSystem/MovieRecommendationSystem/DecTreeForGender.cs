using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRecommendationSystem
{
    internal class DecTreeForGender
    {
        public void BuildTree(List<Movie> moviesL, PropertiesForDecTree prop)
        {
            var mlContext = new MLContext();

            // Példa adatok
            var movies = new List<Gender>();

            for (int i = 80; i < moviesL.Count; i++)
            {
                Gender newGender = new Gender { MainActor = moviesL[i].MainActor, TmdbScore = (float)moviesL[i].TmdbScore, Popularity = (float)moviesL[i].Popularity, Genre=prop.GenreContains[i], GenderOfProtagonist = moviesL[i].GenderOfProtagonist, };
                movies.Add(newGender);
            }
            // Az adatok betöltése IDataView formátumba
            var data = mlContext.Data.LoadFromEnumerable(movies);

            // Az adatok előkészítése: kategóriák és numerikus jellemzők transzformációja
            /*var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(Gender.GenderOfProtagonist))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("GenderOfProtagonistEncoded", nameof(Gender.MainActor)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("MainActorEncoded", nameof(Language.TmdbScore)))
                .Append(mlContext.Transforms.Concatenate("Features", "GenderOfProtagonistEncoded", "MainActorEncoded", nameof(Gender.Popularity)))
                .AppendCacheCheckpoint(mlContext);
            */

            
            var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(Gender.GenderOfProtagonist))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("MainActorEncoded", nameof(Gender.MainActor)))
                // Convert Genre from int[] to float[]
                .Append(mlContext.Transforms.Conversion.ConvertType("GenreFloat", nameof(Gender.Genre), DataKind.Single))
                // Concatenate all features
                .Append(mlContext.Transforms.Concatenate("Features", "MainActorEncoded", nameof(Gender.TmdbScore), nameof(Gender.Popularity), "GenreFloat"))
                .AppendCacheCheckpoint(mlContext);
            
            //nagyonteszt
           /* var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(Gender.GenderOfProtagonist))
                // Convert Genre from int[] to float[]
                .Append(mlContext.Transforms.Conversion.ConvertType("GenreFloat", nameof(Gender.Genre), DataKind.Single))
                // Concatenate all features
                .Append(mlContext.Transforms.Concatenate("Features", "GenreFloat"))
                .AppendCacheCheckpoint(mlContext);
            */

    
            var trainer = mlContext.MulticlassClassification.Trainers.OneVersusAll(
    mlContext.BinaryClassification.Trainers.FastTree(
        labelColumnName: "Label",
        featureColumnName: "Features",
        numberOfLeaves: 50,
        numberOfTrees: 7,
        minimumExampleCountPerLeaf: 10
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
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Gender, GenderPredict>(model);
            int film = 2;
            Console.WriteLine(moviesL[film].Title);
            var testMovie = new Gender { MainActor = moviesL[film].MainActor, TmdbScore = (float)moviesL[film].TmdbScore, Popularity = (float)moviesL[film].Popularity, Genre = prop.GenreContains[film] };
            var prediction = predictionEngine.Predict(testMovie);

            Console.WriteLine($"Predicted Gender: {prediction.PredictedGender}");


        }
    }
}
