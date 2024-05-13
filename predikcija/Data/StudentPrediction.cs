using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace predikcija.Data
{
    public class StudentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        //[ColumnName("Probability")]
        public float Probability { get; set; }

        //[ColumnName("Score")]
        public float Score { get; set; }
    }
}
