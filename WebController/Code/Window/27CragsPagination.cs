using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebController.Code._27Crags;

namespace WebController.Code.Window
{
    public class _27CragsPagination : PaginationBase
    {
        _27CragsProperties properties = new _27CragsProperties();
        private IWebElement pagination;



        public _27CragsPagination(WindowBase window) : base(window)
        {
        }

        public override void GotoPage(string pageId)
        {
            var paginationSearch = new WindowProperty()
            { Pattern = properties.GetPaginationSelector((string) pageId), SearchType = WindowPropertySearchType.Selector };

            window.Click(paginationSearch);
        }

        public override bool HasPagination()
        {
            var paginationSearch = new WindowProperty()
            { Pattern = properties.GetPaginationSelector("0"), SearchType = WindowPropertySearchType.Selector };

            return window.Has(paginationSearch);

        }

        public override bool NextPage()
        {
            var paginationSearch = new WindowProperty()
            { Pattern = properties.GetPaginationSelector("0"), SearchType = WindowPropertySearchType.Selector };

            throw new NotImplementedException();
        }
    }
}
