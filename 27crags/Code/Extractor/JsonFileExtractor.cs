
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27crags.Code.Extractor
{
    class JsonFileExtractor : FileExtractor
    {

        protected override string FilePath => @"Data\json\";

        protected override string FileExtention => ".json";

    }
}
