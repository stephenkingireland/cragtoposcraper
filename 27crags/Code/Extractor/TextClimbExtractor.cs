using _27crags.Code.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27crags.Code.Extractor
{
    public class TextClimbExtractor : ClimbExtractorBase, IClimbExtractor
    {
        private IGradeConverter converter;

        public TextClimbExtractor(IGradeConverter converter): base(converter)
        {
        }


        private string ExtractClimbName(string line, string grade)
        {
            var gradePos = converter.GradePosition(line, grade);

            return line.Substring(0, gradePos - 1);
        }

        public IEnumerable<Climb> ExtractClimbs(string climbData)
        {
            var climbs = new List<Climb>();

            foreach (var line in climbData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!converter.HasGrade(line))
                {
                    continue;
                }

                var grade = converter.GetGrade(line);

                var name = ExtractClimbName(line, grade);

                climbs.Add(new Climb { grade = grade, name = name });
            }

            return climbs;


        }

    }
}
