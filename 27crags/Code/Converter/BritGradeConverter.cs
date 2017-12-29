using System;
using System.Collections.Generic;

namespace _27crags.Code.Converter
{
    public class BritGradeConverter : IGradeConverter
    {
        private Dictionary<String, String> britToFrenchConverstionChart = new Dictionary<String, String>()
            {
                {"3c", "3"},
                {"4a", "4"},
                {"4b", "5"},
                {"4c", "5+"},
                {"5a", "6a"},
                {"5b", "6a+"},
                {"5c", "6b+"},
                {"6a", "7a"},
                {"6b", "7b+"},
                {"6c", "7c+"},
                {"7a", "8a+"},
                {"7b", "8c"},
                {"M", "3"},
                {"Mod", "3"},
                {"V.Diff", "4+"},
                {"V. Diff", "4+"},
                {"V Diff", "4+"},
                {"VD", "4+"},
                {"D", "3"},
                {"Diff", "3"},
                {"MS", "5"},
                {"Mild Severe", "5"},
                {"S", "5"},
                {"Svr", "5"},
                {"VS", "5"},
                {"HS", "5"},
                {"MVS", "5"},
                {"HVS", "5+"},
                { "HVS/VS", "5+"},
                {"E1", "6a"},
                {"E3", "6c"},
                {"E2", "6b"},
                {"E4", "7a"},
                {"E5", "7b"},
                {"E6", "7c"},
                {"E7", "8a"},
                {"E8", "8a+"},
                {"XS", "?"},
                {"MXS", "?"},
                {"HXS", "?"},

            };

        private List<String> britTechGrades = new List<String>()
            {
                {"3a"},
                {"3b"},
                {"3c"},
                {"4a"},
                {"4b"},
                {"4c"},
                {"5a"},
                {"5b"},
                {"5c"},
                {"6a"},
                {"6b"},
                {"6c"},
                {"7a"},
                {"7b"},
                {"7c"},
                {"8a"},
                {"8b"},


            };

        private List<String> britAdjGrades = new List<String>()
        {
            {"M"},
            {"Mod"},
            {"V.Diff"},
            {"V. Diff"},
            {"V Diff"},
            {"VD"},
            {"D"},
            {"Diff"},
            {"MS"},
            {"Mild Severe"},
            {"S"},
            {"Svr"},
            {"HS"},
            {"VS"},
            {"MVS"},
            {"HVS"},
            {"VS/HVS"},
            {"E1"},
            {"E3"},
            {"E2"},
            {"E4"},
            {"E5"},
            {"E6"},
            {"E7"},
            {"E8"},
            {"XS"},
            {"MXS"},
            {"HXS"},
            };


        public string ConvertGrade(string gradeToConvert)
        {
            return britToFrenchConverstionChart[gradeToConvert.Split(',')[0]];
        }

        public string GetGrade(string line)
        {
            foreach (var adjgrade in britAdjGrades)
            {
                foreach (var techgrade in britTechGrades)
                {
                    if (line.Contains(" " + adjgrade + " " + techgrade))
                    {
                        return adjgrade + " " + techgrade;
                    }
                }
            }

            foreach (var adjgrade in britAdjGrades)
            {
                if (line.Contains(" " + adjgrade + " "))
                {
                    return adjgrade;
                }
            }

            foreach (var techgrade in britTechGrades)
            {
                if (line.Contains(" " + techgrade + " "))
                {
                    return techgrade;
                }
            }

            throw new MissingMemberException("Cant find the grade");
        }

        public bool HasGrade(string line)
        {
            foreach (var grade in britToFrenchConverstionChart.Keys)
            {
                if (line.Contains(" " + grade + " ") && (line.EndsWith("*") || line.EndsWith("m")))
                {
                    return true;
                }
            }

            return false;
        }

        public int GradePosition(String line, string grade)
        {

            if (line.Contains(grade))
            {
                return line.LastIndexOf(grade);
            }

            throw new MissingMemberException("Cant Find the grade");
        }
    }

}
