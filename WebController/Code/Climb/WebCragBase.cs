using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebController.Code.Climb
{
    public abstract class WebCragBase
    {
        protected string cragName;

        public String CragName { get => cragName; }


        public WebCragBase(string cragName)
        {
            this.cragName = cragName;
        }

    }

    class _27CragsCrag : WebCragBase
    {
        public _27CragsCrag(string cragName) : base(cragName)
        {
        }

    }
}
