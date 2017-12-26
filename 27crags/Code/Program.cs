using _27crags.Code;
using System;
using System.Collections.Generic;
using System.IO;

namespace _27crags
{
    class Program
    {

        static void Main(string[] args)
        {
            var extractor = new Extractor();
            var converter = new Converter();


            string rawtext = "";
            IList<Climb> rawClimbs;


            foreach (var fileName in extractor.ExtractJsonFilePaths())
            {
                rawtext = extractor.ExtractData(fileName);
                rawClimbs = converter.ConvertFromJson(rawtext);

                var convertedClimbs = converter.ConvertClimbs(rawClimbs);

                var jsonString = converter.ConvertToJson(convertedClimbs);

                InjectToJavascript(jsonString, fileName);
            }

            foreach (var fileName in extractor.ExtractTextFilePaths())
            {
                rawtext = extractor.ExtractData(fileName);
                rawClimbs = converter.ConvertFromText(rawtext);

                var convertedClimbs = converter.ConvertClimbs(rawClimbs);

                var jsonString = converter.ConvertToJson(convertedClimbs);

                InjectToJavascript(jsonString, fileName);
            }
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

    }
}
