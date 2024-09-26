using Microsoft.ML.Data;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableInsertsLibrary;

namespace MovieRecommendationSystem
{
    internal class MainDecTree
    {
        public void BuildTree(List<LearningMovie> learningMovies, List<Movie> moviesOriginal, PropertiesForDecTree prop)
        {
            List<float> predictedValues = new List<float>();
            var mlContext = new MLContext();

            // Tanító adatokat tartalmazó lista feltöltése
            var movies = new List<MainClass>();

            for (int i = 0; i < learningMovies.Count; i++)
            {
                MainClass newMainClass = new MainClass
                {
                    Released = learningMovies[i].Released,
                    Runtime = learningMovies[i].Runtime,
                    GenderOfProtagonist = learningMovies[i].GenderOfProtagonist,
                    MainActor = learningMovies[i].MainActor, // Ezt át kell alakítani
                    TmdbScore = learningMovies[i].TmdbScore,
                    IsPopular = learningMovies[i].IsPopular, // Boolean átalakítás
                    Blockbuster = learningMovies[i].Blockbuster, // Boolean átalakítás
                    Score = learningMovies[i].Score,
                    Genre = learningMovies[i].Genre,
                    Keyword = learningMovies[i].Keyword,
                    Director = learningMovies[i].Director,
                    Language = learningMovies[i].Language,
                    ProductionCountry = learningMovies[i].ProductionCountry,
                   // MainActor = learningMovies[i].MainActor,
                };
                movies.Add(newMainClass);
            }

            // Egyéni séma definiálása
            var schemaDef = SchemaDefinition.Create(typeof(MainClass));
            schemaDef["Keyword"].ColumnType = new VectorDataViewType(NumberDataViewType.Int32, prop.KeywordAll.Count);
            schemaDef["Genre"].ColumnType = new VectorDataViewType(NumberDataViewType.Int32, prop.GenreAll.Count);
            schemaDef["Director"].ColumnType = new VectorDataViewType(NumberDataViewType.Int32, prop.DirectorAll.Count);
            schemaDef["Language"].ColumnType = new VectorDataViewType(NumberDataViewType.Int32, prop.LanguageAll.Count);
            schemaDef["ProductionCountry"].ColumnType = new VectorDataViewType(NumberDataViewType.Int32, prop.CountryAll.Count);

            var data = mlContext.Data.LoadFromEnumerable(movies, schemaDef);

            // Adatok előkészítése és átalakítások
            var dataProcessPipeline = mlContext.Transforms.Conversion.ConvertType(nameof(MainClass.Score), nameof(MainClass.Score), DataKind.Single)
    .Append(mlContext.Transforms.Text.FeaturizeText("MainActorEncoded", nameof(MainClass.MainActor))) // Szöveg featurizálása
    .Append(mlContext.Transforms.Conversion.ConvertType("KeywordEncoded", nameof(MainClass.Keyword), DataKind.Single))
    .Append(mlContext.Transforms.Conversion.ConvertType("GenreEncoded", nameof(MainClass.Genre), DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType("DirectorEncoded", nameof(MainClass.Director), DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType("LanguageEncoded", nameof(MainClass.Language), DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType("ProductionCountryEncoded", nameof(MainClass.ProductionCountry), DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType(nameof(MainClass.Released), outputKind: DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType(nameof(MainClass.Runtime), outputKind: DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType(nameof(MainClass.GenderOfProtagonist), outputKind: DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType(nameof(MainClass.TmdbScore), outputKind: DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType(nameof(MainClass.IsPopular), outputKind: DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType(nameof(MainClass.Blockbuster), outputKind: DataKind.Single))

                    
                    .Append(mlContext.Transforms.Concatenate("Features",
                        "Released", "Runtime", "GenderOfProtagonist", "MainActorEncoded", "TmdbScore",
                        "IsPopular", "Blockbuster", "KeywordEncoded", "GenreEncoded", "DirectorEncoded", "LanguageEncoded", "ProductionCountryEncoded"))
                    .AppendCacheCheckpoint(mlContext);
                    /*.Append(mlContext.Transforms.Concatenate("Features", "KeywordEncoded", "GenreEncoded", "DirectorEncoded", "LanguageEncoded", "ProductionCountryEncoded", "MainActorEncoded"))
                .AppendCacheCheckpoint(mlContext);*/

            // Modell tréningelés FastTree algoritmussal
            var trainer = mlContext.Regression.Trainers.FastTree(
                labelColumnName: nameof(MainClass.Score),
                featureColumnName: "Features",
                numberOfLeaves: 5,
                numberOfTrees: 50,
                minimumExampleCountPerLeaf: 6, //korábban 6
                learningRate: 0.1
            );

            var trainingPipeline = dataProcessPipeline.Append(trainer);

            // Modell tréningelése
            var model = trainingPipeline.Fit(data);

            // Modell kiértékelése
            var predictions = model.Transform(data);
            var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: nameof(MainClass.Score));

            Console.WriteLine($"R^2: {metrics.RSquared}");
            Console.WriteLine($"Mean Absolute Error: {metrics.MeanAbsoluteError}");
            Console.WriteLine($"Mean Squared Error: {metrics.MeanSquaredError}");

            // Predikció létrehozása
            var predictionEngine = mlContext.Model.CreatePredictionEngine<MainClass, PredictedScore>(model, inputSchemaDefinition: schemaDef);
            //int film = 6;
            //Console.WriteLine(learningMovies[film].MainActor); // Példa a kiértékeléshez
            for (int i = 0; i < moviesOriginal.Count; i++)
            {
                var testMovie = new MainClass
                {
                    Released = moviesOriginal[i].Released,
                    Runtime = moviesOriginal[i].Runtime,
                    GenderOfProtagonist = moviesOriginal[i].GenderOfProtagonist,
                    MainActor = moviesOriginal[i].MainActor, // Featurizált adat
                    TmdbScore = moviesOriginal[i].TmdbScore,
                    IsPopular = moviesOriginal[i].IsPopular,
                    Blockbuster = moviesOriginal[i].IsBlockbuster,
                    Genre = prop.GenreContains[i],
                    Keyword = prop.KeywordContains[i],
                    Director = prop.DirectorContains[i],
                    Language = prop.LanguageContains[i],
                    ProductionCountry = prop.CountryContains[i],
                    //MainActor = learningMovies[film].MainActor,
                };

                var prediction = predictionEngine.Predict(testMovie);
                predictedValues.Add(prediction.PredictedSc);
            }
            float max=float.MinValue;
            int index = 0;
            for(int i = 0;i < moviesOriginal.Count; i++)
            {
                Console.WriteLine(moviesOriginal[i].Title+": " + predictedValues[i]);
                moviesOriginal[i].Score = predictedValues[i];
                if (predictedValues[i] > max)
                {
                    max = predictedValues[i];
                    index = i;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Id: "+ moviesOriginal[index].Id +" Max: "+moviesOriginal[index].Title+": " + predictedValues[index]);

            //Console.WriteLine($"Predicted Score: {prediction.PredictedSc}");
        }
    }
}

