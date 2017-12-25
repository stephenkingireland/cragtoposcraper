using System;
using System.IO;

namespace _27crags.Code
{
    class Extractor
    {
        public string ExtractJsonData(string fileName)
        {
            return ExtractData(@"Data\json\", fileName + ".json");
        }

        public string ExtractData(string folderPath, string fileName)
        {
            return File.ReadAllText(Path.Combine(Environment.CurrentDirectory, folderPath, fileName));
        }

    }
}
