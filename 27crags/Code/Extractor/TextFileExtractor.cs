using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27crags.Code.Extractor
{
    public class TextFileExtractor : FileExtractor
    {

        protected override string FilePath => @"Data\text\";

        protected override string FileExtention => ".txt";

    }
}
