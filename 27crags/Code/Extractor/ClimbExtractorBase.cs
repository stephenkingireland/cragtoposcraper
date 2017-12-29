using _27crags.Code.Converter;

namespace _27crags.Code.Extractor
{
    public abstract class ClimbExtractorBase
    {
        protected IGradeConverter converter;

        public ClimbExtractorBase(IGradeConverter converter)
        {
            this.converter = converter;
        }
    }
}