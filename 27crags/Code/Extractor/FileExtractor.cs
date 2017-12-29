using System;
using System.Collections.Generic;
using System.IO;

namespace _27crags.Code.Extractor
{
    internal abstract class FileExtractor : IFileExtractor
    {
        protected string basePath;

        protected abstract string FilePath { get; }

        protected abstract string FileExtention { get; }

        protected string WorkingDirectory { get { return Path.Combine(basePath, FilePath); } }


        public FileExtractor(string workingDirectory)
        {
            this.basePath = workingDirectory;
        }

        public FileExtractor() : this(Environment.CurrentDirectory)
        { }

        public IEnumerable<string> ExtractFilePaths()
        {
                return Directory.GetFiles(WorkingDirectory, "*" + FileExtention);
        }

        public string ExtractData(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}