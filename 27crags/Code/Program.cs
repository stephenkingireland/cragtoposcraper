using _27crags.Code;
using _27crags.Code.Converter;
using _27crags.Code.Extractor;
using _27crags.Code.Injector;
using System;
using System.Collections.Generic;
using System.IO;

namespace _27crags
{
    class Program
    {

        static void Main(string[] args)
        {
            var program = new Program();

            program.Run();
        }

        public void Run()
        {
            var injector = new JSInjector();
            var converter = new BritGradeConverter();

            DoWork(new JsonFileExtractor(), new JsonClimbExtractor(converter), injector);
            DoWork(new TextFileExtractor(), new TextClimbExtractor(converter), injector);

        }


        public void DoWork(IFileExtractor extractor, IClimbExtractor climbExtractor, IInjector injector)
        {

            foreach (var fileName in extractor.ExtractFilePaths())
            {
                var climbs = GetClimbs(extractor, climbExtractor, fileName);

                injector.Inject(climbs, fileName);
            }

        }

        public IEnumerable<Climb> GetClimbs(IFileExtractor fileExtract, IClimbExtractor climbExtract, string fileName)
                                                                                    
        {
            var climbData = fileExtract.ExtractData(fileName);

            return climbExtract.ExtractClimbs(climbData);
        }


       
        

    }
}
