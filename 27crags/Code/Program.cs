using _27crags.Code;
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
            var converter = new Converter();


            var fileName = "ailladie";

            string rawtext = ExtractData(fileName);

            var json = ConvertFromJson(rawtext);

            var convertedClimbs = new List<Climb>();

            foreach (var climb in json)
            {
                var grade = climb.grade.Trim().Split(' ')[0];

                if (climb.grade.StartsWith("f") || !converter.IsBritGrade(grade))
                {
                    continue;
                }

                climb.frenchGrade = converter.ConvertBritGrade(grade);

                climb.grade = climb.grade.Replace("*", "").Trim();

                convertedClimbs.Add(climb);
            }

            var jsonString = ConvertToJson(convertedClimbs);

            InjectToJavascript(jsonString, fileName);

        }

        private static void InjectToJavascript(string jsonString, string fileName)
        {
            var fullFileName = Path.Combine(Environment.CurrentDirectory, @"Data\javascript\", fileName + ".js");
            var fullTemplateName = Path.Combine(Environment.CurrentDirectory, @"Data\javascript\templates\", "inputTempate.js");



            if (File.Exists(fullFileName))
                File.Delete(fullFileName);

            var templateText = File.ReadAllText(fullTemplateName);

            var javascriptContents = templateText.Replace("{{jsonData}}", jsonString.Replace("'",""));

            using (var writer = File.CreateText(fullFileName))
            {
                writer.WriteLine(javascriptContents);
            }

        }

        private static string ConvertToJson(List<Climb> convertedClimbs)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(convertedClimbs);
        }

        private static IList<Climb> ConvertFromJson(string rawtext)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Climb>>(rawtext);
        }

        private static string ExtractData(string fileName)
        {
            return File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Data\json\", fileName + ".json"));
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
