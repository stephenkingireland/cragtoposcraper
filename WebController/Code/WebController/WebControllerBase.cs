using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

}
