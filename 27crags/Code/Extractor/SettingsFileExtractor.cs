using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27crags.Code.Extractor
{
    public class SettingsFileExtractor : FileExtractor
    {
        protected override string FilePath => @"Data\json\";

        protected override string FileExtention => ".json";
    }
}
