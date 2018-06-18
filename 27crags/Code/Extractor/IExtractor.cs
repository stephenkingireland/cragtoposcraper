using System.Collections.Generic;

namespace _27crags.Code.Extractor
{
    public interface IFileExtractor
    {
        void SaveData(string data, string fileName);
        string ExtractData(string data);

        IEnumerable<string> ExtractFilePaths();

    }

    public interface IClimbExtractor
    {
        IEnumerable<Climb> ExtractClimbs(string climbData);
    }
}
