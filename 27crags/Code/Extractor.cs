using System;
using System.Collections.Generic;
using System.IO;

namespace _27crags.Code
{
    class Extractor
    {
        private string workingDirectory;
        private string jsonWorkingDirectory;
        private string textWorkingDirectory;

        private string jsonPath = @"Data\json\";
        private string jsonExt = ".json";

        private string textPath = @"Data\text\";
        private string textExt = ".txt";


        public Extractor(string workingDirectory)
        {
            this.workingDirectory = workingDirectory;
            jsonWorkingDirectory = Path.Combine(workingDirectory, jsonPath);
            textWorkingDirectory = Path.Combine(workingDirectory, textPath);
        }

        public Extractor() : this(Environment.CurrentDirectory)
        {}


        public IEnumerable<string> ExtractJsonFilePaths()
        {
            return Directory.GetFiles(jsonWorkingDirectory, "*" + jsonExt);
        }

        public IEnumerable<string> ExtractTextFilePaths()
        {
            return Directory.GetFiles(textWorkingDirectory, "*" + textExt);
        }

        public string ExtractData(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        public string ExtractData(string folderPath, string fileName)
        {
            return File.ReadAllText(Path.Combine(Environment.CurrentDirectory, folderPath, fileName));
        }

    }
}
