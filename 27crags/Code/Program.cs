using _27crags.Code;
using _27crags.Code.Converter;
using _27crags.Code.Extractor;
using _27crags.Code.Injector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebController.Code;
using WebController.Code.Window;

namespace _27crags
{
    class Program
    {

        static void Main(string[] args)
        {
            var program = new Program();


            program.Scrape();

            //program.Run();
        }

        private void Scrape()
        {

            _27CragsWebController controller = new _27CragsWebController(new ChromeWindow());

            controller.GotoCragPage("glendalough");

            var names = controller.GetClimbNames().Select(i => !string.IsNullOrWhiteSpace(i));

            controller.Cleanup();
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
