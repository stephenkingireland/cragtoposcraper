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
            { Pattern = GetPaginationSelector((string) pageId), SearchType = WindowPropertySearchType.Selector };

            window.Click(paginationSearch);
        }

        public override bool HasPagination()
        {
            var paginationSearch = new WindowProperty()
            { Pattern = GetPaginationSelector("0"), SearchType = WindowPropertySearchType.Selector };


            var pagination = window.Has(paginationSearch);
            return pagination;

        }

        public override bool NextPage()
        {
            var activePaginationSearch = new WindowProperty()
            { Pattern = GetActivePaginationSelector(), SearchType = WindowPropertySearchType.Selector };

            var nextpageNumber = int.Parse(window.GetText(activePaginationSearch)) + 1;

            var nextPageId = nextpageNumber - 1;

            var nextPaginationSearch = new WindowProperty()
            { Pattern = GetPaginationSelector("" + nextPageId), SearchType = WindowPropertySearchType.Selector };

            if (window.Has(nextPaginationSearch))
            {
                window.Click(nextPaginationSearch);
                return true;
            }

            return false;
        }

        private string GetPaginationSelector(String paginationId)
        {
            return String.Format(".pagination [data-page='{0}']", paginationId);
        }


        private string GetActivePaginationSelector()
        {
            return ".pagination .active";
        }

    }
}
