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
        /// <summary>
        /// A film Tmdb pontszámára vonatkozó becslés döntési fa használatával
        /// </summary>
        /// <param name="moviesL">A filmek darabszámát, illetve egyszerű, egy adatot tartalmazó tulajdonságait innen érjük el</param>
        /// <param name="prop">A lebontott tulajdonságok adatait a prop változó tömbjei tartalmazzák</param>
        public void BuildTree(List<Movie> moviesL, PropertiesForDecTree prop)
        {
            var mlContext = new MLContext();
            //A tanító adatokat tartalmazó lista létrehozása és feltöltése, ez esetben az adatbázis első 20 darab film megfelelő adataival
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

            // Egyéni séma definíció létrehozása annak érdekében, hogy dinamikus legyen a vektor mérete
            var schemaDef = SchemaDefinition.Create(typeof(Tmdb));
            schemaDef["Keyword"].ColumnType = new VectorDataViewType(NumberDataViewType.Int32, prop.KeywordAll.Count);
            schemaDef["Genre"].ColumnType = new VectorDataViewType(NumberDataViewType.Int32, prop.GenreAll.Count);

            // Adatok betöltése az egyéni séma használatával
            var data = mlContext.Data.LoadFromEnumerable(movies, schemaDef);

            // A betültött adatok átalakítása megfelelő formába
            var dataProcessPipeline = mlContext.Transforms.Conversion.ConvertType(nameof(Tmdb.TmdbScore), nameof(Tmdb.TmdbScore), DataKind.Single)
                .Append(mlContext.Transforms.Conversion.ConvertType("KeywordEncoded", nameof(Tmdb.Keyword), DataKind.Single))
                .Append(mlContext.Transforms.Conversion.ConvertType("GenreFloat", nameof(Tmdb.Genre), DataKind.Single))
                .Append(mlContext.Transforms.Concatenate("Features", "KeywordEncoded", "GenreFloat"))
                .AppendCacheCheckpoint(mlContext);

            // A modell típusának beállítása, amely ebben az esetben regressziót használó FastTree, és paramétereinek értékének beállítása
            var trainer = mlContext.Regression.Trainers.FastTree(
                labelColumnName: nameof(Tmdb.TmdbScore),
                featureColumnName: "Features",
                numberOfLeaves: 20,
                numberOfTrees: 150,
                minimumExampleCountPerLeaf: 8
            );

            var trainingPipeline = dataProcessPipeline.Append(trainer);


            var model = trainingPipeline.Fit(data); // Modell tanítása a Fit() metódussal

            // A betanított modell kiértékelése
            var predictions = model.Transform(data);
            var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: nameof(Tmdb.TmdbScore));

            Console.WriteLine($"R^2: {metrics.RSquared}");
            Console.WriteLine($"Mean Absolute Error: {metrics.MeanAbsoluteError}");
            Console.WriteLine($"Mean Squared Error: {metrics.MeanSquaredError}");

            // Egy darab film Tmdb pontszámának megbecslése a modell használatával
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Tmdb, TmdbPredict>(model, inputSchemaDefinition: schemaDef);
            /*int film = 19;
            Console.WriteLine(moviesL[film].Title);
            var testMovie = new Tmdb  // A becsléshez használt adattagok feltöltése a megbecsülendő film megfelelő adataival
            {
                Genre = prop.GenreContains[film],
                Keyword = prop.KeywordContains[film]
            };
            var prediction = predictionEngine.Predict(testMovie); // A tényleges becslés elvégzése

            Console.WriteLine($"Predicted TmdbScore: {prediction.PredictedTmdb}");*/
            for (int i = 59; i < 79; i++)
            {
                var testMovie = new Tmdb
                {
                    Genre = prop.GenreContains[i],
                    Keyword = prop.KeywordContains[i],
                };
                var prediction = predictionEngine.Predict(testMovie);
                Console.WriteLine($"Title:{moviesL[i].Title} Predicted Tmdb: {prediction.PredictedTmdb}");

            }
        }
    }

}

