using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebController.Code._27Crags;
using WebController.Code.Climb;
using WebController.Code.Window;

namespace WebController.Code
{
    public abstract class WebControllerBase
    {
        protected WindowBase window;

        public WebControllerBase( WindowBase windowBase)
        {
            window = windowBase;
        }
    }

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

        public IEnumerable<string> GetClimbNames(string cragName)
        {
            window.GoTo(new WindowProperty() { Pattern = properties.GetCragUrl(cragName)});

            var climbNames = window.GetTexts(new WindowProperty { Pattern = properties.ClimbNameSelector, SearchType = WindowPropertySearchType.Selector });

            //var pages = GetPages();

           // if (pages.Count() > 1)
          //  {
           //     foreach(var page in pages)
          //      {
          //
          //      }
          //  }

            return climbNames;
        }

    }

}
