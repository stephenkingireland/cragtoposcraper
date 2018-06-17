using _27crags.Code.Converter;
using System;
using System.Collections.Generic;

namespace _27crags.Code.Extractor
{
    public class JsonClimbExtractor : ClimbExtractorBase, IClimbExtractor
    {
        public JsonClimbExtractor(IGradeConverter converter): base(converter)
        {
        }

        public IEnumerable<Climb> ExtractClimbs(string climbData)
        {
            var rawClimbs = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Climb>>(climbData);

            return ConvertClimbs(rawClimbs);
        }

        public IEnumerable<Climb> ConvertClimbs(IEnumerable<Climb> rawClimbs)
        {
            var convertedClimbs = new List<Climb>();

            foreach (var climb in rawClimbs)
            {
                var grade = converter.NormalizeGrade(climb.grade);

                if (climb.grade.StartsWith("f"))
                {
                    continue;
                }

                climb.frenchGrade = converter.ConvertGrade(grade);

                climb.grade = climb.grade.Replace("*", "").Trim();

                convertedClimbs.Add(climb);
            }

            return convertedClimbs;
        }
    }
}
