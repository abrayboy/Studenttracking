using Studenttracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studenttracking.Util
{
    public static class ClassificationUtils
    {

        public static Classification GetClassification(string classification)
        {
            switch (classification.Trim().ToLower())
            {
                case "senior":
                    return Classification.Senior;
                case "junior":
                    return Classification.Junior;
                case "sophomore":
                    return Classification.Sophomore;
                case "freshman":
                    return Classification.Freshman;
                case "grad":
                    return Classification.Grad;
                case "grad/med":
                    return Classification.Grad_Med;
                case "law":
                    return Classification.Law;
                case "engineering":
                    return Classification.Engineering;
                case "med":
                    return Classification.Med;
                case "phd":
                    return Classification.Phd;
                default:
                    return Classification.None;
            }
        }
    }
}
