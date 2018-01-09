using System.Collections.Generic;
using WebController.Code._27Crags;
using WebController.Code.Window;
using System.Linq;
using OpenQA.Selenium;
using System;

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



        public IEnumerable<Climb._27CragsClimb> GetClimbsOnPage()
        {
            var climbRowSelector = new WindowSelectorProperty() { Pattern = properties.ClimbRowSelector};

            var climbs = new List<Climb._27CragsClimb>();

            var pagination = new _27CragsPagination(window);

            do
            {
                var rows = window.FindAll(climbRowSelector);

                foreach (var row in rows)
               {
                   climbs.Add(GetClimb(row));
               }
            } while (pagination.HasPagination() && pagination.NextPage());


            return climbs;
        }

        private Climb._27CragsClimb GetClimb(IWebElement row)
        {
            var climb = new Climb._27CragsClimb();

            var climbNameSelector = new WindowSelectorProperty() { Pattern = properties.ClimbNameSelector };

            climb.Name = window.Find(climbNameSelector, row).Text;


            var climbGradeSelector = new WindowSelectorProperty() { Pattern = properties.ClimbGradeSelector };

            climb.Grade = window.Find(climbGradeSelector, row).Text;

            var climbSectorSelector = new WindowSelectorProperty() { Pattern = properties.ClimbSectorSelector };

            climb.Sector = window.Find(climbSectorSelector, row).Text;

            var climbTypeSelector = new WindowSelectorProperty() { Pattern = properties.ClimbTypeSelector };

            climb.Type = window.Find(climbTypeSelector, row).Text;

            return climb;

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

            return climbNames.Where(i => !string.IsNullOrWhiteSpace(i));
        }

    }

}
