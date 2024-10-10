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
    internal class DecTreeForDirector
    {
        public void BuildTree(List<Movie> moviesL, PropertiesForDecTree prop)
        {
            double efficiency = 0;
            var mlContext = new MLContext();


            var movies = new List<Director>();

            for (int i = 80; i < moviesL.Count; i++)
            {
                Director newDirector = new Director { Genre = prop.GenreContains[i], Keyword = prop.KeywordContains[i], Dir = moviesL[i].DirectorString[0] };
                movies.Add(newDirector);
            }

            var data = mlContext.Data.LoadFromEnumerable(movies);


            var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(Director.Dir))
    .Append(mlContext.Transforms.Conversion.ConvertType("KeywordEncoded", nameof(Director.Keyword), DataKind.Single))
    .Append(mlContext.Transforms.Conversion.ConvertType("GenreFloat", nameof(Director.Genre), DataKind.Single))
    .Append(mlContext.Transforms.Concatenate("Features", "KeywordEncoded", "GenreFloat"))
    .AppendCacheCheckpoint(mlContext);

            var trainer = mlContext.MulticlassClassification.Trainers.OneVersusAll(
    mlContext.BinaryClassification.Trainers.FastTree(
        labelColumnName: "Label",
        featureColumnName: "Features",
        numberOfLeaves: 9,
        numberOfTrees: 220,
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

            // Egy film előrejelzése
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Director, DirectorPredict>(model);
            /* int film = 2;
             Console.WriteLine(moviesL[film].Title);
             var testMovie = new Director { Genre = prop.GenreContains[film], Keyword = prop.KeywordContains[film] };
             var prediction = predictionEngine.Predict(testMovie);

             Console.WriteLine($"Predicted director's name: {prediction.PredictedDirector}");
            */
            for (int i = 59; i < 79; i++)
            {
                var testMovie = new Director
                {
                    Genre = prop.GenreContains[i],
                    Keyword = prop.KeywordContains[i],
                };
                var prediction = predictionEngine.Predict(testMovie);
                Console.WriteLine($"Title:{moviesL[i].Title} Predicted Director: {prediction.PredictedDirector}");
                if(moviesL[i].DirectorStringWithCommas== prediction.PredictedDirector)
                {
                    efficiency++;
                }

            }
            efficiency = efficiency / 20;
            Console.WriteLine("Efficiency: "+efficiency);
        }
    }
}
