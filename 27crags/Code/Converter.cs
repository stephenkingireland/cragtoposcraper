using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                {"VD", "4+"},
                {"D", "3"},
                {"M", "1"},
                {"S", "5"},
                {"HS", "5"},
                {"VS", "5+"},
                {"HVS", "5+"},
                {"E1", "6a"},
                {"E3", "6c"},
                {"E2", "6b"},
                {"E4", "7a"},
                {"E5", "7b"},
                {"E6", "7c"},
                {"E7", "8a"},
                {"E8", "8a+"},

            };

        public String ConvertBritGrade(String britTechGrade)
        {

            return britToFrenchConverstionChart[britTechGrade.Split(',')[0]];

        }


        public bool IsBritGrade(String britTechGrade)
        {
            return britToFrenchConverstionChart.Keys.Contains(britTechGrade.Split(',')[0]);
        }

        public int BritGradePosition(String line)
        {
            foreach (var grade in britToFrenchConverstionChart.Keys)
            {
                if (line.Contains(" " + grade + " "))
                {
                    return line.IndexOf(grade);
                }
            }

            throw new EntryPointNotFoundException("Cant Find the grade");
        }

        public bool HasBritGrade(String line)
        {
            foreach(var grade in britToFrenchConverstionChart.Keys)
            {
                if (line.Contains(" " + grade + " "))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
