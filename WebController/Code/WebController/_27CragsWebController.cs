using System.Collections.Generic;
using WebController.Code._27Crags;
using WebController.Code.Window;
using System.Linq;

namespace WebController.Code
{
    public class _27CragsWebController : WebControllerBase
    {
        _27CragsProperties properties = new _27CragsProperties();

        public _27CragsWebController(WindowBase windowBase) : base(windowBase)
        {
        }

        public void Cleanup()
        {
            window.Close();
        }

        public void GotoCragPage(string cragName)
        {
            window.GoTo(new WindowProperty() { Pattern = properties.GetCragUrl(cragName) });
        }

        public IEnumerable<string> GetClimbNames()
        {
            var climbNameArea = new WindowProperty() { Pattern = properties.ClimbNameSelector, SearchType = WindowPropertySearchType.Selector };

            var climbNames = window.GetTexts(climbNameArea).ToList();

            var pagination = new _27CragsPagination(window);

            if (pagination.HasPagination())
            {
                while (pagination.NextPage())
                {
                    climbNames = climbNames.Union(window.GetTexts(climbNameArea)).ToList();
                }
            }

            return climbNames;
        }

    }

}
