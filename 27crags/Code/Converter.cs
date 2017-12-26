﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _27crags.Code
{
    public class Converter
    {

        private Dictionary<String, String> britToFrenchConverstionChart = new Dictionary<String, String>()
            {
                {"1", "1"},
                {"2", "2"},
                {"3", "3"},
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
                {"V. Diff", "4+"},
                {"VD", "4+"},
                {"D", "3"},
                {"Diff", "3"},
                {"MS", "5"},
                {"S", "5"},
                {"VS", "5"},
                {"HS", "5"},
                {"MVS", "5"},
                {"HVS", "5+"},
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
                {"1"},
                {"2"},
                {"3"},
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
            {"V. Diff"},
            {"VD"},
            {"D"},
            {"Diff"},
            {"MS"},
            {"S"},
            {"HS"},
            {"VS"},
            {"MVS"},
            {"HVS"},
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

        public String ConvertBritGrade(String britTechGrade)
        {

            return britToFrenchConverstionChart[britTechGrade.Split(',')[0]];

        }


        public bool IsBritGrade(String britTechGrade)
        {
            return britToFrenchConverstionChart.Keys.Contains(britTechGrade.Split(',')[0]);
        }

        public int BritGradePosition(String line, string grade)
        {

                if (line.Contains(grade))
                {
                    return line.LastIndexOf(grade);
                }

            throw new MissingMemberException("Cant Find the grade");
        }


        public string GetBritGrade(string line)
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

            throw new MissingMemberException("Cant find the grade");
        }

        public bool HasBritGrade(String line)
        {
            foreach(var grade in britToFrenchConverstionChart.Keys)
            {
                if (line.Contains(" " + grade + " ")  && (line.EndsWith("*") || line.EndsWith("m")))
                {
                    return true;
                }
            }

            return false;
        }


        public string ConvertToJson(IEnumerable<Climb> convertedClimbs)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(convertedClimbs);
        }

        public IList<Climb> ConvertFromJson(string rawtext)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Climb>>(rawtext);
        }


        public IList<Climb> ConvertFromText(string rawtext)
        {
            var climbs = new List<Climb>();

            foreach (var line in rawtext.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!HasBritGrade(line))
                {
                    continue;
                }

                var grade = GetBritGrade(line);

                var gradePos = BritGradePosition(line, grade);

                var name = line.Substring(0, gradePos - 1);

                climbs.Add(new Climb { grade = grade, name = name });
            }

            return climbs;
        }


        public IEnumerable<Climb> ConvertClimbs(IEnumerable<Climb> rawClimbs)
        {
            var convertedClimbs = new List<Climb>();

            foreach (var climb in rawClimbs)
            {
                var grade = climb.grade.Trim().Split(' ')[0];

                if (climb.grade.StartsWith("f") || !IsBritGrade(grade))
                {
                    continue;
                }

                climb.frenchGrade = ConvertBritGrade(grade);

                climb.grade = climb.grade.Replace("*", "").Trim();

                convertedClimbs.Add(climb);
            }

            return convertedClimbs;
        }

    }
}
