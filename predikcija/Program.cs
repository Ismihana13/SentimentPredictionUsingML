using Microsoft.ML;
using Microsoft.ML.Data;
using ML_des.Data;
using predikcija.Data;
using static Microsoft.ML.DataOperationsCatalog;

namespace predikcija
{
    class Program
    {
        static readonly string _traningDataPath = Path.Combine(Environment.CurrentDirectory, "Kopirano.csv");
       // static readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "Model.zip");
        static void Main(string[] args) 
        {
            classifySentiment();
        }

        private static void classifySentiment()
        {
            MLContext mLContext = new MLContext();

            IDataView traningDataView = mLContext.Data.LoadFromTextFile<StudentInputData>(_traningDataPath, hasHeader: true, separatorChar: ';');
            TrainTestData trainTestData=mLContext.Data.TrainTestSplit(traningDataView, testFraction:0.2);

            var dataPreparationPipeline = mLContext.Transforms.Text.FeaturizeText(inputColumnName: "NacinStudiranja", outputColumnName: "Features")
                .Append(mLContext.Transforms.Concatenate("Features", nameof(StudentInputData.P104),
         nameof(StudentInputData.P12),
         nameof(StudentInputData.P140),
         nameof(StudentInputData.P141),
         nameof(StudentInputData.P142),
         nameof(StudentInputData.P143),
         nameof(StudentInputData.P145),
         nameof(StudentInputData.P146),
         nameof(StudentInputData.P147),
         nameof(StudentInputData.P148),
         nameof(StudentInputData.P149),
         nameof(StudentInputData.P150),
         nameof(StudentInputData.P151),
         nameof(StudentInputData.P152),
         nameof(StudentInputData.P153),
           nameof(StudentInputData.P154),
           nameof(StudentInputData.P155),
           nameof(StudentInputData.P156),
           nameof(StudentInputData.P157),
           nameof(StudentInputData.P158),
           nameof(StudentInputData.P159),
           nameof(StudentInputData.P160),
           nameof(StudentInputData.P161),
           nameof(StudentInputData.P162),
           nameof(StudentInputData.P175),
           nameof(StudentInputData.P176),
           nameof(StudentInputData.P177),
           nameof(StudentInputData.P178),
           nameof(StudentInputData.P218),
           nameof(StudentInputData.P219),
           nameof(StudentInputData.P220),
           nameof(StudentInputData.P221),
           nameof(StudentInputData.P222),
           nameof(StudentInputData.P223),
             nameof(StudentInputData.P224),
             nameof(StudentInputData.P225),
             nameof(StudentInputData.P226),
             nameof(StudentInputData.P227),
             nameof(StudentInputData.P228),
             nameof(StudentInputData.P229),
             nameof(StudentInputData.P230),
             nameof(StudentInputData.P231),
             nameof(StudentInputData.P232),
             nameof(StudentInputData.P233),
             nameof(StudentInputData.P234),
             nameof(StudentInputData.P235),
             nameof(StudentInputData.P236),
             nameof(StudentInputData.P237),
             nameof(StudentInputData.P238),
             nameof(StudentInputData.P239),
             nameof(StudentInputData.P24),
             nameof(StudentInputData.P240),
             nameof(StudentInputData.P241),
             nameof(StudentInputData.P246),
             nameof(StudentInputData.P247),
             nameof(StudentInputData.P276),
             nameof(StudentInputData.P277),
             nameof(StudentInputData.P278),
             nameof(StudentInputData.P279),
             nameof(StudentInputData.P280),
             nameof(StudentInputData.P33),
             nameof(StudentInputData.P45),
             nameof(StudentInputData.P50),
             nameof(StudentInputData.P58),
             nameof(StudentInputData.P7),
             nameof(StudentInputData.P8),
             nameof(StudentInputData.P85))).AppendCacheCheckpoint(mLContext);
            //        var dataPreparationPipeline = mLContext.Transforms.Concatenate("Features", "NacinStudiranja", "P222")
            //.Append(mLContext.Transforms.Text.FeaturizeText("Features"));
           
            var lbfgsLogisticRegressionTrainer = dataPreparationPipeline.Append(mLContext.BinaryClassification.Trainers.LbfgsLogisticRegression(labelColumnName: "Label"));

            var model = lbfgsLogisticRegressionTrainer.Fit(trainTestData.TrainSet);
            IDataView predictionsForEvaluationDataView = model.Transform(trainTestData.TestSet);

            CalibratedBinaryClassificationMetrics metrics = mLContext.BinaryClassification.Evaluate(predictionsForEvaluationDataView, labelColumnName: "Label");
            Console.WriteLine();
            Console.WriteLine("------Binary Classification Trainer Algorithm: LBFGSLogisticRegression---");
            Console.WriteLine();
            Console.WriteLine("  Assessing MLModel Quality using Evaluation Metrics");
            Console.WriteLine($" Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($" F1 Score: {metrics.F1Score:P2}");
            Console.WriteLine();
            Console.WriteLine($" Area Under ROC Curve: {metrics.AreaUnderRocCurve:P2}");
            Console.WriteLine($" Area Under Precision Recall Curve: {metrics.AreaUnderPrecisionRecallCurve:P2}");
            Console.WriteLine();
            Console.WriteLine($" Log loss: {metrics.LogLoss.ToString()}");
            Console.WriteLine($" Log Loss Reduction: {metrics.LogLossReduction.ToString()}");
            Console.WriteLine();
            Console.WriteLine($" Confusion Matrix: {metrics.ConfusionMatrix.GetFormattedConfusionTable().ToString()}");
            Console.WriteLine();
            Console.WriteLine($" Positive Precision: {metrics.PositivePrecision.ToString()}");
            Console.WriteLine($" Positive Recall: {metrics.PositiveRecall.ToString()}");
            Console.WriteLine($" Negative Precision: {metrics.NegativePrecision.ToString()}");
            Console.WriteLine($" Negative Recall: {metrics.NegativeRecall.ToString()}");
            Console.WriteLine();
            Console.WriteLine("--------------------------------");



            var predictionFunction = mLContext.Model.CreatePredictionEngine<StudentInputData, StudentPrediction>(model);

            // Predikcija na testnom skupu podataka
            var predictions = model.Transform(trainTestData.TestSet);

            // Konverzija predikcija u IEnumerable<StudentPrediction>
            var predictionResults = mLContext.Data.CreateEnumerable<StudentPrediction>(predictions, reuseRowObject: false);

            // Učitavanje testnih podataka kako bismo mogli da pristupimo pojedinačnim instancama
            var testDataEnumerable = mLContext.Data.CreateEnumerable<StudentInputData>(trainTestData.TestSet, reuseRowObject: false);

            // Iteriranje kroz rezultate predikcije i testne podatke kako bismo dobili konkretne predikcije za svakog studenta
            int i = 0;
            foreach (var prediction in predictionResults)
            {
                var testDataInstance = testDataEnumerable.ElementAt(i);
                Console.WriteLine($"Student ID: {testDataInstance.StudentID}, Probability: {prediction.Probability}");
                Console.WriteLine($" Predicted sentiment: {(prediction.Prediction ? "Positive" : "Negative")}");
                i++;
            }


        }
    }
    
}