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

            DoWork<JsonFileExtractor, JSInjector>(new JsonClimbExtractor(new BritGradeConverter()));
            DoWork<TextFileExtractor, JSInjector>(new TextClimbExtractor(new BritGradeConverter()));

        }


        public void DoWork<T, T1>(IClimbExtractor climbExtractor)
            where T: IFileExtractor        
            where T1 : IInjector
        {
            IFileExtractor extractor = default(T);
            IInjector injector = default(T1);

            foreach (var fileName in extractor.ExtractFilePaths())
            {
                var climbs = GetClimbs(extractor, climbExtractor, fileName);

                injector.Inject(climbs, fileName);
            }

        }

        public IEnumerable<Climb> GetClimbs<T, T2>(T fileExtract, T2 climbExtract, string fileName) where T : IFileExtractor
                                                                                                    where T2 : IClimbExtractor
        {
            var climbData = fileExtract.ExtractData(fileName);

            return climbExtract.ExtractClimbs(climbData);
        }


       
        

    }
}
