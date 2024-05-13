using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML_des.Data
{
    public class StudentInputData
    {
        [LoadColumn(0)]
        public int StudentID { get; set; }
        [LoadColumn(1)]
        public string NacinStudiranja { get; set; }
        [LoadColumn(2)]
        public float P104 { get; set; }
        [LoadColumn(3)]
        public float P12 { get; set; }
        [LoadColumn(4)]
        public float P140 { get; set; }
        [LoadColumn(5)]
        public float P141 { get; set; }
        [LoadColumn(6)]
        public float P142 { get; set; }
        [LoadColumn(7)]
        public float P143 { get; set; }
        [LoadColumn(8)]
        public float P145 { get; set; }
        [LoadColumn(9)]
        public float P146 { get; set; }
        [LoadColumn(10)]
        public float P147 { get; set; }
        [LoadColumn(11)]
        public float P148 { get; set; }
        [LoadColumn(12)]
        public float P149 { get; set; }
        [LoadColumn(13)]
        public float P150 { get; set; }
        [LoadColumn(14)]
        public float P151 { get; set; }
        [LoadColumn(15)]
        public float P152 { get; set; }
        [LoadColumn(16)]
        public float P153 { get; set; }
        [LoadColumn(17)]
        public float P154 { get; set; }
        [LoadColumn(18)]
        public float P155 { get; set; }
        [LoadColumn(19)]
        public float P156 { get; set; }
        [LoadColumn(20)]
        public float P157 { get; set; }
        [LoadColumn(21)]
        public float P158 { get; set; }
        [LoadColumn(22)]
        public float P159 { get; set; }
        [LoadColumn(23)]
        public float P160 { get; set; }
        [LoadColumn(24)]
        public float P161 { get; set; }
        [LoadColumn(25)]
        public float P162 { get; set; }
        [LoadColumn(26)]
        public float P175 { get; set; }
        [LoadColumn(27)]
        public float P176 { get; set; }
        [LoadColumn(28)]
        public float P177 { get; set; }
        [LoadColumn(29)]
        public float P178 { get; set; }
        [LoadColumn(30)]
        public float P218 { get; set; }
        [LoadColumn(31)]
        public float P219 { get; set; }
        [LoadColumn(32)]
        public float P220 { get; set; }
        [LoadColumn(33)]
        public float P221 { get; set; }
        [LoadColumn(34)]
        public float P222 { get; set; }
        [LoadColumn(35)]
        public float P223 { get; set; }
        [LoadColumn(36)]
        public float P224 { get; set; }
        [LoadColumn(37)]
        public float P225 { get; set; }
        [LoadColumn(38)]
        public float P226 { get; set; }
        [LoadColumn(39)]
        public float P227 { get; set; }
        [LoadColumn(40)]
        public float P228 { get; set; }
        [LoadColumn(41)]
        public float P229 { get; set; }
        [LoadColumn(42)]
        public float P230 { get; set; }
        [LoadColumn(43)]
        public float P231 { get; set; }
        [LoadColumn(44)]
        public float P232 { get; set; }
        [LoadColumn(45)]
        public float P233 { get; set; }
        [LoadColumn(46)]
        public float P234 { get; set; }
        [LoadColumn(47)]
        public float P235 { get; set; }
        [LoadColumn(48)]
        public float P236 { get; set; }
        [LoadColumn(49)]
        public float P237 { get; set; }
        [LoadColumn(50)]
        public float P238 { get; set; }
        [LoadColumn(51)]
        public float P239 { get; set; }
        [LoadColumn(52)]
        public float P24 { get; set; }
        [LoadColumn(53)]
        public float P240 { get; set; }
        [LoadColumn(54)]
        public float P241 { get; set; }
        [LoadColumn(55)]
        public float P246 { get; set; }
        [LoadColumn(56)]
        public float P247 { get; set; }
        [LoadColumn(57)]
        public float P276 { get; set; }
        [LoadColumn(58)]
        public float P277 { get; set; }
        [LoadColumn(59)]
        public float P278 { get; set; }
        [LoadColumn(60)]
        public float P279 { get; set; }
        [LoadColumn(61)]
        public float P280 { get; set; }
        [LoadColumn(62)]
        public float P33 { get; set; }
        [LoadColumn(63)]
        public float P45 { get; set; }
        [LoadColumn(64)]
        public float P50 { get; set; }
        [LoadColumn(65)]
        public float P58 { get; set; }
        [LoadColumn(66)]
        public float P7 { get; set; }
        [LoadColumn(67)]
        public float P8 { get; set; }
        [LoadColumn(68)]
        public float P85 { get; set; }


        [LoadColumn(69), ColumnName("Label")]
        
        public bool Diplomirao { get; set; }
        //[LoadColumn(86)]
        //public float FeaturesArray { get; set; } // Ovo je pojedinačna vrijednost, ne vektor

        // Dodajte niz za značajke
        //[LoadColumn(2, 67), VectorType(66)]
        //public float[] Features { get; set; }



    }
}
