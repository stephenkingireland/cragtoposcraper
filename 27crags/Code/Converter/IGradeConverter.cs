using System;

namespace _27crags.Code.Converter
{
    public interface IGradeConverter
    {
        string ConvertGrade(string gradeToConvert);
        bool HasGrade(string line);
        string GetGrade(string line);
        int GradePosition(String line, string grade);
    }

}
