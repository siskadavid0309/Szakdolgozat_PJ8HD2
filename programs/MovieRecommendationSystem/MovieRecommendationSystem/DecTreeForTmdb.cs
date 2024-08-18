using Microsoft.ML.Data;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem
{
    internal class DecTreeForTmdb
    {
        public void BuildTree(List<Movie> moviesL, PropertiesForDecTree prop)
        {
            var mlContext = new MLContext();

            var movies = new List<Tmdb>();

            for (int i = 20; i < moviesL.Count; i++)
            {
                Tmdb newTmdb = new Tmdb
                {
                    Genre = prop.GenreContains[i],
                    Keyword = prop.KeywordContains[i],
                    TmdbScore = (float)moviesL[i].TmdbScore
                };
                movies.Add(newTmdb);
            }

            var data = mlContext.Data.LoadFromEnumerable(movies);

            // Adatfeldolgozási csővezeték
            var dataProcessPipeline = mlContext.Transforms.Conversion.ConvertType(nameof(Tmdb.TmdbScore), nameof(Tmdb.TmdbScore), DataKind.Single)
                .Append(mlContext.Transforms.Conversion.ConvertType("KeywordEncoded", nameof(Tmdb.Keyword), DataKind.Single))
                .Append(mlContext.Transforms.Conversion.ConvertType("GenreFloat", nameof(Tmdb.Genre), DataKind.Single))
                .Append(mlContext.Transforms.Concatenate("Features", "KeywordEncoded", "GenreFloat"))
                .AppendCacheCheckpoint(mlContext);



            // Regressziós modell beállítása (például FastTreeRegressionTrainer)
            var trainer = mlContext.Regression.Trainers.FastTree(
                labelColumnName: nameof(Tmdb.TmdbScore),
                featureColumnName: "Features",
                numberOfLeaves: 20,
                numberOfTrees: 150,
                minimumExampleCountPerLeaf: 8
            );


            var trainingPipeline = dataProcessPipeline
                .Append(trainer);

            // Modell tanítása
            var model = trainingPipeline.Fit(data);

            // Modell értékelése
            var predictions = model.Transform(data);
            var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: nameof(Tmdb.TmdbScore));

            Console.WriteLine($"R^2: {metrics.RSquared}");
            Console.WriteLine($"Mean Absolute Error: {metrics.MeanAbsoluteError}");
            Console.WriteLine($"Mean Squared Error: {metrics.MeanSquaredError}");

            // Egy film előrejelzése
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Tmdb, TmdbPredict>(model);
            int film = 19;
            Console.WriteLine(moviesL[film].Title);
            var testMovie = new Tmdb
            {
                Genre = prop.GenreContains[film],
                Keyword = prop.KeywordContains[film]
            };
            var prediction = predictionEngine.Predict(testMovie);

            Console.WriteLine($"Predicted TmdbScore: {prediction.PredictedTmdb}");
        }
    }
}
