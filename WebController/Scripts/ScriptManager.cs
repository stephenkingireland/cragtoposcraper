using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebController.Scripts
{
    public class ScriptManager
    {
        public string GetScript(string scriptName)
        {
            return Read(FullPath(scriptName));
        }

        private string Read(string fileName)
        {

            return File.ReadAllText(fileName);
        }

        private string FullPath(string fileName)
        {
            return Path.Combine(Environment.CurrentDirectory, @"Scripts\", fileName + ".js");
        }

    }
}
