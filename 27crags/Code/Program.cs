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


            //program.Scrape();
            program.Convert();

            //program.Run();
        }

        private void Scrape()
        {

            _27CragsWebController controller = new _27CragsWebController(new ChromeWindow());

            controller.GotoCragPage("dalkey-quarry");

            var names = controller.GetClimbsOnPage();

            controller.Cleanup();
        }

        public void Run()
        {
            var injector = new JSInjector();
            var converter = new BritToFrenchGradeConverter();

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

        public void Convert()
        {

            var extractor = new JsonFileExtractor();

            var climb = new JsonClimbExtractor(new BritToFrenchGradeConverter());
           

            foreach (var fileName in extractor.ExtractFilePaths())
            {
                var climbs = ConvertClimbs(extractor, climb, fileName);

                using (var writer = File.CreateText(fileName))
                {
                    writer.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(climbs));
                }

            }

        }

        public IEnumerable<Climb> ConvertClimbs(JsonFileExtractor fileExtract, JsonClimbExtractor climbExtract, string fileName)

        {
            var climbData = fileExtract.ExtractData(fileName);

            var extractedClimbs  = climbExtract.ExtractClimbs(climbData);

            return extractedClimbs;
        }

        public IEnumerable<Climb> GetClimbs(IFileExtractor fileExtract, IClimbExtractor climbExtract, string fileName)
                                                                                    
        {
            var climbData = fileExtract.ExtractData(fileName);

            return climbExtract.ExtractClimbs(climbData);
        }


       
        

    }
}
