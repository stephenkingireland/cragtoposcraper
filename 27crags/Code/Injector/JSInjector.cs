using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27crags.Code.Injector
{
    public class JSInjector : IInjector
    {



        public void Inject(IEnumerable<Climb> climbsToInject, string fileName)
        {

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(climbsToInject);

            InjectToJavascript(json, fileName);
        }


        private void InjectToJavascript(string jsonString, string fileName)
        {
            var fullFileName = Path.Combine(Environment.CurrentDirectory, @"Data\javascript\", fileName + ".js");
            var fullTemplateName = Path.Combine(Environment.CurrentDirectory, @"Data\javascript\templates\", "inputTempate.js");



            if (File.Exists(fullFileName))
                File.Delete(fullFileName);

            var templateText = File.ReadAllText(fullTemplateName);

            var javascriptContents = templateText.Replace("{{jsonData}}", jsonString.Replace("'", ""));

            using (var writer = File.CreateText(fullFileName))
            {
                writer.WriteLine(javascriptContents);
            }

        }

    }
}
