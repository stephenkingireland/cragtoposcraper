using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27crags
{
    class Program
    {


       

        static void Main(string[] args)
        {

            var fileName = "glendo.json";

            var rawtext = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Data\", fileName));


            var json = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Climb>>(rawtext);

            var convertedClimbs = new List<Climb>();

            foreach(var climb in json)
            {
                if(climb.grade.StartsWith("f"))
                {
                    continue;
                }
                var grade = climb.grade.Trim().Split(' ')[0];
                climb.frenchGrade = ConvertGrade(grade);

                convertedClimbs.Add(climb);
            }



            var convertedJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(convertedClimbs);

            json.First();
        }

        public static String ConvertGrade(String britTechGrade)
        {
            var britToFrenchConverstionChart = new Dictionary<String, String>()
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

            


            return britToFrenchConverstionChart[britTechGrade.Split(',')[0]];

        }

    }




    public class Climb
    {
        public String frenchGrade;

        public String grade;
        public String name;
        
        public String section;
    }
}
