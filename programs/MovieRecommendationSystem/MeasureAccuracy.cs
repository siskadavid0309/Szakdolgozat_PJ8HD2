using Microsoft.ML.Data;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem
{
    internal class MeasureAccuracy
    {
        public void Fasttree(List<Movie> moviesL, PropertiesForDecTree prop)
        {
            List<float> predictedTmdbs = new List<float>();


            var mlContext = new MLContext();
            //A tanító adatokat tartalmazó lista létrehozása és feltöltése, ez esetben az adatbázis első 20 darab film megfelelő adataival
            var movies = new List<Tmdb>();

            for (int i = 0; i < 20; i++)
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
                .Append(mlContext.Transforms.Conversion.ConvertType("KeywordFloat", nameof(Tmdb.Keyword), DataKind.Single))
                .Append(mlContext.Transforms.Conversion.ConvertType("GenreFloat", nameof(Tmdb.Genre), DataKind.Single))
                .Append(mlContext.Transforms.Concatenate("Features", "KeywordFloat", "GenreFloat"))
                .AppendCacheCheckpoint(mlContext);

            // A modell típusának beállítása, amely ebben az esetben regressziót használó FastTree, és paramétereinek értékének beállítása
            var trainer = mlContext.Regression.Trainers.FastTree(
                labelColumnName: nameof(Tmdb.TmdbScore),
                featureColumnName: "Features"
            );

            var trainingPipeline = dataProcessPipeline.Append(trainer);


            var model = trainingPipeline.Fit(data); // Modell tanítása a Fit() metódussal

            // A betanított modell kiértékelése
            var predictions = model.Transform(data);
            var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: nameof(Tmdb.TmdbScore));


            // Egy darab film Tmdb pontszámának megbecslése a modell használatával
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Tmdb, TmdbPredict>(model, inputSchemaDefinition: schemaDef);


            for (int i = 0; i < moviesL.Count; i++)
            {

                var testMovie = new Tmdb  // A becsléshez használt adattagok feltöltése a megbecsülendő film megfelelő adataival
                {
                    Genre = prop.GenreContains[i],
                    Keyword = prop.KeywordContains[i]
                };
                var prediction = predictionEngine.Predict(testMovie); // A tényleges becslés elvégzése                                                              

                predictedTmdbs.Add(prediction.PredictedTmdb);
            }
        

        Console.WriteLine("R^2 Fasttree: " + RSquare(moviesL,predictedTmdbs));
        }
        public void FasttreeTuned(List<Movie> moviesL, PropertiesForDecTree prop)
        {
            List<float> predictedTmdbs = new List<float>();
            Random random = new Random();
            double bestRSquared = double.MinValue;
            int bestLeaves = 0;
            int bestTrees = 0;
            int bestMinExample = 0;
            double bestLearningRate = 0;
 
            for (int j = 0; j < 200; j++) // 100 véletlenszerű keresés
            {
                /*int leaves = random.Next(10, 50); // numberOfLeaves: 2-től 100-ig
                int trees = random.Next(40, 400); // numberOfTrees: 50-től 300-ig
                int minExample = random.Next(2, 10); // minimumExampleCountPerLeaf: 1-től 10-ig
                double learningRate = random.NextDouble() * (0.2 - 0.01) + 0.01; // learningRate: 0.01-től 0.2-ig
                */
                int leaves = random.Next(2, 10); // numberOfLeaves: 2-től 30-ig
                int trees = random.Next(20, 200); // numberOfTrees: 20-tól 200-ig
                int minExample = random.Next(3, 10); // minimumExampleCountPerLeaf: 1-től 10-ig
                double learningRate = random.NextDouble() * (0.2 - 0.01) + 0.01;
                var mlContext = new MLContext();
                //A tanító adatokat tartalmazó lista létrehozása és feltöltése, ez esetben az adatbázis első 20 darab film megfelelő adataival
                var movies = new List<Tmdb>();

                for (int i = 0; i < 40; i++)
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
                    .Append(mlContext.Transforms.Conversion.ConvertType("KeywordFloat", nameof(Tmdb.Keyword), DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType("GenreFloat", nameof(Tmdb.Genre), DataKind.Single))
                    .Append(mlContext.Transforms.Concatenate("Features", "KeywordFloat", "GenreFloat"))
                    .AppendCacheCheckpoint(mlContext);

                // A modell típusának beállítása, amely ebben az esetben regressziót használó FastTree, és paramétereinek értékének beállítása
                var trainer = mlContext.Regression.Trainers.FastTree(
                    labelColumnName: nameof(Tmdb.TmdbScore),
                    featureColumnName: "Features",
                    numberOfLeaves: leaves,
                    numberOfTrees: trees,
                    minimumExampleCountPerLeaf: minExample,
                    learningRate: learningRate
                );

                var trainingPipeline = dataProcessPipeline.Append(trainer);


                var model = trainingPipeline.Fit(data); // Modell tanítása a Fit() metódussal

                // A betanított modell kiértékelése
                var predictions = model.Transform(data);
                var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: nameof(Tmdb.TmdbScore));


                // Egy darab film Tmdb pontszámának megbecslése a modell használatával
                var predictionEngine = mlContext.Model.CreatePredictionEngine<Tmdb, TmdbPredict>(model, inputSchemaDefinition: schemaDef);

                bestLeaves = leaves;
                bestTrees = trees;
                bestMinExample = minExample;
                bestLearningRate = learningRate;
                predictedTmdbs.Clear();
                for (int i = 0; i < moviesL.Count; i++)
                {

                    var testMovie = new Tmdb  // A becsléshez használt adattagok feltöltése a megbecsülendő film megfelelő adataival
                    {
                        Genre = prop.GenreContains[i],
                        Keyword = prop.KeywordContains[i]
                    };
                    var prediction = predictionEngine.Predict(testMovie); // A tényleges becslés elvégzése
                                                                         

                    predictedTmdbs.Add(prediction.PredictedTmdb);
                }
                if (bestRSquared < RSquare(moviesL, predictedTmdbs))
                {
                    bestRSquared = RSquare(moviesL, predictedTmdbs);
                }
            }
            Console.WriteLine();
            Console.WriteLine(bestRSquared);
            Console.WriteLine("Leaves: " + bestLeaves);
            Console.WriteLine("Trees: " + bestTrees);
            Console.WriteLine("MinExample: " + bestMinExample);
            Console.WriteLine("LearningRate: " + bestLearningRate);

            Console.WriteLine("R^2 FasttreeTuned: " + bestRSquared);
        }

        public void Sdca(List<Movie> moviesL, PropertiesForDecTree prop)
        {
            List<float> predictedTmdbs = new List<float>();


            var mlContext = new MLContext();
            //A tanító adatokat tartalmazó lista létrehozása és feltöltése, ez esetben az adatbázis első 20 darab film megfelelő adataival
            var movies = new List<Tmdb>();

            for (int i = 0; i < 20; i++)
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
                .Append(mlContext.Transforms.Conversion.ConvertType("KeywordFloat", nameof(Tmdb.Keyword), DataKind.Single))
                .Append(mlContext.Transforms.Conversion.ConvertType("GenreFloat", nameof(Tmdb.Genre), DataKind.Single))
                .Append(mlContext.Transforms.Concatenate("Features", "KeywordFloat", "GenreFloat"))
                .AppendCacheCheckpoint(mlContext);

            // A modell típusának beállítása, amely ebben az esetben regressziót használó FastTree, és paramétereinek értékének beállítása
            var trainer = mlContext.Regression.Trainers.Sdca(
                labelColumnName: nameof(Tmdb.TmdbScore),
                featureColumnName: "Features"
            );

            var trainingPipeline = dataProcessPipeline.Append(trainer);


            var model = trainingPipeline.Fit(data); // Modell tanítása a Fit() metódussal

            // A betanított modell kiértékelése
            var predictions = model.Transform(data);
            var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: nameof(Tmdb.TmdbScore));


            // Egy darab film Tmdb pontszámának megbecslése a modell használatával
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Tmdb, TmdbPredict>(model, inputSchemaDefinition: schemaDef);


            for (int i = 0; i < moviesL.Count; i++)
            {

                var testMovie = new Tmdb  // A becsléshez használt adattagok feltöltése a megbecsülendő film megfelelő adataival
                {
                    Genre = prop.GenreContains[i],
                    Keyword = prop.KeywordContains[i]
                };
                var prediction = predictionEngine.Predict(testMovie); // A tényleges becslés elvégzése                                                              

                predictedTmdbs.Add(prediction.PredictedTmdb);
            }


            Console.WriteLine("R^2 Sdca: " + RSquare(moviesL, predictedTmdbs));
        }

        public void SdcaTuned(List<Movie> moviesL, PropertiesForDecTree prop)
        {
            List<float> predictedTmdbs = new List<float>();
            Random random = new Random();
            double bestRSquared = double.MinValue;
            int bestmaxIterations = 0;
            float bestl2Regularization = 0;

            for (int j = 0; j < 200; j++) // 100 véletlenszerű keresés
            {
                int maxIterations = random.Next(10, 1000); // MaximumNumberOfIterations: 10-től 1000-ig
                double l2Regularization = random.NextDouble() * (1 - 0.0001) + 0.0001; // L2Regularization: 0.0001-től 1-ig
                //double biasLearningRate = random.NextDouble() * (1 - 0.01) + 0.01;

                var mlContext = new MLContext();
                //A tanító adatokat tartalmazó lista létrehozása és feltöltése, ez esetben az adatbázis első 20 darab film megfelelő adataival
                var movies = new List<Tmdb>();

                for (int i = 0; i < 40; i++)
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
                    .Append(mlContext.Transforms.Conversion.ConvertType("KeywordFloat", nameof(Tmdb.Keyword), DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType("GenreFloat", nameof(Tmdb.Genre), DataKind.Single))
                    .Append(mlContext.Transforms.Concatenate("Features", "KeywordFloat", "GenreFloat"))
                    .AppendCacheCheckpoint(mlContext);

                // A modell típusának beállítása, amely ebben az esetben regressziót használó FastTree, és paramétereinek értékének beállítása
                var trainer = mlContext.Regression.Trainers.Sdca(
                    labelColumnName: nameof(Tmdb.TmdbScore),
                    featureColumnName: "Features",
                    maximumNumberOfIterations: maxIterations,
                    l2Regularization: (float)l2Regularization
                );

                var trainingPipeline = dataProcessPipeline.Append(trainer);


                var model = trainingPipeline.Fit(data); // Modell tanítása a Fit() metódussal

                // A betanított modell kiértékelése
                var predictions = model.Transform(data);
                var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: nameof(Tmdb.TmdbScore));


                // Egy darab film Tmdb pontszámának megbecslése a modell használatával
                var predictionEngine = mlContext.Model.CreatePredictionEngine<Tmdb, TmdbPredict>(model, inputSchemaDefinition: schemaDef);

  
                predictedTmdbs.Clear();
                for (int i = 0; i < moviesL.Count; i++)
                {

                    var testMovie = new Tmdb  // A becsléshez használt adattagok feltöltése a megbecsülendő film megfelelő adataival
                    {
                        Genre = prop.GenreContains[i],
                        Keyword = prop.KeywordContains[i]
                    };
                    var prediction = predictionEngine.Predict(testMovie); // A tényleges becslés elvégzése


                    predictedTmdbs.Add(prediction.PredictedTmdb);
                }
                if (bestRSquared < RSquare(moviesL, predictedTmdbs))
                {
                    bestRSquared = RSquare(moviesL, predictedTmdbs);
                }
            }
            Console.WriteLine();
            Console.WriteLine("bestmaxIterations: " + bestmaxIterations);
            Console.WriteLine("l2: " + bestl2Regularization);


            Console.WriteLine("R^2 SdcaTuned: " + bestRSquared);
        }

        public void LbfgsPoissonRegression(List<Movie> moviesL, PropertiesForDecTree prop)
        {
            List<float> predictedTmdbs = new List<float>();


            var mlContext = new MLContext();
            //A tanító adatokat tartalmazó lista létrehozása és feltöltése, ez esetben az adatbázis első 20 darab film megfelelő adataival
            var movies = new List<Tmdb>();

            for (int i = 0; i < 20; i++)
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
                .Append(mlContext.Transforms.Conversion.ConvertType("KeywordFloat", nameof(Tmdb.Keyword), DataKind.Single))
                .Append(mlContext.Transforms.Conversion.ConvertType("GenreFloat", nameof(Tmdb.Genre), DataKind.Single))
                .Append(mlContext.Transforms.Concatenate("Features", "KeywordFloat", "GenreFloat"))
                .AppendCacheCheckpoint(mlContext);

            // A modell típusának beállítása, amely ebben az esetben regressziót használó FastTree, és paramétereinek értékének beállítása
            var trainer = mlContext.Regression.Trainers.LbfgsPoissonRegression(
                labelColumnName: nameof(Tmdb.TmdbScore),
                featureColumnName: "Features"
            );

            var trainingPipeline = dataProcessPipeline.Append(trainer);


            var model = trainingPipeline.Fit(data); // Modell tanítása a Fit() metódussal

            // A betanított modell kiértékelése
            var predictions = model.Transform(data);
            var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: nameof(Tmdb.TmdbScore));


            // Egy darab film Tmdb pontszámának megbecslése a modell használatával
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Tmdb, TmdbPredict>(model, inputSchemaDefinition: schemaDef);


            for (int i = 0; i < moviesL.Count; i++)
            {

                var testMovie = new Tmdb  // A becsléshez használt adattagok feltöltése a megbecsülendő film megfelelő adataival
                {
                    Genre = prop.GenreContains[i],
                    Keyword = prop.KeywordContains[i]
                };
                var prediction = predictionEngine.Predict(testMovie); // A tényleges becslés elvégzése                                                              

                predictedTmdbs.Add(prediction.PredictedTmdb);
            }


            Console.WriteLine("R^2 LbfgsPoissonRegression: " + RSquare(moviesL, predictedTmdbs));
        }

        public void LbfgsPoissonRegressionTuned(List<Movie> moviesL, PropertiesForDecTree prop)
        {
            List<float> predictedTmdbs = new List<float>();
            Random random = new Random();
            double bestRSquared = double.MinValue;

            for (int j = 0; j < 200; j++) // 100 véletlenszerű keresés
            {
                //int maxIterations = random.Next(10, 1000); // MaximumNumberOfIterations: 10-től 1000-ig
                double l2Regularization = random.NextDouble() * (1 - 0.0001) + 0.0001; // L2Regularization: 0.0001-től 1-ig
                double l1Regularization = random.NextDouble() * (1 - 0.0001) + 0.0001; // L1Regularization: 0.0001-től 1-ig
                double optimizationTolerance = random.NextDouble() * (1 - 0.0001) + 0.0001; // OptimizationTolerance: 0.0001-től 1-ig

                var mlContext = new MLContext();
                //A tanító adatokat tartalmazó lista létrehozása és feltöltése, ez esetben az adatbázis első 20 darab film megfelelő adataival
                var movies = new List<Tmdb>();

                for (int i = 0; i < 20; i++)
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
                    .Append(mlContext.Transforms.Conversion.ConvertType("KeywordFloat", nameof(Tmdb.Keyword), DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType("GenreFloat", nameof(Tmdb.Genre), DataKind.Single))
                    .Append(mlContext.Transforms.Concatenate("Features", "KeywordFloat", "GenreFloat"))
                    .AppendCacheCheckpoint(mlContext);

                // A modell típusának beállítása, amely ebben az esetben regressziót használó FastTree, és paramétereinek értékének beállítása
                var trainer = mlContext.Regression.Trainers.LbfgsPoissonRegression(
                    labelColumnName: nameof(Tmdb.TmdbScore),
                    featureColumnName: "Features",
                    l2Regularization: (float)l2Regularization,        // generált L2 regularizációs érték
                    l1Regularization: (float)l1Regularization,        // generált L1 regularizációs érték
                    optimizationTolerance: (float)optimizationTolerance // generált tolerancia
                );

                var trainingPipeline = dataProcessPipeline.Append(trainer);


                var model = trainingPipeline.Fit(data); // Modell tanítása a Fit() metódussal

                // A betanított modell kiértékelése
                var predictions = model.Transform(data);
                var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: nameof(Tmdb.TmdbScore));


                // Egy darab film Tmdb pontszámának megbecslése a modell használatával
                var predictionEngine = mlContext.Model.CreatePredictionEngine<Tmdb, TmdbPredict>(model, inputSchemaDefinition: schemaDef);


                predictedTmdbs.Clear();
                for (int i = 0; i < moviesL.Count; i++)
                {

                    var testMovie = new Tmdb  // A becsléshez használt adattagok feltöltése a megbecsülendő film megfelelő adataival
                    {
                        Genre = prop.GenreContains[i],
                        Keyword = prop.KeywordContains[i]
                    };
                    var prediction = predictionEngine.Predict(testMovie); // A tényleges becslés elvégzése


                    predictedTmdbs.Add(prediction.PredictedTmdb);
                }
                if (bestRSquared < RSquare(moviesL, predictedTmdbs))
                {
                    bestRSquared = RSquare(moviesL, predictedTmdbs);
                }
            }


            Console.WriteLine("R^2 LbfgsPoissonRegressionTuned: " + bestRSquared);
        }

        public void Gam(List<Movie> moviesL, PropertiesForDecTree prop)
        {
            List<float> predictedTmdbs = new List<float>();


            var mlContext = new MLContext();
            //A tanító adatokat tartalmazó lista létrehozása és feltöltése, ez esetben az adatbázis első 20 darab film megfelelő adataival
            var movies = new List<Tmdb>();

            for (int i = 0; i < 20; i++)
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
                .Append(mlContext.Transforms.Conversion.ConvertType("KeywordFloat", nameof(Tmdb.Keyword), DataKind.Single))
                .Append(mlContext.Transforms.Conversion.ConvertType("GenreFloat", nameof(Tmdb.Genre), DataKind.Single))
                .Append(mlContext.Transforms.Concatenate("Features", "KeywordFloat", "GenreFloat"))
                .AppendCacheCheckpoint(mlContext);

            // A modell típusának beállítása, amely ebben az esetben regressziót használó FastTree, és paramétereinek értékének beállítása
            var trainer = mlContext.Regression.Trainers.Gam(
                labelColumnName: nameof(Tmdb.TmdbScore),
                featureColumnName: "Features"
            );

            var trainingPipeline = dataProcessPipeline.Append(trainer);


            var model = trainingPipeline.Fit(data); // Modell tanítása a Fit() metódussal

            // A betanított modell kiértékelése
            var predictions = model.Transform(data);
            var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: nameof(Tmdb.TmdbScore));


            // Egy darab film Tmdb pontszámának megbecslése a modell használatával
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Tmdb, TmdbPredict>(model, inputSchemaDefinition: schemaDef);


            for (int i = 0; i < moviesL.Count; i++)
            {

                var testMovie = new Tmdb  // A becsléshez használt adattagok feltöltése a megbecsülendő film megfelelő adataival
                {
                    Genre = prop.GenreContains[i],
                    Keyword = prop.KeywordContains[i]
                };
                var prediction = predictionEngine.Predict(testMovie); // A tényleges becslés elvégzése                                                              

                predictedTmdbs.Add(prediction.PredictedTmdb);
            }


            Console.WriteLine("R^2 Gam: " + RSquare(moviesL, predictedTmdbs));
        }

        public void GamTuned(List<Movie> moviesL, PropertiesForDecTree prop)
        {
            List<float> predictedTmdbs = new List<float>();
            Random random = new Random();
            double bestRSquared = double.MinValue;

            for (int j = 0; j < 200; j++) // 100 véletlenszerű keresés
            {
                //int maxIterations = random.Next(10, 1000); // MaximumNumberOfIterations: 10-től 1000-ig
                int maxIterations = random.Next(10, 300); // MaximumNumberOfIterations: 10-től 300-ig
                double learningRate = random.NextDouble() * (0.1 - 0.01) + 0.01; // LearningRate: 0.01-től 0.1-ig
                int maxBins = random.Next(10, 100); // MaximumBinCountPerFeature: 10-től 100-ig

                var mlContext = new MLContext();
                //A tanító adatokat tartalmazó lista létrehozása és feltöltése, ez esetben az adatbázis első 20 darab film megfelelő adataival
                var movies = new List<Tmdb>();

                for (int i = 0; i < 20; i++)
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
                    .Append(mlContext.Transforms.Conversion.ConvertType("KeywordFloat", nameof(Tmdb.Keyword), DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType("GenreFloat", nameof(Tmdb.Genre), DataKind.Single))
                    .Append(mlContext.Transforms.Concatenate("Features", "KeywordFloat", "GenreFloat"))
                    .AppendCacheCheckpoint(mlContext);

                // A modell típusának beállítása, amely ebben az esetben regressziót használó FastTree, és paramétereinek értékének beállítása
                var trainer = mlContext.Regression.Trainers.Gam(
                    labelColumnName: nameof(Tmdb.TmdbScore),
                    featureColumnName: "Features",
                    numberOfIterations: maxIterations,
                    learningRate: learningRate,
                    maximumBinCountPerFeature: maxBins
                );

                var trainingPipeline = dataProcessPipeline.Append(trainer);


                var model = trainingPipeline.Fit(data); // Modell tanítása a Fit() metódussal

                // A betanított modell kiértékelése
                var predictions = model.Transform(data);
                var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: nameof(Tmdb.TmdbScore));


                // Egy darab film Tmdb pontszámának megbecslése a modell használatával
                var predictionEngine = mlContext.Model.CreatePredictionEngine<Tmdb, TmdbPredict>(model, inputSchemaDefinition: schemaDef);


                predictedTmdbs.Clear();
                for (int i = 0; i < moviesL.Count; i++)
                {

                    var testMovie = new Tmdb  // A becsléshez használt adattagok feltöltése a megbecsülendő film megfelelő adataival
                    {
                        Genre = prop.GenreContains[i],
                        Keyword = prop.KeywordContains[i]
                    };
                    var prediction = predictionEngine.Predict(testMovie); // A tényleges becslés elvégzése


                    predictedTmdbs.Add(prediction.PredictedTmdb);
                }
                if (bestRSquared < RSquare(moviesL, predictedTmdbs))
                {
                    bestRSquared = RSquare(moviesL, predictedTmdbs);
                }
            }


            Console.WriteLine("R^2 GamTuned: " + bestRSquared);
        }

        public void FastforestTuned(List<Movie> moviesL, PropertiesForDecTree prop)
        {
            List<float> predictedTmdbs = new List<float>();
            Random random = new Random();
            double bestRSquared = double.MinValue;

            for (int j = 0; j < 200; j++) // 100 véletlenszerű keresés
            {
                double learningRate = random.NextDouble() * (0.1 - 0.0001) + 0.0001; // LearningRate: 0.0001-től 0.1-ig
                bool decreasingLearningRate = true;

                var mlContext = new MLContext();
                //A tanító adatokat tartalmazó lista létrehozása és feltöltése, ez esetben az adatbázis első 20 darab film megfelelő adataival
                var movies = new List<Tmdb>();

                for (int i = 0; i < 20; i++)
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
                    .Append(mlContext.Transforms.Conversion.ConvertType("KeywordFloat", nameof(Tmdb.Keyword), DataKind.Single))
                    .Append(mlContext.Transforms.Conversion.ConvertType("GenreFloat", nameof(Tmdb.Genre), DataKind.Single))
                    .Append(mlContext.Transforms.Concatenate("Features", "KeywordFloat", "GenreFloat"))
                    .AppendCacheCheckpoint(mlContext);

                // A modell típusának beállítása, amely ebben az esetben regressziót használó FastTree, és paramétereinek értékének beállítása
                var trainer = mlContext.Regression.Trainers.OnlineGradientDescent(
                labelColumnName: nameof(Tmdb.TmdbScore),
                featureColumnName: "Features",
                learningRate: (float)learningRate,
                decreaseLearningRate: decreasingLearningRate
                );


                var trainingPipeline = dataProcessPipeline.Append(trainer);


                var model = trainingPipeline.Fit(data); // Modell tanítása a Fit() metódussal

                // A betanított modell kiértékelése
                var predictions = model.Transform(data);
                var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: nameof(Tmdb.TmdbScore));


                // Egy darab film Tmdb pontszámának megbecslése a modell használatával
                var predictionEngine = mlContext.Model.CreatePredictionEngine<Tmdb, TmdbPredict>(model, inputSchemaDefinition: schemaDef);


                predictedTmdbs.Clear();
                for (int i = 0; i < moviesL.Count; i++)
                {

                    var testMovie = new Tmdb  // A becsléshez használt adattagok feltöltése a megbecsülendő film megfelelő adataival
                    {
                        Genre = prop.GenreContains[i],
                        Keyword = prop.KeywordContains[i]
                    };
                    var prediction = predictionEngine.Predict(testMovie); // A tényleges becslés elvégzése


                    predictedTmdbs.Add(prediction.PredictedTmdb);
                }
                if (bestRSquared < RSquare(moviesL, predictedTmdbs))
                {
                    bestRSquared = RSquare(moviesL, predictedTmdbs);
                }
            }


            Console.WriteLine("R^2 FastForestTuned: " + bestRSquared);
        }

        public void Fastforest(List<Movie> moviesL, PropertiesForDecTree prop)
        {
            List<float> predictedTmdbs = new List<float>();


            var mlContext = new MLContext();
            //A tanító adatokat tartalmazó lista létrehozása és feltöltése, ez esetben az adatbázis első 20 darab film megfelelő adataival
            var movies = new List<Tmdb>();

            for (int i = 0; i < 20; i++)
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
                .Append(mlContext.Transforms.Conversion.ConvertType("KeywordFloat", nameof(Tmdb.Keyword), DataKind.Single))
                .Append(mlContext.Transforms.Conversion.ConvertType("GenreFloat", nameof(Tmdb.Genre), DataKind.Single))
                .Append(mlContext.Transforms.Concatenate("Features", "KeywordFloat", "GenreFloat"))
                .AppendCacheCheckpoint(mlContext);

            // A modell típusának beállítása, amely ebben az esetben regressziót használó FastTree, és paramétereinek értékének beállítása
            var trainer = mlContext.Regression.Trainers.OnlineGradientDescent(
                labelColumnName: nameof(Tmdb.TmdbScore),
                featureColumnName: "Features"
            );

            var trainingPipeline = dataProcessPipeline.Append(trainer);


            var model = trainingPipeline.Fit(data); // Modell tanítása a Fit() metódussal

            // A betanított modell kiértékelése
            var predictions = model.Transform(data);
            var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: nameof(Tmdb.TmdbScore));


            // Egy darab film Tmdb pontszámának megbecslése a modell használatával
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Tmdb, TmdbPredict>(model, inputSchemaDefinition: schemaDef);


            for (int i = 0; i < moviesL.Count; i++)
            {

                var testMovie = new Tmdb  // A becsléshez használt adattagok feltöltése a megbecsülendő film megfelelő adataival
                {
                    Genre = prop.GenreContains[i],
                    Keyword = prop.KeywordContains[i]
                };
                var prediction = predictionEngine.Predict(testMovie); // A tényleges becslés elvégzése                                                              

                predictedTmdbs.Add(prediction.PredictedTmdb);
            }


            Console.WriteLine("R^2 Fasttree: " + RSquare(moviesL, predictedTmdbs));
        }

        /// <summary>
        /// R^2 érték számítás teljes adathalmazra a modellek hatékonyságának méréséhez
        /// </summary>
        /// <param name="originalMovies">A filmek eredeti adatait, köztük a Tmdb pontszámokat is tartalmazó lista</param>
        /// <param name="predictedValues">A becsült Tmdb pontszámokat tartalmazó lista</param>
        /// <returns>A kiszámolt R^2 érték, tehát a pontosság mértéke</returns>
        public float RSquare(List<Movie> originalMovies, List<float> predictedValues)
        {
            float RSq = 0;
            float mean = 0;
            for (int i = 0; i < originalMovies.Count; i++)
            {
                mean += (float)originalMovies[i].TmdbScore;
            }
            mean = (mean / originalMovies.Count);
            float counter = 0;
            float denominator = 0;
            for (int i = 0; i < originalMovies.Count; i++)
            {
                counter += (float)Math.Pow(((float)originalMovies[i].TmdbScore - predictedValues[i]), 2);
                denominator += (float)Math.Pow(((float)originalMovies[i].TmdbScore - mean), 2);
            }
            RSq = 1 - (counter / denominator);
            return RSq;
        }

        public void MeasureAll(List<Movie> movie, PropertiesForDecTree properties)
        {
            Fasttree(movie, properties);
            FasttreeTuned(movie, properties);
            Sdca(movie, properties);
            SdcaTuned(movie, properties);
            LbfgsPoissonRegression(movie, properties);
            LbfgsPoissonRegressionTuned(movie, properties);
            Gam(movie, properties);
            GamTuned(movie, properties);
            Fastforest(movie, properties);
            FastforestTuned(movie, properties);

        }
    }
}
